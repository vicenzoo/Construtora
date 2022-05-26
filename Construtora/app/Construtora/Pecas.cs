using MetroSet_UI.Forms;
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
    public partial class Pecas : Form
    {
        bool newcad = false;
        public Pecas()
        {
            InitializeComponent();
        }

        private void Pecas_Load(object sender, EventArgs e)
        {
            this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
        }

        private void visiblepanel()
        {
            panel3.Visible = false;
            panel4.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (newcad == true)
            {
                if (MessageBox.Show("Deseja Sair sem Salvar ?", "Sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    visiblepanel();
                    panel3.Visible = true;

                }
                else
                {
                }
                newcad = false;

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
            newcad = true;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
