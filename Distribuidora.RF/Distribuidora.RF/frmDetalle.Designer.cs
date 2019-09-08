namespace Distribuidora.RF
{
    partial class frmDetalle
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblNomLocal = new System.Windows.Forms.Label();
            this.lblNomCliente = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNomLocal = new System.Windows.Forms.TextBox();
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(21, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id";
            // 
            // lblNomLocal
            // 
            this.lblNomLocal.AutoSize = true;
            this.lblNomLocal.Location = new System.Drawing.Point(21, 52);
            this.lblNomLocal.Name = "lblNomLocal";
            this.lblNomLocal.Size = new System.Drawing.Size(69, 13);
            this.lblNomLocal.TabIndex = 1;
            this.lblNomLocal.Text = "Nombre local";
            // 
            // lblNomCliente
            // 
            this.lblNomCliente.AutoSize = true;
            this.lblNomCliente.Location = new System.Drawing.Point(21, 81);
            this.lblNomCliente.Name = "lblNomCliente";
            this.lblNomCliente.Size = new System.Drawing.Size(78, 13);
            this.lblNomCliente.TabIndex = 2;
            this.lblNomCliente.Text = "Nombre cliente";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(21, 110);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(30, 13);
            this.lblCalle.TabIndex = 3;
            this.lblCalle.Text = "Calle";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(21, 139);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 4;
            this.lblNumero.Text = "Número";
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(21, 168);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(34, 13);
            this.lblBarrio.TabIndex = 5;
            this.lblBarrio.Text = "Barrio";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(21, 197);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(21, 226);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Location = new System.Drawing.Point(21, 255);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(74, 13);
            this.lblFechaRegistro.TabIndex = 8;
            this.lblFechaRegistro.Text = "Fecha registro";
            this.lblFechaRegistro.Click += new System.EventHandler(this.label9_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(21, 284);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(107, 16);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(51, 20);
            this.txtId.TabIndex = 10;
            // 
            // txtNomLocal
            // 
            this.txtNomLocal.Enabled = false;
            this.txtNomLocal.Location = new System.Drawing.Point(107, 45);
            this.txtNomLocal.Name = "txtNomLocal";
            this.txtNomLocal.Size = new System.Drawing.Size(193, 20);
            this.txtNomLocal.TabIndex = 11;
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.Enabled = false;
            this.txtNomCliente.Location = new System.Drawing.Point(107, 74);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.Size = new System.Drawing.Size(193, 20);
            this.txtNomCliente.TabIndex = 12;
            // 
            // txtCalle
            // 
            this.txtCalle.Enabled = false;
            this.txtCalle.Location = new System.Drawing.Point(107, 103);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(193, 20);
            this.txtCalle.TabIndex = 13;
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(107, 132);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(67, 20);
            this.txtNumero.TabIndex = 14;
            // 
            // txtBarrio
            // 
            this.txtBarrio.Enabled = false;
            this.txtBarrio.Location = new System.Drawing.Point(107, 161);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(193, 20);
            this.txtBarrio.TabIndex = 15;
            // 
            // txtEstado
            // 
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(107, 190);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(67, 20);
            this.txtEstado.TabIndex = 16;
            // 
            // txtTipo
            // 
            this.txtTipo.Enabled = false;
            this.txtTipo.Location = new System.Drawing.Point(107, 219);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(99, 20);
            this.txtTipo.TabIndex = 17;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.Location = new System.Drawing.Point(107, 248);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(108, 20);
            this.txtFechaRegistro.TabIndex = 18;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(107, 277);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(193, 20);
            this.txtEmail.TabIndex = 19;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(153, 321);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 356);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFechaRegistro);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtBarrio);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtNomCliente);
            this.Controls.Add(this.txtNomLocal);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblBarrio);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblNomCliente);
            this.Controls.Add(this.lblNomLocal);
            this.Controls.Add(this.lblId);
            this.Enabled = false;
            this.Name = "frmDetalle";
            this.Text = "frmDetalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNomLocal;
        private System.Windows.Forms.Label lblNomCliente;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNomLocal;
        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAceptar;
    }
}