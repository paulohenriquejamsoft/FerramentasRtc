using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.OperacoesFiscais;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategorizarProdutos.Repositorios
{
    public class OperacaoFiscalRepository
    {
        public async Task<List<OperacaoFiscal>> ObterRegistros()
        {
            var query = @"SELECT OP.ID, OP.DESCRICAO_OPERACAO DESCRICAO, SIT.CODIGO CSTIBSCBS, CLASS.CODIGO CCLASSTRIB 
                            FROM OPERACAO_FISCAL AS OP (NOLOCK)
                            INNER JOIN OPERACAOTRIBUTACAOFISCAL OTF (NOLOCK) ON OTF.IDOPERFISCAL=OP.ID AND OTF.TIPOREGRA=1
                            LEFT JOIN TRIBUTACAOFISCAL TF ON OTF.IDTRIBUTACAOFISCAL=TF.ID
                            LEFT JOIN CBSIBS_SITUACAOTRIBUTARIA AS SIT ON SIT.ID=TF.IDCSTIBSCBS
                            LEFT JOIN CBSIBS_CLASSIFTRIBUTARIA AS CLASS ON CLASS.ID=TF.IDCLASSIFTRIBUTARIACSTIBSCBS 
                            ORDER BY OP.ID ASC
                        ";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<OperacaoFiscal>(query);

            return (resultado ?? new List<OperacaoFiscal>()).ToList();
        }

        public async Task<int> QtdOperacaoFiscalVenda()
        {
            var query = @"select count(*) from operacao_fiscal where rotina_venda=1";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryFirstOrDefaultAsync<int?>(query);

            return resultado ?? 0;
        }

        public async Task InserirOperacaoPadrao()
        {
            var comando = @"INSERT INTO operacao_fiscal 
                        (descricao_operacao, data_cadastro, data_alteracao, rotina_devol_venda, rotina_venda) 
                        VALUES ('Venda', GETDATE(), GETDATE(), 0,1)";
            var cnx = Conexao.ObterConexao();
            await cnx.ExecuteAsync(comando);
        }
    }
}
