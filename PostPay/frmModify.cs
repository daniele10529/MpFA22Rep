using Checking;
using GenericModelData;
using System;
using System.Windows.Forms;

namespace PostPay
{
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
        }

        private frmPostPay fr = new frmPostPay();

        #region getter and setter
        public string setId { get; set; }
        public string setCause { get; set; }
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }
        #endregion

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

        private void frmModify_Load(object sender, EventArgs e)
        {
            //assegna i valori dai getter alle textbox
            txtId.Text = setId;
            txtCause.Text = setCause;
            txtImport.Text = setImport;
            txtMonth.Text = setMonth;
            //assegna alle variabili pubbliche di frmContocorrente i valori passati ai setter.
            //Passaggio necessario per l'aggiornamento del datagridview
            //dato che le variabili si scaricano all'istanza del form, e tornando indietro non c'è 
            //selezione dell'albero
            fr.year_manage = setYear;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string father = "ListError";
            string feature = "ErrorTitle";
            string pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
            string cause, import;
            bool[] verifyValues = new bool[5];
            int id = 0, id_month = 0;

            ModelDataPP modelpp = new ModelDataPP();
            Checker check = new Checker(pathxml, father, feature);

            //setta i parametri per l'inserimento
            id = Int32.Parse(txtId.Text);
            id_month = selmonth(txtMonth.Text);
            cause = txtCause.Text;
            import = txtImport.Text.Replace(",", ".");

            //verifico la correttezza dei valori e che non siano vuoti
            verifyValues[0] = check.isnumeric(txtImport);
            verifyValues[1] = check.inRange(id_month, 1, 12);
            verifyValues[2] = check.isEmpty(txtCause);
            verifyValues[3] = check.isEmpty(txtImport);
            verifyValues[4] = check.isEmpty(txtMonth);
            if (verifyValues[0] == false || verifyValues[1] == false || verifyValues[2] == true || verifyValues[3] == true || verifyValues[4] == true) return;

            //modifica il DB e riceve true se tutto ok
            verify = modelpp.modifyRow(id, setYear, cause, import, id_month, true);

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
