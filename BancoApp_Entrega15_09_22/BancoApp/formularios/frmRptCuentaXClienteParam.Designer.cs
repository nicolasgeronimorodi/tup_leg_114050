namespace BancoApp.formularios
{
    partial class frmRptCuentaXClienteParam
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnIngresarDni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "BancoApp.reportes.rptCuentasXCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(61, 136);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(75, 40);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 1;
            // 
            // btnIngresarDni
            // 
            this.btnIngresarDni.Location = new System.Drawing.Point(198, 40);
            this.btnIngresarDni.Name = "btnIngresarDni";
            this.btnIngresarDni.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarDni.TabIndex = 2;
            this.btnIngresarDni.Text = "Ingresar DNI";
            this.btnIngresarDni.UseVisualStyleBackColor = true;
            this.btnIngresarDni.Click += new System.EventHandler(this.btnIngresarDni_Click);
            // 
            // frmRptCuentaXClienteParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnIngresarDni);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRptCuentaXClienteParam";
            this.Text = "frmRptCuentaXClienteParam";
            this.Load += new System.EventHandler(this.frmRptCuentaXClienteParam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnIngresarDni;
    }
}