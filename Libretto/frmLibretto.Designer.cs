namespace Libretto
{
    partial class frmLibretto
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ANNI   ");
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.pgHome = new System.Windows.Forms.TabPage();
            this.grpExit = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.gprSave = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.gprYears = new System.Windows.Forms.GroupBox();
            this.btnLoadYears = new System.Windows.Forms.Button();
            this.pgInsert = new System.Windows.Forms.TabPage();
            this.grpSave2 = new System.Windows.Forms.GroupBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.grpInsert = new System.Windows.Forms.GroupBox();
            this.btnSetOftenValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCause = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pgModify = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveThree = new System.Windows.Forms.Button();
            this.grpModiryrow = new System.Windows.Forms.GroupBox();
            this.btnModifyRow = new System.Windows.Forms.Button();
            this.grpMove = new System.Windows.Forms.GroupBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.grpDeleteRow = new System.Windows.Forms.GroupBox();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.pgSearch = new System.Windows.Forms.TabPage();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearchVoice = new System.Windows.Forms.TextBox();
            this.pnlTree = new System.Windows.Forms.Panel();
            this.btnLoadYears2 = new System.Windows.Forms.Button();
            this.treeYears = new System.Windows.Forms.TreeView();
            this.pnlGrd = new System.Windows.Forms.Panel();
            this.grdMovLibVoices = new System.Windows.Forms.DataGridView();
            this.pnlResumeYear = new System.Windows.Forms.Panel();
            this.pnlResume = new System.Windows.Forms.Panel();
            this.btnCloseYear = new System.Windows.Forms.Button();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtBalanceOV = new System.Windows.Forms.TextBox();
            this.lblSaldoFine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBalanceST = new System.Windows.Forms.TextBox();
            this.lblSaldoIni = new System.Windows.Forms.Label();
            this.txtYearMonth = new System.Windows.Forms.TextBox();
            this.pnlMenu.SuspendLayout();
            this.tabMenu.SuspendLayout();
            this.pgHome.SuspendLayout();
            this.grpExit.SuspendLayout();
            this.gprSave.SuspendLayout();
            this.gprYears.SuspendLayout();
            this.pgInsert.SuspendLayout();
            this.grpSave2.SuspendLayout();
            this.grpInsert.SuspendLayout();
            this.pgModify.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpModiryrow.SuspendLayout();
            this.grpMove.SuspendLayout();
            this.grpDeleteRow.SuspendLayout();
            this.pgSearch.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.pnlTree.SuspendLayout();
            this.pnlGrd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMovLibVoices)).BeginInit();
            this.pnlResume.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMenu.Controls.Add(this.tabMenu);
            this.pnlMenu.Location = new System.Drawing.Point(1, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1363, 120);
            this.pnlMenu.TabIndex = 0;
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.pgHome);
            this.tabMenu.Controls.Add(this.pgInsert);
            this.tabMenu.Controls.Add(this.pgModify);
            this.tabMenu.Controls.Add(this.pgSearch);
            this.tabMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenu.Location = new System.Drawing.Point(-1, 3);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1362, 115);
            this.tabMenu.TabIndex = 5;
            // 
            // pgHome
            // 
            this.pgHome.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgHome.Controls.Add(this.grpExit);
            this.pgHome.Controls.Add(this.gprSave);
            this.pgHome.Controls.Add(this.gprYears);
            this.pgHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgHome.Location = new System.Drawing.Point(4, 25);
            this.pgHome.Name = "pgHome";
            this.pgHome.Padding = new System.Windows.Forms.Padding(3);
            this.pgHome.Size = new System.Drawing.Size(1354, 86);
            this.pgHome.TabIndex = 0;
            this.pgHome.Text = "Home";
            // 
            // grpExit
            // 
            this.grpExit.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpExit.Controls.Add(this.btnExit);
            this.grpExit.Location = new System.Drawing.Point(1099, 6);
            this.grpExit.Name = "grpExit";
            this.grpExit.Size = new System.Drawing.Size(105, 75);
            this.grpExit.TabIndex = 14;
            this.grpExit.TabStop = false;
            this.grpExit.Text = "Esci";
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::Libretto.Properties.Resources.Exit;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.Green;
            this.btnExit.Location = new System.Drawing.Point(19, 25);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 44);
            this.btnExit.TabIndex = 15;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gprSave
            // 
            this.gprSave.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gprSave.Controls.Add(this.btnSave);
            this.gprSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gprSave.Location = new System.Drawing.Point(141, 6);
            this.gprSave.Name = "gprSave";
            this.gprSave.Size = new System.Drawing.Size(80, 75);
            this.gprSave.TabIndex = 10;
            this.gprSave.TabStop = false;
            this.gprSave.Text = "Salva";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::Libretto.Properties.Resources.Salva;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(12, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 44);
            this.btnSave.TabIndex = 11;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gprYears
            // 
            this.gprYears.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.gprYears.Controls.Add(this.btnLoadYears);
            this.gprYears.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gprYears.Location = new System.Drawing.Point(6, 6);
            this.gprYears.Name = "gprYears";
            this.gprYears.Size = new System.Drawing.Size(129, 75);
            this.gprYears.TabIndex = 6;
            this.gprYears.TabStop = false;
            this.gprYears.Text = "Anni";
            // 
            // btnLoadYears
            // 
            this.btnLoadYears.BackgroundImage = global::Libretto.Properties.Resources.Aggiorna;
            this.btnLoadYears.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadYears.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadYears.ForeColor = System.Drawing.Color.Green;
            this.btnLoadYears.Location = new System.Drawing.Point(6, 21);
            this.btnLoadYears.Name = "btnLoadYears";
            this.btnLoadYears.Size = new System.Drawing.Size(112, 48);
            this.btnLoadYears.TabIndex = 9;
            this.btnLoadYears.UseVisualStyleBackColor = true;
            this.btnLoadYears.Click += new System.EventHandler(this.btnLoadYears_Click);
            // 
            // pgInsert
            // 
            this.pgInsert.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgInsert.Controls.Add(this.grpSave2);
            this.pgInsert.Controls.Add(this.grpInsert);
            this.pgInsert.Location = new System.Drawing.Point(4, 25);
            this.pgInsert.Name = "pgInsert";
            this.pgInsert.Padding = new System.Windows.Forms.Padding(3);
            this.pgInsert.Size = new System.Drawing.Size(1354, 86);
            this.pgInsert.TabIndex = 1;
            this.pgInsert.Text = "Inserisci";
            // 
            // grpSave2
            // 
            this.grpSave2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpSave2.Controls.Add(this.btnSaveData);
            this.grpSave2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpSave2.Location = new System.Drawing.Point(1063, 6);
            this.grpSave2.Name = "grpSave2";
            this.grpSave2.Size = new System.Drawing.Size(80, 75);
            this.grpSave2.TabIndex = 22;
            this.grpSave2.TabStop = false;
            this.grpSave2.Text = "Salva";
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackgroundImage = global::Libretto.Properties.Resources.Salva;
            this.btnSaveData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveData.ForeColor = System.Drawing.Color.Green;
            this.btnSaveData.Location = new System.Drawing.Point(12, 25);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(55, 44);
            this.btnSaveData.TabIndex = 23;
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // grpInsert
            // 
            this.grpInsert.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpInsert.Controls.Add(this.btnSetOftenValue);
            this.grpInsert.Controls.Add(this.label1);
            this.grpInsert.Controls.Add(this.cmbMonths);
            this.grpInsert.Controls.Add(this.btnInsert);
            this.grpInsert.Controls.Add(this.txtImport);
            this.grpInsert.Controls.Add(this.label11);
            this.grpInsert.Controls.Add(this.txtCause);
            this.grpInsert.Controls.Add(this.label10);
            this.grpInsert.Location = new System.Drawing.Point(27, 6);
            this.grpInsert.Name = "grpInsert";
            this.grpInsert.Size = new System.Drawing.Size(1030, 75);
            this.grpInsert.TabIndex = 16;
            this.grpInsert.TabStop = false;
            this.grpInsert.Text = "Inserisci";
            // 
            // btnSetOftenValue
            // 
            this.btnSetOftenValue.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSetOftenValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetOftenValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetOftenValue.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnSetOftenValue.Location = new System.Drawing.Point(648, 33);
            this.btnSetOftenValue.Name = "btnSetOftenValue";
            this.btnSetOftenValue.Size = new System.Drawing.Size(48, 26);
            this.btnSetOftenValue.TabIndex = 54;
            this.btnSetOftenValue.Text = "***";
            this.btnSetOftenValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSetOftenValue.UseVisualStyleBackColor = false;
            this.btnSetOftenValue.Click += new System.EventHandler(this.btnSetOftenValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(92, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Mese";
            // 
            // cmbMonths
            // 
            this.cmbMonths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(95, 33);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(121, 28);
            this.cmbMonths.TabIndex = 50;
            // 
            // btnInsert
            // 
            this.btnInsert.BackgroundImage = global::Libretto.Properties.Resources.Inserisci;
            this.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsert.ForeColor = System.Drawing.Color.Green;
            this.btnInsert.Location = new System.Drawing.Point(909, 14);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(93, 55);
            this.btnInsert.TabIndex = 53;
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtImport
            // 
            this.txtImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImport.Location = new System.Drawing.Point(722, 33);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(148, 26);
            this.txtImport.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label11.Location = new System.Drawing.Point(719, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Importo";
            // 
            // txtCause
            // 
            this.txtCause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCause.Location = new System.Drawing.Point(252, 33);
            this.txtCause.Name = "txtCause";
            this.txtCause.Size = new System.Drawing.Size(392, 26);
            this.txtCause.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label10.Location = new System.Drawing.Point(249, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Causale ";
            // 
            // pgModify
            // 
            this.pgModify.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgModify.Controls.Add(this.groupBox1);
            this.pgModify.Controls.Add(this.grpModiryrow);
            this.pgModify.Controls.Add(this.grpMove);
            this.pgModify.Controls.Add(this.grpDeleteRow);
            this.pgModify.Location = new System.Drawing.Point(4, 25);
            this.pgModify.Name = "pgModify";
            this.pgModify.Size = new System.Drawing.Size(1354, 86);
            this.pgModify.TabIndex = 2;
            this.pgModify.Text = "Modifica";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.btnSaveThree);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(394, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(80, 75);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Salva";
            // 
            // btnSaveThree
            // 
            this.btnSaveThree.BackgroundImage = global::Libretto.Properties.Resources.Salva;
            this.btnSaveThree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveThree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveThree.ForeColor = System.Drawing.Color.Green;
            this.btnSaveThree.Location = new System.Drawing.Point(12, 25);
            this.btnSaveThree.Name = "btnSaveThree";
            this.btnSaveThree.Size = new System.Drawing.Size(55, 44);
            this.btnSaveThree.TabIndex = 23;
            this.btnSaveThree.UseVisualStyleBackColor = true;
            this.btnSaveThree.Click += new System.EventHandler(this.btnSaveThree_Click);
            // 
            // grpModiryrow
            // 
            this.grpModiryrow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpModiryrow.Controls.Add(this.btnModifyRow);
            this.grpModiryrow.Location = new System.Drawing.Point(288, 6);
            this.grpModiryrow.Name = "grpModiryrow";
            this.grpModiryrow.Size = new System.Drawing.Size(100, 75);
            this.grpModiryrow.TabIndex = 29;
            this.grpModiryrow.TabStop = false;
            this.grpModiryrow.Text = "Modifica riga ";
            // 
            // btnModifyRow
            // 
            this.btnModifyRow.BackgroundImage = global::Libretto.Properties.Resources.Aggiorna1;
            this.btnModifyRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModifyRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifyRow.ForeColor = System.Drawing.Color.Green;
            this.btnModifyRow.Location = new System.Drawing.Point(22, 19);
            this.btnModifyRow.Name = "btnModifyRow";
            this.btnModifyRow.Size = new System.Drawing.Size(59, 50);
            this.btnModifyRow.TabIndex = 30;
            this.btnModifyRow.UseVisualStyleBackColor = true;
            this.btnModifyRow.Click += new System.EventHandler(this.btnModifyRow_Click);
            // 
            // grpMove
            // 
            this.grpMove.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpMove.Controls.Add(this.btnDown);
            this.grpMove.Controls.Add(this.btnUp);
            this.grpMove.Location = new System.Drawing.Point(117, 6);
            this.grpMove.Name = "grpMove";
            this.grpMove.Size = new System.Drawing.Size(165, 75);
            this.grpMove.TabIndex = 26;
            this.grpMove.TabStop = false;
            this.grpMove.Text = "Sposta";
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::Libretto.Properties.Resources.Carica;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.Green;
            this.btnDown.Location = new System.Drawing.Point(88, 19);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(59, 50);
            this.btnDown.TabIndex = 28;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::Libretto.Properties.Resources.Su;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.Green;
            this.btnUp.Location = new System.Drawing.Point(6, 19);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(59, 50);
            this.btnUp.TabIndex = 27;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // grpDeleteRow
            // 
            this.grpDeleteRow.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpDeleteRow.Controls.Add(this.btnDeleteRow);
            this.grpDeleteRow.Location = new System.Drawing.Point(6, 6);
            this.grpDeleteRow.Name = "grpDeleteRow";
            this.grpDeleteRow.Size = new System.Drawing.Size(105, 75);
            this.grpDeleteRow.TabIndex = 24;
            this.grpDeleteRow.TabStop = false;
            this.grpDeleteRow.Text = "Elimina Riga";
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.BackgroundImage = global::Libretto.Properties.Resources.Delete;
            this.btnDeleteRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteRow.ForeColor = System.Drawing.Color.Green;
            this.btnDeleteRow.Location = new System.Drawing.Point(21, 19);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(59, 50);
            this.btnDeleteRow.TabIndex = 25;
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.btnDeleteRow_Click);
            // 
            // pgSearch
            // 
            this.pgSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pgSearch.Controls.Add(this.grpSearch);
            this.pgSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.pgSearch.Location = new System.Drawing.Point(4, 25);
            this.pgSearch.Name = "pgSearch";
            this.pgSearch.Size = new System.Drawing.Size(1354, 86);
            this.pgSearch.TabIndex = 3;
            this.pgSearch.Text = "Cerca";
            // 
            // grpSearch
            // 
            this.grpSearch.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.grpSearch.Controls.Add(this.txtSearchVoice);
            this.grpSearch.Location = new System.Drawing.Point(169, 6);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(940, 75);
            this.grpSearch.TabIndex = 31;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Cerca voci di spesa";
            // 
            // txtSearchVoice
            // 
            this.txtSearchVoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchVoice.Location = new System.Drawing.Point(6, 30);
            this.txtSearchVoice.Name = "txtSearchVoice";
            this.txtSearchVoice.Size = new System.Drawing.Size(928, 26);
            this.txtSearchVoice.TabIndex = 32;
            this.txtSearchVoice.TextChanged += new System.EventHandler(this.txtSearchVoice_TextChanged);
            // 
            // pnlTree
            // 
            this.pnlTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTree.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlTree.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTree.Controls.Add(this.btnLoadYears2);
            this.pnlTree.Controls.Add(this.treeYears);
            this.pnlTree.Location = new System.Drawing.Point(1, 123);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(182, 741);
            this.pnlTree.TabIndex = 2;
            // 
            // btnLoadYears2
            // 
            this.btnLoadYears2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLoadYears2.BackgroundImage = global::Libretto.Properties.Resources.Aggiorna1;
            this.btnLoadYears2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadYears2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadYears2.ForeColor = System.Drawing.Color.Green;
            this.btnLoadYears2.Location = new System.Drawing.Point(30, 12);
            this.btnLoadYears2.Name = "btnLoadYears2";
            this.btnLoadYears2.Size = new System.Drawing.Size(70, 36);
            this.btnLoadYears2.TabIndex = 34;
            this.btnLoadYears2.UseVisualStyleBackColor = false;
            this.btnLoadYears2.Click += new System.EventHandler(this.btnLoadYears2_Click);
            // 
            // treeYears
            // 
            this.treeYears.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeYears.BackColor = System.Drawing.Color.Gainsboro;
            this.treeYears.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeYears.ForeColor = System.Drawing.Color.Indigo;
            this.treeYears.ItemHeight = 20;
            this.treeYears.Location = new System.Drawing.Point(0, 60);
            this.treeYears.Name = "treeYears";
            treeNode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            treeNode1.ForeColor = System.Drawing.Color.Red;
            treeNode1.Name = "nodeYears";
            treeNode1.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "ANNI   ";
            this.treeYears.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeYears.ShowLines = false;
            this.treeYears.ShowNodeToolTips = true;
            this.treeYears.Size = new System.Drawing.Size(177, 682);
            this.treeYears.TabIndex = 33;
            // 
            // pnlGrd
            // 
            this.pnlGrd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrd.Controls.Add(this.grdMovLibVoices);
            this.pnlGrd.Controls.Add(this.pnlResumeYear);
            this.pnlGrd.Location = new System.Drawing.Point(185, 123);
            this.pnlGrd.Name = "pnlGrd";
            this.pnlGrd.Size = new System.Drawing.Size(978, 630);
            this.pnlGrd.TabIndex = 3;
            // 
            // grdMovLibVoices
            // 
            this.grdMovLibVoices.AllowUserToAddRows = false;
            this.grdMovLibVoices.AllowUserToResizeRows = false;
            this.grdMovLibVoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMovLibVoices.BackgroundColor = System.Drawing.SystemColors.Control;
            this.grdMovLibVoices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdMovLibVoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMovLibVoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdMovLibVoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMovLibVoices.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdMovLibVoices.Location = new System.Drawing.Point(3, 0);
            this.grdMovLibVoices.MultiSelect = false;
            this.grdMovLibVoices.Name = "grdMovLibVoices";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMovLibVoices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdMovLibVoices.ShowEditingIcon = false;
            this.grdMovLibVoices.Size = new System.Drawing.Size(974, 627);
            this.grdMovLibVoices.TabIndex = 35;
            this.grdMovLibVoices.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMovLibVoices_CellEndEdit);
            this.grdMovLibVoices.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMovLibVoices_CellValueChanged);
            this.grdMovLibVoices.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdMovLibVoices_MouseClick);
            // 
            // pnlResumeYear
            // 
            this.pnlResumeYear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResumeYear.Location = new System.Drawing.Point(0, 630);
            this.pnlResumeYear.Name = "pnlResumeYear";
            this.pnlResumeYear.Size = new System.Drawing.Size(915, 98);
            this.pnlResumeYear.TabIndex = 4;
            // 
            // pnlResume
            // 
            this.pnlResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResume.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlResume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlResume.Controls.Add(this.btnCloseYear);
            this.pnlResume.Controls.Add(this.pnlStatus);
            this.pnlResume.Controls.Add(this.panel2);
            this.pnlResume.Controls.Add(this.textBox2);
            this.pnlResume.Controls.Add(this.txtBalanceOV);
            this.pnlResume.Controls.Add(this.lblSaldoFine);
            this.pnlResume.Controls.Add(this.panel1);
            this.pnlResume.Controls.Add(this.textBox1);
            this.pnlResume.Controls.Add(this.txtBalanceST);
            this.pnlResume.Controls.Add(this.lblSaldoIni);
            this.pnlResume.Location = new System.Drawing.Point(1165, 123);
            this.pnlResume.Name = "pnlResume";
            this.pnlResume.Size = new System.Drawing.Size(200, 730);
            this.pnlResume.TabIndex = 4;
            // 
            // btnCloseYear
            // 
            this.btnCloseYear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCloseYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseYear.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseYear.ForeColor = System.Drawing.Color.Indigo;
            this.btnCloseYear.Location = new System.Drawing.Point(14, 219);
            this.btnCloseYear.Name = "btnCloseYear";
            this.btnCloseYear.Size = new System.Drawing.Size(163, 32);
            this.btnCloseYear.TabIndex = 54;
            this.btnCloseYear.Text = "Chiudi Anno";
            this.btnCloseYear.UseVisualStyleBackColor = false;
            this.btnCloseYear.Click += new System.EventHandler(this.btnCloseYear_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStatus.Location = new System.Drawing.Point(8, 634);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(181, 23);
            this.pnlStatus.TabIndex = 45;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(1, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(197, 10);
            this.panel2.TabIndex = 41;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(152, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(27, 22);
            this.textBox2.TabIndex = 52;
            this.textBox2.Text = "€";
            // 
            // txtBalanceOV
            // 
            this.txtBalanceOV.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBalanceOV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceOV.Location = new System.Drawing.Point(8, 120);
            this.txtBalanceOV.Name = "txtBalanceOV";
            this.txtBalanceOV.Size = new System.Drawing.Size(146, 22);
            this.txtBalanceOV.TabIndex = 39;
            // 
            // lblSaldoFine
            // 
            this.lblSaldoFine.AutoSize = true;
            this.lblSaldoFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoFine.Location = new System.Drawing.Point(5, 101);
            this.lblSaldoFine.Name = "lblSaldoFine";
            this.lblSaldoFine.Size = new System.Drawing.Size(79, 16);
            this.lblSaldoFine.TabIndex = 50;
            this.lblSaldoFine.Text = "Saldo finale";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(-4, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 10);
            this.panel1.TabIndex = 40;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(27, 22);
            this.textBox1.TabIndex = 48;
            this.textBox1.Text = "€";
            // 
            // txtBalanceST
            // 
            this.txtBalanceST.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtBalanceST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalanceST.Location = new System.Drawing.Point(6, 28);
            this.txtBalanceST.Name = "txtBalanceST";
            this.txtBalanceST.Size = new System.Drawing.Size(146, 22);
            this.txtBalanceST.TabIndex = 38;
            // 
            // lblSaldoIni
            // 
            this.lblSaldoIni.AutoSize = true;
            this.lblSaldoIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoIni.Location = new System.Drawing.Point(3, 9);
            this.lblSaldoIni.Name = "lblSaldoIni";
            this.lblSaldoIni.Size = new System.Drawing.Size(88, 16);
            this.lblSaldoIni.TabIndex = 37;
            this.lblSaldoIni.Text = "Saldo iniziale";
            // 
            // txtYearMonth
            // 
            this.txtYearMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYearMonth.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtYearMonth.Enabled = false;
            this.txtYearMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYearMonth.ForeColor = System.Drawing.Color.Black;
            this.txtYearMonth.Location = new System.Drawing.Point(186, 760);
            this.txtYearMonth.Name = "txtYearMonth";
            this.txtYearMonth.ReadOnly = true;
            this.txtYearMonth.Size = new System.Drawing.Size(978, 22);
            this.txtYearMonth.TabIndex = 37;
            this.txtYearMonth.TabStop = false;
            // 
            // frmLibretto
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1367, 861);
            this.Controls.Add(this.txtYearMonth);
            this.Controls.Add(this.pnlResume);
            this.Controls.Add(this.pnlGrd);
            this.Controls.Add(this.pnlTree);
            this.Controls.Add(this.pnlMenu);
            this.MaximizeBox = false;
            this.Name = "frmLibretto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LIBRETTO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLibretto_FormClosing);
            this.Load += new System.EventHandler(this.frmLibretto_Load);
            this.pnlMenu.ResumeLayout(false);
            this.tabMenu.ResumeLayout(false);
            this.pgHome.ResumeLayout(false);
            this.grpExit.ResumeLayout(false);
            this.gprSave.ResumeLayout(false);
            this.gprYears.ResumeLayout(false);
            this.pgInsert.ResumeLayout(false);
            this.grpSave2.ResumeLayout(false);
            this.grpInsert.ResumeLayout(false);
            this.grpInsert.PerformLayout();
            this.pgModify.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpModiryrow.ResumeLayout(false);
            this.grpMove.ResumeLayout(false);
            this.grpDeleteRow.ResumeLayout(false);
            this.pgSearch.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.pnlTree.ResumeLayout(false);
            this.pnlGrd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMovLibVoices)).EndInit();
            this.pnlResume.ResumeLayout(false);
            this.pnlResume.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage pgHome;
        private System.Windows.Forms.GroupBox grpExit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox gprSave;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gprYears;
        private System.Windows.Forms.Button btnLoadYears;
        private System.Windows.Forms.TabPage pgInsert;
        private System.Windows.Forms.GroupBox grpSave2;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.GroupBox grpInsert;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCause;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage pgModify;
        private System.Windows.Forms.GroupBox grpModiryrow;
        private System.Windows.Forms.Button btnModifyRow;
        private System.Windows.Forms.GroupBox grpMove;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.GroupBox grpDeleteRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.TabPage pgSearch;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.TextBox txtSearchVoice;
        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.Button btnLoadYears2;
        private System.Windows.Forms.TreeView treeYears;
        private System.Windows.Forms.Panel pnlGrd;
        private System.Windows.Forms.DataGridView grdMovLibVoices;
        private System.Windows.Forms.Panel pnlResumeYear;
        private System.Windows.Forms.Panel pnlResume;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtBalanceOV;
        private System.Windows.Forms.Label lblSaldoFine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBalanceST;
        private System.Windows.Forms.Label lblSaldoIni;
        private System.Windows.Forms.TextBox txtYearMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMonths;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSaveThree;
        private System.Windows.Forms.Button btnSetOftenValue;
        private System.Windows.Forms.Button btnCloseYear;
    }
}

