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
    public partial class FRelEstoque : Form
    {
        public FRelEstoque()
        {
            InitializeComponent();
        }

        private void FRelEstoque_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.ESTOQUE'. Você pode movê-la ou removê-la conforme necessário.
            this.eSTOQUETableAdapter.Fill(this.construtoraDataSet.ESTOQUE);

            this.reportViewer1.RefreshReport();
        }
    }
}
