using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Empresa;
using Dapper;

namespace CategorizarProdutos.Repositorios
{
    public class EmpresaRepository
    {
        public async Task<List<DadosEmpresa>> ObterEmpresas()
        {
            var query = @"SELECT CODEMPRESA, EMPRESA, CNPJ
                            FROM CADEMPRESA AS EMP
                            INNER JOIN CLIENTES AS CLI ON CLI.CODIGO=EMP.CODEMPRESA
                            ORDER BY CODEMPRESA ASC";
            var cnx = Conexao.ObterConexao();
            var resultado = await cnx.QueryAsync<DadosEmpresa>(query);

            return (resultado ?? new List<DadosEmpresa>()).ToList();
        }
    }
}
