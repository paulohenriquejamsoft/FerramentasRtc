using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategorizarProdutos.Dao;
using CategorizarProdutos.Models.Natureza;
using CategorizarProdutos.Models.TributacoesFiscal;
using CategorizarProdutos.Repositorios;
using Dapper;

namespace CategorizarProdutos
{
    public partial class FrmNaturezaTributacao : Form
    {
        private CheckBox headerCheckBox = new CheckBox();
        private List<TributacaoFiscal> _tributacoes;     
        public FrmNaturezaTributacao()
        {
            InitializeComponent();
            _tributacoes = new List<TributacaoFiscal>();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmNaturezaTributacao_Shown(object sender, EventArgs e)
        {
            await PreencherGridNaturezas();
            await PreencherComboTributacao();
        }

        private async Task PreencherGridNaturezas()
        {
            var naturezas = await new NaturezaRepository().ObterNaturezasTributacao();
            naturezas = naturezas
                .Where(x => x.CfopProxy>=5000)
                .OrderBy(o => o.CfopProxy)
                .ThenBy(t => t.DescrNatureza)
                .ToList();

            dtGridNaturezas.DataSource = naturezas;
        }

        public async Task PreencherComboTributacao()
        {
            _tributacoes = await new TributacaoFiscalRepository().ObterTodas();

            cbTributacoes.DataSource = _tributacoes;
            cbTributacoes.ValueMember = nameof(TributacaoFiscal.Id);
            cbTributacoes.DisplayMember = nameof(TributacaoFiscal.DescricaoCombo);
            if (_tributacoes.Count > 0)
                cbTributacoes.SelectedIndex = 0;
        }

        private void FrmNaturezaTributacao_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dtGridNaturezas.AutoGenerateColumns = false;
            dtGridNaturezas.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.CodNatureza),
                HeaderText = "Cod. Natureza",
                DataPropertyName = nameof(NaturezaTributacao.CodNatureza),
                Width = 100
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.DescrNatureza),
                HeaderText = "Descriçao",
                DataPropertyName = nameof(NaturezaTributacao.DescrNatureza),
                Width = 250
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.Cfop),
                HeaderText = "CFOP",
                DataPropertyName = nameof(NaturezaTributacao.CfopProxy),
                Width = 50
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.TribId),
                HeaderText = "Cod. Tributação",
                DataPropertyName = nameof(NaturezaTributacao.TribId),
                Width = 70
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.TribDescricao),
                HeaderText = "Descrição Tributação",
                DataPropertyName = nameof(NaturezaTributacao.TribDescricao),
                Width = 250
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.CstIbsCbs),
                HeaderText = "CST CBS/IBS",
                DataPropertyName = nameof(NaturezaTributacao.CstIbsCbs),
                Width = 70
            });

            dtGridNaturezas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = nameof(NaturezaTributacao.CclassTrib),
                HeaderText = "Classificação",
                DataPropertyName = nameof(NaturezaTributacao.CclassTrib),
                Width = 85
            });

            dtGridNaturezas.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = nameof(NaturezaTributacao.isSelecionado),
                HeaderText = " ",
                DataPropertyName = nameof(NaturezaTributacao.isSelecionado),
                Width = 50
            });

            AddHeaderCheckBox();
        }

        private void AddHeaderCheckBox()
        {
            // Posição do header checkbox
            Rectangle rect = dtGridNaturezas.GetCellDisplayRectangle(0, -1, true);
            rect.X = rect.Location.X + 893;
            rect.Y = rect.Location.Y + 9;

            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.Location = rect.Location;

            // Evento de clique
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            dtGridNaturezas.Controls.Add(headerCheckBox);
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool checkAll = ((CheckBox)sender).Checked;

            foreach (DataGridViewRow row in dtGridNaturezas.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[nameof(NaturezaTributacao.isSelecionado)];
                chk.Value = checkAll;
            }

            dtGridNaturezas.EndEdit();
        }

        private List<NaturezaTributacao> ObterNaturezasSelecionadas()
        {
            List<NaturezaTributacao> naturezasSelecionadas = new List<NaturezaTributacao>();
            foreach (DataGridViewRow row in dtGridNaturezas.Rows)
            {
                bool isSelecionado = Convert.ToBoolean(row.Cells[nameof(NaturezaTributacao.isSelecionado)].Value);
                if (isSelecionado)
                {
                    var natureza = row.DataBoundItem as NaturezaTributacao;
                    naturezasSelecionadas.Add(natureza);
                }
            }

            return naturezasSelecionadas;
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {           
            var idTributacao = cbTributacoes.SelectedValue;
            if (idTributacao == null)
            {
                MessageBox.Show("Selecione uma tributação!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var naturezasSelecionadas = ObterNaturezasSelecionadas();
            if (naturezasSelecionadas.Count == 0)
            {
                MessageBox.Show("Selecione alguma natureza!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show("Tem certeza que deseja atualizar as naturezas selecionadas?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resultado == DialogResult.No)
                return;

            var comandoUpdate = new StringBuilder();       
            foreach (var natureza in naturezasSelecionadas)
            {                
                comandoUpdate.AppendLine($"UPDATE NATOPER SET IDTRIBUTACAOFISCAL='{idTributacao}' WHERE NATOPERACAO={natureza.CodNatureza};");
            }

            try
            {
                var cnx = Conexao.ObterConexao();
                cnx.Execute(comandoUpdate.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao atualizar as naturezas:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await PreencherGridNaturezas();
        }
    }
}
