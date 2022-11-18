using System;
using System.Drawing;
using System.Windows.Forms;
using GenericModelData;
using Checking;


namespace MpFA20
{
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
        }

        //istanza a SpeseAnnuali
        private frmSpeseAnnuali fr = new frmSpeseAnnuali();
        //Istanza alla textbox per la somma o sottrazione
        TextBox txtAdd = new TextBox();
        //Istanza alla classe tooltip, visualizza istruzioni
        ToolTip tip = new ToolTip();

        #region getter and setter

        public string setId { get; set; }
        public string setCause { get; set; }
        public string setNote { get; set; }
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setId_month { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }

        #endregion

        #region Form

        private void frmModify_Load(object sender, EventArgs e)
        {
            //Assegna i valori dai getter alle textbox
            txtId.Texts = setId;
            txtCause.Texts = setCause;
            txtNote.Texts = setNote;
            txtImport.Texts = setImport;
            //Assegna alle variabili pubbliche del form chiamante i valori passati ai setter.
            //Passaggio necessario per l'aggiornamento del datagridview
            //dato che le variabili si scaricano all'istanza del form, e tornando indietro non c'è 
            //selezione dell'albero
            fr.year_manage = setYear;
            fr.month_manage = setId_month;
        }

        #endregion

        #region Button

        private void btnModify_Click(object sender, EventArgs e)
        {
            //Istanza alla classe DefineMonth
            DefineMonth defineMonth = new DefineMonth();
            string month = defineMonth.getMonthFromIndex(setId_month);
            string cause, note, import;
            int id = 0;

            //Istanza alla classe model
            ModelDataSY model = new ModelDataSY();

            //Assegna al setter il valore recepito dalla funzione, necessario come getter del
            //form chiamante per l'aggiornamento del datagridview
            setMonth = month;

            //Setta i parametri per l'inserimento
            id = Int32.Parse(txtId.Texts);
            cause = txtCause.Texts;
            note = txtNote.Texts;
            import = txtImport.Texts.Replace(",", ".");

            //Verifica i campi obbligatori
            if (cause.Length == 0 || import.Length == 0)
            {
                MessageBox.Show("I campi Causale e Importo sono campi obbligatori !!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Modifica il DB e riceve true se l'inserimento è avvenuto con successo
            verify = model.modifyRow(id, cause, note, import, setYear, month);
            if (verify == true)
            {
                MessageBox.Show("Inserimento avvenuto con successo !!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //scarica il form.
            Dispose();

        }

        //Chiude il form
        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        //Apre la textbox per la somma dell'importo
        private void btnPlus_Click(object sender, EventArgs e)
        {
            //costruisce la textbox e la visualizza
            txtAdd.Name = "txtAdd";
            txtAdd.Font = new Font("Modern No. 20", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            txtAdd.Size = new Size(50, 50);
            txtAdd.Location = new Point((btnPlus.Location.X) + 10, (btnPlus.Location.Y) + 40);
            txtAdd.Visible = true;
            txtAdd.KeyPress += new KeyPressEventHandler(txtAdd_KeyPress);
            //viene aggiunto il controllo al pannello principale e si visualizza
            pnlMain.Controls.Add(txtAdd); 
            //resetta la finestra prima della visualizzazione
            txtAdd.ResetText();
            //ottiene il focus
            txtAdd.Focus();
            //setta il tooltip
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 100;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.IsBalloon = true;
            tip.Show("Inserire la cifra e premere il tasto + per fare la somma", txtAdd, new Point(1, -50));
        }

        #endregion

        #region TextBox

        private void txtAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sostituisce il punto con la virgola per il corretto calcolo
            if (e.KeyChar == '.') e.KeyChar = ',';

            //se viene premuto +, keychar = 43 codice ascii tasto +
            if (e.KeyChar == 43)
            { 
                string pathxml = Routes.XMLERRORS;

                //istanza alla classe checker per il controllo del valore numerico
                Checker check = new Checker(pathxml);
                //Verifica che il valore inserito obbligatorio sia numerico
                try
                {
                    if (!(check.isEmpty(txtAdd.Text)))
                    {
                        if (check.isNumeric(txtAdd.Text))
                        {
                            //acquisisci i valori e fai la somma
                            double val = Double.Parse(txtImport.Texts);
                            double plus = Double.Parse(txtAdd.Text);
                            txtImport.Texts = (val + plus).ToString();
                            //resetta il testo
                            txtAdd.ResetText();
                            //rendi invisibile la textbox e elimina il controllo per le visualizzazioni future
                            txtAdd.Visible = false;
                            pnlMain.Controls.Remove(txtAdd);
                            tip.RemoveAll();
                        }
                    }

                }
                catch(FormatException ex)
                {
                    MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //Setting dei colori sulla casella di testo con il focus
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

        private void txtNote_Enter(object sender, EventArgs e)
        {
            txtNote.BorderColor = Color.FromArgb(161, 223, 239);
            txtNote.BackColor = Color.FromArgb(210, 228, 242);
        }

        private void txtNote_Leave(object sender, EventArgs e)
        {
            txtNote.BorderColor = Color.DimGray;
            txtNote.BackColor = Color.White;
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


    }
}
