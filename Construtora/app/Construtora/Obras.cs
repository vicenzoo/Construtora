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
    public partial class Obras : Form
    {
        string cod_obra;
        string cod_venda;
        string venda_desc;
        public Obras()
        {
            InitializeComponent();
        }

        private void Obras_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.OBRA'. Você pode movê-la ou removê-la conforme necessário.
            this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);

        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
            fillByVendaFinalizadaToolStrip.Visible = false;
            panel5.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 261)
            {
                panel1.Width = 50;
                button1.Text = "Cons";
                button3.Text = "Sel.";
                button5.Text = "Rel.";

            }
            else
            {
                panel1.Width = 261;
                button1.Text = "Consultar Obra";
                button3.Text = "Selecionar Venda";
                button5.Text = "Relatório";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel3.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
            fillByVendaFinalizadaToolStrip.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];

            if (SelectedRow.Cells[2].Value.ToString() == "O")
            {
                MessageBox.Show("Selecione Venda Finalizada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                cod_venda = SelectedRow.Cells[0].Value.ToString();
                venda_desc = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void fillByVendaFinalizadaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cUSTO_VENDATableAdapter.FillByVendaFinalizada(this.construtoraDataSet.CUSTO_VENDA);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            if (cod_venda == null)
            {
                MessageBox.Show("Selecione uma Venda já Finalizada Antes de Continuar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3_Click_1(sender, e);
            }
            else
            {
                visiblepanel();
                panel5.Visible = true;
                label4.Text = cod_venda;
                label5.Text = venda_desc;
            }
        }
    }
}
