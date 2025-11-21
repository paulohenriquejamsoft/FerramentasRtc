using System;
using System.Text;
using System.Windows.Forms;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Repositorios;

namespace CategorizarProdutos
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            pnFerramentas.Enabled = false;

            lblVersao.Text = $"Versão: {Application.ProductVersion}";
        }

        private async void btnConectar_Click(object sender, EventArgs e)
        {
            pnFerramentas.Enabled = false;
            try
            {
                var servidor = txtServidor.Text.Trim();
                var usuario = txtUsuario.Text.Trim();
                var senha = txtSenha.Text.Trim();
                var banco = txtBanco.Text.Trim();

                var erros = new StringBuilder();
                if (string.IsNullOrEmpty(servidor))
                    erros.AppendLine("O campo 'Servidor' é obrigatório.");

                if (string.IsNullOrEmpty(senha))
                    erros.AppendLine("O campo 'Senha' é obrigatório.");

                if (string.IsNullOrEmpty(usuario))
                    erros.AppendLine("O campo 'Usuário' é obrigatório.");

                if (string.IsNullOrEmpty(banco))
                    erros.AppendLine("O campo 'Banco de Dados' é obrigatório.");

                if (erros.Length > 0)
                {
                    MessageBox.Show(erros.ToString(), "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Conexao.PreencherConexao(servidor, usuario, senha, banco);
                if (Conexao.TestarConexao())
                {
                    var operacaoRepository = new OperacaoFiscalRepository();
                    var qtdOperacoes = await operacaoRepository.QtdOperacaoFiscalVenda();
                    if (qtdOperacoes == 0)
                        await operacaoRepository.InserirOperacaoPadrao();

                    pnFerramentas.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Não foi possível conectar ao banco de dados. Verifique as credenciais e tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNaturezaTributacao_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmNaturezaTributacao())
            {
                frm.ShowDialog();
            }
        }

        private void btnExportarProdComAnexo_Click(object sender, EventArgs e)
        {
            using (var frmProdutos = new FrmExportarProdutos())
            {
                frmProdutos.ShowDialog();
            }
        }   
    }
}
