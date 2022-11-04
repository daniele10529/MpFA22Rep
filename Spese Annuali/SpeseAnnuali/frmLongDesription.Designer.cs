namespace MpFA20
{
    partial class frmLongDesription
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtLongDesription = new RoundendControlCollections.RoundedTextBox();
            this.btnClose = new RoundendControlCollections.RoundedButton();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.LightGray;
            this.pnlMain.BackgroundColor = System.Drawing.Color.LightGray;
            this.pnlMain.BorderColor = System.Drawing.Color.PaleTurquoise;
            this.pnlMain.BorderRadius = 10;
            this.pnlMain.BorderSize = 1;
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Controls.Add(this.txtLongDesription);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.GradientAngle = 90F;
            this.pnlMain.GrdtBottom = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.GrdtTop = System.Drawing.Color.AntiqueWhite;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(242, 187);
            this.pnlMain.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "LONG DESCRIPTION";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLongDesription
            // 
            this.txtLongDesription.BackColor = System.Drawing.Color.White;
            this.txtLongDesription.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.txtLongDesription.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtLongDesription.BorderRadius = 10;
            this.txtLongDesription.BorderSize = 1;
            this.txtLongDesription.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLongDesription.Location = new System.Drawing.Point(6, 39);
            this.txtLongDesription.Multiline = true;
            this.txtLongDesription.Name = "txtLongDesription";
            this.txtLongDesription.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtLongDesription.PasswordChar = false;
            this.txtLongDesription.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtLongDesription.PlaceholderText = "";
            this.txtLongDesription.ReadOnly = false;
            this.txtLongDesription.Size = new System.Drawing.Size(230, 101);
            this.txtLongDesription.TabIndex = 24;
            this.txtLongDesription.Texts = "";
            this.txtLongDesription.UnderlinedStyle = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnClose.BackgroundImage = global::MpFA20.Properties.Resources.Exit;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderColor = System.Drawing.Color.Turquoise;
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderSize = 1;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.GradientAngle = 90F;
            this.btnClose.GrdtBottom = System.Drawing.Color.Empty;
            this.btnClose.Location = new System.Drawing.Point(200, 146);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 25;
            this.btnClose.TextColor = System.Drawing.Color.White;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLongDesription
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 187);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLongDesription";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmLongDesription";
            this.Load += new System.EventHandler(this.frmLongDesription_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundendControlCollections.RoundedPanel pnlMain;
        private RoundendControlCollections.RoundedTextBox txtLongDesription;
        private System.Windows.Forms.Label label5;
        private RoundendControlCollections.RoundedButton btnClose;
    }
}