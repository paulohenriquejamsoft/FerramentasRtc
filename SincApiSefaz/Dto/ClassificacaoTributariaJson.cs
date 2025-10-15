namespace SincApiSefaz.Dto
{
    public class ClassificacaoTributariaJson
    {
        public string CstIbs { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoAliquota { get; set; }
        public decimal PercReducaoIbs { get; set; }
        public decimal PercReducaoCbs { get; set; }
        public bool ReducaoBaseCalculo { get; set; }
        public bool IndTribRegular { get; set; }
        public bool IndCredPresumido { get; set; }
        public bool IndMonofasico { get; set; }
        public bool IndMonofasicoReten { get; set; }
        public bool IndMonofasicoRet { get; set; }
        public bool IndMonofasicoDif { get; set; }
        public bool IndEstornoCred { get; set; }
        public DateTime DataIniVigencia { get; set; }
        public DateTime? DataFimVigencia { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string Link { get; set; }

        public bool NFe { get; set; }
        public bool NFCe { get; set; }
        public bool NFSe { get; set; }
    }
}
