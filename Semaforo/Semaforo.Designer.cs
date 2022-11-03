
namespace Semaforo {
    partial class Semaforo {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnPreventivas = new System.Windows.Forms.Button();
            this.lblnumero = new System.Windows.Forms.Label();
            this.lblSemaforo = new System.Windows.Forms.Label();
            this.btnPausa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(95, 37);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(95, 66);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 23);
            this.btnDetener.TabIndex = 1;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnPreventivas
            // 
            this.btnPreventivas.Enabled = false;
            this.btnPreventivas.Location = new System.Drawing.Point(208, 36);
            this.btnPreventivas.Name = "btnPreventivas";
            this.btnPreventivas.Size = new System.Drawing.Size(75, 23);
            this.btnPreventivas.TabIndex = 2;
            this.btnPreventivas.Text = "Preventivas";
            this.btnPreventivas.UseVisualStyleBackColor = true;
            // 
            // lblnumero
            // 
            this.lblnumero.AutoSize = true;
            this.lblnumero.Font = new System.Drawing.Font("Digital-7 Mono", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero.Location = new System.Drawing.Point(391, 220);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(107, 123);
            this.lblnumero.TabIndex = 3;
            this.lblnumero.Text = "0";
            // 
            // lblSemaforo
            // 
            this.lblSemaforo.AutoSize = true;
            this.lblSemaforo.Location = new System.Drawing.Point(161, 295);
            this.lblSemaforo.Name = "lblSemaforo";
            this.lblSemaforo.Size = new System.Drawing.Size(35, 13);
            this.lblSemaforo.TabIndex = 6;
            this.lblSemaforo.Text = "label1";
            // 
            // btnPausa
            // 
            this.btnPausa.Location = new System.Drawing.Point(95, 95);
            this.btnPausa.Name = "btnPausa";
            this.btnPausa.Size = new System.Drawing.Size(75, 23);
            this.btnPausa.TabIndex = 7;
            this.btnPausa.Text = "Pausa";
            this.btnPausa.UseVisualStyleBackColor = true;
            this.btnPausa.Click += new System.EventHandler(this.btnPausa_Click);
            // 
            // Semaforo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPausa);
            this.Controls.Add(this.lblSemaforo);
            this.Controls.Add(this.lblnumero);
            this.Controls.Add(this.btnPreventivas);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnIniciar);
            this.Name = "Semaforo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador semaforo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Semaforo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnPreventivas;
        private System.Windows.Forms.Label lblnumero;
        private System.Windows.Forms.Label lblSemaforo;
        private System.Windows.Forms.Button btnPausa;
    }
}

