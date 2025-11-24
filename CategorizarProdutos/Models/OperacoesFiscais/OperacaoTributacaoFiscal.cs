namespace CategorizarProdutos.Models.OperacoesFiscais
{
    public class OperacaoTributacaoFiscal
    {
        public int Id { get; set; }
        public int IdOperFiscal { get; set; }
        public int IdTributacaoFiscal { get; set; }
        public int TipoRegra { get; set; }
        public string Ncm { get; set; }
    }
}
