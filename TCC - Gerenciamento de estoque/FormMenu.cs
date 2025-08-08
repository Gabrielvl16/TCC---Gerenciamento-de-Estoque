using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using TCC___Gerenciamento_de_estoque.Movimentações;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class FormMenu : Form
    {
        private string nivelUsuario;
        private string nomeUsuario;

        public FormMenu(string nivel, string nome)
        {
            InitializeComponent();

            nivelUsuario = nivel;
            nomeUsuario = nome;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            ArredondarCantoSuperiorDireito(panelMenu, 30);

            AjustarPermissoes();
            ExibirNomeUsuario();


            lblNomeUsuario.Text = Sessao.Nome;
            lblEmailUsuario.Text = Sessao.Email;
            lblUsuario.Text = Sessao.Usuario;

            if (Sessao.Imagem != null)
            {
                using (MemoryStream ms = new MemoryStream(Sessao.Imagem))
                {
                    picUsuario.Image = Image.FromStream(ms); // Mostra a foto de perfil no topo
                }
            }
            else
            {
                picUsuario.Image = null; // ou uma imagem padrão
            }

            // Não mostra o painel ao iniciar
            panelUsuarioInfo.Visible = false;
        }

        public void ArredondarCantoSuperiorDireito(Panel panel, int raio)
        {
            Rectangle bounds = panel.ClientRectangle;
            GraphicsPath path = new GraphicsPath();
            int d = raio * 2;

            path.StartFigure();

            path.AddLine(bounds.X, bounds.Y, bounds.Right - d, bounds.Y);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddLine(bounds.Right, bounds.Y + d, bounds.Right, bounds.Bottom);
            path.AddLine(bounds.Right, bounds.Bottom, bounds.X, bounds.Bottom);
            path.AddLine(bounds.X, bounds.Bottom, bounds.X, bounds.Y);

            path.CloseFigure();

            panel.Region = new Region(path);
        }

        private void AjustarPermissoes()
        {
            if (nivelUsuario == "Comum")
            {
                btnFuncionarios.Enabled = false;
                btnUsuario.Enabled = false;
                btnRelatorio.Enabled = false;
                // desabilite outros controles que usuários comuns não podem usar
            }
            // Admin tem acesso total, não precisa mexer
        }

        private void ExibirNomeUsuario()
        {
            lblNomeUsuario.Text = $"Bem-vindo, {nomeUsuario}";
        }

        // Seus eventos existentes para mouse enter/leave e botões

        private void btnEstoque_MouseEnter(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnEstoque_MouseLeave(object sender, EventArgs e)
        {
            btnEstoque.BackColor = Color.BlueViolet;
        }

        private void btnFuncionarios_MouseEnter(object sender, EventArgs e)
        {
            btnFuncionarios.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnFuncionarios_MouseLeave(object sender, EventArgs e)
        {
            btnFuncionarios.BackColor = Color.BlueViolet;
        }

        private void btnClientes_MouseEnter(object sender, EventArgs e)
        {
            btnClientes.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            btnClientes.BackColor = Color.BlueViolet;
        }

        private void btnRelatorios_MouseEnter(object sender, EventArgs e)
        {
            btnRelatorio.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnRelatorios_MouseLeave(object sender, EventArgs e)
        {
            btnRelatorio.BackColor = Color.BlueViolet;
        }

        private void btnUsuarios_MouseEnter(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            btnUsuario.BackColor = Color.BlueViolet;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(146, 121, 248);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.BlueViolet;
        }

      

        // Repita para os outros botões...

        public void CarregarUserControl(UserControl uc)
        {
            // Remover todos os controles dentro do panelConteudo, EXCETO o panelUsuarioInfo
            for (int i = panelConteudo.Controls.Count - 1; i >= 0; i--)
            {
                Control ctrl = panelConteudo.Controls[i];
                if (ctrl != panelUsuarioInfo)
                    panelConteudo.Controls.RemoveAt(i);
            }

            // Adiciona o novo UserControl
            uc.Dock = DockStyle.Fill;
            panelConteudo.Controls.Add(uc);

            // Garante que o panelUsuarioInfo fique sempre visível por cima
            panelUsuarioInfo.BringToFront();
        }


        private void btnEstoque_Click(object sender, EventArgs e)
        {
            CarregarUserControl(new UcEstoque());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CarregarUserControl(new UcMovimentacaoEstoque());
        }

        private void btnFuncionarios_Click(object sender, EventArgs e)
        {
            CarregarUserControl(new UcFuncionarios());
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            CarregarUserControl(new UcRelatorios());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            CarregarUserControl(new UcUsuarios());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        // Outras funções...

        private void picUsuario_Click(object sender, EventArgs e)
        {
            if (Sessao.Imagem != null)
            {
                using (MemoryStream ms = new MemoryStream(Sessao.Imagem))
                {
                    picUsuarioInfo.Image = Image.FromStream(ms); // Mostra a imagem ampliada
                }
            }
            else
            {
                picUsuarioInfo.Image = null;
            }

            // Agora sim exibe o painel ao clicar
            panelUsuarioInfo.Visible = true;
            panelUsuarioInfo.BringToFront();

            MostrarPainelUsuarioInfo();
        }

        private void btnFecharInfo_Click(object sender, EventArgs e)
        {
            panelUsuarioInfo.Visible = false;
        }

        public void MostrarPainelUsuarioInfo()
        {
            if (Sessao.Imagem != null)
            {
                using (MemoryStream ms = new MemoryStream(Sessao.Imagem))
                {
                    picUsuarioInfo.Image = Image.FromStream(ms); // Mostra a imagem ampliada
                }
            }
            else
            {
                picUsuarioInfo.Image = null;
            }

            panelUsuarioInfo.Visible = true;
            panelUsuarioInfo.BringToFront();
        }
    }
}
