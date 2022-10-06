using System;
using GenericModelData;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;

namespace RunningReports
{
    /// <summary>
    /// Classe per la creazione del file PDF con il report annuale
    /// </summary>
    public class ExecuteReportPDF
    {
        /// <summary>
        /// Costruttore a cui passo l'oggetto ADT runReport
        /// </summary>
        private ModelDataReports.RunReports runReport;
        public ExecuteReportPDF(ModelDataReports.RunReports runReport)
        {
            this.runReport = runReport;
        }

        /// <summary>
        /// Metodo privato per il settaggio degli headers della tabella
        /// </summary>
        /// <param name="table">Tabella da settare</param>
        /// <param name="value">Valori da inserire negli header</param>
        /// <param name="element">Numero di colonne</param>
        private void setTableHeader(PdfPTable table, string[] value, int element)
        {
            for (int i = 0; i <= element; i++)
            {
                //Definisce lo stile dell'intestazione
                Chunk chunk = new Chunk(value[i], FontFactory.GetFont("Courier New", 12, 1));
                //Aggiunge la stringa al testo da aggiungere all'intestazione
                Phrase phrase = new Phrase(chunk);
                Paragraph columnHeader = new Paragraph(phrase);
                //aggiunge il testo alla cella
                PdfPCell cell = new PdfPCell(columnHeader);
                //Definisce allineamento e colore di sfondo
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.CYAN;
                table.AddCell(cell);
            }
        }

        /// <summary>
        /// Metodo privato per l'inserimento dei valori in tabella
        /// </summary>
        /// <param name="table">Tabella dove inserire i valori</param>
        /// <param name="startRange">Punto dell'array da cui partire a inserire</param>
        private void setTableData(PdfPTable table, int startRange)
        {
            PdfPCell cell;
            Paragraph text;
            int a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                //Inserisce e centra il paragrafo dentro la cella
                text = new Paragraph("ST: "+runReport.reportMounth[a].pay.ToString());
                cell = new PdfPCell(text);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                a++;
            }
            a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                //Inserisce e centra il paragrafo dentro la cella
                text = new Paragraph("SP: " + runReport.reportMounth[a].spend.ToString());
                cell = new PdfPCell(text);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                a++;
            }
            a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                //Inserisce e centra il paragrafo dentro la cella
                text = new Paragraph("RS: " + runReport.reportMounth[a].safe.ToString());
                cell = new PdfPCell(text);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                a++;
            }
        }

        public void generateReport()
        {
            //Valori degli headers della tabella inseriti dal metodo privato
            string[] primo_semestre = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno" };
            string[] secondo_semestre = { "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };
            string[] head_report_annuale = { "TOT Ricavo Annuo", "TOT Spese Annue" };
            //Percorso dove salvare il report in PDF
            string path = @"C:\MpFA22\RunningReports\Data\ReportPDF.pdf";

            try
            {
                //Separatore tra elementi
                PdfDiv div = new PdfDiv();
                div.Height = 30;
                div.PercentageWidth = 100;

                //Definisce lo stile dell'intestazione file
                Chunk chunk = new Chunk("REPORT ANNUALE", FontFactory.GetFont("Courier New", 12, 1));
                //Aggiunge la stringa al testo da aggiungere all'intestazione
                Phrase phrase = new Phrase(chunk);
                Paragraph title = new Paragraph(phrase);
                //Definisce l'allineamento centrato
                title.Alignment = 1;

                //Definisce la tabella con i dati del primo semestre
                PdfPTable tablePrimoSemestre = new PdfPTable(6);
                //Imposta il padding
                tablePrimoSemestre.DefaultCell.Padding = 3;
                //Imposta la larghezza delle celle
                tablePrimoSemestre.WidthPercentage = 100;
                //Alliena il testo a sx
                tablePrimoSemestre.HorizontalAlignment = Element.ALIGN_LEFT;
                //Imposta gli header della tabella
                setTableHeader(tablePrimoSemestre, primo_semestre, 5);
                //Aggiunge i valori alla tabella
                setTableData(tablePrimoSemestre, 0);

                //Definisce la tabella con i dati del secondo semestre
                PdfPTable tableSecondoSemestre = new PdfPTable(6);
                //Imposta il padding
                tableSecondoSemestre.DefaultCell.Padding = 3;
                //Imposta la larghezza delle celle
                tableSecondoSemestre.WidthPercentage = 100;
                //Alliena il testo a sx
                tableSecondoSemestre.HorizontalAlignment = Element.ALIGN_LEFT;
                //Imposta gli header della tabella
                setTableHeader(tableSecondoSemestre, secondo_semestre, 5);
                //Aggiunge i valori alla tabella
                setTableData(tableSecondoSemestre, 6);


                //Definisce la tabella dei totali annuali
                PdfPTable tableReportAnnuale = new PdfPTable(2);
                //Imposta il padding
                tableReportAnnuale.DefaultCell.Padding = 3;
                //Imposta la larghezza delle celle
                tableReportAnnuale.WidthPercentage = 100;
                //Alliena il testo a sx
                tableReportAnnuale.HorizontalAlignment = Element.ALIGN_LEFT;
                //Imposta gli header della tabella
                setTableHeader(tableReportAnnuale, head_report_annuale, 1);
                //Inserisce e centra i valori in tabella
                Paragraph tot = new Paragraph(runReport.tot_year_gain.ToString());
                PdfPCell cell = new PdfPCell(tot);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tableReportAnnuale.AddCell(cell);
                tot = new Paragraph(runReport.tot_year_spend.ToString());
                cell = new PdfPCell(tot);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tableReportAnnuale.AddCell(cell);

                //Calcola la media di risparmio mensile dell'anno
                double media, somma = 0;

                for (int i = 0; i < runReport.reportMounth.Count; i++)
                {
                    somma = somma + runReport.reportMounth[i].safe;
                }
                media = somma / 12;
                string[] mediaHeader = { "MEDIA RISPARMIO MENSILE" };
                //Inserisce la media in tabella
                PdfPTable tableReportMedia = new PdfPTable(1);
                //Imposta il padding
                tableReportMedia.DefaultCell.Padding = 3;
                //Imposta la larghezza delle celle
                tableReportMedia.WidthPercentage = 100;
                //Alliena il testo a sx
                tableReportMedia.HorizontalAlignment = Element.ALIGN_LEFT;
                //Imposta gli header della tabella
                setTableHeader(tableReportMedia, mediaHeader, 0);
                //Inserisce e centra i valori in tabella
                Paragraph mediaText = new Paragraph(media.ToString());
                cell = new PdfPCell(mediaText);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                tableReportMedia.AddCell(cell);

                //Apre il flusso per il file con il percorso passato attraverso il setter
                FileStream stream = new FileStream(path, FileMode.Create);
                //Crea il documento PDF e ne definisce il formato
                Document document = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                //Assegna il documento allo stream del file per il salvataggio
                PdfWriter.GetInstance(document, stream);
                //Apre il documento e ci aggiunge gli elementi
                document.Open();
                document.Add(title);
                document.Add(div);
                document.Add(tablePrimoSemestre);
                document.Add(div);
                document.Add(tableSecondoSemestre);
                document.Add(div);
                document.Add(tableReportMedia);
                document.Add(div);
                document.Add(tableReportAnnuale);
                document.Add(div);
                //Scarica le risorse
                document.Close();
                stream.Close();
                //Messaggio di successo
                MessageBox.Show("Report creato correttamente !!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Impossibile creare il report. Errore: "+ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

    }
}
