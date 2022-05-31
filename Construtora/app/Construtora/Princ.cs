using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construtora
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pecas p1 = new Pecas();
            p1.MdiParent = this;

            p1.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Equipamento e1 = new Equipamento();
            e1.MdiParent = this;

            e1.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Estoque es1 = new Estoque();
            es1.MdiParent = this;

            es1.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Venda v1 = new Venda();
            v1.MdiParent = this;

            v1.Show();
        }
    }
}
