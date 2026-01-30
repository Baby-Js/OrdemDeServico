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
    public partial class TelaAparelho : UserControl
    {
        public TelaAparelho()
        {
            InitializeComponent();

            dgvAparelho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAparelho.MultiSelect = false;
            dgvAparelho.ReadOnly = true;
            dgvAparelho.AllowUserToAddRows = false;

        }

        private void TelaAparelho_Load(object sender, EventArgs e)
        {
            ListarAparelhos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (mskCpfAparelho.Text.Trim() == "")
            {
                MessageBox.Show("Digite um CPF para buscar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "SELECT id_cliente, nome FROM cliente WHERE cpf = @cpf";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cpf", mskCpfAparelho.Text.Trim());

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtClienteAparelho.Text = dr["nome"].ToString();
                    txtIdCliente.Text = dr["id_cliente"].ToString();
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClienteAparelho.Clear();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar cliente: " + ex.Message);
            }
        }

        private void ListarAparelhos()
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = @"SELECT a.id_aparelho, c.nome AS cliente, c.cpf, a.marca, a.modelo, a.numero_serie FROM aparelho a INNER JOIN cliente c ON c.id_cliente = a.id_cliente";

                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAparelho.DataSource = dt;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void Limpar()
        {
            mskCpfAparelho.Clear();
            txtClienteAparelho.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtNumSerie.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (mskCpfAparelho.Text == "")
            {
                MessageBox.Show("Busque um cliente pelo CPF antes de salvar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = @"INSERT INTO aparelho (id_cliente, marca, modelo, numero_serie) VALUES (@id_cliente, @marca, @modelo, @numero_serie)";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text);
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
                cmd.Parameters.AddWithValue("@numero_serie", txtNumSerie.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Aparelho cadastrado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarAparelhos();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdAparelho.Text))
            {
                MessageBox.Show("Selecione o aparelho que deseja editar.", "ERROR");
                return;
            }

            if (string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Busque ou selecione um cliente válido antes de editar.", "ERROR");
                return;
            }

            try
            {
                using (MySqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = @"UPDATE aparelho 
                             SET id_cliente=@id_cliente, marca=@marca, modelo=@modelo, 
                                 numero_serie=@numero_serie 
                             WHERE id_aparelho=@id_aparelho";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_cliente", Convert.ToInt32(txtIdCliente.Text));
                        cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
                        cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
                        cmd.Parameters.AddWithValue("@numero_serie", txtNumSerie.Text);
                        cmd.Parameters.AddWithValue("@id_aparelho", Convert.ToInt32(txtIdAparelho.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Aparelho atualizado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarAparelhos();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdAparelho.Text))
            {
                MessageBox.Show("Selecione o aparelho que deseja excluir.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("Tem certeza que deseja excluir este aparelho?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection con = Conexao.GetConnection())
                {
                    con.Open();

                    string query = "DELETE FROM aparelho WHERE id_aparelho=@id_aparelho";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id_aparelho", Convert.ToInt32(txtIdAparelho.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Aparelho excluído!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarAparelhos();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void dgvAparelho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {            
                DataGridViewRow row = dgvAparelho.Rows[e.RowIndex];

                txtIdAparelho.Text = row.Cells["id_aparelho"].Value?.ToString() ?? "";
                txtClienteAparelho.Text = row.Cells["cliente"].Value?.ToString() ?? "";
                mskCpfAparelho.Text = row.Cells["cpf"].Value?.ToString() ?? "";
                txtMarca.Text = row.Cells["marca"].Value?.ToString() ?? "";
                txtModelo.Text = row.Cells["modelo"].Value?.ToString() ?? "";
                txtNumSerie.Text = row.Cells["numero_serie"].Value?.ToString() ?? "";

                BuscarClientePorCpfSilencioso();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar linha: " + ex.Message);
            }
        }

        private void BuscarClientePorCpfSilencioso()
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "SELECT id_cliente, nome FROM cliente WHERE cpf = @cpf";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@cpf", mskCpfAparelho.Text.Trim());
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtClienteAparelho.Text = dr["nome"].ToString();
                    txtIdCliente.Text = dr["id_cliente"].ToString();
                }

                con.Close();
            }
            catch { }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }
    }
}
