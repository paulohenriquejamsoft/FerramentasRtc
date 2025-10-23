using Microsoft.Data.SqlClient;

namespace CategorizarProdutos.Dao
{
    public static class Conexao
    {
        private static SqlConnection _conexaoAtual = null;

        public static string Servidor { get; private set; } = string.Empty;
        public static string Usuario { get; private set; } = string.Empty;
        public static string Senha { get; private set; } = string.Empty;
        public static string NomeBanco { get; private set; } = string.Empty;

        private static string ConnectionString = string.Empty;
        public static void PreencherConexao(string servidor, string usuario, string senha, string banco)
        {
            Servidor = servidor;
            Usuario = usuario;
            Senha = senha;
            NomeBanco = banco;

            ConnectionString = $"Data Source={Servidor}; Initial Catalog={NomeBanco}; User Id={Usuario}; Password={Senha};TrustServerCertificate=True;";
        }

        public static bool TestarConexao()
        {
            try
            {
                ObterConexao();
                return _conexaoAtual.State == System.Data.ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }


        public static SqlConnection ObterConexao()
        {
            if (_conexaoAtual == null || _conexaoAtual.State != System.Data.ConnectionState.Open)
            {
                var conexaoBuilder = new SqlConnectionStringBuilder(ConnectionString)
                {
                    CommandTimeout = 60,
                    ConnectTimeout = 8
                }.ConnectionString;

                _conexaoAtual = new SqlConnection(conexaoBuilder);
                _conexaoAtual.Open();
            }

            return _conexaoAtual;
        }


        public static void FecharConexao()
        {
            if (_conexaoAtual != null && _conexaoAtual.State == System.Data.ConnectionState.Open)
                _conexaoAtual.Close();

            _conexaoAtual = null;
        }
    }
}
