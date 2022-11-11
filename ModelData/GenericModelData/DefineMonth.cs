using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericModelData
{
    /// <summary>
    /// Classe per la discriminante del mese selezionato.
    /// Da index a mese; da mese a index
    /// </summary>
    public class DefineMonth
    {
        /// <summary>
        /// Costruttore di default
        /// </summary>
        public DefineMonth() { }

        /// <summary>
        /// Metodo per ottenere l'index dal nome del mese
        /// </summary>
        /// <param name="month">Mese per l'index</param>
        /// <returns>Ritorna l'index int del mese</returns>
        public int getIndexFromNameMonth(string month)
        {
            int n = 0;
            switch (month)
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

        /// <summary>
        /// Metodo per ottenere il mone del mese dall'index
        /// </summary>
        /// <param name="indexMonth">Index mese</param>
        /// <returns>Restituisce il nome del mese string dall'index</returns>
        public string getMonthFromIndex(int indexMonth)
        {
            string n = "";
            switch (indexMonth)
            {
                case 1:
                    n = "gennaio";
                    break;
                case 2:
                    n = "febbraio";
                    break;
                case 3:
                    n = "marzo";
                    break;
                case 4:
                    n = "aprile";
                    break;
                case 5:
                    n = "maggio";
                    break;
                case 6:
                    n = "giugno";
                    break;
                case 7:
                    n = "luglio";
                    break;
                case 8:
                    n = "agosto";
                    break;
                case 9:
                    n = "settembre";
                    break;
                case 10:
                    n = "ottobre";
                    break;
                case 11:
                    n = "novembre";
                    break;
                case 12:
                    n = "dicembre";
                    break;
            }
            return n;
        }
        
    }
}
