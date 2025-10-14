using SincApiSefaz.Dao;

namespace SincApiSefaz
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();

            Conexao.PreencherConexao("192.168.0.167\\sistemas", "sa", "#j@msoft1310*", "Varejo");
            Application.Run(new Form1());
        }
    }
}