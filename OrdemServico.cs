using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx;

namespace Ordens_de_Serviço
{
    public partial class OrdemServico : UserControl
    {
        public OrdemServico()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdAparelho.Text))
            {
                MessageBox.Show("Digite um ID de aparelho.");
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = @"SELECT a.marca, a.modelo, c.nome AS cliente FROM Aparelho a INNER JOIN Cliente c ON c.id_cliente = a.id_cliente WHERE a.id_aparelho = @id_aparelho";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_aparelho", txtIdAparelho.Text);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtCliente.Text = dr["cliente"].ToString();
                    txtModelo.Text = dr["modelo"].ToString();
                }
                else
                {
                    MessageBox.Show("Aparelho não encontrado.");
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar aparelho:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarOS()
        {
            try
            {
                using (var con = Conexao.GetConnection())
                {
                    con.Open();

                    string sql = @"SELECT os.id_os, os.data_abertura, os.data_fechamento, os.status, os.valor_total, ap.modelo FROM OS os LEFT JOIN Aparelho ap ON ap.id_aparelho = os.id_aparelho ORDER BY os.id_os DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOS.DataSource = dt;

                    if (dgvOS.Columns.Contains("id_os")) dgvOS.Columns["id_os"].HeaderText = "Nº OS";
                    if (dgvOS.Columns.Contains("data_abertura")) dgvOS.Columns["data_abertura"].HeaderText = "Abertura";
                    if (dgvOS.Columns.Contains("data_fechamento")) dgvOS.Columns["data_fechamento"].HeaderText = "Fechamento";
                    if (dgvOS.Columns.Contains("valor_total")) dgvOS.Columns["valor_total"].HeaderText = "Valor";

                    dgvOS.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar OS:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtIdAparelho.Text))
                {
                    MessageBox.Show("Informe o ID do aparelho antes de salvar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDefeitoRelatado.Text))
                {
                    MessageBox.Show("O defeito relatado é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var con = Conexao.GetConnection())
                {
                    con.Open();

                    string sql = @"INSERT INTO OS (id_aparelho, defeito_relatado, defeito_constatado, solucao_realizada, valor_total, status) VALUES (@id_aparelho, @relatado, @constatado, @solucao, @valor, 'Analise')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id_aparelho", txtIdAparelho.Text.Trim());
                        cmd.Parameters.AddWithValue("@relatado", txtDefeitoRelatado.Text.Trim());
                        cmd.Parameters.AddWithValue("@constatado", txtDefeitoConstatado.Text.Trim());
                        cmd.Parameters.AddWithValue("@solucao", txtSolucao.Text.Trim());

                        decimal valor = 0m;
                        if (!string.IsNullOrWhiteSpace(txtValor.Text))
                        {
                            decimal.TryParse(txtValor.Text, out valor);
                        }

                        cmd.Parameters.AddWithValue("@valor", valor);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("OS salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarOS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar OS:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOS_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvOS.Rows[e.RowIndex];
                if (row.Cells["id_os"].Value == null) return;

                int idOs = Convert.ToInt32(row.Cells["id_os"].Value);

                using (var con = Conexao.GetConnection())
                {
                    con.Open();

                    string sql = @"SELECT os.*, ap.cliente, ap.modelo FROM OS os LEFT JOIN Aparelho ap ON ap.id_aparelho = os.id_aparelho WHERE os.id_os = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idOs);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtIdAparelho.Text = reader["id_aparelho"]?.ToString();
                                txtCliente.Text = reader["cliente"]?.ToString();
                                txtModelo.Text = reader["modelo"]?.ToString();
                                txtDefeitoRelatado.Text = reader["defeito_relatado"]?.ToString();
                                txtDefeitoConstatado.Text = reader["defeito_constatado"]?.ToString();
                                txtSolucao.Text = reader["solucao_realizada"]?.ToString();
                                txtValor.Text = reader["valor_total"]?.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar OS:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            AlterarStatusSelecionada("Conserto", false);
        }

        private void btnConcluido_Click(object sender, EventArgs e)
        {
            AlterarStatusSelecionada("Finalizado", true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOS.SelectedRows.Count == 0 && string.IsNullOrWhiteSpace(txtIdAparelho.Text))
                {
                    MessageBox.Show("Selecione uma OS na lista ou preencha os campos para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idOs = -1;
                if (dgvOS.SelectedRows.Count > 0)
                {
                    var cell = dgvOS.SelectedRows[0].Cells["id_os"];
                    if (cell != null && cell.Value != null)
                        int.TryParse(cell.Value.ToString(), out idOs);
                }

                if (idOs == -1 && !string.IsNullOrWhiteSpace(txtIdAparelho.Text))
                {
                    MessageBox.Show("Selecione uma OS na lista para editar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (idOs <= 0)
                {
                    MessageBox.Show("ID da OS inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var con = Conexao.GetConnection())
                {
                    con.Open();

                    string sql = @"UPDATE OS SET defeito_relatado = @relatado, defeito_constatado = @constatado, solucao_realizada = @solucao, valor_total = @valor WHERE id_os = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@relatado", txtDefeitoRelatado.Text.Trim());
                        cmd.Parameters.AddWithValue("@constatado", txtDefeitoConstatado.Text.Trim());
                        cmd.Parameters.AddWithValue("@solucao", txtSolucao.Text.Trim());

                        decimal valor = 0m;
                        if (!string.IsNullOrWhiteSpace(txtValor.Text)) decimal.TryParse(txtValor.Text, out valor);
                        cmd.Parameters.AddWithValue("@valor", valor);

                        cmd.Parameters.AddWithValue("@id", idOs);

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("OS atualizada com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarOS();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar OS:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione a OS que deseja excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dr = MessageBox.Show("Tem certeza que deseja excluir a OS selecionada?", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                var cell = dgvOS.SelectedRows[0].Cells["id_os"];
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("Não foi possível identificar a OS selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idOs = Convert.ToInt32(cell.Value);

                using (var con = Conexao.GetConnection())
                {
                    con.Open();
                    string sql = "DELETE FROM OS WHERE id_os = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", idOs);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("OS excluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarOS();
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir OS:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
                txtIdAparelho.Clear();
                txtCliente.Clear();
                txtModelo.Clear();
                txtDefeitoRelatado.Clear();
                txtDefeitoConstatado.Clear();
                txtSolucao.Clear();
                txtValor.Clear();
        }

        private void AlterarStatusSelecionada(string novoStatus, bool setarDataFechamento)
        {
            try
            {
                if (dgvOS.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecione uma OS na lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cell = dgvOS.SelectedRows[0].Cells["id_os"];
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("Não foi possível identificar a OS selecionada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idOs = Convert.ToInt32(cell.Value);

                using (var con = Conexao.GetConnection())
                {
                    con.Open();

                    string sql = setarDataFechamento ? "UPDATE OS SET status = @status, data_fechamento = NOW() WHERE id_os = @id" : "UPDATE OS SET status = @status WHERE id_os = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@status", novoStatus);
                        cmd.Parameters.AddWithValue("@id", idOs);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Status atualizado para: " + novoStatus, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarOS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar status:" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

