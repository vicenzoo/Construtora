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
    public partial class Imposto : Form
    {
        string cod;
        bool newcad = false; //Variavel para Controlar Novo Cadastro (Sair Sem Salvar)
        public Imposto()
        {
            InitializeComponent();
        }

        private void Imposto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.IMPOSTO'. Você pode movê-la ou removê-la conforme necessário.
            this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);

        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botão Consulta
            if (newcad == true)
            {
                if (MessageBox.Show("Deseja Sair sem Salvar ?", "Sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    visiblepanel();
                    panel3.Visible = true;

                }
                else { }
                newcad = false;

            }
            else
            {
                visiblepanel();
                panel3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
            newcad = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel5.Visible = true;
        }

        private void ClearForm()
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro
            newcad = false;

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
                "INSERT INTO IMPOSTO (IMPOSTO) " +
                "VALUES (@IMPOSTO)"
                , conn);
            try
            {


                comm.Parameters.Add("@IMPOSTO", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@IMPOSTO"].Value = textBox1.Text;


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


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlDataAdapter adapter;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                adapter = new SqlDataAdapter(
                "SELECT CODIMP,IMPOSTO " +
                "FROM IMPOSTO " +
                "WHERE IMPOSTO like '%" + textBox2.Text + "%'", conn);

                DataSet table = new DataSet();
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                adapter.Fill(table);
                dataGridView2.DataSource = table.Tables[0];


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir a Conexão com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];
            try
            {
                cod = SelectedRow.Cells[0].Value.ToString();
                textBox3.Text = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE IMPOSTO SET IMPOSTO = @IMPOSTO " +
              "WHERE CODIMP = @CODIMP", conn);

            comm.Parameters.Add("@CODIMP", System.Data.SqlDbType.Int);
            comm.Parameters["@CODIMP"].Value = Convert.ToInt32(cod);


            comm.Parameters.Add("@IMPOSTO", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@IMPOSTO"].Value = textBox3.Text;


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

                MessageBox.Show("Registro Alterado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.iMPOSTOTableAdapter.Fill(this.construtoraDataSet.IMPOSTO);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 261)
            {
                panel1.Width = 50;
                button1.Text = "Cons.";

            }
            else
            {
                panel1.Width = 261;
                button1.Text = "Consultar";
            }
        }


    }
}
