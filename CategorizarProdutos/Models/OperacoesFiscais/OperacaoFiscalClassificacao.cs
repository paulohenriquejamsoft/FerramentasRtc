namespace CategorizarProdutos.Models.OperacoesFiscais
{
    public class OperacaoFiscalClassificacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CstIbsCbs { get; set; }
        public string CClassTrib { get; set; }

        public string DescricaoCombo => $"{Descricao} - CST: {CstIbsCbs} - Classificação: {CClassTrib}";
    }
}
