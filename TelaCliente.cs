using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ordens_de_Serviço
{
    public partial class TelaCliente : UserControl
    {
        public TelaCliente()
        {
            InitializeComponent();
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            ListarClientes();
        }

        private void ListarClientes()
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "SELECT * FROM Cliente";
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClientes.DataSource = dt;
                
                dgvClientes.Columns[0].Name = "id_cliente";
                dgvClientes.Columns[0].HeaderText = "ID Cliente";
                dgvClientes.Columns[0].DataPropertyName = "id_cliente";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar Cliente: " + ex.Message);
            }
        }

        private void Limpar()
        {
            txtNome.Clear();
            mskCpf.Clear();
            txtEmail.Clear();
            mskTel.Clear();
            txtEndereco.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "INSERT INTO Cliente (nome, cpf, email, telefone, endereco) VALUES (@nome, @cpf, @email, @telefone, @endereco)";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", mskCpf.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@telefone", mskTel.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cliente salvo com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListarClientes();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar cliente: " + ex.Message);

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleciona o cliente que deseja editar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "UPDATE Cliente SET nome=@nome, cpf=@cpf, email=@email, telefone=@telefone, endereco=@endereco WHERE id_cliente = @id_cliente";

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id_cliente", Convert.ToInt32(dgvClientes.CurrentRow.Cells["id_cliente"].Value));
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@cpf", mskCpf.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@telefone", mskTel.Text);
                cmd.Parameters.AddWithValue("@endereco", txtEndereco.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cliente editado com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarClientes();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar cliente: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleciona o cliente que deseja excluir.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MySqlConnection con = Conexao.GetConnection();
                con.Open();

                string query = "DELETE FROM Cliente WHERE id_cliente=@id_cliente";
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id_cliente", Convert.ToInt32(dgvClientes.CurrentRow.Cells["id_cliente"].Value));

                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Cliente excluído com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarClientes();
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente: "+ ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                mskCpf.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                mskTel.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtEndereco.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }
    }
}
