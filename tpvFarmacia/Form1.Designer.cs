namespace tpvFarmacia
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.lbStockMin = new System.Windows.Forms.Label();
            this.lbStockActual = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnVaciarCesta = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lbSuma = new System.Windows.Forms.Label();
            this.txtdni = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.txtPasswordEmpresa = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMail = new System.Windows.Forms.Label();
            this.lbDni = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtLector = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLectorUsuario = new System.Windows.Forms.TextBox();
            this.btnBloqueo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(170, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(404, 296);
            this.tabControl1.TabIndex = 0;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(77, 380);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(35, 13);
            this.lbNombre.TabIndex = 2;
            this.lbNombre.Text = "label1";
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.Location = new System.Drawing.Point(129, 380);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(35, 13);
            this.lbPrecio.TabIndex = 3;
            this.lbPrecio.Text = "label2";
            // 
            // lbStockMin
            // 
            this.lbStockMin.AutoSize = true;
            this.lbStockMin.Location = new System.Drawing.Point(187, 380);
            this.lbStockMin.Name = "lbStockMin";
            this.lbStockMin.Size = new System.Drawing.Size(35, 13);
            this.lbStockMin.TabIndex = 4;
            this.lbStockMin.Text = "label3";
            // 
            // lbStockActual
            // 
            this.lbStockActual.AutoSize = true;
            this.lbStockActual.Location = new System.Drawing.Point(239, 380);
            this.lbStockActual.Name = "lbStockActual";
            this.lbStockActual.Size = new System.Drawing.Size(35, 13);
            this.lbStockActual.TabIndex = 5;
            this.lbStockActual.Text = "label4";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(117, 15);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(170, 15);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(227, 15);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 10;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnVaciarCesta
            // 
            this.btnVaciarCesta.Location = new System.Drawing.Point(601, 66);
            this.btnVaciarCesta.Name = "btnVaciarCesta";
            this.btnVaciarCesta.Size = new System.Drawing.Size(75, 48);
            this.btnVaciarCesta.TabIndex = 11;
            this.btnVaciarCesta.Text = "Vaciar";
            this.btnVaciarCesta.UseVisualStyleBackColor = true;
            this.btnVaciarCesta.Visible = false;
            this.btnVaciarCesta.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Precio});
            this.dataGridView1.Location = new System.Drawing.Point(12, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.Size = new System.Drawing.Size(152, 274);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 75;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 50;
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(601, 171);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 46);
            this.btnPagar.TabIndex = 13;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbSuma
            // 
            this.lbSuma.AutoSize = true;
            this.lbSuma.Location = new System.Drawing.Point(12, 336);
            this.lbSuma.Name = "lbSuma";
            this.lbSuma.Size = new System.Drawing.Size(35, 13);
            this.lbSuma.TabIndex = 14;
            this.lbSuma.Text = "label1";
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(501, 340);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(100, 20);
            this.txtdni.TabIndex = 15;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(501, 366);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(100, 20);
            this.txtPwd.TabIndex = 16;
            this.txtPwd.TextChanged += new System.EventHandler(this.txtPwd_TextChanged);
            this.txtPwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyUp);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(501, 397);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(35, 13);
            this.lbUsuario.TabIndex = 17;
            this.lbUsuario.Text = "label1";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(748, 326);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 46);
            this.btnCerrarSesion.TabIndex = 18;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Visible = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(748, 378);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 35);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(601, 266);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(75, 46);
            this.btnGestion.TabIndex = 20;
            this.btnGestion.Text = "Gestión";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Visible = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 345);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(384, 345);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(242, 345);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(119, 20);
            this.txtCodigoBarra.TabIndex = 23;
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.txtCodigoBarra_TextChanged);
            // 
            // txtPasswordEmpresa
            // 
            this.txtPasswordEmpresa.Location = new System.Drawing.Point(326, 15);
            this.txtPasswordEmpresa.Name = "txtPasswordEmpresa";
            this.txtPasswordEmpresa.PasswordChar = '*';
            this.txtPasswordEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordEmpresa.TabIndex = 24;
            this.txtPasswordEmpresa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPasswordEmpresa_KeyUp);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(436, 15);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(701, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Tarjeta Sanitaria";
            // 
            // lbMail
            // 
            this.lbMail.AutoSize = true;
            this.lbMail.Location = new System.Drawing.Point(701, 164);
            this.lbMail.Name = "lbMail";
            this.lbMail.Size = new System.Drawing.Size(34, 13);
            this.lbMail.TabIndex = 28;
            this.lbMail.Text = "lbMail";
            // 
            // lbDni
            // 
            this.lbDni.AutoSize = true;
            this.lbDni.Location = new System.Drawing.Point(701, 151);
            this.lbDni.Name = "lbDni";
            this.lbDni.Size = new System.Drawing.Size(31, 13);
            this.lbDni.TabIndex = 29;
            this.lbDni.Text = "lbDni";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(704, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(121, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtLector
            // 
            this.txtLector.Location = new System.Drawing.Point(701, 223);
            this.txtLector.Name = "txtLector";
            this.txtLector.Size = new System.Drawing.Size(100, 20);
            this.txtLector.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(701, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Lector Clientes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(621, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Lector Usuario";
            // 
            // txtLectorUsuario
            // 
            this.txtLectorUsuario.Location = new System.Drawing.Point(624, 365);
            this.txtLectorUsuario.Name = "txtLectorUsuario";
            this.txtLectorUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtLectorUsuario.TabIndex = 34;
            this.txtLectorUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLectorUsuario_KeyPress);
            // 
            // btnBloqueo
            // 
            this.btnBloqueo.Location = new System.Drawing.Point(748, 278);
            this.btnBloqueo.Name = "btnBloqueo";
            this.btnBloqueo.Size = new System.Drawing.Size(75, 34);
            this.btnBloqueo.TabIndex = 35;
            this.btnBloqueo.Text = "Bloquear Pantalla";
            this.btnBloqueo.UseVisualStyleBackColor = true;
            this.btnBloqueo.Click += new System.EventHandler(this.btnBloqueo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(867, 422);
            this.Controls.Add(this.btnBloqueo);
            this.Controls.Add(this.txtLectorUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLector);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbDni);
            this.Controls.Add(this.lbMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtPasswordEmpresa);
            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnGestion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lbUsuario);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtdni);
            this.Controls.Add(this.lbSuma);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnVaciarCesta);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lbStockActual);
            this.Controls.Add(this.lbStockMin);
            this.Controls.Add(this.lbPrecio);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "TpvFarmacia";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.Label lbStockMin;
        private System.Windows.Forms.Label lbStockActual;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnVaciarCesta;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Label lbSuma;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.TextBox txtPasswordEmpresa;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMail;
        private System.Windows.Forms.Label lbDni;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtLector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLectorUsuario;
        private System.Windows.Forms.Button btnBloqueo;
    }
}

