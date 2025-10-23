namespace CategorizarProdutos.Models.TributacoesFiscal
{
    public class TributacaoFiscal
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CstIbsCbs { get; set; }
        public string CclassTrib { get; set; }

        public string DescricaoCombo => $"{Descricao} - CST: {CstIbsCbs} - Classificação: {CclassTrib}";
    }
}
