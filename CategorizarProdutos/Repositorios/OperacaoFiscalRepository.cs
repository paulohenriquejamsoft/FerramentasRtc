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
    }
}
