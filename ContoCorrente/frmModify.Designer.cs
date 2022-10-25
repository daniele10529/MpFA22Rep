namespace ContoCorrente
{
    partial class frmModify
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
            this.pnlMain = new RoundendControlCollections.RoundedPanel();
            this.btnClose = new RoundendControlCollections.RoundedButton();
            this.btnModify = new RoundendControlCollections.RoundedButton();
            this.btnPlus = new RoundendControlCollections.RoundedButton();
            this.txtImport = new RoundendControlCollections.RoundedTextBox();
            this.txtCause = new RoundendControlCollections.RoundedTextBox();
            this.txtId = new RoundendControlCollections.RoundedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtDay = new RoundendControlCollections.RoundedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnlMain.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain.BorderRadius = 15;
            this.pnlMain.BorderSize = 1;
            this.pnlMain.Controls.Add(this.txtDay);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.btnModify);
            this.pnlMain.Controls.Add(this.btnPlus);
            this.pnlMain.Controls.Add(this.txtImport);
            this.pnlMain.Controls.Add(this.txtCause);
            this.pnlMain.Controls.Add(this.txtId);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.Label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.GradientAngle = 90F;
            this.pnlMain.GrdtBottom = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.GrdtTop = System.Drawing.Color.AntiqueWhite;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(365, 488);
            this.pnlMain.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.BackgroundImage = global::ContoCorrente.Properties.Resources.Exit;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderColor = System.Drawing.Color.Turquoise;
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderSize = 1;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.GradientAngle = 90F;
            this.btnClose.GrdtBottom = System.Drawing.Color.Empty;
            this.btnClose.Location = new System.Drawing.Point(323, 446);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 6;
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnModify
            // 
            this.btnModify.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnModify.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnModify.BorderColor = System.Drawing.Color.Turquoise;
            this.btnModify.BorderRadius = 10;
            this.btnModify.BorderSize = 1;
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModify.ForeColor = System.Drawing.Color.White;
            this.btnModify.GradientAngle = 90F;
            this.btnModify.GrdtBottom = System.Drawing.Color.Empty;
            this.btnModify.Image = global::ContoCorrente.Properties.Resources.pencil_piccola;
            this.btnModify.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModify.Location = new System.Drawing.Point(216, 446);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(88, 30);
            this.btnModify.TabIndex = 5;
            this.btnModify.Text = "Modifica";
            this.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify.TextColor = System.Drawing.Color.White;
            this.btnModify.UseVisualStyleBackColor = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlus.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnPlus.BorderColor = System.Drawing.Color.Cyan;
            this.btnPlus.BorderRadius = 10;
            this.btnPlus.BorderSize = 1;
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnPlus.GradientAngle = 90F;
            this.btnPlus.GrdtBottom = System.Drawing.Color.Empty;
            this.btnPlus.Location = new System.Drawing.Point(274, 325);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(30, 30);
            this.btnPlus.TabIndex = 4;
            this.btnPlus.Text = "+";
            this.btnPlus.TextColor = System.Drawing.Color.BlueViolet;
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // txtImport
            // 
            this.txtImport.BackColor = System.Drawing.Color.White;
            this.txtImport.BorderColor = System.Drawing.Color.DimGray;
            this.txtImport.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtImport.BorderRadius = 5;
            this.txtImport.BorderSize = 1;
            this.txtImport.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImport.Location = new System.Drawing.Point(12, 325);
            this.txtImport.Multiline = false;
            this.txtImport.Name = "txtImport";
            this.txtImport.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtImport.PasswordChar = false;
            this.txtImport.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtImport.PlaceholderText = "";
            this.txtImport.ReadOnly = false;
            this.txtImport.Size = new System.Drawing.Size(250, 31);
            this.txtImport.TabIndex = 3;
            this.txtImport.Texts = "";
            this.txtImport.UnderlinedStyle = false;
            this.txtImport.Enter += new System.EventHandler(this.txtImport_Enter);
            this.txtImport.Leave += new System.EventHandler(this.txtImport_Leave);
            // 
            // txtCause
            // 
            this.txtCause.BackColor = System.Drawing.Color.White;
            this.txtCause.BorderColor = System.Drawing.Color.DimGray;
            this.txtCause.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtCause.BorderRadius = 5;
            this.txtCause.BorderSize = 1;
            this.txtCause.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCause.Location = new System.Drawing.Point(12, 240);
            this.txtCause.Multiline = false;
            this.txtCause.Name = "txtCause";
            this.txtCause.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCause.PasswordChar = false;
            this.txtCause.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCause.PlaceholderText = "";
            this.txtCause.ReadOnly = false;
            this.txtCause.Size = new System.Drawing.Size(341, 31);
            this.txtCause.TabIndex = 1;
            this.txtCause.Texts = "";
            this.txtCause.UnderlinedStyle = false;
            this.txtCause.Enter += new System.EventHandler(this.txtCause_Enter);
            this.txtCause.Leave += new System.EventHandler(this.txtCause_Leave);
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtId.BorderColor = System.Drawing.Color.DimGray;
            this.txtId.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtId.BorderRadius = 10;
            this.txtId.BorderSize = 1;
            this.txtId.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtId.Location = new System.Drawing.Point(12, 84);
            this.txtId.Multiline = false;
            this.txtId.Name = "txtId";
            this.txtId.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtId.PasswordChar = false;
            this.txtId.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtId.PlaceholderText = "";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(95, 31);
            this.txtId.TabIndex = 23;
            this.txtId.TabStop = false;
            this.txtId.Texts = "";
            this.txtId.UnderlinedStyle = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(116, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 22;
            this.label5.Text = "MODIFICA RIGA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 299);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "IMPORTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "CAUSALE";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 66);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(21, 15);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "ID";
            // 
            // txtDay
            // 
            this.txtDay.BackColor = System.Drawing.Color.White;
            this.txtDay.BorderColor = System.Drawing.Color.DimGray;
            this.txtDay.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtDay.BorderRadius = 5;
            this.txtDay.BorderSize = 1;
            this.txtDay.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDay.Location = new System.Drawing.Point(12, 161);
            this.txtDay.Multiline = false;
            this.txtDay.Name = "txtDay";
            this.txtDay.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtDay.PasswordChar = false;
            this.txtDay.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtDay.PlaceholderText = "";
            this.txtDay.ReadOnly = false;
            this.txtDay.Size = new System.Drawing.Size(101, 31);
            this.txtDay.TabIndex = 24;
            this.txtDay.Texts = "";
            this.txtDay.UnderlinedStyle = false;
            this.txtDay.Enter += new System.EventHandler(this.txtDay_Enter);
            this.txtDay.Leave += new System.EventHandler(this.txtDay_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "GIORNO";
            // 
            // frmModify
            // 
            this.AcceptButton = this.btnModify;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(365, 488);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmModify";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modifica";
            this.Load += new System.EventHandler(this.frmModify_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundendControlCollections.RoundedPanel pnlMain;
        private RoundendControlCollections.RoundedTextBox txtDay;
        private System.Windows.Forms.Label label6;
        private RoundendControlCollections.RoundedButton btnClose;
        private RoundendControlCollections.RoundedButton btnModify;
        private RoundendControlCollections.RoundedButton btnPlus;
        private RoundendControlCollections.RoundedTextBox txtImport;
        private RoundendControlCollections.RoundedTextBox txtCause;
        private RoundendControlCollections.RoundedTextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Label1;
    }
}