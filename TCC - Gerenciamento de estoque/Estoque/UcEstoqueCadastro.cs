using System;
using System.Drawing;
using System.IO;
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

            picImagemProduto.Click += picImagemProduto_Click;
        }

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
            string nome = txtNome.Text.Trim();
            string categoria = cbCategoria.SelectedItem?.ToString() ?? "";
            string tamanho = cbTamanho.SelectedItem?.ToString() ?? "";
            string cor = cbCor.SelectedItem?.ToString() ?? "";
            int quantidade = (int)numQuantidade.Value;
            string precoTexto = txtPreco.Text.Trim().Replace(',', '.');
            decimal preco;

            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Informe o nome do produto.");
                txtNome.Focus();
                return;
            }

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade deve ser maior que zero.");
                numQuantidade.Focus();
                return;
            }

            if (!decimal.TryParse(precoTexto, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out preco))
            {
                MessageBox.Show("Informe um preço válido, use números decimais (ex: 99.90 ou 99,90).");
                txtPreco.Focus();
                return;
            }

            if (preco <= 0)
            {
                MessageBox.Show("O preço deve ser maior que zero.");
                txtPreco.Focus();
                return;
            }

            string descricao = txtDescricao.Text.Trim();

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
                        cmd.Parameters.AddWithValue("@imagem", imagemProduto ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }

                    int novoId;
                    using (MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                    {
                        novoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    // Gera o documento fiscal simulado em PDF (sem "FAKE" no título)
                    string caminhoPdf = NotaFiscalSimuladaGenerator.GerarNfcePdf(novoId, "Cliente Exemplo", nome, quantidade, preco);

                    // Salva dados do documento fiscal no banco
                    string queryNota = "INSERT INTO notas_fiscais (produto_id, numero, chave_acesso, xml, pdf_path, api_response, data_emissao, valor_total) " +
                                       "VALUES (@produto_id, @numero, @chave, @xml, @pdf, @resp, @dataem, @valor)";

                    using (MySqlCommand cmdNota = new MySqlCommand(queryNota, conn))
                    {
                        cmdNota.Parameters.AddWithValue("@produto_id", novoId);
                        cmdNota.Parameters.AddWithValue("@numero", DBNull.Value);
                        cmdNota.Parameters.AddWithValue("@chave", DBNull.Value);
                        cmdNota.Parameters.AddWithValue("@xml", DBNull.Value);
                        cmdNota.Parameters.AddWithValue("@pdf", caminhoPdf);
                        cmdNota.Parameters.AddWithValue("@resp", "Simulação: documento fiscal gerado localmente, sem API.");
                        cmdNota.Parameters.AddWithValue("@dataem", DateTime.Now);
                        cmdNota.Parameters.AddWithValue("@valor", quantidade * preco);

                        cmdNota.ExecuteNonQuery();
                    }

                    // NÃO mostra mensagem para o usuário aqui, conforme pedido

                    LimparCampos();
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
            CarregarImagemPadrao();
        }
    }
}
