using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenericModelData;

namespace RunReports.RunReports
{
    public partial class frmSarchYear : Form
    {
        //Definizione attributi globali

        //Tabella dati
        DataTable table;
        //percorso file xml con errori
        private const string pathxml = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
        //Istanza ModelData RunReports
        ModelDataReports modelReports;

        public frmSarchYear()
        {
            InitializeComponent();
            table = new DataTable();
            modelReports = new ModelDataReports();
        }

        private void btnSelectYear_Click(object sender, EventArgs e)
        {
            //Preleva l'anno selezionato
            var selectCell = grdYear.CurrentRow.Cells;
            ModelDataReports.RunReports.year = (int)selectCell[0].Value;
            Dispose();
        }

        private void frmSarchYear_Load(object sender, EventArgs e)
        {
            //Associazione dati, serve a definire la dimensione della colonna
            grdYear.DataSource = table;
            //Set della tabella, ricva il nome della colonna dalla struttura dati
            table.Columns.Add(ModelDataReports.RunReports.columnYear);
            //Set griglia
            grdYear.Columns[0].Width = 230;
            grdYear.Columns[0].ReadOnly = true;
            
            //Aggiunge i dati in tabella
            grdYear.DataSource = modelReports.loadYar();

        }
    }
}
