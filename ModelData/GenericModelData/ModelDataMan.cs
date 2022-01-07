using Connection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using ReadXML;
using System.Drawing;
using System.IO;

namespace GenericModelData
{
    /// <summary>
    /// Classe per la gestione dati verso il DB di Mantenimento
    /// </summary>
    public class ModelDataMan : ModelDataSY
    {
        /// <summary>
        /// Classe per la gestione dati verso il DB di Mantenimento, eredita ModelDataSY
        /// </summary>
        public ModelDataMan() { }

        /// <summary>
        /// Struttura dati Mantenimento
        /// </summary>
        public struct Payment
        {
            public int id_mantenimento;//PK
            public string causale;//causale movimento
            public double importo;//importo versato
            public string mese;//mese in formato stringa
        }

        /// <summary>
        /// Metodo per il caricamento TreeView degli anni 
        /// </summary>
        /// <param name="tree">TreeView in cui caricare gli anni</param>
        /// <param name="tab">Tabella del DB per mapping</param>
        public void loadTree(TreeView tree, string tab)
        {
            //istanza alle classi
            ReadErrorXml xml = new ReadErrorXml();
            ReaderXML readxml = new ReaderXML(pathconn, "string");
            //connessione al DB
            stringConnection = readxml.readNode("strconnect");
            Connecting connect = new Connecting(stringConnection);
            //gestione immagini albero
            ImageList imageList = new ImageList();
            string icons = "Spese Annuali.png";

            try
            {   //aggiungo le immagini all'albero
                string ico = pathIco + icons;
                imageList.Images.Add(Image.FromFile(ico));
                tree.ImageList = imageList;
                //connessione e mapping
                var connecting = connect.connection();
                var command = connect.command(connecting);
                string query = "SELECT * FROM " + tab;
                var reader = connect.reader(command, query);
                //aggiungo i valori da DB all'albero
                while (reader.Read())
                {
                    tree.Nodes[0].Nodes.Add(reader.GetString(0));
                    tree.Nodes[0].ImageIndex = 0;
                }
                //scarico gli oggetti
                reader.Dispose();
                command.Dispose();
                connecting.Dispose();

            }
            catch (FileNotFoundException ex)//immagini non trovate
            {
                xml.manageError(5, path, father, featur);
            }
            catch (Exception ex)//errore di connessione DB
            {
                xml.manageError(9, path, father, featur);
            }
        }

        /// <summary>
        /// Metodo perinserire un nuovo anno nel DB
        /// </summary>
        /// <param name="tree">TreeView per update nuovo anno</param>
        /// <param name="anno">Valore dell'anno da inserire, se=0->anno+1</param>
        public void insertYear(TreeView tree, int anno = 0)
        {
            ReadErrorXml xml = new ReadErrorXml();
            int annoinsert;
            string sanno;

            try
            {   //se anno è valorizzata acquisisci quel valore
                if (anno > 0)
                {
                    annoinsert = anno;
                }//se non ci sono anni nel DB e non ne  è stato specificato uno parti dal 2018
                else if (tree.Nodes[0].Nodes.Count == 0 && anno == 0)
                {
                    annoinsert = 2018;
                }
                else//se ci sono già anni nel DB e non ne è specificato uno
                {//incrementa il valore di 1 dell'anno
                    sanno = tree.Nodes[0].LastNode.Text;
                    annoinsert = Int32.Parse(sanno) + 1;
                }
                //Connessione e genero in ogni tabella il valore dell'anno e del mese creato
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);

                var connection = connecting.connection();
                var command = connecting.command(connection);
                command.Parameters.AddWithValue("@anno", annoinsert);
                command.CommandText = $"INSERT INTO anni_mantenimento(anno) VALUES(@anno);" +
                    $"INSERT INTO totale_annuo_mantenimento(anno) VALUES(@anno);";

                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //aggiorno l'albero dopo l'inserimento chiamando il metodo locale
                tree.Nodes[0].Nodes.Clear();
                loadTree(tree, "anni_mantenimento");

            }
            catch (Exception ex)
            {
                xml.manageError(11, path, father, featur);
            }

        }

        /// <summary>
        /// Metodo per il caricamento dei dati da DB
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <returns>Ritorna list(payment) di dati da DB</returns>
        public List<Payment> loadDataMan(int year)
        {
            //lista per il caricamento di tipo struct
            List<Payment> listdata = new List<Payment>();
            ReadErrorXml xml = new ReadErrorXml();
            //istanza alla struttura
            Payment payment;

            try
            {
                //carico i dati da DB in base all'anno selezionato e li assegno alla lista
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM versamenti_mantenimento WHERE anno={year};";
                var reader = connecting.reader(command, query);
                //utilizzo la struttura per caricare la lista
                //ogni elemento della lista è una tupla del DB
                while (reader.Read())
                {
                    payment.id_mantenimento = reader.GetInt32(0);
                    payment.causale = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    payment.mese = reader.GetString(3);
                    listdata.Add(payment);
                }
                //scarico gli oggetti
                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //ritorna la lista
            return listdata;

        }

        /// <summary>
        /// Metodo per il salvataggio dei dati nel DB
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="data">list(payment) di dati da inserire</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveDataMan(int year, List<Payment> data)
        {
            ReadErrorXml xml = new ReadErrorXml();
            //lista di tipo struct per l'insert nel DB
            List<Payment> listdata = new List<Payment>();
            //istanza alla struttura
            Payment payment;
            bool execute = false;
            int i;
            string import;

            try
            {//connessione al DB + mapping dati già presenti
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);

                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM versamenti_mantenimento WHERE anno={year};";
                var reader = connecting.reader(command, query);
                //Leggo i dati presenti su DB, genero la lista di tipo Payment da DB
                while (reader.Read())
                {
                    payment.id_mantenimento = reader.GetInt32(0);
                    payment.causale = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    payment.mese = reader.GetString(3);
                    listdata.Add(payment);
                }
                reader.Dispose();
                //Algoritmo di confronto tra i dati manipolati in datagridview e i dati presenti nel DB
                //Se la lista da datagridview è piu lunga
                if (data.Count >= listdata.Count)
                {//inserisci tutti i nuovi dati
                    for (i = 0; i < data.Count; i++)
                    {//inserisci solo le nuove righe aggiunte
                        if (i >= listdata.Count)
                        {
                            for (i = listdata.Count; i < data.Count; i++)
                            {//ogni elemento della lista è una tupla del DB
                                import = data[i].importo.ToString().Replace(",", ".");
                                command.CommandText = $"INSERT INTO versamenti_mantenimento(id_mantenimento,causale,importo,mese,anno) VALUES({data[i].id_mantenimento},'{data[i].causale}',{import},'{data[i].mese}',{year});";
                                command.ExecuteNonQuery();
                            }
                            break;
                        }//se sono state modificate le righe, aggiorna i valori
                        else if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].mese == data[i].mese))
                        {
                            import = data[i].importo.ToString().Replace(',', '.');
                            command.CommandText = $"UPDATE versamenti_mantenimento SET causale='{data[i].causale}',importo={import},mese='{data[i].mese}' WHERE id_mantenimento={data[i].id_mantenimento}";
                            command.ExecuteNonQuery();
                            command.Dispose();
                            //se non ci sono piu valori da aggiornare esci
                            if (i == (data.Count - 1) && data.Count == listdata.Count)
                            {
                                connection.Close();
                                execute = true;
                                return execute;
                            }
                        }
                    }
                }
                else //se i dati del datagridview sono meno sono state eliminate righe
                {//cicla tutti i dati del datagridview
                    for (i = 0; i < data.Count; i++)
                    {//se i dati non chiave primaria sono diversi
                        if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].mese == data[i].mese))
                        {//preleva le chiavi primarie da ambo le liste

                            if (listdata[i].id_mantenimento < data[i].id_mantenimento)//se la chiave primaria del DB è inferiore a quella datagridview
                            {//allora è stata eliminata una riga, quindi eliminala dal DB
                                command.CommandText = $"DELETE FROM versamenti_mantenimento WHERE id_mantenimento={listdata[i].id_mantenimento}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                                listdata.RemoveAt(i);//rimuovila anche dalla lista

                            }
                            else
                            {//altrimenti aggiorna la voce modificata
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"UPDATE versamenti_mantenimento SET causale='{data[i].causale}',importo={import},mese='{data[i].mese}' WHERE id_mantenimento={data[i].id_mantenimento}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }

                        }
                    }
                    //cicla ed elimina da DB le voci eliminate da DataGridView
                    for (i = data.Count; i < listdata.Count; i++)
                    {
                        command.CommandText = $"DELETE FROM versamenti_mantenimento WHERE id_mantenimento={listdata[i].id_mantenimento}";
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                    execute = true;
                    return execute;
                }
                //scarica gli oggetti e imposta a true il valore di ritorno
                command.Dispose();
                connection.Close();
                execute = true;

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisco true se non genero alcuna eccezione
            return execute;

        }

        /// <summary>
        /// Metodo per il caricamento del saldo annuale
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <returns>Ritorna il valore di saldo</returns>
        public double loadBalanceYear(int year)
        {

            ReadErrorXml xml = new ReadErrorXml();
            double balance = 0;
            try
            {   //connessione + mapping
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM totale_annuo_mantenimento WHERE anno={year};";
                var reader = connecting.reader(command, query);
                //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                //invocare il metodo read()
                if(reader.Read()) balance = reader.GetDouble(1);

                //scarico le risorse
                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            return balance;
        }

        /// <summary>
        /// Metodo per il salvataggio del saldo annuale, polimorfismo del metodo di ModelDataSY
        /// </summary>
        /// <param name="balance">Valore di saldo da inserire nel DB</param>
        /// <param name="year">Anno per update</param>
        /// <param name="tab">Tabella del DB per update</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveBalanceYear(double balance, int year, string tab)
        {
            bool save = false;
            ReadErrorXml xml = new ReadErrorXml();
            try
            {//aggiorno il valore del saldo finale già generato alla creazione dell'anno
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"UPDATE " + tab + $" SET totale_mantenimento={balance} WHERE anno={year};".Replace(",", ".");
                command.CommandText = query;

                //verifico ci sia stato l'inserimento e restituisco true
                if (command.ExecuteNonQuery() > 0)
                {
                    save = true;
                }

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

            return save;
        }

        /// <summary>
        /// Metodo per la modifica di una sola riga della tabella, polimorfismo del metodo di ModelDataSY
        /// </summary>
        /// <param name="id">Campo PK</param>
        /// <param name="year">Anno per l'update</param>
        /// <param name="cause">Campo causale</param>
        /// <param name="import">Campo importo</param>
        /// <param name="month">Campo mese</param>
        /// <param name="tab">Tabella del DB per l'update</param>
        /// <returns>Ritorna true se modifica ok</returns>
        public bool modifyRow(int id, int year, string cause, string import, string month, string tab)
        {

            //polimorfismo del motodo di Spese Annuali
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;

            try
            {   //mapping su tabella DB passata come metodo
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                command.CommandText = $"UPDATE {tab} SET causale='{cause}', importo={import},mese='{month}' WHERE id_mantenimento={id} AND anno={year}";

                if (command.ExecuteNonQuery() > 0)
                {
                    execute = true;
                }
                command.Dispose();

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisco true se non genero alcuna eccezione
            return execute;

        }

    }
}
