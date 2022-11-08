
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
            this.lblnumero = new System.Windows.Forms.Label();
            this.lblSemaforo = new System.Windows.Forms.Label();
            this.chkPreventivas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnIniciar = new FontAwesome.Sharp.IconButton();
            this.btnPausar = new FontAwesome.Sharp.IconButton();
            this.btnDetener = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblnumero
            // 
            this.lblnumero.AutoSize = true;
            this.lblnumero.Font = new System.Drawing.Font("Digital-7 Mono", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero.Location = new System.Drawing.Point(421, 61);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(107, 123);
            this.lblnumero.TabIndex = 3;
            this.lblnumero.Text = "0";
            // 
            // lblSemaforo
            // 
            this.lblSemaforo.AutoSize = true;
            this.lblSemaforo.Location = new System.Drawing.Point(176, 274);
            this.lblSemaforo.Name = "lblSemaforo";
            this.lblSemaforo.Size = new System.Drawing.Size(35, 13);
            this.lblSemaforo.TabIndex = 6;
            this.lblSemaforo.Text = "label1";
            // 
            // chkPreventivas
            // 
            this.chkPreventivas.AutoSize = true;
            this.chkPreventivas.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.chkPreventivas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPreventivas.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkPreventivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPreventivas.Location = new System.Drawing.Point(781, 16);
            this.chkPreventivas.Name = "chkPreventivas";
            this.chkPreventivas.Size = new System.Drawing.Size(125, 58);
            this.chkPreventivas.TabIndex = 8;
            this.chkPreventivas.Text = "Preventivas";
            this.chkPreventivas.UseVisualStyleBackColor = false;
            this.chkPreventivas.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.btnDetener);
            this.groupBox1.Controls.Add(this.btnPausar);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.chkPreventivas);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(909, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.LightGreen;
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnIniciar.IconColor = System.Drawing.Color.Black;
            this.btnIniciar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(3, 16);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(147, 58);
            this.btnIniciar.TabIndex = 10;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click_1);
            // 
            // btnPausar
            // 
            this.btnPausar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPausar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPausar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPausar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPausar.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.btnPausar.IconColor = System.Drawing.Color.Black;
            this.btnPausar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPausar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPausar.Location = new System.Drawing.Point(150, 16);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(147, 58);
            this.btnPausar.TabIndex = 11;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPausar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPausar.UseVisualStyleBackColor = false;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.Salmon;
            this.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetener.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetener.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetener.IconChar = FontAwesome.Sharp.IconChar.Stop;
            this.btnDetener.IconColor = System.Drawing.Color.Black;
            this.btnDetener.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDetener.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetener.Location = new System.Drawing.Point(297, 16);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(147, 58);
            this.btnDetener.TabIndex = 12;
            this.btnDetener.Text = "Detener";
            this.btnDetener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetener.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblnumero);
            this.panel1.Controls.Add(this.lblSemaforo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 583);
            this.panel1.TabIndex = 10;
            // 
            // Semaforo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 660);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(800, 0);
            this.Name = "Semaforo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador semaforo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Semaforo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblnumero;
        private System.Windows.Forms.Label lblSemaforo;
        private System.Windows.Forms.CheckBox chkPreventivas;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnIniciar;
        private FontAwesome.Sharp.IconButton btnPausar;
        private FontAwesome.Sharp.IconButton btnDetener;
        private System.Windows.Forms.Panel panel1;
    }
}

