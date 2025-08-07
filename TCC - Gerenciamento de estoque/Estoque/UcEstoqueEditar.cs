using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC___Gerenciamento_de_estoque
{
    public partial class UcEstoqueEditar: UserControl
    {
        public UcEstoqueEditar()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
