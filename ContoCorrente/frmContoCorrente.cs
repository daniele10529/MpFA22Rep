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
using LeaderProcess;
using PDFCreator;
using System.Drawing.Text;

namespace ContoCorrente
{
    public partial class frmContoCorrente : Form
    {
        //tabella contenente i dati
        private DataTable table;
        //percorso file xml con errori
        private const string pathxml = Routes.XMLERRORS;
        //Percorso file XML con definizione path processi
        private const string runPath = Routes.RUNPATH;
        //verifica sul comportamento utente
        private bool isLoad;
        private bool isSaved;
        private bool isChanged;
        //istanza alla classe di gestione con DB
        private ModelDataCC model;
        //istanza alla classe checker
        private Checker check;
        //numero dell'anno e mese caricato
        public int year_manage, month_manage;
        private string manage_mese;

        public frmContoCorrente()
        {
            InitializeComponent();
            table = new DataTable();
            isLoad = false;
            isSaved = false;
            isChanged = false;
            model = new ModelDataCC();
        }    

        #region Metodi Privati

        /// <summary>
        /// Genera una list(ModelDataSY.PaymentSY) per l'inserimento nel DB
        /// </summary>
        /// <returns></returns>
        private List<ModelDataCC.PaymentCC> createListStruct()
        {
            List<ModelDataCC.PaymentCC> list = new List<ModelDataCC.PaymentCC>();
            ModelDataCC.PaymentCC payment;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                payment.id_tupla_mese = Int32.Parse(lastrow[0].ToString());
                payment.giorno = Int32.Parse(lastrow[1].ToString());
                payment.causale = lastrow[2].ToString();
                payment.importo = Double.Parse(lastrow[3].ToString());
                list.Add(payment);
            }
            return list;
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
            tip.SetToolTip(btnSpeseAnnuali, "Avvia modulo Spese Annuali");
            tip.SetToolTip(btnContoCorrente, "Avvia modulo Conto Corrente");
            tip.SetToolTip(btnLibretto, "Avvia modulo Libretto e PostPay");
            tip.SetToolTip(btnMantenimento, "Avvia modulo Mantenimento");

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
                list.Images.Add(Image.FromFile(pathIco + "Moduls.png"));
                //assegna la lista di immagini al tabcontrol
                tabMenu.ImageList = list;
                pgHome.ImageIndex = 1;
                pgInsert.ImageIndex = 0;
                pgModify.ImageIndex = 2;
                pgSearch.ImageIndex = 3;
                pgModules.ImageIndex = 4;

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
            if(txtBalanceST.Text.Length > 0)
            {
                total = Double.Parse(txtBalanceST.Text);
            }
            for (i = 0; i < table.Rows.Count; i++)
            {
                row = table.NewRow();
                row.ItemArray = table.Rows[i].ItemArray;
                total += Double.Parse(row[3].ToString());
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

         #region form

        private void frmContoCorrente_Load(object sender, EventArgs e)
        {
            Clipboard.Clear();
            toolTip();
            loadImage();
            model.loadTree(treeYears);
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);

            //impostazioni di tabella e datagridview
            grdMonthVoices.DataSource = table;
            table.Columns.Add("ID");
            table.Columns.Add("GIORNO");
            table.Columns.Add("CAUSALE DEL MOVIMENTO");
            table.Columns.Add("IMPORTO");
            grdMonthVoices.Columns[0].Width = (grdMonthVoices.Width * 5) / 100;
            grdMonthVoices.Columns[1].Width = (grdMonthVoices.Width * 5) / 100;
            grdMonthVoices.Columns[2].Width = (grdMonthVoices.Width * 75) / 100;
            grdMonthVoices.Columns[3].Width = (grdMonthVoices.Width * 15) / 100;
            grdMonthVoices.Columns[0].ReadOnly = true;

            txtYearMonth.Text = "Gestione Conto Corrente.....";

        }

        //Intercetta la chusura del form
        private void frmContoCorrente_FormClosing(object sender, FormClosingEventArgs e)
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
       
        public void btnLoadYears_Click(object sender, EventArgs e)
        {
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            List<ModelDataCC.PaymentCC> listdata = new List<ModelDataCC.PaymentCC>();
            List<string> listinsert = new List<string>();
            string selezione, anno, mese;
            int year, month, i;
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
                anno = treeYears.SelectedNode.Parent.Text;
                mese = treeYears.SelectedNode.Text.ToLower();
                manage_mese = mese;

                if (anno == "ANNI") return;
                else
                {
                    year = Int32.Parse(anno);
                    month = selmonth(mese);
                    //assegna il valore alle variabili globali per la gestione con DB
                    year_manage = year;
                    month_manage = month;
                    //carica i dati da DB e li assegna alla lista
                    listdata = model.loadDataCC(mese, year);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_tupla_mese.ToString());
                        listinsert.Add(listdata[i].giorno.ToString());
                        listinsert.Add(listdata[i].causale);
                        listinsert.Add(listdata[i].importo.ToString());
                        populate.inserisci(4, listinsert);
                        listinsert.Clear();
                        i++;
                    }
                    txtYearMonth.Text = mese.ToUpper() + " " + anno.ToUpper();
                }
            }

            isChanged = false;
            isLoad = true;
            //deseleziona l'albero 
            treeYears.SelectedNode = null;
            //carica il valore di saldo del mese precedente e lo inserisce nella textbox
            txtBalanceST.Text = model.balanceMonthPre(year, month).ToString();
            //conteggia il saldo finale
            counter();
            //tronca il bilancio iniziale
            if(txtBalanceST.Text.Length > 1)
            {
                check = new Checker();
                check.truncate(txtBalanceST, 2);
            }
            //Se non caricato l'ultimo anno il Datagridview è disabilitato
            //Disabilito inserimento, modifiche, calcellazione e salvataggio
            lastyear = checkLastYear(year_manage);
            if (!lastyear)
            {
                grdMonthVoices.ReadOnly = true;
                btnInsert.Enabled = false;
                btnSave.Enabled = false;
                btnSaveData.Enabled = false;
                btnSaveThree.Enabled = false;
                btnModifyRow.Enabled = false;
                btnDeleteRow.Enabled = false;
            }
            else
            {
                grdMonthVoices.ReadOnly = false;
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

            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            List<string> list = new List<string>();
            
            int id = 0, idgrid = 0, idDB = 0;
            string father = "ListError";
            string feature = "ErrorTitle";

            //verifica sulla presenza di tutti i campi dalla classe checker
            //e che sia stato caricato un anno\mese
            if (isLoad == false) return;

            populate.path = pathxml;
            populate.father = father;
            populate.feature = feature;
            check = new Checker(pathxml);

            try
            {

                if(!(check.isEmpty(txtDay.Texts)) && !(check.isEmpty(txtCause.Texts)) && !(check.isEmpty(txtImport.Texts)))
                {
                    if(check.isNumeric(txtDay.Texts) && check.isNumeric(txtImport.Texts) && check.inRange(txtDay.Texts, 1, 31))
                    {
                        //Acquisisce il valore di PK da DataGridView se c'è almeno una riga
                        if (!(table.Rows.Count == 0))
                        {
                            int i = table.Rows.Count - 1;
                            DataRow lastrow = table.NewRow();
                            lastrow.ItemArray = table.Rows[i].ItemArray;
                            idgrid = Int16.Parse(lastrow[0].ToString());
                        }

                        //Acquidisce il valore di primary key da DB, in base al mese selezionato
                        idDB = model.primaryKey($"{manage_mese}_cc", $"id_{manage_mese}_cc");

                        //Se la chiave è maggiore quella della griglia incrementala di 1
                        //valori inseriti e non ancora salvati
                        if (idgrid >= idDB) id = idgrid + 1;
                        //altrimenti incrementa di 1 la chiave prelevata da DB
                        else id = idDB + 1;

                        list.Add(id.ToString());
                        list.Add(txtDay.Texts);
                        list.Add(txtCause.Texts);
                        list.Add(txtImport.Texts.Replace('.', ','));

                        //Popola la griglia attraverso la lista
                        populate.inserisci(4, list);

                        //Resetta i valori
                        txtDay.Texts = "";
                        txtCause.Texts = "";
                        txtImport.Texts = "";
                        txtDay.Focus();
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

            //genera la lista(ModelDataCC.PaymentCC)da struct della tabella e salva i dati nel DB
            List<ModelDataCC.PaymentCC> lista = createListStruct();
            isSaved = model.saveDataCC(manage_mese.ToLower(), year_manage, lista);
            isSavedBalance = model.saveBalanceMonth(balance, year_manage, month_manage);
            //verifica il corretto salvataggio dei dati
            if(isSavedBalance == false || isSaved == false)
            {
                MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                statusPanel();
            }

        }
        //Inserisce il Saldo finale nel mese appena iniziato, altrimenti al
        //primo caricamento in spese annuali non è visibile il saldo del CC
        private void btnCloseMonth_Click(object sender, EventArgs e)
        {
            if (isLoad == false) return;

            double balance = Double.Parse(txtBalanceOV.Text);
            bool isSavedBalance = false;
            int nextMonthUpdate, yearClose;
            bool lastYear;

            //Verifica di essere all'ultimo mese per la chiusura dell'anno e aggiornamento anno successivo
            //altrimenti aggiorna il mese successivo
            if(month_manage == 12)
            {
                nextMonthUpdate = 1;
                yearClose = year_manage + 1;
                //Invoca il metodo di controllo per verificare sia stato creato il nuovo anno
                lastYear = checkLastYear(yearClose);
                //Se l'anno passato al metodo non è uguale all'ultimo anno ricevo false
                if (!lastYear)
                {
                    MessageBox.Show("Impossibile chiudere il mese, l'anno successivo non è stato creato",
                           "Attenzione!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                nextMonthUpdate = month_manage + 1;
                yearClose = year_manage;
            }

            //salva il bilancio finale del mese nel mese successivo
            isSavedBalance = model.saveBalanceMonth(balance, yearClose, nextMonthUpdate);
            //verifica il corretto salvataggio dei dati
            if (isSavedBalance == false)
            {
                MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Update effettuato con successo !!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            int index = grdMonthVoices.Rows.IndexOf(grdMonthVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            //se confermato elimina la riga
            if (MessageBox.Show("Sicuro di voler eliminare la riga ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                populate.deleterow();
            }
            counter();
            
        }
        
        private void btnModifyRow_Click(object sender, EventArgs e)
        {
            //istanza per form modifica e per aggiornare il datagridview
            frmModify frmMod = new frmModify();
            PopulateGrid populate = new PopulateGrid(grdMonthVoices,table);
            string id, day, cause, import;
            List<ModelDataCC.PaymentCC> listdata = new List<ModelDataCC.PaymentCC>();
            List<string> listinsert = new List<string>();
            int i;
            string mese;
            //variabile di avvenuta modifica
            bool modifyRow = false;
            try
            {
                //prelevo i dati dal datagridview
                var val = grdMonthVoices.CurrentRow.Cells;
                id = val[0].Value.ToString();
                day = val[1].Value.ToString();
                cause = val[2].Value.ToString();
                import = val[3].Value.ToString();
                //passo i dati ai setter di frmModify
                frmMod.setId = id;
                frmMod.setDay = day;
                frmMod.setCause = cause;
                frmMod.setImport = import;
                //setto l'anno e il mese selezionato
                frmMod.setYear = year_manage;
                frmMod.setId_month = month_manage;
                //visualizzo il form
                frmMod.ShowDialog();
                //ricevo tru dal getter se alvataggio avvenuto con successo
                modifyRow = frmMod.verify;
                if(modifyRow == true)
                {//aggiorno il datagridview
                    isSaved = true;
                    table.Rows.Clear();
                    //prelevo il valore del mese dal getter di frmModify
                    mese = frmMod.setMonth;
                    //carica i dati da DB e li assegna alla lista
                    listdata = model.loadDataCC(mese, year_manage);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_tupla_mese.ToString());
                        listinsert.Add(listdata[i].giorno.ToString());
                        listinsert.Add(listdata[i].causale);
                        listinsert.Add(listdata[i].importo.ToString());
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


        private void btnUp_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMonthVoices.Rows.IndexOf(grdMonthVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            populate.mouveUp();
            grdMonthVoices.CurrentRow.Selected = true;
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMonthVoices.Rows.IndexOf(grdMonthVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            populate.mouveDown();
            grdMonthVoices.CurrentRow.Selected = true;
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
        
        //Avvia il modulo Spese Annuali
        private void btnSpeseAnnuali_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/speseannuali", "SpeseAnnuali");
        }
        //Avvia il modulo Libretto
        private void btnLibretto_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/libretto", "Libretto");
        }
        //Avvia il modulo PostPay
        private void btnPostPay_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/postpay", "PostPay");
        }
        //Avvia il modulo Mantenimento
        private void btnMantenimento_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/mantenimento", "Mantenimento");
        }
        //Avvia il modulo Reports
        private void btnRunningReports_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/report", "RunningReports");
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
            svdPDF.FileName = year_manage.ToString() + "_" + month_manage.ToString() + "_" + "DataCC.pdf";
            //Se premuto ok nel SaveDialog
            if (svdPDF.ShowDialog() == DialogResult.OK)
            {
                //istanza alla classe
                DataGridViewToPDF dataPDF = new DataGridViewToPDF(grdMonthVoices);
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

        private void grdMonthVoices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //imposta parametri al cambiamento diretto di una cella
            isChanged = true;
            isSaved = false;
            statusPanel();
            counter();
        }

        private void grdMonthVoices_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //modifica il . in una , per il corretto cast double
            if (grdMonthVoices.CurrentCell.ColumnIndex == 3)
            {
                var val = grdMonthVoices.CurrentCell.Value;
                string valore = val.ToString().Replace('.', ',');
                grdMonthVoices.CurrentCell.Value = valore;
            }

        }

        private void grdMonthVoices_MouseClick(object sender, MouseEventArgs e)
        {
            //se viene premuto il tasto SX, esci dalla funzione
            if (e.Button == MouseButtons.Left) return;
            //istanza alla classe di creazione del ContextMenu
            CreateContexMenu creatMenu = new CreateContexMenu(grdMonthVoices);
            //setting degli eventi da richiamare con i pulsanti
            creatMenu.setEvents("delete", btnDeleteRow_Click);
            creatMenu.setEvents("modifyIt", btnModifyRow_Click);
            creatMenu.setEvents("moveUp", btnUp_Click);
            creatMenu.setEvents("moveDown", btnDown_Click);
            //mostra il menu
            creatMenu.showContextMenu(e);
        }

        #endregion

        #region TreeView

        private void treeYears_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Verifica sia chiccato un nodo esistente
            if (e.Node == null) return;
            //Se il nodo è espandibile modifica l'immagine
            if (e.Node.IsExpanded) e.Node.ImageIndex = 1;
            else e.Node.ImageIndex = 0;

        }

        private void treeYears_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //Affinché possa ridisegnare è necessario impostare l'attributo
            //DrawMode su OwnerDrawText

            Image image;

            //Antialias sul disegno del testo
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //Se TreeView perde il focus disegna i nodi in modo standard
            if (treeYears.Focused == false)
            {
                //Evita il sovrapporsi del disegno del nodo
                treeYears.FullRowSelect = true;
                e.DrawDefault = true;
                return;
            }

            // Draw the background and node text for a selected node.
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                // Draw the background of the selected node. The NodeBounds
                // method makes the highlight rectangle large enough to
                // include the text of a node tag, if one is present.
                e.Graphics.FillRectangle(Brushes.LightSteelBlue, NodeBounds(e.Node));

                //Evita il sovrapporsi del disegno del nodo
                treeYears.FullRowSelect = false;

                // Retrieve the node font. If the node font has not been set,
                // use the TreeView font.
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                // Draw the node text.
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black,
                    Rectangle.Inflate(e.Bounds, 2, 0));
                
                //Verifica se il nodo è espanso e imposta l'icona
                if (e.Node.IsExpanded)
                {
                    //Disegna l'immagine al nodo selezionato
                    image = Image.FromFile(Routes.ICONS + "Ordina_giu.png");
                    e.Graphics.DrawImage(image, e.Node.Bounds.X - 30, e.Node.Bounds.Y, 20, 20);
                }
                else
                {
                    //Se il nodo non ha nodi genitori, imposta l'icona
                    if (e.Node.Parent == null)
                    {
                        //Disegna l'immagine al nodo selezionato
                        image = Image.FromFile(Routes.ICONS + "Ordina_dx.png");
                        e.Graphics.DrawImage(image, e.Node.Bounds.X - 30, e.Node.Bounds.Y, 20, 20);
                        return;
                    }
                    //Se ha nodi genitori in posta l'icona in base allo stao
                    if (e.Node.IsExpanded)
                    {
                        //Disegna l'immagine al nodo selezionato
                        image = Image.FromFile(Routes.ICONS + "Ordina_giu.png");
                        e.Graphics.DrawImage(image, e.Node.Bounds.X - 30, e.Node.Bounds.Y, 20, 20);
                    }
                    else
                    {
                        //Disegna l'immagine al nodo selezionato
                        image = Image.FromFile(Routes.ICONS + "Ordina_dx.png");
                        e.Graphics.DrawImage(image, e.Node.Bounds.X - 30, e.Node.Bounds.Y, 20, 20);
                    }

                }
                
            }
            else
            {
                //Se il nodo non è selezionato lo disegna in modo standard
                e.DrawDefault = true;
            }

        }

        private void treeYears_MouseDown(object sender, MouseEventArgs e)
        {
            //Cliccando sul + seleziona il nodo
            TreeNode clickedNode = treeYears.GetNodeAt(e.X, e.Y);
            if (NodeBounds(clickedNode).Contains(e.X, e.Y))
            {
                treeYears.SelectedNode = clickedNode;
            }
        }

        //Ritorna i limiti del nodo selezionato incluso il testo
        private Rectangle NodeBounds(TreeNode node)
        {
            //Definisce il font del nodo
            Font tagFont = new Font("MS Reference Sans Serif", 10, FontStyle.Regular);
            //Definisce i limiti del nodo
            Rectangle bounds = new Rectangle(0, node.Bounds.Y, treeYears.Width, node.Bounds.Height);
            // Set the return value to the normal node bounds.
            //Rectangle bounds = node.Bounds;
            if (node.Tag != null)
            {
                // Retrieve a Graphics object from the TreeView handle
                // and use it to calculate the display width of the tag.
                Graphics g = treeYears.CreateGraphics();
                int tagWidth = (int)g.MeasureString(node.Tag.ToString(), tagFont).Width + 6;

                // Adjust the node bounds using the calculated value.
                bounds.Offset(tagWidth / 2, 0);
                bounds = Rectangle.Inflate(bounds, tagWidth / 2, 0);
                g.Dispose();
            }

            return bounds;
        }

        //Carica i dati al doppio click sul nodo prescelto
        private void treeYears_DoubleClick(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }

        #endregion

        #region Textbox

        private void txtSearchVoice_TextChanged(object sender, EventArgs e)
        {
            //cerco all'interno del datagridview passando la colonna in cui cercare
            Searching search = new Searching(grdMonthVoices, table, txtSearchVoice);
            search.searchingRow(2);
        }

        //Setta i colori delle TextBox all'inserimento 
        private void txtDay_Enter(object sender, EventArgs e)
        {
            txtDay.BorderColor = Color.FromArgb(161, 223, 239);
            txtDay.BackColor = Color.FromArgb(210, 228, 242);
        }

        private void txtDay_Leave(object sender, EventArgs e)
        {
            txtDay.BorderColor = Color.DimGray;
            txtDay.BackColor = Color.White;
        }

        private void txtCause_Enter(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.FromArgb(161, 223, 239);
            txtCause.BackColor = Color.FromArgb(210, 228, 242);
        }

        private void txtCause_Leave(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.DimGray;
            txtCause.BackColor = Color.White;
        }

        private void txtImport_Enter(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.FromArgb(161, 223, 239);
            txtImport.BackColor = Color.FromArgb(210, 228, 242);
        }

        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.DimGray;
            txtImport.BackColor = Color.White;
        }

        #endregion

    #endregion

    }
}
