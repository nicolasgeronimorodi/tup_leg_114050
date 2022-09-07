namespace BancoAppV6.frontend
{
    partial class frmCuentas
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtCuentaCorriente = new System.Windows.Forms.RadioButton();
            this.rbtCajaAhorro = new System.Windows.Forms.RadioButton();
            this.btnAgregarCuenta = new System.Windows.Forms.Button();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.ColCBU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTipoCuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cboClientes = new System.Windows.Forms.ComboBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Registro de cuentas";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Cuentas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Tipo de cuenta";
            // 
            // rbtCuentaCorriente
            // 
            this.rbtCuentaCorriente.AutoSize = true;
            this.rbtCuentaCorriente.Location = new System.Drawing.Point(44, 201);
            this.rbtCuentaCorriente.Name = "rbtCuentaCorriente";
            this.rbtCuentaCorriente.Size = new System.Drawing.Size(103, 17);
            this.rbtCuentaCorriente.TabIndex = 34;
            this.rbtCuentaCorriente.TabStop = true;
            this.rbtCuentaCorriente.Text = "Cuenta corriente";
            this.rbtCuentaCorriente.UseVisualStyleBackColor = true;
            // 
            // rbtCajaAhorro
            // 
            this.rbtCajaAhorro.AutoSize = true;
            this.rbtCajaAhorro.Location = new System.Drawing.Point(44, 237);
            this.rbtCajaAhorro.Name = "rbtCajaAhorro";
            this.rbtCajaAhorro.Size = new System.Drawing.Size(94, 17);
            this.rbtCajaAhorro.TabIndex = 35;
            this.rbtCajaAhorro.TabStop = true;
            this.rbtCajaAhorro.Text = "Caja de ahorro";
            this.rbtCajaAhorro.UseVisualStyleBackColor = true;
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.Location = new System.Drawing.Point(27, 277);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(163, 35);
            this.btnAgregarCuenta.TabIndex = 36;
            this.btnAgregarCuenta.Text = "Agregar";
            this.btnAgregarCuenta.UseVisualStyleBackColor = true;
            this.btnAgregarCuenta.Click += new System.EventHandler(this.btnAgregarCuenta_Click);
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCBU,
            this.ColTipoCuenta});
            this.dgvCuentas.Location = new System.Drawing.Point(241, 43);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.Size = new System.Drawing.Size(442, 148);
            this.dgvCuentas.TabIndex = 37;
            // 
            // ColCBU
            // 
            this.ColCBU.HeaderText = "Cbu";
            this.ColCBU.Name = "ColCBU";
            this.ColCBU.ReadOnly = true;
            // 
            // ColTipoCuenta
            // 
            this.ColTipoCuenta.HeaderText = "Tipo cuenta";
            this.ColTipoCuenta.Name = "ColTipoCuenta";
            this.ColTipoCuenta.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-5, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Seleccione un cliente para asociarlo con cuentas";
            // 
            // cboClientes
            // 
            this.cboClientes.FormattingEnabled = true;
            this.cboClientes.Location = new System.Drawing.Point(12, 101);
            this.cboClientes.Name = "cboClientes";
            this.cboClientes.Size = new System.Drawing.Size(200, 21);
            this.cboClientes.TabIndex = 39;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(386, 237);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(109, 23);
            this.btnGuardarCambios.TabIndex = 40;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // frmCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.cboClientes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCuentas);
            this.Controls.Add(this.btnAgregarCuenta);
            this.Controls.Add(this.rbtCajaAhorro);
            this.Controls.Add(this.rbtCuentaCorriente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "frmCuentas";
            this.Text = "frmCuentas";
            this.Load += new System.EventHandler(this.frmCuentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtCuentaCorriente;
        private System.Windows.Forms.RadioButton rbtCajaAhorro;
        private System.Windows.Forms.Button btnAgregarCuenta;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboClientes;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCBU;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTipoCuenta;
    }
}