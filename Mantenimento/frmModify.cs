using System;
using System.Windows.Forms;
using GenericModelData;
using Checking;

namespace Mantenimento
{
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
        }

        //istanza alla classe Mentenimento
        private frmMantenimento fr = new frmMantenimento();

#region getter and setter
        public string setId { get; set; }
        public string setCause { get; set; }
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }
#endregion

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
            string cause, import, month;
            string[] months = { "gennaio", "febbraio", "marzo", "aprile", "maggio", "giugno", "luglio", "agosto", "settembre", "ottobre", "novembre", "dicembre" };
            bool[] verifyValues = new bool[5];
            int id = 0;

            //istanze alle classi model e checker
            ModelDataMan model = new ModelDataMan();
            Checker check = new Checker(pathxml, father, feature);

            //setta i parametri per l'inserimento
            id = Int32.Parse(txtId.Text);
            cause = txtCause.Text;
            import = txtImport.Text.Replace(",", ".");
            month = txtMonth.Text;

            //verifico la correttezza dei valori e che non siano vuoti
            verifyValues[0] = check.isnumeric(txtImport);
            verifyValues[1] = check.inRange(txtMonth, months);
            verifyValues[2] = check.isEmpty(txtCause);
            verifyValues[3] = check.isEmpty(txtImport);
            verifyValues[4] = check.isEmpty(txtMonth);
            if (verifyValues[0] == false || verifyValues[1] == false || verifyValues[2] == true || verifyValues[3] == true || verifyValues[4] == true) return;

            verify = model.modifyRow(id, setYear, cause, import, month, "versamenti_mantenimento");

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
