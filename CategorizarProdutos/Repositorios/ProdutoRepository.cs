using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Produtos;
using Dapper;

namespace CategorizarProdutos.Repositorios
{
    public class ProdutoRepository
    {
        public async Task<List<ProdutoClassificacao>> ObterParaClassificacao()
        {
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<ProdutoClassificacao>("SELECT CODPROD, PRODUTO, APELIDOPROD, CODIGOBARRA, CODIGONCM FROM PRODUTOS WHERE CODIGONCM<>'00000000' AND LEN(CODIGONCM)=8 ORDER BY CODPROD ASC");

            return (resultado ?? new List<ProdutoClassificacao>()).ToList();
        }
    }
}
