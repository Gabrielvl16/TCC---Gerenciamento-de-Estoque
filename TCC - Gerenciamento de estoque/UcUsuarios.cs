using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaLoja;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcUsuarios : UserControl
    {
        public UcUsuarios()
        {
            InitializeComponent();

            // Configuração dos eventos de foco da TextBox de busca
            txtBuscar.GotFocus += TxtBuscar_GotFocus;
            txtBuscar.LostFocus += TxtBuscar_LostFocus;
            txtBuscar.KeyDown += TxtBuscar_KeyDown;

            // Placeholder inicial
            txtBuscar.Text = "Buscar...";
            txtBuscar.ForeColor = Color.White;

            // Preenchendo o ComboBox de status
            comboStatus.Items.AddRange(new string[] { "Todos", "Ativo", "Inativo" });
            comboStatus.SelectedIndex = 0;

            // Carrega os usuários no DataGridView
            CarregarUsuarios();
        }

        private void TxtBuscar_GotFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = Color.White;
            }
        }

        private void TxtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar...";
                txtBuscar.ForeColor = Color.Gray;
            }
        }

        private void TxtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarUsuarios();
                e.SuppressKeyPress = true;
            }
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            string busca = txtBuscar.Text.Trim() == "Buscar..." ? "" : txtBuscar.Text.Trim();
            string statusFiltro = comboStatus.SelectedItem?.ToString();

            try
            {
                Conexao conexao = new Conexao();
                using (MySqlConnection conn = conexao.Conectar())
                {
                    string sql = "SELECT id, nome, email, usuario, nivel_acesso, status FROM usuarios WHERE 1=1";

                    if (!string.IsNullOrEmpty(busca))
                        sql += " AND nome LIKE @busca";

                    if (!string.IsNullOrEmpty(statusFiltro) && statusFiltro != "Todos")
                        sql += " AND status = @status";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrEmpty(busca))
                            cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");

                        if (!string.IsNullOrEmpty(statusFiltro) && statusFiltro != "Todos")
                            cmd.Parameters.AddWithValue("@status", statusFiltro);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            dataGridViewUsuarios.DataSource = dt;

                            if (dt.Rows.Count == 0)
                                MessageBox.Show("Nenhum usuário encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Não usar para buscar automaticamente a cada letra
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // Abre o UcUsuarioCadastro dentro do FormMenu
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcUsuarioCadastro());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Abre o UcUsuarioEditar dentro do FormMenu
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcUsuarioEditar());
            }
        }
    }
}
