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

namespace Mantenimento
{
    public partial class frmMantenimento : Form
    {
        //Tabella contenente i dati
        private DataTable table;
        //Percorso file xml con errori
        private const string pathxml = Routes.XMLERRORS;
        //Verifica sul comportamento utente
        private bool isLoad;
        private bool isSaved;
        private bool isChanged;
        //Istanza alla classe di gestione con DB
        ModelDataMan model;
        //Numero dell'anno e mese caricato
        public int year_manage, month_manage;

        public frmMantenimento()
        {
            InitializeComponent();
            table = new DataTable();
            isLoad = false;
            isSaved = false;
            isChanged = false;
            model = new ModelDataMan();
        }

        #region Metodi Privati

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
            tip.SetToolTip(btnNewYears, "Genera un nuovo anno");
            tip.SetToolTip(btnNewYear2, "Genera un nuovo anno");
            tip.SetToolTip(btnExit, "Chiudi Spese Annuali");
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
                //Si può assegnare l'icona alle pagine solo tramite una lista di immagini
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
        /// Esegue il conteggio del saldo annuale e lo salva
        /// </summary>
        private void counter(bool save = true)
        {
            int i;
            double total = 0;
            DataRow row;

            for (i = 0; i < table.Rows.Count; i++)
            {
                row = table.NewRow();
                row.ItemArray = table.Rows[i].ItemArray;
                total += Double.Parse(row[2].ToString());
            }
            //textbox saldo annuale
            txtBalance.Text = total.ToString();

            //Salva il saldo annuale, opzionale al carico dei dati non salva
            if (save)
            {
                //Salva il saldo annuale
                double balance = Double.Parse(txtBalance.Text);
                if (model.saveBalanceYear(balance, year_manage, "totale_annuo_mantenimento") == false)
                {
                    MessageBox.Show("Non è stato salvato il saldo annuale!!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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

        private void frmMantenimento_Load(object sender, EventArgs e)
        {
            //Mesi per combobox
            string[] mesi = { "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre" };

            Clipboard.Clear();
            toolTip();
            loadImage();
            //Carico l'albero, polimorfismo del metodo di ModelDataSY con nome tabella
            model.loadTree(treeYears, "anni_mantenimento");
            pnlStatus.BackColor = Color.FromArgb(255, 255, 255);

            //Impostazioni di tabella e datagridview
            grdKeepingVoices.DataSource = table;
            table.Columns.Add("ID");
            table.Columns.Add("CAUSALE DEL MOVIMENTO");
            table.Columns.Add("IMPORTO");
            table.Columns.Add("MESE");
            grdKeepingVoices.Columns[0].Width = (grdKeepingVoices.Width * 5) / 100;
            grdKeepingVoices.Columns[1].Width = (grdKeepingVoices.Width * 70) / 100;
            grdKeepingVoices.Columns[2].Width = (grdKeepingVoices.Width * 15) / 100;
            grdKeepingVoices.Columns[3].Width = (grdKeepingVoices.Width * 10) / 100;
            grdKeepingVoices.Columns[0].ReadOnly = true;

            //Set valori comboBox mesi
            cmbMonths.Items.AddRange(mesi);
            //Set textbox YearMonth
            txtYearMonth.Text = "Gestione Mantenimento.....";
            //Set valore txtYearInsert
            txtYearInsert.Texts = "0";
        }

        //Intercetta la chusura del form
        private void frmMantenimento_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Metodo per caricare i dati su DatagridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadYears_Click(object sender, EventArgs e)
        {
      
            string selezione, anno;
            int year;

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

                    //Popola la tabelle
                    model.getAll(year, table);

                    //Visualizza anno caricato
                    txtYearMonth.Text = "Anno caricato : ".ToUpper() + anno.ToUpper();
                }
            }

            isChanged = false;
            isLoad = true;
            //deseleziona l'albero 
            treeYears.SelectedNode = null;
            //Carica il valore di saldo del mese
            txtBalance.Text = model.loadBalanceYear(year_manage).ToString();
            //Conteggia il saldo finale senza salvare
            counter(false);
            //Tronca il bilancio iniziale
            if (txtBalance.Text.Length > 1)
            {
                Checker check = new Checker();
                check.truncate(txtBalance, 2);
            }

            
        }

        /// <summary>
        /// Inserisce un nuovo anno nel DB relativo a mantenimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewYear_Click(object sender, EventArgs e)
        {

            Checker check = new Checker(pathxml);
            int year = 0;
            
            //Chiede conferma di inserimento
            if(MessageBox.Show("Stai per inserire un nuovo anno, sei sicuro ?","Attenzione",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Verifica il dato inserito
                try
                {

                    if (check.isNumeric(txtYearInsert.Texts))
                    {
                        if(txtYearInsert.Texts.Length == 4 || txtYearInsert.Texts.Equals("0"))
                        {
                            //Inserisce il nuovo valore, se year=0 e ci sono già anni incrementa di 1,
                            //se primo anno parte da 2018
                            year = Int32.Parse(txtYearInsert.Texts);
                            model.insertYear(treeYears, year);
                        }
                        else
                        {
                            MessageBox.Show("Il valore dell'anno non è corretto, ammesso 0 oppure anno in formato yyyy", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                }catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
        }

        /// <summary>
        /// Inserisce un record nel DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();

            ModelDataMan.Payment record = new ModelDataMan.Payment();
            Checker check = new Checker(pathxml);
            int idgrid = 0, idDB = 0;

            //Verifica sulla presenza di tutti i campi dalla classe checker
            //e che sia stato caricato un anno\mese
            if (isLoad == false) return;

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
                        idDB = model.primaryKey("versamenti_mantenimento", "id_mantenimento");

                        //Se la chiave è maggiore quella della griglia incrementala di 1
                        //valori inseriti e non ancora salvati
                        if (idgrid >= idDB) record.id_mantenimento = idgrid + 1;
                        //altrimenti incrementa di 1 la chiave prelevata da DB
                        else record.id_mantenimento = idDB + 1;

                        //Setta il record da inserire
                        record.causale = txtCause.Texts;
                        record.importo = Double.Parse(txtImport.Texts.Replace('.', ','));
                        record.mese = cmbMonths.SelectedItem.ToString();
                        
                        //Verifica il corretto inserimento del record
                        //Popola la griglia e salva il saldo annuale
                        if (model.insert(year_manage, record))
                        {
                            //Popola la griglia
                            model.populate(record, table);
                            //Calcola il saldo annuale e lo salva
                            counter();
                            //Aggiorna lo stato d'ambiente
                            isChanged = false;
                            isSaved = true;
                            statusPanel();
                        }

                        //Resetta i valori
                        txtCause.Texts = "";
                        txtImport.Texts = "";
                        cmbMonths.SelectedItem = null;
                        cmbMonths.Focus();            

                    }

                }

            }
            catch (FormatException ex)//Eccezione generata dai metodi della classe check
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Modifica il record selezionato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyRow_Click(object sender, EventArgs e)
        {

            //Istanza per form modifica 
            frmModify frmMod = new frmModify();
            string id, cause, import, month;
            
            //variabile di avvenuta modifica
            bool modifyRow = false;
            try
            {
                //prelevo i dati dal datagridview
                var val = grdKeepingVoices.CurrentRow.Cells;
                id = val[0].Value.ToString();
                cause = val[1].Value.ToString();
                import = val[2].Value.ToString();
                month = val[3].Value.ToString();
                //passo i dati ai setter di frmModify
                frmMod.setId = id;
                frmMod.setCause = cause;
                frmMod.setImport = import;
                frmMod.setMonth = month;
                //setto l'anno selezionato
                frmMod.setYear = year_manage;
                //visualizzo il form
                frmMod.ShowDialog();
                //ricevo tru dal getter se alvataggio avvenuto con successo
                modifyRow = frmMod.verify;
                if (modifyRow == true)
                {
                    //Aggiorna lo stato d'ambiente
                    isSaved = true;
                    isChanged = false;
                    statusPanel();

                    //Popola la tabella
                    table.Rows.Clear();
                    model.getAll(year_manage, table);

                    //Calcola il saldo annuale e lo salva
                    counter();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nessuna riga selezionata per la modifica, selezionare una riga" + ex.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Elimina la riga selezionata
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            isSaved = false;
            isChanged = true;
            statusPanel();

            //Istanza all'oggetto record
            ModelDataMan.Payment record = new ModelDataMan.Payment();

            //Preleva l'indice dalla riga selezionata, se non selezionata non fa nulla
            int index = grdKeepingVoices.Rows.IndexOf(grdKeepingVoices.CurrentRow);
            if (index < 0) return;

            //Preleva i dati dalla riga selezionata del DataGridview
            var val = grdKeepingVoices.CurrentRow.Cells;
            record.id_mantenimento = Int32.Parse(val[0].Value.ToString());

            //se confermato elimina la riga
            if (MessageBox.Show("Sicuro di voler eliminare la riga ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(model.deleteRow(year_manage, record))
                {
                    //Aggiorna lo stato d'ambiente
                    isSaved = true;
                    isChanged = false;
                    statusPanel();
                    //Aggiorna la tabella
                    table.Rows.Clear();
                    //Popola la tabella
                    model.getAll(year_manage, table);
                    //Calcola il saldo annuale e lo salva
                    counter();
                }
            }
            
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdKeepingVoices.Rows.IndexOf(grdKeepingVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdKeepingVoices, table);
            populate.mouveUp();
            grdKeepingVoices.CurrentRow.Selected = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //preleva l'indice della riga selezionata, se non selezionata esce
            int index = grdKeepingVoices.Rows.IndexOf(grdKeepingVoices.CurrentRow);
            if (index < 0) return;

            PopulateGrid populate = new PopulateGrid(grdKeepingVoices, table);
            populate.mouveDown();
            grdKeepingVoices.CurrentRow.Selected = true;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region DataGridView

        private void grdKeepingVoices_MouseClick(object sender, MouseEventArgs e)
        {
            //se viene premuto il tasto SX, esci dalla funzione
            if (e.Button == MouseButtons.Left) return;
            //istanza alla classe di creazione del ContextMenu
            CreateContexMenu creatMenu = new CreateContexMenu(grdKeepingVoices);
            //setting degli eventi da richiamare con i pulsanti
            creatMenu.setEvents("delete", btnDeleteRow_Click);
            creatMenu.setEvents("modifyIt", btnModifyRow_Click);
            // creatMenu.setEvents("oftenVal", btnOftenVal_Click);
            creatMenu.setEvents("moveUp", btnUp_Click);
            creatMenu.setEvents("moveDown", btnDown_Click);
            //mostra il menu
            creatMenu.showContextMenu(e);
        }

        private void grdKeepingVoices_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Modifica permessa solo attraverso la funzione modifica", "Attenzione!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        #region Textbox

        private void txtSearchVoice_TextChanged(object sender, EventArgs e)
        {
            //cerco all'interno del datagridview passando la colonna in cui cercare
            Searching search = new Searching(grdKeepingVoices, table, txtSearchVoice);
            search.searchingRow(1);
        }

        //Setta i colori delle TextBox all'inserimento 
        private void txtYearInsert_Enter(object sender, EventArgs e)
        {
            txtYearInsert.BorderColor = Color.FromArgb(161, 223, 239);
            txtYearInsert.BackColor = Color.FromArgb(210, 228, 242);
        }

        private void txtYearInsert_Leave(object sender, EventArgs e)
        {
            txtYearInsert.BorderColor = Color.DimGray;
            txtYearInsert.BackColor = Color.White;
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

        #region ComboBox
        //Setta i colori di inserimento
        private void cmbMonths_Enter(object sender, EventArgs e)
        {
            cmbMonths.BackColor = Color.FromArgb(210, 228, 242);
        }


        private void cmbMonths_Leave(object sender, EventArgs e)
        {
            cmbMonths.BackColor = Color.White;
        }

        private void cmbMonths_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Affinché possa ridisegnare è necessario impostare l'attributo
            //DrawMode su OwnerDrawFixed

            //Antialias sul disegno del testo
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //Eredita dal controllo combobox
            ComboBox cb = (ComboBox)sender;

            //Disegna l'item selezionato
            if ((e.State & DrawItemState.Selected) != 0)
            {
                //Ricava il rettangolo dell'Item selezionato
                Rectangle rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                //Disegna il rettangolo di selezione con il colore personalizzato
                e.Graphics.FillRectangle(Brushes.LightSteelBlue, rec);

                //Disegna il testo dell'Item
                e.Graphics.DrawString(cb.Items[e.Index].ToString(), cb.Font, Brushes.Black, Rectangle.Inflate(e.Bounds, -5, 0));
            
            }
            else
            {
                ///Ricava il rettangolo dell'Item selezionato
                Rectangle rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                //Disegna il rettangolo di selezione con il colore personalizzato
                e.Graphics.FillRectangle(Brushes.White, rec);

                //Disegna il testo dell'Item
                e.Graphics.DrawString(cb.Items[e.Index].ToString(), cb.Font, Brushes.Black, Rectangle.Inflate(e.Bounds, -5, 0));

            }
        }

        #endregion

        #region Treeview

        private void treeYears_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //Affinché possa ridisegnare è necessario impostare l'attributo
            //DrawMode su OwnerDrawText

            //Antialias sul disegno del testo
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //Se TreeView perde il focus disegna i nodi in modo standard
            if (treeYears.Focused == false)
            {
                e.DrawDefault = true;
                return;
            }

            //Disegna il colore di sfondo del nodo selezionato
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //Ricava il rettangolo con la larghezza del TreeView e punto di partenza in X
                //Altezza e punto di partenza in y del nodo selezionato
                Rectangle rec = new Rectangle(treeYears.Bounds.X, e.Node.Bounds.Y, treeYears.Width, e.Node.Bounds.Height);
                //Disegna il rettangolo di selezione con il colore personalizzato
                e.Graphics.FillRectangle(Brushes.LightSteelBlue, rec);

                //Preleva il font del nodo, se non selezionato utilizza quello del TreeView
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                //Disegna il testo del nodo
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, Rectangle.Inflate(e.Bounds, 2, 0));
                //Disegna l'immagine al nodo selezionato
                Image i = Image.FromFile(Routes.ICONS + "Ordina_dx.png");
                e.Graphics.DrawImage(i, e.Node.Bounds.X - 30, e.Node.Bounds.Y, 20, 20);

            }
            else
            {
                //Se il nodo non è selezionato lo disegna in modo standard
                e.DrawDefault = true;
            }


        }

       

        //Carica i dati al doppio click sul nodo prescelto
        private void treeYears_DoubleClick(object sender, EventArgs e)
        {
            btnLoadYears_Click(sender, e);
        }


        #endregion

        #endregion
    }
}
