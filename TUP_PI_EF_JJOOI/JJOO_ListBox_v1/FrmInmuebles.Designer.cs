﻿namespace JJOO_ListBox
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
            this.lstCompetidores = new System.Windows.Forms.ListBox();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtNomenclatura = new System.Windows.Forms.TextBox();
            this.cboDisciplina = new System.Windows.Forms.ComboBox();
            this.rbtFemenino = new System.Windows.Forms.RadioButton();
            this.rbtMasculino = new System.Windows.Forms.RadioButton();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLista.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(431, 351);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(169, 50);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar competidor";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(803, 350);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(169, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(40, 350);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(169, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Editar Competidor";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grpLista
            // 
            this.grpLista.Controls.Add(this.lstCompetidores);
            this.grpLista.Location = new System.Drawing.Point(415, 12);
            this.grpLista.Name = "grpLista";
            this.grpLista.Size = new System.Drawing.Size(563, 318);
            this.grpLista.TabIndex = 6;
            this.grpLista.TabStop = false;
            this.grpLista.Text = "Listado de Inmuebles :";
            // 
            // lstCompetidores
            // 
            this.lstCompetidores.FormattingEnabled = true;
            this.lstCompetidores.Location = new System.Drawing.Point(6, 19);
            this.lstCompetidores.Name = "lstCompetidores";
            this.lstCompetidores.Size = new System.Drawing.Size(551, 290);
            this.lstCompetidores.TabIndex = 0;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.dateTimePicker1);
            this.grpDatos.Controls.Add(this.txtNomenclatura);
            this.grpDatos.Controls.Add(this.cboDisciplina);
            this.grpDatos.Controls.Add(this.rbtFemenino);
            this.grpDatos.Controls.Add(this.rbtMasculino);
            this.grpDatos.Controls.Add(this.txtId);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.numero);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Location = new System.Drawing.Point(14, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(375, 318);
            this.grpDatos.TabIndex = 4;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del Inmueble: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha de Nacimiento";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(142, 250);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // txtNomenclatura
            // 
            this.txtNomenclatura.Location = new System.Drawing.Point(111, 93);
            this.txtNomenclatura.Name = "txtNomenclatura";
            this.txtNomenclatura.Size = new System.Drawing.Size(200, 20);
            this.txtNomenclatura.TabIndex = 1;
            // 
            // cboDisciplina
            // 
            this.cboDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDisciplina.FormattingEnabled = true;
            this.cboDisciplina.Location = new System.Drawing.Point(114, 148);
            this.cboDisciplina.Name = "cboDisciplina";
            this.cboDisciplina.Size = new System.Drawing.Size(166, 21);
            this.cboDisciplina.TabIndex = 4;
            // 
            // rbtFemenino
            // 
            this.rbtFemenino.AutoSize = true;
            this.rbtFemenino.Location = new System.Drawing.Point(216, 200);
            this.rbtFemenino.Name = "rbtFemenino";
            this.rbtFemenino.Size = new System.Drawing.Size(83, 17);
            this.rbtFemenino.TabIndex = 3;
            this.rbtFemenino.TabStop = true;
            this.rbtFemenino.Text = "F- Femenino";
            this.rbtFemenino.UseVisualStyleBackColor = true;
            // 
            // rbtMasculino
            // 
            this.rbtMasculino.AutoSize = true;
            this.rbtMasculino.Location = new System.Drawing.Point(112, 200);
            this.rbtMasculino.Name = "rbtMasculino";
            this.rbtMasculino.Size = new System.Drawing.Size(91, 17);
            this.rbtMasculino.TabIndex = 2;
            this.rbtMasculino.TabStop = true;
            this.rbtMasculino.Text = "M - Masculino";
            this.rbtMasculino.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(111, 43);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(37, 20);
            this.txtId.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sexo: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre: ";
            // 
            // numero
            // 
            this.numero.AutoSize = true;
            this.numero.Location = new System.Drawing.Point(43, 46);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(47, 13);
            this.numero.TabIndex = 2;
            this.numero.Text = "Numero:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Disciplina:";
            // 
            // FrmInmuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 413);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpLista);
            this.Controls.Add(this.grpDatos);
            this.Name = "FrmInmuebles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ListBox lstCompetidores;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.ComboBox cboDisciplina;
        private System.Windows.Forms.RadioButton rbtFemenino;
        private System.Windows.Forms.RadioButton rbtMasculino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label numero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomenclatura;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

