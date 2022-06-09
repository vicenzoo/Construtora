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
    public partial class Venda : Form
    {
        string cod;
        bool newcad = false; //Variavel para Controlar Novo Cadastro (Sair Sem Salvar)
        public Venda()
        {
            InitializeComponent();
        }

        private void Venda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.VENDA_IMPOSTO'. Você pode movê-la ou removê-la conforme necessário.
            this.vENDA_IMPOSTOTableAdapter.Fill(this.construtoraDataSet.VENDA_IMPOSTO);
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);

        }
        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 261)
            {
                panel1.Width = 50;
                button1.Text = "Cons.";
                button5.Text = "Rel.";
                button7.Text = "Fin.";
                button9.Text = "Imp.";
            }
            else
            {
                panel1.Width = 261;
                button1.Text = "Consultar";
                button5.Text = "Relatório";
                button7.Text = "Editar | Finalizar";
                button9.Text = "Adicionar Imposto";
            }
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

        private void ClearForm()
        {
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            richTextBox1.Clear();
        }

        private void DEnableButtons()
        {
            maskedTextBox5.Enabled = false;
            maskedTextBox6.Enabled = false;
            maskedTextBox7.Enabled = false;
            maskedTextBox8.Enabled = false;
            richTextBox2.Enabled = false;
        }
        private void EnableButtons()
        {
            maskedTextBox5.Enabled = true;
            maskedTextBox6.Enabled = true;
            maskedTextBox7.Enabled = true;
            maskedTextBox8.Enabled = true;
            richTextBox2.Enabled = true;
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
                "INSERT INTO CUSTO_VENDA (ORCAMENTO,CUSTO_ENG,OPER_ESCRITORIO,PROJ_LUCRO,DESCRICAO) " +
                "VALUES (@ORCAMENTO,@CUSTO_ENG,@OPER_ESCRITORIO,@PROJ_LUCRO,@DESCRICAO)"
                , conn);
            try
            {

                comm.Parameters.Add("@ORCAMENTO", System.Data.SqlDbType.Money);
                comm.Parameters["@ORCAMENTO"].Value = maskedTextBox1.Text;

                comm.Parameters.Add("@CUSTO_ENG", System.Data.SqlDbType.Money);
                comm.Parameters["@CUSTO_ENG"].Value = maskedTextBox2.Text;

                comm.Parameters.Add("@OPER_ESCRITORIO", System.Data.SqlDbType.Money);
                comm.Parameters["@OPER_ESCRITORIO"].Value = maskedTextBox3.Text;

                comm.Parameters.Add("@PROJ_LUCRO", System.Data.SqlDbType.Money);
                comm.Parameters["@PROJ_LUCRO"].Value = maskedTextBox4.Text;

                comm.Parameters.Add("@DESCRICAO", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@DESCRICAO"].Value = richTextBox1.Text;


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
                this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
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
                decimal v1 = Convert.ToDecimal(SelectedRow.Cells[1].Value);
                maskedTextBox8.Text = v1.ToString("C");
                decimal v2 = Convert.ToDecimal(SelectedRow.Cells[2].Value);
                maskedTextBox7.Text = v2.ToString("C");
                decimal v3 = Convert.ToDecimal(SelectedRow.Cells[3].Value);
                maskedTextBox6.Text = v3.ToString("C");
                if (SelectedRow.Cells[4].Value.ToString() == "O")
                {
                    button8.Enabled = true;
                    EnableButtons();
                    label12.Text = "Em orçamento";

                }else
                {
                    button8.Enabled = false;
                    DEnableButtons();
                    label12.Text = "Venda Finalizada";
                }
                decimal v4 = Convert.ToDecimal(SelectedRow.Cells[5].Value);
                maskedTextBox5.Text = v3.ToString("C");
                richTextBox2.Text = SelectedRow.Cells[6].Value.ToString();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                this.vENDA_IMPOSTOTableAdapter.FillByCodVenda(this.construtoraDataSet.VENDA_IMPOSTO, Convert.ToInt32(cod));
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao tentar Buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if ((MessageBox.Show("Deseja Finalizar Orçamento ?", "Finalizar Orçamento ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes))
            {



                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                  "UPDATE CUSTO_VENDA SET STATUS_VENDA = @STATUS_VENDA " +
                  "WHERE CODCUSTOVENDA = @CODCUSTOVENDA", conn);
                try
                {
                    comm.Parameters.Add("@CODCUSTOVENDA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODCUSTOVENDA"].Value = Convert.ToInt32(cod);
                }
                catch
                {
                    MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                comm.Parameters.Add("@STATUS_VENDA", System.Data.SqlDbType.Char);
                comm.Parameters["@STATUS_VENDA"].Value = "F";


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
                    this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
                }
            }
            else { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Imposto_Venda i1 = new Imposto_Venda();
            i1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE CUSTO_VENDA SET ORCAMENTO = @ORCAMENTO,CUSTO_ENG = @CUSTO_ENG,OPER_ESCRITORIO = @OPER_ESCRITORIO,PROJ_LUCRO = @PROJ_LUCRO,DESCRICAO = @DESCRICAO " +
              "WHERE CODCUSTOVENDA = @CODCUSTOVENDA", conn);
            try
            {
                comm.Parameters.Add("@CODCUSTOVENDA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODCUSTOVENDA"].Value = Convert.ToInt32(cod);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            comm.Parameters.Add("@ORCAMENTO", System.Data.SqlDbType.Money);
            comm.Parameters["@ORCAMENTO"].Value = maskedTextBox8.Text;

            comm.Parameters.Add("@CUSTO_ENG", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_ENG"].Value = maskedTextBox7.Text;

            comm.Parameters.Add("@OPER_ESCRITORIO", System.Data.SqlDbType.Money);
            comm.Parameters["@OPER_ESCRITORIO"].Value = maskedTextBox6.Text;

            comm.Parameters.Add("@PROJ_LUCRO", System.Data.SqlDbType.Money);
            comm.Parameters["@PROJ_LUCRO"].Value = maskedTextBox5.Text;

            comm.Parameters.Add("@DESCRICAO", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@DESCRICAO"].Value = richTextBox2.Text;

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
                this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);
            }
        }
    }
}
