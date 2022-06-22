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
    public partial class Financeiro : Form
    {
        string cod_obra;
        public Financeiro()
        {
            InitializeComponent();
        }
        private void Financeiro_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.OBRA'. Você pode movê-la ou removê-la conforme necessário.
            this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.FINANCEIRO'. Você pode movê-la ou removê-la conforme necessário.
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);

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
                button1.Text = "Consultar";
                button3.Text = "Selecionar Obra";
                button5.Text = "Relatório";
            }
        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
              panel3.Visible = false;
              panel4.Visible = false;
              panel5.Visible = false;
           // panel6.Visible = false;
           // panel7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel3.Visible = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow SelectedRow = dataGridView1.Rows[index];


                if (SelectedRow.Cells[3].Value.ToString() == "S")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            if (cod_obra == null)
            {
                MessageBox.Show("Selecione uma Obra já Finalizada Antes de Continuar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3_Click(sender, e);
            }
            else
            {
                visiblepanel();
                panel5.Visible = true;
                label4.Text = cod_obra;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Salva CodObra Finalizada

            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView3.Rows[index];

            try
            {
                cod_obra = SelectedRow.Cells[0].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
            this.oBRATableAdapter.FillBy(this.construtoraDataSet.OBRA);
        }
    }
}
