using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Repositorios;

namespace CategorizarProdutos
{
    public partial class FrmPrincipal : Form
    {
        private bool _baixarTabelaNcm = true;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            pnFerramentas.Enabled = false;

            lblVersao.Text = $"Versão: {Application.ProductVersion}";
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            pnFerramentas.Enabled = false;
            try
            {
                lblConexao.Text = string.Empty;
                lblConexao.Refresh();

                Task.Delay(1000).Wait();

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
                    return;
                }

                Conexao.FecharConexao();
                Conexao.PreencherConexao(servidor, usuario, senha, banco);
                if (Conexao.TestarConexao())
                {
                    pnFerramentas.Enabled = true;
                    lblConexao.Text = "Conectado!!!";
                    //MessageBox.Show("Conexao realizada com sucesso!");
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

        private async void btnNaturezaTributacao_Click(object sender, EventArgs e)
        {
            await CriarTributacaoPadraoAsync();
            using (var frm = new FrmNaturezaTributacao())
            {
                frm.ShowDialog();
            }
        }

        public async Task CriarTributacaoPadraoAsync()
        {
            var operacaoRepository = new OperacaoFiscalRepository();
            var qtdOperacoes = await operacaoRepository.QtdOperacaoFiscalVenda();
            if (qtdOperacoes == 0)
                await operacaoRepository.InserirOperacaoPadrao();
        }

        private async void btnExportarProdComAnexo_Click(object sender, EventArgs e)
        {
            btnExportarProdComAnexo.Enabled = false;
            if (_baixarTabelaNcm)
            {
                var diretorioAtual = AppDomain.CurrentDomain.BaseDirectory;
                var tabelaNcmJson = $"{diretorioAtual}Tabelas\\tabela_ncm.json";

                var resultadoDownload = await BaixarTabelaNcmAsync(tabelaNcmJson);
                if (!resultadoDownload)
                {
                    MessageBox.Show("O sistema irá utilizar a tabela existente em cache.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _baixarTabelaNcm = false;
                }                    
            }            
            using (var frmProdutos = new FrmExportarProdutos())
            {
                frmProdutos.ShowDialog();
            }
            btnExportarProdComAnexo.Enabled = true;
        }

        private async Task<bool> BaixarTabelaNcmAsync(string arquivoTabela)
        {
            try
            {
                var urlTabelaNcm = "https://www.unimake.com.br/downloads/tabela_ncm.json";
                var httpClient = new System.Net.Http.HttpClient();
                var resposta = await httpClient.GetAsync(urlTabelaNcm);
                if (resposta.IsSuccessStatusCode)
                {
                    var conteudo = await resposta.Content.ReadAsStringAsync();
                    File.WriteAllText(arquivoTabela, conteudo);
                    return true;
                }
                else
                {
                    MessageBox.Show("Não foi possível baixar a tabela NCM.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao baixar a tabela NCM:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnImportarClassificacao_Click(object sender, EventArgs e)
        {

            await CriarTributacaoPadraoAsync();
            using (var frm = new FrmImportarClassificacao())
            {
                frm.ShowDialog();
            }
        }
    }
}
