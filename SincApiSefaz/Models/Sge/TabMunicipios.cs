namespace SincApiSefaz.Models.Sge;

internal class TabMunicipios
{
    public int CodMunicipio { get; set; }
    public string NomeMunicipio { get; set; } = string.Empty;
    public int CodEstado { get; set; }
    public string NomeEstado { get; set; } = string.Empty;
    public int CodContigencia { get; set; }
}
