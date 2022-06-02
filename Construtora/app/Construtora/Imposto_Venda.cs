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
    public partial class Imposto_Venda : Form
    {
        public Imposto_Venda()
        {
            InitializeComponent();
        }

        private void Imposto_Venda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.IMPOSTO'. Você pode movê-la ou removê-la conforme necessário.
            this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);

        }
    }
}
