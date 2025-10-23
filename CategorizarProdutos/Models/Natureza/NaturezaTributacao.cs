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
                if (string.IsNullOrEmpty(Cfop))
                    return 0;

                return Convert.ToInt32(Cfop.Replace(".", ""));
            }
        }

        public int TribId { get; set; }
        public string TribDescricao { get; set; }
        public string CstIbsCbs { get; set; }
        public string CclassTrib { get; set; }
    }
}
