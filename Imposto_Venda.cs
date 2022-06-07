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
    public partial class Imposto_Venda : Form
    {
        string Cod_imp;
        string Cod_vend;
        public Imposto_Venda()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            maskedTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Imposto_Venda_Load(object sender, EventArgs e)
        {
            fillByVendaOrcadaToolStripButton_Click(sender , e);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.IMPOSTO'. Você pode movê-la ou removê-la conforme necessário.
            this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView1.Rows[index];
            try
            {
                Cod_vend = SelectedRow.Cells[0].Value.ToString();
                textBox2.Text = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void fillByVendaOrcadaToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.cUSTO_VENDATableAdapter.FillByVendaOrcada(this.construtoraDataSet.CUSTO_VENDA);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
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
                "INSERT INTO VENDA_IMPOSTO (CODVENDA,CODIMP,VALOR_SIMULACAO) " +
                "VALUES (@CODVENDA,@CODIMP,@VALOR_SIMULACAO)"
                , conn);
            try
            {

                comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODVENDA"].Value = Convert.ToInt32(Cod_vend);

                comm.Parameters.Add("@CODIMP", System.Data.SqlDbType.Int);
                comm.Parameters["@CODIMP"].Value = Convert.ToInt32(Cod_imp);

                comm.Parameters.Add("@VALOR_SIMULACAO", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR_SIMULACAO"].Value = maskedTextBox1.Text;

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
                this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);
            }
        }
    }
}
