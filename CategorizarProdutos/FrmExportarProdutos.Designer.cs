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
            this.rdTempComClassifPadrao = new System.Windows.Forms.RadioButton();
            this.rdTempSemClassificacao = new System.Windows.Forms.RadioButton();
            this.rdTempPadrao = new System.Windows.Forms.RadioButton();
            this.btnExportar = new System.Windows.Forms.Button();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdProdAmbos = new System.Windows.Forms.RadioButton();
            this.rdProdSomenteComAnexo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(509, 47);
            this.panel1.TabIndex = 3;
            // 
            // btnFechar
            // 
            this.btnFechar.BackgroundImage = global::CategorizarProdutos.Properties.Resources.Close;
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Location = new System.Drawing.Point(470, 10);
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
            this.label1.Location = new System.Drawing.Point(183, 9);
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
            this.groupBox1.Controls.Add(this.rdTempComClassifPadrao);
            this.groupBox1.Controls.Add(this.rdTempSemClassificacao);
            this.groupBox1.Controls.Add(this.rdTempPadrao);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(231, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Template";
            // 
            // rdTempComClassifPadrao
            // 
            this.rdTempComClassifPadrao.AutoSize = true;
            this.rdTempComClassifPadrao.Location = new System.Drawing.Point(7, 55);
            this.rdTempComClassifPadrao.Name = "rdTempComClassifPadrao";
            this.rdTempComClassifPadrao.Size = new System.Drawing.Size(160, 23);
            this.rdTempComClassifPadrao.TabIndex = 3;
            this.rdTempComClassifPadrao.Text = "Com Classif. Padrão";
            this.rdTempComClassifPadrao.UseVisualStyleBackColor = true;
            // 
            // rdTempSemClassificacao
            // 
            this.rdTempSemClassificacao.AutoSize = true;
            this.rdTempSemClassificacao.Location = new System.Drawing.Point(6, 84);
            this.rdTempSemClassificacao.Name = "rdTempSemClassificacao";
            this.rdTempSemClassificacao.Size = new System.Drawing.Size(127, 23);
            this.rdTempSemClassificacao.TabIndex = 2;
            this.rdTempSemClassificacao.TabStop = true;
            this.rdTempSemClassificacao.Text = "Sem Classificar";
            this.rdTempSemClassificacao.UseVisualStyleBackColor = true;
            // 
            // rdTempPadrao
            // 
            this.rdTempPadrao.AutoSize = true;
            this.rdTempPadrao.Checked = true;
            this.rdTempPadrao.Location = new System.Drawing.Point(7, 26);
            this.rdTempPadrao.Name = "rdTempPadrao";
            this.rdTempPadrao.Size = new System.Drawing.Size(76, 23);
            this.rdTempPadrao.TabIndex = 0;
            this.rdTempPadrao.TabStop = true;
            this.rdTempPadrao.Text = "Padrão";
            this.rdTempPadrao.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Red;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Image = global::CategorizarProdutos.Properties.Resources.Synchronize;
            this.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportar.Location = new System.Drawing.Point(175, 262);
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.rdProdAmbos);
            this.groupBox2.Controls.Add(this.rdProdSomenteComAnexo);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 120);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Produtos";
            // 
            // rdProdAmbos
            // 
            this.rdProdAmbos.AutoSize = true;
            this.rdProdAmbos.Checked = true;
            this.rdProdAmbos.Location = new System.Drawing.Point(6, 26);
            this.rdProdAmbos.Name = "rdProdAmbos";
            this.rdProdAmbos.Size = new System.Drawing.Size(156, 23);
            this.rdProdAmbos.TabIndex = 1;
            this.rdProdAmbos.TabStop = true;
            this.rdProdAmbos.Text = "Com e Sem Anexos";
            this.rdProdAmbos.UseVisualStyleBackColor = true;
            // 
            // rdProdSomenteComAnexo
            // 
            this.rdProdSomenteComAnexo.AutoSize = true;
            this.rdProdSomenteComAnexo.Location = new System.Drawing.Point(6, 55);
            this.rdProdSomenteComAnexo.Name = "rdProdSomenteComAnexo";
            this.rdProdSomenteComAnexo.Size = new System.Drawing.Size(172, 23);
            this.rdProdSomenteComAnexo.TabIndex = 0;
            this.rdProdSomenteComAnexo.Text = "Somente com Anexos";
            this.rdProdSomenteComAnexo.UseVisualStyleBackColor = true;
            // 
            // FrmExportarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 321);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.RadioButton rdTempPadrao;
        private System.Windows.Forms.RadioButton rdTempSemClassificacao;
        private System.Windows.Forms.RadioButton rdTempComClassifPadrao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdProdAmbos;
        private System.Windows.Forms.RadioButton rdProdSomenteComAnexo;
    }
}