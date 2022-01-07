using System;
using System.Windows.Forms;
using GenericModelData;
using Checking;


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

        private void frmModify_Load(object sender, EventArgs e)
        {
            //assegna i valori dai getter alle textbox
            txtId.Text = setId;
            txtDay.Text = setDay;
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
            string cause,import;
            string month = selmonth(setId_month);
            int id = 0,day = 0;
            bool[] verifyValues = new bool[5];

            //istanze alle classi model e checker
            ModelDataCC model = new ModelDataCC();
            Checker check = new Checker(pathxml, father, feature);

            //essegna al setter il valore recepito dalla funzione, necessario come getter per
            //frmContoCorrente per l'aggiornamento del datagridview
            setMonth = month;
            //setta i parametri per l'inserimento
            id = Int32.Parse(txtId.Text);
            day = Int32.Parse(txtDay.Text);
            cause = txtCause.Text;
            import = txtImport.Text.Replace(",",".");

            //verifico la correttezza dei dati e che non siano vuoti
            verifyValues[0] = check.isnumeric(txtImport);
            verifyValues[1] = check.inRange(txtDay, 1, 31);
            verifyValues[2] = check.isEmpty(txtCause);
            verifyValues[3] = check.isEmpty(txtImport);
            verifyValues[4] = check.isEmpty(txtDay);
            if (verifyValues[0] == false || verifyValues[1] == false || verifyValues[2] == true || verifyValues[3] == true || verifyValues[4] == true) return;

            //modifica il DB e riceve true se tutto ok
            verify = model.modifyRow(id, day, cause, import, setYear, month);    

            if (verify == true)
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
    }
}
