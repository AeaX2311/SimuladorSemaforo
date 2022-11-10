
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Semaforo));
            this.chkPreventivas = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetener = new FontAwesome.Sharp.IconButton();
            this.btnPausar = new FontAwesome.Sharp.IconButton();
            this.btnIniciar = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbO = new System.Windows.Forms.PictureBox();
            this.pcbE = new System.Windows.Forms.PictureBox();
            this.pcbS = new System.Windows.Forms.PictureBox();
            this.pcbN = new System.Windows.Forms.PictureBox();
            this.lblnumero = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbN)).BeginInit();
            this.SuspendLayout();
            // 
            // chkPreventivas
            // 
            this.chkPreventivas.AutoSize = true;
            this.chkPreventivas.BackColor = System.Drawing.Color.Gold;
            this.chkPreventivas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPreventivas.Dock = System.Windows.Forms.DockStyle.Right;
            this.chkPreventivas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPreventivas.Location = new System.Drawing.Point(645, 16);
            this.chkPreventivas.Name = "chkPreventivas";
            this.chkPreventivas.Size = new System.Drawing.Size(161, 58);
            this.chkPreventivas.TabIndex = 8;
            this.chkPreventivas.Text = "PREVENTIVAS";
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
            this.groupBox1.Size = new System.Drawing.Size(809, 77);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.Salmon;
            this.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetener.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetener.Enabled = false;
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
            // btnPausar
            // 
            this.btnPausar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPausar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPausar.Enabled = false;
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
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.pcbO);
            this.panel1.Controls.Add(this.pcbE);
            this.panel1.Controls.Add(this.pcbS);
            this.panel1.Controls.Add(this.pcbN);
            this.panel1.Controls.Add(this.lblnumero);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 786);
            this.panel1.TabIndex = 10;
            // 
            // pcbO
            // 
            this.pcbO.BackColor = System.Drawing.Color.Transparent;
            this.pcbO.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbO.BackgroundImage")));
            this.pcbO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbO.Location = new System.Drawing.Point(93, 215);
            this.pcbO.Name = "pcbO";
            this.pcbO.Size = new System.Drawing.Size(100, 82);
            this.pcbO.TabIndex = 7;
            this.pcbO.TabStop = false;
            // 
            // pcbE
            // 
            this.pcbE.BackColor = System.Drawing.Color.Transparent;
            this.pcbE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbE.BackgroundImage")));
            this.pcbE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbE.Location = new System.Drawing.Point(625, 488);
            this.pcbE.Name = "pcbE";
            this.pcbE.Size = new System.Drawing.Size(100, 82);
            this.pcbE.TabIndex = 6;
            this.pcbE.TabStop = false;
            // 
            // pcbS
            // 
            this.pcbS.BackColor = System.Drawing.Color.Transparent;
            this.pcbS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbS.BackgroundImage")));
            this.pcbS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbS.Location = new System.Drawing.Point(215, 600);
            this.pcbS.Name = "pcbS";
            this.pcbS.Size = new System.Drawing.Size(82, 100);
            this.pcbS.TabIndex = 5;
            this.pcbS.TabStop = false;
            // 
            // pcbN
            // 
            this.pcbN.BackColor = System.Drawing.Color.Transparent;
            this.pcbN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbN.BackgroundImage")));
            this.pcbN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbN.Location = new System.Drawing.Point(505, 82);
            this.pcbN.Name = "pcbN";
            this.pcbN.Size = new System.Drawing.Size(82, 100);
            this.pcbN.TabIndex = 4;
            this.pcbN.TabStop = false;
            // 
            // lblnumero
            // 
            this.lblnumero.BackColor = System.Drawing.Color.Transparent;
            this.lblnumero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblnumero.Font = new System.Drawing.Font("Digital-7 Mono", 89.99999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumero.ForeColor = System.Drawing.Color.White;
            this.lblnumero.Location = new System.Drawing.Point(0, 0);
            this.lblnumero.Name = "lblnumero";
            this.lblnumero.Size = new System.Drawing.Size(809, 786);
            this.lblnumero.TabIndex = 3;
            this.lblnumero.Text = "0";
            this.lblnumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Semaforo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 863);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(625, 39);
            this.Name = "Semaforo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulador semaforo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Semaforo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkPreventivas;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnIniciar;
        private FontAwesome.Sharp.IconButton btnPausar;
        private FontAwesome.Sharp.IconButton btnDetener;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbS;
        private System.Windows.Forms.PictureBox pcbN;
        private System.Windows.Forms.PictureBox pcbO;
        private System.Windows.Forms.PictureBox pcbE;
        private System.Windows.Forms.Label lblnumero;
    }
}

