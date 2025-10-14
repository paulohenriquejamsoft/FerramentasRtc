using System.Text.Json;
using Dapper;
using SincApiSefaz.Dao;
using SincApiSefaz.Models.Gov.Responses;
using SincApiSefaz.Models.Sge;

namespace SincApiSefaz.Servicos
{
    public class SincronizacaoGov
    {
        const string URL_BASE = "https://piloto-cbs.tributos.gov.br/servico/calculadora-consumo/api";
        private readonly JsonSerializerOptions _jsonOptions;
        public SincronizacaoGov()
        {
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task Municipios()
        {
            var cnx = Conexao.ObterConexao();
            var municipiosCadastrados = await cnx.QueryAsync<TabMunicipios>("select * from TabMunicipios order by CodEstado asc");

            var ufs = municipiosCadastrados.Select(x => new { x.CodEstado, x.NomeEstado })
                                           .Distinct()
                                           .OrderBy(x => x.NomeEstado)
                                           .ToList();

            var municipiosInexistentes = new List<TabMunicipios>();
            foreach (var uf in ufs)
            {
                var municipiosApi = await ConsultarMunicipiosAsync(uf.NomeEstado);
                if (municipiosApi.Any())
                {
                    foreach (var municipioApi in municipiosApi)
                    {
                        var municipiosCadastradosUf = municipiosCadastrados.FirstOrDefault(x => x.CodMunicipio == municipioApi.Codigo);
                        if (municipiosCadastradosUf == null)
                        {

                            municipiosInexistentes.Add(new TabMunicipios
                            {
                                CodMunicipio = municipioApi.Codigo,
                                NomeMunicipio = municipioApi.Nome,
                                CodEstado = uf.CodEstado,
                                NomeEstado = uf.NomeEstado,
                                CodContigencia = municipiosCadastrados.First(x => x.CodEstado == uf.CodEstado).CodContigencia
                            });
                        }
                    }
                }
            }

            if (municipiosInexistentes.Any())
            {
                var insertQuery = @"INSERT INTO TabMunicipios (CodMunicipio, NomeMunicipio, CodEstado, NomeEstado, CodContigencia) 
                                    VALUES (@CodMunicipio, @NomeMunicipio, @CodEstado, @NomeEstado, @CodContigencia)";
                await cnx.ExecuteAsync(insertQuery, municipiosInexistentes);
            }

            var resultado = municipiosCadastrados;
        }

        public async Task SituacoesTributarias()
        {
            var registrosApi = await ConsultarSituacoesTributariasCbsIbsAsync(new DateTime(2026, 1, 1));
            if (registrosApi.Any())
            {
                var cnx = Conexao.ObterConexao();
                await cnx.ExecuteAsync("DELETE FROM CBSIBSSITUACAOTRIBUTARIA");

                foreach (var registro in registrosApi)
                {
                    var insertQuery = @"INSERT INTO CBSIBSSITUACAOTRIBUTARIA (Id, Codigo, Descricao) 
                                    VALUES (@Id, @Codigo, @Descricao)";
                    await cnx.ExecuteAsync(insertQuery, registro);

                }
            }
        }

        public async Task ClassificacoesTributarias()
        {
            var excluirClassificacao = true;
            var cnx = Conexao.ObterConexao();

            var situacoesTributarias = await cnx.QueryAsync<CbsIbsSituacaoTributaria>("SELECT * FROM CbsIbsSituacaoTributaria order by id asc");
            foreach (var situacaoTributaria in situacoesTributarias)
            {
                var registrosApi = await ConsultarClassificacoesTributariasCbsIbsAsync(situacaoTributaria.Id, new DateTime(2026, 1, 1));
                if (registrosApi.Any())
                {
                    if (excluirClassificacao)
                    {
                        await cnx.ExecuteAsync("DELETE FROM CBSIBSCLASSIFICACAOTRIBUTARIA");
                        excluirClassificacao = false;
                    }
                    
                    foreach (var registro in registrosApi)
                    {
                        var insertQuery = @"INSERT INTO [dbo].[CbsIbsClassificacaoTributaria]
                                           ([IdSituacaoTributaria]
                                           ,[Codigo]
                                           ,[Descricao]
                                           ,[TipoAliquota]
                                           ,[Nomenclatura]
                                           ,[DescricaoTratamentoTributario]
                                           ,[IncompativelComSuspensao]
                                           ,[ExigeGrupoDesoneracao]
                                           ,[PossuiPercentualReducao])
                                     VALUES
                                           (@IdSituacaoTributaria
                                           ,@Codigo
                                           ,@Descricao
                                           ,@TipoAliquota
                                           ,@Nomenclatura
                                           ,@DescricaoTratamentoTributario
                                           ,@IncompativelComSuspensao
                                           ,@ExigeGrupoDesoneracao
                                           ,@PossuiPercentualReducao)";
                        await cnx.ExecuteAsync(insertQuery, new
                        {
                            IdSituacaoTributaria = situacaoTributaria.Id,
                            registro.Codigo,
                            registro.Descricao,
                            registro.TipoAliquota,
                            registro.Nomenclatura,
                            registro.DescricaoTratamentoTributario,
                            registro.IncompativelComSuspensao,
                            registro.ExigeGrupoDesoneracao,
                            registro.PossuiPercentualReducao
                        });
                    }
                }
            }          
        }
        private async Task<List<ClassificacaoTributariaDadosAbertosOutput>> ConsultarClassificacoesTributariasCbsIbsAsync(int idSituacaoTributaria, DateTime data)
        {
            var dataFormatada = data.ToString("yyyy-MM-dd");
            var url = $"{URL_BASE}/calculadora/dados-abertos/classificacoes-tributarias/{idSituacaoTributaria}?data={dataFormatada}";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ClassificacaoTributariaDadosAbertosOutput>>(responseJson, _jsonOptions) ?? new List<ClassificacaoTributariaDadosAbertosOutput>();
        }

        public async Task<List<UfDadosAbertosOutput>> ConsultarUfsAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{URL_BASE}/calculadora/dados-abertos/ufs");
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UfDadosAbertosOutput>>(responseJson, _jsonOptions) ?? new List<UfDadosAbertosOutput>();
        }

        private async Task<List<MunicipioDadosAbertosOutput>> ConsultarMunicipiosAsync(string siglaUf)
        {
            var httpClient = new HttpClient();
            var url = $"{URL_BASE}/calculadora/dados-abertos/ufs/municipios?siglaUf={Uri.EscapeDataString(siglaUf)}";
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<MunicipioDadosAbertosOutput>>(responseJson, _jsonOptions) ?? new List<MunicipioDadosAbertosOutput>();
        }

        private async Task<List<SituacaoTributariaDadosAbertosOutput>> ConsultarSituacoesTributariasCbsIbsAsync(DateTime data)
        {
            var dataFormatada = data.ToString("yyyy-MM-dd");
            var url = $"{URL_BASE}/calculadora/dados-abertos/situacoes-tributarias/cbs-ibs?data={dataFormatada}";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SituacaoTributariaDadosAbertosOutput>>(responseJson, _jsonOptions) ?? new List<SituacaoTributariaDadosAbertosOutput>();
        }

    }
}
