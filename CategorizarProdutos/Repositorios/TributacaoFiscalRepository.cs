using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.TributacoesFiscal;
using Dapper;

namespace CategorizarProdutos.Repositorios
{
    public class TributacaoFiscalRepository
    {
        public async Task<List<TributacaoFiscal>> ObterTodas()
        {
            var query = @"
                        SELECT TF.ID, TF.DESCRICAO, SIT.CODIGO CSTIBSCBS, CLASS.CODIGO CCLASSTRIB
                        FROM TRIBUTACAOFISCAL TF 
                        LEFT JOIN CBSIBS_SITUACAOTRIBUTARIA AS SIT ON SIT.ID=TF.IDCSTIBSCBS
                        LEFT JOIN CBSIBS_CLASSIFTRIBUTARIA AS CLASS ON CLASS.ID=TF.IDCLASSIFTRIBUTARIACSTIBSCBS 
                        ORDER BY TF.ID ASC";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<TributacaoFiscal>(query);

            return (resultado ?? new List<TributacaoFiscal>()).ToList();
        }
    }
}
