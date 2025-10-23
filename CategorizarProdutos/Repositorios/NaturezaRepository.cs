using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Natureza;
using Dapper;

namespace CategorizarProdutos.Repositorios
{
    public class NaturezaRepository
    {
        public async Task<List<NaturezaTributacao>> ObterNaturezasTributacao()
        {
            var query = @"SELECT NATOPERACAO CODNATUREZA, DESCRNATUREZA,CODFISCAL CFOP, TF.ID AS TRIBID, TF.DESCRICAO TRIBDESCRICAO , SIT.CODIGO CSTIBSCBS, CLASS.CODIGO CCLASSTRIB
                        FROM NATOPER NAT
                        LEFT JOIN TRIBUTACAOFISCAL TF ON NAT.IDTRIBUTACAOFISCAL=TF.ID
                        LEFT JOIN CBSIBS_SITUACAOTRIBUTARIA AS SIT ON SIT.ID=TF.IDCSTIBSCBS
                        LEFT JOIN CBSIBS_CLASSIFTRIBUTARIA AS CLASS ON CLASS.ID=TF.IDCLASSIFTRIBUTARIACSTIBSCBS
                        ";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<NaturezaTributacao>(query);

            return (resultado ?? new List<NaturezaTributacao>()).ToList();
        }
    }
}
