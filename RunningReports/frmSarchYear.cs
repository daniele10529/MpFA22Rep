using System;
using System.Data;
using System.Windows.Forms;
using GenericModelData;

namespace RunningReports
{
    public partial class frmSarchYear : Form
    {
        //Definizione attributi globali

        //Tabella dati
        DataTable table;
        //percorso file xml con errori
        private const string pathxml = Routes.XMLERRORS;
        //Istanza ModelData RunReports
        ModelDataReports modelReports;

        /// <summary>
        /// Costruttore
        /// </summary>
        public frmSarchYear()
        {
            InitializeComponent();
            table = new DataTable();
            modelReports = new ModelDataReports();
        }

        /// <summary>
        /// Assegna all'attributo statico della struttura ADT il valore della riga selezionata
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Args</param>
        private void btnSelectYear_Click(object sender, EventArgs e)
        {
            //Preleva l'anno selezionato e lo assegna all'ADT 
            var selectCell = grdYear.CurrentRow.Cells;
            ModelDataReports.RunReports.year = (int)selectCell[0].Value;
            Dispose();
        }

        /// <summary>
        /// Carica i valori nella griglia al caricamento del form
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Args</param>
        private void frmSarchYear_Load(object sender, EventArgs e)
        {
            //Associazione dati, serve a definire la dimensione della colonna
            grdYear.DataSource = table;
            //Set della tabella, ricva il nome della colonna dalla struttura dati
            table.Columns.Add(ModelDataReports.RunReports.columnYear);
            //Set griglia
            grdYear.Columns[0].Width = (grdYear.Width * 98) / 100;
            grdYear.Columns[0].ReadOnly = true;
            
            //Aggiunge i dati in tabella
            grdYear.DataSource = modelReports.loadYar();

        }

       
    }
}
