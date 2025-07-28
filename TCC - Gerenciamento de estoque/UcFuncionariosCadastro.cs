using MySql.Data.MySqlClient;
using SistemaLoja;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcFuncionariosCadastro : UserControl
    {
        public UcFuncionariosCadastro()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu form = (FormMenu)Application.OpenForms["FormMenu"];
            form.CarregarUserControl(new UcFuncionarios());
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
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
                    if (conn == null || conn.State != System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Erro ao conectar ao banco de dados.");
                        return;
                    }

                    string sql = @"INSERT INTO funcionarios 
                        (nome, cpf, rg, data_nasc, telefone, email, cep, cargo, departamento, status, data_admissao, salario, carteira_trabalho, pis_pasep) 
                        VALUES 
                        (@nome, @cpf, @rg, @data_nasc, @telefone, @email, @cep, @cargo, @departamento, @status, @data_admissao, @salario, @carteira_trabalho, @pis_pasep)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
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

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MessageBox.Show("Funcionário cadastrado com sucesso!");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar funcionário.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro do MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
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

            // Campos de texto e combobox
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

            // Datas
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            mtbCPF.Clear();
            txtRG.Clear();
            mtbTelefone.Clear();
            txtEmail.Clear();
            txtCEP.Clear();
            cbmCargo.SelectedIndex = -1;
            cbmDepartamento.SelectedIndex = -1;
            cbmStatus.SelectedIndex = -1;
            txtSalario.Clear();
            txtCarteiraTrabalho.Clear();
            txtPISPASEP.Clear();
            dtpNascimento.Value = DateTime.Now;
            dtpAdmissao.Value = DateTime.Now;

            // Ocultar todas as labels de validação
            lblNome.Visible = false;
            lblCPF.Visible = false;
            lblRG.Visible = false;
            lblTelefone.Visible = false;
            lblEmail.Visible = false;
            lblCEP.Visible = false;
            lblCargo.Visible = false;
            lblDepartamento.Visible = false;
            lblStatus.Visible = false;
            lblSalario.Visible = false;
            lblCarteiraTrabalho.Visible = false;
            lblPISPASEP.Visible = false;
            lblNascimento.Visible = false;
            lblAdmissao.Visible = false;
        }

        private void UcFuncionariosCadastro_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }
    }
}
