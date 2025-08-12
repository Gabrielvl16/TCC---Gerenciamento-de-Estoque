namespace TCC___Gerenciamento_de_estoque
{
    partial class UcRelatorios
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
            this.Clientes = new System.Windows.Forms.Label();
            this.cbAno = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.dgvRelatorio = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new CustomControls.RJControls.RJButton();
            this.btnExportarPdf = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // Clientes
            // 
            this.Clientes.AutoSize = true;
            this.Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clientes.Location = new System.Drawing.Point(20, 2);
            this.Clientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(170, 37);
            this.Clientes.TabIndex = 2;
            this.Clientes.Text = "Relatorios";
            // 
            // cbAno
            // 
            this.cbAno.FormattingEnabled = true;
            this.cbAno.Items.AddRange(new object[] {
            "Todos",
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cbAno.Location = new System.Drawing.Point(495, 146);
            this.cbAno.Name = "cbAno";
            this.cbAno.Size = new System.Drawing.Size(225, 28);
            this.cbAno.TabIndex = 3;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(744, 146);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(225, 28);
            this.cbMes.TabIndex = 4;
            // 
            // dgvRelatorio
            // 
            this.dgvRelatorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorio.Location = new System.Drawing.Point(27, 194);
            this.dgvRelatorio.Name = "dgvRelatorio";
            this.dgvRelatorio.RowHeadersWidth = 62;
            this.dgvRelatorio.RowTemplate.Height = 28;
            this.dgvRelatorio.Size = new System.Drawing.Size(942, 341);
            this.dgvRelatorio.TabIndex = 7;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.BlueViolet;
            this.btnPesquisar.BackgroundColor = System.Drawing.Color.BlueViolet;
            this.btnPesquisar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPesquisar.BorderRadius = 10;
            this.btnPesquisar.BorderSize = 0;
            this.btnPesquisar.FlatAppearance.BorderSize = 0;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPesquisar.Location = new System.Drawing.Point(744, 71);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(225, 52);
            this.btnPesquisar.TabIndex = 11;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextColor = System.Drawing.SystemColors.Window;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.BackColor = System.Drawing.Color.Indigo;
            this.btnExportarPdf.BackgroundColor = System.Drawing.Color.Indigo;
            this.btnExportarPdf.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnExportarPdf.BorderRadius = 10;
            this.btnExportarPdf.BorderSize = 0;
            this.btnExportarPdf.FlatAppearance.BorderSize = 0;
            this.btnExportarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPdf.ForeColor = System.Drawing.SystemColors.Window;
            this.btnExportarPdf.Location = new System.Drawing.Point(27, 543);
            this.btnExportarPdf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(225, 52);
            this.btnExportarPdf.TabIndex = 12;
            this.btnExportarPdf.Text = "Exportar em PDF";
            this.btnExportarPdf.TextColor = System.Drawing.SystemColors.Window;
            this.btnExportarPdf.UseVisualStyleBackColor = false;
            this.btnExportarPdf.Click += new System.EventHandler(this.btnExportarPdf_Click);
            // 
            // UcRelatorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportarPdf);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dgvRelatorio);
            this.Controls.Add(this.cbMes);
            this.Controls.Add(this.cbAno);
            this.Controls.Add(this.Clientes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcRelatorios";
            this.Size = new System.Drawing.Size(998, 606);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Clientes;
        private System.Windows.Forms.ComboBox cbAno;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.DataGridView dgvRelatorio;
        private CustomControls.RJControls.RJButton btnPesquisar;
        private CustomControls.RJControls.RJButton btnExportarPdf;
    }
}
