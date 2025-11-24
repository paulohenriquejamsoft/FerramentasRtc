using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Natureza;
using CategorizarProdutos.Models.OperacoesFiscais;
using CategorizarProdutos.Models.TributacoesFiscal;
using CategorizarProdutos.Repositorios;
using ClosedXML.Excel;
using Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategorizarProdutos
{
    public partial class FrmImportarClassificacao : Form
    {
        List<ClassificacaoExcel> _classificacoes = new List<ClassificacaoExcel>();
        public FrmImportarClassificacao()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmImportarClassificacao_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dtGridTributacoes.AutoGenerateColumns = false;
            dtGridTributacoes.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtGridTributacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(ClassificacaoExcel.Cst),
                HeaderText = "CST",
                DataPropertyName = nameof(ClassificacaoExcel.Cst),
                Width = 100
            });

            dtGridTributacoes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(ClassificacaoExcel.CClassTrib),
                HeaderText = "cClasstrib",
                DataPropertyName = nameof(ClassificacaoExcel.CClassTrib),
                Width = 250
            });
        }

        private List<ClassificacaoExcel> ObterClassificacoesGrid()
        {
            List<ClassificacaoExcel> classificacoes = new List<ClassificacaoExcel>();
            foreach (DataGridViewRow row in dtGridTributacoes.Rows)
            {
                var natureza = row.DataBoundItem as ClassificacaoExcel;
                classificacoes.Add(natureza);
            }
            return classificacoes;
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (_classificacoes.Count == 0)
            {
                MessageBox.Show("Nenhuma classificação importada para cadastrar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idOperacao = cbTributacoes.SelectedValue;
            if (idOperacao == null)
            {
                MessageBox.Show("Selecione uma Operação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tabClassificacoes = await new ClassifTributariaRepository().ObterTodas();

            var tributacaoFiscalRepo = new TributacaoFiscalRepository();

            var tribCadastradas = await tributacaoFiscalRepo.ObterTodas();
            var classificGrid = ObterClassificacoesGrid();
            var novosRegistros = false;
            foreach (var classificacao in classificGrid)
            {
                var registro = tribCadastradas.Find(t => t.CclassTrib == classificacao.CClassTrib);
                if (registro == null)
                {
                    var registroClassif = tabClassificacoes.Find(c => c.Codigo == classificacao.CClassTrib);
                    await tributacaoFiscalRepo.AdicionarAsync(new TributacaoFiscal
                    {
                        IdCstIbsCbs = registroClassif.IdSituacaoTributaria,
                        IdClassifTributariaCstIbsCbs = registroClassif.Id,
                        Descricao = "",
                        Governamental = 1,
                        tpEntiGovernamental = 0,
                        pRedutor = 0m,
                        TpOperGov = 0
                    });
                    novosRegistros = true;
                }
            }

            // recarrega as tributacoes
            if(novosRegistros)
                tribCadastradas = await tributacaoFiscalRepo.ObterTodas();


            var OperacaoFRepo = new OperacaoFiscalRepository();
            var regras = await OperacaoFRepo.ObterRegrasOperacao(Convert.ToInt32(idOperacao));
            foreach (var classificacao in classificGrid)
            {
                var tributacao = tribCadastradas.Find(t => t.CclassTrib == classificacao.CClassTrib);
                var cClassTribPadrao = "000001";

                var iscClassTribPadrao = classificacao.CClassTrib.Equals(cClassTribPadrao);

                OperacaoTributacaoFiscal regra;
                if (iscClassTribPadrao)
                {
                    regra = regras.Find(r => r.IdTributacaoFiscal == tributacao.Id && r.TipoRegra == 1);
                    if(regra == null)
                    {
                        await OperacaoFRepo.InserirRegrasOperacao(new OperacaoTributacaoFiscal
                        {
                            IdOperFiscal = Convert.ToInt32(idOperacao),
                            IdTributacaoFiscal = tributacao.Id,
                            TipoRegra = 1,
                            Ncm = ""
                        });
                    }

                    _classificacoes.RemoveAll(t => t.CClassTrib == classificacao.CClassTrib);
                    continue;
                }
                else
                {
                    var registrosClassif = _classificacoes
                                        .Where(t => t.CClassTrib == classificacao.CClassTrib)
                                        .GroupBy(c => new { c.Ncm, c.CClassTrib })
                                        .Select(x => x.First())
                                        .ToList();
                    foreach (var registroClassif in registrosClassif)
                    {
                        regra = regras.Find(r => r.IdTributacaoFiscal == tributacao.Id && r.TipoRegra == 2 && r.Ncm.Equals(registroClassif.Ncm));
                        if(regra == null)
                        {
                            await OperacaoFRepo.InserirRegrasOperacao(new OperacaoTributacaoFiscal
                            {
                                IdOperFiscal = Convert.ToInt32(idOperacao),
                                IdTributacaoFiscal = tributacao.Id,
                                TipoRegra = 2,
                                Ncm = registroClassif.Ncm
                            });
                        }
                    }
                }

                    
                //var registrosClassif = _classificacoes.Where(t => t.CClassTrib == classificacao.CClassTrib).ToList();
                //foreach (var registroClassif in registrosClassif)
                //{

                //}

                //_classificacoes.RemoveAll(t => t.CClassTrib == classificacao.CClassTrib);
                //var registroRegra = regras.

                //if (classificacao.CClassTrib.Equals(cClassTribPadrao))
                //{

                //}
                //else
                //{

                //}


            }




            var teste = "";

            //var naturezasSelecionadas = ObterNaturezasSelecionadas();
            //if (naturezasSelecionadas.Count == 0)
            //{
            //    MessageBox.Show("Selecione alguma natureza!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //var resultado = MessageBox.Show("Tem certeza que deseja atualizar as naturezas selecionadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (resultado == DialogResult.No)
            //    return;

            //var comandoUpdate = new StringBuilder();
            //foreach (var natureza in naturezasSelecionadas)
            //{
            //    comandoUpdate.AppendLine($"UPDATE NATOPER SET IDOPERACAOFISCAL='{idOperacao}' WHERE NATOPERACAO={natureza.CodNatureza};");
            //}

            //try
            //{
            //    var cnx = Conexao.ObterConexao();
            //    cnx.Execute(comandoUpdate.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Ocorreu um erro ao atualizar as naturezas:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
        }

        private void lblLinkModelo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "Modelo_Importacao_Classificacao.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, Properties.Resources.Modelo_Importacao_Classificacao);
                        MessageBox.Show("Arquivo salvo com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar arquivo: {ex.Message}");
                    }
                }
            }
        }

        private async void btnImportar_Click(object sender, EventArgs e)
        {
            _classificacoes.Clear();
            pnClassificacao.Enabled = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string arquivoXlsx = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(arquivoXlsx);
                    if (fileInfo.Extension.ToLower().Equals(".xlsx"))
                    {
                        lblArquivoImportacao.Text = arquivoXlsx;
                        ExtrairDadosModelo(arquivoXlsx);
                        if (_classificacoes.Count == 0)
                        {
                            MessageBox.Show("Não foi encontrado nenhum calssificação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            PreencherGridTributacao();
                            await PreencherComboTributacao();

                            pnClassificacao.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato de arquivo não suportado. Por favor, selecione um arquivo Excel (.xlsx).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExtrairDadosModelo(string arquivoXlsx)
        {
            try
            {
                using (var workbook = new XLWorkbook(arquivoXlsx))
                {
                    var worksheet = workbook.Worksheet(1);
                    int ultimaLinha = worksheet.LastRowUsed().RowNumber();
                    for (int linha = 2; linha <= ultimaLinha; linha++)
                    {
                        var ncm = worksheet.Cell($"D{linha}").Value.ToString();
                        var cst = worksheet.Cell($"G{linha}").Value.ToString();
                        var cclasstrib = worksheet.Cell($"H{linha}").Value.ToString();

                        var tamanhoCst = 3;
                        var tamanhoCclasstrib = 6;
                        var tamanhoNcm = 8;
                        if (cst.Length == tamanhoCst && cclasstrib.Length == tamanhoCclasstrib && ncm.Length == tamanhoNcm)
                            _classificacoes.Add(new ClassificacaoExcel { Cst = cst, CClassTrib = cclasstrib, Ncm = ncm });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na importação da classificação:\n {ex.Message}");
            }

        }

        private void PreencherGridTributacao()
        {
            var classificacoes = _classificacoes
                .GroupBy(c => new { c.Cst, c.CClassTrib })
                .Select(x => x.First())
                .ToList();
            dtGridTributacoes.DataSource = classificacoes;
        }

        public async Task PreencherComboTributacao()
        {
            var operacoes = await new OperacaoFiscalRepository().ObterRegistros();

            cbTributacoes.DataSource = operacoes;
            cbTributacoes.ValueMember = nameof(OperacaoFiscal.Id);
            cbTributacoes.DisplayMember = nameof(OperacaoFiscal.DescricaoCombo);
            if (operacoes.Count > 0)
                cbTributacoes.SelectedIndex = 0;
        }
    }
    public class ClassificacaoExcel
    {
        public string Cst { get; set; }
        public string CClassTrib { get; set; }
        public string Ncm { get; set; }
    }
}
