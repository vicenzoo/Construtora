using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Construtora
{
    public partial class Estoque : Form
    {
        public Estoque()
        {
            InitializeComponent();
        }



        private void Estoque_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.EQUIPAMENTO'. Você pode movê-la ou removê-la conforme necessário.
            this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.PECA'. Você pode movê-la ou removê-la conforme necessário.
            this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.ESTOQUE'. Você pode movê-la ou removê-la conforme necessário.
            this.eSTOQUETableAdapter.Fill(this.construtoraDataSet.ESTOQUE);

        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
           // panel5.Visible = false;
        }

        private void ClearForm()
        {
            //Função para Limpar Forms
           // this.textBox1.Clear();
           // this.numericUpDown1.Value = 0;
           // this.maskedTextBox1.Clear();
           // this.maskedTextBox2.Clear();
           // this.maskedTextBox3.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
