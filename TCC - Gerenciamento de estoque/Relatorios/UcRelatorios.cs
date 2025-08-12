using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcRelatorios : UserControl
    {
        public UcRelatorios()
        {
            InitializeComponent();
            CarregarComboAno();
            CarregarComboMes();
        }

        private void CarregarComboAno()
        {
            int anoAtual = DateTime.Now.Year;
            cbAno.Items.Clear();
            for (int i = anoAtual - 5; i <= anoAtual; i++)
            {
                cbAno.Items.Add(i);
            }
            cbAno.SelectedItem = anoAtual;
        }

        private void CarregarComboMes()
        {
            cbMes.Items.Clear();
            cbMes.Items.Add("Todos");
            cbMes.Items.Add("Janeiro");
            cbMes.Items.Add("Fevereiro");
            cbMes.Items.Add("Março");
            cbMes.Items.Add("Abril");
            cbMes.Items.Add("Maio");
            cbMes.Items.Add("Junho");
            cbMes.Items.Add("Julho");
            cbMes.Items.Add("Agosto");
            cbMes.Items.Add("Setembro");
            cbMes.Items.Add("Outubro");
            cbMes.Items.Add("Novembro");
            cbMes.Items.Add("Dezembro");
            cbMes.SelectedIndex = 0;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (cbAno.SelectedItem == null)
            {
                MessageBox.Show("Selecione um ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ano = (int)cbAno.SelectedItem;
            int mes = cbMes.SelectedIndex; // 0 = Todos

            string conexao = "server=localhost;user=root;database=loja_roupas_2_0;password=;";
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = @"
                    SELECT p.nome AS Produto, 
                           SUM(m.quantidade) AS QuantidadeEntrada, 
                           p.preco AS PrecoUnitario,
                           SUM(m.quantidade * p.preco) AS ValorTotal,
                           MAX(m.data_movimentacao) AS DataEntrada
                    FROM movimentacoes_estoque m
                    INNER JOIN produtos p ON m.produto_id = p.id
                    WHERE m.tipo = 'Entrada'
                      AND YEAR(m.data_movimentacao) = @ano
                ";

                if (mes != 0)
                {
                    sql += " AND MONTH(m.data_movimentacao) = @mes ";
                }

                sql += @"
                    GROUP BY p.id, p.nome, p.preco
                    ORDER BY DataEntrada DESC;
                ";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ano", ano);
                    if (mes != 0)
                        cmd.Parameters.AddWithValue("@mes", mes);

                    DataTable dt = new DataTable();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }

                    dgvRelatorio.DataSource = dt;

                    // Formatar colunas monetárias para moeda brasileira
                    if (dgvRelatorio.Columns["PrecoUnitario"] != null)
                        dgvRelatorio.Columns["PrecoUnitario"].DefaultCellStyle.Format = "C2";
                    if (dgvRelatorio.Columns["ValorTotal"] != null)
                        dgvRelatorio.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";
                }
            }
        }

        private void btnExportarPdf_Click(object sender, EventArgs e)
        {
            if (dgvRelatorio.DataSource == null || dgvRelatorio.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Arquivos PDF (*.pdf)|*.pdf", FileName = "Relatorio_Estoque.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportarDataGridViewParaPdf(dgvRelatorio, sfd.FileName);
                        MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao exportar PDF: " + ex.Message);
                    }
                }
            }
        }

        private void ExportarDataGridViewParaPdf(DataGridView dgv, string caminhoArquivo)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);

            using (FileStream stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, stream);
                doc.Open();

                // Título
                Paragraph titulo = new Paragraph("Relatório de Entradas no Estoque\n\n", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                PdfPTable table = new PdfPTable(dgv.Columns.Count);
                table.WidthPercentage = 100;

                // Cabeçalho
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                // Dados
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        string texto = cell.Value?.ToString() ?? "";
                        table.AddCell(new Phrase(texto));
                    }
                }

                doc.Add(table);
                doc.Close();
            }
        }
    }
}
