using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TCC___Gerenciamento_de_estoque.Movimentações
{
    public partial class UcMovimentacaoEstoque : UserControl
    {
        private string conexaoStr = "server=localhost;database=loja_roupas_2_0;uid=root;pwd=;";

        public UcMovimentacaoEstoque()
        {
            InitializeComponent();
            CarregarProdutos();
            PreencherTipoMovimentacao();

            btnRegistrar.Click += BtnRegistrar_Click;
        }

        private void CarregarProdutos()
        {
            using (MySqlConnection con = new MySqlConnection(conexaoStr))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT id, nome FROM produtos ORDER BY nome";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbProduto.DisplayMember = "nome";
                        cbProduto.ValueMember = "id";
                        cbProduto.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
                }
            }
        }

        private void PreencherTipoMovimentacao()
        {
            cbTipoMovimentacao.Items.Clear();
            cbTipoMovimentacao.Items.Add("Entrada");
            cbTipoMovimentacao.Items.Add("Saída");
            cbTipoMovimentacao.Items.Add("Devolução");
            cbTipoMovimentacao.SelectedIndex = 0;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbProduto.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um produto.");
                return;
            }

            if (nudQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe uma quantidade maior que zero.");
                return;
            }

            string tipoMov = cbTipoMovimentacao.SelectedItem.ToString();
            int produtoId = Convert.ToInt32(cbProduto.SelectedValue);
            int quantidade = (int)nudQuantidade.Value;
            string observacao = txtObservacao.Text.Trim();

            try
            {
                using (MySqlConnection con = new MySqlConnection(conexaoStr))
                {
                    con.Open();

                    // Começa a transação para garantir atomicidade
                    using (MySqlTransaction transacao = con.BeginTransaction())
                    {
                        // Insere o registro na tabela de movimentações
                        string sqlInsert = @"INSERT INTO movimentacoes_estoque
                            (produto_id, tipo_movimentacao, quantidade, data_movimentacao, observacao)
                            VALUES (@produto_id, @tipo_movimentacao, @quantidade, NOW(), @observacao)";
                        using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, con, transacao))
                        {
                            cmdInsert.Parameters.AddWithValue("@produto_id", produtoId);
                            cmdInsert.Parameters.AddWithValue("@tipo_movimentacao", tipoMov);
                            cmdInsert.Parameters.AddWithValue("@quantidade", quantidade);
                            cmdInsert.Parameters.AddWithValue("@observacao", observacao);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // Atualiza a quantidade na tabela produtos
                        string sqlUpdate = "";
                        if (tipoMov == "Entrada" || tipoMov == "Devolução")
                        {
                            sqlUpdate = "UPDATE produtos SET quantidade = quantidade + @quantidade WHERE id = @produto_id";
                        }
                        else if (tipoMov == "Saída")
                        {
                            // Antes de subtrair, verifique se tem estoque suficiente
                            string sqlVerifica = "SELECT quantidade FROM produtos WHERE id = @produto_id";
                            using (MySqlCommand cmdVerifica = new MySqlCommand(sqlVerifica, con, transacao))
                            {
                                cmdVerifica.Parameters.AddWithValue("@produto_id", produtoId);
                                int estoqueAtual = Convert.ToInt32(cmdVerifica.ExecuteScalar());
                                if (estoqueAtual < quantidade)
                                {
                                    MessageBox.Show("Estoque insuficiente para essa saída.");
                                    transacao.Rollback();
                                    return;
                                }
                            }

                            sqlUpdate = "UPDATE produtos SET quantidade = quantidade - @quantidade WHERE id = @produto_id";
                        }

                        using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, con, transacao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@quantidade", quantidade);
                            cmdUpdate.Parameters.AddWithValue("@produto_id", produtoId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        transacao.Commit();
                    }
                }

                MessageBox.Show("Movimentação registrada com sucesso.");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao registrar movimentação: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            cbProduto.SelectedIndex = -1;
            cbTipoMovimentacao.SelectedIndex = 0;
            nudQuantidade.Value = 1;
            txtObservacao.Clear();
        }
    }
}

