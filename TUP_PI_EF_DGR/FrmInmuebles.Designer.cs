namespace TUP_PI_EF_DGR
{
    partial class FrmInmuebles
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
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grpLista = new System.Windows.Forms.GroupBox();
            this.lstInmuebles = new System.Windows.Forms.ListBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtValuacion = new System.Windows.Forms.TextBox();
            this.txtEdificada = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTerreno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomenclatura = new System.Windows.Forms.TextBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.rbtRural = new System.Windows.Forms.RadioButton();
            this.rbtUrbano = new System.Windows.Forms.RadioButton();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLista.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(318, 350);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(169, 50);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar Inmueble";
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(596, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(169, 50);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(40, 350);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(169, 50);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Editar Inmueble";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // grpLista
            // 
            this.grpLista.Controls.Add(this.lstInmuebles);
            this.grpLista.Location = new System.Drawing.Point(415, 12);
            this.grpLista.Name = "grpLista";
            this.grpLista.Size = new System.Drawing.Size(375, 318);
            this.grpLista.TabIndex = 6;
            this.grpLista.TabStop = false;
            this.grpLista.Text = "Listado de Inmuebles :";
            // 
            // lstInmuebles
            // 
            this.lstInmuebles.FormattingEnabled = true;
            this.lstInmuebles.Location = new System.Drawing.Point(6, 19);
            this.lstInmuebles.Name = "lstInmuebles";
            this.lstInmuebles.Size = new System.Drawing.Size(363, 290);
            this.lstInmuebles.TabIndex = 0;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.label10);
            this.grpDatos.Controls.Add(this.label9);
            this.grpDatos.Controls.Add(this.label8);
            this.grpDatos.Controls.Add(this.txtValuacion);
            this.grpDatos.Controls.Add(this.txtEdificada);
            this.grpDatos.Controls.Add(this.label7);
            this.grpDatos.Controls.Add(this.txtTerreno);
            this.grpDatos.Controls.Add(this.label6);
            this.grpDatos.Controls.Add(this.txtNomenclatura);
            this.grpDatos.Controls.Add(this.cboCategoria);
            this.grpDatos.Controls.Add(this.rbtRural);
            this.grpDatos.Controls.Add(this.rbtUrbano);
            this.grpDatos.Controls.Add(this.txtTitular);
            this.grpDatos.Controls.Add(this.label5);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Location = new System.Drawing.Point(14, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(375, 318);
            this.grpDatos.TabIndex = 4;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del Inmueble: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "M2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(224, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "M2";
            // 
            // txtValuacion
            // 
            this.txtValuacion.Location = new System.Drawing.Point(146, 261);
            this.txtValuacion.Name = "txtValuacion";
            this.txtValuacion.Size = new System.Drawing.Size(128, 20);
            this.txtValuacion.TabIndex = 4;
            // 
            // txtEdificada
            // 
            this.txtEdificada.Location = new System.Drawing.Point(146, 223);
            this.txtEdificada.Name = "txtEdificada";
            this.txtEdificada.Size = new System.Drawing.Size(72, 20);
            this.txtEdificada.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Superficie Edificada:";
            // 
            // txtTerreno
            // 
            this.txtTerreno.Location = new System.Drawing.Point(146, 185);
            this.txtTerreno.Name = "txtTerreno";
            this.txtTerreno.Size = new System.Drawing.Size(72, 20);
            this.txtTerreno.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Superficie Terreno:";
            // 
            // txtNomenclatura
            // 
            this.txtNomenclatura.Location = new System.Drawing.Point(146, 71);
            this.txtNomenclatura.Name = "txtNomenclatura";
            this.txtNomenclatura.Size = new System.Drawing.Size(200, 20);
            this.txtNomenclatura.TabIndex = 5;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(146, 147);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(166, 21);
            this.cboCategoria.TabIndex = 6;
            // 
            // rbtRural
            // 
            this.rbtRural.AutoSize = true;
            this.rbtRural.Location = new System.Drawing.Point(250, 109);
            this.rbtRural.Name = "rbtRural";
            this.rbtRural.Size = new System.Drawing.Size(62, 17);
            this.rbtRural.TabIndex = 9;
            this.rbtRural.TabStop = true;
            this.rbtRural.Text = "2- Rural";
            this.rbtRural.UseVisualStyleBackColor = true;
            // 
            // rbtUrbano
            // 
            this.rbtUrbano.AutoSize = true;
            this.rbtUrbano.Location = new System.Drawing.Point(146, 109);
            this.rbtUrbano.Name = "rbtUrbano";
            this.rbtUrbano.Size = new System.Drawing.Size(72, 17);
            this.rbtUrbano.TabIndex = 3;
            this.rbtUrbano.TabStop = true;
            this.rbtUrbano.Text = "1- Urbano";
            this.rbtUrbano.UseVisualStyleBackColor = true;
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(146, 33);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(200, 20);
            this.txtTitular.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Valuación Fiscal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tipo Inmueble:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nomenclatura Catastral:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Titular:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoría:";
            // 
            // FrmInmuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 413);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpLista);
            this.Controls.Add(this.grpDatos);
            this.Name = "FrmInmuebles";
            this.Text = "Dirección General de Rentas";
            this.Load += new System.EventHandler(this.FrmInmuebles_Load);
            this.grpLista.ResumeLayout(false);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.GroupBox grpLista;
        private System.Windows.Forms.ListBox lstInmuebles;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.RadioButton rbtRural;
        private System.Windows.Forms.RadioButton rbtUrbano;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtValuacion;
        private System.Windows.Forms.TextBox txtEdificada;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTerreno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomenclatura;
    }
}

