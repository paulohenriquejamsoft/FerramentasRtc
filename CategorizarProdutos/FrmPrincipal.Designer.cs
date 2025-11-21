namespace CategorizarProdutos
{
    partial class FrmPrincipal
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblConexao = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConectar = new System.Windows.Forms.Button();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnFerramentas = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportarProdComAnexo = new System.Windows.Forms.Button();
            this.btnNaturezaTributacao = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnFerramentas.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 47);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(226, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categorização de CBS/IBS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CategorizarProdutos.Properties.Resources.jamsoft;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblConexao);
            this.groupBox1.Controls.Add(this.txtBanco);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 147);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados de Conexão";
            // 
            // lblConexao
            // 
            this.lblConexao.AutoSize = true;
            this.lblConexao.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblConexao.Location = new System.Drawing.Point(410, 101);
            this.lblConexao.Name = "lblConexao";
            this.lblConexao.Size = new System.Drawing.Size(29, 19);
            this.lblConexao.TabIndex = 9;
            this.lblConexao.Text = "     ";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(10, 103);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(202, 25);
            this.txtBanco.TabIndex = 8;
            this.txtBanco.Text = "VarejoReformaTrib";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Banco";
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.Red;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.Image = global::CategorizarProdutos.Properties.Resources.Disconnected;
            this.btnConectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConectar.Location = new System.Drawing.Point(247, 92);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(152, 36);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(484, 48);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(202, 25);
            this.txtSenha.TabIndex = 5;
            this.txtSenha.Text = "#j@msoft1310*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(484, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(247, 48);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(202, 25);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(247, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuário";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(10, 48);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(202, 25);
            this.txtServidor.TabIndex = 1;
            this.txtServidor.Text = "192.168.0.167\\sistemas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Servidor";
            // 
            // pnFerramentas
            // 
            this.pnFerramentas.Controls.Add(this.groupBox2);
            this.pnFerramentas.Location = new System.Drawing.Point(0, 207);
            this.pnFerramentas.Name = "pnFerramentas";
            this.pnFerramentas.Size = new System.Drawing.Size(695, 179);
            this.pnFerramentas.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportarProdComAnexo);
            this.groupBox2.Controls.Add(this.btnNaturezaTributacao);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 134);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ferramentas";
            // 
            // btnExportarProdComAnexo
            // 
            this.btnExportarProdComAnexo.Location = new System.Drawing.Point(309, 35);
            this.btnExportarProdComAnexo.Name = "btnExportarProdComAnexo";
            this.btnExportarProdComAnexo.Size = new System.Drawing.Size(156, 41);
            this.btnExportarProdComAnexo.TabIndex = 1;
            this.btnExportarProdComAnexo.Text = "Exportar Produtos";
            this.btnExportarProdComAnexo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarProdComAnexo.UseVisualStyleBackColor = true;
            this.btnExportarProdComAnexo.Click += new System.EventHandler(this.btnExportarProdComAnexo_Click);
            // 
            // btnNaturezaTributacao
            // 
            this.btnNaturezaTributacao.Location = new System.Drawing.Point(10, 35);
            this.btnNaturezaTributacao.Name = "btnNaturezaTributacao";
            this.btnNaturezaTributacao.Size = new System.Drawing.Size(293, 41);
            this.btnNaturezaTributacao.TabIndex = 0;
            this.btnNaturezaTributacao.Text = "Naturezas x Tributação Fiscal (CBS/IBS)";
            this.btnNaturezaTributacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNaturezaTributacao.UseVisualStyleBackColor = true;
            this.btnNaturezaTributacao.Click += new System.EventHandler(this.btnNaturezaTributacao_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.Color.Red;
            this.lblVersao.Location = new System.Drawing.Point(3, 396);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(87, 15);
            this.lblVersao.TabIndex = 3;
            this.lblVersao.Text = "Versão: 0.0.0.0";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 420);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.pnFerramentas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "Reforma Tributária";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnFerramentas.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Panel pnFerramentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNaturezaTributacao;
        private System.Windows.Forms.Button btnExportarProdComAnexo;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label lblConexao;
    }
}

