namespace CategorizarProdutos.Models.TributacoesFiscal
{
    public class TributacaoFiscal
    {
        public int Id { get; set; }
        public int IdCstIbsCbs { get; set; }
        public int IdClassifTributariaCstIbsCbs { get; set; }
        public string Descricao { get; set; }
        public int Governamental { get; set; }
        public int tpEntiGovernamental { get; set; }
        public decimal pRedutor { get; set; }
        public int TpOperGov { get; set; }
    }
}
