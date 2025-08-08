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
                picImagemProduto.Image = Properties.Resources.adicionar_imagem__1_;
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
                    }

                    // Obtém o ID do produto recém-cadastrado
                    int novoId;
                    using (MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                    {
                        novoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    // Gera a nota fiscal em TXT
                    GerarNotaFiscalTxt(novoId, nome, categoria, tamanho, cor, quantidade, preco, descricao);

                    MessageBox.Show("Produto cadastrado com sucesso!");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar produto: " + ex.Message);
            }
        }

        private void GerarNotaFiscalTxt(int produtoId, string nome, string categoria, string tamanho, string cor, int quantidade, decimal precoUnitario, string descricao)
        {
            try
            {
                string pastaNotas = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "NotasFiscais");
                if (!Directory.Exists(pastaNotas))
                    Directory.CreateDirectory(pastaNotas);

                string nomeArquivo = $"NF_{produtoId}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string caminhoArquivo = Path.Combine(pastaNotas, nomeArquivo);

                decimal total = precoUnitario * quantidade;

                using (StreamWriter sw = new StreamWriter(caminhoArquivo))
                {
                    sw.WriteLine("*********** NOTA FISCAL ***********");
                    sw.WriteLine($"Data de emissão: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    sw.WriteLine("-----------------------------------");
                    sw.WriteLine($"ID Produto: {produtoId}");
                    sw.WriteLine($"Nome: {nome}");
                    sw.WriteLine($"Categoria: {categoria}");
                    sw.WriteLine($"Tamanho: {tamanho}");
                    sw.WriteLine($"Cor: {cor}");
                    sw.WriteLine($"Quantidade: {quantidade}");
                    sw.WriteLine($"Preço Unitário: R$ {precoUnitario:F2}");
                    sw.WriteLine($"Total: R$ {total:F2}");
                    sw.WriteLine("-----------------------------------");
                    sw.WriteLine("Descrição:");
                    sw.WriteLine(descricao);
                    sw.WriteLine("***********************************");
                }

                MessageBox.Show($"Nota Fiscal gerada com sucesso!\nLocal: {caminhoArquivo}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar nota fiscal: " + ex.Message);
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
            CarregarImagemPadrao();
        }
    }
}