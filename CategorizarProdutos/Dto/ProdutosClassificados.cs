using System.Collections.Generic;
using CategorizarProdutos.Models.Produtos;

namespace CategorizarProdutos.Dto
{
    public class ProdutosClassificados
    {
        public string CnpjEmpresa { get; set; }
        public int CodProd { get; set; }
        public string Produto { get; set; } = string.Empty;
        public string ApelidoProd { get; set; } = string.Empty;
        public string CodigoBarra { get; set; } = string.Empty;
        public string CodigoNcm { get; set; } = string.Empty;

        public string Cst1 { get; set; }
        public string ClassTrib1 { get; set; }
        public string Anexo1 { get; set; }

        public string Cst2 { get; set; }
        public string ClassTrib2 { get; set; }
        public string Anexo2 { get; set; }

        public string Cst3 { get; set; }
        public string ClassTrib3 { get; set; }
        public string Anexo3 { get; set; }

        public string Cst4 { get; set; }
        public string ClassTrib4 { get; set; }
        public string Anexo4 { get; set; }

        public List<ProdutosClassificados> Converter(List<ProdutoClassificacao> produtos, string cnpjEmpresa, bool comClassifPadrao)
        {
            var produtosClassificados = new List<ProdutosClassificados>();
            foreach (var produto in produtos)
            {
                var produtoClassificado = new ProdutosClassificados
                {
                    CnpjEmpresa = cnpjEmpresa,
                    CodProd = produto.CodProd,
                    Produto = produto.Produto,
                    ApelidoProd = produto.ApelidoProd,
                    CodigoBarra = produto.CodigoBarra,
                    CodigoNcm = produto.CodigoNcm
                };

                if (produto.Anexos.Count > 0)
                {
                    var anexo = 1;
                    foreach (var infoAnexo in produto.Anexos)
                    {
                        if (anexo > 4)
                            break;

                        if (anexo == 1)
                        {
                            produtoClassificado.Anexo1 = infoAnexo.Anexo;
                            produtoClassificado.Cst1 = infoAnexo.Cst;
                            produtoClassificado.ClassTrib1 = infoAnexo.CclassTrib;
                        }
                        else if (anexo == 2)
                        {
                            produtoClassificado.Anexo2 = infoAnexo.Anexo;
                            produtoClassificado.Cst2 = infoAnexo.Cst;
                            produtoClassificado.ClassTrib2 = infoAnexo.CclassTrib;
                        }
                        else if (anexo == 3)
                        {
                            produtoClassificado.Anexo3 = infoAnexo.Anexo;
                            produtoClassificado.Cst3 = infoAnexo.Cst;
                            produtoClassificado.ClassTrib3 = infoAnexo.CclassTrib;
                        }
                        else
                        {
                            produtoClassificado.Anexo4 = infoAnexo.Anexo;
                            produtoClassificado.Cst4 = infoAnexo.Cst;
                            produtoClassificado.ClassTrib4 = infoAnexo.CclassTrib;
                        }

                        anexo++;
                    }
                }
                else
                {
                    if (comClassifPadrao)
                    {
                        produtoClassificado.Anexo1 = string.Empty;
                        produtoClassificado.Cst1 = "000";
                        produtoClassificado.ClassTrib1 = "000001";
                    }
                }
                produtosClassificados.Add(produtoClassificado);
            }
            return produtosClassificados;
        }
    }
}
