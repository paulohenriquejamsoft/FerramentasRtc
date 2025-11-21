namespace CategorizarProdutos
{
    partial class FrmImportarClassificacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLinkModelo = new System.Windows.Forms.LinkLabel();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblArquivoImportacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTributacoes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.pnClassificacao = new System.Windows.Forms.Panel();
            this.dtGridNaturezas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.pnClassificacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridNaturezas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.btnFechar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 47);
            this.panel1.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::CategorizarProdutos.Properties.Resources.Close;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Location = new System.Drawing.Point(978, 9);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(27, 28);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(292, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Importar Classificação";
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lblLinkModelo);
            this.groupBox1.Controls.Add(this.btnImportar);
            this.groupBox1.Controls.Add(this.lblArquivoImportacao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(985, 81);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arquivos XLSx";
            // 
            // lblLinkModelo
            // 
            this.lblLinkModelo.AutoSize = true;
            this.lblLinkModelo.Location = new System.Drawing.Point(864, 35);
            this.lblLinkModelo.Name = "lblLinkModelo";
            this.lblLinkModelo.Size = new System.Drawing.Size(71, 19);
            this.lblLinkModelo.TabIndex = 4;
            this.lblLinkModelo.TabStop = true;
            this.lblLinkModelo.Text = "Template";
            this.lblLinkModelo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLinkModelo_LinkClicked);
            // 
            // btnImportar
            // 
            this.btnImportar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.Location = new System.Drawing.Point(706, 30);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 29);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "...";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblArquivoImportacao
            // 
            this.lblArquivoImportacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivoImportacao.Location = new System.Drawing.Point(85, 30);
            this.lblArquivoImportacao.Name = "lblArquivoImportacao";
            this.lblArquivoImportacao.ReadOnly = true;
            this.lblArquivoImportacao.Size = new System.Drawing.Size(610, 29);
            this.lblArquivoImportacao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selecione: ";
            // 
            // cbTributacoes
            // 
            this.cbTributacoes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTributacoes.FormattingEnabled = true;
            this.cbTributacoes.Location = new System.Drawing.Point(3, 341);
            this.cbTributacoes.Name = "cbTributacoes";
            this.cbTributacoes.Size = new System.Drawing.Size(662, 29);
            this.cbTributacoes.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Regra Operação Fiscal/Tributação";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.Red;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Image = global::CategorizarProdutos.Properties.Resources.Synchronize;
            this.btnAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAtualizar.Location = new System.Drawing.Point(709, 328);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(112, 42);
            this.btnAtualizar.TabIndex = 7;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // pnClassificacao
            // 
            this.pnClassificacao.Controls.Add(this.dtGridNaturezas);
            this.pnClassificacao.Controls.Add(this.cbTributacoes);
            this.pnClassificacao.Controls.Add(this.btnAtualizar);
            this.pnClassificacao.Controls.Add(this.label2);
            this.pnClassificacao.Enabled = false;
            this.pnClassificacao.Location = new System.Drawing.Point(12, 140);
            this.pnClassificacao.Name = "pnClassificacao";
            this.pnClassificacao.Size = new System.Drawing.Size(985, 406);
            this.pnClassificacao.TabIndex = 8;
            // 
            // dtGridNaturezas
            // 
            this.dtGridNaturezas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridNaturezas.Location = new System.Drawing.Point(0, 4);
            this.dtGridNaturezas.MultiSelect = false;
            this.dtGridNaturezas.Name = "dtGridNaturezas";
            this.dtGridNaturezas.Size = new System.Drawing.Size(985, 293);
            this.dtGridNaturezas.TabIndex = 4;
            // 
            // FrmImportarClassificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 599);
            this.Controls.Add(this.pnClassificacao);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmImportarClassificacao";
            this.Text = "FrmNaturezaTributacao";
            this.Load += new System.EventHandler(this.FrmImportarClassificacao_Load);
            this.Shown += new System.EventHandler(this.FrmImportarClassificacao_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnClassificacao.ResumeLayout(false);
            this.pnClassificacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridNaturezas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTributacoes;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblArquivoImportacao;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.LinkLabel lblLinkModelo;
        private System.Windows.Forms.Panel pnClassificacao;
        private System.Windows.Forms.DataGridView dtGridNaturezas;
    }
}