namespace TCC___Gerenciamento_de_estoque
{
    partial class UcUsuarioEditar
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcUsuarioEditar));
            this.Clientes = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new CustomControls.RJControls.RJButton();
            this.btnEditar = new CustomControls.RJControls.RJButton();
            this.btnVoltar = new CustomControls.RJControls.RJButton();
            this.picUsuarioInfo = new CustomControls.RJControls.RJCircularPictureBox();
            this.Cadastro = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCancelar = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioInfo)).BeginInit();
            this.Cadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // Clientes
            // 
            this.Clientes.AutoSize = true;
            this.Clientes.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clientes.Location = new System.Drawing.Point(15, 5);
            this.Clientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(172, 30);
            this.Clientes.TabIndex = 27;
            this.Clientes.Text = "Usuários / Editar";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.BlueViolet;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(457, 25);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(192, 23);
            this.txtId.TabIndex = 33;
            this.txtId.Tag = "";
            this.txtId.Text = "Insira ID aqui...";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(418, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(34, 34);
            this.btnBuscar.TabIndex = 32;
            this.btnBuscar.TabStop = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.Firebrick;
            this.btnExcluir.BackgroundColor = System.Drawing.Color.Firebrick;
            this.btnExcluir.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExcluir.BorderRadius = 10;
            this.btnExcluir.BorderSize = 0;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.Location = new System.Drawing.Point(174, 342);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(150, 43);
            this.btnExcluir.TabIndex = 57;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextColor = System.Drawing.Color.White;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditar.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEditar.BorderRadius = 10;
            this.btnEditar.BorderSize = 0;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(18, 342);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 43);
            this.btnEditar.TabIndex = 56;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextColor = System.Drawing.Color.White;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.BlueViolet;
            this.btnVoltar.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnVoltar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnVoltar.BorderRadius = 15;
            this.btnVoltar.BorderSize = 0;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(497, 346);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(150, 34);
            this.btnVoltar.TabIndex = 55;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.TextColor = System.Drawing.Color.White;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // picUsuarioInfo
            // 
            this.picUsuarioInfo.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picUsuarioInfo.BorderColor = System.Drawing.Color.Violet;
            this.picUsuarioInfo.BorderColor2 = System.Drawing.Color.BlueViolet;
            this.picUsuarioInfo.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picUsuarioInfo.BorderSize = 2;
            this.picUsuarioInfo.GradientAngle = 45F;
            this.picUsuarioInfo.Image = ((System.Drawing.Image)(resources.GetObject("picUsuarioInfo.Image")));
            this.picUsuarioInfo.Location = new System.Drawing.Point(488, 67);
            this.picUsuarioInfo.Name = "picUsuarioInfo";
            this.picUsuarioInfo.Size = new System.Drawing.Size(157, 157);
            this.picUsuarioInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsuarioInfo.TabIndex = 54;
            this.picUsuarioInfo.TabStop = false;
            this.picUsuarioInfo.Click += new System.EventHandler(this.PicUsuarioInfo_Click);
            // 
            // Cadastro
            // 
            this.Cadastro.Controls.Add(this.lblStatus);
            this.Cadastro.Controls.Add(this.txtEmail);
            this.Cadastro.Controls.Add(this.label6);
            this.Cadastro.Controls.Add(this.lblSenha);
            this.Cadastro.Controls.Add(this.cmbStatus);
            this.Cadastro.Controls.Add(this.label5);
            this.Cadastro.Controls.Add(this.lblEmail);
            this.Cadastro.Controls.Add(this.cmbNivel);
            this.Cadastro.Controls.Add(this.lblNome);
            this.Cadastro.Controls.Add(this.label4);
            this.Cadastro.Controls.Add(this.txtSenha);
            this.Cadastro.Controls.Add(this.txtUsuario);
            this.Cadastro.Controls.Add(this.txtNome);
            this.Cadastro.Controls.Add(this.label3);
            this.Cadastro.Controls.Add(this.label2);
            this.Cadastro.Controls.Add(this.label1);
            this.Cadastro.Controls.Add(this.lblUsuario);
            this.Cadastro.Controls.Add(this.lblNivel);
            this.Cadastro.Location = new System.Drawing.Point(26, 62);
            this.Cadastro.Name = "Cadastro";
            this.Cadastro.Size = new System.Drawing.Size(443, 162);
            this.Cadastro.TabIndex = 53;
            this.Cadastro.TabStop = false;
            this.Cadastro.Text = "Cadastro";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblStatus.Location = new System.Drawing.Point(419, 114);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(17, 21);
            this.lblStatus.TabIndex = 53;
            this.lblStatus.Text = "*";
            this.lblStatus.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(73, 54);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(346, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNivel.ForeColor = System.Drawing.Color.Crimson;
            this.lblNivel.Location = new System.Drawing.Point(224, 114);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(17, 21);
            this.lblNivel.TabIndex = 52;
            this.lblNivel.Text = "*";
            this.lblNivel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblSenha.ForeColor = System.Drawing.Color.Crimson;
            this.lblSenha.Location = new System.Drawing.Point(419, 80);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(17, 21);
            this.lblSenha.TabIndex = 51;
            this.lblSenha.Text = "*";
            this.lblSenha.Visible = false;
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Ativo",
            "Inativo"});
            this.cmbStatus.Location = new System.Drawing.Point(297, 117);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(249, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.Crimson;
            this.lblEmail.Location = new System.Drawing.Point(419, 49);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(17, 21);
            this.lblEmail.TabIndex = 49;
            this.lblEmail.Text = "*";
            this.lblEmail.Visible = false;
            // 
            // cmbNivel
            // 
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Items.AddRange(new object[] {
            "Admin",
            "comum"});
            this.cmbNivel.Location = new System.Drawing.Point(105, 117);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(121, 21);
            this.cmbNivel.TabIndex = 7;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.Crimson;
            this.lblNome.Location = new System.Drawing.Point(419, 21);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(17, 21);
            this.lblNome.TabIndex = 48;
            this.lblNome.Text = "*";
            this.lblNome.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nível de acesso:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(285, 84);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(134, 20);
            this.txtSenha.TabIndex = 5;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(73, 84);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(153, 20);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 25);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(346, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.Crimson;
            this.lblUsuario.Location = new System.Drawing.Point(224, 80);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(17, 21);
            this.lblUsuario.TabIndex = 50;
            this.lblUsuario.Text = "*";
            this.lblUsuario.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelar.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnCancelar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnCancelar.BorderRadius = 10;
            this.btnCancelar.BorderSize = 0;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(330, 342);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 43);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // UcUsuarioEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.picUsuarioInfo);
            this.Controls.Add(this.Cadastro);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.Clientes);
            this.Name = "UcUsuarioEditar";
            this.Size = new System.Drawing.Size(665, 394);
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioInfo)).EndInit();
            this.Cadastro.ResumeLayout(false);
            this.Cadastro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Clientes;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.PictureBox btnBuscar;
        private CustomControls.RJControls.RJButton btnExcluir;
        private CustomControls.RJControls.RJButton btnEditar;
        private CustomControls.RJControls.RJButton btnVoltar;
        private CustomControls.RJControls.RJCircularPictureBox picUsuarioInfo;
        private System.Windows.Forms.GroupBox Cadastro;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuario;
        private CustomControls.RJControls.RJButton btnCancelar;
    }
}
