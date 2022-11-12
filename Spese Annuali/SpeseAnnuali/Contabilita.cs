﻿using System.Drawing;
using System.Windows.Forms;
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
        private const string pathSetIni = Routes.XMLSETINI;
        private const string fatherIni = "setIni";
        private int manage_year;
        private int manage_month;
        /// <summary>
        /// Costruttore della classe per la gestione di contabilità
        /// </summary>
        /// <param name="manage_year">integer, anno caricato</param>
        /// <param name="manage_month">integer, mese caricato</param>
        public Contabilita(int manage_year,int manage_month)
        {
            this.manage_year = manage_year;
            this.manage_month = manage_month;
        }
        /// <summary>
        /// Esegue il conteggio, dopo l'estrazione da DB attraverso ModelData,
        /// restituisce lo stato della contabilità
        /// </summary>
        /// <param name="risparmiati">double, soldi risparmiati mese attuale</param>
        /// <param name="contanti">double, contanti attuali</param>
        /// <param name="saldoCC">double, saldo cc attuale</param>
        /// <param name="saldoLib">double, saldo libretto attuale</param>
        /// <param name="saldoPP">double, saldo pp attuale</param>
        /// <param name="t">textbox, oggetto su form, gestione colori</param>
        /// <returns>restituisce valore string per la textbox</returns>
        public string conteggio(double risparmiati,double contanti,double saldoCC,double saldoLib,double saldoPP, RoundedTextBox t)
        {
            //22963.83;
            double tot_cc = 0, tot_lib = 0, tot_pp = 0;
            double mesePre = 0, meseActual = 0, conteggio = 0, dif = 0;
            double tolmin = risparmiati - 0.5;
            double tolmax = risparmiati + 0.5;

            ModelDataSY model = new ModelDataSY();
            //se al gennaio 2019 legge i dati di setIni e li somma
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
                mesePre = model.countMonthPre(manage_year, manage_month);
            }

            meseActual = contanti + saldoCC + saldoLib + saldoPP;
            conteggio = meseActual - mesePre;

            if(conteggio == risparmiati || (conteggio > tolmin && conteggio < tolmax))
            {
                t.ForeColor = Color.FromArgb(6, 179, 29);
                t.BorderColor = Color.FromArgb(133, 247, 190);
                return "Contabilità OK";
            }
            else
            {
                t.ForeColor = Color.FromArgb(195, 74, 78);
                t.BorderColor = Color.FromArgb(255, 10, 10);
                dif = conteggio - risparmiati;
                if(!(dif.ToString().Length > 6))
                {
                    return "Contabilità KO:  " + dif.ToString() + "€";
                }
                return "Contabilità KO  " + dif.ToString().Remove(6) + "€"; 
            }
        }
    }
}
