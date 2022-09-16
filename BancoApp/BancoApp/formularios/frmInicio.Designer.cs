namespace BancoApp
{
    partial class frmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.soporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asociarClienteConCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCuentasPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soporteToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // soporteToolStripMenuItem
            // 
            this.soporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.toolStripSeparator1,
            this.verCuentasPorClienteToolStripMenuItem});
            this.soporteToolStripMenuItem.Name = "soporteToolStripMenuItem";
            this.soporteToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.soporteToolStripMenuItem.Text = "Soporte";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asociarClienteConCuentasToolStripMenuItem,
            this.modificarCuentasToolStripMenuItem});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "Acciones";
            // 
            // asociarClienteConCuentasToolStripMenuItem
            // 
            this.asociarClienteConCuentasToolStripMenuItem.Name = "asociarClienteConCuentasToolStripMenuItem";
            this.asociarClienteConCuentasToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.asociarClienteConCuentasToolStripMenuItem.Text = "Asociar cliente con cuenta/s";
            this.asociarClienteConCuentasToolStripMenuItem.Click += new System.EventHandler(this.asociarClienteConCuentasToolStripMenuItem_Click);
            // 
            // modificarCuentasToolStripMenuItem
            // 
            this.modificarCuentasToolStripMenuItem.Name = "modificarCuentasToolStripMenuItem";
            this.modificarCuentasToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.modificarCuentasToolStripMenuItem.Text = "Modificar cuentas";
            // 
            // verCuentasPorClienteToolStripMenuItem
            // 
            this.verCuentasPorClienteToolStripMenuItem.Name = "verCuentasPorClienteToolStripMenuItem";
            this.verCuentasPorClienteToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.verCuentasPorClienteToolStripMenuItem.Text = "Ver cuentas por cliente";
            this.verCuentasPorClienteToolStripMenuItem.Click += new System.EventHandler(this.verCuentasPorClienteToolStripMenuItem_Click);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmInicio";
            this.Text = "frmInicio.cs";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem soporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asociarClienteConCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem verCuentasPorClienteToolStripMenuItem;
    }
}

