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
        decimal val2;
        decimal val3;
        string cod_Imovel;
        string cod_Veiculo;
        public Central_Financeira()
        {
            InitializeComponent();
        }

        private void Central_Financeira_Load(object sender, EventArgs e)
        {
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

                if (SelectedRow.Cells[11].Value.ToString() == "C")
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
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

                //Aba Sobre
                maskedTextBox1.Text = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox2.Text = SelectedRow.Cells[8].Value.ToString();
                maskedTextBox3.Text = SelectedRow.Cells[9].Value.ToString();
                maskedTextBox4.Text = SelectedRow.Cells[10].Value.ToString();

                
                if (SelectedRow.Cells[11].Value.ToString()  == "C" || SelectedRow.Cells[11].Value.ToString() == "P")
                {
                    button1.Enabled = false;    
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                }

                //Aba Imóvel
                this.iMOVELTableAdapter.FillByImovelFinanc(this.construtoraDataSet.IMOVEL,Convert.ToInt32(cod_fin));

                //Aba Veículo
                this.vEICULOTableAdapter.FillByVeiculoFinanc(this.construtoraDataSet.VEICULO,Convert.ToInt32(cod_fin));
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
                MessageBox.Show("Registro Alterado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            val2 = Convert.ToDecimal(maskedTextBox2.Text);
            calcLucro();
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            val3 = Convert.ToDecimal(maskedTextBox3.Text);
            calcLucro();
        }

        private void calcLucro()
        {
                maskedTextBox4.Clear();
                maskedTextBox4.Text = (val2 - val3).ToString("n");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja desfazer Lançamento Pago/Cancelado ?", "Sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                status_fin = "E";
                updatefinancstatus();
            }
        }

        /// IMOVEL

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) //Grid Imovel
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView2.Rows[index];
            try
            {
                cod_Imovel = SelectedRow.Cells[0].Value.ToString();
                maskedTextBox6.Text = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox5.Text = SelectedRow.Cells[2].Value.ToString();
                label15.Visible = false; //Mesagem alerta Selecione a row para editar \ Excluir
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void button5_Click(object sender, EventArgs e) //Editar Imovel
        {
            if (cod_Imovel == null)
            {
                MessageBox.Show("Selecione um Imóvel!", "Selecione um Imóvel!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label15.Visible = true;
                return;
            }

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE IMOVEL SET AVALIACAO = @AVALIACAO,GASTOS = @GASTOS   " +
              "WHERE CODIMOVEL = @CODIMOVEL", conn);

            comm.Parameters.Add("@CODIMOVEL", System.Data.SqlDbType.Int);
            comm.Parameters["@CODIMOVEL"].Value = Convert.ToInt32(cod_Imovel);

            comm.Parameters.Add("@AVALIACAO", System.Data.SqlDbType.Money);
            comm.Parameters["@AVALIACAO"].Value = maskedTextBox6.Text;

            comm.Parameters.Add("@GASTOS", System.Data.SqlDbType.Money);
            comm.Parameters["@GASTOS"].Value = maskedTextBox5.Text;


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
                MessageBox.Show("Registro Alterado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.iMOVELTableAdapter.Fill(this.construtoraDataSet.IMOVEL);
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e) //Excluir Imovel
        {
            if (cod_Imovel == null)
            {
                MessageBox.Show("Selecione um Imóvel!", "Selecione um Imóvel!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label15.Visible = true;
                return;
            }

            if (MessageBox.Show("Deseja EXCLUIR o Lançamento desse Imóvel ?", "Esta Ação Não Poderá ser desfeita ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                  "DELETE IMOVEL " +
                  "WHERE CODIMOVEL = @CODIMOVEL", conn);

                comm.Parameters.Add("@CODIMOVEL", System.Data.SqlDbType.Int);
                comm.Parameters["@CODIMOVEL"].Value = Convert.ToInt32(cod_Imovel);

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
                    MessageBox.Show("Registro Excluído!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.iMOVELTableAdapter.Fill(this.construtoraDataSet.IMOVEL);
                    this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                    conn.Close();
                    label15.Visible = true;
                }

            }
        }

        /// VEICULO

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) //Grid Veiculo
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView3.Rows[index];
            try
            {
                cod_Veiculo = SelectedRow.Cells[0].Value.ToString();
                maskedTextBox8.Text = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox7.Text = SelectedRow.Cells[2].Value.ToString();
                label15.Visible = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button8_Click(object sender, EventArgs e) //Editar Veiculo
        {
            if (cod_Veiculo == null)
            {
                MessageBox.Show("Selecione um Veículo!", "Selecione um Veículo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label15.Visible = true;
                return;
            }

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE VEICULO SET AVALIACAO = @AVALIACAO,GASTOS = @GASTOS   " +
              "WHERE CODVEICULO = @CODVEICULO", conn);

            comm.Parameters.Add("@CODVEICULO", System.Data.SqlDbType.Int);
            comm.Parameters["@CODVEICULO"].Value = Convert.ToInt32(cod_Veiculo);

            comm.Parameters.Add("@AVALIACAO", System.Data.SqlDbType.Money);
            comm.Parameters["@AVALIACAO"].Value = maskedTextBox8.Text;

            comm.Parameters.Add("@GASTOS", System.Data.SqlDbType.Money);
            comm.Parameters["@GASTOS"].Value = maskedTextBox7.Text;


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
                MessageBox.Show("Registro Alterado!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.vEICULOTableAdapter.Fill(this.construtoraDataSet.VEICULO);
                conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e) //Excluir Veiculo
        {
            if (cod_Veiculo == null)
            {
                MessageBox.Show("Selecione um Veículo!", "Selecione um Veículo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label15.Visible = true;
                return;
            }

            if (MessageBox.Show("Deseja EXCLUIR o Lançamento desse Veículo ?", "Esta Ação Não Poderá ser desfeita ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                  "DELETE VEICULO " +
                  "WHERE CODVEICULO = @CODVEICULO", conn);

                comm.Parameters.Add("@CODVEICULO", System.Data.SqlDbType.Int);
                comm.Parameters["@CODVEICULO"].Value = Convert.ToInt32(cod_Veiculo);

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
                    MessageBox.Show("Registro Excluído!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.vEICULOTableAdapter.Fill(this.construtoraDataSet.VEICULO);
                    this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                    conn.Close();
                    label15.Visible = true;
                }
            }

        }
    }
}
