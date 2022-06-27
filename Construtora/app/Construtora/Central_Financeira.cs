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
    public partial class Central_Financeira : Form
    {
        string cod_fin;
        string status_pag;
        string status_fin;
        public Central_Financeira()
        {
            InitializeComponent();
        }

        private void Central_Financeira_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.FINANCEIRO'. Você pode movê-la ou removê-la conforme necessário.
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow SelectedRow = dataGridView1.Rows[index];


                if (SelectedRow.Cells[3].Value.ToString() == "S")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                }

                if (SelectedRow.Cells[11].Value.ToString() == "P")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
                }

            }
            catch (Exception)
            {

            }
        }

        private void ComboStatus()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    status_pag = "E";
                break;
                case 1:
                    status_pag = "C";
                break;
                case 2:
                    status_pag = "P";
                break;

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboStatus();
            this.fINANCEIROTableAdapter.FillByFiltroFinanceiro(this.construtoraDataSet.FINANCEIRO, status_pag);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            try
            {
                cod_fin = SelectedRow.Cells[0].Value.ToString();
                maskedTextBox1.Text = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox2.Text = SelectedRow.Cells[8].Value.ToString();
                maskedTextBox3.Text = SelectedRow.Cells[9].Value.ToString();
                maskedTextBox4.Text = SelectedRow.Cells[10].Value.ToString();


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updatefinancstatus()
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE FINANCEIRO SET STATUS_PAGAMENTO = @STATUS_PAGAMENTO " +
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

            comm.Parameters.Add("@STATUS_PAGAMENTO", System.Data.SqlDbType.Char);
            comm.Parameters["@STATUS_PAGAMENTO"].Value = status_fin;


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
                MessageBox.Show("Status Alterado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                conn.Close();
            }
        }

        private void updatefinanc()
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE FINANCEIRO SET VALOR_RECEBIDO = @VALOR_RECEBIDO,VALOR_TOTAL = @VALOR_TOTAL,DESPESA_ADICIONAL = @DESPESA_ADICIONAL,LUCRO_TOTAL = @LUCRO_TOTAL  " +
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
            comm.Parameters.Add("@VALOR_RECEBIDO", System.Data.SqlDbType.Money);
            comm.Parameters["@VALOR_RECEBIDO"].Value = maskedTextBox1.Text;

            comm.Parameters.Add("@VALOR_TOTAL", System.Data.SqlDbType.Money);
            comm.Parameters["@VALOR_TOTAL"].Value = maskedTextBox2.Text;

            comm.Parameters.Add("@DESPESA_ADICIONAL", System.Data.SqlDbType.Money);
            comm.Parameters["@DESPESA_ADICIONAL"].Value = maskedTextBox3.Text;

            comm.Parameters.Add("@LUCRO_TOTAL", System.Data.SqlDbType.Money);
            comm.Parameters["@LUCRO_TOTAL"].Value = maskedTextBox4.Text;



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
                //MessageBox.Show("Status Alterado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status_fin = "P";
            updatefinancstatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            status_fin = "C";
            updatefinancstatus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatefinanc();
        }

    }
}
