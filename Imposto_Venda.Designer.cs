namespace Construtora
{
    partial class Imposto_Venda
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cUSTOVENDABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cODIMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPOSTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPOSTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.iMPOSTOTableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.IMPOSTOTableAdapter();
            this.cUSTO_VENDATableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.CUSTO_VENDATableAdapter();
            this.fillByVendaOrcadaToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByVendaOrcadaToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cODCUSTOVENDADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRICAODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUS_VENDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOVENDABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPOSTOBindingSource)).BeginInit();
            this.fillByVendaOrcadaToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.maskedTextBox1);
            this.panel5.Controls.Add(this.textBox2);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(575, 498);
            this.panel5.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Valor:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(77, 457);
            this.maskedTextBox1.Mask = "$ 00000.00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(156, 20);
            this.maskedTextBox1.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 431);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Venda:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Para:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODCUSTOVENDADataGridViewTextBoxColumn,
            this.dESCRICAODataGridViewTextBoxColumn,
            this.STATUS_VENDA});
            this.dataGridView1.DataSource = this.cUSTOVENDABindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(304, 71);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(251, 206);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cUSTOVENDABindingSource
            // 
            this.cUSTOVENDABindingSource.DataMember = "CUSTO_VENDA";
            this.cUSTOVENDABindingSource.DataSource = this.construtoraDataSet;
            // 
            // construtoraDataSet
            // 
            this.construtoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.construtoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 411);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Imposto:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 16;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODIMPDataGridViewTextBoxColumn,
            this.iMPOSTODataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.iMPOSTOBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(9, 71);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(252, 206);
            this.dataGridView2.TabIndex = 13;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // cODIMPDataGridViewTextBoxColumn
            // 
            this.cODIMPDataGridViewTextBoxColumn.DataPropertyName = "CODIMP";
            this.cODIMPDataGridViewTextBoxColumn.HeaderText = "Cod";
            this.cODIMPDataGridViewTextBoxColumn.Name = "cODIMPDataGridViewTextBoxColumn";
            this.cODIMPDataGridViewTextBoxColumn.ReadOnly = true;
            this.cODIMPDataGridViewTextBoxColumn.Width = 50;
            // 
            // iMPOSTODataGridViewTextBoxColumn
            // 
            this.iMPOSTODataGridViewTextBoxColumn.DataPropertyName = "IMPOSTO";
            this.iMPOSTODataGridViewTextBoxColumn.HeaderText = "Imposto";
            this.iMPOSTODataGridViewTextBoxColumn.Name = "iMPOSTODataGridViewTextBoxColumn";
            this.iMPOSTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPOSTOBindingSource
            // 
            this.iMPOSTOBindingSource.DataMember = "IMPOSTO";
            this.iMPOSTOBindingSource.DataSource = this.construtoraDataSet;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(136, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 37);
            this.label14.TabIndex = 5;
            this.label14.Text = "Imposto";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(461, 455);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Adicionar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 37);
            this.label16.TabIndex = 0;
            this.label16.Text = "Adicionar";
            // 
            // iMPOSTOTableAdapter
            // 
            this.iMPOSTOTableAdapter.ClearBeforeFill = true;
            // 
            // cUSTO_VENDATableAdapter
            // 
            this.cUSTO_VENDATableAdapter.ClearBeforeFill = true;
            // 
            // fillByVendaOrcadaToolStrip
            // 
            this.fillByVendaOrcadaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByVendaOrcadaToolStripButton});
            this.fillByVendaOrcadaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByVendaOrcadaToolStrip.Name = "fillByVendaOrcadaToolStrip";
            this.fillByVendaOrcadaToolStrip.Size = new System.Drawing.Size(575, 25);
            this.fillByVendaOrcadaToolStrip.TabIndex = 24;
            this.fillByVendaOrcadaToolStrip.Text = "fillByVendaOrcadaToolStrip";
            // 
            // fillByVendaOrcadaToolStripButton
            // 
            this.fillByVendaOrcadaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByVendaOrcadaToolStripButton.Name = "fillByVendaOrcadaToolStripButton";
            this.fillByVendaOrcadaToolStripButton.Size = new System.Drawing.Size(205, 22);
            this.fillByVendaOrcadaToolStripButton.Text = "Exibir Apenas Vendas não Finalizadas";
            this.fillByVendaOrcadaToolStripButton.Click += new System.EventHandler(this.fillByVendaOrcadaToolStripButton_Click);
            // 
            // cODCUSTOVENDADataGridViewTextBoxColumn
            // 
            this.cODCUSTOVENDADataGridViewTextBoxColumn.DataPropertyName = "CODCUSTOVENDA";
            this.cODCUSTOVENDADataGridViewTextBoxColumn.HeaderText = "Cod";
            this.cODCUSTOVENDADataGridViewTextBoxColumn.Name = "cODCUSTOVENDADataGridViewTextBoxColumn";
            this.cODCUSTOVENDADataGridViewTextBoxColumn.ReadOnly = true;
            this.cODCUSTOVENDADataGridViewTextBoxColumn.Width = 50;
            // 
            // dESCRICAODataGridViewTextBoxColumn
            // 
            this.dESCRICAODataGridViewTextBoxColumn.DataPropertyName = "DESCRICAO";
            this.dESCRICAODataGridViewTextBoxColumn.HeaderText = "Venda";
            this.dESCRICAODataGridViewTextBoxColumn.Name = "dESCRICAODataGridViewTextBoxColumn";
            this.dESCRICAODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // STATUS_VENDA
            // 
            this.STATUS_VENDA.DataPropertyName = "STATUS_VENDA";
            this.STATUS_VENDA.HeaderText = "Status";
            this.STATUS_VENDA.Name = "STATUS_VENDA";
            this.STATUS_VENDA.ReadOnly = true;
            this.STATUS_VENDA.Width = 50;
            // 
            // Imposto_Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 498);
            this.Controls.Add(this.fillByVendaOrcadaToolStrip);
            this.Controls.Add(this.panel5);
            this.Name = "Imposto_Venda";
            this.Text = "Imposto_Venda";
            this.Load += new System.EventHandler(this.Imposto_Venda_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOVENDABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPOSTOBindingSource)).EndInit();
            this.fillByVendaOrcadaToolStrip.ResumeLayout(false);
            this.fillByVendaOrcadaToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label16;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource iMPOSTOBindingSource;
        private ConstrutoraDataSetTableAdapters.IMPOSTOTableAdapter iMPOSTOTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource cUSTOVENDABindingSource;
        private ConstrutoraDataSetTableAdapters.CUSTO_VENDATableAdapter cUSTO_VENDATableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPOSTODataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ToolStrip fillByVendaOrcadaToolStrip;
        private System.Windows.Forms.ToolStripButton fillByVendaOrcadaToolStripButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODCUSTOVENDADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRICAODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUS_VENDA;
    }
}