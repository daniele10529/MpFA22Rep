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
            this.pnlStart = new System.Windows.Forms.Panel();
            this.btnSetStart = new System.Windows.Forms.Button();
            this.pnlMenuStart = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlManageDB = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDB = new System.Windows.Forms.Panel();
            this.btnDump = new System.Windows.Forms.Button();
            this.btnSetPathDump = new System.Windows.Forms.Button();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.btnChange = new System.Windows.Forms.Button();
            this.txPathDump = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlStart.SuspendLayout();
            this.pnlMenuStart.SuspendLayout();
            this.pnlManageDB.SuspendLayout();
            this.pnlDB.SuspendLayout();
            this.pnlSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStart
            // 
            this.pnlStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStart.AutoSize = true;
            this.pnlStart.BackColor = System.Drawing.Color.DimGray;
            this.pnlStart.Controls.Add(this.btnSetStart);
            this.pnlStart.ForeColor = System.Drawing.Color.Indigo;
            this.pnlStart.Location = new System.Drawing.Point(0, 39);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(642, 124);
            this.pnlStart.TabIndex = 1;
            // 
            // btnSetStart
            // 
            this.btnSetStart.AutoSize = true;
            this.btnSetStart.BackColor = System.Drawing.Color.DarkGray;
            this.btnSetStart.BackgroundImage = global::SpeseAnnuali.Properties.Resources.settings2;
            this.btnSetStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetStart.FlatAppearance.BorderSize = 0;
            this.btnSetStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetStart.Location = new System.Drawing.Point(3, 6);
            this.btnSetStart.Name = "btnSetStart";
            this.btnSetStart.Size = new System.Drawing.Size(143, 114);
            this.btnSetStart.TabIndex = 0;
            this.btnSetStart.Text = "Set valori iniziali";
            this.btnSetStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSetStart.UseVisualStyleBackColor = false;
            this.btnSetStart.Click += new System.EventHandler(this.btnSetStart_Click);
            // 
            // pnlMenuStart
            // 
            this.pnlMenuStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenuStart.BackColor = System.Drawing.Color.DimGray;
            this.pnlMenuStart.Controls.Add(this.label1);
            this.pnlMenuStart.Location = new System.Drawing.Point(0, -3);
            this.pnlMenuStart.Name = "pnlMenuStart";
            this.pnlMenuStart.Size = new System.Drawing.Size(639, 42);
            this.pnlMenuStart.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(200, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "STARTING SETTING";
            // 
            // pnlManageDB
            // 
            this.pnlManageDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlManageDB.BackColor = System.Drawing.Color.DimGray;
            this.pnlManageDB.Controls.Add(this.label2);
            this.pnlManageDB.Location = new System.Drawing.Point(0, 163);
            this.pnlManageDB.Name = "pnlManageDB";
            this.pnlManageDB.Size = new System.Drawing.Size(639, 42);
            this.pnlManageDB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(200, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "GESTIONE DB";
            // 
            // pnlDB
            // 
            this.pnlDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDB.AutoSize = true;
            this.pnlDB.BackColor = System.Drawing.Color.DimGray;
            this.pnlDB.Controls.Add(this.btnDump);
            this.pnlDB.Controls.Add(this.btnSetPathDump);
            this.pnlDB.ForeColor = System.Drawing.Color.Indigo;
            this.pnlDB.Location = new System.Drawing.Point(-1, 205);
            this.pnlDB.Name = "pnlDB";
            this.pnlDB.Size = new System.Drawing.Size(642, 121);
            this.pnlDB.TabIndex = 4;
            // 
            // btnDump
            // 
            this.btnDump.BackColor = System.Drawing.Color.DarkGray;
            this.btnDump.BackgroundImage = global::SpeseAnnuali.Properties.Resources.dump;
            this.btnDump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDump.Location = new System.Drawing.Point(153, 4);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(143, 114);
            this.btnDump.TabIndex = 2;
            this.btnDump.Text = "Esegui dump";
            this.btnDump.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDump.UseVisualStyleBackColor = false;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // btnSetPathDump
            // 
            this.btnSetPathDump.AutoSize = true;
            this.btnSetPathDump.BackColor = System.Drawing.Color.DarkGray;
            this.btnSetPathDump.BackgroundImage = global::SpeseAnnuali.Properties.Resources.settings2;
            this.btnSetPathDump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetPathDump.FlatAppearance.BorderSize = 0;
            this.btnSetPathDump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPathDump.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPathDump.Location = new System.Drawing.Point(4, 4);
            this.btnSetPathDump.Name = "btnSetPathDump";
            this.btnSetPathDump.Size = new System.Drawing.Size(143, 114);
            this.btnSetPathDump.TabIndex = 1;
            this.btnSetPathDump.Text = "Set Path Dump";
            this.btnSetPathDump.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSetPathDump.UseVisualStyleBackColor = false;
            this.btnSetPathDump.Click += new System.EventHandler(this.btnSetPathDump_Click);
            // 
            // pnlSet
            // 
            this.pnlSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSet.AutoSize = true;
            this.pnlSet.BackColor = System.Drawing.Color.DimGray;
            this.pnlSet.Controls.Add(this.btnChange);
            this.pnlSet.Controls.Add(this.txPathDump);
            this.pnlSet.Controls.Add(this.btnExit);
            this.pnlSet.ForeColor = System.Drawing.Color.Indigo;
            this.pnlSet.Location = new System.Drawing.Point(0, 322);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(639, 231);
            this.pnlSet.TabIndex = 5;
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnChange.BackgroundImage = global::SpeseAnnuali.Properties.Resources.Salva;
            this.btnChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(599, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(37, 27);
            this.btnChange.TabIndex = 3;
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txPathDump
            // 
            this.txPathDump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txPathDump.BackColor = System.Drawing.Color.Gainsboro;
            this.txPathDump.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPathDump.ForeColor = System.Drawing.Color.Teal;
            this.txPathDump.Location = new System.Drawing.Point(-1, 3);
            this.txPathDump.Name = "txPathDump";
            this.txPathDump.Size = new System.Drawing.Size(594, 27);
            this.txPathDump.TabIndex = 2;
            this.txPathDump.TextChanged += new System.EventHandler(this.txPathDump_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = global::SpeseAnnuali.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(464, 107);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 114);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Chiudi";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(639, 554);
            this.Controls.Add(this.pnlSet);
            this.Controls.Add(this.pnlDB);
            this.Controls.Add(this.pnlManageDB);
            this.Controls.Add(this.pnlMenuStart);
            this.Controls.Add(this.pnlStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.pnlStart.ResumeLayout(false);
            this.pnlStart.PerformLayout();
            this.pnlMenuStart.ResumeLayout(false);
            this.pnlMenuStart.PerformLayout();
            this.pnlManageDB.ResumeLayout(false);
            this.pnlManageDB.PerformLayout();
            this.pnlDB.ResumeLayout(false);
            this.pnlDB.PerformLayout();
            this.pnlSet.ResumeLayout(false);
            this.pnlSet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Panel pnlMenuStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlManageDB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDB;
        private System.Windows.Forms.Panel pnlSet;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSetPathDump;
        private System.Windows.Forms.TextBox txPathDump;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDump;
    }
}