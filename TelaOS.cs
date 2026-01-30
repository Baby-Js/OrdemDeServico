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

namespace Ordens_de_Serviço
{
    public partial class TelaOS : UserControl
    {
        public TelaOS()
        {
            InitializeComponent();
        }

        private void TelaOS_Load(object sender, EventArgs e)
        {
            ListarOS();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (!dgvOS.Columns.Contains("btnIniciar"))
            {
                DataGridViewButtonColumn iniciar = new DataGridViewButtonColumn();
                iniciar.Name = "btnIniciar";
                iniciar.HeaderText = "Iniciar";
                iniciar.Text = "Iniciar";
                iniciar.UseColumnTextForButtonValue = true;
                dgvOS.Columns.Add(iniciar);
            }

            if (!dgvOS.Columns.Contains("btnFinalizar"))
            {
                DataGridViewButtonColumn finalizar = new DataGridViewButtonColumn();
                finalizar.Name = "btnFinalizar";
                finalizar.HeaderText = "Finalizar";
                finalizar.Text = "Finalizar";
                finalizar.UseColumnTextForButtonValue = true;
                dgvOS.Columns.Add(finalizar);
            }
        }

        private void ListarOS()
        {
            try
            {
                using (MySqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = @"SELECT o.id_os,
                                    o.id_aparelho,
                                    c.nome AS cliente,
                                    CONCAT(a.marca, ' / ', a.modelo) AS aparelho,
                                    o.status,
                                    o.data_abertura,
                                    o.data_fechamento,
                                    o.valor_total,
                                    o.defeito_relatado,
                                    o.defeito_constatado,
                                    o.solucao_realizada
                             FROM OS o
                             INNER JOIN aparelho a ON a.id_aparelho = o.id_aparelho
                             INNER JOIN cliente c ON c.id_cliente = a.id_cliente
                             ORDER BY o.data_abertura DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvOS.DataSource = dt;

                    if (dgvOS.Columns.Contains("id_os"))
                    {
                        dgvOS.Columns["id_os"].HeaderText = "ID OS";
                    }
                    if (dgvOS.Columns.Contains("id_aparelho"))
                    {
                        dgvOS.Columns["id_aparelho"].HeaderText = "ID Aparelho";
                    }
                    if (dgvOS.Columns.Contains("cliente"))
                    {
                        dgvOS.Columns["cliente"].HeaderText = "Cliente";
                    }
                    if (dgvOS.Columns.Contains("aparelho"))
                    {
                        dgvOS.Columns["aparelho"].HeaderText = "Aparelho";
                    }

                    AtualizarVisibilidadeBotoes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar OS: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarVisibilidadeBotoes()
        {
            foreach (DataGridViewRow row in dgvOS.Rows)
            {
                if (row.Cells["status"].Value == null) continue;
                string status = row.Cells["status"].Value.ToString();

                row.Cells["btnIniciar"].ReadOnly = true;
                row.Cells["btnFinalizar"].ReadOnly = true;

                if (status == "Analise")
                {
                    row.Cells["btnIniciar"].Style.BackColor = System.Drawing.Color.LightGreen;
                    row.Cells["btnFinalizar"].Style.BackColor = System.Drawing.Color.LightGray;
                }
                else if (status == "Conserto")
                {
                    row.Cells["btnIniciar"].Style.BackColor = System.Drawing.Color.LightGray;
                    row.Cells["btnFinalizar"].Style.BackColor = System.Drawing.Color.LightYellow;
                }
                else
                {
                    row.Cells["btnIniciar"].Style.BackColor = System.Drawing.Color.LightGray;
                    row.Cells["btnFinalizar"].Style.BackColor = System.Drawing.Color.LightGray;
                }
            }
        }

        private void Limpar()
        {
            txtIdAparelho.Clear();
            txtDefRelatado.Clear();
            txtDefConstatado.Clear();
            txtSolucao.Clear();
            txtValorTotal.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdAparelho.Text == "")
                {
                    MessageBox.Show("Selecione um aparelho!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "INSERT INTO OS (id_aparelho, defeito_relatado, defeito_constatado, solucao_realizada, valor_total) " +
                               "VALUES (@id_aparelho, @dr, @dc, @solucao, @valor)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id_aparelho", txtIdAparelho.Text);
                cmd.Parameters.AddWithValue("@dr", txtDefRelatado.Text);
                cmd.Parameters.AddWithValue("@dc", txtDefConstatado.Text);
                cmd.Parameters.AddWithValue("@solucao", txtSolucao.Text);
                cmd.Parameters.AddWithValue("@valor", txtValorTotal.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("OS salva!", "SUCESSO");
                ListarOS();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar OS: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtIdOS.Text == "")
            {
                MessageBox.Show("Selecione uma OS!", "ERRO");
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "UPDATE OS SET defeito_relatado=@dr, defeito_constatado=@dc, solucao_realizada=@solucao, valor_total=@valor " +
                               "WHERE id_os=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", txtIdOS.Text);
                cmd.Parameters.AddWithValue("@dr", txtDefRelatado.Text);
                cmd.Parameters.AddWithValue("@dc", txtDefConstatado.Text);
                cmd.Parameters.AddWithValue("@solucao", txtSolucao.Text);
                cmd.Parameters.AddWithValue("@valor", txtValorTotal.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("OS editada!");
                ListarOS();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar OS: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdOS.Text == "")
            {
                MessageBox.Show("Selecione uma OS!");
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "DELETE FROM OS WHERE id_os=@id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", txtIdOS.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("OS excluída!");

                ListarOS();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir OS: " + ex.Message);
            }
        }

        private void btnBuscarAparelho_Click(object sender, EventArgs e)
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
                    txtClienteAparelho.Text = dr["cliente"].ToString();
                    txtAparelho.Text = dr["modelo"].ToString();
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
                MessageBox.Show("Erro ao buscar aparelho: " + ex.Message);
            }
        }

        private void dgvOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOS.Columns["btnIniciar"].Index)
            {
                string status = dgvOS.Rows[e.RowIndex].Cells["status"].Value.ToString();
                string id = dgvOS.Rows[e.RowIndex].Cells["id_os"].Value.ToString();

                if (status == "Analise")
                {
                    AtualizarStatus(id, "Conserto");
                }
            }

            if (e.ColumnIndex == dgvOS.Columns["btnFinalizar"].Index)
            {
                string status = dgvOS.Rows[e.RowIndex].Cells["status"].Value.ToString();
                string id = dgvOS.Rows[e.RowIndex].Cells["id_os"].Value.ToString();

                if (status == "Conserto")
                {
                    FinalizarOS(id);
                }
            }
        }

        private void AtualizarStatus(string id, string status)
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "UPDATE OS SET status=@s WHERE id_os=@id";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                con.Close();
                ListarOS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar status: " + ex.Message);
            }
        }

        private void FinalizarOS(string id)
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "UPDATE OS SET status='Finalizado', data_fechamento=NOW() WHERE id_os=@id";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                con.Close();
                ListarOS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar OS: " + ex.Message);
            }
        }
    }
    
}
