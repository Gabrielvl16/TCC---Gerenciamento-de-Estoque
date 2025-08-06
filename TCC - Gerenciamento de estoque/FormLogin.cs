using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaLoja;
using System.IO;

namespace TCC___Gerenciamento_de_estoque
{

    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Informe usuário e senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexao conexao = new Conexao();
                using (MySqlConnection conn = conexao.Conectar())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Falha na conexão com o banco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Verifica se a tabela está vazia
                    string sqlVerifica = "SELECT COUNT(*) FROM usuarios";
                    MySqlCommand cmdVerifica = new MySqlCommand(sqlVerifica, conn);
                    int totalUsuarios = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                    // Se não houver usuários cadastrados, permite login padrão
                    if (totalUsuarios == 0 && usuario == "admin" && senha == "admin")
                    {
                        MessageBox.Show("Login padrão realizado.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Preenche dados da sessão com usuário padrão
                        Sessao.Id = 0;
                        Sessao.Nome = "Administrador Padrão";
                        Sessao.Email = "";
                        Sessao.Usuario = "admin";
                        Sessao.Imagem = null;
                        Sessao.NivelAcesso = "Admin";

                        FormMenu formPrincipal = new FormMenu("Admin", "Administrador Padrão");
                        formPrincipal.Show();
                        this.Hide();
                        return;
                    }

                    // Continua com login normal
                    string senhaCodificada = Convert.ToBase64String(Encoding.UTF8.GetBytes(senha));

                    string sql = @"SELECT id, nome, email, usuario, senha, nivel_acesso, status, imagem FROM usuarios 
                                   WHERE usuario = @usuario AND senha = @senha";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senhaCodificada);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string status = reader["status"].ToString();

                            if (status != "Ativo")
                            {
                                MessageBox.Show("Usuário inativo. Contate o administrador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Preenche dados da sessão para uso posterior
                            Sessao.Id = Convert.ToInt32(reader["id"]);
                            Sessao.Nome = reader["nome"].ToString();
                            Sessao.Email = reader["email"].ToString();
                            Sessao.Usuario = reader["usuario"].ToString();
                            Sessao.NivelAcesso = reader["nivel_acesso"].ToString();

                            if (!(reader["imagem"] is DBNull))
                                Sessao.Imagem = (byte[])reader["imagem"];
                            else
                                Sessao.Imagem = null;

                            MessageBox.Show($"Bem-vindo, {Sessao.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FormMenu formPrincipal = new FormMenu(Sessao.NivelAcesso, Sessao.Nome);
                            formPrincipal.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha incorretos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar fazer login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void olhoAberto_Click(object sender, EventArgs e)
        {
            olhoFechado.Visible = true;
            txtSenha.UseSystemPasswordChar = true;
        
        }

        private void olhoFechado_Click(object sender, EventArgs e)
        {
            olhoFechado.Visible = false;
            txtSenha.UseSystemPasswordChar = false;
        }
    }
}
