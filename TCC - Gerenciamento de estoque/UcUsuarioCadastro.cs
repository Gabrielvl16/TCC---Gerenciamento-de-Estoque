using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaLoja;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcUsuarioCadastro : UserControl
    {
        private byte[] imagemUsuario;

        public UcUsuarioCadastro()
        {
            InitializeComponent();

            lblNome.Visible = false;
            lblEmail.Visible = false;
            lblUsuario.Visible = false;
            lblSenha.Visible = false;
            lblNivel.Visible = false;
            lblStatus.Visible = false;

            picUsuarioInfo.Click += PicUsuarioInfo_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnVoltar.Click += BtnVoltar_Click;
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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

                Conexao conexao = new Conexao();
                using (MySqlConnection conn = conexao.Conectar())
                {
                    string sql = @"INSERT INTO usuarios 
                        (nome, email, usuario, senha, nivel_acesso, status, imagem)
                        VALUES 
                        (@nome, @email, @usuario, @senha, @nivel, @status, @imagem)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@senha", senha);
                        cmd.Parameters.AddWithValue("@nivel", nivel);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@imagem", imagemUsuario ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show("Nome de usuário já existe. Escolha outro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar usuário: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            cmbNivel.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            lblNome.Visible = false;
            lblEmail.Visible = false;
            lblUsuario.Visible = false;
            lblSenha.Visible = false;
            lblNivel.Visible = false;
            lblStatus.Visible = false;
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
    }
}
