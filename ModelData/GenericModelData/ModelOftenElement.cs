using Connection;
using System.Windows.Forms;
using System;
using ReadXML;

namespace GenericModelData
{
    /// <summary>
    /// Classe per la lettura e il salvataggio delle voci frequenti
    /// </summary>
    public class ModelOftenElement : ModelDataSY
    {
        /// <summary>
        /// Costruttore della classe di tipo void
        /// </summary>
        public ModelOftenElement() { }

        /// <summary>
        /// Metodo per leggere le causali frequenti e aggiungerle a una ListBox
        /// </summary>
        /// <param name="list">ListBox in cui aggiungere i valori</param>
        public void loadOftenCause(ListBox list)
        {
            ReadErrorXml xml = new ReadErrorXml();

            try
            {   //connessione + mapping
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM causali_frequenti;";
                var reader = connecting.reader(command, query);

                //aggiunge gli elementi alla ListBox
                while (reader.Read())
                {
                    list.Items.Add(reader.GetString(1));
                }

                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Metodo per salvare le causali frequenti
        /// </summary>
        /// <param name="val">Causale da inserire nel DB</param>
        /// <returns>Ritorna true se inserimento ok</returns>
        public bool saveOftenCause(string val)
        {
            bool insert = false;
            ReadErrorXml xml = new ReadErrorXml();

            try
            {   //connessione
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //Utilizza la funzione dual per evitare di inserire elementi già esistenti
                string query = $"INSERT INTO causali_frequenti(often_cause) " +
                    $"SELECT '{val}' FROM DUAL WHERE NOT EXISTS " +
                    $"(SELECT * FROM causali_frequenti WHERE often_cause LIKE '%{val}%');";

                command.CommandText = query;
                //se l'inserimento ha avuto effetto set il valore di ritorno a true
                if (command.ExecuteNonQuery() > 0)
                {
                    insert = true;
                }
                else insert = false;

                //scarica le risorse
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
                MessageBox.Show(ex.Message);
            }
            //restituisce true se inserimento ok
            return insert;
        }

        /// <summary>
        /// Metodo per eliminare una causale frequente
        /// </summary>
        /// <param name="val">Causale da eliminare</param>
        /// <returns>Ritorna true se eliminazione ok</returns>
        public bool removeOftenCause(string val)
        {
            bool insert = false;
            ReadErrorXml xml = new ReadErrorXml();
            int id = 0;

            try
            {   //connessione
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //mapping per ricavare la PK della riga da eliminare
                string query = $"SELECT * FROM causali_frequenti WHERE often_cause LIKE('%{val}%'); ";
                var reader = connecting.reader(command, query);

                if (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                command.Dispose();
                reader.Dispose();

                //elimino la riga confrontando la PK
                query = $"DELETE FROM causali_frequenti WHERE id_often_cause={id}";
                command.CommandText = query;
                //se l'inserimento ha avuto effetto set il valore di ritorno a true
                if (command.ExecuteNonQuery() > 0)
                {
                    insert = true;
                }
                else insert = false;

                //scarica le risorse
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
                MessageBox.Show(ex.Message);
            }
            //restituisce true se inserimento ok
            return insert;
        }

    }
}
