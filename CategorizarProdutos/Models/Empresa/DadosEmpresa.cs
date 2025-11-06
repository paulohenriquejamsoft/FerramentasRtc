namespace CategorizarProdutos.Models.Empresa
{
    public class DadosEmpresa
    {
        public int CodEmpresa { get; set; }
        public string Empresa { get; set; }
        public string Cnpj { get; set; }

        public string DescricaoCombo => $"{Empresa} ({CodEmpresa})";
    }
}
