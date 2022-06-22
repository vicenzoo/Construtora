using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Construtora
{
    public partial class Carros_Financeiro : Form
    {
        string cod_Financ;
        public Carros_Financeiro()
        {
            InitializeComponent();
        }

        private void CarrosFinanc_Enter(object sender, EventArgs e)
        {

        }

        private void Carros_Financeiro_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.FINANCEIRO'. Você pode movê-la ou removê-la conforme necessário.
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);

        }

        private void ClearForm()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Salva CodFinanc Finalizada

            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];

            try
            {
                cod_Financ = SelectedRow.Cells[0].Value.ToString();
                label1.Text = cod_Financ;
                label1.Visible = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void udpatefinanc()
        {


            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE FINANCEIRO SET RECEBE_VEICULO = @RECEBE_VEICULO  " +
              "WHERE CODFINANC = @CODFINANC", conn);
            try
            {
                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(cod_Financ);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@RECEBE_VEICULO", System.Data.SqlDbType.Char);
            comm.Parameters["@RECEBE_VEICULO"].Value = "S";


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

        private void insertFinanc_Veiculo()
        {

            //Botão Confirmar Cadastro

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
            "INSERT INTO VEICULO (CODFINANC,AVALIACAO,GASTOS) " +
            "VALUES (@CODFINANC,@AVALIACAO,@GASTOS)"
             , conn);

            try
            {

                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = label1.Text;

                comm.Parameters.Add("@AVALIACAO", System.Data.SqlDbType.Money);
                comm.Parameters["@AVALIACAO"].Value = maskedTextBox1.Text;

                comm.Parameters.Add("@GASTOS", System.Data.SqlDbType.Money);
                comm.Parameters["@GASTOS"].Value = maskedTextBox2.Text;



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
                ClearForm();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                insertFinanc_Veiculo();
                udpatefinanc();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Executar Comando SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void maskedTextBox2_CursorChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_LocationChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void maskedTextBox2_Leave(object sender, EventArgs e)
        {
            label2.Visible = true;
                decimal v1 = Convert.ToDecimal(maskedTextBox1.Text);
                decimal v2 = Convert.ToDecimal(maskedTextBox1.Text);
                label2.Text = Convert.ToString(v1 - v2);
        }
    }
}
