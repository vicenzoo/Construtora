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
    public partial class Venda : Form
    {
        public Venda()
        {
            InitializeComponent();
        }

        private void Venda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);

        }
    }
}
