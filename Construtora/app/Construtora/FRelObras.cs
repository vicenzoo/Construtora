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
    public partial class FRelObras : Form
    {
        public FRelObras()
        {
            InitializeComponent();
        }

        private void FRelObras_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.OBRA'. Você pode movê-la ou removê-la conforme necessário.
            this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);
            this.reportViewer1.RefreshReport();

        }
    }
}
