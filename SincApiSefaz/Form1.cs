using System.Text.Json;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using SincApiSefaz.Dto;
using SincApiSefaz.Models.TabNcm;
using SincApiSefaz.Repositorios;
using SincApiSefaz.Servicos;

namespace SincApiSefaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnSincronizarMunicipios_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().Municipios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao sincronizar municípios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSituacaoTributaria_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().SituacoesTributarias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao situacoes Tributarias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnClassificacaoTributaria_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().ClassificacoesTributarias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao sincronizar classificações tributárias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnClassTrib031025_Click(object sender, EventArgs e)
        {
            try
            {
                var caminhoArquivo = "C:\\Users\\phs\\Downloads\\CST_cClassTrib_2025-10-03_Public_verde.xlsx";

                var excelInstance = new ImportacaoTabClassTrib();
                var (csts, classificacoes) = excelInstance.ExtrairDados(caminhoArquivo);

                await excelInstance.AtualizarCstsBanco(csts);
                await excelInstance.AtualizarCClassificacoesBanco(classificacoes);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar classificações tributárias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExportarCClassTrib_Click(object sender, EventArgs e)
        {
            var registros = await new ClassifTributariaRepository().ObterDadosExportacao();

            var planilha = JsonSerializer.Serialize(registros);
            System.IO.File.WriteAllText("tabela_cst_cclasstrib.json", planilha, System.Text.Encoding.UTF8);

            MessageBox.Show($"Arquivo Exportado", "JAMSOFT Tecnologia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnImportarNcm_Click(object sender, EventArgs e)
        {
            var caminhoArquivo = "C:\\Users\\phs\\Downloads\\tabela_ncm.json";
            var retono = JsonSerializer.Deserialize<NcmCamex?>(File.ReadAllText(caminhoArquivo), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            var nomenclaturas = retono?.Nomenclaturas;
            if (nomenclaturas != null && nomenclaturas.Count > 0)
            {
                var combinacoes = nomenclaturas
               .Select(x => x.CodigoProxy.Length)
               .Distinct()
               .OrderBy(x => x)
               .ToList();

                var produtosRepo = new ProdutoRepository();
                var produtosClassificacao = await produtosRepo.ObterParaClassificacao();

                produtosClassificacao = produtosClassificacao
                                        .OrderBy(p => p.CodigoNcm)
                                        .ToList();         


                //var ncms = new List<string>() { "30039069", "34011900", "22021000", "85169000", "30049099", "96190000", "30049099", "85363090", "87089100", "87088000" };
                var ncms = new List<string>() { "22011000" };
                var posibilidades = new List<string>();
                var ultimoNcm = string.Empty;
                var ultimoIndiceValido = -1;
                foreach (var produto in produtosClassificacao)
                {
                    if (ultimoNcm.Equals(produto.CodigoNcm))
                    {
                        produto.Anexos = produtosClassificacao[ultimoIndiceValido].Anexos;
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

                    var anexosEncontrados = nomenclaturas
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

                SalvarProdutosClassificados(produtosClassificacao);
            }

            MessageBox.Show($"Produtos categorizados", "JAMSOFT Tecnologia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void SalvarProdutosClassificados(List<ProdutoClassificacao> produtosClassificacao)
        {
            produtosClassificacao = produtosClassificacao.OrderBy(p => p.CodProd).ToList();
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Planilha1");
            worksheet.Cell("A1").Value = "Código";
            worksheet.Cell("B1").Value = "Produto";
            worksheet.Cell("C1").Value = "Apelido";
            worksheet.Cell("D1").Value = "Cod. Barra";
            worksheet.Cell("E1").Value = "Ncm";

            worksheet.Cell("F1").Value = "Anexo_1";
            worksheet.Cell("G1").Value = "CST_1";
            worksheet.Cell("H1").Value = "CclasTrib_1";

            worksheet.Cell("I1").Value = "Anexo_2";
            worksheet.Cell("J1").Value = "CST_2";
            worksheet.Cell("K1").Value = "CclasTrib_2";

            worksheet.Cell("L1").Value = "Anexo_3";
            worksheet.Cell("M1").Value = "CST_3";
            worksheet.Cell("N1").Value = "CclasTrib_3";

            worksheet.Cell("O1").Value = "Anexo_4";
            worksheet.Cell("P1").Value = "CST_4";
            worksheet.Cell("Q1").Value = "CclasTrib_4";

            var linha = 1;
            foreach (var produtoClassificado in produtosClassificacao)
            {

                linha++;
                worksheet.Cell($"A{linha}").Value = produtoClassificado.CodProd;
                worksheet.Cell($"B{linha}").Value = produtoClassificado.Produto;
                worksheet.Cell($"C{linha}").Value = produtoClassificado.ApelidoProd;
                worksheet.Cell($"D{linha}").Value = produtoClassificado.CodigoBarra;
                worksheet.Cell($"E{linha}").Value = produtoClassificado.CodigoNcm;

                var anexo = 1;
                foreach (var infoAnexo in produtoClassificado.Anexos)
                {
                    if (anexo > 4)
                        break;

                    if (anexo == 1)
                    {
                        worksheet.Cell($"F{linha}").Value = infoAnexo.Anexo;
                        worksheet.Cell($"G{linha}").Value = infoAnexo.Cst;
                        worksheet.Cell($"H{linha}").Value = infoAnexo.CclasTrib;
                    }
                    else if (anexo == 2)
                    {
                        worksheet.Cell($"I{linha}").Value = infoAnexo.Anexo;
                        worksheet.Cell($"J{linha}").Value = infoAnexo.Cst;
                        worksheet.Cell($"K{linha}").Value = infoAnexo.CclasTrib;
                    }
                    else if (anexo == 3)
                    {
                        worksheet.Cell($"I{linha}").Value = infoAnexo.Anexo;
                        worksheet.Cell($"J{linha}").Value = infoAnexo.Cst;
                        worksheet.Cell($"K{linha}").Value = infoAnexo.CclasTrib;
                    }
                    else
                    {
                        worksheet.Cell($"O{linha}").Value = infoAnexo.Anexo;
                        worksheet.Cell($"P{linha}").Value = infoAnexo.Cst;
                        worksheet.Cell($"Q{linha}").Value = infoAnexo.CclasTrib;
                    }

                    anexo++;
                }
              
            }

            string filePath = @"C:\lixo\produtos_classificados.xlsx";
            workbook.SaveAs(filePath);
        }
    }
}
