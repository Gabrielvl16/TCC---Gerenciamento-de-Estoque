using MySql.Data.MySqlClient;
using SistemaLoja;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcFuncionarios : UserControl
    {
        public UcFuncionarios()
        {
            InitializeComponent();

            this.Load += UcFuncionarios_Load;
            pictureBox1.Click += PictureBox1_Click;
            cmbFiltroCargo.SelectedIndexChanged += CmbFiltroCargo_SelectedIndexChanged;
            btnCadastrar.Click += BtnCadastrar_Click;

            // Placeholder da caixa de busca
            txtPesquisar.Enter += TxtPesquisar_Enter;
            txtPesquisar.Leave += TxtPesquisar_Leave;
            txtPesquisar.KeyDown += TxtPesquisar_KeyDown;

            this.ParentChanged += (s, e) => RegistrarEventosDeCliqueNosControles(this);
        }

        private void UcFuncionarios_Load(object sender, EventArgs e)
        {
            cmbFiltroCargo.Items.Clear();
            cmbFiltroCargo.Items.Add("Todos");
            cmbFiltroCargo.Items.AddRange(new string[]
            {
                "Assistente de Vendas",
                "Atendimento ao Cliente",
                "Caixa",
                "Diretor de Vendas",
                "Estilista",
                "Estoquista",
                "Gerente",
                "Recepcionista",
                "Supervisor",
                "Vendedor"
            });

            cmbFiltroCargo.SelectedIndex = 0;

            txtPesquisar.Text = "Buscar...";
            txtPesquisar.ForeColor = Color.LightGray;

            CarregarFuncionarios();
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
                txtPesquisar.ForeColor = Color.LightGray;
            }
        }

        private void TxtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string nome = txtPesquisar.Text.Trim();

                if (!string.IsNullOrEmpty(nome) && nome != "Buscar...")
                {
                    CarregarFuncionarios(nome: nome);
                }
                else
                {
                    MessageBox.Show("Digite um nome para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisar.Text.Trim();

            if (string.IsNullOrEmpty(nome) || nome == "Buscar...")
            {
                MessageBox.Show("Digite um nome para pesquisar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CarregarFuncionarios(nome: nome);
        }

        private void CmbFiltroCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cargo = cmbFiltroCargo.Text;
            string nome = txtPesquisar.Text.Trim();

            if (string.IsNullOrEmpty(nome) || nome.Equals("Buscar...", StringComparison.OrdinalIgnoreCase))
                nome = "";

            CarregarFuncionarios(cargo, nome);
        }

        private void CarregarFuncionarios(string cargo = "", string nome = "")
        {
            try
            {
                using (MySqlConnection conn = new Conexao().Conectar())
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    string sql = "SELECT * FROM funcionarios WHERE 1=1";

                    if (!string.IsNullOrEmpty(cargo) && cargo != "Todos")
                        sql += " AND cargo = @cargo";

                    if (!string.IsNullOrEmpty(nome))
                        sql += " AND nome LIKE @nome";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(cargo) && cargo != "Todos")
                            cmd.Parameters.AddWithValue("@cargo", cargo);

                        if (!string.IsNullOrEmpty(nome))
                            cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvFuncionarios.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message);
            }
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            UcFuncionariosCadastro ucCadastro = new UcFuncionariosCadastro();
            ucCadastro.Dock = DockStyle.Fill;

            Form formPai = this.FindForm();

            if (formPai != null)
            {
                Panel painelConteudo = formPai.Controls.Find("panelConteudo", true).FirstOrDefault() as Panel;

                if (painelConteudo != null)
                {
                    painelConteudo.Controls.Clear();
                    painelConteudo.Controls.Add(ucCadastro);
                }
                else
                {
                    MessageBox.Show("Painel 'panelConteudo' não encontrado no Form.");
                }
            }
        }

        private void RegistrarEventosDeCliqueNosControles(Control controle)
        {
            foreach (Control c in controle.Controls)
            {
                c.Click += Control_Click;
                if (c.HasChildren)
                    RegistrarEventosDeCliqueNosControles(c);
            }
        }

        private void Control_Click(object sender, EventArgs e)
        {
            if (!txtPesquisar.Focused && string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                txtPesquisar.Text = "Buscar...";
                txtPesquisar.ForeColor = Color.LightGray;
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UcFuncionariosEditar ucEditar = new UcFuncionariosEditar();
            ucEditar.Dock = DockStyle.Fill;

            Form formPai = this.FindForm();

            if (formPai != null)
            {
                Panel painelConteudo = formPai.Controls.Find("panelConteudo", true).FirstOrDefault() as Panel;

                if (painelConteudo != null)
                {
                    painelConteudo.Controls.Clear();
                    painelConteudo.Controls.Add(ucEditar);
                }
                else
                {
                    MessageBox.Show("Painel 'panelConteudo' não encontrado no Form.");
                }
            }
        }

        private void Clientes_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFiltroCargo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dgvFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
