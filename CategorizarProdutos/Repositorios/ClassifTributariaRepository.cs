using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Tabelas;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategorizarProdutos.Repositorios
{
    public class ClassifTributariaRepository
    {
        public async Task<List<ClassifTributaria>> ObterTodas()
        {
            var query = @"
                       SELECT ID,  IDSITUACAOTRIBUTARIA, CODIGO  FROM CBSIBS_CLASSIFTRIBUTARIA ORDER BY ID ASC";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<ClassifTributaria>(query);

            return (resultado ?? new List<ClassifTributaria>()).ToList();
        }
    }
}
