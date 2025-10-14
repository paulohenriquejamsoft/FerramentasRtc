using Dapper;
using SincApiSefaz.Dao;
using SincApiSefaz.Models.Erp;

namespace SincApiSefaz.Repositorios
{
    public class SituacaoTributariaRepository
    {
        public async Task<List<SituacaoTributaria>> ObterTodos()
        {
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<SituacaoTributaria>("SELECT * FROM CBSIBS_SITUACAOTRIBUTARIA ORDER BY ID ASC");

            return (resultado ?? new List<SituacaoTributaria>()).ToList();
        }


        public async Task<List<SituacaoTributaria>> SalvarAtualizar(List<SituacaoTributaria> situacoes)
        {
            foreach (var situacao in situacoes)
                await SalvarAtualizar(situacao);

            return situacoes;
        }

        public async Task<SituacaoTributaria> SalvarAtualizar(SituacaoTributaria situacao)
        {
            var cnx = Conexao.ObterConexao();

            if (situacao.Id > 0)
            {
                var comando = @"UPDATE [dbo].[CbsIbs_SituacaoTributaria]
                               SET [Codigo] = @Codigo
                                  ,[Descricao] = @Descricao
                                  ,[IndIBSCBS] = @IndIBSCBS
                                  ,[indIBSCBSMono] = @IndIBSCBSMono
                                  ,[IndRed] = @IndRed
                                  ,[IndDif] = @IndDif
                                  ,[IndTransfCred] = @IndTransfCred
                                  ,[IndCredPresIBSZFM] = @IndCredPresIBSZFM
                                  ,[IndAjusteCompet] = @IndAjusteCompet
                                WHERE ID=@Id";

                await cnx.ExecuteAsync(comando, situacao);
            }
            else
            {
                var comando = @"INSERT INTO [dbo].[CbsIbs_SituacaoTributaria]
                               ([Codigo]
                               ,[Descricao]
                               ,[IndIBSCBS]
                               ,[indIBSCBSMono]
                               ,[IndRed]
                               ,[IndDif]
                               ,[IndTransfCred]
                               ,[IndCredPresIBSZFM]
                               ,[IndAjusteCompet])
                         VALUES
                               (@Codigo
                               ,@Descricao
                               ,@IndIBSCBS
                               ,@IndIBSCBSMono
                               ,@IndRed
                               ,@IndDif
                               ,@IndTransfCred
                               ,@IndCredPresIBSZFM
                               ,@IndAjusteCompet); SELECT CAST(SCOPE_IDENTITY() as int);";

                situacao.Id = await cnx.QuerySingleAsync<int>(comando, situacao);                
            }

            return situacao;
        }
    }
}
