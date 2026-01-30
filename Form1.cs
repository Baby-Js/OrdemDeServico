using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordens_de_Serviço
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text) || string.IsNullOrEmpty(senha.Text))
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (login.Text == "ServicePoint" && senha.Text == "1234")
            {
                // tentei fazer samerda nn ter aquela desgrama de deley p abrir a outra tela
                // consegui?! nn, só aparece um milésimo de segundo mais rápido
                // pq a PORRA do Windows Forms é uma DESGRACEIRA e nn funciona como eu quero
                Form2 f2 = new Form2();
                this.Hide();  
                f2.Show();     
                f2.FormClosed += (s, args) => Application.Exit();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // esses três pra baixo é só trem p usar a tecla ENTER e nn precisar ficar usando o maouse pra clicar nos trem q precisa

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            // permite usar o ENTER p ir pro campo de senha, tipo, digita o login e aperta ENTER e
            // automaticamente vai para o campo de senha
            if (e.KeyCode == Keys.Enter)
            {
                senha.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void login_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null; // desativa o botão entrar, pois desta forma quando se aperta o ENTER
                                      // nn executa o código do botão, evitando o erro de "campo vazio" por ainda nn ter
                                      // colocado a senha, ent vai direto pro textBox da senha
        }

        private void senha_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = entrar; // ativa o botão entrar, pois desta forma quando se aperta o ENTER
                                        // executa o código do botão
        }
    }
}
