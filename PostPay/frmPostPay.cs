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
        //istanza alla classe di gestione con DB
        ModelDataPP model;
        //Istanza alla classe checker
        private Checker check;
        //numero dell'anno e mese caricato
        public int year_manage, month_manage;
        //Variabili private necessarie alla paginazione
        private int[] min;
        private int[] max;
        private double pages;
        private int range;
        //Massimo numero di righe per pagina
        private const int MAXROW = 20;
        //Lista popolata da DB per la paginazione
        private List<ModelDataPP.PaymentPP> listdata;

        public frmPostPay()
        {
            InitializeComponent();
            table = new DataTable();
            tableSaveCount = new DataTable();
            model = new ModelDataPP();
            pages = 0;
            range = 0;
            pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
            isLoad = false;
            isSaved = false;
            isChanged = false;

    }

        #region FUNZIONI
        /// <summary>
        /// Metodo per la gestione lista di PostPay basata sulla struttura PaymentLibPP
        /// </summary>
        /// <param name="table">tabella per creare la lista</param>
        /// <returns>Ritorna la lista(PaymentLibPP) per il salvataggio su DB</returns>
        private List<ModelDataPP.PaymentPP> createListStruct(DataTable table)
        {
            ModelDataPP.PaymentPP payment;
            List<ModelDataPP.PaymentPP> lista = new List<ModelDataPP.PaymentPP>();
            //cicla tutta la tabella e aggiunge gli elementi alla lista
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                payment.id_postpay = Int32.Parse(lastrow[0].ToString());
                payment.causale = lastrow[1].ToString();
                payment.importo = Double.Parse(lastrow[2].ToString());
                payment.id_mese = Int32.Parse(lastrow[3].ToString());
                lista.Add(payment);

            }
            return lista;
        }

        /// <summary>
        /// Metodo per paginare la tabella del Datagrdiview
        /// </summary>
        /// <param name="populate">Oggetto per popolare la Datagridview in base alla tabella passata al costruttore</param>
        private void loadPaginationTable(PopulateGrid populate)
        {            
            //Variabili per la paginazione
            //Con calcolo della divisione in pagine
            double countpages = (double)listdata.Count / (double)MAXROW;
            int minimum = 0; int maxim = 19; int i; range = 0;

            //indicizza l'array
            pages = Math.Ceiling(countpages);
            min = new int[(int)pages];
            max = new int[(int)pages];

            //Se la lista è inferiore al max numero di righe non deve paginare
            if (listdata.Count <= MAXROW)
            {
                min[0] = minimum;
                max[0] = listdata.Count;
            }
            else
            {
                //Definisce i range di minimo e massimo per la paginazione
                for (i = 0; i < pages; i++)
                {
                    min[i] = minimum;
                    max[i] = maxim;
                    minimum = minimum + 19;
                    maxim = maxim + 19;

                }
            }

            //Carica i dati nel datagridview per il primo range
            populateGridview(populate, min[range], max[range]);
      
        }

        /// <summary>
        /// Metodo per la popolazione del DataTable di visualizzazione, conversione da numero mese a nome mese
        /// </summary>
        /// <param name="listdata"></param>
        /// <param name="populate"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        private void populateGridview(PopulateGrid populate, int min, int max)
        {
            List<string> listinsert = new List<string>();
            int i = min;
            while (i < max)
            {
                if (i == listdata.Count) return;
               
                listinsert.Add(listdata[i].id_postpay.ToString());
                listinsert.Add(listdata[i].causale);
                listinsert.Add(listdata[i].importo.ToString());
                listinsert.Add(selmonth(listdata[i].id_mese));
                populate.inserisci(4, listinsert);
                listinsert.Clear();
                i++;
            }
        }

        private void populateDataTable(PopulateGrid populateCount)
        {
            List<string> listinsert = new List<string>();
            int j = 0;
            while (j < listdata.Count)
            {
                listinsert.Add(listdata[j].id_postpay.ToString());
                listinsert.Add(listdata[j].causale);
                listinsert.Add(listdata[j].importo.ToString());
                listinsert.Add(listdata[j].id_mese.ToString());
                populateCount.inserisci(4, listinsert);
                listinsert.Clear();
                j++;
            }
        }

        /// <summary>
        /// Metodo per salvare il saldo annuo
        /// </summary>
        /// <returns></returns>
        private bool saveBalance()
        {
            double balance = Double.Parse(txtBalanceOV.Text);
            bool isSavedBalance = false;
            try
            {
                isSavedBalance = model.saveBalanceYear(balance, year_manage, true);
            }
            catch (Exception ex)
            {
                isSavedBalance = false;
            }
            return isSavedBalance;
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
            string pathIco = @"C:\MpFA22\Icons\";
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
        /// necessario alla visualizzazione
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
            model.loadTree(treeYears, true);
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);

            //impostazioni di tabella e datagridview
            grdMonthVoices.DataSource = table;
            table.Columns.Add("ID");
            table.Columns.Add("CAUSALE DEL MOVIMENTO");
            table.Columns.Add("IMPORTO");
            table.Columns.Add("MESE");
            grdMonthVoices.Columns[0].Width = 70;
            grdMonthVoices.Columns[1].Width = 650;
            grdMonthVoices.Columns[2].Width = 90;
            grdMonthVoices.Columns[3].Width = 80;
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
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            //Necessario al conteggio del saldo
            PopulateGrid populateCount = new PopulateGrid(grdMonthVoices, tableSaveCount);
            listdata = new List<ModelDataPP.PaymentPP>();
            string selezione, anno;
            int year;
            bool lastyear = false;

            table.Rows.Clear();
            tableSaveCount.Rows.Clear();

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
                    listdata = model.loadDataPP(year);

                    //Verifica ci siano elementi per la paginazione
                    if(listdata.Count > 0)
                    {
                        //Invoca il metodo per popolare la DataTable per il salvataggio e conteggio
                        populateDataTable(populateCount);

                        //Invoco il metodo per paginare la datageridview
                        loadPaginationTable(populate);
                        //Aggiorno la grafica
                        double writepages = pages - 1;
                        lblPages.Text = "(" + range.ToString() + " / " + writepages.ToString() + ")";
                        //Abilita il pulsante avanti se c'è più di una pagina
                        if(listdata.Count > MAXROW) btnForward.Enabled = true;

                    }

                    txtYearMonth.Text = "Anno caricato : " + anno;                   
                }
            }
           
            isChanged = false;
            isLoad = true;
            //deseleziona l'albero 
            treeYears.SelectedNode = null;
            //carica il valore di saldo del mese precedente e lo inserisce nella textbox
            txtBalanceST.Text = model.balanceYearPre(year, true).ToString();
            //Esegue il conteggio della tabella
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
                btnInsert.Enabled = false;
                btnSave.Enabled = false;
                btnSaveData.Enabled = false;
                btnSaveThree.Enabled = false;
                btnModifyRow.Enabled = false;
                btnDeleteRow.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = true;
                btnSave.Enabled = true;
                btnSaveData.Enabled = true;
                btnSaveThree.Enabled = true;
                btnModifyRow.Enabled = true;
                btnDeleteRow.Enabled = true;
            }

        }

        //Metodo per avanzare con il range della paginazione
        private void btnForward_Click(object sender, EventArgs e)
        {
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);

            //Verifica di non essere arrivato all'ultimo range
            if (range < pages - 1) range++;
            else range = 0;
            //Stabilisce il punto minimo da cui partire
            int i = min[range];
            //Per la visualizzazione pagine
            double writepages = pages - 1;

            //Definisce e popola la Datagridview
            table.Rows.Clear();       
            populateGridview(populate, min[range], max[range]);
           
            //Abilita il tasto indietro
            btnBack.Enabled = true;
            //Aggiorna la posizione pagina
            lblPages.Text = "(" + range.ToString() + " / " + writepages.ToString() + ")";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);

            //Per la visualizzazione pagine
            double writepages = pages - 1;

            if (range > 0) range--;
            else return;

            //Stabilisce il punto minimo da cui partire
            int i = min[range];

            //Definisce e popola la Datagridview
            table.Rows.Clear();
            populateGridview(populate, min[range], max[range]);
           
            //Aggiorna la posizione pagina
            lblPages.Text = "(" + range.ToString() + " / " + writepages.ToString() + ")";
        }

        private void btnLoadYears2_Click(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //in questo metodo non è necessario passare per riferimento l'anno
            //in quanto il valore passato è già valorizzato dopo il caricamento
            //sono necessari gli altri puntatori
            if (isLoad == false || isSaved == true) return;
            if (isChanged == false) return;

            //genera la lista dalla tabella e salva i dati nel DB attraverso la classe modeldata
            List<ModelDataPP.PaymentPP> lista = createListStruct(tableSaveCount);
            isSaved = model.saveDataPP(year_manage, lista);
            bool isSavedBalance = saveBalance();
            
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

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnSaveThree_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();

            //Inserisce solo sull'ultima pagina
            if (range < pages - 1)
            {
                MessageBox.Show("Posizionarsi sull'ultima pagina per l'inserimento", "Attenzione!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            //Necessario al conteggio del saldo
            PopulateGrid populateCount = new PopulateGrid(grdMonthVoices, tableSaveCount);
            Checker check;
            //Lista di inserimento per il salvataggio
            List<string> listCountSave = new List<string>();
            //Lista di inserimento per la visualizzazione con il mese in formato stringa
            List<string> list = new List<string>();
            bool[] isempty = new bool[2];
            bool isNumeric = false;
            bool isSelected = false;
            int id = 0;
            int month;
            string father = "ListError";
            string feature = "ErrorTitle";
            int idgrid = 0, idDB = 0;
            
            //verifica sulla presenza di tutti i campi dalla classe checker
            //e che sia stato caricato un anno\mese
            if (isLoad == false) return;
            populate.path = pathxml;
            populate.father = father;
            populate.feature = feature;
            check = new Checker(pathxml, father, feature);
            isempty[0] = check.isEmpty(txtImport);
            isempty[1] = check.isEmpty(txtCause);
            isNumeric = check.isnumeric(txtImport);
            isSelected = check.isSelected(cmbMonths);

            //esci dalla funzione se controlli ko
            if (isNumeric == false || isSelected == false) return;

            //acquisisco il valore di PK da DataGridView
            if (!(table.Rows.Count == 0))
            {
                int i = table.Rows.Count - 1;
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                idgrid = Int16.Parse(lastrow[0].ToString());
            }

            //acquidisco il valore di primary key da DB
            idDB = model.primaryKey("postpay", "id_postpay");

            //Se la chiave è maggiore quella della griglia incrementala di 1
            //valori inseriti e non ancora salvati
            if (idgrid >= idDB) id = idgrid + 1;
            //altrimenti incrementa di 1 la chiave prelevata da DB
            else id = idDB + 1;

            //inserisce nella lista i valori inseriti da textbox
            if (!(isempty[0] == true || isempty[1] == true))
            {
                listCountSave.Add(id.ToString());
                listCountSave.Add(txtCause.Text);
                listCountSave.Add(txtImport.Text.Replace('.', ','));
                //ottiene il numero del mese dal mese selezionato
                month = selmonth(cmbMonths.SelectedItem.ToString());
                listCountSave.Add(month.ToString());
                //lista di visualizzazione mese in formato stringa
                list.Add(id.ToString());
                list.Add(txtCause.Text);
                list.Add(txtImport.Text.Replace('.', ','));
                list.Add(cmbMonths.SelectedItem.ToString());

            }
            else return;
            //popola la griglia attraverso la lista
            populate.inserisci(4, list);
            //popola la tabella per il calcolo del saldo
            populateCount.inserisci(4, listCountSave);

            txtCause.Clear();
            txtImport.Clear();
            cmbMonths.SelectedItem = null;
            cmbMonths.Focus();
            counter();
        }


        private void btnCloseYear_Click(object sender, EventArgs e)
        {
            if (isLoad == false || isSaved == true) return;

            bool isSavedBalance = false;
            double balance = Double.Parse(txtBalanceOV.Text);
            bool lastyear = false;
            int yearnext = year_manage + 1;

            //Verifica sia stato creato il nuovo anno per la chiusura
            lastyear = checkLastYear(yearnext);
            if (lastyear)
            {
                isSavedBalance = model.saveBalanceYear(balance, yearnext, true);
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
                                                       
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            //se confermato elimina la riga
            if (MessageBox.Show("Sicuro di voler eliminare la riga ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                populate.deleterow();
                //Calcola l'indice della riga selezionata in base al numero di pagina
                //e elimina la riga dalla tabella per il salvataggio e il conteggio
                //20 = righe per pagina; range = pagina corrente; index = riga corrente
                int indexTableSave = (MAXROW * range) + index;
                tableSaveCount.Rows.RemoveAt(indexTableSave);
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
            //istanza per form modifica e per aggiornare il datagridview
            frmModify frmMod = new frmModify();
            PopulateGrid populate = new PopulateGrid(grdMonthVoices, table);
            PopulateGrid populateCount = new PopulateGrid(grdMonthVoices, tableSaveCount);
            string id, cause, import, id_month;

            //variabile di avvenuta modifica
            bool modifyRow = false;
            try
            {
                //prelevo i dati dal datagridview
                var val = grdMonthVoices.CurrentRow.Cells;
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
                    tableSaveCount.Rows.Clear();
                    
                    //Carica i dati da DB e li assegna alla lista
                    //Aggiorna la tabella integrale per salvataggio e conteggio
                    //Invocando il metodo di popolazione
                    listdata = model.loadDataPP(year_manage);
                    populateDataTable(populateCount);

                    //Invoco il metodo per paginare la datageridview
                    loadPaginationTable(populate);

                }
                
                counter();
                //Salva il saldo annuo e aggiorna lo stato di salvataggio
                bool isSavedBalance = saveBalance();
                if (isSavedBalance == false)
                    MessageBox.Show("Errore di salvataggio dei dati", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else statusPanel();

                //Aggiorna la posizione pagina
                //Per la visualizzazione pagine
                double writepages = pages - 1;
                lblPages.Text = "(" + range.ToString() + " / " + writepages.ToString() + ")";
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
            form.oftenCause = txtCause;
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
            svdPDF.FileName = year_manage.ToString() + "_" + month_manage.ToString() + "_" + "DataPP.pdf";
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

        #endregion

        #endregion

    }
}
