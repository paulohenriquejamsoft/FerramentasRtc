namespace SincApiSefaz.Models.Gov.Responses;


public class ClassificacaoTributariaDadosAbertosOutput
{
    public string Codigo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string TipoAliquota { get; set; } = string.Empty;
    public string Nomenclatura { get; set; } = string.Empty;
    public string DescricaoTratamentoTributario { get; set; } = string.Empty;
    public bool IncompativelComSuspensao { get; set; }
    public bool ExigeGrupoDesoneracao { get; set; }
    public bool PossuiPercentualReducao { get; set; }
}
public class SituacaoTributariaDadosAbertosOutput
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}

public class MunicipioDadosAbertosOutput
{
    public string Nome { get; set; } = string.Empty;
    public int Codigo { get; set; }
}


public class UfDadosAbertosOutput
{
    public string Sigla { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public int Codigo { get; set; }
}
public class ROC
{
    public List<Objeto> Objetos { get; set; } = new();
    public ValoresTotais? Total { get; set; }
}

public class Objeto
{
    public int NObj { get; set; }
    public Tributos? TribCalc { get; set; }
}

public class ValoresTotais
{
    public TributosTotais? TribCalc { get; set; }
}

public class TributosTotais
{
    public ImpostoSeletivoTotal? ISTot { get; set; }
    public IBSCBSTotal? IBSCBSTot { get; set; }
}

public class Tributos
{
    public ImpostoSeletivo? IS { get; set; }
    public IBSCBS? IBSCBS { get; set; }
}

public class ImpostoSeletivo
{
    public int CSTIS { get; set; }
    public string? CClassTribIS { get; set; }
    public decimal? VBCIS { get; set; }
    public decimal? PIS { get; set; }
    public decimal? PISEspec { get; set; }
    public string? UTrib { get; set; }
    public decimal? QTrib { get; set; }
    public decimal? VIS { get; set; }
    public string? MemoriaCalculo { get; set; }
}

public class IBSCBS
{
    public int CST { get; set; }
    public string? CClassTrib { get; set; }
    public GrupoIBSCBS? GIBSCBS { get; set; }
}

public class GrupoIBSCBS
{
    public decimal? VBC { get; set; }
    public IBSUF? GIBSUF { get; set; }
    public IBSMun? GIBSMun { get; set; }
    public CBS? GCBS { get; set; }
}

public class IBSUF
{
    public decimal? PIBSUF { get; set; }
    public decimal? VIBSUF { get; set; }
    public string? MemoriaCalculo { get; set; }
}

public class IBSMun
{
    public decimal? PIBSMun { get; set; }
    public decimal? VIBSMun { get; set; }
    public string? MemoriaCalculo { get; set; }
}

public class CBS
{
    public decimal? PCBS { get; set; }
    public decimal? VCBS { get; set; }
    public string? MemoriaCalculo { get; set; }
}

public class ImpostoSeletivoTotal
{
    public decimal? VIS { get; set; }
}

public class IBSCBSTotal
{
    public decimal? VBCIBSCBS { get; set; }
    public IBSTotal? GIBS { get; set; }
    public CBSTotal? GCBS { get; set; }
}

public class IBSTotal
{
    public decimal? VIBS { get; set; }
}

public class CBSTotal
{
    public decimal? VCBS { get; set; }
}

public class PedagioOutput
{
    public DateTime DataHoraEmissao { get; set; }
    public long MunicipioOrigem { get; set; }
    public string UfMunicipioOrigem { get; set; } = string.Empty;
    public string Cst { get; set; } = string.Empty;
    public decimal BaseCalculo { get; set; }
    public decimal ExtensaoTotal { get; set; }
    public List<TrechoPedagioOutput> Trechos { get; set; } = new();
    public TotalPedagioOutput? Total { get; set; }
    public string CClassTrib { get; set; } = string.Empty;
}

public class TrechoPedagioOutput
{
    public int Numero { get; set; }
    public long Municipio { get; set; }
    public string Uf { get; set; } = string.Empty;
    public decimal BaseCalculo { get; set; }
    public decimal ExtensaoTrecho { get; set; }
    public decimal ExtensaoTotal { get; set; }
    public TributoPedagioOutput? Cbs { get; set; }
    public TributoPedagioOutput? IbsEstadual { get; set; }
    public TributoPedagioOutput? IbsMunicipal { get; set; }
}

public class TributoPedagioOutput
{
    public decimal Aliquota { get; set; }
    public decimal AliquotaEfetiva { get; set; }
    public decimal TributoCalculado { get; set; }
    public string? MemoriaCalculo { get; set; }
}

public class TotalPedagioOutput
{
    public TributoTotalPedagioOutput? CbsTotal { get; set; }
    public TributoTotalPedagioOutput? IbsEstadualTotal { get; set; }
    public TributoTotalPedagioOutput? IbsMunicipalTotal { get; set; }
}

public class TributoTotalPedagioOutput
{
    public decimal BaseCalculo { get; set; }
    public decimal ValorApurado { get; set; }
    public decimal ValorDevido { get; set; }
    public decimal ValorTributo { get; set; }
    public decimal TotalMontanteDesonerado { get; set; }
}
