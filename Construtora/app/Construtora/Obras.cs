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
    public partial class Obras : Form
    {
        string cod_obra;
        string cod_obra_vist;
        string cod_venda;
        string venda_desc;
        public Obras()
        {
            InitializeComponent();
        }

        private void Obras_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.OBRA'. Você pode movê-la ou removê-la conforme necessário.
            this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);

        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void denableitens()
        {
            //Função para Deshabilitar itens (editar)
            this.maskedTextBox4.Enabled = false;
            this.maskedTextBox5.Enabled = false;
            this.maskedTextBox6.Enabled = false;
            this.dateTimePicker5.Enabled = false;
            this.dateTimePicker6.Enabled = false;
            this.dateTimePicker7.Enabled = false;
        }

        private void enableitens()
        {
            //Função para Habilitar itens (editar)
            this.maskedTextBox4.Enabled = true;
            this.maskedTextBox5.Enabled = true;
            this.maskedTextBox6.Enabled = true;
            this.dateTimePicker5.Enabled = true;
            this.dateTimePicker6.Enabled = true;
            this.dateTimePicker7.Enabled = true;
        }

        private void ClearForm()
        {
            //Função para Limpar Forms
            this.maskedTextBox1.Clear();
            this.maskedTextBox2.Clear();
            this.maskedTextBox3.Clear();
            this.dateTimePicker1.Value = DateTime.Today;
            this.dateTimePicker2.Value = DateTime.Today;
            this.dateTimePicker3.Value = DateTime.Today;
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
                button1.Text = "Consultar Obra";
                button3.Text = "Selecionar Venda";
                button5.Text = "Relatório";
                button7.Text = "Editar";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel3.Visible = true;
            this.oBRATableAdapter.FillByNaoFinalizada(this.construtoraDataSet.OBRA);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
            //fillByVendaFinalizadaToolStrip.Visible = true;
            this.cUSTO_VENDATableAdapter.FillByVendaFinalizada(this.construtoraDataSet.CUSTO_VENDA);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];

            try
            {
                cod_venda = SelectedRow.Cells[0].Value.ToString();
                venda_desc = SelectedRow.Cells[1].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            if (cod_venda == null)
            {
                MessageBox.Show("Selecione uma Venda já Finalizada Antes de Continuar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3_Click_1(sender, e);
            }
            else
            {
                visiblepanel();
                panel5.Visible = true;
                label4.Text = cod_venda;
                label5.Text = venda_desc;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
            "INSERT INTO OBRA (CODVENDA,CUSTO_ESTADIA,CUSTO_DESLOCAMENTO,CUSTO_MONTAG_EXTERNA,DATA_INICIO_MONTAG,DATA_FIM_MONTAG,DATA_FIM_OBRA) " +
            "VALUES (@CODVENDA,@CUSTO_ESTADIA,@CUSTO_DESLOCAMENTO,@CUSTO_MONTAG_EXTERNA,@DATA_INICIO_MONTAG,@DATA_FIM_MONTAG,@DATA_FIM_OBRA)"
             , conn);

                try
                {

                    comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODVENDA"].Value = label4.Text;

                    comm.Parameters.Add("@CUSTO_ESTADIA", System.Data.SqlDbType.Money);
                    comm.Parameters["@CUSTO_ESTADIA"].Value = maskedTextBox1.Text;

                    comm.Parameters.Add("@CUSTO_DESLOCAMENTO", System.Data.SqlDbType.Money);
                    comm.Parameters["@CUSTO_DESLOCAMENTO"].Value = maskedTextBox2.Text;

                    comm.Parameters.Add("@CUSTO_MONTAG_EXTERNA", System.Data.SqlDbType.Money);
                    comm.Parameters["@CUSTO_MONTAG_EXTERNA"].Value = maskedTextBox3.Text;

                    comm.Parameters.Add("@DATA_INICIO_MONTAG", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_INICIO_MONTAG"].Value = dateTimePicker1.Value;

                    comm.Parameters.Add("@DATA_FIM_MONTAG", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_FIM_MONTAG"].Value = dateTimePicker2.Value;

                    comm.Parameters.Add("@DATA_FIM_OBRA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_FIM_OBRA"].Value = dateTimePicker3.Value;


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
                    this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);
                }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel6.Visible = true;
            this.oBRATableAdapter.FillByVistoriaObra(this.construtoraDataSet.OBRA);
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];

            try
            {
                cod_obra_vist = SelectedRow.Cells[0].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Deseja Realizar Vistoria ?", "Realizar Vistoria ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {



                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                  "UPDATE OBRA SET STATUS_VISTORIA = @STATUS_VISTORIA,DATA_VISTORIA = @DATA_VISTORIA,STATUS_OBRA =@STATUS_OBRA " +
                  "WHERE CODOBRA = @CODOBRA", conn);
                try
                {
                    comm.Parameters.Add("@CODOBRA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODOBRA"].Value = Convert.ToInt32(cod_obra_vist);
                }
                catch
                {
                    MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comm.Parameters.Add("@STATUS_VISTORIA", System.Data.SqlDbType.Char);
                comm.Parameters["@STATUS_VISTORIA"].Value = "F";

                comm.Parameters.Add("@DATA_VISTORIA", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_VISTORIA"].Value = dateTimePicker4.Value;

                comm.Parameters.Add("@STATUS_OBRA", System.Data.SqlDbType.Char);
                comm.Parameters["@STATUS_OBRA"].Value = "F";


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

                    MessageBox.Show("Registro Finalizado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);
                    this.oBRATableAdapter.FillByVistoriaObra(this.construtoraDataSet.OBRA);
                    this.oBRATableAdapter.FillByNaoFinalizada(this.construtoraDataSet.OBRA);
                }
            }
            else { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel7.Visible = true;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView4.Rows[index];


            if (SelectedRow.Cells[6].Value.ToString() == "F")
            {
                label13.Text = "Realizada";
                dateTimePicker8.Text = SelectedRow.Cells[7].Value.ToString();
                denableitens();
            }
            else
            {
                label13.Text = "Não Realizada";
                dateTimePicker8.Value = DateTime.Today;
                enableitens();
            }



            try
            {
                cod_obra = SelectedRow.Cells[0].Value.ToString();
                maskedTextBox6.Text = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox5.Text = SelectedRow.Cells[2].Value.ToString();
                maskedTextBox4.Text = SelectedRow.Cells[3].Value.ToString();
                dateTimePicker7.Text = SelectedRow.Cells[4].Value.ToString();
                dateTimePicker6.Text = SelectedRow.Cells[5].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {



            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE OBRA SET CUSTO_ESTADIA = @CUSTO_ESTADIA,CUSTO_DESLOCAMENTO = @CUSTO_DESLOCAMENTO,CUSTO_MONTAG_EXTERNA = @CUSTO_MONTAG_EXTERNA,DATA_INICIO_MONTAG = @DATA_INICIO_MONTAG,DATA_FIM_MONTAG = @DATA_FIM_MONTAG,DATA_FIM_OBRA = @DATA_FIM_OBRA " +
              "WHERE CODOBRA = @CODOBRA", conn);

            comm.Parameters.Add("@CODOBRA", System.Data.SqlDbType.Int);
            comm.Parameters["@CODOBRA"].Value = Convert.ToInt32(cod_obra);

            comm.Parameters.Add("@CUSTO_ESTADIA", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_ESTADIA"].Value = maskedTextBox6.Text;

            comm.Parameters.Add("@CUSTO_DESLOCAMENTO", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_DESLOCAMENTO"].Value = maskedTextBox5.Text;

            comm.Parameters.Add("@CUSTO_MONTAG_EXTERNA", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_MONTAG_EXTERNA"].Value = maskedTextBox4.Text;

            comm.Parameters.Add("@DATA_INICIO_MONTAG", System.Data.SqlDbType.Date);
            comm.Parameters["@DATA_INICIO_MONTAG"].Value = dateTimePicker7.Value;

            comm.Parameters.Add("@DATA_FIM_MONTAG", System.Data.SqlDbType.Date);
            comm.Parameters["@DATA_FIM_MONTAG"].Value = dateTimePicker6.Value;

            comm.Parameters.Add("@DATA_FIM_OBRA", System.Data.SqlDbType.Date);
            comm.Parameters["@DATA_FIM_OBRA"].Value = dateTimePicker5.Value;


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

                MessageBox.Show("Registro Editado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.oBRATableAdapter.Fill(this.construtoraDataSet.OBRA);
            }
        }
    }
}
