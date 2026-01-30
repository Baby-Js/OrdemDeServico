namespace Ordens_de_Serviço
{
    partial class TelaOS
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscarAparelho = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdAparelho = new System.Windows.Forms.TextBox();
            this.txtClienteAparelho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAparelho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDefRelatado = new System.Windows.Forms.TextBox();
            this.txtDefConstatado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolucao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dgvOS = new System.Windows.Forms.DataGridView();
            this.txtIdOS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de Clientes";
            // 
            // btnBuscarAparelho
            // 
            this.btnBuscarAparelho.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarAparelho.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAparelho.Location = new System.Drawing.Point(236, 128);
            this.btnBuscarAparelho.Name = "btnBuscarAparelho";
            this.btnBuscarAparelho.Size = new System.Drawing.Size(99, 34);
            this.btnBuscarAparelho.TabIndex = 34;
            this.btnBuscarAparelho.Text = "Buscar";
            this.btnBuscarAparelho.UseVisualStyleBackColor = true;
            this.btnBuscarAparelho.Click += new System.EventHandler(this.btnBuscarAparelho_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "ID do Aparelho:";
            // 
            // txtIdAparelho
            // 
            this.txtIdAparelho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdAparelho.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdAparelho.Location = new System.Drawing.Point(68, 133);
            this.txtIdAparelho.Name = "txtIdAparelho";
            this.txtIdAparelho.Size = new System.Drawing.Size(162, 26);
            this.txtIdAparelho.TabIndex = 35;
            // 
            // txtClienteAparelho
            // 
            this.txtClienteAparelho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClienteAparelho.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClienteAparelho.Location = new System.Drawing.Point(68, 188);
            this.txtClienteAparelho.Name = "txtClienteAparelho";
            this.txtClienteAparelho.Size = new System.Drawing.Size(244, 26);
            this.txtClienteAparelho.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Cliente:";
            // 
            // txtAparelho
            // 
            this.txtAparelho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAparelho.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAparelho.Location = new System.Drawing.Point(327, 188);
            this.txtAparelho.Name = "txtAparelho";
            this.txtAparelho.Size = new System.Drawing.Size(256, 26);
            this.txtAparelho.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Modelo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(589, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Defeito Relatado:";
            // 
            // txtDefRelatado
            // 
            this.txtDefRelatado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefRelatado.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefRelatado.Location = new System.Drawing.Point(593, 188);
            this.txtDefRelatado.Multiline = true;
            this.txtDefRelatado.Name = "txtDefRelatado";
            this.txtDefRelatado.Size = new System.Drawing.Size(256, 26);
            this.txtDefRelatado.TabIndex = 47;
            // 
            // txtDefConstatado
            // 
            this.txtDefConstatado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefConstatado.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefConstatado.Location = new System.Drawing.Point(68, 246);
            this.txtDefConstatado.Multiline = true;
            this.txtDefConstatado.Name = "txtDefConstatado";
            this.txtDefConstatado.Size = new System.Drawing.Size(244, 26);
            this.txtDefConstatado.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "Defeito Constatado:";
            // 
            // txtSolucao
            // 
            this.txtSolucao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSolucao.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSolucao.Location = new System.Drawing.Point(327, 246);
            this.txtSolucao.Multiline = true;
            this.txtSolucao.Name = "txtSolucao";
            this.txtSolucao.Size = new System.Drawing.Size(256, 26);
            this.txtSolucao.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 20);
            this.label7.TabIndex = 50;
            this.label7.Text = "Defeito Constatado:";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTotal.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(593, 246);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(256, 26);
            this.txtValorTotal.TabIndex = 53;
            this.txtValorTotal.Text = "R$ ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(589, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "Valor Total:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(592, 278);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(99, 34);
            this.btnLimpar.TabIndex = 57;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExcluir.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(479, 278);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(99, 34);
            this.btnExcluir.TabIndex = 56;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(363, 278);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(99, 34);
            this.btnEditar.TabIndex = 55;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Font = new System.Drawing.Font("Modern No. 20", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(249, 278);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(99, 34);
            this.btnSalvar.TabIndex = 54;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // dgvOS
            // 
            this.dgvOS.AllowUserToAddRows = false;
            this.dgvOS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOS.Location = new System.Drawing.Point(29, 335);
            this.dgvOS.Name = "dgvOS";
            this.dgvOS.ReadOnly = true;
            this.dgvOS.RowHeadersVisible = false;
            this.dgvOS.RowHeadersWidth = 51;
            this.dgvOS.RowTemplate.Height = 24;
            this.dgvOS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOS.Size = new System.Drawing.Size(873, 293);
            this.dgvOS.TabIndex = 58;
            this.dgvOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOS_CellContentClick);
            // 
            // txtIdOS
            // 
            this.txtIdOS.AutoSize = true;
            this.txtIdOS.Location = new System.Drawing.Point(98, 435);
            this.txtIdOS.Name = "txtIdOS";
            this.txtIdOS.Size = new System.Drawing.Size(44, 16);
            this.txtIdOS.TabIndex = 59;
            this.txtIdOS.Text = "label9";
            // 
            // TelaOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvOS);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSolucao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDefConstatado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDefRelatado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAparelho);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClienteAparelho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdAparelho);
            this.Controls.Add(this.btnBuscarAparelho);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdOS);
            this.Name = "TelaOS";
            this.Size = new System.Drawing.Size(940, 647);
            this.Load += new System.EventHandler(this.TelaOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarAparelho;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdAparelho;
        private System.Windows.Forms.TextBox txtClienteAparelho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAparelho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDefRelatado;
        private System.Windows.Forms.TextBox txtDefConstatado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSolucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvOS;
        private System.Windows.Forms.Label txtIdOS;
    }
}
