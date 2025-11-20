using System;

namespace CategorizarProdutos.Models.Natureza
{
    public class NaturezaTributacao
    {
        public int CodNatureza { get; set; }
        public string DescrNatureza { get; set; }
        public string Cfop { get; set; }

        public int CfopProxy
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Cfop))
                    return 0;

                return Convert.ToInt32(Cfop.Replace(".", ""));
            }
        }

        public int OpId { get; set; }
        public string OpDescricao { get; set; }
        public string CstIbsCbs { get; set; }
        public string CclassTrib { get; set; }

        public bool isSelecionado { get; set; }
    }
}
