﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Construtora
{
    public partial class Pecas : Form
    {
        bool newcad = false; //Variavel para Controlar Novo Cadastro (Sair Sem Salvar)
        string cod;
        public Pecas()
        {
            InitializeComponent();
        }

        private void Pecas_Load(object sender, EventArgs e)
        {
            this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
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
            this.numericUpDown1.Value = 0;
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

        private void button3_Click(object sender, EventArgs e)
        {
            //Botão Confirmar Cadastro
            newcad = false;

            SqlConnection conn;
            SqlCommand comm;

            string connectionString = Properties.Settings.Default.ConstrutoraConnectionString;
            conn = new SqlConnection(connectionString);

            comm = new SqlCommand(
                "INSERT INTO PECA (DESCRICAO_PECA,QUANTIDADE,VALOR_UNIDADE,CUSTO_PRODUCAO,PROJ_CUSTO_MAO_OBRA) " +
                "VALUES (@DESCRICAO_PECA,@QUANTIDADE,@VALOR_UNIDADE,@CUSTO_PRODUCAO,@PROJ_CUSTO_MAO_OBRA)"
                ,conn);
            try
            {


                comm.Parameters.Add("@DESCRICAO_PECA", System.Data.SqlDbType.NVarChar);
                comm.Parameters["@DESCRICAO_PECA"].Value = textBox1.Text;

                comm.Parameters.Add("@QUANTIDADE", System.Data.SqlDbType.Int);
                comm.Parameters["@QUANTIDADE"].Value = numericUpDown1.Value;

                comm.Parameters.Add("@VALOR_UNIDADE", System.Data.SqlDbType.Money);
                comm.Parameters["@VALOR_UNIDADE"].Value = maskedTextBox1.Text;

                comm.Parameters.Add("@CUSTO_PRODUCAO", System.Data.SqlDbType.Money);
                comm.Parameters["@CUSTO_PRODUCAO"].Value = maskedTextBox2.Text;

                comm.Parameters.Add("@PROJ_CUSTO_MAO_OBRA", System.Data.SqlDbType.Money);
                comm.Parameters["@PROJ_CUSTO_MAO_OBRA"].Value = maskedTextBox2.Text;


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
                this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            visiblepanel();
            panel5.Visible = true;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
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
        private void Button4_Click(object sender, EventArgs e)
        {
            //Botão Limpar Form
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
                "SELECT CODPECA,DESCRICAO_PECA,QUANTIDADE,VALOR_UNIDADE,CUSTO_PRODUCAO,PROJ_CUSTO_MAO_OBRA " +
                "FROM PECA " +
                "WHERE DESCRICAO_PECA like '%" + textBox2.Text + "%'", conn);

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

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {

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
              "UPDATE PECA SET DESCRICAO_PECA = @DESCRICAO_PECA,QUANTIDADE = @QUANTIDADE,VALOR_UNIDADE = @VALOR_UNIDADE,CUSTO_PRODUCAO = @CUSTO_PRODUCAO,PROJ_CUSTO_MAO_OBRA = @PROJ_CUSTO_MAO_OBRA " +
              "WHERE CODPECA = @CODPECA", conn);
            try
            {
                comm.Parameters.Add("@CODPECA", System.Data.SqlDbType.Int);
                comm.Parameters["@CODPECA"].Value = Convert.ToInt32(cod);
            }
            catch
            {
                MessageBox.Show("Codigo Inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            comm.Parameters.Add("@DESCRICAO_PECA", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@DESCRICAO_PECA"].Value = textBox3.Text;

            comm.Parameters.Add("@QUANTIDADE", System.Data.SqlDbType.SmallInt);
            comm.Parameters["@QUANTIDADE"].Value = numericUpDown2.Text;

            comm.Parameters.Add("@VALOR_UNIDADE", System.Data.SqlDbType.Money);
            comm.Parameters["@VALOR_UNIDADE"].Value = maskedTextBox6.Text;

            comm.Parameters.Add("@CUSTO_PRODUCAO", System.Data.SqlDbType.Money);
            comm.Parameters["@CUSTO_PRODUCAO"].Value = maskedTextBox5.Text;

            comm.Parameters.Add("@PROJ_CUSTO_MAO_OBRA", System.Data.SqlDbType.Money);
            comm.Parameters["@PROJ_CUSTO_MAO_OBRA"].Value = maskedTextBox6.Text;


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
                this.pECATableAdapter.Fill(this.construtoraDataSet.PECA);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FRelPecas r1 = new FRelPecas();
            r1.Show();
        }
    }
}
