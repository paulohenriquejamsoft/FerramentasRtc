using System.ComponentModel.DataAnnotations;

namespace SincApiSefaz.Models.Gov.Requests;

internal class Modelos
{
    public class OperacaoInput
    {
        [Required]
        public string Id { get; set; } = string.Empty;

        [Required]
        public string Versao { get; set; } = string.Empty;

        [Required]
        public DateTime DataHoraEmissao { get; set; }

        [Required]
        [Range(0, 9999)]
        public long Municipio { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Uf { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public List<ItemOperacaoInput> Itens { get; set; } = new();
    }

    public class ItemOperacaoInput
    {
        [Required]
        [Range(1, 9999)]
        public int Numero { get; set; }

        public string? Ncm { get; set; }
        public string? Nbs { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(@"\d+")]
        public string Cst { get; set; } = string.Empty;

        [Required]
        public decimal BaseCalculo { get; set; }

        public decimal? Quantidade { get; set; }
        public string? Unidade { get; set; }

        public ImpostoSeletivoInput? ImpostoSeletivo { get; set; }
        public TributacaoRegularInput? TributacaoRegular { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"\d+")]
        public string CClassTrib { get; set; } = string.Empty;
    }

    public class ImpostoSeletivoInput
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(@"\d+")]
        public string Cst { get; set; } = string.Empty;

        [Required]
        public decimal BaseCalculo { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        [MinLength(1)]
        public string Unidade { get; set; } = string.Empty;

        [Required]
        public decimal ImpostoInformado { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"\d+")]
        public string CClassTrib { get; set; } = string.Empty;
    }

    public class TributacaoRegularInput
    {
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression(@"\d+")]
        public string Cst { get; set; } = string.Empty;

        [Required]
        [StringLength(6, MinimumLength = 6)]
        [RegularExpression(@"\d+")]
        public string CClassTrib { get; set; } = string.Empty;
    }

    public class PedagioInput
    {
        [Required]
        public DateTime DataHoraEmissao { get; set; }

        [Required]
        [Range(0, 9999)]
        public long CodigoMunicipioOrigem { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string UfMunicipioOrigem { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Cst { get; set; } = string.Empty;

        [Required]
        public decimal BaseCalculo { get; set; }

        [Required]
        [MinLength(1)]
        public List<TrechoPedagioInput> Trechos { get; set; } = new();

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string CClassTrib { get; set; } = string.Empty;
    }

    public class TrechoPedagioInput
    {
        [Required]
        public int Numero { get; set; }

        [Required]
        [Range(0, 9999)]
        public long Municipio { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Uf { get; set; } = string.Empty;

        [Required]
        public decimal Extensao { get; set; }
    }

}
