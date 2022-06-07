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
using System.Data.SqlClient;

namespace Construtora
{
    public partial class Estoque : Form
    {
        bool newcad = false; //Variavel para Controlar Novo Cadastro (Sair Sem Salvar)
        string cod;
        public Estoque()
        {
            InitializeComponent();
        }

        private void Estoque_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet1.ESTOQUE'. Você pode movê-la ou removê-la conforme necessário.
            this.eSTOQUETableAdapter.Fill(this.construtoraDataSet1.ESTOQUE);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.EQUIPAMENTO'. Você pode movê-la ou removê-la conforme necessário.
            this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.PECA'. Você pode movê-la ou removê-la conforme necessário.
            this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.ESTOQUE'. Você pode movê-la ou removê-la conforme necessário.
            this.eSTOQUETableAdapter.Fill(this.construtoraDataSet.ESTOQUE);

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 261)
            {
                panel1.Width = 50;
                button1.Text = "Cons.";
                button5.Text = "Rel.";

            }
            else
            {
                panel1.Width = 261;
                button1.Text = "Consultar";
                button5.Text = "Relatório";
            }
        }

        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void ClearForm()
        {
            //Função para Limpar Forms
              this.numericUpDown1.Value = 0;
              this.numericUpDown2.Value = 0;
              this.maskedTextBox1.Clear();
              this.dateTimePicker1.Value = DateTime.Today;
              this.dateTimePicker2.Value = DateTime.Today;
              this.comboBox1.SelectedIndex = 0;
              this.comboBox2.SelectedIndex = 0;
              this.comboBox3.SelectedIndex = 0;
              this.richTextBox1.Clear();
              this.radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro
            newcad = false;

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            //Cadastro Movimento Peça
            if (radioButton1.Checked) {


                comm = new SqlCommand(
                    "INSERT INTO ESTOQUE (DATA_ENTRADA,QNT_ENTRADA,DATA_SAIDA,QNT_SAIDA,VALOR,CODPECA,CODVENDA,COMPLEMENTO) " +
                    "VALUES (@DATA_ENTRADA,@QNT_ENTRADA,@DATA_SAIDA,@QNT_SAIDA,@VALOR,@CODPECA,@CODVENDA,@COMPLEMENTO)"
                    , conn);

                try
                {

                    comm.Parameters.Add("@DATA_ENTRADA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_ENTRADA"].Value = dateTimePicker1.Text;

                    comm.Parameters.Add("@QNT_ENTRADA", System.Data.SqlDbType.SmallInt);
                    comm.Parameters["@QNT_ENTRADA"].Value = numericUpDown1.Value;

                    comm.Parameters.Add("@DATA_SAIDA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_SAIDA"].Value = dateTimePicker2.Text;

                    comm.Parameters.Add("@QNT_SAIDA", System.Data.SqlDbType.SmallInt);
                    comm.Parameters["@QNT_SAIDA"].Value = numericUpDown2.Text;

                    comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                    comm.Parameters["@VALOR"].Value = maskedTextBox1.Text;

                    comm.Parameters.Add("@CODPECA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODPECA"].Value = comboBox1.SelectedValue;

                    comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODVENDA"].Value = comboBox3.SelectedValue;

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
                    MessageBox.Show("Registro Cadastrado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    this.eSTOQUETableAdapter.Fill(this.construtoraDataSet1.ESTOQUE);
                }




            }
            else if (radioButton2.Checked) //Cadastro Movimento Equipamento
            {
                comm = new SqlCommand(
                    "INSERT INTO ESTOQUE (DATA_ENTRADA,QNT_ENTRADA,DATA_SAIDA,QNT_SAIDA,VALOR,CODEQUIP,CODVENDA,COMPLEMENTO) " +
                    "VALUES (@DATA_ENTRADA,@QNT_ENTRADA,@DATA_SAIDA,@QNT_SAIDA,@VALOR,@CODEQUIP,@CODVENDA,@COMPLEMENTO)"
                    , conn);

                try
                {

                    comm.Parameters.Add("@DATA_ENTRADA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_ENTRADA"].Value = dateTimePicker1.Text;

                    comm.Parameters.Add("@QNT_ENTRADA", System.Data.SqlDbType.SmallInt);
                    comm.Parameters["@QNT_ENTRADA"].Value = numericUpDown1.Value;

                    comm.Parameters.Add("@DATA_SAIDA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_SAIDA"].Value = dateTimePicker2.Text;

                    comm.Parameters.Add("@QNT_SAIDA", System.Data.SqlDbType.SmallInt);
                    comm.Parameters["@QNT_SAIDA"].Value = numericUpDown2.Text;

                    comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                    comm.Parameters["@VALOR"].Value = maskedTextBox1.Text;

                    comm.Parameters.Add("@CODEQUIP", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODEQUIP"].Value = comboBox2.SelectedValue;

                    comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODVENDA"].Value = comboBox3.SelectedValue;

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
                    MessageBox.Show("Registro Cadastrado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    this.eSTOQUETableAdapter.Fill(this.construtoraDataSet1.ESTOQUE);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
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
                "SELECT CODESTOQUE,DATA_REGISTRO,DATA_ENTRADA,QNT_ENTRADA,DATA_SAIDA,QNT_SAIDA,VALOR,COMPLEMENTO,CODEQUIP,CODPECA,CODVENDA " +
                "FROM ESTOQUE " +
                "WHERE COMPLEMENTO like '%" + richTextBox2.Text + "%'", conn);

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
                dateTimePicker4.Text = SelectedRow.Cells[2].Value.ToString();
                numericUpDown4.Text = SelectedRow.Cells[3].Value.ToString();
                dateTimePicker3.Text = SelectedRow.Cells[4].Value.ToString();
                numericUpDown3.Text = SelectedRow.Cells[5].Value.ToString();
                decimal v1 = Convert.ToDecimal(SelectedRow.Cells[6].Value);
                maskedTextBox2.Text = v1.ToString("C");
                richTextBox2.Text = SelectedRow.Cells[7].Value.ToString();
                if (SelectedRow.Cells[8].Value.ToString() == "")
                {
                    comboBox5.Enabled = false;
                    comboBox5.SelectedIndex = -1;
                }
                else
                {
                    comboBox5.Enabled = true;
                    comboBox5.SelectedValue = SelectedRow.Cells[8].Value.ToString();
                }
                if (SelectedRow.Cells[9].Value.ToString() == "")
                {
                    comboBox6.Enabled = false;
                    comboBox6.SelectedIndex = -1;
                }
                else
                {
                    comboBox6.Enabled = true;
                    comboBox6.SelectedValue = SelectedRow.Cells[9].Value.ToString();
                }
                comboBox4.SelectedValue = SelectedRow.Cells[10].Value.ToString();



            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel5.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            if (comboBox5.Enabled == true) //Equipamento
            {

                comm = new SqlCommand(
              "UPDATE ESTOQUE SET DATA_ENTRADA = @DATA_ENTRADA,QNT_ENTRADA = @QNT_ENTRADA,DATA_SAIDA = @DATA_SAIDA,QNT_SAIDA = @QNT_SAIDA,VALOR = @VALOR,COMPLEMENTO = @COMPLEMENTO,CODEQUIP = @CODEQUIP,CODVENDA = @CODVENDA " +
              "WHERE CODESTOQUE = @CODESTOQUE", conn);
                try
                {
                    comm.Parameters.Add("@CODESTOQUE", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODESTOQUE"].Value = Convert.ToInt32(cod);
                }
                catch
                {
                    MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comm.Parameters.Add("@DATA_ENTRADA", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_ENTRADA"].Value = dateTimePicker4.Text;

                comm.Parameters.Add("@QNT_ENTRADA", System.Data.SqlDbType.SmallInt);
                comm.Parameters["@QNT_ENTRADA"].Value = numericUpDown4.Value;

                comm.Parameters.Add("@DATA_SAIDA", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_SAIDA"].Value = dateTimePicker3.Text;

                comm.Parameters.Add("@QNT_SAIDA", System.Data.SqlDbType.SmallInt);
                comm.Parameters["@QNT_SAIDA"].Value = numericUpDown3.Text;

                comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR"].Value = maskedTextBox2.Text;

                comm.Parameters.Add("@CODEQUIP", System.Data.SqlDbType.Int);
                comm.Parameters["@CODEQUIP"].Value = comboBox5.SelectedValue;

                comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODVENDA"].Value = comboBox4.SelectedValue;

                comm.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@COMPLEMENTO"].Value = richTextBox2.Text;


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
                    this.eSTOQUETableAdapter.Fill(this.construtoraDataSet1.ESTOQUE);



                }
            }
            if (comboBox6.Enabled == true) //Peça
            {
                comm = new SqlCommand(
                "UPDATE ESTOQUE SET DATA_ENTRADA = @DATA_ENTRADA,QNT_ENTRADA = @QNT_ENTRADA,DATA_SAIDA = @DATA_SAIDA,QNT_SAIDA = @QNT_SAIDA,VALOR = @VALOR,COMPLEMENTO = @COMPLEMENTO,CODPECA = @CODPECA,CODVENDA = @CODVENDA " +
                "WHERE CODESTOQUE = @CODESTOQUE", conn);
                try
                {
                    comm.Parameters.Add("@CODESTOQUE", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODESTOQUE"].Value = Convert.ToInt32(cod);
                }
                catch
                {
                    MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comm.Parameters.Add("@DATA_ENTRADA", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_ENTRADA"].Value = dateTimePicker4.Text;

                comm.Parameters.Add("@QNT_ENTRADA", System.Data.SqlDbType.SmallInt);
                comm.Parameters["@QNT_ENTRADA"].Value = numericUpDown4.Value;

                comm.Parameters.Add("@DATA_SAIDA", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_SAIDA"].Value = dateTimePicker3.Text;

                comm.Parameters.Add("@QNT_SAIDA", System.Data.SqlDbType.SmallInt);
                comm.Parameters["@QNT_SAIDA"].Value = numericUpDown3.Text;

                comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR"].Value = maskedTextBox2.Text;

                comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODVENDA"].Value = comboBox4.SelectedValue;

                comm.Parameters.Add("@CODPECA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODPECA"].Value = comboBox6.SelectedValue;

                comm.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@COMPLEMENTO"].Value = richTextBox2.Text;


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
                    this.eSTOQUETableAdapter.Fill(this.construtoraDataSet1.ESTOQUE);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRelEstoque est1 = new FRelEstoque();
            est1.Show();
        }
    }
}
