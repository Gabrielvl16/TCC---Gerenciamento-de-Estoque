using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoqueEditar : UserControl
    {
        private MySqlConnection conexao = new MySqlConnection("server=localhost;database=loja_roupas_2_0;uid=root;pwd=;");
        private int produtoIdAtual = -1;
        private byte[] imagemProduto = null;

        public UcEstoqueEditar()
        {
            InitializeComponent();

            picImagemProduto.Image = Properties.Resources.desenvolvimento_de_produto__1_;

            // Configurar placeholder e evento de pesquisa
            txtPesquisar.ForeColor = Color.White;
            txtPesquisar.Text = "Buscar...";
            txtPesquisar.GotFocus += RemoverPlaceholder;
            txtPesquisar.LostFocus += AdicionarPlaceholder;
            txtPesquisar.TextChanged += BuscarProduto;

            // Eventos de botões
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            picImagemProduto.Click += picImagemProduto_Click;
        }

        private void RemoverPlaceholder(object sender, EventArgs e)
        {
            if (txtPesquisar.Text == "Buscar...")
            {
                txtPesquisar.Text = "";
                txtPesquisar.ForeColor = Color.Black;
            }
        }

        private void AdicionarPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPesquisar.Text))
            {
                txtPesquisar.Text = "Buscar...";
                txtPesquisar.ForeColor = Color.Gray;
            }
        }

        private void BuscarProduto(object sender, EventArgs e)
        {
            string busca = txtPesquisar.Text.Trim();

            if (string.IsNullOrEmpty(busca) || busca == "Buscar...")
            {
                LimparCampos();
                return;
            }

            if (int.TryParse(busca, out int id))
                BuscarProdutoPorId(id);
            else
                BuscarProdutoPorNome(busca);
        }

        private void BuscarProdutoPorNome(string nome)
        {
            try
            {
                conexao.Open();
                string query = "SELECT * FROM produtos WHERE nome LIKE @nome LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    PreencherCampos(reader);
                else
                    LimparCampos();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto por nome: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void BuscarProdutoPorId(int id)
        {
            try
            {
                conexao.Open();
                string query = "SELECT * FROM produtos WHERE id = @id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    PreencherCampos(reader);
                else
                    LimparCampos();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar produto por ID: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void PreencherCampos(MySqlDataReader reader)
        {
            produtoIdAtual = reader.GetInt32("id");
            txtNome.Text = reader.GetString("nome");
            cmbCategoria.SelectedItem = reader.GetString("categoria");
            cmbTamanho.SelectedItem = reader.GetString("tamanho");
            cmbCor.SelectedItem = reader.GetString("cor");
            nudQuantidade.Value = reader.GetInt32("quantidade");
            txtPreco.Text = reader.GetDecimal("preco").ToString("F2");
            txtDescricao.Text = reader.IsDBNull(reader.GetOrdinal("descricao")) ? "" : reader.GetString("descricao");

            if (!reader.IsDBNull(reader.GetOrdinal("imagem")))
            {
                imagemProduto = (byte[])reader["imagem"];
                using (MemoryStream ms = new MemoryStream(imagemProduto))
                    picImagemProduto.Image = Image.FromStream(ms);
            }
            else
            {
                imagemProduto = null;
                picImagemProduto.Image = Properties.Resources.desenvolvimento_de_produto__1_;
            }
        }

        private void picImagemProduto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Selecionar Imagem";
            ofd.Filter = "Imagens (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagemProduto = File.ReadAllBytes(ofd.FileName);
                picImagemProduto.Image = new Bitmap(ofd.FileName);
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (produtoIdAtual == -1)
            {
                MessageBox.Show("Nenhum produto selecionado.");
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                conexao.Open();
                string query = @"UPDATE produtos SET 
                        nome = @nome, 
                        categoria = @categoria, 
                        tamanho = @tamanho, 
                        cor = @cor, 
                        quantidade = @quantidade, 
                        preco = @preco, 
                        descricao = @descricao, 
                        imagem = @imagem 
                        WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                cmd.Parameters.AddWithValue("@categoria", cmbCategoria.Text);
                cmd.Parameters.AddWithValue("@tamanho", cmbTamanho.Text);
                cmd.Parameters.AddWithValue("@cor", cmbCor.Text);
                cmd.Parameters.AddWithValue("@quantidade", (int)nudQuantidade.Value);
                cmd.Parameters.AddWithValue("@preco", decimal.Parse(txtPreco.Text));
                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@imagem", imagemProduto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", produtoIdAtual);

                int resultado = cmd.ExecuteNonQuery();
                MessageBox.Show(resultado > 0 ? "Produto atualizado com sucesso!" : "Nenhuma alteração realizada.");

                if (resultado > 0)
                    LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o nome.");
                return false;
            }
            if (cmbCategoria.SelectedIndex < 0 || cmbTamanho.SelectedIndex < 0 || cmbCor.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione categoria, tamanho e cor.");
                return false;
            }
            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco < 0)
            {
                MessageBox.Show("Preço inválido.");
                return false;
            }
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            produtoIdAtual = -1;
            txtNome.Clear();
            cmbCategoria.SelectedIndex = -1;
            cmbTamanho.SelectedIndex = -1;
            cmbCor.SelectedIndex = -1;
            nudQuantidade.Value = 0;
            txtPreco.Clear();
            txtDescricao.Clear();
            imagemProduto = null;
            picImagemProduto.Image = Properties.Resources.desenvolvimento_de_produto__1_;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoque());
            }
        }
    }
}
