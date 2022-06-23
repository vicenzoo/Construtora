using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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

        private void clearform()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            clearform();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
            "INSERT INTO FINANCEIRO (CODOBRA,VALOR_RECEBIDO,VALOR_TOTAL,DESPESA_ADICIONAL,LUCRO_TOTAL) " +
            "VALUES (@CODOBRA,@VALOR_RECEBIDO,@VALOR_TOTAL,@DESPESA_ADICIONAL,@LUCRO_TOTAL)"
             , conn);

            try
            {

                comm.Parameters.Add("@CODOBRA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODOBRA"].Value = label4.Text;

                comm.Parameters.Add("@VALOR_RECEBIDO", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR_RECEBIDO"].Value = maskedTextBox1.Text;

                comm.Parameters.Add("@VALOR_TOTAL", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR_TOTAL"].Value = maskedTextBox2.Text;

                if (maskedTextBox3.MaskCompleted == false)
                {
                    maskedTextBox3.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    maskedTextBox3.Text = "0";
                    comm.Parameters.Add("@DESPESA_ADICIONAL", System.Data.SqlDbType.Money);
                    comm.Parameters["@DESPESA_ADICIONAL"].Value = maskedTextBox3.Text;
                }
                else
                {
                    comm.Parameters.Add("@DESPESA_ADICIONAL", System.Data.SqlDbType.Money);
                    comm.Parameters["@DESPESA_ADICIONAL"].Value = maskedTextBox3.Text;
                }

                comm.Parameters.Add("@LUCRO_TOTAL", System.Data.SqlDbType.Money);
                comm.Parameters["@LUCRO_TOTAL"].Value = maskedTextBox4.Text;


            }
            catch (Exception error)
            {
                MessageBox.Show("Campo Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                try
                {
                    conn.Open();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro ao Abrir a Conexão com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro ao Abrir ao Executar Comando SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception error) { }
            finally
            {
                conn.Close();
                MessageBox.Show("Registro Cadastrado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearform();
                this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Carros_Financeiro c1 = new Carros_Financeiro();
            c1.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Imovel_Financeiro i1 = new Imovel_Financeiro();
            i1.Show();
        }
    }
}
