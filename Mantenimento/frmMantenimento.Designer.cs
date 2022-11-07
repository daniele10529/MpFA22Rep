namespace Mantenimento
{
    partial class frmMantenimento
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ANNI   ");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.pgHome = new System.Windows.Forms.TabPage();
            this.roundedPanel3 = new RoundendControlCollections.RoundedPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.roundedPanel1 = new RoundendControlCollections.RoundedPanel();
            this.txtYearInsert = new RoundendControlCollections.RoundedTextBox();
            this.btnNewYears = new System.Windows.Forms.Button();
            this.btnLoadYears = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblGrAnni = new System.Windows.Forms.Label();
            this.pgInsert = new System.Windows.Forms.TabPage();
            this.roundedPanel5 = new RoundendControlCollections.RoundedPanel();
            this.btnSetOftenValue = new RoundendControlCollections.RoundedButton();
            this.txtImport = new RoundendControlCollections.RoundedTextBox();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtCause = new RoundendControlCollections.RoundedTextBox();
            this.lblMese = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pgModify = new System.Windows.Forms.TabPage();
            this.roundedPanel7 = new RoundendControlCollections.RoundedPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnModifyRow = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pgSearch = new System.Windows.Forms.TabPage();
            this.roundedPanel8 = new RoundendControlCollections.RoundedPanel();
            this.txtSearchVoice = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.treeYears = new System.Windows.Forms.TreeView();
            this.label15 = new System.Windows.Forms.Label();
            this.btnNewYear2 = new System.Windows.Forms.Button();
            this.btnLoadYears2 = new System.Windows.Forms.Button();
            this.pnlResume = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.lblSaldoFine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtYearMonth = new System.Windows.Forms.TextBox();
            this.pnlFooter = new RoundendControlCollections.RoundedPanel();
            this.pnlGrid = new RoundendControlCollections.RoundedPanel();
            this.grdKeepingVoices = new System.Windows.Forms.DataGridView();
            this.pnlMenu.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.pgHome.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pgInsert.SuspendLayout();
            this.roundedPanel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.pgModify.SuspendLayout();
            this.roundedPanel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.pgSearch.SuspendLayout();
            this.roundedPanel8.SuspendLayout();
            this.panel11.SuspendLayout();
            this.pnlTree.SuspendLayout();
            this.pnlResume.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKeepingVoices)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.tabMenu);
            this.pnlMenu.Location = new System.Drawing.Point(1, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(1);
            this.pnlMenu.Size = new System.Drawing.Size(1367, 120);
            this.pnlMenu.TabIndex = 1;
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.pgHome);
            this.tabMenu.Controls.Add(this.pgInsert);
            this.tabMenu.Controls.Add(this.pgModify);
            this.tabMenu.Controls.Add(this.pgSearch);
            this.tabMenu.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenu.Location = new System.Drawing.Point(1, 1);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1359, 115);
            this.tabMenu.TabIndex = 2;
            // 
            // pgHome
            // 
            this.pgHome.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgHome.Controls.Add(this.roundedPanel3);
            this.pgHome.Controls.Add(this.roundedPanel1);
            this.pgHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgHome.Location = new System.Drawing.Point(4, 25);
            this.pgHome.Name = "pgHome";
            this.pgHome.Padding = new System.Windows.Forms.Padding(3);
            this.pgHome.Size = new System.Drawing.Size(1351, 86);
            this.pgHome.TabIndex = 0;
            this.pgHome.Text = "Home";
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel3.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel3.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel3.BorderRadius = 2;
            this.roundedPanel3.BorderSize = 2;
            this.roundedPanel3.Controls.Add(this.panel6);
            this.roundedPanel3.Controls.Add(this.btnExit);
            this.roundedPanel3.GradientAngle = 90F;
            this.roundedPanel3.GrdtBottom = System.Drawing.Color.Empty;
            this.roundedPanel3.GrdtTop = System.Drawing.Color.Empty;
            this.roundedPanel3.Location = new System.Drawing.Point(1271, 6);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.roundedPanel3.Size = new System.Drawing.Size(70, 75);
            this.roundedPanel3.TabIndex = 41;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label14);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(64, 23);
            this.panel6.TabIndex = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label14.Location = new System.Drawing.Point(14, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Esci";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::Mantenimento.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Green;
            this.btnExit.Location = new System.Drawing.Point(21, 35);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 26;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel1.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel1.BorderRadius = 2;
            this.roundedPanel1.BorderSize = 2;
            this.roundedPanel1.Controls.Add(this.txtYearInsert);
            this.roundedPanel1.Controls.Add(this.btnNewYears);
            this.roundedPanel1.Controls.Add(this.btnLoadYears);
            this.roundedPanel1.Controls.Add(this.panel5);
            this.roundedPanel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedPanel1.GradientAngle = 90F;
            this.roundedPanel1.GrdtBottom = System.Drawing.Color.Empty;
            this.roundedPanel1.GrdtTop = System.Drawing.Color.Empty;
            this.roundedPanel1.Location = new System.Drawing.Point(180, 6);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.roundedPanel1.Size = new System.Drawing.Size(984, 75);
            this.roundedPanel1.TabIndex = 0;
            // 
            // txtYearInsert
            // 
            this.txtYearInsert.BackColor = System.Drawing.Color.White;
            this.txtYearInsert.BorderColor = System.Drawing.Color.DimGray;
            this.txtYearInsert.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtYearInsert.BorderRadius = 10;
            this.txtYearInsert.BorderSize = 1;
            this.txtYearInsert.Location = new System.Drawing.Point(63, 34);
            this.txtYearInsert.Multiline = false;
            this.txtYearInsert.Name = "txtYearInsert";
            this.txtYearInsert.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtYearInsert.PasswordChar = false;
            this.txtYearInsert.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtYearInsert.PlaceholderText = "";
            this.txtYearInsert.ReadOnly = false;
            this.txtYearInsert.Size = new System.Drawing.Size(79, 31);
            this.txtYearInsert.TabIndex = 12;
            this.txtYearInsert.Texts = "";
            this.txtYearInsert.UnderlinedStyle = false;
            this.txtYearInsert.Enter += new System.EventHandler(this.txtYearInsert_Enter);
            this.txtYearInsert.Leave += new System.EventHandler(this.txtYearInsert_Leave);
            // 
            // btnNewYears
            // 
            this.btnNewYears.BackgroundImage = global::Mantenimento.Properties.Resources.Nuovo;
            this.btnNewYears.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewYears.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewYears.ForeColor = System.Drawing.Color.Green;
            this.btnNewYears.Location = new System.Drawing.Point(18, 35);
            this.btnNewYears.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewYears.Name = "btnNewYears";
            this.btnNewYears.Size = new System.Drawing.Size(30, 30);
            this.btnNewYears.TabIndex = 9;
            this.btnNewYears.UseVisualStyleBackColor = true;
            this.btnNewYears.Click += new System.EventHandler(this.btnNewYear_Click);
            // 
            // btnLoadYears
            // 
            this.btnLoadYears.BackgroundImage = global::Mantenimento.Properties.Resources.Aggiorna;
            this.btnLoadYears.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadYears.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadYears.ForeColor = System.Drawing.Color.Green;
            this.btnLoadYears.Location = new System.Drawing.Point(158, 35);
            this.btnLoadYears.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadYears.Name = "btnLoadYears";
            this.btnLoadYears.Size = new System.Drawing.Size(30, 30);
            this.btnLoadYears.TabIndex = 10;
            this.btnLoadYears.UseVisualStyleBackColor = true;
            this.btnLoadYears.Click += new System.EventHandler(this.btnLoadYears_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblGrAnni);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(978, 23);
            this.panel5.TabIndex = 1;
            // 
            // lblGrAnni
            // 
            this.lblGrAnni.AutoSize = true;
            this.lblGrAnni.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrAnni.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblGrAnni.Location = new System.Drawing.Point(14, 3);
            this.lblGrAnni.Name = "lblGrAnni";
            this.lblGrAnni.Size = new System.Drawing.Size(30, 16);
            this.lblGrAnni.TabIndex = 0;
            this.lblGrAnni.Text = "File";
            // 
            // pgInsert
            // 
            this.pgInsert.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgInsert.Controls.Add(this.roundedPanel5);
            this.pgInsert.Location = new System.Drawing.Point(4, 25);
            this.pgInsert.Name = "pgInsert";
            this.pgInsert.Padding = new System.Windows.Forms.Padding(3);
            this.pgInsert.Size = new System.Drawing.Size(1351, 86);
            this.pgInsert.TabIndex = 1;
            this.pgInsert.Text = "Inserisci";
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel5.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel5.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel5.BorderRadius = 2;
            this.roundedPanel5.BorderSize = 2;
            this.roundedPanel5.Controls.Add(this.btnSetOftenValue);
            this.roundedPanel5.Controls.Add(this.txtImport);
            this.roundedPanel5.Controls.Add(this.cmbMonths);
            this.roundedPanel5.Controls.Add(this.btnInsert);
            this.roundedPanel5.Controls.Add(this.txtCause);
            this.roundedPanel5.Controls.Add(this.lblMese);
            this.roundedPanel5.Controls.Add(this.label2);
            this.roundedPanel5.Controls.Add(this.label4);
            this.roundedPanel5.Controls.Add(this.panel8);
            this.roundedPanel5.GradientAngle = 90F;
            this.roundedPanel5.GrdtBottom = System.Drawing.Color.Empty;
            this.roundedPanel5.GrdtTop = System.Drawing.Color.Empty;
            this.roundedPanel5.Location = new System.Drawing.Point(180, 3);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.Padding = new System.Windows.Forms.Padding(3);
            this.roundedPanel5.Size = new System.Drawing.Size(991, 80);
            this.roundedPanel5.TabIndex = 56;
            // 
            // btnSetOftenValue
            // 
            this.btnSetOftenValue.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSetOftenValue.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.btnSetOftenValue.BorderColor = System.Drawing.Color.Cyan;
            this.btnSetOftenValue.BorderRadius = 10;
            this.btnSetOftenValue.BorderSize = 1;
            this.btnSetOftenValue.FlatAppearance.BorderSize = 0;
            this.btnSetOftenValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOftenValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetOftenValue.ForeColor = System.Drawing.Color.White;
            this.btnSetOftenValue.GradientAngle = 90F;
            this.btnSetOftenValue.GrdtBottom = System.Drawing.Color.LightCyan;
            this.btnSetOftenValue.Location = new System.Drawing.Point(748, 49);
            this.btnSetOftenValue.Name = "btnSetOftenValue";
            this.btnSetOftenValue.Size = new System.Drawing.Size(43, 23);
            this.btnSetOftenValue.TabIndex = 53;
            this.btnSetOftenValue.Text = "***";
            this.btnSetOftenValue.TextColor = System.Drawing.Color.White;
            this.btnSetOftenValue.UseVisualStyleBackColor = false;
            this.btnSetOftenValue.Click += new System.EventHandler(this.btnSetOftenValue_Click);
            // 
            // txtImport
            // 
            this.txtImport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtImport.BorderColor = System.Drawing.Color.DimGray;
            this.txtImport.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtImport.BorderRadius = 10;
            this.txtImport.BorderSize = 1;
            this.txtImport.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImport.Location = new System.Drawing.Point(804, 43);
            this.txtImport.Multiline = false;
            this.txtImport.Name = "txtImport";
            this.txtImport.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtImport.PasswordChar = false;
            this.txtImport.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtImport.PlaceholderText = "";
            this.txtImport.ReadOnly = false;
            this.txtImport.Size = new System.Drawing.Size(126, 31);
            this.txtImport.TabIndex = 52;
            this.txtImport.Texts = "";
            this.txtImport.UnderlinedStyle = false;
            this.txtImport.Enter += new System.EventHandler(this.txtImport_Enter);
            this.txtImport.Leave += new System.EventHandler(this.txtImport_Leave);
            // 
            // cmbMonths
            // 
            this.cmbMonths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonths.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(6, 46);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(121, 24);
            this.cmbMonths.TabIndex = 50;
            this.cmbMonths.Enter += new System.EventHandler(this.cmbMonths_Enter);
            this.cmbMonths.Leave += new System.EventHandler(this.cmbMonths_Leave);
            // 
            // btnInsert
            // 
            this.btnInsert.BackgroundImage = global::Mantenimento.Properties.Resources.Inserisci;
            this.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.ForeColor = System.Drawing.Color.Green;
            this.btnInsert.Location = new System.Drawing.Point(946, 42);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(30, 30);
            this.btnInsert.TabIndex = 54;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtCause
            // 
            this.txtCause.BackColor = System.Drawing.Color.White;
            this.txtCause.BorderColor = System.Drawing.Color.DimGray;
            this.txtCause.BorderFocusColor = System.Drawing.Color.LightSteelBlue;
            this.txtCause.BorderRadius = 10;
            this.txtCause.BorderSize = 1;
            this.txtCause.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCause.Location = new System.Drawing.Point(143, 43);
            this.txtCause.Multiline = false;
            this.txtCause.Name = "txtCause";
            this.txtCause.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.txtCause.PasswordChar = false;
            this.txtCause.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCause.PlaceholderText = "";
            this.txtCause.ReadOnly = false;
            this.txtCause.Size = new System.Drawing.Size(599, 31);
            this.txtCause.TabIndex = 51;
            this.txtCause.Texts = "";
            this.txtCause.UnderlinedStyle = false;
            this.txtCause.Enter += new System.EventHandler(this.txtCause_Enter);
            this.txtCause.Leave += new System.EventHandler(this.txtCause_Leave);
            // 
            // lblMese
            // 
            this.lblMese.AutoSize = true;
            this.lblMese.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblMese.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMese.Location = new System.Drawing.Point(10, 27);
            this.lblMese.Name = "lblMese";
            this.lblMese.Size = new System.Drawing.Size(42, 16);
            this.lblMese.TabIndex = 56;
            this.lblMese.Text = "Mese";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(803, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Importo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 53;
            this.label4.Text = "Causale ";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(985, 23);
            this.panel8.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label5.Location = new System.Drawing.Point(28, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Inserisci";
            // 
            // pgModify
            // 
            this.pgModify.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgModify.Controls.Add(this.roundedPanel7);
            this.pgModify.Location = new System.Drawing.Point(4, 25);
            this.pgModify.Name = "pgModify";
            this.pgModify.Size = new System.Drawing.Size(1351, 86);
            this.pgModify.TabIndex = 2;
            this.pgModify.Text = "Modifica";
            // 
            // roundedPanel7
            // 
            this.roundedPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel7.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel7.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel7.BorderRadius = 2;
            this.roundedPanel7.BorderSize = 2;
            this.roundedPanel7.Controls.Add(this.panel10);
            this.roundedPanel7.Controls.Add(this.btnDeleteRow);
            this.roundedPanel7.Controls.Add(this.btnDown);
            this.roundedPanel7.Controls.Add(this.btnModifyRow);
            this.roundedPanel7.Controls.Add(this.btnUp);
            this.roundedPanel7.GradientAngle = 90F;
            this.roundedPanel7.GrdtBottom = System.Drawing.Color.Empty;
            this.roundedPanel7.GrdtTop = System.Drawing.Color.Empty;
            this.roundedPanel7.Location = new System.Drawing.Point(180, 6);
            this.roundedPanel7.Name = "roundedPanel7";
            this.roundedPanel7.Padding = new System.Windows.Forms.Padding(3);
            this.roundedPanel7.Size = new System.Drawing.Size(985, 75);
            this.roundedPanel7.TabIndex = 45;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(979, 23);
            this.panel10.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label7.Location = new System.Drawing.Point(9, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Opzioni di modifica";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackgroundImage = global::Mantenimento.Properties.Resources.Delete;
            this.btnDeleteRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRow.ForeColor = System.Drawing.Color.Green;
            this.btnDeleteRow.Location = new System.Drawing.Point(16, 34);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteRow.TabIndex = 25;
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::Mantenimento.Properties.Resources.Carica;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.Green;
            this.btnDown.Location = new System.Drawing.Point(202, 34);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 30);
            this.btnDown.TabIndex = 28;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnModifyRow
            // 
            this.btnModifyRow.BackgroundImage = global::Mantenimento.Properties.Resources.pencil_17925;
            this.btnModifyRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModifyRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyRow.ForeColor = System.Drawing.Color.Green;
            this.btnModifyRow.Location = new System.Drawing.Point(78, 34);
            this.btnModifyRow.Name = "btnModifyRow";
            this.btnModifyRow.Size = new System.Drawing.Size(30, 30);
            this.btnModifyRow.TabIndex = 30;
            this.btnModifyRow.UseVisualStyleBackColor = true;
            this.btnModifyRow.Click += new System.EventHandler(this.btnModifyRow_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::Mantenimento.Properties.Resources.Su;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.Green;
            this.btnUp.Location = new System.Drawing.Point(140, 34);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 30);
            this.btnUp.TabIndex = 27;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // pgSearch
            // 
            this.pgSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgSearch.Controls.Add(this.roundedPanel8);
            this.pgSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pgSearch.Location = new System.Drawing.Point(4, 25);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(1351, 86);
            this.pgSearch.TabIndex = 3;
            this.pgSearch.Text = "Cerca";
            // 
            // roundedPanel8
            // 
            this.roundedPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel8.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.roundedPanel8.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel8.BorderRadius = 2;
            this.roundedPanel8.BorderSize = 2;
            this.roundedPanel8.Controls.Add(this.txtSearchVoice);
            this.roundedPanel8.Controls.Add(this.panel11);
            this.roundedPanel8.GradientAngle = 90F;
            this.roundedPanel8.GrdtBottom = System.Drawing.Color.Empty;
            this.roundedPanel8.GrdtTop = System.Drawing.Color.Empty;
            this.roundedPanel8.Location = new System.Drawing.Point(180, 6);
            this.roundedPanel8.Name = "roundedPanel8";
            this.roundedPanel8.Padding = new System.Windows.Forms.Padding(3);
            this.roundedPanel8.Size = new System.Drawing.Size(994, 75);
            this.roundedPanel8.TabIndex = 45;
            // 
            // txtSearchVoice
            // 
            this.txtSearchVoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchVoice.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchVoice.Location = new System.Drawing.Point(6, 36);
            this.txtSearchVoice.Name = "txtSearchVoice";
            this.txtSearchVoice.Size = new System.Drawing.Size(982, 23);
            this.txtSearchVoice.TabIndex = 32;
            this.txtSearchVoice.TextChanged += new System.EventHandler(this.txtSearchVoice_TextChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.label8);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(988, 23);
            this.panel11.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label8.Location = new System.Drawing.Point(9, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cerca";
            // 
            // pnlTree
            // 
            this.pnlTree.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTree.Controls.Add(this.treeYears);
            this.pnlTree.Controls.Add(this.label15);
            this.pnlTree.Controls.Add(this.btnNewYear2);
            this.pnlTree.Controls.Add(this.btnLoadYears2);
            this.pnlTree.Location = new System.Drawing.Point(1, 124);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(182, 730);
            this.pnlTree.TabIndex = 30;
            // 
            // treeYears
            // 
            this.treeYears.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeYears.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeYears.ForeColor = System.Drawing.Color.Indigo;
            this.treeYears.FullRowSelect = true;
            this.treeYears.ItemHeight = 20;
            this.treeYears.LineColor = System.Drawing.Color.LightSteelBlue;
            this.treeYears.Location = new System.Drawing.Point(1, 83);
            this.treeYears.Name = "treeYears";
            treeNode2.BackColor = System.Drawing.Color.AntiqueWhite;
            treeNode2.ForeColor = System.Drawing.Color.DarkSlateGray;
            treeNode2.Name = "nodeYears";
            treeNode2.NodeFont = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "ANNI   ";
            this.treeYears.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeYears.ShowLines = false;
            this.treeYears.ShowNodeToolTips = true;
            this.treeYears.Size = new System.Drawing.Size(177, 645);
            this.treeYears.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(5, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 20);
            this.label15.TabIndex = 37;
            this.label15.Text = "GESTIONE ANNUALE";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewYear2
            // 
            this.btnNewYear2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewYear2.BackgroundImage = global::Mantenimento.Properties.Resources.Nuovo;
            this.btnNewYear2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewYear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewYear2.ForeColor = System.Drawing.Color.Green;
            this.btnNewYear2.Location = new System.Drawing.Point(104, 41);
            this.btnNewYear2.Name = "btnNewYear2";
            this.btnNewYear2.Size = new System.Drawing.Size(30, 30);
            this.btnNewYear2.TabIndex = 32;
            this.btnNewYear2.UseVisualStyleBackColor = false;
            this.btnNewYear2.Click += new System.EventHandler(this.btnNewYear_Click);
            // 
            // btnLoadYears2
            // 
            this.btnLoadYears2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLoadYears2.BackgroundImage = global::Mantenimento.Properties.Resources.Aggiorna;
            this.btnLoadYears2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadYears2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadYears2.ForeColor = System.Drawing.Color.Green;
            this.btnLoadYears2.Location = new System.Drawing.Point(144, 41);
            this.btnLoadYears2.Name = "btnLoadYears2";
            this.btnLoadYears2.Size = new System.Drawing.Size(30, 30);
            this.btnLoadYears2.TabIndex = 31;
            this.btnLoadYears2.UseVisualStyleBackColor = false;
            this.btnLoadYears2.Click += new System.EventHandler(this.btnLoadYears_Click);
            // 
            // pnlResume
            // 
            this.pnlResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResume.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlResume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResume.Controls.Add(this.label16);
            this.pnlResume.Controls.Add(this.pnlStatus);
            this.pnlResume.Controls.Add(this.panel2);
            this.pnlResume.Controls.Add(this.textBox2);
            this.pnlResume.Controls.Add(this.txtBalance);
            this.pnlResume.Controls.Add(this.lblSaldoFine);
            this.pnlResume.Controls.Add(this.panel1);
            this.pnlResume.Location = new System.Drawing.Point(1175, 122);
            this.pnlResume.Name = "pnlResume";
            this.pnlResume.Size = new System.Drawing.Size(190, 730);
            this.pnlResume.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.AntiqueWhite;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 20);
            this.label16.TabIndex = 58;
            this.label16.Text = "DATI CONTABILI";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStatus.Location = new System.Drawing.Point(3, 634);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(181, 23);
            this.pnlStatus.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(5, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 10);
            this.panel2.TabIndex = 40;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(152, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(27, 23);
            this.textBox2.TabIndex = 38;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "€";
            // 
            // txtBalance
            // 
            this.txtBalance.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBalance.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(8, 120);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(146, 23);
            this.txtBalance.TabIndex = 37;
            // 
            // lblSaldoFine
            // 
            this.lblSaldoFine.AutoSize = true;
            this.lblSaldoFine.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoFine.Location = new System.Drawing.Point(5, 99);
            this.lblSaldoFine.Name = "lblSaldoFine";
            this.lblSaldoFine.Size = new System.Drawing.Size(101, 16);
            this.lblSaldoFine.TabIndex = 50;
            this.lblSaldoFine.Text = "Saldo Annuale";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(5, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 10);
            this.panel1.TabIndex = 39;
            // 
            // txtYearMonth
            // 
            this.txtYearMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYearMonth.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtYearMonth.Enabled = false;
            this.txtYearMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtYearMonth.Location = new System.Drawing.Point(189, 31);
            this.txtYearMonth.Name = "txtYearMonth";
            this.txtYearMonth.ReadOnly = true;
            this.txtYearMonth.Size = new System.Drawing.Size(985, 22);
            this.txtYearMonth.TabIndex = 36;
            this.txtYearMonth.TabStop = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFooter.BackgroundColor = System.Drawing.Color.Transparent;
            this.pnlFooter.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFooter.BorderRadius = 10;
            this.pnlFooter.BorderSize = 3;
            this.pnlFooter.Controls.Add(this.txtYearMonth);
            this.pnlFooter.GradientAngle = 90F;
            this.pnlFooter.GrdtBottom = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.GrdtTop = System.Drawing.Color.AntiqueWhite;
            this.pnlFooter.Location = new System.Drawing.Point(1, 858);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1366, 156);
            this.pnlFooter.TabIndex = 39;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.LightGray;
            this.pnlGrid.BackgroundColor = System.Drawing.Color.LightGray;
            this.pnlGrid.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.pnlGrid.BorderRadius = 10;
            this.pnlGrid.BorderSize = 2;
            this.pnlGrid.Controls.Add(this.grdKeepingVoices);
            this.pnlGrid.GradientAngle = 90F;
            this.pnlGrid.GrdtBottom = System.Drawing.Color.WhiteSmoke;
            this.pnlGrid.GrdtTop = System.Drawing.Color.Gainsboro;
            this.pnlGrid.Location = new System.Drawing.Point(184, 124);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(5);
            this.pnlGrid.Size = new System.Drawing.Size(994, 730);
            this.pnlGrid.TabIndex = 44;
            // 
            // grdKeepingVoices
            // 
            this.grdKeepingVoices.AllowUserToAddRows = false;
            this.grdKeepingVoices.AllowUserToResizeRows = false;
            this.grdKeepingVoices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdKeepingVoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdKeepingVoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdKeepingVoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdKeepingVoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdKeepingVoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdKeepingVoices.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdKeepingVoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdKeepingVoices.EnableHeadersVisualStyles = false;
            this.grdKeepingVoices.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.grdKeepingVoices.Location = new System.Drawing.Point(5, 5);
            this.grdKeepingVoices.Margin = new System.Windows.Forms.Padding(5);
            this.grdKeepingVoices.MultiSelect = false;
            this.grdKeepingVoices.Name = "grdKeepingVoices";
            this.grdKeepingVoices.ReadOnly = true;
            this.grdKeepingVoices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdKeepingVoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdKeepingVoices.RowHeadersVisible = false;
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.RoyalBlue;
            this.grdKeepingVoices.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdKeepingVoices.RowTemplate.DividerHeight = 1;
            this.grdKeepingVoices.ShowEditingIcon = false;
            this.grdKeepingVoices.Size = new System.Drawing.Size(984, 720);
            this.grdKeepingVoices.TabIndex = 21;
            this.grdKeepingVoices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdKeepingVoices_KeyPress);
            this.grdKeepingVoices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdKeepingVoices_MouseClick);
            // 
            // frmMantenimento
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1367, 1016);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlResume);
            this.Controls.Add(this.pnlTree);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMantenimento";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANTENIMENTO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMantenimento_FormClosing);
            this.Load += new System.EventHandler(this.frmMantenimento_Load);
            this.pnlMenu.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.pgHome.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pgInsert.ResumeLayout(false);
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.pgModify.ResumeLayout(false);
            this.roundedPanel7.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.pgSearch.ResumeLayout(false);
            this.roundedPanel8.ResumeLayout(false);
            this.roundedPanel8.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.pnlTree.ResumeLayout(false);
            this.pnlTree.PerformLayout();
            this.pnlResume.ResumeLayout(false);
            this.pnlResume.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKeepingVoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage pgHome;
        private System.Windows.Forms.TabPage pgInsert;
        private System.Windows.Forms.TabPage pgModify;
        private System.Windows.Forms.TabPage pgSearch;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Button btnNewYear2;
        private System.Windows.Forms.Button btnLoadYears2;
        private System.Windows.Forms.Panel pnlResume;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblSaldoFine;
        private System.Windows.Forms.Panel panel1;
        private RoundendControlCollections.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblGrAnni;
        private System.Windows.Forms.Button btnNewYears;
        private System.Windows.Forms.Button btnLoadYears;
        private RoundendControlCollections.RoundedTextBox txtYearInsert;
        private RoundendControlCollections.RoundedPanel roundedPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnExit;
        private RoundendControlCollections.RoundedPanel roundedPanel5;
        private RoundendControlCollections.RoundedButton btnSetOftenValue;
        private RoundendControlCollections.RoundedTextBox txtImport;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.Button btnInsert;
        private RoundendControlCollections.RoundedTextBox txtCause;
        private System.Windows.Forms.Label lblMese;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
        private RoundendControlCollections.RoundedPanel roundedPanel7;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnModifyRow;
        private System.Windows.Forms.Button btnUp;
        private RoundendControlCollections.RoundedPanel roundedPanel8;
        private System.Windows.Forms.TextBox txtSearchVoice;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TreeView treeYears;
        private System.Windows.Forms.TextBox txtYearMonth;
        private RoundendControlCollections.RoundedPanel pnlFooter;
        private RoundendControlCollections.RoundedPanel pnlGrid;
        private System.Windows.Forms.DataGridView grdKeepingVoices;
    }
}

