using System.Drawing;
using GenericModelData;
using ReadXML;
using System;
using RoundendControlCollections;

namespace MpFA20
{
    /// <summary>
    /// Classe per la verifica della contabilità mensile
    /// </summary>
    class Contabilita
    {
        //Attributi privati
        private const string pathSetIni = Routes.XMLSETINI;
        private const string fatherIni = "setIni";
        private int manage_year;
        private int manage_month;
        
        /// <summary>
        /// Costruttore della classe per la gestione di contabilità
        /// </summary>
        /// <param name="manage_year">Anno caricato</param>
        /// <param name="manage_month">Mese caricato</param>
        public Contabilita(int manage_year,int manage_month)
        {
            this.manage_year = manage_year;
            this.manage_month = manage_month;
        }

        /// <summary>
        /// Esegue il conteggio, dopo l'estrazione da DB attraverso ModelData,
        /// restituisce lo stato della contabilità
        /// </summary>
        /// <param name="risparmiati">Soldi risparmiati mese attuale</param>
        /// <param name="contanti">Contanti attuali</param>
        /// <param name="saldoCC">Saldo cc attuale</param>
        /// <param name="saldoLib">Saldo libretto attuale</param>
        /// <param name="saldoPP">Saldo pp attuale</param>
        /// <param name="t">TextBox di response contabilità</param>
        /// <returns>Restituisce valore string con lesito del bilancio</returns>
        public string conteggio(double risparmiati,double contanti,double saldoCC,double saldoLib,double saldoPP, RoundedTextBox t)
        {
            
            double tot_cc = 0, tot_lib = 0, tot_pp = 0;
            double mesePre = 0, meseActual = 0, conteggio = 0, difference = 0, returnValue = 0;
            double tolleranceMin = risparmiati - 0.5;
            double tolleranceMax = risparmiati + 0.5;

            //Istanza alla classe model
            ModelDataSY model = new ModelDataSY();

            //Se al gennaio 2019 legge i dati di setIni e li somma
            //come valore del mese precedente
            if (manage_year == 2019 && manage_month == 1)
            {
                ReaderXML reader = new ReaderXML(pathSetIni, fatherIni);
                tot_cc = Double.Parse(reader.readNode("tot_cc"));
                tot_lib = Double.Parse(reader.readNode("tot_lib"));
                tot_pp = Double.Parse(reader.readNode("tot_pp"));
                mesePre = tot_cc + tot_lib + tot_pp;
            }
            else
            {
                //Altrimenti estrae la situazione al mese precedente da DB
                mesePre = model.countMonthPre(manage_year, manage_month);
            }
            //Calcola lo stato del mese attuale
            meseActual = contanti + saldoCC + saldoLib + saldoPP;
            //Calcola la differenza di contabilità del mese attuale rispetto allo stato del mese precedente
            conteggio = meseActual - mesePre;

            //Verifica lo sbilancio rispetto al conteggio di quanto risparmiato(stipendio - spese del mese)
            if(conteggio == risparmiati || (conteggio > tolleranceMin && conteggio < tolleranceMax))
            {
                //Setta i colori verdi di OK
                t.ForeColor = Color.FromArgb(6, 179, 29);
                t.BorderColor = Color.FromArgb(133, 247, 190);
                return "Contabilità OK";
            }
            else
            {
                //Setta i colori rossi di KO
                t.ForeColor = Color.FromArgb(195, 74, 78);
                t.BorderColor = Color.FromArgb(255, 10, 10);
                //Calcola lo sbilancio e arrotonda alla seconda cifra decimale
                difference = conteggio - risparmiati;
                returnValue = Math.Round(difference, 2);
                return "Contabilità KO: " + returnValue.ToString() + "€"; 
            }

        }

    }
}
