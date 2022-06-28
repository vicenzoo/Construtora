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
        string cod_fin;
        string parc;
        decimal valortotal;
        decimal calc;
        public Financeiro()
        {
            InitializeComponent();
        }
        private void Financeiro_Load(object sender, EventArgs e)
        {
            this.fINANCEIROTableAdapter.FillByEmitidas(this.construtoraDataSet.FINANCEIRO);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.ENTRADA_PARCELAS'. Você pode movê-la ou removê-la conforme necessário.
            this.eNTRADA_PARCELASTableAdapter.Fill(this.construtoraDataSet.ENTRADA_PARCELAS);
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

            }
            else
            {
                panel1.Width = 261;
                button1.Text = "Consultar";
                button3.Text = "Selecionar Obra";
            }
        }

        private void clearform()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
              panel3.Visible = false;
              panel4.Visible = false;
              panel5.Visible = false;
              panel6.Visible = false;
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
            "INSERT INTO FINANCEIRO (CODOBRA,VALOR_RECEBIDO,VALOR_TOTAL,DESPESA_ADICIONAL) " +
            "VALUES (@CODOBRA,@VALOR_RECEBIDO,@VALOR_TOTAL,@DESPESA_ADICIONAL)"
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

        private void button9_Click(object sender, EventArgs e)
        {
            Imposto_Financeiro if1 = new Imposto_Financeiro();
            if1.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];
            try
            {
                cod_fin = SelectedRow.Cells[0].Value.ToString();
                label13.Text =  cod_fin;
                this.eNTRADA_PARCELASTableAdapter.FillByParcelasFeitas(this.construtoraDataSet.ENTRADA_PARCELAS, Convert.ToInt32(cod_fin));
                
                parc = SelectedRow.Cells[5].Value.ToString();

                numericUpDown1.Value = Convert.ToInt32(SelectedRow.Cells[6].Value);
                valortotal = (decimal)SelectedRow.Cells[8].Value;
                calc = valortotal / numericUpDown1.Value;

                label7.Text = calc.ToString();

                if (parc == "S")
                {
                    button13.Enabled = false;
                }
                else
                {
                    button13.Enabled = true;
                }


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel6.Visible = true;
        }
        private void numericUpDown1_Click(object sender, EventArgs e)
        {
            calc = valortotal / numericUpDown1.Value;
            label7.Text = calc.ToString();
        }


        private void insertFinanc_Parcela()
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                //Botão Confirmar Cadastro

                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                "INSERT INTO ENTRADA_PARCELAS (CODFINANC,VALOR_PARCELA,DATA_VENC,COMPLEMENTO) " +
                "VALUES (@CODFINANC,@VALOR_PARCELA,@DATA_VENC,@COMPLEMENTO)"
                 , conn);

                try
                {

                    comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(label13.Text);

                    comm.Parameters.Add("@VALOR_PARCELA", System.Data.SqlDbType.Money);
                    comm.Parameters["@VALOR_PARCELA"].Value = label7.Text;

                    dateTimePicker4.Value = dateTimePicker4.Value.AddMonths(i);
                    comm.Parameters.Add("@DATA_VENC", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_VENC"].Value = dateTimePicker4.Value;

                    comm.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar);
                    comm.Parameters["@COMPLEMENTO"].Value = richTextBox1.Text;


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
                    this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                }
            }

        }

        private void udpatefinanc()
        {


            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE FINANCEIRO SET POSSSUI_PARCELAS = @POSSSUI_PARCELAS, NUM_PARCELAS = @NUM_PARCELAS  " +
              "WHERE CODFINANC = @CODFINANC", conn);
            try
            {
                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(cod_fin);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@POSSSUI_PARCELAS", System.Data.SqlDbType.Char);
            comm.Parameters["@POSSSUI_PARCELAS"].Value = "S";

            comm.Parameters.Add("@NUM_PARCELAS", System.Data.SqlDbType.SmallInt);
            comm.Parameters["@NUM_PARCELAS"].Value = numericUpDown1.Value;


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
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 1)
            {
                try
                {
                    insertFinanc_Parcela();
                    udpatefinanc();
                    this.fINANCEIROTableAdapter.FillByEmitidas(this.construtoraDataSet.FINANCEIRO);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro ao Abrir ao Executar Comando SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Numero de Parcelas Inválido! ", "Erro ao Executar!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Central_Financeira c1 = new Central_Financeira();
            c1.Show();
        }
    }
}
