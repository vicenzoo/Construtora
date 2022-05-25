using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Construtora
{
    public partial class Construtora : Form
    {
        public Construtora()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Pecas p1 = new Pecas();
            p1.MdiParent = this;

            p1.Show();
        }

        private void Construtora_Load(object sender, EventArgs e)
        {

        }
    }
}
