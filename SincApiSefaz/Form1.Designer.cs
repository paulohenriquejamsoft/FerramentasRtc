namespace SincApiSefaz
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnSincronizarMunicipios = new Button();
            BtnSituacaoTributaria = new Button();
            groupBox1 = new GroupBox();
            BtnClassificacaoTributaria = new Button();
            btnClassTrib031025 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnSincronizarMunicipios
            // 
            BtnSincronizarMunicipios.Location = new Point(6, 22);
            BtnSincronizarMunicipios.Name = "BtnSincronizarMunicipios";
            BtnSincronizarMunicipios.Size = new Size(124, 23);
            BtnSincronizarMunicipios.TabIndex = 0;
            BtnSincronizarMunicipios.Text = "Municipios";
            BtnSincronizarMunicipios.UseVisualStyleBackColor = true;
            BtnSincronizarMunicipios.Click += BtnSincronizarMunicipios_Click;
            // 
            // BtnSituacaoTributaria
            // 
            BtnSituacaoTributaria.Location = new Point(147, 22);
            BtnSituacaoTributaria.Name = "BtnSituacaoTributaria";
            BtnSituacaoTributaria.Size = new Size(190, 23);
            BtnSituacaoTributaria.TabIndex = 1;
            BtnSituacaoTributaria.Text = "Situações Tributarias";
            BtnSituacaoTributaria.UseVisualStyleBackColor = true;
            BtnSituacaoTributaria.Click += BtnSituacaoTributaria_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClassTrib031025);
            groupBox1.Controls.Add(BtnClassificacaoTributaria);
            groupBox1.Controls.Add(BtnSincronizarMunicipios);
            groupBox1.Controls.Add(BtnSituacaoTributaria);
            groupBox1.Location = new Point(14, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(597, 144);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sincronizações";
            // 
            // BtnClassificacaoTributaria
            // 
            BtnClassificacaoTributaria.Location = new Point(343, 22);
            BtnClassificacaoTributaria.Name = "BtnClassificacaoTributaria";
            BtnClassificacaoTributaria.Size = new Size(190, 23);
            BtnClassificacaoTributaria.TabIndex = 2;
            BtnClassificacaoTributaria.Text = "Classificação Tributária";
            BtnClassificacaoTributaria.UseVisualStyleBackColor = true;
            BtnClassificacaoTributaria.Click += BtnClassificacaoTributaria_Click;
            // 
            // btnClassTrib031025
            // 
            btnClassTrib031025.Location = new Point(6, 85);
            btnClassTrib031025.Name = "btnClassTrib031025";
            btnClassTrib031025.Size = new Size(190, 23);
            btnClassTrib031025.TabIndex = 3;
            btnClassTrib031025.Text = "Ler - Tab ClassTrib - 03/10/2025";
            btnClassTrib031025.UseVisualStyleBackColor = true;
            btnClassTrib031025.Click += btnClassTrib031025_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 287);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnSincronizarMunicipios;
        private Button BtnSituacaoTributaria;
        private GroupBox groupBox1;
        private Button BtnClassificacaoTributaria;
        private Button btnClassTrib031025;
    }
}
