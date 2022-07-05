namespace Construtora
{
    partial class FRelObras
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
            this.construtoraDataSet = new Construtora.ConstrutoraDataSet();
            this.construtoraDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oBRABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oBRATableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.OBRATableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oBRABindingSource)).BeginInit();
            this.SuspendLayout();
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
            // oBRABindingSource
            // 
            this.oBRABindingSource.DataMember = "OBRA";
            this.oBRABindingSource.DataSource = this.construtoraDataSet;
            // 
            // oBRATableAdapter
            // 
            this.oBRATableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.oBRABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Construtora.Rel.RelObras.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 1;
            // 
            // FRelObras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRelObras";
            this.Text = "FRelObras";
            this.Load += new System.EventHandler(this.FRelObras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.construtoraDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oBRABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource construtoraDataSetBindingSource;
        private ConstrutoraDataSet construtoraDataSet;
        private System.Windows.Forms.BindingSource oBRABindingSource;
        private ConstrutoraDataSetTableAdapters.OBRATableAdapter oBRATableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}