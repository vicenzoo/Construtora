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
    public partial class Imposto_Financeiro : Form
    {
        string Cod_imp;
        string Cod_fin;
        public Imposto_Financeiro()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            maskedTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Imposto_Financeiro_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.FINANCEIRO'. Você pode movê-la ou removê-la conforme necessário.
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.IMPOSTO'. Você pode movê-la ou removê-la conforme necessário.
            this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];
            try
            {
                Cod_imp = SelectedRow.Cells[0].Value.ToString();
                textBox1.Text = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            try
            {
                Cod_fin = SelectedRow.Cells[0].Value.ToString();
                textBox2.Text = Cod_fin;
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
              "UPDATE FINANCEIRO SET POSSSUI_IMPOSTOS = @POSSSUI_IMPOSTOS  " +
              "WHERE CODFINANC = @CODFINANC", conn);
            try
            {
                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(Cod_fin);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@POSSSUI_IMPOSTOS", System.Data.SqlDbType.Char);
            comm.Parameters["@POSSSUI_IMPOSTOS"].Value = "S";


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

        private void button6_Click(object sender, EventArgs e)
        {

            //Botão Adicionar Imposto
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
                "INSERT INTO FINANCEIRO_IMPOSTO (CODFINANC,CODIMP,VALOR) " +
                "VALUES (@CODFINANC,@CODIMP,@VALOR)"
                , conn);
            try
            {

                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(Cod_fin);

                comm.Parameters.Add("@CODIMP", System.Data.SqlDbType.Int);
                comm.Parameters["@CODIMP"].Value = Convert.ToInt32(Cod_imp);

                comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR"].Value = maskedTextBox1.Text;

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
                udpatefinanc();
                ClearForm();
                this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
            }
        }
    }
}
