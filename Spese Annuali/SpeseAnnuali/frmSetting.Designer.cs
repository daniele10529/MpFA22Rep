namespace SpeseAnnuali
{
    partial class frmSetting
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
            this.pnlHeader = new RoundendControlCollections.RoundedPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDiv = new RoundendControlCollections.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPathDump = new RoundendControlCollections.RoundedTextBox();
            this.lblSetPath = new System.Windows.Forms.Label();
            this.btnExit = new RoundendControlCollections.RoundedButton();
            this.btnChange = new RoundendControlCollections.RoundedButton();
            this.btnDump = new RoundendControlCollections.RoundedButton();
            this.brnSetPuthDump = new RoundendControlCollections.RoundedButton();
            this.btnSetStart = new RoundendControlCollections.RoundedButton();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnlHeader.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.BorderRadius = 20;
            this.pnlHeader.BorderSize = 2;
            this.pnlHeader.Controls.Add(this.btnExit);
            this.pnlHeader.Controls.Add(this.lblSetPath);
            this.pnlHeader.Controls.Add(this.btnChange);
            this.pnlHeader.Controls.Add(this.txtPathDump);
            this.pnlHeader.Controls.Add(this.btnDump);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.brnSetPuthDump);
            this.pnlHeader.Controls.Add(this.pnlDiv);
            this.pnlHeader.Controls.Add(this.btnSetStart);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.GradientAngle = 90F;
            this.pnlHeader.GrdtBottom = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.GrdtTop = System.Drawing.Color.AntiqueWhite;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(639, 554);
            this.pnlHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IMPOSTAZIONI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(234, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 18);
            this.label3.TabIndex = 11;
            this.label3.Text = "SETTING DATABASE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDiv
            // 
            this.pnlDiv.BackColor = System.Drawing.Color.Black;
            this.pnlDiv.BackgroundColor = System.Drawing.Color.Black;
            this.pnlDiv.BorderColor = System.Drawing.Color.LightGray;
            this.pnlDiv.BorderRadius = 5;
            this.pnlDiv.BorderSize = 1;
            this.pnlDiv.GradientAngle = 90F;
            this.pnlDiv.GrdtBottom = System.Drawing.Color.Empty;
            this.pnlDiv.GrdtTop = System.Drawing.Color.Empty;
            this.pnlDiv.Location = new System.Drawing.Point(19, 171);
            this.pnlDiv.Name = "pnlDiv";
            this.pnlDiv.Size = new System.Drawing.Size(600, 5);
            this.pnlDiv.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "SETTING VALORI INIZIALI";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPathDump
            // 
            this.txtPathDump.BorderColor = System.Drawing.Color.DimGray;
            this.txtPathDump.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtPathDump.BorderRadius = 10;
            this.txtPathDump.BorderSize = 1;
            this.txtPathDump.Location = new System.Drawing.Point(19, 379);
            this.txtPathDump.Multiline = false;
            this.txtPathDump.Name = "txtPathDump";
            this.txtPathDump.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtPathDump.PasswordChar = false;
            this.txtPathDump.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPathDump.PlaceholderText = "";
            this.txtPathDump.ReadOnly = false;
            this.txtPathDump.Size = new System.Drawing.Size(407, 28);
            this.txtPathDump.TabIndex = 13;
            this.txtPathDump.Texts = "";
            this.txtPathDump.UnderlinedStyle = false;
            this.txtPathDump.Enter += new System.EventHandler(this.txtPathDump_Enter);
            this.txtPathDump.Leave += new System.EventHandler(this.txtPathDump_Leave);
            // 
            // lblSetPath
            // 
            this.lblSetPath.AutoSize = true;
            this.lblSetPath.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetPath.Location = new System.Drawing.Point(234, 342);
            this.lblSetPath.Name = "lblSetPath";
            this.lblSetPath.Size = new System.Drawing.Size(177, 18);
            this.lblSetPath.TabIndex = 15;
            this.lblSetPath.Text = "SETTING PATH DUMP";
            this.lblSetPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.BackgroundImage = global::SpeseAnnuali.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.BorderColor = System.Drawing.Color.Turquoise;
            this.btnExit.BorderRadius = 10;
            this.btnExit.BorderSize = 1;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.GradientAngle = 90F;
            this.btnExit.GrdtBottom = System.Drawing.Color.Empty;
            this.btnExit.Location = new System.Drawing.Point(589, 512);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 16;
            this.btnExit.TextColor = System.Drawing.Color.White;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnChange.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnChange.BackgroundImage = global::SpeseAnnuali.Properties.Resources.Salva;
            this.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChange.BorderColor = System.Drawing.Color.Turquoise;
            this.btnChange.BorderRadius = 10;
            this.btnChange.BorderSize = 1;
            this.btnChange.FlatAppearance.BorderSize = 0;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.ForeColor = System.Drawing.Color.White;
            this.btnChange.GradientAngle = 90F;
            this.btnChange.GrdtBottom = System.Drawing.Color.Empty;
            this.btnChange.Location = new System.Drawing.Point(448, 377);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(30, 30);
            this.btnChange.TabIndex = 14;
            this.btnChange.TextColor = System.Drawing.Color.White;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDump.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnDump.BorderColor = System.Drawing.Color.Turquoise;
            this.btnDump.BorderRadius = 10;
            this.btnDump.BorderSize = 1;
            this.btnDump.FlatAppearance.BorderSize = 0;
            this.btnDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDump.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDump.ForeColor = System.Drawing.Color.White;
            this.btnDump.GradientAngle = 90F;
            this.btnDump.GrdtBottom = System.Drawing.Color.Empty;
            this.btnDump.Image = global::SpeseAnnuali.Properties.Resources.dump1;
            this.btnDump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDump.Location = new System.Drawing.Point(177, 242);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(117, 30);
            this.btnDump.TabIndex = 12;
            this.btnDump.Text = "Esegui Dump";
            this.btnDump.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDump.TextColor = System.Drawing.Color.White;
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // brnSetPuthDump
            // 
            this.brnSetPuthDump.BackColor = System.Drawing.Color.LightSteelBlue;
            this.brnSetPuthDump.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.brnSetPuthDump.BorderColor = System.Drawing.Color.Turquoise;
            this.brnSetPuthDump.BorderRadius = 10;
            this.brnSetPuthDump.BorderSize = 1;
            this.brnSetPuthDump.FlatAppearance.BorderSize = 0;
            this.brnSetPuthDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnSetPuthDump.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnSetPuthDump.ForeColor = System.Drawing.Color.White;
            this.brnSetPuthDump.GradientAngle = 90F;
            this.brnSetPuthDump.GrdtBottom = System.Drawing.Color.Empty;
            this.brnSetPuthDump.Image = global::SpeseAnnuali.Properties.Resources.pencil_17925;
            this.brnSetPuthDump.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.brnSetPuthDump.Location = new System.Drawing.Point(20, 242);
            this.brnSetPuthDump.Name = "brnSetPuthDump";
            this.brnSetPuthDump.Size = new System.Drawing.Size(123, 30);
            this.brnSetPuthDump.TabIndex = 10;
            this.brnSetPuthDump.Text = "Set Path Dump";
            this.brnSetPuthDump.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.brnSetPuthDump.TextColor = System.Drawing.Color.White;
            this.brnSetPuthDump.UseVisualStyleBackColor = false;
            this.brnSetPuthDump.Click += new System.EventHandler(this.btnSetPathDump_Click);
            // 
            // btnSetStart
            // 
            this.btnSetStart.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSetStart.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnSetStart.BorderColor = System.Drawing.Color.Turquoise;
            this.btnSetStart.BorderRadius = 10;
            this.btnSetStart.BorderSize = 1;
            this.btnSetStart.FlatAppearance.BorderSize = 0;
            this.btnSetStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetStart.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetStart.ForeColor = System.Drawing.Color.White;
            this.btnSetStart.GradientAngle = 90F;
            this.btnSetStart.GrdtBottom = System.Drawing.Color.Empty;
            this.btnSetStart.Image = global::SpeseAnnuali.Properties.Resources.Impostazioni21;
            this.btnSetStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetStart.Location = new System.Drawing.Point(20, 116);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(146, 31);
            this.btnSetStart.TabIndex = 8;
            this.btnSetStart.Text = "Set Valori Iniziali";
            this.btnSetStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetStart.TextColor = System.Drawing.Color.White;
            this.btnSetStart.UseVisualStyleBackColor = false;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(639, 554);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundendControlCollections.RoundedPanel pnlHeader;
        private System.Windows.Forms.Label label1;
        private RoundendControlCollections.RoundedButton btnExit;
        private System.Windows.Forms.Label lblSetPath;
        private RoundendControlCollections.RoundedButton btnChange;
        private RoundendControlCollections.RoundedTextBox txtPathDump;
        private RoundendControlCollections.RoundedButton btnDump;
        private System.Windows.Forms.Label label3;
        private RoundendControlCollections.RoundedButton brnSetPuthDump;
        private RoundendControlCollections.RoundedPanel pnlDiv;
        private RoundendControlCollections.RoundedButton btnSetStart;
        private System.Windows.Forms.Label label2;
    }
}