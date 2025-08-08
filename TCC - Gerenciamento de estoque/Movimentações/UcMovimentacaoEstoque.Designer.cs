namespace TCC___Gerenciamento_de_estoque.Movimentações
{
    partial class UcMovimentacaoEstoque
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
            this.btnRegistrar = new CustomControls.RJControls.RJButton();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.cbTipoMovimentacao = new System.Windows.Forms.ComboBox();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRegistrar.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRegistrar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnRegistrar.BorderRadius = 10;
            this.btnRegistrar.BorderSize = 0;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(359, 96);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(188, 43);
            this.btnRegistrar.TabIndex = 33;
            this.btnRegistrar.Text = "Salvar";
            this.btnRegistrar.TextColor = System.Drawing.Color.White;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(43, 86);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(291, 136);
            this.txtObservacao.TabIndex = 32;
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(333, 36);
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 31;
            // 
            // cbTipoMovimentacao
            // 
            this.cbTipoMovimentacao.FormattingEnabled = true;
            this.cbTipoMovimentacao.Location = new System.Drawing.Point(43, 35);
            this.cbTipoMovimentacao.Name = "cbTipoMovimentacao";
            this.cbTipoMovimentacao.Size = new System.Drawing.Size(121, 21);
            this.cbTipoMovimentacao.TabIndex = 30;
            // 
            // cbProduto
            // 
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(187, 35);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(121, 21);
            this.cbProduto.TabIndex = 29;
            // 
            // UcMovimentacaoEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.cbTipoMovimentacao);
            this.Controls.Add(this.cbProduto);
            this.Name = "UcMovimentacaoEstoque";
            this.Size = new System.Drawing.Size(566, 305);
            //this.Load += new System.EventHandler(this.UcMovimentacaoEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJButton btnRegistrar;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.ComboBox cbTipoMovimentacao;
        private System.Windows.Forms.ComboBox cbProduto;
    }
}
