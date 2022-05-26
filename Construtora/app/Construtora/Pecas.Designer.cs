namespace Construtora
{
    partial class Pecas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.construtoraDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pECABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pECATableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.PECATableAdapter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cODPECADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRICAOPECADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qUANTIDADEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALORUNIDADEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTOPRODUCAODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pECABindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 481);
            this.panel1.TabIndex = 3;
            // 
            // construtoraDataSet
            // 
            this.construtoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.construtoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // construtoraDataSetBindingSource
            // 
            this.construtoraDataSetBindingSource.DataSource = this.construtoraDataSet;
            this.construtoraDataSetBindingSource.Position = 0;
            // 
            // pECABindingSource
            // 
            this.pECABindingSource.DataMember = "PECA";
            this.pECABindingSource.DataSource = this.construtoraDataSet;
            // 
            // pECATableAdapter
            // 
            this.pECATableAdapter.ClearBeforeFill = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(261, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(720, 481);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODPECADataGridViewTextBoxColumn,
            this.dESCRICAOPECADataGridViewTextBoxColumn,
            this.qUANTIDADEDataGridViewTextBoxColumn,
            this.vALORUNIDADEDataGridViewTextBoxColumn,
            this.cUSTOPRODUCAODataGridViewTextBoxColumn,
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.pECABindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(720, 481);
            this.dataGridView1.TabIndex = 12;
            // 
            // cODPECADataGridViewTextBoxColumn
            // 
            this.cODPECADataGridViewTextBoxColumn.DataPropertyName = "CODPECA";
            this.cODPECADataGridViewTextBoxColumn.HeaderText = "CODPECA";
            this.cODPECADataGridViewTextBoxColumn.Name = "cODPECADataGridViewTextBoxColumn";
            this.cODPECADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESCRICAOPECADataGridViewTextBoxColumn
            // 
            this.dESCRICAOPECADataGridViewTextBoxColumn.DataPropertyName = "DESCRICAO_PECA";
            this.dESCRICAOPECADataGridViewTextBoxColumn.HeaderText = "DESCRICAO_PECA";
            this.dESCRICAOPECADataGridViewTextBoxColumn.Name = "dESCRICAOPECADataGridViewTextBoxColumn";
            this.dESCRICAOPECADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qUANTIDADEDataGridViewTextBoxColumn
            // 
            this.qUANTIDADEDataGridViewTextBoxColumn.DataPropertyName = "QUANTIDADE";
            this.qUANTIDADEDataGridViewTextBoxColumn.HeaderText = "QUANTIDADE";
            this.qUANTIDADEDataGridViewTextBoxColumn.Name = "qUANTIDADEDataGridViewTextBoxColumn";
            this.qUANTIDADEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALORUNIDADEDataGridViewTextBoxColumn
            // 
            this.vALORUNIDADEDataGridViewTextBoxColumn.DataPropertyName = "VALOR_UNIDADE";
            this.vALORUNIDADEDataGridViewTextBoxColumn.HeaderText = "VALOR_UNIDADE";
            this.vALORUNIDADEDataGridViewTextBoxColumn.Name = "vALORUNIDADEDataGridViewTextBoxColumn";
            this.vALORUNIDADEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTOPRODUCAODataGridViewTextBoxColumn
            // 
            this.cUSTOPRODUCAODataGridViewTextBoxColumn.DataPropertyName = "CUSTO_PRODUCAO";
            this.cUSTOPRODUCAODataGridViewTextBoxColumn.HeaderText = "CUSTO_PRODUCAO";
            this.cUSTOPRODUCAODataGridViewTextBoxColumn.Name = "cUSTOPRODUCAODataGridViewTextBoxColumn";
            this.cUSTOPRODUCAODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pROJCUSTOMAOOBRADataGridViewTextBoxColumn
            // 
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn.DataPropertyName = "PROJ_CUSTO_MAO_OBRA";
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn.HeaderText = "PROJ_CUSTO_MAO_OBRA";
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn.Name = "pROJCUSTOMAOOBRADataGridViewTextBoxColumn";
            this.pROJCUSTOMAOOBRADataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(261, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(720, 481);
            this.panel4.TabIndex = 11;
            this.panel4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 165);
            this.panel2.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 165);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(261, 21);
            this.button2.TabIndex = 14;
            this.button2.Text = "Novo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pecas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 481);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Pecas";
            this.Text = "Pecas";
            this.Load += new System.EventHandler(this.Pecas_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pECABindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource construtoraDataSetBindingSource;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource pECABindingSource;
        private ConstrutoraDataSetTableAdapters.PECATableAdapter pECATableAdapter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODPECADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRICAOPECADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qUANTIDADEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORUNIDADEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTOPRODUCAODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pROJCUSTOMAOOBRADataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}