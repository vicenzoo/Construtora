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

    public partial class Equipamento : Form
    {
        decimal valor1;
        decimal valor2;
        decimal valor3;
        string last;
        string cod;
        bool newcad = false; //Variavel para Controlar Novo Cadastro (Sair Sem Salvar)
        public Equipamento()
        {
            InitializeComponent();
        }

        private void Equipamento_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.EQUIPAMENTO'. Você pode movê-la ou removê-la conforme necessário.
            this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);

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
            this.textBox1.Clear();
            this.numericUpDown1.Value = 1;
            this.maskedTextBox1.Clear();
            this.maskedTextBox2.Clear();
            this.maskedTextBox3.Clear();
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
            //Botão Novo
            visiblepanel();
            panel4.Visible = true;
            newcad = true;
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

        private void movimentoestoque()
        {
            //Movimentação de Estoque
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            //Cadastro Movimento Entrada


                comm = new SqlCommand(
                    "INSERT INTO ESTOQUE (DATA_ENTRADA,QNT_ENTRADA,VALOR,CODEQUIP,CODVENDA,COMPLEMENTO) " +
                    "VALUES (@DATA_ENTRADA,@QNT_ENTRADA,@VALOR,@CODEQUIP,@CODVENDA,@COMPLEMENTO)"
                                   , conn);

                try
                {

                    comm.Parameters.Add("@DATA_ENTRADA", System.Data.SqlDbType.Date);
                    comm.Parameters["@DATA_ENTRADA"].Value = dateTimePicker1.Text;

                    comm.Parameters.Add("@QNT_ENTRADA", System.Data.SqlDbType.SmallInt);
                    comm.Parameters["@QNT_ENTRADA"].Value = numericUpDown1.Value;

                    comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
                    comm.Parameters["@VALOR"].Value = maskedTextBox7.Text;

                    comm.Parameters.Add("@CODEQUIP", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODEQUIP"].Value = last;

                    comm.Parameters.Add("@CODVENDA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODVENDA"].Value = comboBox3.SelectedValue;

                    comm.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar);
                    comm.Parameters["@COMPLEMENTO"].Value = textBox1.Text;


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
                }
        }

        private void selectlastinsert()
        {
            //Codigo para pegar o codigo do ultimo equipamento cadastrado
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
            "SELECT TOP 1 CODEQUIP " +
            "FROM EQUIPAMENTO ",conn);



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
                    reader = comm.ExecuteReader();
                    if (reader.Read())
                    {
                        last = reader["CODEQUIP"].ToString();
                    }
                    reader.Close();

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

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro
            newcad = false;

            if (maskedTextBox7.MaskCompleted == false)
            {
             MessageBox.Show("Insira o Valor Total!", "Erro ao Abrir a Conexão com o Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
                "INSERT INTO EQUIPAMENTO (DESCRICAO_EQUIP,QUANTIDADE,PROJ_CUSTO_MUCH,PROJ_CUSTO_FRETE,CUSTO_MAQUINAS) " +
                "VALUES (@DESCRICAO_EQUIP,@QUANTIDADE,@PROJ_CUSTO_MUCH,@PROJ_CUSTO_FRETE,@CUSTO_MAQUINAS)"
                , conn);
            try
            {


                comm.Parameters.Add("@DESCRICAO_EQUIP", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@DESCRICAO_EQUIP"].Value = textBox1.Text;

                comm.Parameters.Add("@QUANTIDADE", System.Data.SqlDbType.Int);
                comm.Parameters["@QUANTIDADE"].Value = numericUpDown1.Value;

                comm.Parameters.Add("@PROJ_CUSTO_MUCH", System.Data.SqlDbType.Money);
                comm.Parameters["@PROJ_CUSTO_MUCH"].Value = maskedTextBox1.Text;

                comm.Parameters.Add("@PROJ_CUSTO_FRETE", System.Data.SqlDbType.Money);
                comm.Parameters["@PROJ_CUSTO_FRETE"].Value = maskedTextBox2.Text;

                comm.Parameters.Add("@CUSTO_MAQUINAS", System.Data.SqlDbType.Money);
                comm.Parameters["@CUSTO_MAQUINAS"].Value = maskedTextBox2.Text;


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
                if (checkBox1.Checked)
                {
                    selectlastinsert();
                    movimentoestoque();
                }
                ClearForm();
                this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);
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
                "SELECT CODEQUIP,DESCRICAO_EQUIP,QUANTIDADE,PROJ_CUSTO_MUCH,PROJ_CUSTO_FRETE,CUSTO_MAQUINAS " +
                "FROM EQUIPAMENTO " +
                "WHERE DESCRICAO_EQUIP like '%" + textBox2.Text + "%'", conn);

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

        private void button7_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel5.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];
            try
            {
                cod = SelectedRow.Cells[0].Value.ToString();
                textBox3.Text = SelectedRow.Cells[1].Value.ToString();
                numericUpDown2.Text = SelectedRow.Cells[2].Value.ToString();
                decimal v1 = Convert.ToDecimal(SelectedRow.Cells[3].Value);
                maskedTextBox6.Text = v1.ToString("C");
                decimal v2 = Convert.ToDecimal(SelectedRow.Cells[4].Value);
                maskedTextBox5.Text = v2.ToString("C");
                decimal v3 = Convert.ToDecimal(SelectedRow.Cells[5].Value);
                maskedTextBox4.Text = v3.ToString("C");
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
              "UPDATE EQUIPAMENTO SET DESCRICAO_EQUIP = @DESCRICAO_EQUIP,QUANTIDADE = @QUANTIDADE,PROJ_CUSTO_MUCH = @PROJ_CUSTO_MUCH,PROJ_CUSTO_FRETE = @PROJ_CUSTO_FRETE,CUSTO_MAQUINAS = @CUSTO_MAQUINAS " +
              "WHERE CODEQUIP = @CODEQUIP", conn);
            try
            {
                comm.Parameters.Add("@CODEQUIP", System.Data.SqlDbType.Int);
                comm.Parameters["@CODEQUIP"].Value = Convert.ToInt32(cod);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@DESCRICAO_EQUIP", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@DESCRICAO_EQUIP"].Value = textBox3.Text;

            comm.Parameters.Add("@QUANTIDADE", System.Data.SqlDbType.SmallInt);
            comm.Parameters["@QUANTIDADE"].Value = numericUpDown2.Text;

            comm.Parameters.Add("@PROJ_CUSTO_MUCH", System.Data.SqlDbType.Money);
            comm.Parameters["@PROJ_CUSTO_MUCH"].Value = maskedTextBox6.Text;

            comm.Parameters.Add("@PROJ_CUSTO_FRETE", System.Data.SqlDbType.Money);
            comm.Parameters["@PROJ_CUSTO_FRETE"].Value = maskedTextBox5.Text;

            comm.Parameters.Add("@CUSTO_MAQUINAS", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_MAQUINAS"].Value = maskedTextBox6.Text;


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
                this.eQUIPAMENTOTableAdapter.Fill(this.construtoraDataSet.EQUIPAMENTO);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FRelEquip e1 = new FRelEquip();
            e1.Show();
        }

        private void valtotal()
        {
          //  label10.Text = Convert.ToString(valor1 + valor2 + valor3);
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
          //  string um = maskedTextBox1.Text;
          //  um =  maskedTextBox1.Text.Replace("R$", "");
          //  um = um.Replace(".", "");
          //  if (um != null)
          //  {
          //      valor1 = Convert.ToDecimal(um);
          //  }
          //  else
          //  {
          //      valor1 = 0;
         //   }
         //   valtotal();
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
        //    string dois = maskedTextBox2.Text;
        //   dois = maskedTextBox2.Text.Replace("R$", "");
        //    dois = dois.Replace(".", "");
        //   if (dois != null)
        //    {
        //        MessageBox.Show(dois);
        //        valor2 = Convert.ToDecimal(dois);
        //    }
        //    else
        //    {
        //       valor2 = 0;
        //    }
        //    valtotal();
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
           // string tres = maskedTextBox3.Text;
           // tres = maskedTextBox2.Text.Replace("R$", "");
           // tres = tres.Replace(".", "");
           /// if (tres != null)
          ///  {
          //      valor3 = Convert.ToDecimal(tres);
         //   }
         //   else
         //   {
         //       valor3 = 0;
        //    }
            valtotal();
        }
    }
}
