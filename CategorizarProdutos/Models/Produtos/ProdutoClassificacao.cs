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
}
