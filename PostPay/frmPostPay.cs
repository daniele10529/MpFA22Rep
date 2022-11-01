using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ManageGrid;
using GenericModelData;
using Checking;
using CreateForm;
using MenuGenerator;
using PDFCreator;

namespace PostPay
{
    public partial class frmPostPay : Form
    {

        //tabella contenente i dati utilizzata in sola lettura per la paginazione Datagridview
        private DataTable table;
        //Tabella integrale per il salvataggio dei dati e il calcolo del saldo
        private DataTable tableSaveCount;
        //percorso file xml con errori
        private string pathxml;
        //verifica sul comportamento utente
        private bool isLoad;
        private bool isSaved;
        private bool isChanged;
        //Gestione DB
        ModelDataPostPay modelPP;
        ModelDataPostPay.RecordPostPay record;
        //Istanza alla classe checker
        private Checker check;
        //Variabile anno di passaggio a form modify
        public int year_manage;

        public frmPostPay()
        {
            InitializeComponent();
            table = new DataTable();
            tableSaveCount = new DataTable();

            modelPP = new ModelDataPostPay();
            record = new ModelDataPostPay.RecordPostPay();

            pathxml = Routes.XMLErrors;
            isLoad = false;
            isSaved = false;
            isChanged = false;

        }

        #region Metodi Privati

        /// <summary>
        /// Metodo per salvare il saldo annuo
        /// </summary>
        /// <returns></returns>
        private bool saveBalance()
        {
            double balance = Double.Parse(txtBalanceOV.Text);
            bool isSavedBalance = false;
            //Esegue e verifica il corretto salvataggio del saldo annuale
            if (modelPP.saveBalanceYear(balance, record)) isSavedBalance = true;
            
            return isSavedBalance;
        }

        /// <summary>
        /// Metodo per l'aggiornamento di visualizzazione della griglia
        /// </summary>
        /// <param name="modify">Stabilisce il chiamante per la pagina da visualizzare</param>
        private void updateGridView(bool modify)
        {
            int page;

            //aggiorno il datagridview
            isSaved = true;
            table.Rows.Clear();
            tableSaveCount.Rows.Clear();

            //Valorizza la tabella con il totale dei dati per PDF e count
            tableSaveCount = modelPP.getAll(record);
            //Calcola l'indice di partenza della pagina da visualizzare
            //in base al chiamante => insert o modifyrow
            if(modify) page = modelPP.CurrentPage;
            else page = modelPP.Pages;

            //Verifica in caso di eliminazione righe se sia necessario eliminare una pagina
            if (page > modelPP.Pages) page = modelPP.Pages;

            //Calcola l'indice di partenza della pagina
            int maxrow = ModelDataPostPay.MAXROW;
            int index = (page * maxrow) - maxrow;
            //Binding sui dati per visualizzazione della griglia
            modelPP.selectData(grdMonthVoices, table, record, index);
            //Print sulle pagine
            lblPages.Text = "(" + modelPP.CurrentPage + " / " + modelPP.Pages + ")";

            //Abilita i pulsanti in base alla posizione e numero delle pagine
            if(modelPP.Pages == 1)
            {
                btnBack.Enabled = false;
                btnForward.Enabled = false;
                return;
            }
            if (modelPP.CurrentPage == modelPP.Pages)
            {
                btnBack.Enabled = true;
                btnForward.Enabled = false;
            }
            else if(modelPP.CurrentPage == 1)
            {
                btnForward.Enabled = true;
                btnBack.Enabled = false;
            }

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
            for (i = 0; i < tableSaveCount.Rows.Count; i++)
            {
                row = tableSaveCount.NewRow();
                row.ItemArray = tableSaveCount.Rows[i].ItemArray;
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

        #region OGGETTI DEL FORM

        #region FORM

        private void frmPostPay_Load(object sender, EventArgs e)
        {
            string[] mesi = { "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre" };

            Clipboard.Clear();
            toolTip();
            loadImage();
            modelPP.loadTree(treeYears, true);
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);

            //impostazioni di tabella e datagridview
            grdMonthVoices.DataSource = table;
            table.Columns.Add("ID");
            table.Columns.Add("CAUSALE DEL MOVIMENTO");
            table.Columns.Add("IMPORTO");
            table.Columns.Add("MESE");
            grdMonthVoices.Columns[0].Width = (grdMonthVoices.Width * 5) / 100;
            grdMonthVoices.Columns[1].Width = (grdMonthVoices.Width * 70) / 100;
            grdMonthVoices.Columns[2].Width = (grdMonthVoices.Width * 15) / 100;
            grdMonthVoices.Columns[3].Width = (grdMonthVoices.Width * 10) / 100;
            grdMonthVoices.Columns[0].ReadOnly = true;
            grdMonthVoices.ReadOnly = true;

            //Set colonne della tabella per il calcolo del saldo
            tableSaveCount.Columns.Add("ID");
            tableSaveCount.Columns.Add("CAUSALE DEL MOVIMENTO");
            tableSaveCount.Columns.Add("IMPORTO");
            tableSaveCount.Columns.Add("MESE");

            //set valori comboBox mesi
            cmbMonths.Items.AddRange(mesi);
            
            //Set textbox YearMonth
            txtYearMonth.Text = "Gestione PostPay.....";

            //Disabilita i pulsanti indetro e avanti nella paginazione Datagridview
            btnForward.Enabled = false;
            btnBack.Enabled = false;

        }


        private void frmPostPay_FormClosing(object sender, FormClosingEventArgs e)
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

        #region BUTTON

        private void btnLoadYears_Click(object sender, EventArgs e)
        {
            bool lastyear = false;
            string selezione, anno;

            if (isChanged == true && isSaved == false)
            {
                if (MessageBox.Show("Sicuro di voler caricare un nuovo mese i dati non sono salvati ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }

            //Reinizializza le tabelle al caricamento
            table.Rows.Clear();
            tableSaveCount.Rows.Clear();


            //Controllo sulla selezione del nodo anno\mese dall'albero
            if (treeYears.SelectedNode == null) return;
            //Verifica di essere sul nodo ANNI
            selezione = treeYears.SelectedNode.Text;
            if (selezione == "ANNI") return;
            else
            {
                //Assegna il valore di anno\mese in base al nodo selezionato
                anno = treeYears.SelectedNode.Text;
                // Verifica di essere sul nodo ANNI
                if (anno == "ANNI") return;
                else
                {
                    //Assegna all'ADT il valore dell'anno selezionato
                    record.anno = Int32.Parse(anno);
                    //Assegna il valore alla variabile protetta globale
                    year_manage = record.anno;
                    //Valorizza la tabella con il totale dei dati per PDF e count
                    tableSaveCount = modelPP.getAll(record);
                    //Binding sui dati per visualizzazione della griglia
                    modelPP.selectData(grdMonthVoices, table, record);
                    //Print sulle pagine
                    lblPages.Text = "(" + modelPP.CurrentPage + " / " + modelPP.Pages + ")";

                }
                //Print sulla TextBox
                txtYearMonth.Text = "Anno caricato : ".ToUpper() + anno.ToUpper();
            }

            //Verifica lo stato dei pulsanti abilita l'avanti se ci sono più pagina
            //Disabilita il back
            if(modelPP.Pages == 1)
            {
                btnForward.Enabled = false;
                btnBack.Enabled = false;
            }
            else
            {
                btnForward.Enabled = true;
                btnBack.Enabled = false;
            }

            //Setta lo stato dell'applicazione
            isChanged = false;
            isLoad = true;
            //deseleziona l'albero 
            treeYears.SelectedNode = null;
            //carica il valore di saldo del mese precedente e lo inserisce nella textbox
            txtBalanceST.Text = modelPP.getBalanceYearPrev(record).ToString();
            //Esegue il conteggio del saldo dalla tabella interamente valorizzata
            counter();
            //tronca il bilancio iniziale
            if (txtBalanceST.Text.Length > 1)
            {
                check = new Checker();
                check.truncate(txtBalanceST, 2);
            }

            //Se non caricato l'ultimo anno il Datagridview è disabilitato
            //Disabilito inserimento, modifiche, calcellazione e salvataggio
            lastyear = checkLastYear(record.anno);
            if (!lastyear)
            {
                btnInsert.Enabled = false;
                btnSave.Enabled = false;
                btnModifyRow.Enabled = false;
                btnDeleteRow.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = true;
                btnSave.Enabled = true;
                btnModifyRow.Enabled = true;
                btnDeleteRow.Enabled = true;
            }

        }

        private void btnLoadYears2_Click(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }

        //Metodo per avanzare con il range della paginazione
        private void btnForward_Click(object sender, EventArgs e)
        {
            //Abilita il pulsante indietro
            btnBack.Enabled = true;
            //Mouve in avanti la pagina
            modelPP.forward(grdMonthVoices, table, record);
            //Visualizza lo stato pagine
            lblPages.Text = "(" + modelPP.CurrentPage + " / " + modelPP.Pages + ")";
            //Se arrivato all'ultima pagina disabilita il pulsante ed esce dal metodo
            if (modelPP.CurrentPage == modelPP.Pages)
            {
                btnForward.Enabled = false;
                return;
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Abilita il pulsante farward
            btnForward.Enabled = true;
            //Muove indietro la pagina
            modelPP.back(grdMonthVoices, table, record);
            //Visualizza lo stato pagine
            lblPages.Text = "(" + modelPP.CurrentPage + " / " + modelPP.Pages + ")";
            //Se arrivato all'ultima pagina disabilita il pulsante ed esce dal metodo
            if (modelPP.CurrentPage == 1)
            {
                btnBack.Enabled = false;
                return;
            }
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            //Se non è stato caricato l'anno esce dal metodo
            if (isLoad == false) return;
            //Inizializza variabili e pannello per l'insert
            isSaved = false;
            isChanged = true;
            statusPanel();

            Checker check = new Checker(pathxml);
            bool isSavedBalance = false;

            try
            {

                if (check.isSelected(cmbMonths) && !(check.isEmpty(txtCause.Texts)) && !(check.isEmpty(txtImport.Texts)))
                {
                    if (check.isNumeric(txtImport.Texts))
                    {
                        //Acquisisce i dati dai controls
                        record.causale = txtCause.Texts;
                        record.importo = Double.Parse(txtImport.Texts);
                        //Preleva il numero del mese dal nome e lo assegna al record 
                        record.id_mese = selmonth(cmbMonths.SelectedItem.ToString());
                        //L'anno è già acquisito in fase di caricamento

                        //Inserisco i dati del record nel DB
                        isSaved = modelPP.insert(record);

                        //Verifica il corretto salvataggio dei dati, e aggiorna la visualizzazione
                        if (isSaved == false)
                        {
                            MessageBox.Show("Errore di inserimento del record", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;

                        }
                        else
                        {
                            //Se l'inserimento del record è ok 
                            //Inserisce i dati del bilancio nel DB
                            isSavedBalance = saveBalance();

                            if (isSavedBalance == false)
                            {
                                MessageBox.Show("Errore di inserimento del bilancio annuale", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }

                            //Aggiorna la griglia e il pannello
                            updateGridView(false);
                            isSaved = true;
                            isChanged = false;
                            statusPanel();
                        }

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

        private void btnCloseYear_Click(object sender, EventArgs e)
        {
            if (isLoad == false || isSaved == true) return;

            bool isSavedBalance = false;
            double balance = Double.Parse(txtBalanceOV.Text);
            bool lastyear = false;
            int yearnext = record.anno + 1;

            //Verifica sia stato creato il nuovo anno per la chiusura
            lastyear = checkLastYear(yearnext);
            if (lastyear)
            {
                isSavedBalance = modelPP.saveBalanceYear(balance, yearnext);
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

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            
            isSaved = false;
            isChanged = true;
            statusPanel();

            //preleva l'indice dalla riga selezionata, se non selezionata non fa nulla
            int index = grdMonthVoices.Rows.IndexOf(grdMonthVoices.CurrentRow);
            if (index < 0) return;

            //Preleve i dati dalla riga selezionata del DataGridview
            var val = grdMonthVoices.CurrentRow.Cells;
            record.id_postpay = Int32.Parse(val[0].Value.ToString());

            //Se confermata eliminazione della riga
            if (MessageBox.Show($"Sicuro di voler eliminare la riga N° {record.id_postpay}?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                //Se le riga viene eliminata dal DB, viene eliminata dalla tabella totale
                if (modelPP.delete(record))
                {
                    isSaved = true;
                    isChanged = false;
                    statusPanel();
                    updateGridView(true);
                } 

            }
            counter();

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

        private void btnModifyRow_Click(object sender, EventArgs e)
        {
           
            //Istanza per form modifica e per aggiornare il datagridview
            frmModify frmMod = new frmModify();
            string id, cause, import, id_month;

            //Variabile di avvenuta modifica
            bool modifyRow = false;
            try
            {
                //Preleva i dati dal DataGridView
                var val = grdMonthVoices.CurrentRow.Cells;
                id = val[0].Value.ToString();
                cause = val[1].Value.ToString();
                import = val[2].Value.ToString();
                id_month = val[3].Value.ToString();
                //Passa i dati ai setter di frmModify
                frmMod.setId = id;
                frmMod.setCause = cause;
                frmMod.setImport = import;
                frmMod.setMonth = id_month;
                //Setta l'anno selezionato
                frmMod.setYear = record.anno;
                //Visualizza il form
                frmMod.ShowDialog();
                
                //Riceve true dal getter se alvataggio avvenuto con successo
                modifyRow = frmMod.verify;
                if (modifyRow == true)
                {
                    //Aggiorna il datagridview
                    updateGridView(true);
                    //Calcola il saldo mensile
                    counter();
                    //Salva il saldo annuo e aggiorna lo stato di salvataggio
                    bool isSavedBalance = saveBalance();
                    if (isSavedBalance == false)
                        MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        isChanged = false;
                        isSaved = true;
                        statusPanel();
                    }

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nessuna riga selezionata per la modifica, selezionare una riga" + ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

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
            svdPDF.FileName = record.anno.ToString() + "_" + "DataPostPay.pdf";
            //Se premuto ok nel SaveDialog
            if (svdPDF.ShowDialog() == DialogResult.OK)
            {
                //istanza alla classe
                DataGridViewToPDF dataPDF = new DataGridViewToPDF(tableSaveCount);
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

        #region GRIDVIEW

        private void grdMonthVoices_MouseClick(object sender, MouseEventArgs e)
        {
            //se viene premuto il tasto SX, esci dalla funzione
            if (e.Button == MouseButtons.Left) return;
            //istanza alla classe di creazione del ContextMenu
            CreateContexMenu creatMenu = new CreateContexMenu(grdMonthVoices);
            //setting degli eventi da richiamare con i pulsanti
            creatMenu.setEvents("delete", btnDeleteRow_Click);
            creatMenu.setEvents("modifyIt", btnModifyRow_Click);
            // creatMenu.setEvents("oftenVal", btnOftenVal_Click);
            creatMenu.setEvents("moveUp", btnUp_Click);
            creatMenu.setEvents("moveDown", btnDown_Click);
            //mostra il menu
            creatMenu.showContextMenu(e);
        }

        private void grdMonthVoices_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Modifica permessa solo attraverso la funzione modifica", "Attenzione!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        #region TEXTBOX

        private void txtSearchVoice_TextChanged(object sender, EventArgs e)
        {
            //cerco all'interno del datagridview passando la colonna in cui cercare
            Searching search = new Searching(grdMonthVoices, table, txtSearchVoice);
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


        private void txtImport_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se viene premuto il punto mette la virgola.
            //il carattere viene poi modificato dalla funzione di 
            //salvataggio della classe model
            if (e.KeyChar == '.') e.KeyChar = ',';

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
