namespace RunningReports
{
    partial class frmSarchYear
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectYear = new RoundendControlCollections.RoundedButton();
            this.label16 = new System.Windows.Forms.Label();
            this.grdYear = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYear)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSelectYear);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.grdYear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 261);
            this.panel1.TabIndex = 0;
            // 
            // btnSelectYear
            // 
            this.btnSelectYear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSelectYear.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSelectYear.BorderColor = System.Drawing.Color.Aqua;
            this.btnSelectYear.BorderRadius = 11;
            this.btnSelectYear.BorderSize = 1;
            this.btnSelectYear.FlatAppearance.BorderSize = 0;
            this.btnSelectYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectYear.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectYear.ForeColor = System.Drawing.Color.White;
            this.btnSelectYear.GradientAngle = 90F;
            this.btnSelectYear.GrdtBottom = System.Drawing.Color.Empty;
            this.btnSelectYear.Image = global::RunningReports.Properties.Resources.Salva;
            this.btnSelectYear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectYear.Location = new System.Drawing.Point(140, 218);
            this.btnSelectYear.Name = "btnSelectYear";
            this.btnSelectYear.Size = new System.Drawing.Size(132, 31);
            this.btnSelectYear.TabIndex = 114;
            this.btnSelectYear.Text = "Seleziona anno";
            this.btnSelectYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectYear.TextColor = System.Drawing.Color.White;
            this.btnSelectYear.UseVisualStyleBackColor = false;
            this.btnSelectYear.Click += new System.EventHandler(this.btnSelectYear_Click);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label16.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(12, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 18);
            this.label16.TabIndex = 12;
            this.label16.Text = "Seleziona Anno";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdYear
            // 
            this.grdYear.AllowUserToAddRows = false;
            this.grdYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYear.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdYear.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdYear.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdYear.Location = new System.Drawing.Point(3, 49);
            this.grdYear.Name = "grdYear";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdYear.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdYear.Size = new System.Drawing.Size(278, 140);
            this.grdYear.TabIndex = 0;
            // 
            // frmSarchYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.Name = "frmSarchYear";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleziona Anno";
            this.Load += new System.EventHandler(this.frmSarchYear_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView grdYear;
        private System.Windows.Forms.Label label16;
        private RoundendControlCollections.RoundedButton btnSelectYear;
    }
}