﻿namespace WFANOTIFIACIONES
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_legajo = new System.Windows.Forms.TextBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btnNotifica = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVNotificaciones = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotificaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_legajo);
            this.groupBox1.Controls.Add(this.txt_nombre);
            this.groupBox1.Controls.Add(this.btnNotifica);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Acciones ]";
            // 
            // txt_legajo
            // 
            this.txt_legajo.Location = new System.Drawing.Point(138, 70);
            this.txt_legajo.Name = "txt_legajo";
            this.txt_legajo.Size = new System.Drawing.Size(191, 20);
            this.txt_legajo.TabIndex = 5;
            this.txt_legajo.TextChanged += new System.EventHandler(this.txt_legajo_TextChanged);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(138, 22);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(191, 20);
            this.txt_nombre.TabIndex = 4;
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            // 
            // btnNotifica
            // 
            this.btnNotifica.BackColor = System.Drawing.Color.SlateGray;
            this.btnNotifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotifica.Location = new System.Drawing.Point(536, 59);
            this.btnNotifica.Name = "btnNotifica";
            this.btnNotifica.Size = new System.Drawing.Size(151, 40);
            this.btnNotifica.TabIndex = 3;
            this.btnNotifica.Text = "Enviar Notificacion";
            this.btnNotifica.UseVisualStyleBackColor = false;
            this.btnNotifica.Click += new System.EventHandler(this.btnNotifica_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buequeda por Legajo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busqueda por nombre";
            // 
            // DGVNotificaciones
            // 
            this.DGVNotificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNotificaciones.Location = new System.Drawing.Point(12, 114);
            this.DGVNotificaciones.Name = "DGVNotificaciones";
            this.DGVNotificaciones.Size = new System.Drawing.Size(1203, 573);
            this.DGVNotificaciones.TabIndex = 1;
            this.DGVNotificaciones.ReadOnlyChanged += new System.EventHandler(this.DGVNotificaciones_ReadOnlyChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 727);
            this.Controls.Add(this.DGVNotificaciones);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Envio de Notificaciones ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNotificaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotifica;
        private System.Windows.Forms.DataGridView DGVNotificaciones;
        private System.Windows.Forms.TextBox txt_legajo;
        private System.Windows.Forms.TextBox txt_nombre;
    }
}

