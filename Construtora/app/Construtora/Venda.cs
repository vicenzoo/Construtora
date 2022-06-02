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
            // TODO: esta linha de código carrega dados na tabela 'construtoraDataSet.CUSTO_VENDA'. Você pode movê-la ou removê-la conforme necessário.
            this.cUSTO_VENDATableAdapter.Fill(this.construtoraDataSet.CUSTO_VENDA);

        }
        private void visiblepanel()
        {
            //Função para deixar Painels Não visiveis
            panel3.Visible = false;
            panel4.Visible = false;
           // panel5.Visible = false;
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
    }
}
