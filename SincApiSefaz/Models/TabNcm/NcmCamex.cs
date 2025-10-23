using System.Text.Json;
using System.Text.Json.Serialization;

namespace SincApiSefaz.Models.TabNcm
{

    // Link da tabela: https://www.unimake.com.br/downloads/tabela_ncm.json
    public class NcmCamex
    {
        public string Data_Ultima_Atualizacao_NCM { get; set; } = string.Empty;
        public string Ato { get; set; } = string.Empty;
        public List<Nomenclatura> Nomenclaturas { get; set; }
    }

    public class Nomenclatura
    {
        public string Codigo { get; set; } = string.Empty;

        public string CodigoProxy
        {
            get
            {
                return Codigo.Replace(".", "");
            }
        }
        public string Descricao { get; set; } = string.Empty;

        [JsonConverter(typeof(UtcDateTimeConverter))]
        public DateTime Data_Inicio { get; set; }
        public string? Data_Fim { get; set; }
        public string Tipo_Ato { get; set; } = string.Empty;
        public string Numero_Ato { get; set; } = string.Empty;
        public string Ano_Ato { get; set; } = string.Empty;
        public List<InformacaoAnexo> Anexos { get; set; } = new List<InformacaoAnexo>();
    }

    public class InformacaoAnexo
    {
        public string Legislacao { get; set; } = string.Empty;
        public string Anexo { get; set; } = string.Empty;
        public string Cst { get; set; } = string.Empty;
        public string CclasTrib { get; set; } = string.Empty;
    }

    public class UtcDateTimeConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DateTime) || typeToConvert == typeof(DateTime?);
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (dateString == null) return null;
            return DateTime.Parse(dateString);
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {

            if (value != null)
            {
                writer.WriteStringValue(((DateTime)value).ToString("yyyy-MM-ddTHH:mm:ssZ"));

            }
            else if (options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingNull)
            {
                writer.WriteNullValue();
            }
        }
    }
}
