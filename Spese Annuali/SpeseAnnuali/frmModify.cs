using System;
using System.Drawing;
using System.Windows.Forms;
using GenericModelData;
using Checking;


namespace SpeseAnnuali
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
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setId_month { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }
#endregion

        //selezione il mese in formato stringa dal numero del mese
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

        private void frmModify_Load(object sender, EventArgs e)
        {
            //assegna i valori dai getter alle textbox
            txtId.Text = setId;
            txtCause.Text = setCause;
            txtImport.Text = setImport;
            //assegna alle variabili pubbliche di frmContocorrente i valori passati ai setter.
            //Passaggio necessario per l'aggiornamento del datagridview
            //dato che le variabili si scaricano all'istanza del form, e tornando indietro non c'è 
            //selezione dell'albero
            fr.year_manage = setYear;
            fr.month_manage = setId_month;
        }


        private void btnModify_Click(object sender, EventArgs e)
        {
            string father = "ListError";
            string feature = "ErrorTitle";
            string pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
            string month = selmonth(setId_month);
            string cause, import;
            int id = 0;
            bool[] verifyValue = new bool[3];

            //istanza alle classi model e checker
            ModelDataSY model = new ModelDataSY();
            Checker check = new Checker(pathxml, father, feature);

            //essegna al setter il valore recepito dalla funzione, necessario come getter per
            //frmContoCorrente per l'aggiornamento del datagridview
            setMonth = month;
            //setta i parametri per l'inserimento
            id = Int32.Parse(txtId.Text);
            cause = txtCause.Text;
            import = txtImport.Text.Replace(",", ".");

            //verifico i dati modificati, necessario il controllo solo sull'importo
            //o su campi vuoti
            verifyValue[0] = check.isnumeric(txtImport);
            verifyValue[1] = check.isEmpty(txtCause);
            verifyValue[2] = check.isEmpty(txtImport);
            if (verifyValue[0] == false || verifyValue[1] == true || verifyValue[2] == true) return;

            //modifica il DB e riceve true se tutto ok
            verify = model.modifyRow(id, cause, import, setYear, month);

            if(verify == true)
            {
                MessageBox.Show("Inserimento avvenuto con successo");
            }
            //scarica appena fatto.
            Dispose();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();   
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {   
            //costruisce la textbox e la visualizza
            txtAdd.Name = "txtAdd";
            txtAdd.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            txtAdd.Size = new Size(50, 50);
            txtAdd.Location = new Point((btnPlus.Location.X) + 10,(btnPlus.Location.Y) + 30);
            txtAdd.Visible = true;
            txtAdd.KeyPress += new KeyPressEventHandler(txtAdd_KeyPress);
            //viene aggiunto il controllo e si visualizza
            Controls.Add(txtAdd);
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
            tip.Show("Inserire la cifra e premere il tasto + per fare la somma", txtAdd, new Point(1,-50));
        }

        private void txtAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sostituisce il punto con la virgola per il corretto calcolo
            if (e.KeyChar == '.') e.KeyChar = ',';
            
            //se viene premuto +, keychar = 43 codice ascii tasto +
            if (e.KeyChar == 43)
            {
                //se la casella è vuota esci
                if (txtAdd.Text.Length == 0) return;

                string father = "ListError";
                string feature = "ErrorTitle";
                string pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";

                //istanza alla classe checker per il controllo di valore numerico
                Checker check = new Checker(pathxml, father, feature);
                bool check_number = check.isnumeric(txtAdd);
                //se il controllo è true
                if (check_number)
                {//acquisisci i valori e fai la somma
                    double val = Double.Parse(txtImport.Text);
                    double plus = Double.Parse(txtAdd.Text);
                    txtImport.Text = (val + plus).ToString();
                    //resetta il testo
                    txtAdd.ResetText();
                    //rendi invisibile la textbox e elimina il controllo per le visualizzazioni future
                    txtAdd.Visible = false;
                    Controls.Remove(txtAdd);
                    tip.RemoveAll();
                }
            }
            
        }

    }
}
