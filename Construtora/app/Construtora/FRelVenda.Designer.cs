namespace Construtora
{
    partial class FRelVenda
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.construtoraDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cUSTOVENDABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cUSTO_VENDATableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.CUSTO_VENDATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOVENDABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // construtoraDataSetBindingSource
            // 
            this.construtoraDataSetBindingSource.DataSource = this.construtoraDataSet;
            this.construtoraDataSetBindingSource.Position = 0;
            // 
            // construtoraDataSet
            // 
            this.construtoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.construtoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cUSTOVENDABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Construtora.Rel.RelVenda.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 1;
            // 
            // cUSTOVENDABindingSource
            // 
            this.cUSTOVENDABindingSource.DataMember = "CUSTO_VENDA";
            this.cUSTOVENDABindingSource.DataSource = this.construtoraDataSet;
            // 
            // cUSTO_VENDATableAdapter
            // 
            this.cUSTO_VENDATableAdapter.ClearBeforeFill = true;
            // 
            // FRelVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRelVenda";
            this.Text = "FRelVenda";
            this.Load += new System.EventHandler(this.FRelVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cUSTOVENDABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource construtoraDataSetBindingSource;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource cUSTOVENDABindingSource;
        private ConstrutoraDataSetTableAdapters.CUSTO_VENDATableAdapter cUSTO_VENDATableAdapter;
    }
}