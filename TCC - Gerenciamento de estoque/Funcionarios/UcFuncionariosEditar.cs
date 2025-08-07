using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaLoja;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcFuncionariosEditar : UserControl
    {
        public UcFuncionariosEditar()
        {
            InitializeComponent();

            // Placeholder e estilo do txtID
            txtID.ForeColor = Color.White;
            txtID.Text = "Digite o ID do funcionário";
            txtID.GotFocus += TxtID_GotFocus;
            txtID.LostFocus += TxtID_LostFocus;
            txtID.KeyDown += TxtID_KeyDown;
        }

        private void TxtID_GotFocus(object sender, EventArgs e)
        {
            if (txtID.Text == "Digite o ID do funcionário")
            {
                txtID.Text = "";
            }
        }

        private void TxtID_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "Digite o ID do funcionário";
            }
        }

        private void TxtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtID.Text) && txtID.Text != "Digite o ID do funcionário")
            {
                BuscarFuncionario(txtID.Text.Trim());
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BuscarFuncionario(string id)
        {
            try
            {
                Conexao conexao = new Conexao();
                using (MySqlConnection conn = conexao.Conectar())
                {
                    string query = "SELECT * FROM funcionarios WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNome.Text = reader["nome"].ToString();
                        mtbCPF.Text = reader["cpf"].ToString();
                        txtRG.Text = reader["rg"].ToString();
                        dtpNascimento.Value = Convert.ToDateTime(reader["data_nasc"]);
                        mtbTelefone.Text = reader["telefone"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtCEP.Text = reader["cep"].ToString();
                        cbmCargo.Text = reader["cargo"].ToString();
                        cbmDepartamento.Text = reader["departamento"].ToString();
                        cbmStatus.Text = reader["status"].ToString();
                        dtpAdmissao.Value = Convert.ToDateTime(reader["data_admissao"]);
                        txtSalario.Text = reader["salario"].ToString();
                        txtCarteiraTrabalho.Text = reader["carteira_trabalho"].ToString();
                        txtPISPASEP.Text = reader["pis_pasep"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Funcionário não encontrado.");
                        LimparCampos();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || txtID.Text == "Digite o ID do funcionário")
            {
                MessageBox.Show("Digite o ID do funcionário.");
                return;
            }

            if (!ValidarCamposObrigatorios())
            {
                MessageBox.Show("Preencha todos os campos obrigatórios corretamente.");
                return;
            }

            try
            {
                Conexao conexao = new Conexao();
                using (MySqlConnection conn = conexao.Conectar())
                {
                    string sql = @"UPDATE funcionarios SET 
                        nome=@nome, cpf=@cpf, rg=@rg, data_nasc=@data_nasc, telefone=@telefone, email=@email, 
                        cep=@cep, cargo=@cargo, departamento=@departamento, status=@status, 
                        data_admissao=@data_admissao, salario=@salario, carteira_trabalho=@carteira_trabalho, 
                        pis_pasep=@pis_pasep WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@cpf", mtbCPF.Text.Trim());
                    cmd.Parameters.AddWithValue("@rg", txtRG.Text.Trim());
                    cmd.Parameters.AddWithValue("@data_nasc", dtpNascimento.Value.Date);
                    cmd.Parameters.AddWithValue("@telefone", mtbTelefone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@cep", txtCEP.Text.Trim());
                    cmd.Parameters.AddWithValue("@cargo", cbmCargo.Text.Trim());
                    cmd.Parameters.AddWithValue("@departamento", cbmDepartamento.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", cbmStatus.Text.Trim());
                    cmd.Parameters.AddWithValue("@data_admissao", dtpAdmissao.Value.Date);

                    decimal salario;
                    if (!decimal.TryParse(txtSalario.Text.Trim(), out salario))
                        salario = 0;
                    cmd.Parameters.AddWithValue("@salario", salario);

                    cmd.Parameters.AddWithValue("@carteira_trabalho", txtCarteiraTrabalho.Text.Trim());
                    cmd.Parameters.AddWithValue("@pis_pasep", txtPISPASEP.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show(result > 0 ? "Dados atualizados com sucesso!" : "Erro ao atualizar.");

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private bool ValidarCamposObrigatorios()
        {
            bool valido = true;

            void Verificar(Control campo, Label label)
            {
                if (string.IsNullOrWhiteSpace(campo.Text))
                {
                    label.Visible = true;
                    valido = false;
                }
                else
                {
                    label.Visible = false;
                }
            }

            Verificar(txtNome, lblNome);
            Verificar(mtbCPF, lblCPF);
            Verificar(txtRG, lblRG);
            Verificar(mtbTelefone, lblTelefone);
            Verificar(txtEmail, lblEmail);
            Verificar(txtCEP, lblCEP);
            Verificar(cbmCargo, lblCargo);
            Verificar(cbmDepartamento, lblDepartamento);
            Verificar(cbmStatus, lblStatus);
            Verificar(txtSalario, lblSalario);
            Verificar(txtCarteiraTrabalho, lblCarteiraTrabalho);
            Verificar(txtPISPASEP, lblPISPASEP);

            if (dtpNascimento.Value.Date > DateTime.Now)
            {
                lblNascimento.Visible = true;
                valido = false;
            }
            else
            {
                lblNascimento.Visible = false;
            }

            if (dtpAdmissao.Value.Date > DateTime.Now)
            {
                lblAdmissao.Visible = true;
                valido = false;
            }
            else
            {
                lblAdmissao.Visible = false;
            }

            return valido;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || txtID.Text == "Digite o ID do funcionário")
            {
                MessageBox.Show("Digite o ID do funcionário.");
                return;
            }

            DialogResult confirmar = MessageBox.Show("Tem certeza que deseja excluir este funcionário?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                try
                {
                    Conexao conexao = new Conexao();
                    using (MySqlConnection conn = conexao.Conectar())
                    {
                        string sql = "DELETE FROM funcionarios WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", txtID.Text.Trim());

                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result > 0 ? "Funcionário excluído com sucesso!" : "Funcionário não encontrado.");

                        LimparCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            var pai = this.Parent;
            this.Dispose(); // Remove o atual

            UcFuncionarios uc = new UcFuncionarios
            {
                Dock = DockStyle.Fill
            };
            pai.Controls.Add(uc);
        }

        private void LimparCampos()
        {
            txtID.Text = "Digite o ID do funcionário";
            txtNome.Clear();
            mtbCPF.Clear();
            txtRG.Clear();
            dtpNascimento.Value = DateTime.Now;
            mtbTelefone.Clear();
            txtEmail.Clear();
            txtCEP.Clear();
            cbmCargo.SelectedIndex = -1;
            cbmDepartamento.SelectedIndex = -1;
            cbmStatus.SelectedIndex = -1;
            dtpAdmissao.Value = DateTime.Now;
            txtSalario.Clear();
            txtCarteiraTrabalho.Clear();
            txtPISPASEP.Clear();

            // Oculta labels de erro
            lblNome.Visible = false;
            lblCPF.Visible = false;
            lblRG.Visible = false;
            lblNascimento.Visible = false;
            lblTelefone.Visible = false;
            lblEmail.Visible = false;
            lblCEP.Visible = false;
            lblCargo.Visible = false;
            lblDepartamento.Visible = false;
            lblStatus.Visible = false;
            lblAdmissao.Visible = false;
            lblSalario.Visible = false;
            lblCarteiraTrabalho.Visible = false;
            lblPISPASEP.Visible = false;
        }
    }
}
