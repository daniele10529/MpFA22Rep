using System;
using System.Windows.Forms;
using GenericModelData;
using Checking;
using System.Drawing;

namespace ContoCorrente
{
    public partial class frmModify : Form
    {
        
        public frmModify()
        {
            InitializeComponent();
           
        }
       
        //istanza alla classe ContoCorrente
        private frmContoCorrente fr = new frmContoCorrente();
        //Istanza alla textbox per la somma o sottrazione
        TextBox txtAdd = new TextBox();
        //Istanza alla classe tooltip, visualizza istruzioni
        ToolTip tip = new ToolTip();

        #region getter and setter

        public string setId { get; set; }
        public string setDay { get; set; }
        public string setCause { get; set; }
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setId_month { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }

        #endregion

        #region Metodi Privati

        //assegna il mese in formato stringa dal numero di id_mese passato
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

        #endregion


        #region Form
        private void frmModify_Load(object sender, EventArgs e)
        {
            //assegna i valori dai getter alle textbox
            txtId.Texts = setId;
            txtDay.Texts = setDay;
            txtCause.Texts = setCause;
            txtImport.Texts = setImport;
            //assegna alle variabili pubbliche di frmContocorrente i valori passati ai setter.
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
            string pathxml = Routes.XMLERRORS;
            string cause, import;
            string month = selmonth(setId_month);
            int id = 0, day = 0;
            bool[] verifyValues = new bool[5];

            //istanze alle classi model e checker
            ModelDataCC model = new ModelDataCC();
            Checker check = new Checker(pathxml);

            try
            {

                if(!(check.isEmpty(txtDay.Texts)) && !(check.isEmpty(txtCause.Texts)) && !(check.isEmpty(txtImport.Texts)))
                {
                    if (check.isNumeric(txtDay.Texts) && check.isNumeric(txtImport.Texts) && check.inRange(txtDay.Texts, 1, 31))
                    {
                        //essegna al setter il valore recepito dalla funzione, necessario come getter per
                        //frmContoCorrente per l'aggiornamento del datagridview
                        setMonth = month;
                        //setta i parametri per l'inserimento
                        id = Int32.Parse(txtId.Texts);
                        day = Int32.Parse(txtDay.Texts);
                        cause = txtCause.Texts;
                        import = txtImport.Texts.Replace(",", ".");

                        //modifica il DB e riceve true se tutto ok
                        verify = model.modifyRow(id, day, cause, import, setYear, month);

                        if (verify == true)
                        {
                            MessageBox.Show("Inserimento avvenuto con successo");
                        }
                        //scarica appena fatto.
                        Dispose();
                    }
                }

            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
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
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //Setting dei colori sulla casella di testo con il focus
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

        
    }
}
