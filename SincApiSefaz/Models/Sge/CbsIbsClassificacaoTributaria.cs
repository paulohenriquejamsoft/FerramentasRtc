namespace SincApiSefaz.Models.Sge;

internal class CbsIbsClassificacaoTributaria
{
    public int Id { get; set; }
    public int IdSituacaoTributaria { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string TipoAliquota { get; set; } = string.Empty;
    public string Nomenclatura { get; set; } = string.Empty;
    public string DescricaoTratamentoTributario { get; set; } = string.Empty;
    public bool IncompativelComSuspensao { get; set; }
    public bool ExigeGrupoDesoneracao { get; set; }
    public bool PossuiPercentualReducao { get; set; }
}
