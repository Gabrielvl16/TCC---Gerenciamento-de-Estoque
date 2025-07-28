using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoque : UserControl
    {
        public UcEstoque()
        {
            InitializeComponent();
        }

        private void UcEstoque_Load(object sender, EventArgs e)
        {
            EstilizarDataGridView();
        }

        private void EstilizarDataGridView()
        {
            var roxoPrimario = Color.FromArgb(138, 43, 226); // BlueViolet
            var roxoSecundario = Color.FromArgb(159, 105, 255); // Um roxo mais claro
            var branco = Color.White;
            var cinzaClaro = Color.FromArgb(240, 240, 240);

            DataGridView dgv = dataGridView1;

            // Estilo geral
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = branco;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = roxoPrimario;

            // Cabeçalho
            dgv.ColumnHeadersDefaultCellStyle.BackColor = roxoPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = branco;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 11, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Células
            dgv.DefaultCellStyle.BackColor = branco;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Poppins", 10);
            dgv.DefaultCellStyle.SelectionBackColor = roxoSecundario;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Alternar cor das linhas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = cinzaClaro;

            // Linhas
            dgv.RowTemplate.Height = 35;
            dgv.RowHeadersVisible = false;

            // Desabilita edição
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
