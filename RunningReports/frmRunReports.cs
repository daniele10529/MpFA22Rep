using System;
using System.Windows.Forms;
using GenericModelData;
using System.Drawing;

namespace RunningReports
{
    public partial class frmRunReports : Form
    {
        //Istanza model e struttura dati
        private ModelDataReports dataReports;
        private ModelDataReports.RunReports runReports;

        //Attributo privato per il caricamento dei dati
        private bool reportDone = false;

        //Costruttore
        public frmRunReports()
        {
            InitializeComponent();
            //Set dei tooltip sui pulsanti
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(btnListYears, "Apri lista Anni disponibili");
            tip.SetToolTip(btnRunningReport, "Esegui Report annuale");
            tip.SetToolTip(btnExit, "Esci");
            tip.SetToolTip(btnPDFCreator, "Stampa Report");
            //Istanza model e struttura dati
            dataReports = new ModelDataReports();
            runReports = new ModelDataReports.RunReports();
            //Definisce il colore senza focus sulla textbox custom
            txtSelectYear.BorderColor = Color.FromArgb(169,172,174);

        }

        #region Metodi privati

        /// <summary>
        /// Metodo per l'acquisizione del parametro statico "year" della struttura dati
        /// Passaggio di valori tra form alla chiusura del form
        /// </summary>
        /// <param name="sender">Parametro obbligatorio</param>
        /// <param name="e">Parametro obbligatorio</param>
        private void refreshText(object sender, EventArgs e)
        {
            //Acquisisce il valore dell'attributo statico della struttura dati
            txtSelectYear.Texts = ModelDataReports.RunReports.year.ToString();
        }

        /// <summary>
        /// Metodo per l'associazione dei dati alle textbox
        /// </summary>
        /// <param name="report">Struttura dati ADT</param>
        private void bindingData(ModelDataReports.RunReports report)
        {
            //Verifica siano presenti valori mensili di report
            if (report.reportMounth.Count == 0) return;

            //Valori mensili di tot entrate, spese mensili, soldi risparmiati
            txtGennuary.Text = report.reportMounth[0].pay.ToString();
            txtGenSpend.Text = report.reportMounth[0].spend.ToString();
            txtGenSafe.Text = report.reportMounth[0].safe.ToString();
            txtFebbruary.Text = report.reportMounth[1].pay.ToString();
            txtFebSpend.Text = report.reportMounth[1].spend.ToString();
            txtFebSafe.Text = report.reportMounth[1].safe.ToString();
            txtMarch.Text = report.reportMounth[2].pay.ToString();
            txtMarchSpend.Text = report.reportMounth[2].spend.ToString();
            txtMarchSafe.Text = report.reportMounth[2].safe.ToString();
            txtApril.Text = report.reportMounth[3].pay.ToString();
            txtAprilSpend.Text = report.reportMounth[3].spend.ToString();
            txtAprilSafe.Text = report.reportMounth[3].safe.ToString();
            txtMay.Text = report.reportMounth[4].pay.ToString();
            txtMaySpend.Text = report.reportMounth[4].spend.ToString();
            txtMaySafe.Text = report.reportMounth[4].safe.ToString();
            txtJune.Text = report.reportMounth[5].pay.ToString();
            txtJuneSpend.Text = report.reportMounth[5].spend.ToString();
            txtJuneSafe.Text = report.reportMounth[5].safe.ToString();
            txtJuly.Text = report.reportMounth[6].pay.ToString();
            txtJulySpend.Text = report.reportMounth[6].spend.ToString();
            txtJulySafe.Text = report.reportMounth[6].safe.ToString();
            txtAug.Text = report.reportMounth[7].pay.ToString();
            txtAugSpend.Text = report.reportMounth[7].spend.ToString();
            txtAugSafe.Text = report.reportMounth[7].safe.ToString();
            txtSept.Text = report.reportMounth[8].pay.ToString();
            txtSeptSpend.Text = report.reportMounth[8].spend.ToString();
            txtSeptSafe.Text = report.reportMounth[8].safe.ToString();
            txtOctb.Text = report.reportMounth[9].pay.ToString();
            txtOctbSpend.Text = report.reportMounth[9].spend.ToString();
            txtOctbSafe.Text = report.reportMounth[9].safe.ToString();
            txtNov.Text = report.reportMounth[10].pay.ToString();
            txtNovSpend.Text = report.reportMounth[10].spend.ToString();
            txtNovSafe.Text = report.reportMounth[10].safe.ToString();
            txtDec.Text = report.reportMounth[11].pay.ToString();
            txtDecSpend.Text = report.reportMounth[11].spend.ToString();
            txtDecSafe.Text = report.reportMounth[11].safe.ToString();

            //Calcolo media mensile risparmiati
            double media, somma = 0;

            for (int i = 0; i < report.reportMounth.Count; i++)
            {
                somma = somma + report.reportMounth[i].safe;
            }
            media = somma / 12;
            txtMedia.Text = media.ToString();

            //Totale entrate annue, tot spese annue
            txtTotEntryYear.Text = report.tot_year_gain.ToString();
            txtTotSpendYear.Text = report.tot_year_spend.ToString();
            
        }

        #endregion

        #region Buttons

        private void btnListYears_Click(object sender, EventArgs e)
        {
            //Attiva il form searchYear
            frmSarchYear searchYear = new frmSarchYear();
            searchYear.Show();
            //Alla chiusura del form assegna il valore al textbox
            searchYear.Deactivate += new EventHandler(refreshText);

        }

        private void btnRunningReport_Click(object sender, EventArgs e)
        {
            //Attributo anno da reportare
            int year;

            //Verifica sia stato inserito un valore come anno da reportare
            if (txtSelectYear.Texts.Length > 0)
            {
                try
                {
                    //Ottiente l'ADT dalla struttura dati e esegue il binding sulle textbox
                    year = Int32.Parse(txtSelectYear.Texts);

                }catch(Exception ex)
                {
                    MessageBox.Show("Il valore inserito non è numerico", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Ottiente l'ADT dalla struttura dati e esegue il binding sulle textbox
                runReports = dataReports.getReport(year);
                bindingData(runReports);
                reportDone = true;
            }
        }


        private void btnPDFCreator_Click(object sender, EventArgs e)
        {
            //Se il report è stato eseguito
            if (reportDone)
            {
                //Istanza all'oggetto per la creazione del file PDF
                ExecuteReportPDF report = new ExecuteReportPDF(runReports);
                //Invoca il metodo per generare il PDF
                report.generateReport();
            }
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Chiude il form
            Dispose();
        }

        #endregion

         #region links

        private void lnkSpendElements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Mostra il form di report spese e nasconde il form principale
            frmSpendElements frmSpendsElement = new frmSpendElements();
            frmSpendsElement.Show();
            this.Hide();
        }


        #endregion

        #region Textbox
        private void txtSelectYear_Enter(object sender, EventArgs e)
        {
            //Setta il colore del bordo al ricevimento del focus
            txtSelectYear.BorderColor = Color.FromArgb(178, 221, 249);
        }

        private void txtSelectYear_Leave(object sender, EventArgs e)
        {
            //Setta il colore del bordo allo scarico del focus
            txtSelectYear.BorderColor = Color.FromArgb(169, 172, 174);
        }

        #endregion

    }
}
