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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // encerra todo o programa ao clicar no "X", agora SAMERDA DESGRAMEIRA
                                // nn vai ficar rodando em 2º plano e surtando td mundo pq nn fechou direito,
                                // nem pra ser um bicho de sete cabeças, é uma merda simples dessa dando trabalheira, ÓDIO viu
        }

        private void AbrirTela(UserControl tela)
        {
            panel.Controls.Clear();
            tela.Dock = DockStyle.Fill;
            panel.Controls.Add(tela);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirTela(new TelaCliente());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AbrirTela(new TelaAparelho());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AbrirTela(new OrdemServico());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
