using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ManageGrid;
using GenericModelData;
using ReadXML;
using MenuGenerator;
using CreateForm;
using LeaderProcess;
using Checking;
using PDFCreator;

namespace SpeseAnnuali
{
    public partial class frmSpeseAnnuali : Form
    {
        //tabella contenente i dati
        private DataTable table;
        //percorso file xml con errori
        private const string pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
        //Percorso file XML con definizione path processi
        private const string runPath = @"C:\MpFA22\RunPath\RunPath.xml";
        //verifica sul comportamento utente
        private bool isLoad;
        private bool isSaved;
        private bool isChanged;
        //istanza alla classe di gestione con DB
        private ModelDataSY model;
        //Istanza alla classe checker
        
        //numero dell'anno e mese caricato
        public int year_manage, month_manage;
        private string manage_mese;

        public frmSpeseAnnuali()
        {
            InitializeComponent();
            table = new DataTable();
            isLoad = false;
            isSaved = false;
            isChanged = false;
            model = new ModelDataSY();
        }


#region FUNZIONI

        /// <summary>
        /// Genera una list(ModelDataSY.PaymentSY) per l'inserimento nel DB
        /// </summary>
        /// <returns></returns>
        private List<ModelDataSY.PaymentSY> createListStruct()
        {
            List<ModelDataSY.PaymentSY> list = new List<ModelDataSY.PaymentSY>();
            ModelDataSY.PaymentSY payment;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                payment.id_tupla_mese = Int32.Parse(lastrow[0].ToString());
                payment.voce_spesa = lastrow[1].ToString();
                payment.importo = Double.Parse(lastrow[2].ToString());
                list.Add(payment);
            }
            return list;
        }

        /// <summary>
        /// Somma tutte le voci di spesa, e invia il valore alla textbox
        /// </summary>
        private void counter()
        {
            int i;
            double total = 0;
            DataRow row;

            txtTotSpends.ResetText();

            for (i = 0; i < table.Rows.Count; i++)
            {
                row = table.NewRow();
                row.ItemArray = table.Rows[i].ItemArray;
                total += Double.Parse(row[2].ToString());
            }
            txtTotSpends.Text = total.ToString();
        }

        /// <summary>
        /// Conteggia i soldi risparmiati, prelevando il totale entrate meno
        /// il totale delle spese. invia il valore alla textbox
        /// </summary>
        private void totKeepMoney()
        {
            double pay = 0, payadd = 0, totalspend = 0;
            double moneyKeep = 0;

            txtMoneyKeep.ResetText();

            //sostiuisce il punto con la virgola per evitare errore di cast con la variabile double
            if (txtPay.Text.Length > 0) pay = Double.Parse(txtPay.Text.Replace('.', ','));
            if (txtPlusEntry.Text.Length > 0) payadd = Double.Parse(txtPlusEntry.Text.Replace('.', ','));
            if (txtTotSpends.Text.Length > 0) totalspend = Double.Parse(txtTotSpends.Text.Replace('.', ','));
            //esegue il conteggio
            moneyKeep = (pay + payadd) - totalspend;
            txtMoneyKeep.Text = moneyKeep.ToString();
            //va in rosso se inferiore a 0
            if (moneyKeep > 0) txtMoneyKeep.ForeColor = Color.FromArgb(0, 128, 0);
            else txtMoneyKeep.ForeColor = Color.FromArgb(161, 31, 18);

        }

        /// <summary>
        /// resituisce il numero del mese in base a quello selezionato dall'albero
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
        /// Genera i tooltip sui pulsanti
        /// </summary>
        private void toolTip()
        {
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(btnNewYear, "Aggiungi un anno al DB");
            tip.SetToolTip(btnLoadYear, "Carica i valori dal DB del mese selezionato");
            tip.SetToolTip(btnNewYears, "Aggiungi un anno al DB");
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
            tip.SetToolTip(btnSetting, "Modifica Setup");
            tip.SetToolTip(btnSaveData, "Salva le modifiche");
            tip.SetToolTip(txtSearchVoice, "Ricarca nel DataGridView");
            tip.SetToolTip(txtContability, "Click per aggiornare contabilità");
            tip.SetToolTip(btnSetOftenValue, "Seleziona causale frequente");
            tip.SetToolTip(btnSpeseAnnuali, "Avvia modulo Spese Annuali");
            tip.SetToolTip(btnContoCorrente, "Avvia modulo Conto Corrente");
            tip.SetToolTip(btnLibretto, "Avvia modulo Libretto e PostPay");
            tip.SetToolTip(btnMantenimento, "Avvia modulo Mantenimento");
            tip.SetToolTip(btnPDFCreator, "Genera File PDF");
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
                list.Images.Add(Image.FromFile(pathIco + "Moduls.png"));
                //assegna la lista di immagini al tabcontrol
                tabMenu.ImageList = list;
                pageHome.ImageIndex = 1;
                pageInsert.ImageIndex = 0;
                pageModify.ImageIndex = 2;
                pageSearch.ImageIndex = 3;
                pageModules.ImageIndex = 4;

            }
            catch(Exception ex)
            {

            }
            
        }

        /// <summary>
        /// modifica il colore del pannello colorato in base al comportamento utente
        /// </summary>
        private void statusPanel()
        {
            if (isSaved == true) pnlStatus.BackColor = Color.FromArgb(0, 255, 0);
            else if(isSaved == false && isChanged == true) pnlStatus.BackColor = Color.FromArgb(255, 0, 0);
            else if(isLoad == true) pnlStatus.BackColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

        #region EVENTI DEGLI OGGETTI :

#region form
        private void frmSpeseAnnuali_Load(object sender, EventArgs e)
        {
            Clipboard.Clear();
            txtSaldoCC.Text = "0";
            txtSaldoLibretto.Text = "0";
            txtSaldoPP.Text = "0";
            
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);
            loadImage();
            toolTip();
            //associa i dati della griglia alla tabella
            grdMonthSpends.DataSource = table;
            //imposta il nome delle colonne
            table.Columns.Add("ID");
            table.Columns.Add("CAUSALE DI SPESA");
            table.Columns.Add("IMPORTO");
            //imposta la dimensione delle colonne
            grdMonthSpends.Columns[0].Width = 70;
            grdMonthSpends.Columns[1].Width = 760;
            grdMonthSpends.Columns[2].Width = 110;
            //la PK è di sola lettura
            grdMonthSpends.Columns[0].ReadOnly = true;

            txtYearMonth.Text = "Spese.....";

            model.loadTree(treeYears);
            
        }

        //Intercetta la chusura del form
        private void frmSpeseAnnuali_FormClosing(object sender, FormClosingEventArgs e)
        {//se i dati non sono salvati chiede conferma
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
        private void btnInsert_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();

            PopulateGrid populate = new PopulateGrid(grdMonthSpends, table);
            List<string> list = new List<string>();
            bool[] isempty = new bool[2];
            bool isNumeric = false;
            int id = 0, idgrid = 0, idDB = 0;
            string father = "ListError";
            string feature = "ErrorTitle";
     
            //verifica sulla presenza di tutti i campi dalla classe checker
            //e che sia stato caricato un anno\mese
            if (isLoad == false) return;
            populate.path = pathxml;
            populate.father = father;
            populate.feature = feature;
            Checker check = new Checker(pathxml, father, feature);
            isempty[0] = check.isEmpty(txtCause);
            isempty[1] = check.isEmpty(txtImport);
            isNumeric = check.isnumeric(txtImport);

            //Se valore numerico ko esci dalla funzione
            if (isNumeric == false) return;
            
            //acquisisco il valore di PK da DataGridView se c'è almeno una riga
            if (!(table.Rows.Count == 0))
            {
                int i = table.Rows.Count - 1;
                DataRow lastrow = table.NewRow();
                lastrow.ItemArray = table.Rows[i].ItemArray;
                idgrid = Int16.Parse(lastrow[0].ToString());
            }
            
            //acquidisco il valore di primary key da DB, in base al mese selezionato
            idDB = model.primaryKey($"{manage_mese}", $"id_{manage_mese}");
            
            //Se la chiave è maggiore quella della griglia incrementala di 1
            //valori inseriti e non ancora salvati
            if (idgrid >= idDB) id = idgrid + 1;
            //altrimenti incrementa di 1 la chiave prelevata da DB
            else id = idDB + 1; 
             

            //inserisce nella lista i valori inseriti da textbox
            if (!(isempty[0] == true || isempty[1] == true))
            {
                list.Add(id.ToString());
                list.Add(txtCause.Text);
                list.Add(txtImport.Text.Replace('.',','));
            }
            else return;
            //popola la griglia attraverso la lista
            populate.inserisci(3, list);
            
            txtCause.Clear();
            txtImport.Clear();
            txtCause.Focus();
            counter();
            totKeepMoney();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMonthSpends.Rows.IndexOf(grdMonthSpends.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthSpends,table);
            populate.mouveUp();
            grdMonthSpends.CurrentRow.Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMonthSpends.Rows.IndexOf(grdMonthSpends.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthSpends, table);
            populate.mouveDown();
            grdMonthSpends.CurrentRow.Selected = true;
        }

        
        private void btnLoadYear_Click(object sender, EventArgs e)
        {
            PopulateGrid populate = new PopulateGrid(grdMonthSpends, table);
            List<ModelDataSY.PaymentSY> listdata = new List<ModelDataSY.PaymentSY>();
            List<string> listinsert = new List<string>();
            string selezione, anno, mese;
            int year, month, i;
            double pay = 0, money = 0, payAdd = 0;
            bool lastyear = false;

            table.Rows.Clear();
            txtTotSpends.ResetText();

            if(isChanged == true && isSaved == false)
            {
                if (MessageBox.Show("Sicuro di voler caricareun nuovo mese i dati non sono salvati ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
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
                    listdata = model.loadDataSY(mese, year);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_tupla_mese.ToString());
                        listinsert.Add(listdata[i].voce_spesa);
                        listinsert.Add(listdata[i].importo.ToString());
                        populate.inserisci(3, listinsert);
                        listinsert.Clear();
                        i++;
                    }
                    txtYearMonth.Text = mese + " " + anno;
                }
            }

            isChanged = false;
            isLoad = true;
            //deseleziona l'albero e conteggia il totale spese
            treeYears.SelectedNode = null;
            counter();

            //Carico lo stipendio le entrate extra e i contanti da DB
            pay = model.loadPay(year_manage, month_manage);
            txtPay.Text = pay.ToString();
            payAdd = model.loadPayAdd(year_manage, month_manage);
            txtPlusEntry.Text = payAdd.ToString();
            money = model.loadMoney(year_manage, month_manage);
            txtMoney.Text = money.ToString();
            //modifico i soldi risparmiati solo dopo aver caricato lo stipendio
            totKeepMoney();
            //carico il totale entrate annuali e totale spese annuali
            model.loadTotRichSpendYear(year_manage, txtTotSpendyear, txtTotRestyear);
            //carico il saldo conto corrente
            ModelDataCC modelCC = new ModelDataCC();
            txtSaldoCC.Text = modelCC.loadBalanceCC(year_manage, month_manage).ToString();

            //carico il saldo Libretto e PostPay
            //sfrutto l'ereditarietà della classe ModelDataPP
            ModelDataPP modLibPP = new ModelDataPP();
            txtSaldoLibretto.Text = modLibPP.loadBalanceLib(year_manage).ToString();
            txtSaldoPP.Text = modLibPP.loadBalanceLib(year_manage, true).ToString();

            //tronca le textbox saldo cc,pp,lib
            Checker check = new Checker();
            if (txtSaldoPP.Text.Length > 1)
            {
                check.truncate(txtSaldoPP, 2);
            }
            if (txtSaldoCC.Text.Length > 1)
            {
                check.truncate(txtSaldoCC, 2);
            }
            if (txtSaldoLibretto.Text.Length > 1)
            {
                check.truncate(txtSaldoLibretto, 2);
            }

            //Se non caricato l'ultimo anno il Datagridview è disabilitato
            //Disabilito inserimento, modifiche, calcellazione e salvataggio
            lastyear = checkLastYear(year_manage);
            if (!lastyear)
            {
                grdMonthSpends.ReadOnly = true;
                btnInsert.Enabled = false;
                btnSave.Enabled = false;
                btnSaveData.Enabled = false;
                btnSaveThree.Enabled = false;
                btnModifyRow.Enabled = false;
                btnDeleteRow.Enabled = false;
                txtPay.ReadOnly = true;
                txtPlusEntry.ReadOnly = true;
                txtMoney.ReadOnly = true;
            }
            else
            {
                grdMonthSpends.ReadOnly = false;
                btnInsert.Enabled = true;
                btnSave.Enabled = true;
                btnSaveData.Enabled = true;
                btnSaveThree.Enabled = true;
                btnModifyRow.Enabled = true;
                btnDeleteRow.Enabled = true;
                txtPay.ReadOnly = false;
                txtPlusEntry.ReadOnly = false;
                txtMoney.ReadOnly = false;
            }

        }
        private void btnLoadYears_Click(object sender, EventArgs e)
        {
            btnLoadYear_Click(sender, e);
        }

        /// <summary>
        /// elimina una riga e aggiorna il conteggio totale spese
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdMonthSpends.Rows.IndexOf(grdMonthSpends.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdMonthSpends, table);

            if (MessageBox.Show("Sicuro di voler eliminare la riga ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                populate.deleterow();
            }
            counter();
            totKeepMoney();
        }

        /// <summary>
        /// Metodo per generare un nuovo anno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewYear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Stai per creare un nuovo anno, proseguire ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                model.insertYear(treeYears);
            }
        }

        private void btnNewYears_Click(object sender, EventArgs e)
        {
            btnNewYear_Click(sender, e);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isLoad == false || isSaved == true) return;
            if (isChanged == false) return;
            
            //salva lo stipendio e le entrate extra
            double pay = Double.Parse(txtPay.Text);
            double payadd = Double.Parse(txtPlusEntry.Text);
            model.savePay(pay, payadd, year_manage, month_manage);
            //salva i contanti
            double money = Double.Parse(txtMoney.Text);
            model.saveMoney(money, year_manage, month_manage);
            //salva il totale spese mese
            double total = Double.Parse(txtTotSpends.Text);
            model.updateTotSpend(year_manage, month_manage, total);
           
            //genera la lista dalla tabella e salva i dati nel DB attraverso la classe modeldata
            List<ModelDataSY.PaymentSY> lista = createListStruct();
            isSaved = model.saveDataSY(manage_mese.ToLower(), year_manage, lista);

            //aggiorna le spese annuali, la posizione è obbligata della riga
            //perche il DBMS deve prima fare l'update corretto delle spese mensili, altrimenti 
            //non si aggiorna
            model.updateTotYears(year_manage);
            //carica il totale spese annuali da DB
            model.loadTotRichSpendYear(year_manage, txtTotSpendyear, txtTotRestyear);
            statusPanel();
        }
        private void btnSaveData_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }
        private void btnSaveThree_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        /// <summary>
        /// Istanza alla form di modifica di una riga, non c'è aggiornamento fresh
        /// è necessario ricaricare i dati
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyRow_Click(object sender, EventArgs e)
        {
            //istanza per form modifica e per aggiornare il datagridview
            frmModify frmMod = new frmModify();
            PopulateGrid populate = new PopulateGrid(grdMonthSpends, table);
            string id, cause, import;
            List<ModelDataSY.PaymentSY> listdata = new List<ModelDataSY.PaymentSY>();
            List<string> listinsert = new List<string>();
            int i;
            string mese;
            //variabile di avvenuta modifica
            bool modifyRow = false;

            try
            {
                //prelevo i dati dal datagridview
                var val = grdMonthSpends.CurrentRow.Cells;
                id = val[0].Value.ToString();
                cause = val[1].Value.ToString();
                import = val[2].Value.ToString();
                //passo i dati ai setter di frmModify
                frmMod.setId = id;
                frmMod.setCause = cause;
                frmMod.setImport = import;
                //setto l'anno e il mese selezionato
                frmMod.setYear = year_manage;
                frmMod.setId_month = month_manage;
                //visualizzo il form
                frmMod.ShowDialog();
                //ricevo tru dal getter se alvataggio avvenuto con successo
                modifyRow = frmMod.verify;
                if (modifyRow == true)
                {//aggiorno il datagridview
                    isSaved = true;
                    table.Rows.Clear();
                    //prelevo il valore del mese dal getter di frmModify
                    mese = frmMod.setMonth;
                    //carica i dati da DB e li assegna alla lista
                    listdata = model.loadDataSY(mese, year_manage);

                    //utilizza una lista di appoggio per poter popolare ogni riga del DatagridView
                    i = 0;
                    while (i < listdata.Count)
                    {
                        listinsert.Add(listdata[i].id_tupla_mese.ToString());
                        listinsert.Add(listdata[i].voce_spesa);
                        listinsert.Add(listdata[i].importo.ToString());
                        populate.inserisci(3, listinsert);
                        listinsert.Clear();
                        i++;
                    }
                }
                statusPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nessuna riga selezionata per la modifica, selezionare una riga", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //Visualizza form impostazioni
        private void btnSetting_Click(object sender, EventArgs e)
        {
            try
            {
                //istanzio la classe
                frmSetting frmsetting = new frmSetting();

                //mostro la finestra impostazioni
                frmsetting.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Visualizza il form per le voci frequenti
        private void btnSetOftenValue_Click(object sender, EventArgs e)
        {
            //istanzia la classe
            CreateFormOftenCause form = new CreateFormOftenCause();
            //imposta nel setter la textbox che deve acquisire il valoe dalla 
            //lista delle causali frequenti
            form.oftenCause = txtCause;
        }
        
        //Avvia modulo Conto Corrente
        private void btnContoCorrente_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/contocorrente", "ContoCorrente");
        }
        
        //Avvia modulo Libretto
        private void btnLibretto_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/libretto", "Libretto");
        }

        //Avvia modulo PostPay
        private void btnPostPay_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/postpay", "PostPay");
        }

        //Avvia modulo Mantenimento
        private void btnMantenimento_Click(object sender, EventArgs e)
        {
            ProcessRunning processRunning = new ProcessRunning();
            processRunning.XMlpathConteinerFile = runPath;
            processRunning.runProcess("/runpath/mantenimento", "Mantenimento");
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
            svdPDF.FileName = year_manage.ToString()+"_"+month_manage.ToString()+"_"+"DataSY.pdf";
            //Se premuto ok nel SaveDialog
            if (svdPDF.ShowDialog() == DialogResult.OK)
            {
                //istanza alla classe
                DataGridViewToPDF dataPDF = new DataGridViewToPDF(grdMonthSpends);
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

#region gridview

        /// <summary>
        /// gestisce la modifica diretta della griglia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdMonthSpends_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            isChanged = true;
            isSaved = false;
            statusPanel();
            counter();
            totKeepMoney();
        }

        private void grdMonthSpends_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //modifica il . in una , per il corretto cast double
            if(grdMonthSpends.CurrentCell.ColumnIndex == 2)
            {
                var val = grdMonthSpends.CurrentCell.Value;
                string valore = val.ToString().Replace('.', ',');
                grdMonthSpends.CurrentCell.Value = valore;
            }
            
        }
        
        //intercetta il click del mouse nel DataGridView
        private void grdMonthSpends_MouseClick(object sender, MouseEventArgs e)
        {
            //se viene premuto il tasto SX, esci dalla funzione
            if (e.Button == MouseButtons.Left) return;
            //istanza alla classe di creazione del ContextMenu
            CreateContexMenu creatMenu = new CreateContexMenu(grdMonthSpends);
            //setting degli eventi da richiamare con i pulsanti
            creatMenu.setEvents("delete", btnDeleteRow_Click);
            creatMenu.setEvents("modifyIt", btnModifyRow_Click);
            creatMenu.setEvents("moveUp", btnUp_Click);
            creatMenu.setEvents("moveDown", btnDown_Click);
            //mostra il menu
            creatMenu.showContextMenu(e);
        }

        #endregion

#region textbox
        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
            isSaved = false;
            statusPanel();
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
            isSaved = false;
            statusPanel();
        }

        /// <summary>
        /// esegue il conteggio di contabilità
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContability_Click(object sender, EventArgs e)
        {
            string father = "ListError";
            string feature = "ErrorTitle";
            if (year_manage == 0 || month_manage == 0)
            {
                ReadErrorXml erxml = new ReadErrorXml();
                erxml.manageError(12, pathxml, father, feature);
                return;
            }
            //istanza alla classe contabilità, da cui c'è la query su DB
            Contabilita contabilita = new Contabilita(year_manage, month_manage);
            double risparmiati = Double.Parse(txtMoneyKeep.Text);
            double totCC = Double.Parse(txtSaldoCC.Text);
            double totLib = Double.Parse(txtSaldoLibretto.Text);
            double totPP = Double.Parse(txtSaldoPP.Text);
            double contanti = Double.Parse(txtMoney.Text);

            txtContability.Text = contabilita.conteggio(risparmiati,contanti,totCC,totLib,totPP,txtContability);

        }     

        private void txtPlusEntry_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
            isSaved = false;
            statusPanel();
        }

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se viene premuto il punto metto la virgola.
            //il carattere viene poi modificato dalla funzione di 
            //salvataggio della classe model
            if (e.KeyChar == '.') e.KeyChar = ',';
        }

        private void txtPlusEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se viene premuto il punto metto la virgola.
            //il carattere viene poi modificato dalla funzione di 
            //salvataggio della classe model
            if (e.KeyChar == '.') e.KeyChar = ',';
        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            //se viene premuto il punto metto la virgola.
            //il carattere viene poi modificato dalla funzione di 
            //salvataggio della classe model
            if (e.KeyChar == '.') e.KeyChar = ',';
        }

        /// <summary>
        /// ricarca voci nel DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchVoice_TextChanged(object sender, EventArgs e)
        {
            Searching searching = new Searching(grdMonthSpends, table, txtSearchVoice);
            searching.searchingRow(1);
        }
#endregion
        #endregion

    }
}
