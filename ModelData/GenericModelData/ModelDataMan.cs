using Connection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using ReadXML;
using System.Drawing;
using System.IO;
using System.Data;

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
        public ModelDataMan()
        {
            if (testEnvironment) node_connect = "strconnect_test";
            else node_connect = "strconnect";
        }

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
        /// Metodo pe popolare la tabella
        /// </summary>
        /// <param name="r">ADT</param>
        /// <param name="t">Tabella</param>
        public void populate(Payment r, DataTable t)
        {
            DataRow row = t.NewRow();
            row["ID"] = r.id_mantenimento;
            row["CAUSALE DEL MOVIMENTO"] = r.causale;
            row["IMPORTO"] = r.importo;
            row["MESE"] = r.mese;
            t.Rows.Add(row);
            t.AcceptChanges();
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
            stringConnection = readxml.readNode(node_connect);
            Connecting connect = new Connecting(stringConnection);
            //gestione immagini albero
            ImageList imageList = new ImageList();
            string icons = "Ordina_dx.png";

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
                stringConnection = readerxml.readNode(node_connect);
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
        /// Metodo per popolare un DataTable con mapping da Db
        /// </summary>
        /// <param name="year">Anno selezionato</param>
        /// <param name="table">Tabella da popolare</param>
        public void getAll(int year, DataTable table)
        {
            ReadErrorXml xml = new ReadErrorXml();
            Payment record = new Payment();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM versamenti_mantenimento WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    record.id_mantenimento = reader.GetInt32("id_mantenimento");
                    record.causale = reader.GetString("causale");
                    record.importo = reader.GetDouble("importo");
                    record.mese = reader.GetString("mese");
                    populate(record, table);
                }

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

        }

        /// <summary>
        /// Metodo per l'inserimento di un record nella tabella Mantenimento
        /// </summary>
        /// <param name="year">Anno selezionato</param>
        /// <param name="record">Record da inserire</param>
        /// <returns></returns>
        public bool insert(int year, Payment record)
        {
            bool insert = false;

            ReadErrorXml xml = new ReadErrorXml();
            try
            {
                //Inserisce il record nella tabella postpay
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string import = record.importo.ToString().Replace(',', '.');
                string query = $"INSERT INTO versamenti_mantenimento(id_mantenimento,causale,importo,mese,anno) " +
                    $"VALUES({record.id_mantenimento},'{record.causale}',{import},'{record.mese}',{year});";
                command.CommandText = query;

                //Verifica ci sia stato l'inserimento e restituisce true
                if (command.ExecuteNonQuery() > 0) insert = true;

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //Ritorna il risultato dell'inserimento
            return insert;
        }

        /// <summary>
        /// Metodo per eliminare un record del DB
        /// </summary>
        /// <param name="year">Anno selezionato</param>
        /// <param name="record">Record da eliminare</param>
        /// <returns>Ritorna true se delete corretto</returns>
        public bool deleteRow(int year, Payment record)
        {
            bool delete = false;

            ReadErrorXml xml = new ReadErrorXml();
            try
            {
                //Inserisce il record nella tabella postpay
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string import = record.importo.ToString().Replace(',', '.');
                string query = $"DELETE FROM versamenti_mantenimento WHERE id_mantenimento={record.id_mantenimento} AND anno={year};";
                command.CommandText = query;

                //Verifica ci sia stato l'inserimento e restituisce true
                if (command.ExecuteNonQuery() > 0) delete = true;

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //Ritorna il risultato dell'eliminazione
            return delete;
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
                stringConnection = readerxml.readNode(node_connect);
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
                stringConnection = readerxml.readNode(node_connect);
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
                stringConnection = readerxml.readNode(node_connect);
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
