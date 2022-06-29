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
        string cod_fin; //Armazena cod Mov Financeiro Selecionado no datagrid Principal
        string status_pag; //Armazena Filtro Datagrid Principal Movimento Financeiro
        string status_fin; //Variavel para mudar o Status do Movimento (Emitido,Cancelado,Pago)
        decimal val2; //Armazena valor total para Calculo do Lucro total
        decimal val3; //Armazena Despesa Adicional para Calculo do Lucro total
        string cod_Imovel;  //Armazena cod Imovel Selecionado no datagrid2
        string cod_Veiculo; //Armazena cod Veiculo Selecionado no datagrid3
        string cod_Imposto; //Armazena cod Imposto Selecionado no datagrid4
        string indeximposto; // Salva index imposto para combobox2 (edição imposto)
        string cod_Parcela; //Armazena cod Parcela Selecionado no datagrid5
        string status_Par; //Variavel para mudar o Status do Movimento (Emitido,Cancelado,Pago)
        string num_Par;  //Variavel armazena o num de Parcelas
        decimal calcparc; // Divide Valor total no Valor das Parcelas
        public Central_Financeira()
        {
            InitializeComponent();
        }

        private void Central_Financeira_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.ENTRADA_PARCELAS'. Você pode movê-la ou removê-la conforme necessário.
            //this.eNTRADA_PARCELASTableAdapter.Fill(this.construtoraDataSet.ENTRADA_PARCELAS);
            this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        // Formata Datagrid Pinta as Celulas dependendo do Status do Lançamento
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
        //Função Filtro Datagrid Principal Movimento
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


                if (SelectedRow.Cells[11].Value.ToString() == "C" || SelectedRow.Cells[11].Value.ToString() == "P")
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
                this.iMOVELTableAdapter.FillByImovelFinanc(this.construtoraDataSet.IMOVEL, Convert.ToInt32(cod_fin));

                //Aba Veículo
                this.vEICULOTableAdapter.FillByVeiculoFinanc(this.construtoraDataSet.VEICULO, Convert.ToInt32(cod_fin));

                //Aba Imposto
                this.fINANCEIRO_IMPOSTOTableAdapter.FillByIMPFINANCEIRO(this.construtoraDataSet.FINANCEIRO_IMPOSTO, Convert.ToInt32(cod_fin));

                //Aba Parcelas
                this.eNTRADA_PARCELASTableAdapter.FillByParcelasFinanc(this.construtoraDataSet.ENTRADA_PARCELAS, Convert.ToInt32(cod_fin));
                num_Par = SelectedRow.Cells[6].Value.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updatefinancstatus()
        //Altera Status do Lançamento Financeiro Principal
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
        //Atualiza Dados (Aba Sobre)
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
        //Pagar Lançamento Movimento Financeiro
        {
            status_fin = "P";
            updatefinancstatus();
        }

        private void button2_Click(object sender, EventArgs e)
        //Cancelar Lançamento Movimento Financeiro 
        {
            status_fin = "C";
            updatefinancstatus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updatefinanc(); //Chama função para Atualizar (Aba Sobre)
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            val2 = Convert.ToDecimal(maskedTextBox2.Text); //Valor Total
            calcLucro();
        }

        private void maskedTextBox3_TextChanged(object sender, EventArgs e)
        {
            val3 = Convert.ToDecimal(maskedTextBox3.Text); //Despesa Adicional
            calcLucro();
        }

        private void calcLucro()
        //Função para calcular Lucro total
        {
            maskedTextBox4.Clear();
            maskedTextBox4.Text = (val2 - val3).ToString("n");
        }

        private void button4_Click(object sender, EventArgs e)
        //Botão Desfazer Movimento Financeiro
        {
            if (MessageBox.Show("Deseja desfazer Lançamento Pago/Cancelado ?", "Sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                status_fin = "E";
                updatefinancstatus();
            }
        }

        /// IMOVEL

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        //Grid Imovel
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

        private void button6_Click(object sender, EventArgs e)
        //Excluir Imovel
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        //Grid Veiculo
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

        private void button8_Click(object sender, EventArgs e)
        //Editar Veiculo
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

        private void button7_Click(object sender, EventArgs e)
        //Excluir Veiculo
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

        /// IMPOSTO

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        //GRID IMPOSTO
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView4.Rows[index];
            try
            {
                cod_Imposto = SelectedRow.Cells[0].Value.ToString();
                indeximposto = SelectedRow.Cells[1].Value.ToString();
                maskedTextBox9.Text = SelectedRow.Cells[3].Value.ToString();
                label26.Visible = false;

                this.iMPOSTOTableAdapter.FillByPreencheComboImposto(this.construtoraDataSet.IMPOSTO, Convert.ToInt32(indeximposto));

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        //Editar Imposto
        {
            if (cod_Imposto == null)
            {
                MessageBox.Show("Selecione um Imposto!", "Selecione um Imposto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label26.Visible = true;
                return;
            }

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE FINANCEIRO_IMPOSTO SET CODIMP = @CODIMP,VALOR = @VALOR   " +
              "WHERE CODIMP_FINANC = @CODIMP_FINANC", conn);

            comm.Parameters.Add("@CODIMP_FINANC", System.Data.SqlDbType.Int);
            comm.Parameters["@CODIMP_FINANC"].Value = Convert.ToInt32(cod_Imposto);

            comm.Parameters.Add("@CODIMP", System.Data.SqlDbType.Int);
            comm.Parameters["@CODIMP"].Value = comboBox2.SelectedValue;

            comm.Parameters.Add("@VALOR", System.Data.SqlDbType.Money);
            comm.Parameters["@VALOR"].Value = maskedTextBox9.Text;

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
                this.fINANCEIRO_IMPOSTOTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO_IMPOSTO);
                conn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        //Excluir Imposto
        {
            if (cod_Imposto == null)
            {
                MessageBox.Show("Selecione um Imposto!", "Selecione um Imposto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label15.Visible = true;
                return;
            }

            if (MessageBox.Show("Deseja EXCLUIR o Lançamento desse Imposto ?", "Esta Ação Não Poderá ser desfeita ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn;
                SqlCommand comm;

                string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
                conn = new SqlConnection(connectionString);

                comm = new SqlCommand(
                  "DELETE FINANCEIRO_IMPOSTO " +
                  "WHERE CODIMP_FINANC = @CODIMP_FINANC", conn);

                comm.Parameters.Add("@CODIMP_FINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODIMP_FINANC"].Value = Convert.ToInt32(cod_Imposto);

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
                    this.fINANCEIRO_IMPOSTOTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO_IMPOSTO);
                    this.fINANCEIROTableAdapter.Fill(this.construtoraDataSet.FINANCEIRO);
                    conn.Close();
                    label15.Visible = true;
                }
            }

        }


        //PARCELAS


        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        //GRID PARCELA
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView5.Rows[index];
            try
            {
                cod_Parcela = SelectedRow.Cells[0].Value.ToString();
                maskedTextBox10.Text = SelectedRow.Cells[1].Value.ToString();
                dateTimePicker4.Value = Convert.ToDateTime(SelectedRow.Cells[2].Value);
                richTextBox1.Text = SelectedRow.Cells[4].Value.ToString();
                label30.Text = (num_Par);


                label33.Visible = false;

                if (SelectedRow.Cells[4].Value.ToString() == "C" || SelectedRow.Cells[4].Value.ToString() == "P")
                {
                    button14.Enabled = false;
                    button12.Enabled = false;
                    button13.Enabled = false;
                    button11.Enabled = true;
                }
                else
                {
                    button14.Enabled = true;
                    button12.Enabled = true;
                    button13.Enabled = true;
                    button11.Enabled = false;
                }


            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Erro ao Abrir ao Buscar no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateParcelastatus()
        //Altera Status do Lançamento Parcela
        {
            if (cod_Parcela == null)
            {
                MessageBox.Show("Selecione um Imposto!", "Selecione um Imposto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label33.Visible = true;
                return;
            }


            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
              "UPDATE ENTRADA_PARCELAS SET STATUS_PARCELA = @STATUS_PARCELA " +
              "WHERE CODPARCELA = @CODPARCELA", conn);
            try
            {
                comm.Parameters.Add("@CODPARCELA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODPARCELA"].Value = Convert.ToInt32(cod_Parcela);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@STATUS_PARCELA", System.Data.SqlDbType.Char);
            comm.Parameters["@STATUS_PARCELA"].Value = status_Par;


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
                this.eNTRADA_PARCELASTableAdapter.Fill(this.construtoraDataSet.ENTRADA_PARCELAS);
                conn.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        //Botão Desfazer Parcela
        {
            if (MessageBox.Show("Deseja desfazer Lançamento Pago/Cancelado ?", "Sair ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                status_Par = "E";
                updateParcelastatus();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        //Cancelar Lançamento Movimento Financeiro 
        {
            status_Par = "C";
            updateParcelastatus();
        }

        private void button14_Click(object sender, EventArgs e)
        //Pagar Lançamento Movimento Financeiro
        {
            status_Par = "P";
            updateParcelastatus();
        }

        private void updateParc()
        //Altera Lançamento Parcela
        {

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);


            if (cod_Parcela == null)
            {
                MessageBox.Show("Selecione um Imposto!", "Selecione um Imposto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label33.Visible = true;
                return;
            }

                comm = new SqlCommand(
                  "UPDATE ENTRADA_PARCELAS SET CODFINANC = @CODFINANC,DATA_VENC = @DATA_VENC,COMPLEMENTO = @COMPLEMENTO  " +
                  "WHERE CODPARCELA = @CODPARCELA", conn);
                try
                {
                    comm.Parameters.Add("@CODPARCELA", System.Data.SqlDbType.Int);
                    comm.Parameters["@CODPARCELA"].Value = Convert.ToInt32(cod_Parcela);
                }
                catch
                {
                    MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                comm.Parameters.Add("@CODFINANC", System.Data.SqlDbType.Int);
                comm.Parameters["@CODFINANC"].Value = Convert.ToInt32(cod_fin);

                comm.Parameters.Add("@VALOR_PARCELA", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR_PARCELA"].Value = maskedTextBox10.Text;

                comm.Parameters.Add("@DATA_VENC", System.Data.SqlDbType.Date);
                comm.Parameters["@DATA_VENC"].Value = dateTimePicker4.Value;

                comm.Parameters.Add("@COMPLEMENTO", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@COMPLEMENTO"].Value = richTextBox1.Text;

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
                    this.eNTRADA_PARCELASTableAdapter.Fill(this.construtoraDataSet.ENTRADA_PARCELAS);
                    conn.Close();
                }
            }

        private void button12_Click(object sender, EventArgs e)
        //Botão Editar Parcela
        {
                try
                {
                    updateParc(); //Chama Função
                    this.fINANCEIROTableAdapter.FillByEmitidas(this.construtoraDataSet.FINANCEIRO);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Erro ao Abrir ao Executar Comando SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
        }


        private void dataGridView5_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow SelectedRow = dataGridView5.Rows[index];


            if (Convert.ToDateTime(SelectedRow.Cells[2].Value) < DateTime.Now)
            {
                dataGridView5.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }

            if (SelectedRow.Cells[3].Value.ToString() == "P")
            {
                dataGridView5.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LimeGreen;
            }

            if (SelectedRow.Cells[3].Value.ToString() == "C")
            {
                dataGridView5.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }
    }
}
