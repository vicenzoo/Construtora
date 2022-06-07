namespace Construtora
{
    partial class FRelEstoque
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.construtoraDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSTOQUEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eSTOQUETableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.ESTOQUETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTOQUEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.eSTOQUEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Construtora.Rel.RelEstoque.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(897, 476);
            this.reportViewer1.TabIndex = 0;
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
            // eSTOQUEBindingSource
            // 
            this.eSTOQUEBindingSource.DataMember = "ESTOQUE";
            this.eSTOQUEBindingSource.DataSource = this.construtoraDataSet;
            // 
            // eSTOQUETableAdapter
            // 
            this.eSTOQUETableAdapter.ClearBeforeFill = true;
            // 
            // FRelEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 476);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRelEstoque";
            this.Text = "FRelEstoque";
            this.Load += new System.EventHandler(this.FRelEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eSTOQUEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource construtoraDataSetBindingSource;
        private System.Windows.Forms.BindingSource eSTOQUEBindingSource;
        private ConstrutoraDataSetTableAdapters.ESTOQUETableAdapter eSTOQUETableAdapter;
    }
}