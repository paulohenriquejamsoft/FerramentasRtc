using System.Text.Json;
using SincApiSefaz.Repositorios;
using SincApiSefaz.Servicos;

namespace SincApiSefaz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnSincronizarMunicipios_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().Municipios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao sincronizar municípios: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSituacaoTributaria_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().SituacoesTributarias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao situacoes Tributarias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnClassificacaoTributaria_Click(object sender, EventArgs e)
        {
            try
            {
                await new SincronizacaoGov().ClassificacoesTributarias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao sincronizar classificações tributárias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnClassTrib031025_Click(object sender, EventArgs e)
        {
            try
            {
                var caminhoArquivo = "C:\\Users\\phs\\Downloads\\CST_cClassTrib_2025-10-03_Public_verde.xlsx";

                var excelInstance = new ImportacaoTabClassTrib();
                var (csts, classificacoes) = excelInstance.ExtrairDados(caminhoArquivo);

                await excelInstance.AtualizarCstsBanco(csts);
                await excelInstance.AtualizarCClassificacoesBanco(classificacoes);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao importar classificações tributárias: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExportarCClassTrib_Click(object sender, EventArgs e)
        {
            var registros = await new ClassifTributariaRepository().ObterDadosExportacao();

            var planilha = JsonSerializer.Serialize(registros);
            System.IO.File.WriteAllText("tabela_cst_cclasstrib.json", planilha);
        }
    }
}
