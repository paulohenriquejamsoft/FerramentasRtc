namespace CategorizarProdutos
{
    partial class FrmExportarProdutos
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
            this.rdTempComeSemAnexoeClassifPadrao = new System.Windows.Forms.RadioButton();
            this.rdTempProdSemClassificacao = new System.Windows.Forms.RadioButton();
            this.rdTempComeSemAnexo = new System.Windows.Forms.RadioButton();
            this.rdTempProdComAnexo = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(800, 47);
            this.panel1.TabIndex = 3;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::CategorizarProdutos.Properties.Resources.Close;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Location = new System.Drawing.Point(766, 10);
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
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Exportar Produtos";
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
            this.groupBox1.Controls.Add(this.rdTempComeSemAnexoeClassifPadrao);
            this.groupBox1.Controls.Add(this.rdTempProdSemClassificacao);
            this.groupBox1.Controls.Add(this.rdTempComeSemAnexo);
            this.groupBox1.Controls.Add(this.rdTempProdComAnexo);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 96);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template";
            // 
            // rdTempComeSemAnexoeClassifPadrao
            // 
            this.rdTempComeSemAnexoeClassifPadrao.AutoSize = true;
            this.rdTempComeSemAnexoeClassifPadrao.Location = new System.Drawing.Point(4, 54);
            this.rdTempComeSemAnexoeClassifPadrao.Name = "rdTempComeSemAnexoeClassifPadrao";
            this.rdTempComeSemAnexoeClassifPadrao.Size = new System.Drawing.Size(270, 23);
            this.rdTempComeSemAnexoeClassifPadrao.TabIndex = 3;
            this.rdTempComeSemAnexoeClassifPadrao.Text = "Com e Sem Anexo +  Classif. Padrão";
            this.rdTempComeSemAnexoeClassifPadrao.UseVisualStyleBackColor = true;
            // 
            // rdTempProdSemClassificacao
            // 
            this.rdTempProdSemClassificacao.AutoSize = true;
            this.rdTempProdSemClassificacao.Location = new System.Drawing.Point(285, 54);
            this.rdTempProdSemClassificacao.Name = "rdTempProdSemClassificacao";
            this.rdTempProdSemClassificacao.Size = new System.Drawing.Size(127, 23);
            this.rdTempProdSemClassificacao.TabIndex = 2;
            this.rdTempProdSemClassificacao.TabStop = true;
            this.rdTempProdSemClassificacao.Text = "Sem Classificar";
            this.rdTempProdSemClassificacao.UseVisualStyleBackColor = true;
            // 
            // rdTempComeSemAnexo
            // 
            this.rdTempComeSemAnexo.AutoSize = true;
            this.rdTempComeSemAnexo.Location = new System.Drawing.Point(285, 25);
            this.rdTempComeSemAnexo.Name = "rdTempComeSemAnexo";
            this.rdTempComeSemAnexo.Size = new System.Drawing.Size(156, 23);
            this.rdTempComeSemAnexo.TabIndex = 1;
            this.rdTempComeSemAnexo.TabStop = true;
            this.rdTempComeSemAnexo.Text = "Com e Sem Anexos";
            this.rdTempComeSemAnexo.UseVisualStyleBackColor = true;
            // 
            // rdTempProdComAnexo
            // 
            this.rdTempProdComAnexo.AutoSize = true;
            this.rdTempProdComAnexo.Checked = true;
            this.rdTempProdComAnexo.Location = new System.Drawing.Point(7, 25);
            this.rdTempProdComAnexo.Name = "rdTempProdComAnexo";
            this.rdTempProdComAnexo.Size = new System.Drawing.Size(172, 23);
            this.rdTempProdComAnexo.TabIndex = 0;
            this.rdTempProdComAnexo.TabStop = true;
            this.rdTempProdComAnexo.Text = "Somente com Anexos";
            this.rdTempProdComAnexo.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Red;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Image = global::CategorizarProdutos.Properties.Resources.Synchronize;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(552, 118);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(158, 42);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(12, 83);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(485, 29);
            this.cbEmpresa.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Empresa";
            // 
            // FrmExportarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 226);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmExportarProdutos";
            this.Text = "FrmExportarProdutos";
            this.Load += new System.EventHandler(this.FrmExportarProdutos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdTempProdComAnexo;
        private System.Windows.Forms.RadioButton rdTempComeSemAnexo;
        private System.Windows.Forms.RadioButton rdTempProdSemClassificacao;
        private System.Windows.Forms.RadioButton rdTempComeSemAnexoeClassifPadrao;
    }
}