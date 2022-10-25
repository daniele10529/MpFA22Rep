namespace MpFA20
{
    partial class frmMain
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPP = new System.Windows.Forms.Button();
            this.btnPPlibretto = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMantenimento = new System.Windows.Forms.Button();
            this.btnContoCorrente = new System.Windows.Forms.Button();
            this.btnSpeseAnnuali = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(362, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "by DaamDev Software Solutions";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(2, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 5);
            this.panel1.TabIndex = 7;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnReports.Image = global::MpFA20.Properties.Resources.imagesRep2_piccolo;
            this.btnReports.Location = new System.Drawing.Point(462, 467);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(120, 120);
            this.btnReports.TabIndex = 10;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::MpFA20.Properties.Resources.DaamDev2;
            this.panel2.Location = new System.Drawing.Point(12, 627);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 162);
            this.panel2.TabIndex = 9;
            // 
            // btnPP
            // 
            this.btnPP.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPP.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPP.Image = global::MpFA20.Properties.Resources.images;
            this.btnPP.Location = new System.Drawing.Point(12, 467);
            this.btnPP.Name = "btnPP";
            this.btnPP.Size = new System.Drawing.Size(120, 120);
            this.btnPP.TabIndex = 8;
            this.btnPP.UseVisualStyleBackColor = false;
            this.btnPP.Click += new System.EventHandler(this.btnPP_Click);
            // 
            // btnPPlibretto
            // 
            this.btnPPlibretto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnPPlibretto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPPlibretto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPPlibretto.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPPlibretto.Image = global::MpFA20.Properties.Resources.Start_setting2_piccolo;
            this.btnPPlibretto.Location = new System.Drawing.Point(462, 329);
            this.btnPPlibretto.Name = "btnPPlibretto";
            this.btnPPlibretto.Size = new System.Drawing.Size(120, 120);
            this.btnPPlibretto.TabIndex = 6;
            this.btnPPlibretto.UseVisualStyleBackColor = false;
            this.btnPPlibretto.Click += new System.EventHandler(this.btnPPlibretto_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::MpFA20.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnExit.Location = new System.Drawing.Point(523, 731);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 58);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMantenimento
            // 
            this.btnMantenimento.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnMantenimento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMantenimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimento.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnMantenimento.Image = global::MpFA20.Properties.Resources.Mantenimento_piccolo;
            this.btnMantenimento.Location = new System.Drawing.Point(309, 329);
            this.btnMantenimento.Name = "btnMantenimento";
            this.btnMantenimento.Size = new System.Drawing.Size(120, 120);
            this.btnMantenimento.TabIndex = 3;
            this.btnMantenimento.UseVisualStyleBackColor = false;
            this.btnMantenimento.Click += new System.EventHandler(this.btnMantenimento_Click);
            // 
            // btnContoCorrente
            // 
            this.btnContoCorrente.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnContoCorrente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnContoCorrente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContoCorrente.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnContoCorrente.Image = global::MpFA20.Properties.Resources.Conto_Corrente_piccolo;
            this.btnContoCorrente.Location = new System.Drawing.Point(160, 329);
            this.btnContoCorrente.Name = "btnContoCorrente";
            this.btnContoCorrente.Size = new System.Drawing.Size(120, 120);
            this.btnContoCorrente.TabIndex = 2;
            this.btnContoCorrente.UseVisualStyleBackColor = false;
            this.btnContoCorrente.Click += new System.EventHandler(this.btnContoCorrente_Click);
            // 
            // btnSpeseAnnuali
            // 
            this.btnSpeseAnnuali.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSpeseAnnuali.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSpeseAnnuali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeseAnnuali.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnSpeseAnnuali.Image = global::MpFA20.Properties.Resources.Spese_Annuali_piccolo;
            this.btnSpeseAnnuali.Location = new System.Drawing.Point(12, 329);
            this.btnSpeseAnnuali.Name = "btnSpeseAnnuali";
            this.btnSpeseAnnuali.Size = new System.Drawing.Size(120, 120);
            this.btnSpeseAnnuali.TabIndex = 1;
            this.btnSpeseAnnuali.UseVisualStyleBackColor = false;
            this.btnSpeseAnnuali.Click += new System.EventHandler(this.btnSpeseAnnuali_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.BackColor = System.Drawing.Color.Turquoise;
            this.elementHost1.BackgroundImage = global::MpFA20.Properties.Resources.MpFA5;
            this.elementHost1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.elementHost1.Location = new System.Drawing.Point(2, 12);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(602, 219);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.TabStop = false;
            this.elementHost1.Child = null;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(608, 806);
            this.ControlBox = false;
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnPP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPPlibretto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMantenimento);
            this.Controls.Add(this.btnContoCorrente);
            this.Controls.Add(this.btnSpeseAnnuali);
            this.Controls.Add(this.elementHost1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(608, 806);
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Button btnSpeseAnnuali;
        private System.Windows.Forms.Button btnContoCorrente;
        private System.Windows.Forms.Button btnMantenimento;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPPlibretto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPP;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReports;
    }
}

