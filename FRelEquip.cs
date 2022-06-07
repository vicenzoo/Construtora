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
    public partial class FRelEquip : Form
    {
        public FRelEquip()
        {
            InitializeComponent();
        }

        private void FRelEquip_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.EQUIPAMENTO'. Você pode movê-la ou removê-la conforme necessário.
            this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);

            this.reportViewer1.RefreshReport();
        }
    }
}
