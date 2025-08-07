using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoqueEditar : UserControl
    {
        private MySqlConnection conexao = new MySqlConnection("server=localhost;database=loja_roupas_2_0;uid=root;pwd=;");

        private int produtoIdAtual = -1; // Armazena o id do produto carregado para edição

        public UcEstoqueEditar()
        {
            InitializeComponent();
            CarregarCategorias();
            CarregarTamanhos();
            CarregarCores();

            txtBuscarProduto.TextChanged += BuscarProdutoPorNome;
            txtBuscarIdDoProduto.TextChanged += BuscarProdutoPorId;

            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;
        }

        private void CarregarCategorias()
        {
            cmbCategoria.Items.Clear();
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT categoria FROM produtos", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCategoria.Items.Add(reader.GetString("categoria"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void CarregarTamanhos()
        {
            cmbTamanho.Items.Clear();
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT tamanho FROM produtos", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbTamanho.Items.Add(reader.GetString("tamanho"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tamanhos: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void CarregarCores()
        {
            cmbCor.Items.Clear();
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT cor FROM produtos", conexao);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbCor.Items.Add(reader.GetString("cor"));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cores: " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        private void BuscarProdutoPorNome(object sender, EventArgs e)
        {
            string nomeBusca = txtBuscarProduto.Text.Trim();
            if (string.IsNullOrEmpty(nomeBusca))
            {
                LimparCampos();
                return;
            }

            try
            {
                conexao.Open();
                string query = "SELECT * FROM produtos WHERE nome LIKE @nome LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@nome", "%" + nomeBusca + "%");
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    PreencherCampos(reader);
                }
                else
                {
                    LimparCampos();
                }
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

        private void BuscarProdutoPorId(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscarIdDoProduto.Text.Trim(), out int idBusca))
            {
                LimparCampos();
                return;
            }

            try
            {
                conexao.Open();
                string query = "SELECT * FROM produtos WHERE id = @id LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@id", idBusca);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    PreencherCampos(reader);
                }
                else
                {
                    LimparCampos();
                }
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
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (produtoIdAtual == -1)
            {
                MessageBox.Show("Nenhum produto selecionado para salvar.");
                return;
            }

            if (!ValidarCampos())
                return;

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
                                    descricao = @descricao
                                 WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, conexao);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                cmd.Parameters.AddWithValue("@categoria", cmbCategoria.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@tamanho", cmbTamanho.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@cor", cmbCor.SelectedItem?.ToString() ?? "");
                cmd.Parameters.AddWithValue("@quantidade", (int)nudQuantidade.Value);

                if (decimal.TryParse(txtPreco.Text.Trim(), out decimal preco))
                    cmd.Parameters.AddWithValue("@preco", preco);
                else
                {
                    MessageBox.Show("Preço inválido.");
                    return;
                }

                cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text.Trim());
                cmd.Parameters.AddWithValue("@id", produtoIdAtual);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Produto atualizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produto: " + ex.Message);
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
                MessageBox.Show("Preencha o nome do produto.");
                return false;
            }
            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a categoria.");
                return false;
            }
            if (cmbTamanho.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione o tamanho.");
                return false;
            }
            if (cmbCor.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione a cor.");
                return false;
            }
            if (nudQuantidade.Value < 0)
            {
                MessageBox.Show("Quantidade inválida.");
                return false;
            }
            if (!decimal.TryParse(txtPreco.Text.Trim(), out decimal preco) || preco < 0)
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