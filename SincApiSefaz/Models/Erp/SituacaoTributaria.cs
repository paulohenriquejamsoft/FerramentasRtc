namespace SincApiSefaz.Models.Erp
{
    public class SituacaoTributaria
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool IndIBSCBS { get; set; }
        public bool IndIBSCBSMono { get; set; }
        public bool IndRed { get; set; }
        public bool IndDif { get; set; }
        public bool IndTransfCred { get; set; }
        public bool IndCredPresIBSZFM { get; set; }
        public bool IndAjusteCompet { get; set; }
    }
}
