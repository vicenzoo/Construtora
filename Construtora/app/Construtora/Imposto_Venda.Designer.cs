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
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.iMPOSTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iMPOSTOTableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.IMPOSTOTableAdapter();
            this.cODIMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iMPOSTODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPOSTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Window;
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.dataGridView2);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.button6);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(566, 483);
            this.panel5.TabIndex = 23;
            this.panel5.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 285);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Imposto:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(76, 282);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 16;
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
            this.dataGridView2.Size = new System.Drawing.Size(537, 206);
            this.dataGridView2.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(136, 6);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 37);
            this.label14.TabIndex = 5;
            this.label14.Text = "Imposto";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(452, 285);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Adicionar";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(2, 6);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 37);
            this.label16.TabIndex = 0;
            this.label16.Text = "Adicionar";
            // 
            // construtoraDataSet
            // 
            this.construtoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.construtoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iMPOSTOBindingSource
            // 
            this.iMPOSTOBindingSource.DataMember = "IMPOSTO";
            this.iMPOSTOBindingSource.DataSource = this.construtoraDataSet;
            // 
            // iMPOSTOTableAdapter
            // 
            this.iMPOSTOTableAdapter.ClearBeforeFill = true;
            // 
            // cODIMPDataGridViewTextBoxColumn
            // 
            this.cODIMPDataGridViewTextBoxColumn.DataPropertyName = "CODIMP";
            this.cODIMPDataGridViewTextBoxColumn.HeaderText = "CODIMP";
            this.cODIMPDataGridViewTextBoxColumn.Name = "cODIMPDataGridViewTextBoxColumn";
            this.cODIMPDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iMPOSTODataGridViewTextBoxColumn
            // 
            this.iMPOSTODataGridViewTextBoxColumn.DataPropertyName = "IMPOSTO";
            this.iMPOSTODataGridViewTextBoxColumn.HeaderText = "IMPOSTO";
            this.iMPOSTODataGridViewTextBoxColumn.Name = "iMPOSTODataGridViewTextBoxColumn";
            this.iMPOSTODataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Imposto_Venda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 483);
            this.Controls.Add(this.panel5);
            this.Name = "Imposto_Venda";
            this.Text = "Imposto_Venda";
            this.Load += new System.EventHandler(this.Imposto_Venda_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iMPOSTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label16;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource iMPOSTOBindingSource;
        private ConstrutoraDataSetTableAdapters.IMPOSTOTableAdapter iMPOSTOTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODIMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iMPOSTODataGridViewTextBoxColumn;
    }
}