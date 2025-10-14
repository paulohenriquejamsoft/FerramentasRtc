namespace SincApiSefaz.Models.Erp
{
    public class ClassifTributaria
    {
        public int Id { get; set; }
        public int IdSituacaoTributaria { get; set; }

        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value == null ? string.Empty : value;

                if (codigo.Length > 6)
                    codigo = codigo.Substring(0, 6);
            }
        }
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

        private DateTime dataIniVigencia;
        public DateTime DataIniVigencia
        {
            get { return dataIniVigencia; }
            set
            {
                dataIniVigencia = value == DateTime.MinValue ? new DateTime(1900, 1, 1) : value;
            }
        }

        private DateTime? dataFimVigencia;
        public DateTime? DataFimVigencia
        {
            get { return dataFimVigencia; }
            set
            {
                dataFimVigencia = value == null || value == DateTime.MinValue ? new DateTime(1900, 1, 1) : value;
            }
        }

        private DateTime dataAtualizacao;
        public DateTime DataAtualizacao
        {
            get { return dataAtualizacao; }
            set
            {
                dataAtualizacao = value == DateTime.MinValue ? DateTime.Now : value;
            }
        }
        public bool NFe { get; set; }
        public bool NFCe { get; set; }
        public bool NFSe { get; set; }
        public string Link { get; set; }

    }
}
