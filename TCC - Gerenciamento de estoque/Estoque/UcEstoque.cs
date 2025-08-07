using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoque : UserControl
    {
        public UcEstoque()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoqueCadastro());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormMenu formPai = this.FindForm() as FormMenu;
            if (formPai != null)
            {
                formPai.CarregarUserControl(new UcEstoqueEditar());
            }
        }
    }
}
