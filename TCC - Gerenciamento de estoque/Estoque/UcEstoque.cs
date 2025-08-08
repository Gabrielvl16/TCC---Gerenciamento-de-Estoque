using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoque : UserControl
    {
        private MySqlConnection conexao = new MySqlConnection("server=localhost;database=loja_roupas_2_0;uid=root;pwd=;");

        public UcEstoque()
        {
            InitializeComponent();
            CarregarCategorias();
            CarregarTamanhos();
            CarregarDadosEstoque();
            AdicionarEventos();

            // Placeholder inicial
            txtPesquisar.Text = "Buscar...";
            txtPesquisar.ForeColor = Color.White;

            // Resetar DataGridView para estilo padrão
            ResetarEstiloDataGridView();
        }

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add("Todos");
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT categoria FROM produtos", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategoria.Items.Add(reader.GetString("categoria"));
                }
                reader.Close();
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void CarregarTamanhos()
        {
            cmbTamanho.Items.Clear();
            cmbTamanho.Items.Add("Todos");
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT tamanho FROM produtos", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbTamanho.Items.Add(reader.GetString("tamanho"));
                }
                reader.Close();
                cmbTamanho.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tamanhos: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void AdicionarEventos()
        {
            txtPesquisar.TextChanged += (s, e) => CarregarDadosEstoque();
            cmbCategoria.SelectedIndexChanged += (s, e) => CarregarDadosEstoque();
            cmbTamanho.SelectedIndexChanged += (s, e) => CarregarDadosEstoque();

            txtPesquisar.Enter += TxtPesquisar_Enter;
            txtPesquisar.Leave += TxtPesquisar_Leave;
        }

        private void TxtPesquisar_Enter(object sender, EventArgs e)
        {
            if (txtPesquisar.Text == "Buscar...")
            {
                txtPesquisar.Text = "";
                txtPesquisar.ForeColor = Color.White;
            }
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                txtPesquisar.Text = "Buscar...";
                txtPesquisar.ForeColor = Color.White;
            }
        }

        private void CarregarDadosEstoque()
        {
            string nome = txtPesquisar.Text.Trim();
            if (nome == "Buscar...")
                nome = "";

            string categoria = cmbCategoria.SelectedItem?.ToString() ?? "Todos";
            string tamanho = cmbTamanho.SelectedItem?.ToString() ?? "Todos";

            try
            {
                conexao.Open();
                string query = "SELECT id, nome, categoria, tamanho, cor, quantidade, preco, descricao FROM produtos WHERE 1=1";

                if (!string.IsNullOrEmpty(nome))
                    query += " AND nome LIKE @nome";

                if (categoria != "Todos")
                    query += " AND categoria = @categoria";

                if (tamanho != "Todos")
                    query += " AND tamanho = @tamanho";

                MySqlCommand cmd = new MySqlCommand(query, conexao);

                if (!string.IsNullOrEmpty(nome))
                    cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                if (categoria != "Todos")
                    cmd.Parameters.AddWithValue("@categoria", categoria);

                if (tamanho != "Todos")
                    cmd.Parameters.AddWithValue("@tamanho", tamanho);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvEstoque.DataSource = dt;
                dgvEstoque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void ResetarEstiloDataGridView()
        {
            dgvEstoque.EnableHeadersVisualStyles = true;
            dgvEstoque.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dgvEstoque.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgvEstoque.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);

            dgvEstoque.DefaultCellStyle.BackColor = SystemColors.Window;
            dgvEstoque.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            dgvEstoque.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvEstoque.DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;

            dgvEstoque.RowHeadersVisible = true;
            dgvEstoque.BorderStyle = BorderStyle.Fixed3D;
            dgvEstoque.BackgroundColor = SystemColors.Window;
            dgvEstoque.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoqueCadastro());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoqueEditar());
            }
        }
    }
}
