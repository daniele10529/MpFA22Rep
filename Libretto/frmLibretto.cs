using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ManageGrid;
using GenericModelData;
using Checking;
using MenuGenerator;
using CreateForm;
using PDFCreator;

namespace Libretto
{
    //modulo per la gestione del Libretto e della PostPay
    //utilizza una classe specifica per la gestione PP
    public partial class frmLibretto : Form
    {
        //tabella contenente i dati
        private DataTable table;
        //percorso file xml con errori
        private const string pathxml = Routes.XMLERRORS;
        //verifica sul comportamento utente
        private bool isLoad;
        private bool isSaved;
        private bool isChanged;
        //istanza alla classe di gestione con DB
        ModelDataLibNom model;
        //Istanza alla classe checker
        protected Checker check;
        //numero dell'anno e mese caricato
        public int year_manage, month_manage;

        public frmLibretto()
        {
            InitializeComponent();
            table = new DataTable();
            isLoad = false;
            isSaved = false;
            isChanged = false;
            model = new ModelDataLibNom();
        }

        #region Metodi Privati
        //genera la lista dati basata sulla struct
        private List<ModelDataLibNom.PaymentLibNom> createListStruct()
        {
            //istanza di struttura e lista
            ModelDataLibNom.PaymentLibNom payment;
            List<ModelDataLibNom.PaymentLibNom> lista = new List<ModelDataLibNom.PaymentLibNom>();
            //cicla tutta la tabella e aggiunge gli elementi alla lista
            //rispettando la struttura
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                payment.id_libretto = Int32.Parse(lastrow[0].ToString());
                payment.causale = lastrow[1].ToString();
                payment.importo = Double.Parse(lastrow[2].ToString());
                //Ricava il numero del mese per il salvataggio nel DB
                payment.id_mese = selmonth(lastrow[3].ToString());
                lista.Add(payment);

            }
            return lista;

        }

        /// <summary>
        /// Genera i tooltip sui pulsanti
        /// </summary>
        private void toolTip()
        {
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(btnLoadYears2, "Carica i valori dal DB del mese selezionato");
            tip.SetToolTip(btnLoadYears, "Carica i valori dal DB del mese selezionato");
            tip.SetToolTip(btnExit, "Chiudi Spese Annuali");
            tip.SetToolTip(btnSave, "Salva le modifiche");
            tip.SetToolTip(txtCause, "Inserisci una causale di spesa");
            tip.SetToolTip(txtImport, "Inserisci un importo");
            tip.SetToolTip(btnInsert, "Inserisci i valori in tabella");
            tip.SetToolTip(btnDeleteRow, "Elimina una riga");
            tip.SetToolTip(btnUp, "Sposta in alto la riga");
            tip.SetToolTip(btnDown, "Sposta in basso la riga");
            tip.SetToolTip(btnModifyRow, "Modifica una riga");
            tip.SetToolTip(treeYears, "Seleziona il mese da caricare");
            tip.SetToolTip(btnSaveData, "Salva le modifiche");
            tip.SetToolTip(txtSearchVoice, "Ricarca nel DataGridView");
            tip.SetToolTip(cmbMonths, "Seleziona il mese per l'inserimento");
            tip.SetToolTip(btnCloseYear, "Chiudere l'anno soltanto dopo aver creato un nuovo anno!!");
        }

        /// <summary>
        /// carica immagini per le pagine del tabcontrol
        /// </summary>
        private void loadImage()
        {
            string pathIco = Routes.ICONS;
            ImageList list = new ImageList();

            try
            {
                //si può assegnare l'icona alle pagine solo tramite una lista di immagini
                list.Images.Add(Image.FromFile(pathIco + "Insert.png"));
                list.Images.Add(Image.FromFile(pathIco + "Home.png"));
                list.Images.Add(Image.FromFile(pathIco + "Modify.png"));
                list.Images.Add(Image.FromFile(pathIco + "Search.png"));
                //assegna la lista di immagini al tabcontrol
                tabMenu.ImageList = list;
                pgHome.ImageIndex = 1;
                pgInsert.ImageIndex = 0;
                pgModify.ImageIndex = 2;
                pgSearch.ImageIndex = 3;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Restituisce il numero del mese selezionato
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private int selmonth(string m)
        {
            int n = 0;
            switch (m)
            {
                case "gennaio":
                    n = 1;
                    break;
                case "febbraio":
                    n = 2;
                    break;
                case "marzo":
                    n = 3;
                    break;
                case "aprile":
                    n = 4;
                    break;
                case "maggio":
                    n = 5;
                    break;
                case "giugno":
                    n = 6;
                    break;
                case "luglio":
                    n = 7;
                    break;
                case "agosto":
                    n = 8;
                    break;
                case "settembre":
                    n = 9;
                    break;
                case "ottobre":
                    n = 10;
                    break;
                case "novembre":
                    n = 11;
                    break;
                case "dicembre":
                    n = 12;
                    break;
            }
            return n;
        }

        /// <summary>
        /// Restituisce il mese in stringa in base al suo numero
        /// necessario al salvataggio nel DB.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string selmonth(int m)
        {
            string n = "";
            switch (m)
            {
                case 1:
                    n = "gennaio";
                    break;
                case 2:
                    n = "febbraio";
                    break;
                case 3:
                    n = "marzo";
                    break;
                case 4:
                    n = "aprile";
                    break;
                case 5:
                    n = "maggio";
                    break;
                case 6:
                    n = "giugno";
                    break;
                case 7:
                    n = "luglio";
                    break;
                case 8:
                    n = "agosto";
                    break;
                case 9:
                    n = "settembre";
                    break;
                case 10:
                    n = "ottobre";
                    break;
                case 11:
                    n = "novembre";
                    break;
                case 12:
                    n = "dicembre";
                    break;
            }
            return n;
        }

        /// <summary>
        /// Metodo per la verifica del lavoro sull'ultimo anno
        /// </summary>
        /// <param name="year">Anno da verificare</param>
        /// <returns>Ritorna false se non è l'ultimo anno</returns>
        private bool checkLastYear(int year)
        {
            int lastYear;
            //Preleva tutti i nodi
            TreeNodeCollection nodes = treeYears.Nodes;
            //Cicla i nodi e prelevo il valore dell'ultimo nodo
            foreach (TreeNode node in nodes)
            {
                lastYear = Int32.Parse(node.LastNode.Text);
                //Verifica ultimo nodo selezionato per update, salvataggio
                if (year < lastYear) return false;
                //Verifica anno successivo per update saldo
                else if (year == lastYear) return true;
            }
            return false;
        }

        /// <summary>
        /// Esegue il conteggio del saldo attuale
        /// </summary>
        private void counter()
        {
            int i;
            double total = 0;
            DataRow row;

            txtBalanceOV.ResetText();
            if (txtBalanceST.Text.Length > 0)
            {
                total = Double.Parse(txtBalanceST.Text);
            }
            for (i = 0; i < table.Rows.Count; i++)
            {
                row = table.NewRow();
                row.ItemArray = table.Rows[i].ItemArray;
                total += Double.Parse(row[2].ToString());
            }
            txtBalanceOV.Text = total.ToString();
            //tronca la stringa dopo il calcolo
            check = new Checker();
            check.truncate(txtBalanceOV, 2);
        }

        /// <summary>
        /// Gestisce il colore del pannello per il salvataggio
        /// </summary>
        private void statusPanel()
        {
            if (isSaved == true) pnlStatus.BackColor = Color.FromArgb(0, 255, 0);
            else if (isSaved == false && isChanged == true) pnlStatus.BackColor = Color.FromArgb(255, 0, 0);
            else if (isLoad == true) pnlStatus.BackColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

        #region EVENTI DEGLI OGGETTI

        #region Form

        private void frmLibretto_Load(object sender, EventArgs e)
        {
            string[] mesi = { "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre" };

            Clipboard.Clear();
            toolTip();
            loadImage();
            model.loadTree(treeYears, true);
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);

            //impostazioni di tabella e datagridview
            grdMovLibVoices.DataSource = table;
            table.Columns.Add("ID");
            table.Columns.Add("CAUSALE DEL MOVIMENTO");
            table.Columns.Add("IMPORTO");
            table.Columns.Add("MESE");
            grdMovLibVoices.Columns[0].Width = (grdMovLibVoices.Width * 5) / 100;
            grdMovLibVoices.Columns[1].Width = (grdMovLibVoices.Width * 70) / 100;
            grdMovLibVoices.Columns[2].Width = (grdMovLibVoices.Width * 15) / 100;
            grdMovLibVoices.Columns[3].Width = (grdMovLibVoices.Width * 10) / 100;
            grdMovLibVoices.Columns[0].ReadOnly = true;

            //set valori comboBox mesi
            cmbMonths.Items.AddRange(mesi);

            //Set textbox YearMonth
            txtYearMonth.Text = "Gestione Libretto nominale.....";
        }

        //Intercetta la chusura del form
        private void frmLibretto_FormClosing(object sender, FormClosingEventArgs e)
        {
            //se i dati non sono salvati chiede conferma
            if (isChanged == true && isSaved == false)
            {
                if (MessageBox.Show("Sicuro di voler chiudere l'App, i dati non salvati andranno persi ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {//se non si conferma la chiusura annulla l'evento
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Button

        private void btnLoadYears_Click(object sender, EventArgs e)
        {

            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            //istanza alla lista basata su struct
            List<ModelDataLibNom.PaymentLibNom> listdata = new List<ModelDataLibNom.PaymentLibNom>();
            List<string> listinsert = new List<string>();
            string selezione, anno;
            int year, i;
            bool lastyear = false;

            table.Rows.Clear();

            if (isChanged == true && isSaved == false)
            {
                if (MessageBox.Show("Sicuro di voler caricare un nuovo mese i dati non sono salvati ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            //controllo sulla selezione del nodo anno\mese dall'albero
            if (treeYears.SelectedNode == null) return;

            selezione = treeYears.SelectedNode.Text;
            if (selezione == "ANNI") return;
            else
            {
                //assegna il valore di anno\mese in base al nodo selezionato
                anno = treeYears.SelectedNode.Text;

                if (anno == "ANNI") return;
                else
                {
                    year = Int32.Parse(anno);
                    //assegna il valore alle variabili globali per la gestione con DB
                    year_manage = year;
                    //carica i dati da DB e li assegna alla lista
                    listdata = model.loadDataLib(year);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    //ogni elemento della lista struct è una tupla del DB
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_libretto.ToString());
                        listinsert.Add(listdata[i].causale);
                        listinsert.Add(listdata[i].importo.ToString());
                        listinsert.Add(selmonth(listdata[i].id_mese));
                        populate.inserisci(4, listinsert);
                        listinsert.Clear();
                        i++;
                    }
                    txtYearMonth.Text = "Anno caricato : ".ToUpper() + anno.ToUpper();
                }
            }

            isChanged = false;
            isLoad = true;
            //deseleziona l'albero 
            treeYears.SelectedNode = null;
            //carica il valore di saldo del mese precedente e lo inserisce nella textbox
            txtBalanceST.Text = model.balanceYearPre(year_manage).ToString();
            //conteggia il saldo finale
            counter();
            //tronca il bilancio iniziale
            if (txtBalanceST.Text.Length > 1)
            {
                check = new Checker();
                check.truncate(txtBalanceST, 2);
            }

            //Se non caricato l'ultimo anno il Datagridview è disabilitato
            //Disabilito inserimento, modifiche, calcellazione e salvataggio
            lastyear = checkLastYear(year_manage);
            if (!lastyear)
            {
                grdMovLibVoices.ReadOnly = true;
                btnInsert.Enabled = false;
                btnSave.Enabled = false;
                btnSaveData.Enabled = false;
                btnSaveThree.Enabled = false;
                btnModifyRow.Enabled = false;
                btnDeleteRow.Enabled = false;
            }
            else
            {
                grdMovLibVoices.ReadOnly = false;
                btnInsert.Enabled = true;
                btnSave.Enabled = true;
                btnSaveData.Enabled = true;
                btnSaveThree.Enabled = true;
                btnModifyRow.Enabled = true;
                btnDeleteRow.Enabled = true;
            }

        }

        private void btnLoadYears2_Click(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();

            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            Checker check;
            List<string> list = new List<string>();
            int id = 0;
            string father = "ListError";
            string feature = "ErrorTitle";
            int idgrid = 0, idDB = 0;
            //verifica sulla presenza di tutti i campi dalla classe checker
            //e che sia stato caricato un anno\mese
            if (isLoad == false) return;
            populate.path = pathxml;
            populate.father = father;
            populate.feature = feature;
            check = new Checker(pathxml);

            try
            {

                if (check.isSelected(cmbMonths) && !(check.isEmpty(txtCause.Texts)) && !(check.isEmpty(txtImport.Texts)))
                {
                    if (check.isNumeric(txtImport.Texts))
                    {
                        //Acquisisce il valore di PK da DataGridView
                        if (!(table.Rows.Count == 0))
                        {
                            int i = table.Rows.Count - 1;
                            DataRow lastrow = table.NewRow();
                            lastrow.ItemArray = table.Rows[i].ItemArray;
                            idgrid = Int16.Parse(lastrow[0].ToString());
                        }

                        //Acquidisce il valore di primary key da DB
                        idDB = model.primaryKey("libretto_postale", "id_libretto");

                        //Se la chiave è maggiore quella della griglia incrementala di 1
                        //valori inseriti e non ancora salvati
                        if (idgrid >= idDB) id = idgrid + 1;
                        //altrimenti incrementa di 1 la chiave prelevata da DB
                        else id = idDB + 1;

                        list.Add(id.ToString());
                        list.Add(txtCause.Texts);
                        list.Add(txtImport.Texts.Replace('.', ','));
                        list.Add(cmbMonths.SelectedItem.ToString());

                        //Popola la griglia attraverso la lista
                        populate.inserisci(4, list);

                        //Resetta i valori
                        txtCause.Texts = "";
                        txtImport.Texts = "";
                        cmbMonths.SelectedItem = null;
                        cmbMonths.Focus();
                        counter();

                    }
                }

            }
            catch (FormatException ex)//Eccezione generata dai metodi della classe check
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (isLoad == false || isSaved == true) return;
            if (isChanged == false) return;

            double balance = Double.Parse(txtBalanceOV.Text);
            bool isSavedBalance = false;

            //genera la lista dalla tabella e salva i dati nel DB attraverso la classe modeldata
            List<ModelDataLibNom.PaymentLibNom> lista = createListStruct();
            isSaved = model.saveDataLib(year_manage, lista);
            isSavedBalance = model.saveBalanceYear(balance, year_manage);
            //verifica il corretto salvataggio dei dati
            if (isSavedBalance == false || isSaved == false)
            {
                MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                statusPanel();
            }

        }

        //update del saldo annuo per l'anno successivo, in modo che al primo caricamento in spese annuali
        //non ci sia saldo 0
        private void btnCloseYear_Click(object sender, EventArgs e)
        {
            if (isLoad == false) return;

            bool isSavedBalance = false;
            double balance = Double.Parse(txtBalanceOV.Text);
            bool lastyear = false;
            int yearnext = year_manage + 1;

            //Verifica sia stato creato il nuovo anno per la chiusura
            lastyear = checkLastYear(yearnext);
            if (lastyear)
            {
                isSavedBalance = model.saveBalanceYear(balance, yearnext);
                if (isSavedBalance == false)
                {
                    MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    MessageBox.Show("Update effettuato con successo !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Impossibile chiudere l'anno, non è stato creato !!",
                           "Attenzione!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnSaveThree_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();
            //preleva l'indice dalla riga selezionata, se non selezionata non fa nulla
            int index = grdMovLibVoices.Rows.IndexOf(grdMovLibVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            //se confermato elimina la riga
            if (MessageBox.Show("Sicuro di voler eliminare la riga ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                populate.deleterow();
            }
            counter();
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMovLibVoices.Rows.IndexOf(grdMovLibVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            populate.mouveUp();
            grdMovLibVoices.CurrentRow.Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMovLibVoices.Rows.IndexOf(grdMovLibVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            populate.mouveDown();
            grdMovLibVoices.CurrentRow.Selected = true;
        }


        private void btnModifyRow_Click(object sender, EventArgs e)
        {
            //istanza per form modifica e per aggiornare il datagridview
            frmModify frmMod = new frmModify();
            PopulateGrid populate = new PopulateGrid(grdMovLibVoices, table);
            string id, cause, import, id_month;
            List<ModelDataLibNom.PaymentLibNom> listdata = new List<ModelDataLibNom.PaymentLibNom>();
            List<string> listinsert = new List<string>();
            int i;

            //variabile di avvenuta modifica
            bool modifyRow = false;
            try
            {
                //prelevo i dati dal datagridview
                var val = grdMovLibVoices.CurrentRow.Cells;
                id = val[0].Value.ToString();
                cause = val[1].Value.ToString();
                import = val[2].Value.ToString();
                id_month = val[3].Value.ToString();
                //passo i dati ai setter di frmModify
                frmMod.setId = id;
                frmMod.setCause = cause;
                frmMod.setImport = import;
                frmMod.setMonth = id_month;
                //setto l'anno selezionato
                frmMod.setYear = year_manage;
                //visualizzo il form
                frmMod.ShowDialog();
                //ricevo tru dal getter se alvataggio avvenuto con successo
                modifyRow = frmMod.verify;
                if (modifyRow == true)
                {//aggiorno il datagridview
                    isSaved = true;
                    table.Rows.Clear();

                    //carica i dati da DB e li assegna alla lista
                    listdata = model.loadDataLib(year_manage);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_libretto.ToString());
                        listinsert.Add(listdata[i].causale);
                        listinsert.Add(listdata[i].importo.ToString());
                        listinsert.Add(selmonth(listdata[i].id_mese));
                        populate.inserisci(4, listinsert);
                        listinsert.Clear();
                        i++;
                    }
                }
                statusPanel();
                counter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nessuna riga selezionata per la modifica, selezionare una riga" + ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //Visualizza il form per le voci frequenti
        private void btnSetOftenValue_Click(object sender, EventArgs e)
        {
            //istanzia la classe
            CreateFormOftenCause form = new CreateFormOftenCause();
            //imposta nel setter la textbox che deve acquisire il valoe dalla 
            //lista delle causali frequenti
            form.OftenCause = txtCause;
        }


        private void btnPDFCreator_Click(object sender, EventArgs e)
        {
            //Se non sono caricati dati esci
            if (isLoad == false)
            {
                MessageBox.Show("Nessun mese caricato, impossibile creare il PDF", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Imposta l'estensione per il file pdf nel SaveDialog
            svdPDF.Filter = "PDF (*.pdf)|*.pdf";
            //Definisce il nome del file
            svdPDF.FileName = year_manage.ToString() + "_" + month_manage.ToString() + "_" + "DataLIB.pdf";
            //Se premuto ok nel SaveDialog
            if (svdPDF.ShowDialog() == DialogResult.OK)
            {
                //istanza alla classe
                DataGridViewToPDF dataPDF = new DataGridViewToPDF(grdMovLibVoices);
                //imposta il setter per il percorso del file da salvare
                dataPDF.pathFile = svdPDF.FileName;
                //crea il pdf
                dataPDF.CreatePDF();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region DatagridView

        private void grdMovLibVoices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //imposta parametri al cambiamento diretto di una cella
            isChanged = true;
            isSaved = false;
            statusPanel();
            counter();
        }

        private void grdMovLibVoices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //modifica il . in una , per il corretto cast double
            if (grdMovLibVoices.CurrentCell.ColumnIndex == 3)
            {
                var val = grdMovLibVoices.CurrentCell.Value;
                string valore = val.ToString().Replace('.', ',');
                grdMovLibVoices.CurrentCell.Value = valore;
            }

        }

        private void grdMovLibVoices_MouseClick(object sender, MouseEventArgs e)
        {
            //se viene premuto il tasto SX, esci dalla funzione
            if (e.Button == MouseButtons.Left) return;
            //istanza alla classe di creazione del ContextMenu
            CreateContexMenu creatMenu = new CreateContexMenu(grdMovLibVoices);
            //setting degli eventi da richiamare con i pulsanti
            creatMenu.setEvents("delete", btnDeleteRow_Click);
            creatMenu.setEvents("modifyIt", btnModifyRow_Click);
            // creatMenu.setEvents("oftenVal", btnOftenVal_Click);
            creatMenu.setEvents("moveUp", btnUp_Click);
            creatMenu.setEvents("moveDown", btnDown_Click);
            //mostra il menu
            creatMenu.showContextMenu(e);
        }

        #endregion

        #region Textbox

        private void txtSearchVoice_TextChanged(object sender, EventArgs e)
        {
            //cerco all'interno del datagridview passando la colonna in cui cercare
            Searching search = new Searching(grdMovLibVoices, table, txtSearchVoice);
            search.searchingRow(1);
        }

        //Setta i colori delle TextBox all'inserimento 
        private void txtCause_Enter(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.FromArgb(161, 223, 239);
            txtCause.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void txtCause_Leave(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.DimGray;
            txtCause.BackColor = Color.White;
        }

        private void txtImport_Enter(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.FromArgb(161, 223, 239);
            txtImport.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.DimGray;
            txtImport.BackColor = Color.White;
        }

        #endregion

        #region ComboBox
        //Setta i colori di inserimento
        private void cmbMonths_Enter(object sender, EventArgs e)
        {
            cmbMonths.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void cmbMonths_Leave(object sender, EventArgs e)
        {
            cmbMonths.BackColor = Color.White;
        }

        #endregion

        #region TreeView
        //Carica i dati al doppio click sul nodo prescelto
        private void treeYears_DoubleClick(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }

        #endregion

        #endregion

    }

}
