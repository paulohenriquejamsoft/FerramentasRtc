using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Dto;
using CategorizarProdutos.Models.Produtos;
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
        }

        private void btnConectar_Click(object sender, EventArgs e)
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

        private async void btnExportarProdComAnexo_Click(object sender, EventArgs e)
        {
            var produtosClassificados = await ClassificarProdutos();
            if(produtosClassificados == null || produtosClassificados.Count == 0)
            {
                MessageBox.Show("Nenhum produto encontrado para classificação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //var fileDialog = new SaveFileDialog
            //{
            //    Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
            //    Title = "Salvar arquivo Excel"
            //};
            //fileDialog.ShowDialog();

            //var nomeArquivo = fileDialog.FileName;
            //if (string.IsNullOrWhiteSpace(nomeArquivo))
            //{
            //    MessageBox.Show("Operação cancelada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}


            //nomeArquivo = $"{nomeArquivo}.xlsx";          
        }

        private async Task<List<ProdutoClassificacao>> ClassificarProdutos()
        {
            var produtos = new List<ProdutoClassificacao>();
            var ncmsTabela = CarregarTabelaNcm();
            if (ncmsTabela == null || ncmsTabela.Count == 0)
            {
                MessageBox.Show("Não foi possível carregar a tabela NCM.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return produtos;
            }

            var combinacoes = ncmsTabela
               .Select(x => x.CodigoProxy.Length)
               .Distinct()
               .OrderBy(x => x)
               .ToList();

            var produtosRepo = new ProdutoRepository();
            produtos = await produtosRepo.ObterParaClassificacao();

            produtos = produtos.OrderBy(p => p.CodigoNcm).ToList();

            var posibilidades = new List<string>();
            var ultimoNcm = string.Empty;
            var ultimoIndiceValido = -1;
            foreach (var produto in produtos)
            {
                if (ultimoNcm.Equals(produto.CodigoNcm))
                {
                    produto.Anexos = produtos[ultimoIndiceValido].Anexos;
                    ultimoIndiceValido++;
                    continue;
                }

                posibilidades.Clear();
                foreach (var tamanho in combinacoes)
                {
                    if (produto.CodigoNcm.Length >= tamanho)
                    {
                        var combinacao = produto.CodigoNcm.Substring(0, tamanho);
                        posibilidades.Add(combinacao);
                    }
                }

                var anexosEncontrados = ncmsTabela
                    .Where(n => posibilidades.Contains(n.CodigoProxy))
                    .SelectMany(n => n.Anexos)
                    .GroupBy(g => new { g.CclasTrib, g.Cst, g.Anexo, g.Legislacao })
                    .ToList();

                if (anexosEncontrados.Count > 0)
                {
                    foreach (var anexos in anexosEncontrados)
                    {

                        produto.Anexos.Add(new InformacaoAnexo
                        {
                            CclasTrib = anexos.Key.CclasTrib,
                            Cst = anexos.Key.Cst,
                            Anexo = anexos.Key.Anexo,
                            Legislacao = anexos.Key.Legislacao
                        });
                    }

                }
                ultimoNcm = produto.CodigoNcm;
                ultimoIndiceValido++;
            }

            return produtos;
        }

        private List<Nomenclatura> CarregarTabelaNcm()
        {
            var diretorioAtual = AppDomain.CurrentDomain.BaseDirectory;
            var tabelaNcmJson = $"{diretorioAtual}\\Tabelas\\tabela_ncm.json";
            var retono = JsonSerializer.Deserialize<NcmCamex>(File.ReadAllText(tabelaNcmJson), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return retono?.Nomenclaturas;
        }
    }
}
