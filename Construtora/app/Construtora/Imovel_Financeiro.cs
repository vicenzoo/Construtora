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
    public partial class Imovel_Financeiro : Form
    {
        string cod_Financ;
        public Imovel_Financeiro()
        {
            InitializeComponent();
        }

        private void Imovel_Financeiro_Load(object sender, EventArgs e)
        {
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
        }

        private void ClearForm()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
              "UPDATE FINANCEIRO SET RECEBE_IMOVEL = @RECEBE_IMOVEL  " +
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

            comm.Parameters.Add("@RECEBE_IMOVEL", System.Data.SqlDbType.Char);
            comm.Parameters["@RECEBE_IMOVEL"].Value = "S";


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
        private void insertFinanc_Imovel()
        {

            //Botão Confirmar Cadastro

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
            "INSERT INTO IMOVEL (CODFINANC,AVALIACAO,GASTOS) " +
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
                insertFinanc_Imovel();
                udpatefinanc();
                this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Executar Comando SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
