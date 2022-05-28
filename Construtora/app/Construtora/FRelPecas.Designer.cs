namespace Construtora
{
    partial class FRelPecas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ConstrutoraDataSet = new Construtora.ConstrutoraDataSet();
            this.PECABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PECATableAdapter = new Construtora.ConstrutoraDataSetTableAdapters.PECATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ConstrutoraDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PECABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.PECABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Construtora.Rel.RelPeca.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // ConstrutoraDataSet
            // 
            this.ConstrutoraDataSet.DataSetName = "ConstrutoraDataSet";
            this.ConstrutoraDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PECABindingSource
            // 
            this.PECABindingSource.DataMember = "PECA";
            this.PECABindingSource.DataSource = this.ConstrutoraDataSet;
            // 
            // PECATableAdapter
            // 
            this.PECATableAdapter.ClearBeforeFill = true;
            // 
            // FRelPecas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FRelPecas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRelPecas";
            this.Load += new System.EventHandler(this.FRelPecas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConstrutoraDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PECABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PECABindingSource;
        private ConstrutoraDataSet ConstrutoraDataSet;
        private ConstrutoraDataSetTableAdapters.PECATableAdapter PECATableAdapter;
    }
}