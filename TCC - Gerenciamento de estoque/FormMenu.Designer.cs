namespace TCC___Gerenciamento_de_estoque
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelConteudo = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelUsuarioInfo = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFecharInfo = new System.Windows.Forms.PictureBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEmailUsuario = new System.Windows.Forms.Label();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.picUsuarioInfo = new CustomControls.RJControls.RJCircularPictureBox();
            this.btnUsuario = new CustomControls.RJControls.RJButton();
            this.picUsuario = new CustomControls.RJControls.RJCircularPictureBox();
            this.btnLogin = new CustomControls.RJControls.RJButton();
            this.btnRelatorio = new CustomControls.RJControls.RJButton();
            this.btnClientes = new CustomControls.RJControls.RJButton();
            this.btnFuncionarios = new CustomControls.RJControls.RJButton();
            this.btnEstoque = new CustomControls.RJControls.RJButton();
            this.panelMenu.SuspendLayout();
            this.panelConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panelUsuarioInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 44);
            this.panel1.TabIndex = 4;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.BlueViolet;
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.picUsuario);
            this.panelMenu.Controls.Add(this.btnLogin);
            this.panelMenu.Controls.Add(this.btnRelatorio);
            this.panelMenu.Controls.Add(this.btnClientes);
            this.panelMenu.Controls.Add(this.btnFuncionarios);
            this.panelMenu.Controls.Add(this.btnEstoque);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 44);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(135, 394);
            this.panelMenu.TabIndex = 5;
            // 
            // panelConteudo
            // 
            this.panelConteudo.Controls.Add(this.panelUsuarioInfo);
            this.panelConteudo.Controls.Add(this.picLogo);
            this.panelConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConteudo.Location = new System.Drawing.Point(135, 44);
            this.panelConteudo.Name = "panelConteudo";
            this.panelConteudo.Size = new System.Drawing.Size(665, 394);
            this.panelConteudo.TabIndex = 6;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(-132, -58);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(929, 510);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            // 
            // panelUsuarioInfo
            // 
            this.panelUsuarioInfo.BackColor = System.Drawing.SystemColors.Menu;
            this.panelUsuarioInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsuarioInfo.Controls.Add(this.label3);
            this.panelUsuarioInfo.Controls.Add(this.label2);
            this.panelUsuarioInfo.Controls.Add(this.label1);
            this.panelUsuarioInfo.Controls.Add(this.panel2);
            this.panelUsuarioInfo.Controls.Add(this.lblUsuario);
            this.panelUsuarioInfo.Controls.Add(this.lblEmailUsuario);
            this.panelUsuarioInfo.Controls.Add(this.lblNomeUsuario);
            this.panelUsuarioInfo.Location = new System.Drawing.Point(0, 50);
            this.panelUsuarioInfo.Name = "panelUsuarioInfo";
            this.panelUsuarioInfo.Size = new System.Drawing.Size(186, 256);
            this.panelUsuarioInfo.TabIndex = 15;
            this.panelUsuarioInfo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(15, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(14, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(14, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nome:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Indigo;
            this.panel2.Controls.Add(this.picUsuarioInfo);
            this.panel2.Controls.Add(this.btnFecharInfo);
            this.panel2.Location = new System.Drawing.Point(-4, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 78);
            this.panel2.TabIndex = 2;
            // 
            // btnFecharInfo
            // 
            this.btnFecharInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharInfo.Image")));
            this.btnFecharInfo.Location = new System.Drawing.Point(167, 7);
            this.btnFecharInfo.Name = "btnFecharInfo";
            this.btnFecharInfo.Size = new System.Drawing.Size(18, 21);
            this.btnFecharInfo.TabIndex = 12;
            this.btnFecharInfo.TabStop = false;
            this.btnFecharInfo.Click += new System.EventHandler(this.btnFecharInfo_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(24, 197);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(33, 15);
            this.lblUsuario.TabIndex = 15;
            this.lblUsuario.Text = "lbltxt";
            // 
            // lblEmailUsuario
            // 
            this.lblEmailUsuario.AutoSize = true;
            this.lblEmailUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailUsuario.Location = new System.Drawing.Point(24, 160);
            this.lblEmailUsuario.Name = "lblEmailUsuario";
            this.lblEmailUsuario.Size = new System.Drawing.Size(33, 15);
            this.lblEmailUsuario.TabIndex = 14;
            this.lblEmailUsuario.Text = "lbltxt";
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUsuario.Location = new System.Drawing.Point(24, 122);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(33, 15);
            this.lblNomeUsuario.TabIndex = 13;
            this.lblNomeUsuario.Text = "lbltxt";
            // 
            // picUsuarioInfo
            // 
            this.picUsuarioInfo.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picUsuarioInfo.BorderColor = System.Drawing.Color.Violet;
            this.picUsuarioInfo.BorderColor2 = System.Drawing.Color.BlueViolet;
            this.picUsuarioInfo.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picUsuarioInfo.BorderSize = 2;
            this.picUsuarioInfo.GradientAngle = 45F;
            this.picUsuarioInfo.Location = new System.Drawing.Point(69, 10);
            this.picUsuarioInfo.Name = "picUsuarioInfo";
            this.picUsuarioInfo.Size = new System.Drawing.Size(56, 56);
            this.picUsuarioInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsuarioInfo.TabIndex = 11;
            this.picUsuarioInfo.TabStop = false;
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.BlueViolet;
            this.btnUsuario.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnUsuario.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnUsuario.BorderRadius = 15;
            this.btnUsuario.BorderSize = 0;
            this.btnUsuario.FlatAppearance.BorderSize = 0;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnUsuario.Image")));
            this.btnUsuario.Location = new System.Drawing.Point(-82, 222);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(217, 31);
            this.btnUsuario.TabIndex = 11;
            this.btnUsuario.Text = "                               Usuários";
            this.btnUsuario.TextColor = System.Drawing.Color.White;
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            this.btnUsuario.MouseEnter += new System.EventHandler(this.btnUsuarios_MouseEnter);
            this.btnUsuario.MouseLeave += new System.EventHandler(this.btnUsuarios_MouseLeave);
            // 
            // picUsuario
            // 
            this.picUsuario.BorderCapStyle = System.Drawing.Drawing2D.DashCap.Flat;
            this.picUsuario.BorderColor = System.Drawing.Color.Violet;
            this.picUsuario.BorderColor2 = System.Drawing.Color.BlueViolet;
            this.picUsuario.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.picUsuario.BorderSize = 2;
            this.picUsuario.GradientAngle = 45F;
            this.picUsuario.Location = new System.Drawing.Point(38, 9);
            this.picUsuario.Name = "picUsuario";
            this.picUsuario.Size = new System.Drawing.Size(56, 56);
            this.picUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsuario.TabIndex = 1;
            this.picUsuario.TabStop = false;
            this.picUsuario.Click += new System.EventHandler(this.picUsuario_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.BlueViolet;
            this.btnLogin.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnLogin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnLogin.BorderRadius = 15;
            this.btnLogin.BorderSize = 0;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(-82, 350);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(217, 31);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.Text = "                          Login";
            this.btnLogin.TextColor = System.Drawing.Color.White;
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.BlueViolet;
            this.btnRelatorio.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnRelatorio.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRelatorio.BorderRadius = 15;
            this.btnRelatorio.BorderSize = 0;
            this.btnRelatorio.FlatAppearance.BorderSize = 0;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.ForeColor = System.Drawing.Color.White;
            this.btnRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorio.Image")));
            this.btnRelatorio.Location = new System.Drawing.Point(-82, 185);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(217, 31);
            this.btnRelatorio.TabIndex = 9;
            this.btnRelatorio.Text = "                                 Relatorios";
            this.btnRelatorio.TextColor = System.Drawing.Color.White;
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorios_Click);
            this.btnRelatorio.MouseEnter += new System.EventHandler(this.btnRelatorios_MouseEnter);
            this.btnRelatorio.MouseLeave += new System.EventHandler(this.btnRelatorios_MouseLeave);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.BlueViolet;
            this.btnClientes.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnClientes.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnClientes.BorderRadius = 15;
            this.btnClientes.BorderSize = 0;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.Location = new System.Drawing.Point(-82, 148);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(217, 31);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "                             Clientes";
            this.btnClientes.TextColor = System.Drawing.Color.White;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            this.btnClientes.MouseEnter += new System.EventHandler(this.btnClientes_MouseEnter);
            this.btnClientes.MouseLeave += new System.EventHandler(this.btnClientes_MouseLeave);
            // 
            // btnFuncionarios
            // 
            this.btnFuncionarios.BackColor = System.Drawing.Color.BlueViolet;
            this.btnFuncionarios.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnFuncionarios.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnFuncionarios.BorderRadius = 15;
            this.btnFuncionarios.BorderSize = 0;
            this.btnFuncionarios.FlatAppearance.BorderSize = 0;
            this.btnFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuncionarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncionarios.ForeColor = System.Drawing.Color.White;
            this.btnFuncionarios.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncionarios.Image")));
            this.btnFuncionarios.Location = new System.Drawing.Point(-82, 111);
            this.btnFuncionarios.Name = "btnFuncionarios";
            this.btnFuncionarios.Size = new System.Drawing.Size(217, 31);
            this.btnFuncionarios.TabIndex = 7;
            this.btnFuncionarios.Text = "                                      Funcionarios";
            this.btnFuncionarios.TextColor = System.Drawing.Color.White;
            this.btnFuncionarios.UseVisualStyleBackColor = false;
            this.btnFuncionarios.Click += new System.EventHandler(this.btnFuncionarios_Click);
            this.btnFuncionarios.MouseEnter += new System.EventHandler(this.btnFuncionarios_MouseEnter);
            this.btnFuncionarios.MouseLeave += new System.EventHandler(this.btnFuncionarios_MouseLeave);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.BlueViolet;
            this.btnEstoque.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnEstoque.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnEstoque.BorderRadius = 15;
            this.btnEstoque.BorderSize = 0;
            this.btnEstoque.FlatAppearance.BorderSize = 0;
            this.btnEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstoque.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.ForeColor = System.Drawing.Color.White;
            this.btnEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnEstoque.Image")));
            this.btnEstoque.Location = new System.Drawing.Point(-82, 76);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(217, 31);
            this.btnEstoque.TabIndex = 6;
            this.btnEstoque.Text = "                             Estoque";
            this.btnEstoque.TextColor = System.Drawing.Color.White;
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            this.btnEstoque.MouseEnter += new System.EventHandler(this.btnEstoque_MouseEnter);
            this.btnEstoque.MouseLeave += new System.EventHandler(this.btnEstoque_MouseLeave);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.panelConteudo);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panelUsuarioInfo.ResumeLayout(false);
            this.panelUsuarioInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuarioInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMenu;
        private CustomControls.RJControls.RJButton btnEstoque;
        private CustomControls.RJControls.RJButton btnRelatorio;
        private CustomControls.RJControls.RJButton btnClientes;
        private CustomControls.RJControls.RJButton btnFuncionarios;
        private CustomControls.RJControls.RJButton btnLogin;
        private System.Windows.Forms.Panel panelConteudo;
        private CustomControls.RJControls.RJCircularPictureBox picUsuario;
        private CustomControls.RJControls.RJButton btnUsuario;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelUsuarioInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private CustomControls.RJControls.RJCircularPictureBox picUsuarioInfo;
        private System.Windows.Forms.PictureBox btnFecharInfo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEmailUsuario;
        private System.Windows.Forms.Label lblNomeUsuario;
        // private System.Windows.Forms.PictureBox ToggleSubMenu;
    }
}