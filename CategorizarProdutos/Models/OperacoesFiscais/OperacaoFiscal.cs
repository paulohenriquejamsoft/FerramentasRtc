namespace CategorizarProdutos.Models.OperacoesFiscais
{
    public class OperacaoFiscal
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public string DescricaoCombo => $"{Descricao} - {Id}";
    }
}
