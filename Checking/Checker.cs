﻿using System.Windows.Forms;
using ReadXML;
using System;


namespace Checking
{
    /// <summary>
    /// Classe per il controllo elementi
    /// </summary>
    public class Checker
    {
        private ReadErrorXml xml;
        private ReaderXML reader;
        private string path;
        private string father;
        private string featur;

        /// <summary>
        /// Classe per il controllo elementi
        /// </summary>
        /// <param name="path">Percorso file XML degli errori</param>
        /// <param name="father">Nodo padre</param>
        /// <param name="featur">Attributo nodo padre</param>
        public Checker(string path, string father, string featur)
        {
            xml = new ReadErrorXml();
            this.path = path;
            this.father = father;
            this.featur = featur;
        }
        /// <summary>
        /// Costruttore di default
        /// </summary>
        public Checker(string path)
        {
            this.path = path;
            reader = new ReaderXML(path);
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public Checker() { }

        /// <summary>
        /// Metodo per la verifica di campo vuoto
        /// </summary>
        /// <param name="t">Textbox da verificare</param>
        /// <returns>Ritorno false se textbox compilata</returns>
        public bool isEmpty(string t)
        {
            bool empty = true;
            if (t.Length > 0)
            {
                empty = false;
            }
            else
            {
                empty = true;
                throw new FormatException(reader.readNode("ListError", "Error1"));
            }
            return empty;
        }

        /// <summary>
        /// Metodo per la verifica di valore double di RoundedTextBox
        /// </summary>
        /// <param name="t">Textbox con il valore da controllare</param>
        /// <returns>Ritorna true se il valore è double</returns>
        public bool isNumeric(string t)
        {
            double d = 0;
            bool ver = double.TryParse(t, out d);

            if (ver == false)
            {
                throw new FormatException(reader.readNode("ListError", "Error2"));
            }

            return ver;
        }

        /// <summary>
        /// Metodo per la verifica di valore integer
        /// </summary>
        /// <param name="t">Textbox con il valore da controllare</param>
        /// <param name="isInt">Parametro a true se il controllo è su integer</param>
        /// <returns>Ritorna true se il valore è integer</returns>
        public bool isNumeric(TextBox t,bool isInt)
        {
            bool ver = false;

            if(isInt == true)
            {
                string val = t.Text;
                int i = 0;
                ver = int.TryParse(val, out i);

                if(ver == false)
                {
                    xml.manageError(2, path, father, featur);
                }
            }
            return ver;
        }


        /// <summary>
        /// Metodo per il controllo TextBox rounded del valore in un range int
        /// </summary>
        /// <param name="t">Textbox con i valori da controllare</param>
        /// <param name="valMin">Valore minimo compreso nel range</param>
        /// <param name="valMax">Valore massimo compreso nel range</param>
        /// <returns></returns>
        public bool inRange(string t, int valMin, int valMax)
        {
            bool val = false;
            if (t.Length == 0) return val;
            int v = Int32.Parse(t);

            if (v >= valMin && v <= valMax)
            {
                val = true;
            }
            else
            {
                throw new FormatException(reader.readNode("ListError", "Error13"));
            }
            return val;
        }

        /// <summary>
        /// Metodo per il controllo del valore in un range int
        /// </summary>
        /// <param name="t">Range int da verificare</param>
        /// <param name="valMin">Valore minimo del range</param>
        /// <param name="valMax">Valore massimo del range</param>
        /// <returns></returns>
        public bool inRange(int t, int valMin, int valMax)
        {
            bool val = false;

            if (t >= valMin && t <= valMax)
            {
                val = true;
            }
            else
            {
                xml.manageError(13, path, father, featur);
            }
            return val;
        }

        /// <summary>
        ///  Metodo per il controllo del valore in un array string 
        /// </summary>
        /// <param name="t">Textbox con i valori da controllare</param>
        /// <param name="values">Range da verificare</param>
        /// <returns>Ritorna true se compreso nel range</returns>
        public bool inRange(TextBox t, string[] values)
        {
            bool val = false;
            int i = values.Length;

            for(int j = 0; j <= i; j++)
            {
                if (t.Text.Equals(values[j]))
                {
                    val = true;
                    return val;
                }
                else
                {
                    val = false;
                }
            }
            return val;

        }

        /// <summary>
        /// Metodo per il controllo di selezione di un comboBox
        /// </summary>
        /// <param name="t">ComboBox da controllare</param>
        /// <returns>Restituisce true se un elemento è selezionato</returns>
        public bool isSelected(ComboBox t)
        {
            bool val = false;

            if (!(t.SelectedItem == null))
            {
                val = true;
            }
            else
            {
                throw new FormatException(reader.readNode("ListError", "Error1"));
            }
            return val;

        }

        /// <summary>
        /// Metodo per troncare una stringa a un certo numero di caratteri dopo la virgola
        /// </summary>
        /// <param name="t">TextBox su cui troncare i caratteri</param>
        /// <param name="nChar">Numero di caratteri dopo la virgola</param>
        public void truncateString(TextBox t, int nChar = 0)
        {
            
            string text, newPart = "" , newVal;
            //attributo opzionale, se non valorizzato di default è 3
            if (nChar == 0) nChar = 3;

            text = t.Text;

            //tronca la stringa dopo la virgola
            string[] parts = text.Split(',');
            //Verifica ci siano numeri dopo la virgola
            if (parts.Length > 1)
            {
                //se maggiore di 3 caratteri dopo la virgola lo tronca
                if (parts[1].ToString().Length > nChar)
                {
                    newPart = parts[1].ToString().Substring(0, nChar);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            //assegna il nuovo valore alla textbox
            newVal = parts[0].ToString() + "," + newPart;
            t.Text = newVal;

        }

        /// <summary>
        /// Motodo per l'arrotondamento alla cifra decimale stabilita di un valore double
        /// </summary>
        /// <param name="t">TextBox con il valore da arrotondare</param>
        /// <param name="nChar">Numero di decimali per l'arrotondamento</param>
        public void truncate(TextBox t, int nChar = 0)
        {
            double showValue = 0, value = 0;
            //Se non specificato un numero di decimali per l'arrotondamento
            //viene settato alla seconda cifra decimale
            if (nChar == 0) nChar = 2;
            //Acquisisce il valore dalla TextBox
            value = Double.Parse(t.Text);
            //Arrotonda alla cifra decimale stabilita
            showValue = Math.Round(value, nChar);
            //Restituisce il valore arrotondato alla TextBox
            t.Text = showValue.ToString();

        }

    }
}
