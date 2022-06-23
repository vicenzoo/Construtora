namespace Construtora
{
    partial class Imovel_Financeiro
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
            this.label10 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lUCROTOTALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESPESAADICIONALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALORTOTALDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUMPARCELASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECEBEIMOVELDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iNADIMPLENTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rECEBEVEICULODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vALORRECEBIDODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODFINANCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fINANCEIROBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.fINANCEIROTableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.FINANCEIROTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fINANCEIROBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 65;
            this.label10.Text = "Gastos:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(107, 455);
            this.maskedTextBox2.Mask = "$ 99990.00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(82, 20);
            this.maskedTextBox2.TabIndex = 64;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(107, 432);
            this.maskedTextBox1.Mask = "$ 99990.00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(82, 20);
            this.maskedTextBox1.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Cod";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Financeiro:";
            // 
            // lUCROTOTALDataGridViewTextBoxColumn
            // 
            this.lUCROTOTALDataGridViewTextBoxColumn.DataPropertyName = "LUCRO_TOTAL";
            this.lUCROTOTALDataGridViewTextBoxColumn.HeaderText = "Lucro Total";
            this.lUCROTOTALDataGridViewTextBoxColumn.Name = "lUCROTOTALDataGridViewTextBoxColumn";
            this.lUCROTOTALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dESPESAADICIONALDataGridViewTextBoxColumn
            // 
            this.dESPESAADICIONALDataGridViewTextBoxColumn.DataPropertyName = "DESPESA_ADICIONAL";
            this.dESPESAADICIONALDataGridViewTextBoxColumn.HeaderText = "Despesa Adicional";
            this.dESPESAADICIONALDataGridViewTextBoxColumn.Name = "dESPESAADICIONALDataGridViewTextBoxColumn";
            this.dESPESAADICIONALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALORTOTALDataGridViewTextBoxColumn
            // 
            this.vALORTOTALDataGridViewTextBoxColumn.DataPropertyName = "VALOR_TOTAL";
            this.vALORTOTALDataGridViewTextBoxColumn.HeaderText = "Valor Total";
            this.vALORTOTALDataGridViewTextBoxColumn.Name = "vALORTOTALDataGridViewTextBoxColumn";
            this.vALORTOTALDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pOSSSUIIMPOSTOSDataGridViewTextBoxColumn
            // 
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn.DataPropertyName = "POSSSUI_IMPOSTOS";
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn.HeaderText = "Possuí Impostos";
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn.Name = "pOSSSUIIMPOSTOSDataGridViewTextBoxColumn";
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nUMPARCELASDataGridViewTextBoxColumn
            // 
            this.nUMPARCELASDataGridViewTextBoxColumn.DataPropertyName = "NUM_PARCELAS";
            this.nUMPARCELASDataGridViewTextBoxColumn.HeaderText = "Num Parcelas";
            this.nUMPARCELASDataGridViewTextBoxColumn.Name = "nUMPARCELASDataGridViewTextBoxColumn";
            this.nUMPARCELASDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pOSSSUIPARCELASDataGridViewTextBoxColumn
            // 
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn.DataPropertyName = "POSSSUI_PARCELAS";
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn.HeaderText = "Possuí parcelas";
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn.Name = "pOSSSUIPARCELASDataGridViewTextBoxColumn";
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rECEBEIMOVELDataGridViewTextBoxColumn
            // 
            this.rECEBEIMOVELDataGridViewTextBoxColumn.DataPropertyName = "RECEBE_IMOVEL";
            this.rECEBEIMOVELDataGridViewTextBoxColumn.HeaderText = "Recebe Imovel";
            this.rECEBEIMOVELDataGridViewTextBoxColumn.Name = "rECEBEIMOVELDataGridViewTextBoxColumn";
            this.rECEBEIMOVELDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iNADIMPLENTEDataGridViewTextBoxColumn
            // 
            this.iNADIMPLENTEDataGridViewTextBoxColumn.DataPropertyName = "INADIMPLENTE";
            this.iNADIMPLENTEDataGridViewTextBoxColumn.HeaderText = "Inadimplente";
            this.iNADIMPLENTEDataGridViewTextBoxColumn.Name = "iNADIMPLENTEDataGridViewTextBoxColumn";
            this.iNADIMPLENTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rECEBEVEICULODataGridViewTextBoxColumn
            // 
            this.rECEBEVEICULODataGridViewTextBoxColumn.DataPropertyName = "RECEBE_VEICULO";
            this.rECEBEVEICULODataGridViewTextBoxColumn.HeaderText = "Recebe Veículo";
            this.rECEBEVEICULODataGridViewTextBoxColumn.Name = "rECEBEVEICULODataGridViewTextBoxColumn";
            this.rECEBEVEICULODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vALORRECEBIDODataGridViewTextBoxColumn
            // 
            this.vALORRECEBIDODataGridViewTextBoxColumn.DataPropertyName = "VALOR_RECEBIDO";
            this.vALORRECEBIDODataGridViewTextBoxColumn.HeaderText = "Valor Recebido";
            this.vALORRECEBIDODataGridViewTextBoxColumn.Name = "vALORRECEBIDODataGridViewTextBoxColumn";
            this.vALORRECEBIDODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cODFINANCDataGridViewTextBoxColumn
            // 
            this.cODFINANCDataGridViewTextBoxColumn.DataPropertyName = "CODFINANC";
            this.cODFINANCDataGridViewTextBoxColumn.HeaderText = "Cod";
            this.cODFINANCDataGridViewTextBoxColumn.Name = "cODFINANCDataGridViewTextBoxColumn";
            this.cODFINANCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODFINANCDataGridViewTextBoxColumn,
            this.vALORRECEBIDODataGridViewTextBoxColumn,
            this.rECEBEVEICULODataGridViewTextBoxColumn,
            this.iNADIMPLENTEDataGridViewTextBoxColumn,
            this.rECEBEIMOVELDataGridViewTextBoxColumn,
            this.pOSSSUIPARCELASDataGridViewTextBoxColumn,
            this.nUMPARCELASDataGridViewTextBoxColumn,
            this.pOSSSUIIMPOSTOSDataGridViewTextBoxColumn,
            this.vALORTOTALDataGridViewTextBoxColumn,
            this.dESPESAADICIONALDataGridViewTextBoxColumn,
            this.lUCROTOTALDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fINANCEIROBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(18, 62);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(546, 262);
            this.dataGridView1.TabIndex = 59;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // fINANCEIROBindingSource
            // 
            this.fINANCEIROBindingSource.DataMember = "FINANCEIRO";
            this.fINANCEIROBindingSource.DataSource = this.construtoraDataSet;
            // 
            // construtoraDataSet
            // 
            this.construtoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.construtoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fINANCEIROTableAdapter
            // 
            this.fINANCEIROTableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 435);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 63;
            this.label8.Text = "Avaliação:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(126, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 37);
            this.label14.TabIndex = 58;
            this.label14.Text = "Imóvel";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(470, 453);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 57;
            this.button6.Text = "Adicionar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 23);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 37);
            this.label16.TabIndex = 56;
            this.label16.Text = "Receber";
            // 
            // Imovel_Financeiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 498);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label16);
            this.Name = "Imovel_Financeiro";
            this.Text = "Imovel_Financeiro";
            this.Load += new System.EventHandler(this.Imovel_Financeiro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fINANCEIROBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUCROTOTALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESPESAADICIONALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORTOTALDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOSSSUIIMPOSTOSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nUMPARCELASDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pOSSSUIPARCELASDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECEBEIMOVELDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iNADIMPLENTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECEBEVEICULODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vALORRECEBIDODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODFINANCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fINANCEIROBindingSource;
        private ConstrutoraDataSet construtoraDataSet;
        private ConstrutoraDataSetTableAdapters.FINANCEIROTableAdapter fINANCEIROTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label16;
    }
}