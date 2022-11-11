namespace RunningReports
{
    partial class frmSpendElements
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cmbSelOftenSpends = new RoundendControlCollections.CustomComboBox();
            this.btnPDFCreator = new System.Windows.Forms.Button();
            this.lnkYearReport = new System.Windows.Forms.LinkLabel();
            this.btnRunReports = new RoundendControlCollections.RoundedButton();
            this.txtReportsSpends = new RoundendControlCollections.RoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectYear = new RoundendControlCollections.RoundedTextBox();
            this.btnListYears = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.roundedPanel1 = new RoundendControlCollections.RoundedPanel();
            this.roundedPanel2 = new RoundendControlCollections.RoundedPanel();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.roundedPanel2);
            this.pnlMain.Controls.Add(this.roundedPanel1);
            this.pnlMain.Controls.Add(this.cmbSelOftenSpends);
            this.pnlMain.Controls.Add(this.btnPDFCreator);
            this.pnlMain.Controls.Add(this.lnkYearReport);
            this.pnlMain.Controls.Add(this.btnRunReports);
            this.pnlMain.Controls.Add(this.txtReportsSpends);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtSelectYear);
            this.pnlMain.Controls.Add(this.btnListYears);
            this.pnlMain.Controls.Add(this.label19);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Controls.Add(this.label20);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(644, 761);
            this.pnlMain.TabIndex = 0;
            // 
            // cmbSelOftenSpends
            // 
            this.cmbSelOftenSpends.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSelOftenSpends.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelOftenSpends.FormattingEnabled = true;
            this.cmbSelOftenSpends.Location = new System.Drawing.Point(239, 129);
            this.cmbSelOftenSpends.Name = "cmbSelOftenSpends";
            this.cmbSelOftenSpends.Size = new System.Drawing.Size(283, 24);
            this.cmbSelOftenSpends.TabIndex = 128;
            // 
            // btnPDFCreator
            // 
            this.btnPDFCreator.BackgroundImage = global::RunningReports.Properties.Resources.Stampante;
            this.btnPDFCreator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPDFCreator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDFCreator.ForeColor = System.Drawing.Color.Green;
            this.btnPDFCreator.Location = new System.Drawing.Point(22, 686);
            this.btnPDFCreator.Margin = new System.Windows.Forms.Padding(0);
            this.btnPDFCreator.Name = "btnPDFCreator";
            this.btnPDFCreator.Size = new System.Drawing.Size(43, 43);
            this.btnPDFCreator.TabIndex = 127;
            this.btnPDFCreator.UseVisualStyleBackColor = true;
            this.btnPDFCreator.Click += new System.EventHandler(this.btnPDFCreator_Click);
            // 
            // lnkYearReport
            // 
            this.lnkYearReport.AutoSize = true;
            this.lnkYearReport.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkYearReport.Location = new System.Drawing.Point(12, 9);
            this.lnkYearReport.Name = "lnkYearReport";
            this.lnkYearReport.Size = new System.Drawing.Size(91, 15);
            this.lnkYearReport.TabIndex = 126;
            this.lnkYearReport.TabStop = true;
            this.lnkYearReport.Text = "Report Annuale";
            this.lnkYearReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkYearReport_LinkClicked);
            // 
            // btnRunReports
            // 
            this.btnRunReports.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRunReports.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRunReports.BorderColor = System.Drawing.Color.Aqua;
            this.btnRunReports.BorderRadius = 11;
            this.btnRunReports.BorderSize = 1;
            this.btnRunReports.FlatAppearance.BorderSize = 0;
            this.btnRunReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunReports.ForeColor = System.Drawing.Color.White;
            this.btnRunReports.GradientAngle = 90F;
            this.btnRunReports.GrdtBottom = System.Drawing.Color.Empty;
            this.btnRunReports.Image = global::RunningReports.Properties.Resources.imagesRep1;
            this.btnRunReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunReports.Location = new System.Drawing.Point(504, 175);
            this.btnRunReports.Name = "btnRunReports";
            this.btnRunReports.Size = new System.Drawing.Size(118, 25);
            this.btnRunReports.TabIndex = 125;
            this.btnRunReports.Text = "Esegui report";
            this.btnRunReports.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRunReports.TextColor = System.Drawing.Color.White;
            this.btnRunReports.UseVisualStyleBackColor = false;
            this.btnRunReports.Click += new System.EventHandler(this.btnRunReports_Click);
            // 
            // txtReportsSpends
            // 
            this.txtReportsSpends.BackColor = System.Drawing.SystemColors.Control;
            this.txtReportsSpends.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.txtReportsSpends.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtReportsSpends.BorderRadius = 10;
            this.txtReportsSpends.BorderSize = 1;
            this.txtReportsSpends.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportsSpends.Location = new System.Drawing.Point(22, 259);
            this.txtReportsSpends.Multiline = true;
            this.txtReportsSpends.Name = "txtReportsSpends";
            this.txtReportsSpends.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtReportsSpends.PasswordChar = false;
            this.txtReportsSpends.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtReportsSpends.PlaceholderText = "";
            this.txtReportsSpends.ReadOnly = true;
            this.txtReportsSpends.Size = new System.Drawing.Size(600, 402);
            this.txtReportsSpends.TabIndex = 124;
            this.txtReportsSpends.Texts = "";
            this.txtReportsSpends.UnderlinedStyle = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 18);
            this.label2.TabIndex = 120;
            this.label2.Text = "REPORT ESEGUITO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 117;
            this.label1.Text = "Seleziona Voce di Spesa";
            // 
            // txtSelectYear
            // 
            this.txtSelectYear.BorderColor = System.Drawing.Color.DimGray;
            this.txtSelectYear.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtSelectYear.BorderRadius = 10;
            this.txtSelectYear.BorderSize = 1;
            this.txtSelectYear.Location = new System.Drawing.Point(21, 126);
            this.txtSelectYear.Multiline = false;
            this.txtSelectYear.Name = "txtSelectYear";
            this.txtSelectYear.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtSelectYear.PasswordChar = false;
            this.txtSelectYear.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSelectYear.PlaceholderText = "";
            this.txtSelectYear.ReadOnly = false;
            this.txtSelectYear.Size = new System.Drawing.Size(102, 28);
            this.txtSelectYear.TabIndex = 116;
            this.txtSelectYear.Texts = "";
            this.txtSelectYear.UnderlinedStyle = false;
            this.txtSelectYear.Enter += new System.EventHandler(this.txtSelectYear_Enter);
            this.txtSelectYear.Leave += new System.EventHandler(this.txtSelectYear_Leave);
            // 
            // btnListYears
            // 
            this.btnListYears.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnListYears.BackgroundImage = global::RunningReports.Properties.Resources.img_lookup_over;
            this.btnListYears.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnListYears.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListYears.Location = new System.Drawing.Point(137, 122);
            this.btnListYears.Name = "btnListYears";
            this.btnListYears.Size = new System.Drawing.Size(31, 33);
            this.btnListYears.TabIndex = 115;
            this.btnListYears.UseVisualStyleBackColor = false;
            this.btnListYears.Click += new System.EventHandler(this.btnListYears_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 101);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 18);
            this.label19.TabIndex = 114;
            this.label19.Text = "Seleziona anno";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::RunningReports.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Green;
            this.btnExit.Location = new System.Drawing.Point(579, 9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 26);
            this.btnExit.TabIndex = 113;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label20.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(247, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(142, 18);
            this.label20.TabIndex = 111;
            this.label20.Text = "REPORT SPESE ";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.DimGray;
            this.roundedPanel1.BackgroundColor = System.Drawing.Color.DimGray;
            this.roundedPanel1.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel1.BorderRadius = 5;
            this.roundedPanel1.BorderSize = 1;
            this.roundedPanel1.GradientAngle = 90F;
            this.roundedPanel1.GrdtBottom = System.Drawing.Color.DimGray;
            this.roundedPanel1.GrdtTop = System.Drawing.Color.DimGray;
            this.roundedPanel1.Location = new System.Drawing.Point(22, 74);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(600, 6);
            this.roundedPanel1.TabIndex = 129;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.DimGray;
            this.roundedPanel2.BackgroundColor = System.Drawing.Color.DimGray;
            this.roundedPanel2.BorderColor = System.Drawing.Color.LightGray;
            this.roundedPanel2.BorderRadius = 5;
            this.roundedPanel2.BorderSize = 1;
            this.roundedPanel2.GradientAngle = 90F;
            this.roundedPanel2.GrdtBottom = System.Drawing.Color.DimGray;
            this.roundedPanel2.GrdtTop = System.Drawing.Color.DimGray;
            this.roundedPanel2.Location = new System.Drawing.Point(22, 206);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(600, 6);
            this.roundedPanel2.TabIndex = 130;
            // 
            // frmSpendElements
            // 
            this.AcceptButton = this.btnRunReports;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 761);
            this.Controls.Add(this.pnlMain);
            this.MaximumSize = new System.Drawing.Size(660, 800);
            this.Name = "frmSpendElements";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSpendElements";
            this.Load += new System.EventHandler(this.frmSpendElements_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private RoundendControlCollections.RoundedTextBox txtSelectYear;
        private System.Windows.Forms.Button btnListYears;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label2;
        private RoundendControlCollections.RoundedTextBox txtReportsSpends;
        private RoundendControlCollections.RoundedButton btnRunReports;
        private System.Windows.Forms.LinkLabel lnkYearReport;
        private System.Windows.Forms.Button btnPDFCreator;
        private RoundendControlCollections.CustomComboBox cmbSelOftenSpends;
        private RoundendControlCollections.RoundedPanel roundedPanel2;
        private RoundendControlCollections.RoundedPanel roundedPanel1;
    }
}