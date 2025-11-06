using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategorizarProdutos.Dto;
using CategorizarProdutos.Models.Empresa;
using CategorizarProdutos.Models.Produtos;
using CategorizarProdutos.Repositorios;
using ClosedXML.Excel;

namespace CategorizarProdutos
{
    public partial class FrmExportarProdutos : Form
    {

        public FrmExportarProdutos()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmExportarProdutos_Load(object sender, EventArgs e)
        {
            await PreencherComboTributacao();
        }

        public async Task PreencherComboTributacao()
        {
            var empresas = await new EmpresaRepository().ObterEmpresas();

            cbEmpresa.DataSource = empresas;
            cbEmpresa.ValueMember = nameof(DadosEmpresa.Cnpj);
            cbEmpresa.DisplayMember = nameof(DadosEmpresa.DescricaoCombo);
            if (empresas.Count > 0)
                cbEmpresa.SelectedIndex = 0;
        }

        private async void btnExportar_Click(object sender, EventArgs e)
        {
            var pergunta = MessageBox.Show("Deseja realmente exportar os produtos para o sistema fiscal? Essa operação pode demorar um pouco.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pergunta == DialogResult.No)
                return;

            try
            {
                btnExportar.Enabled = false;

                var produtosRepo = new ProdutoRepository();
                var produtos = await produtosRepo.ObterParaClassificacao();

                if (produtos.Count == 0)
                {
                    MessageBox.Show("Nenhum produto encontrado para exportação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnExportar.Enabled = true;
                    return;
                }

                List<ProdutoClassificacao> produtosClassificados = await ClassificarProdutos(produtos);
                if (produtosClassificados == null || produtosClassificados.Count == 0)
                {
                    MessageBox.Show("Nenhum produto encontrado para classificação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnExportar.Enabled = true;
                    return;
                }

                List<LayoutTabela> colunas;
                if (rdTempProdComAnexo.Checked)
                {                    
                    produtosClassificados = produtosClassificados
                                            .Where(p => p.Anexos != null && p.Anexos.Count > 0)
                                            .ToList();

                    if (produtosClassificados == null || produtosClassificados.Count == 0)
                    {
                        MessageBox.Show("Não existe produtos com anexo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnExportar.Enabled = true;
                        return;
                    }

                    colunas = new List<LayoutTabela>
                           {
                               new LayoutTabela("A", "CNPJ", "CnpjEmpresa"),
                               new LayoutTabela("B", "Código do Produto", "CodProd"),
                               new LayoutTabela("C", "GTIN", "CodigoBarra"),
                               new LayoutTabela("D", "NCM", "CodigoNcm"),
                               new LayoutTabela("E", "Descrição", "Produto"),
                               new LayoutTabela("F", "Apelido", "ApelidoProd"),                               
                               new LayoutTabela("G", "CST_1", "Cst2"),
                               new LayoutTabela("H", "cClasTrib_1", "ClassTrib2"),
                               new LayoutTabela("I", "Anexo_1", "Anexo2"),
                               new LayoutTabela("J", "CST_2", "Cst3"),
                               new LayoutTabela("K", "cClasTrib_2", "ClassTrib3"),
                               new LayoutTabela("L", "Anexo_2", "Anexo3"),
                               new LayoutTabela("M", "CST_3", "Cst4"),
                               new LayoutTabela("N", "cClasTrib_3", "ClassTrib4"),
                               new LayoutTabela("O", "Anexo_3", "Anexo4"),
                               new LayoutTabela("P", "CST_4", "Cst5"),
                               new LayoutTabela("Q", "cClasTrib_4", "ClassTrib5"),
                               new LayoutTabela("R", "Anexo_4", "Anexo5"),
                           };
                }
                else if (rdTempComeSemAnexo.Checked)
                {
                    colunas = new List<LayoutTabela>
                           {
                               new LayoutTabela("A", "CNPJ", "CnpjEmpresa"),
                               new LayoutTabela("B", "Código do Produto", "CodProd"),
                               new LayoutTabela("C", "GTIN", "CodigoBarra"),
                               new LayoutTabela("D", "NCM", "CodigoNcm"),
                               new LayoutTabela("E", "Descrição", "Produto"),
                               new LayoutTabela("F", "Apelido", "ApelidoProd"),
                               new LayoutTabela("G", "CST_1", "Cst2"),
                               new LayoutTabela("H", "cClasTrib_1", "ClassTrib2"),
                               new LayoutTabela("I", "Anexo_1", "Anexo2"),
                               new LayoutTabela("J", "CST_2", "Cst3"),
                               new LayoutTabela("K", "cClasTrib_2", "ClassTrib3"),
                               new LayoutTabela("L", "Anexo_2", "Anexo3"),
                               new LayoutTabela("M", "CST_3", "Cst4"),
                               new LayoutTabela("N", "cClasTrib_3", "ClassTrib4"),
                               new LayoutTabela("O", "Anexo_3", "Anexo4"),
                               new LayoutTabela("P", "CST_4", "Cst5"),
                               new LayoutTabela("Q", "cClasTrib_4", "ClassTrib5"),
                               new LayoutTabela("R", "Anexo_4", "Anexo5"),
                           };
                }
                else if (rdTempProdSemClassificacao.Checked)
                {
                    colunas = new List<LayoutTabela>
                           {
                               new LayoutTabela("A", "CNPJ", "CnpjEmpresa"),
                               new LayoutTabela("B", "Código do Produto", "CodProd"),
                               new LayoutTabela("C", "GTIN", "CodigoBarra"),
                               new LayoutTabela("D", "NCM", "CodigoNcm"),
                               new LayoutTabela("E", "Descrição", "Produto"),
                               new LayoutTabela("F", "Apelido", "ApelidoProd"),
                               new LayoutTabela("G", "CST", ""),
                               new LayoutTabela("H", "cClasTrib", ""),                              
                    };
                }
                else
                {
                    colunas = new List<LayoutTabela>
                           {
                               new LayoutTabela("A", "CNPJ", "CnpjEmpresa"),
                               new LayoutTabela("B", "Código do Produto", "CodProd"),
                               new LayoutTabela("C", "GTIN", "CodigoBarra"),
                               new LayoutTabela("D", "NCM", "CodigoNcm"),
                               new LayoutTabela("E", "Descrição", "Produto"),
                               new LayoutTabela("F", "Apelido", "ApelidoProd"),
                               new LayoutTabela("G", "CST Padrão", "CstPadrao"),
                               new LayoutTabela("H", "cClasTrib Padrão", "CclasTribPadrao"),
                               new LayoutTabela("I", "CST_2", "Cst2"),
                               new LayoutTabela("J", "cClasTrib_2", "ClassTrib2"),
                               new LayoutTabela("K", "Anexo_2", "Anexo2"),
                               new LayoutTabela("L", "CST_3", "Cst3"),
                               new LayoutTabela("M", "cClasTrib_3", "ClassTrib3"),
                               new LayoutTabela("N", "Anexo_3", "Anexo3"),
                               new LayoutTabela("O", "CST_4", "Cst4"),
                               new LayoutTabela("P", "cClasTrib_4", "ClassTrib4"),
                               new LayoutTabela("Q", "Anexo_4", "Anexo4"),
                               new LayoutTabela("R", "CST_5", "Cst5"),
                               new LayoutTabela("S", "cClasTrib_5", "ClassTrib5"),
                               new LayoutTabela("T", "Anexo_5", "Anexo5"),
                           };
                }

                if (produtosClassificados == null || produtosClassificados.Count == 0)
                {
                    MessageBox.Show("Nenhum produto encontrado para classificação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var arquivoDestino = EscolherCaminhoArquivo();
                    if (string.IsNullOrWhiteSpace(arquivoDestino))
                    {
                        MessageBox.Show("Operação cancelada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnExportar.Enabled = true;
                        return;
                    }

                    var cnpjEmpresa = cbEmpresa.SelectedValue?.ToString() ?? "00000000000000";

                    produtosClassificados = produtosClassificados.OrderBy(p => p.CodProd).ToList();                   
                    var produtosClassificado = new ProdutosClassificados().Converter(produtosClassificados, cnpjEmpresa);

                    GerarPlanilha(colunas, produtosClassificado, arquivoDestino);

                    MessageBox.Show("Planilha exportada com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao exportar os produtos:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnExportar.Enabled = true;
            }
        }

        private async Task<List<ProdutoClassificacao>> ClassificarProdutos(List<ProdutoClassificacao> produtos)
        {
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
                    .GroupBy(g => new { g.CclassTrib, g.Cst, g.Anexo, g.Legislacao })
                    .ToList();

                if (anexosEncontrados.Count > 0)
                {
                    foreach (var anexos in anexosEncontrados)
                    {

                        produto.Anexos.Add(new InformacaoAnexo
                        {
                            CclassTrib = anexos.Key.CclassTrib,
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

        private void GerarPlanilha(List<LayoutTabela> colunas, List<ProdutosClassificados> produtos, string arquivo)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Planilha1");
            foreach (var coluna in colunas)
            {
                var celula = worksheet.Cell($"{coluna.Coluna}1");
                celula.Style = celula.Style.Font.SetBold();
                celula.Value = coluna.DescricaoColuna;
            }

            var linha = 2;
            foreach (var produto in produtos)
            {
                foreach (var coluna in colunas)
                {
                    var propriedade = produto.GetType().GetProperty(coluna.CampoLinha);
                    var valorCampo = propriedade?.GetValue(produto, null) ?? "";
                    worksheet.Cell($"{coluna.Coluna}{linha}").Value = valorCampo.ToString();
                }
                linha++;
            }
            workbook.SaveAs(arquivo);
        }

        private string EscolherCaminhoArquivo()
        {
            var fileDialog = new SaveFileDialog
            {
                Filter = "Arquivo Excel (*.xlsx)|*.xlsx",
                Title = "Salvar arquivo Excel"
            };
            fileDialog.ShowDialog();

            var nomeArquivo = fileDialog.FileName;
            if (string.IsNullOrWhiteSpace(nomeArquivo))
                return string.Empty;

            nomeArquivo = nomeArquivo.ToLower().Replace(".xls", string.Empty)
                          .Replace(".xlsx", string.Empty);

            return nomeArquivo = $"{nomeArquivo}.xlsx";
        }
    }

    public class LayoutTabela
    {
        public LayoutTabela(string coluna, string descricaoColuna, string campoLinha)
        {
            Coluna = coluna;
            DescricaoColuna = descricaoColuna;
            CampoLinha = campoLinha;
        }

        public string Coluna { get; private set; }
        public string DescricaoColuna { get; private set; }
        public string CampoLinha { get; private set; }
    }
}
