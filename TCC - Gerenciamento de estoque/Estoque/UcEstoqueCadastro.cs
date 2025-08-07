using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoqueCadastro : UserControl
    {
        public UcEstoqueCadastro()
        {
            InitializeComponent();
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

            try
            {
                string conexao = "server=localhost;user=root;database=loja_roupas_2_0;password=;";
                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string query = "INSERT INTO produtos (nome, categoria, tamanho, cor, quantidade, preco, descricao) " +
                                   "VALUES (@nome, @categoria, @tamanho, @cor, @quantidade, @preco, @descricao)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", nome);
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                        cmd.Parameters.AddWithValue("@cor", cor);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@preco", preco);
                        cmd.Parameters.AddWithValue("@descricao", descricao);

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
            txtNome.Text = ""; 
            cbCategoria.SelectedIndex = -1;
            cbTamanho.SelectedIndex = -1;
            cbCor.SelectedIndex = -1;
            numQuantidade.Value = 0;
            txtPreco.Text = "";
            txtDescricao.Text = "";
        }
    }
}