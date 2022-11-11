using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GenericModelData;

namespace RunningReports
{
    public partial class frmSpendElements : Form
    {
        //Istanza model e struttura dati
        private ModelDataReports dataReports;
        private ModelDataReports.RunReportsSpends reportsSpends;
        private List<ModelDataReports.RunReportsSpends> list;

        //Attributi privati per la creazione del Report in PDF
        /// <summary>
        /// Getter Setter per il mese con la spesa più elevata
        /// </summary>
        private string BadMonths { get; set; }
        /// <summary>
        /// Getter Setter per la cifra della spesa più elevata
        /// </summary>
        private double BadImport { get; set; }
        //Attributo di verifica dell'esecuzione del report
        private bool reportDone = false;

        //Costruttore di Default
        public frmSpendElements()
        {
            InitializeComponent();
            //Set dei tooltip sui pulsanti
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(btnListYears, "Apri lista Anni disponibili");
            tip.SetToolTip(btnRunReports, "Esegui Report spesa mensile");
            tip.SetToolTip(btnExit, "Esci");
            tip.SetToolTip(btnPDFCreator, "Stampa Report");
            //Istanza agli oggetti
            dataReports = new ModelDataReports();
            reportsSpends = new ModelDataReports.RunReportsSpends();
            list = new List<ModelDataReports.RunReportsSpends>();
            //Definisce il colore di bordo della textbox
            txtSelectYear.BorderColor = Color.FromArgb(169, 172, 174);
          
        }

        #region Metodi privati
        /// <summary>
        /// Aggiorna il valore della textbox con l'anno selezionato
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Args</param>
        private void refreshText(object sender, EventArgs e)
        {
            //Aggiorno la textbox
            txtSelectYear.Texts = ModelDataReports.RunReports.year.ToString();
        }

        /// <summary>
        /// Metodo per visualizzare il form principale alla chiesura di questo form
        /// oppure utilizzando il link
        /// </summary>
        private void showMainForm()
        {
            //Mostra il form principale e scarica il form di reportSpese.
            frmRunReports frmRunReports = new frmRunReports();
            frmRunReports.Show();
            this.Dispose();
        }

        #endregion

        #region Form
        private void frmSpendElements_Load(object sender, EventArgs e)
        {
            //Ottiene la lista con le causali frequenti
            reportsSpends = dataReports.getOftenCauses();
            //Preleva ogni stringa dalla lista e l'assegna al comboBox
            foreach (string val in reportsSpends.oftenCauses)
            {
                cmbSelOftenSpends.Items.Add(val);
            }

        }

        #endregion

        #region Button

        private void btnRunReports_Click(object sender, EventArgs e)
        {
            string spend = "", monthPre = "", badMonth = "";
            int year = 0;
            double totAnnuo = 0, totMensile = 0, totBadMonth = 0;
            txtReportsSpends.Texts = "";

            //Se non sono stati selezionati i valori per il report esce dal metodo
            if (cmbSelOftenSpends.SelectedIndex < 0 || txtSelectYear.Texts.Length == 0)
            {
                MessageBox.Show("Nessun valore è stato selezionato per eseguire il report", "MESSAGGIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Preleva i valori selezionati
            spend = cmbSelOftenSpends.SelectedItem.ToString();
            year = Int32.Parse(txtSelectYear.Texts);
            //Ottiene la lista dal DB
            list = dataReports.getOftenSpendsList(spend, year);

            //Se la lista contiene elementi
            if (list.Count > 0)
            {
                txtReportsSpends.Texts += "REPORT ANNO: " + year.ToString().ToUpper() + "\r\n\r\n";                
                //Cicla ogni elemento della lista e assegna il valore al textbox del risultato
                foreach (ModelDataReports.RunReportsSpends voice in list)
                {
                    txtReportsSpends.Texts += voice.oftenCause.ToUpper() + "\t" + voice.import.ToString().ToUpper() + "€" + "\t" + voice.mese.ToUpper() + "\r\n";
                    totAnnuo += voice.import;
                    //Calcola il mese/mesi con la spese più elevata
                    if (monthPre == voice.mese)
                    {
                        totMensile += voice.import;
                        if(totMensile > totBadMonth) totBadMonth = totMensile;
                        badMonth = voice.mese;
                    }
                    else
                    {
                        monthPre = voice.mese;
                        if (voice.import > totBadMonth)
                        {
                            totBadMonth = voice.import;
                            badMonth = voice.mese;
                        }
                        else if(voice.import == totBadMonth)
                        {
                            totBadMonth = voice.import;
                            badMonth += " / " + voice.mese;
                        }
                    }
                }
                txtReportsSpends.Texts += "\r\n\r\nTOTALE ANNUALE: " + totAnnuo.ToString().ToUpper() + "€" + "\r\n\r\n";
                txtReportsSpends.Texts += "MESI CON SPESA PIù ELEVATA: \r\n" + badMonth.ToUpper() + " => " + totBadMonth.ToString().ToUpper() + "€" + "\r\n\r\n";

                //Set parametri privati per report PDF
                BadMonths = badMonth;
                BadImport = totBadMonth;
                reportDone = true;

            }
            else
            {
                txtReportsSpends.Texts = "NESSUN RISULTATO TROVATO";
            }

        }

        private void btnListYears_Click(object sender, EventArgs e)
        {
            //Apre la finestra degli anni disponibili da DB
            frmSarchYear frmYear = new frmSarchYear();
            frmYear.Show();
            //Alla chiusura del form child aggiorna la casella di testo
            frmYear.Deactivate += new EventHandler(refreshText);
        }

        private void btnPDFCreator_Click(object sender, EventArgs e)
        {
            //Se eseguito il report
            if (reportDone)
            {
                //Istanza all'oggetto per la creazione del file PDF con il report
                ExecuteReportPDF exeReport = new ExecuteReportPDF(list);
                //Invoca il metodo per ottenere il file PDF
                exeReport.generateReport(txtSelectYear.Texts, BadMonths, BadImport);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Invoca il metodo per la chiusura di questo form
            //e la visualizzazione del form principale
            showMainForm();
        }

        #endregion

        #region Link
        private void lnkYearReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Invoca il metodo per la chiusura di questo form
            //e la visualizzazione del form principale
            showMainForm();
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
            //Setta il colore del bordo al rilascio del focus
            txtSelectYear.BorderColor = Color.FromArgb(169, 172, 174);
        }

        #endregion

        

    }
}
