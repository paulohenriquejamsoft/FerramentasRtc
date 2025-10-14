using Dapper;
using SincApiSefaz.Dao;
using SincApiSefaz.Models.Erp;

namespace SincApiSefaz.Repositorios
{
    public class ClassifTributariaRepository
    {
        public async Task<List<ClassifTributaria>> ObterTodos()
        {
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<ClassifTributaria>("SELECT * FROM CbsIbs_ClassifTributaria ORDER BY ID ASC");

            return (resultado ?? new List<ClassifTributaria>()).ToList();
        }

        public async Task<List<ClassifTributaria>> SalvarAtualizar(List<ClassifTributaria> classificacoes)
        {
            foreach (var situacao in classificacoes)
                await SalvarAtualizar(situacao);

            return classificacoes;
        }

        public async Task<ClassifTributaria> SalvarAtualizar(ClassifTributaria classificacao)
        {
            var cnx = Conexao.ObterConexao();

            if (classificacao.Id > 0)
            {
                var comando = @"UPDATE CbsIbs_ClassifTributaria
                                SET
                                    [IdSituacaoTributaria] = @IdSituacaoTributaria,
                                    [Codigo] = @Codigo,
                                    [Nome] = @Nome,
                                    [Descricao] = @Descricao,
                                    [TipoAliquota] = @TipoAliquota,
                                    [PercReducaoIbs] = @PercReducaoIbs,
                                    [PercReducaoCbs] = @PercReducaoCbs,
                                    [ReducaoBaseCalculo] = @ReducaoBaseCalculo,
                                    [IndTribRegular] = @IndTribRegular,
                                    [IndCredPresumido] = @IndCredPresumido,
                                    [IndMonofasico] = @IndMonofasico,
                                    [IndMonofasicoReten] = @IndMonofasicoReten,
                                    [IndMonofasicoRet] = @IndMonofasicoRet,
                                    [IndMonofasicoDif] = @IndMonofasicoDif,
                                    [IndEstornoCred] = @IndEstornoCred,
                                    [DataIniVigencia] = @DataIniVigencia,
                                    [DataFimVigencia] = @DataFimVigencia,
                                    [DataAtualizacao] = @DataAtualizacao,
                                    [NFe] = @NFe,
                                    [NFCe] = @NFCe,
                                    [NFSe] = @NFSe,
                                    [Link] = @Link
                                WHERE [Id] = @Id;";

                await cnx.ExecuteAsync(comando, classificacao);
            }
            else
            {
                var comando = @"INSERT INTO CbsIbs_ClassifTributaria
                                (
                                    [IdSituacaoTributaria],
                                    [Codigo],
                                    [Nome],
                                    [Descricao],
                                    [TipoAliquota],
                                    [PercReducaoIbs],
                                    [PercReducaoCbs],
                                    [ReducaoBaseCalculo],
                                    [IndTribRegular],
                                    [IndCredPresumido],
                                    [IndMonofasico],
                                    [IndMonofasicoReten],
                                    [IndMonofasicoRet],
                                    [IndMonofasicoDif],
                                    [IndEstornoCred],
                                    [DataIniVigencia],
                                    [DataFimVigencia],
                                    [DataAtualizacao],
                                    [NFe],
                                    [NFCe],
                                    [NFSe],
                                    [Link]
                                )
                                VALUES
                                (
                                    @IdSituacaoTributaria,
                                    @Codigo,
                                    @Nome,
                                    @Descricao,
                                    @TipoAliquota,
                                    @PercReducaoIbs,
                                    @PercReducaoCbs,
                                    @ReducaoBaseCalculo,
                                    @IndTribRegular,
                                    @IndCredPresumido,
                                    @IndMonofasico,
                                    @IndMonofasicoReten,
                                    @IndMonofasicoRet,
                                    @IndMonofasicoDif,
                                    @IndEstornoCred,
                                    @DataIniVigencia,
                                    @DataFimVigencia,
                                    @DataAtualizacao,
                                    @NFe,
                                    @NFCe,
                                    @NFSe,
                                    @Link
                                ); SELECT CAST(SCOPE_IDENTITY() as int);";

                classificacao.Id = await cnx.QuerySingleAsync<int>(comando, classificacao);
            }

            return classificacao;
        }
    }
}
