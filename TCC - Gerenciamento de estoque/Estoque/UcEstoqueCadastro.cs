using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoqueCadastro : UserControl
    {
        private byte[] imagemProduto = null;

        public UcEstoqueCadastro()
        {
            InitializeComponent();
            CarregarImagemPadrao();

            // Adiciona o evento de clique à PictureBox
            picImagemProduto.Click += picImagemProduto_Click;
        }

        // Carrega a imagem padrão na PictureBox
        private void CarregarImagemPadrao()
        {
            try
            {
                // Se você adicionou a imagem como recurso no Visual Studio:
                picImagemProduto.Image = Properties.Resources.adicionar_imagem__1_  ;

                // Se estiver embutido como recurso no assembly, descomente abaixo:
                /*
                using (Stream stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("TCC___Gerenciamento_de_estoque.Resources.padrao.png"))
                {
                    if (stream != null)
                        picImagemProduto.Image = new Bitmap(stream);
                }
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar imagem padrão: " + ex.Message);
            }
        }

        private void picImagemProduto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecione uma imagem";
            ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picImagemProduto.Image = new Bitmap(ofd.FileName);
                imagemProduto = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string categoria = cbCategoria.Text;
            string tamanho = cbTamanho.Text;
            string cor = cbCor.Text;
            int quantidade = (int)numQuantidade.Value;
            string descricao = txtDescricao.Text;
            string precoTexto = txtPreco.Text.Replace("R$", "").Trim().Replace(",", ".");
            decimal preco;

            if (!decimal.TryParse(precoTexto, out preco))
            {
                MessageBox.Show("Preço inválido.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(categoria))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.");
                return;
            }

            if (imagemProduto == null)
            {
                MessageBox.Show("Selecione uma imagem do produto.");
                return;
            }

            try
            {
                string conexao = "server=localhost;user=root;database=loja_roupas_2_0;password=;";
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string query = "INSERT INTO produtos (nome, categoria, tamanho, cor, quantidade, preco, descricao, imagem) " +
                                   "VALUES (@nome, @categoria, @tamanho, @cor, @quantidade, @preco, @descricao, @imagem)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                        cmd.Parameters.AddWithValue("@cor", cor);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@descricao", descricao);
                        cmd.Parameters.AddWithValue("@imagem", imagemProduto);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Produto cadastrado com sucesso!");
                        LimparCampos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoque());
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            cbCategoria.SelectedIndex = -1;
            cbTamanho.SelectedIndex = -1;
            cbCor.SelectedIndex = -1;
            numQuantidade.Value = 0;
            txtPreco.Clear();
            txtDescricao.Clear();

            imagemProduto = null;

            // Restaura imagem padrão
            CarregarImagemPadrao();
        }
    }
}
