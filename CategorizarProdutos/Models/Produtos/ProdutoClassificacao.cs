using System.Collections.Generic;
using CategorizarProdutos.Dto;

namespace CategorizarProdutos.Models.Produtos
{
    public class ProdutoClassificacao
    {        
        public int CodProd { get; set; }
        public string Produto { get; set; } = string.Empty;
        public string ApelidoProd { get; set; } = string.Empty;
        public string CodigoBarra { get; set; } = string.Empty;
        public string CodigoNcm { get; set; } = string.Empty;
        public List<InformacaoAnexo> Anexos { get; set; } = new List<InformacaoAnexo>();
    }

    public class ProdutosClassificados
    {
        public string CnpjEmpresa { get; set; }
        public int CodProd { get; set; }
        public string Produto { get; set; } = string.Empty;
        public string ApelidoProd { get; set; } = string.Empty;
        public string CodigoBarra { get; set; } = string.Empty;
        public string CodigoNcm { get; set; } = string.Empty;

        public string CstPadrao { get; set; } = "001";
        public string CclasTribPadrao { get; set; } = "000001";

        public string Cst2 { get; set; }
        public string ClassTrib2 { get; set; }
        public string Anexo2 { get; set; }

        public string Cst3 { get; set; }
        public string ClassTrib3 { get; set; }
        public string Anexo3 { get; set; }

        public string Cst4 { get; set; }
        public string ClassTrib4 { get; set; }
        public string Anexo4 { get; set; }

        public string Cst5 { get; set; }
        public string ClassTrib5 { get; set; }
        public string Anexo5 { get; set; }

        public List<ProdutosClassificados> Converter(List<ProdutoClassificacao> produtos, string cnpjEmpresa)
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

                var anexo = 1;
                foreach (var infoAnexo in produto.Anexos)
                {
                    if (anexo > 4)
                        break;

                    if (anexo == 1)
                    {
                        produtoClassificado.Anexo2 = infoAnexo.Anexo;
                        produtoClassificado.Cst2 = infoAnexo.Cst;
                        produtoClassificado.ClassTrib2 = infoAnexo.CclassTrib;
                    }
                    else if (anexo == 2)
                    {
                        produtoClassificado.Anexo3 = infoAnexo.Anexo;
                        produtoClassificado.Cst3 = infoAnexo.Cst;
                        produtoClassificado.ClassTrib3 = infoAnexo.CclassTrib;
                    }
                    else if (anexo == 3)
                    {
                        produtoClassificado.Anexo4 = infoAnexo.Anexo;
                        produtoClassificado.Cst4 = infoAnexo.Cst;
                        produtoClassificado.ClassTrib4 = infoAnexo.CclassTrib;
                    }
                    else
                    {
                        produtoClassificado.Anexo5 = infoAnexo.Anexo;
                        produtoClassificado.Cst5 = infoAnexo.Cst;
                        produtoClassificado.ClassTrib5 = infoAnexo.CclassTrib;
                    }

                    anexo++;
                }

                produtosClassificados.Add(produtoClassificado);
            }

            return produtosClassificados;
        }
    }
}
