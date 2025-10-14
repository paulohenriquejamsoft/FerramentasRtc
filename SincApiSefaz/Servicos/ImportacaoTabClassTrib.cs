using ClosedXML.Excel;
using SincApiSefaz.Models.Erp;
using SincApiSefaz.Models.TabCclassTrib;
using SincApiSefaz.Repositorios;

namespace SincApiSefaz.Servicos
{
    public class ImportacaoTabClassTrib
    {
        public (List<Cst03102025> Csts, List<CstClassTrib03102025> Classificacoes) ExtrairDados(string arquivoXls)
        {
            var listaCsts = new List<Cst03102025>();
            var listaClassificacoes = new List<CstClassTrib03102025>();

            using (var workbook = new XLWorkbook(arquivoXls))
            {
                var worksheet = workbook.Worksheet(1); // Primeira planilha
                var linhas = worksheet.RangeUsed().RowsUsed().Skip(1); // Pula o cabeçalho

                foreach (var linha in linhas)
                {
                    linha.Cell(1).TryGetValue<string>(out string cstIbs);
                    linha.Cell(3).TryGetValue<int>(out int indGIbsCbs);
                    linha.Cell(4).TryGetValue<int>(out int indGIbsCbsMono);
                    linha.Cell(5).TryGetValue<int>(out int indGRed);
                    linha.Cell(6).TryGetValue<int>(out int indGDif);
                    linha.Cell(7).TryGetValue<int>(out int indGTransfCred);
                    linha.Cell(8).TryGetValue<int>(out int indGCredPresIbsZfm);
                    linha.Cell(9).TryGetValue<int>(out int indGAjusteCompet);

                    var tamanhoCst = 3;
                    if (cstIbs.Length != tamanhoCst)
                        continue;

                    var item = new Cst03102025
                    {
                        CstIbsCbs = cstIbs,
                        DescricaoCstIbsCbs = linha.Cell(2).GetValue<string>(),
                        IndGIbsCbs = indGIbsCbs,
                        IndGIbsCbsMono = indGIbsCbsMono,
                        IndGRed = indGRed,
                        IndGDif = indGDif,
                        IndGTransfCred = indGTransfCred,
                        IndGCredPresIbsZfm = indGCredPresIbsZfm,
                        IndGAjusteCompet = indGAjusteCompet
                    };

                    listaCsts.Add(item);
                }

                worksheet = workbook.Worksheet(2); // Primeira planilha
                linhas = worksheet.RangeUsed().RowsUsed().Skip(1); // Pula o cabeçalho

                foreach (var linha in linhas)
                {
                    linha.Cell(1).TryGetValue<string>(out string cstIbsCbs);
                    linha.Cell(2).TryGetValue<string>(out string descricaoCstIbsCbs);
                    linha.Cell(3).TryGetValue<string>(out string cClassTrib);
                    linha.Cell(4).TryGetValue<string>(out string nomecClassTrib);
                    linha.Cell(5).TryGetValue<string>(out string descricaocClassTrib);
                    linha.Cell(8).TryGetValue<string>(out string tipoAliquota);
                    linha.Cell(9).TryGetValue<decimal>(out decimal pRedIbs);
                    linha.Cell(10).TryGetValue<decimal>(out decimal pRedCbs);
                    linha.Cell(11).TryGetValue<bool>(out bool indRedutorBase);
                    linha.Cell(12).TryGetValue<bool>(out bool indgTribRegular);
                    linha.Cell(13).TryGetValue<bool>(out bool indgCredPresOper);
                    linha.Cell(14).TryGetValue<bool>(out bool indgMonoPadrao);
                    linha.Cell(15).TryGetValue<bool>(out bool indgMonoReten);
                    linha.Cell(16).TryGetValue<bool>(out bool indgMonoRet);
                    linha.Cell(17).TryGetValue<bool>(out bool indgMonoDif);
                    linha.Cell(18).TryGetValue<bool>(out bool indgEstornoCred);
                    linha.Cell(20).TryGetValue<DateTime>(out DateTime dIniVig);
                    linha.Cell(21).TryGetValue<DateTime?>(out DateTime? dFimVig);
                    linha.Cell(22).TryGetValue<DateTime>(out DateTime dataAtualizacao);

                    linha.Cell(24).TryGetValue<bool>(out bool indNfe);
                    linha.Cell(25).TryGetValue<bool>(out bool indNfce);
                    linha.Cell(26).TryGetValue<bool>(out bool indCte);
                    linha.Cell(32).TryGetValue<bool>(out bool indNfse);
                    linha.Cell(39).TryGetValue<string>(out string link);

                    var tamanhoMinimocClassTrib = 6;
                    if (cClassTrib.Length < tamanhoMinimocClassTrib)
                        continue;

                    var item = new CstClassTrib03102025
                    {
                        CstIbsCbs = cstIbsCbs,
                        DescricaoCstIbsCbs = descricaoCstIbsCbs,
                        cClassTrib = cClassTrib,
                        NomecClassTrib = nomecClassTrib,
                        DescricaocClassTrib = descricaocClassTrib,
                        TipoAliquota = tipoAliquota,
                        PRedIbs = pRedIbs,
                        PRedCbs = pRedCbs,
                        IndRedutorBase = indRedutorBase,
                        IndgTribRegular = indgTribRegular,
                        IndgCredPresOper = indgCredPresOper,
                        IndgMonoPadrao = indgMonoPadrao,
                        IndgMonoReten = indgMonoReten,
                        IndgMonoRet = indgMonoRet,
                        IndgMonoDif = indgMonoDif,
                        IndgEstornoCred = indgEstornoCred,
                        DIniVig = dIniVig,
                        DFimVig = dFimVig ?? new DateTime(1900, 1, 1),
                        DataAtualizacao = dataAtualizacao,
                        IndNfe = indNfe,
                        IndNfce = indNfce,
                        IndNfse = indNfse,
                        IndCte = indCte,
                        Link = link
                    };

                    listaClassificacoes.Add(item);
                }
            }

            return (listaCsts, listaClassificacoes);
        }

        public async Task<List<SituacaoTributaria>> AtualizarCstsBanco(List<Cst03102025> csts)
        {
            var situacaoTributariaRepository = new SituacaoTributariaRepository();
            var registrosExistentes = await situacaoTributariaRepository.ObterTodos();

            var situacoes = new List<SituacaoTributaria>();
            foreach (var cst in csts)
            {
                var registro = registrosExistentes.Find(x => x.Codigo.Equals(cst.CstIbsCbs));
                var situacaoConvertida = MontarSituacaoTributaria(registro, cst);
                situacoes.Add(situacaoConvertida);
            }

            if (situacoes.Count > 0)
                await situacaoTributariaRepository.SalvarAtualizar(situacoes);

            return situacoes;
        }

        public async Task<List<ClassifTributaria>> AtualizarCClassificacoesBanco(List<CstClassTrib03102025> classificacoes)
        {
            var situacaoTributariaRepository = new SituacaoTributariaRepository();
            var situacoes = await situacaoTributariaRepository.ObterTodos();

            var classifTributariaRepository = new ClassifTributariaRepository();
            var registrosExistentes = await classifTributariaRepository.ObterTodos();

            var registros = new List<ClassifTributaria>();
            foreach (var classificacao in classificacoes)
            {
                var registro = registrosExistentes.Find(x => x.Codigo.Equals(classificacao.cClassTrib));
                var situacaoConvertida = MontarClassifTributaria(registro, classificacao);

                var situacao = situacoes.Find(x => x.Codigo == classificacao.CstIbsCbs);
                if(situacao != null)
                {
                    situacaoConvertida.IdSituacaoTributaria = situacao.Id;
                    registros.Add(situacaoConvertida);
                }                
            }

            if (registros.Count > 0)
                await classifTributariaRepository.SalvarAtualizar(registros);

            return registros;
        }

        private SituacaoTributaria MontarSituacaoTributaria(SituacaoTributaria? situacao, Cst03102025 cst)
        {
            if (situacao == null)
                situacao = new SituacaoTributaria();

            situacao.Codigo = cst.CstIbsCbs;
            situacao.Descricao = cst.DescricaoCstIbsCbs;
            situacao.IndIBSCBS = cst.IndGIbsCbs == 1;
            situacao.IndIBSCBSMono = cst.IndGIbsCbsMono == 1;
            situacao.IndRed = cst.IndGRed == 1;
            situacao.IndDif = cst.IndGDif == 1;
            situacao.IndTransfCred = cst.IndGTransfCred == 1;
            situacao.IndCredPresIBSZFM = cst.IndGCredPresIbsZfm == 1;
            situacao.IndAjusteCompet = cst.IndGAjusteCompet == 1;

            return situacao;
        }

        private ClassifTributaria MontarClassifTributaria(ClassifTributaria? classificacao, CstClassTrib03102025 cstClassificacao)
        {
            if (classificacao == null)
                classificacao = new ClassifTributaria();

            classificacao.Codigo = cstClassificacao.cClassTrib;
            classificacao.Nome = cstClassificacao.NomecClassTrib;
            classificacao.Descricao = cstClassificacao.DescricaocClassTrib;
            classificacao.TipoAliquota = cstClassificacao.TipoAliquota;
            classificacao.PercReducaoIbs = cstClassificacao.PRedIbs;
            classificacao.PercReducaoCbs = cstClassificacao.PRedCbs;
            classificacao.ReducaoBaseCalculo = cstClassificacao.IndRedutorBase;
            classificacao.IndTribRegular = cstClassificacao.IndgTribRegular;
            classificacao.IndCredPresumido = cstClassificacao.IndgCredPresOper;
            classificacao.IndMonofasico = cstClassificacao.IndgMonoPadrao;
            classificacao.IndMonofasicoReten = cstClassificacao.IndgMonoReten;
            classificacao.IndMonofasicoRet = cstClassificacao.IndgMonoRet;
            classificacao.IndMonofasicoDif = cstClassificacao.IndgMonoDif;
            classificacao.IndEstornoCred = cstClassificacao.IndgEstornoCred;
            classificacao.DataIniVigencia = cstClassificacao.DIniVig;
            classificacao.DataFimVigencia = cstClassificacao.DFimVig;
            classificacao.DataAtualizacao = cstClassificacao.DataAtualizacao;
            classificacao.NFe = cstClassificacao.IndNfe;
            classificacao.NFCe = cstClassificacao.IndNfce;
            classificacao.NFSe = cstClassificacao.IndNfse;
            classificacao.Link = cstClassificacao.Link;
            return classificacao;
        }
    }
}
