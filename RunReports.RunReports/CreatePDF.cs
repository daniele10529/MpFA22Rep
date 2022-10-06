using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GenericModelData;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace RunReports.RunReports
{
    public class CreatePDF
    {
        private ModelDataReports.RunReports runReport;

        public CreatePDF(ModelDataReports.RunReports runReport)
        {
            this.runReport = runReport;
        }

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
                PdfPCell cell = new PdfPCell();
                //Definisce allineamento e colore di sfondo
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.CYAN;
                table.AddCell(cell);
            }
        }

        private void setTableData(PdfPTable table, int startRange)
        {
            int a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                table.AddCell(runReport.reportMounth[a].pay.ToString());
                a++;
            }
            a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                table.AddCell(runReport.reportMounth[a].spend.ToString());
                a++;
            }
            a = startRange;
            for (int i = 0; i <= 5; i++)
            {
                table.AddCell(runReport.reportMounth[a].safe.ToString());
                a++;
            }
        }

        public void getReportPDF()
        {
            string[] primo_semestre = { "Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno" };
            string[] secondo_semestre = { "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };
            string[] head_report_annuale = { "TOT Ricavo Annuo", "TOT Spese Annue" };
            string path = @"D:\Test\ReportPDF.pdf";

            //Definisce lo stile dell'intestazione
            Chunk chunk = new Chunk("REPORT ANNUALE", FontFactory.GetFont("Courier New", 12, 1));
            //Aggiunge la stringa al testo da aggiungere all'intestazione
            Phrase phrase = new Phrase(chunk);
            Paragraph title = new Paragraph(phrase);



            //Definisce la tabelle per il PDF partendo dalle colonne del DataGridView
            PdfPTable tablePrimoSemestre = new PdfPTable(6);
            //Imposta il padding
            tablePrimoSemestre.DefaultCell.Padding = 3;
            //Imposta la larghezza delle celle
            tablePrimoSemestre.WidthPercentage = 100;
            //Alliena il testo a sx
            tablePrimoSemestre.HorizontalAlignment = Element.ALIGN_LEFT;

            setTableHeader(tablePrimoSemestre, primo_semestre, 5);

            setTableData(tablePrimoSemestre, 0);


            //Definisce la tabelle per il PDF partendo dalle colonne del DataGridView
            PdfPTable tableSecondoSemestre = new PdfPTable(6);
            //Imposta il padding
            tablePrimoSemestre.DefaultCell.Padding = 3;
            //Imposta la larghezza delle celle
            tablePrimoSemestre.WidthPercentage = 100;
            //Alliena il testo a sx
            tablePrimoSemestre.HorizontalAlignment = Element.ALIGN_LEFT;

            setTableHeader(tableSecondoSemestre, secondo_semestre, 5);

            setTableData(tableSecondoSemestre, 6);


            //Definisce la tabelle per il PDF partendo dalle colonne del DataGridView
            PdfPTable tableReportAnnuale = new PdfPTable(2);
            //Imposta il padding
            tablePrimoSemestre.DefaultCell.Padding = 3;
            //Imposta la larghezza delle celle
            tablePrimoSemestre.WidthPercentage = 100;
            //Alliena il testo a sx
            tablePrimoSemestre.HorizontalAlignment = Element.ALIGN_LEFT;

            setTableHeader(tableReportAnnuale, head_report_annuale, 1);

            tableReportAnnuale.AddCell(runReport.tot_year_gain.ToString());
            tableReportAnnuale.AddCell(runReport.tot_year_spend.ToString());

            

            //Apre il flusso per il file con il percorso passato attraverso il setter
            FileStream stream = new FileStream(path, FileMode.Create);
            //Crea il documento PDF e ne definisce il formato
            Document document = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
            //Assegna il documento allo stream del file per il salvataggio
            PdfWriter.GetInstance(document, stream);
            //Apre il documento e ci aggiunge la tabella
            document.Open();
            document.Add(title);
            document.Add(tablePrimoSemestre);
            document.Add(tableSecondoSemestre);
            document.Add(tableReportAnnuale);
            //Scarica le risorse
            document.Close();
            stream.Close();

        }


    }
}
