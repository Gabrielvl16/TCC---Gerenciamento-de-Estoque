using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaLoja;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcUsuarioEditar : UserControl
    {
        private byte[] imagemUsuario;

        public UcUsuarioEditar()
        {
            InitializeComponent();
            InicializarEventos();

            // Placeholder inicial para txtId
            txtId.Text = "Digite o ID aqui...";
            txtId.ForeColor = Color.White;
            txtId.GotFocus += RemoverPlaceholderId;
            txtId.LostFocus += AdicionarPlaceholderId;
        }

        private void InicializarEventos()
        {
            picUsuarioInfo.Click += PicUsuarioInfo_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnVoltar.Click += BtnVoltar_Click;
            txtId.KeyDown += TxtId_KeyDown;

            // Esconder todos os asteriscos no início
            lblNome.Visible = false;
            lblEmail.Visible = false;
            lblUsuario.Visible = false;
            lblSenha.Visible = false;
            lblNivel.Visible = false;
            lblStatus.Visible = false;
        }

        private void RemoverPlaceholderId(object sender, EventArgs e)
        {
            if (txtId.Text == "Digite o ID aqui...")
            {
                txtId.Text = "";
                txtId.ForeColor = Color.White;
            }
        }

        private void AdicionarPlaceholderId(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                txtId.Text = "Digite o ID aqui...";
                txtId.ForeColor = Color.White;
            }
        }

        private void TxtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarUsuarioPorId();
            }
        }

        private void CarregarUsuarioPorId()
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new Conexao().Conectar())
            {
                string query = "SELECT * FROM usuarios WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNome.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtUsuario.Text = reader["usuario"].ToString();
                            txtSenha.Text = Encoding.UTF8.GetString(Convert.FromBase64String(reader["senha"].ToString()));
                            cmbNivel.SelectedItem = reader["nivel_acesso"].ToString();
                            cmbStatus.SelectedItem = reader["status"].ToString();

                            if (!(reader["imagem"] is DBNull))
                            {
                                imagemUsuario = (byte[])reader["imagem"];
                                using (MemoryStream ms = new MemoryStream(imagemUsuario))
                                {
                                    picUsuarioInfo.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                imagemUsuario = null;
                                picUsuarioInfo.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuário não encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void PicUsuarioInfo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Imagens (*.jpg;*.png)|*.jpg;*.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagemUsuario = File.ReadAllBytes(dialog.FileName);
                    picUsuarioInfo.Image = Image.FromFile(dialog.FileName);
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool camposValidos = true;

            lblNome.Visible = string.IsNullOrWhiteSpace(txtNome.Text);
            lblEmail.Visible = string.IsNullOrWhiteSpace(txtEmail.Text);
            lblUsuario.Visible = string.IsNullOrWhiteSpace(txtUsuario.Text);
            lblSenha.Visible = string.IsNullOrWhiteSpace(txtSenha.Text);
            lblNivel.Visible = cmbNivel.SelectedIndex == -1;
            lblStatus.Visible = cmbStatus.SelectedIndex == -1;

            if (lblNome.Visible || lblEmail.Visible || lblUsuario.Visible || lblSenha.Visible || lblNivel.Visible || lblStatus.Visible)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                camposValidos = false;
            }

            if (!camposValidos) return;

            try
            {
                string nome = txtNome.Text.Trim();
                string email = txtEmail.Text.Trim();
                string usuario = txtUsuario.Text.Trim();
                string senha = Convert.ToBase64String(Encoding.UTF8.GetBytes(txtSenha.Text.Trim()));
                string nivel = cmbNivel.SelectedItem.ToString();
                string status = cmbStatus.SelectedItem.ToString();

                using (MySqlConnection conn = new Conexao().Conectar())
                {
                    string sql = @"UPDATE usuarios SET nome=@nome, email=@email, usuario=@usuario, senha=@senha,
                                   nivel_acesso=@nivel, status=@status, imagem=@imagem WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@nivel", nivel);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@imagem", imagemUsuario ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("ID inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este usuário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                using (MySqlConnection conn = new Conexao().Conectar())
                {
                    string sql = "DELETE FROM usuarios WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent != null)
            {
                parent.Controls.Clear();
                UcUsuarios uc = new UcUsuarios();
                uc.Dock = DockStyle.Fill;
                parent.Controls.Add(uc);
            }
        }

        private void LimparCampos()
        {
            txtId.Text = "Digite o ID aqui...";
            txtId.ForeColor = Color.Gray;

            txtNome.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            cmbNivel.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            picUsuarioInfo.Image = null;
            imagemUsuario = null;

            lblNome.Visible = false;
            lblEmail.Visible = false;
            lblUsuario.Visible = false;
            lblSenha.Visible = false;
            lblNivel.Visible = false;
            lblStatus.Visible = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Evita erro de duplicação
        }
    }
}
