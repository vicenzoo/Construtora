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
    public partial class FRelPecas : Form
    {
        public FRelPecas()
        {
            InitializeComponent();
        }

        private void FRelPecas_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'ConstrutoraDataSet.PECA'. Você pode movê-la ou removê-la conforme necessário.
            this.PECATableAdapter.Fill(this.ConstrutoraDataSet.PECA);

            this.reportViewer1.RefreshReport();
        }
    }
}
