using Connection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using ReadXML;
using System.Drawing;
using System.IO;

/// <summary>
/// API per la gestione dati software -> DB
/// </summary>
namespace GenericModelData
{

    /// <summary>
    /// Classe per la gestione dati verso il DB di SpeseAnnuali
    /// </summary>
    public class ModelDataSY
    {
        //SslMode = none è necessario per evitare l'errore : localhost non support SSL mode.
        // = "server=localhost;user id=root;database=mpfa20;port=3308;SslMode=none";
        //stringa di connessione prelevata da file xml
        protected string stringConnection;
        protected const string pathconn = @"C:\MpFA22\StrConnect\strConnect.xml";
        protected const string path = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
        protected const string pathIco = @"C:\MpFA22\Icons\";
        protected const string father = "ListError";
        protected const string featur = "ErrorTitle";
        protected const string pathSetIni = @"C:\MpFA22\SetIni\SetIni.xml";
        protected const string fatherIni = "setIni";

        /// <summary>
        /// Classe per la gestione dati verso il DB di SpeseAnnuali
        /// </summary>
        public ModelDataSY() { }

        /// <summary>
        /// Struttura dati SpeseAnnuali
        /// </summary>
        public struct PaymentSY
        {
            public int id_tupla_mese;
            public string voce_spesa;
            public double importo;
        }

        /// <summary>
        /// Metodo per ricavare il valore di PK 
        /// </summary>
        /// <param name="tab">Tabella da cui ricavare la PK</param>
        /// <param name="field">Campo definito PK</param>
        /// <returns>Ritorna il valore della PK</returns>
        public int primaryKey(string tab, string field)
        {
            ReadErrorXml xml = new ReadErrorXml();
            int pk = 0;
            try
            {   //connessione + mapping
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT MAX({field}) FROM {tab};";
                var reader = connecting.reader(command, query);

                //acquisisco il valore di PK da DB, se la tabella è vuota restituisce 0
                //valore incrementato di 1 dal chiamante
                if (reader.Read() == true && reader.IsDBNull(0) == false) pk = reader.GetInt32(0);

                //scarico gli oggetti
                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisco il valore di PK
            return pk;
        }

        /// <summary>
        /// Metodo per popolare il TreeView con gli anni e mesi prelevati dal DB
        /// </summary>
        /// <param name="tree">TreeView in cui caricare i nodi</param>
        public void loadTree(TreeView tree)
        {
            //Istanze classi per la lettura da file XML
            ReadErrorXml xml = new ReadErrorXml();
            ReaderXML readerxml = new ReaderXML(pathconn, "string");
            stringConnection = readerxml.readNode("strconnect");
            //Istanza classe connessione e assegnazione icone
            Connecting connecting = new Connecting(stringConnection);
            ImageList imagelist = new ImageList();
            int n = 0;
            string[] mesi = { "Gennaio", "Febbraio" , "Marzo" , "Aprile" , "Maggio" , "Giugno" , "Luglio"
            , "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"};
            string[] icons = { "Conto Corrente.png", "Spese Annuali.png" };

            try
            {
                //carica le immagini e le aggiunge alla lista
                string ico = pathIco + icons[0];
                imagelist.Images.Add(Image.FromFile(ico));
                ico = pathIco + icons[1];
                imagelist.Images.Add(Image.FromFile(ico));
                //assegna la lista all'albero
                tree.ImageList = imagelist;
                //connessione al DB e query
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = "SELECT * FROM anni";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    tree.Nodes[0].Nodes.Add(reader.GetString(0));
                    tree.Nodes[0].ImageIndex = 0;
                }

                //Scarica le risorse
                reader.Dispose();
                command.Dispose();
                connection.Close();

                for (n = 0; n < tree.Nodes[0].Nodes.Count; n++)
                {
                    for (int i = 0; i < mesi.Length; i++)
                    {
                        tree.Nodes[0].Nodes[n].Nodes.Add(mesi[i]);
                        tree.Nodes[0].Nodes[n].ImageIndex = 1;
                    }
                }
                
            }
            catch (FileNotFoundException ex)
            {
                xml.manageError(5, path, father, featur);
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

        }

        /// <summary>
        /// Metodo per la generazione di un nuovo anno gestionale
        /// </summary>
        /// <param name="tree">TreeView in cui caricare i nodi</param>
        public void insertYear(TreeView tree)
        {
            ReadErrorXml xml = new ReadErrorXml();
            int anno, i;
            string string_anno;
            try
            {
                if (tree.Nodes[0].Nodes.Count == 0)
                {
                    anno = 2019;
                }
                else
                {
                    string_anno = tree.Nodes[0].LastNode.Text;
                    anno = Int32.Parse(string_anno) + 1;
                }
                //Connessione e genera in ogni tabella il valore dell'anno e del mese creato
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);

                //non è possibile accorporare i comandi di inserimento, altrimenti si generano errori
                //sulle FK.
                //è obbligatorio lasciare inalterata la disposizione dei comandi

                var connection = connecting.connection();
                var command = connecting.command(connection);
                command.Parameters.AddWithValue("@anno", anno);
                command.CommandText = "INSERT INTO anni values(@anno);";
                command.ExecuteNonQuery();
                command.Dispose();

                //genero in ogni tabella riassuntiva i mesi dell'anno creato, in modo da utilizzare
                //solo l'update per i valori di resoconto.
                //su DB i valori hanno default a 0
                for (i = 1; i <= 12; i++)
                {
                    //$ necessario per inserire la variabile nella stringa che va introdotta tra graffe
                    command.CommandText = $"INSERT INTO resoconto_mensile(anno,id_mese) VALUES({anno},{i});";
                    command.ExecuteNonQuery();
                    command.Dispose();
                    command.CommandText = $"INSERT INTO totale_mese_cc(anno,id_mese) VALUES({anno},{i});";
                    command.ExecuteNonQuery();
                    command.Dispose();

                }
                //genero l'anno per il totale annuo libretto e postpay
                command.CommandText = $"INSERT INTO totale_libretto(anno) VALUES({anno});";
                command.ExecuteNonQuery();
                command.Dispose();
                command.CommandText = $"INSERT INTO totale_postpay(anno) VALUES({anno});";
                command.ExecuteNonQuery();
                command.Dispose();

                //genero l'anno per il resoconto annuale
                command = connecting.command(connection);
                command.Parameters.AddWithValue("@anno", anno);
                command.CommandText = "INSERT INTO resoconto_annuale(anno) values(@anno);";
                command.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
                tree.Nodes[0].Nodes.Clear();
                loadTree(tree);

            }
            catch (Exception ex)
            {
                xml.manageError(11, path, father, featur);
            }

        }

        /// <summary>
        /// Metodo per caricare i dati da DB e associerli a una lista
        /// </summary>
        /// <param name="mese">Mese selezionato</param>
        /// <param name="year">Anno per mapping</param>
        /// <returns>Ritorna una list(PaymentSY) di dati</returns>
        public List<PaymentSY> loadDataSY(string mese, int year)
        {
            List<PaymentSY> listdata = new List<PaymentSY>();
            PaymentSY payment;
            ReadErrorXml xml = new ReadErrorXml();

            try
            {
                //carico i dati da DB in base al mese selezionato e li assegno alla lista
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM {mese} WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_tupla_mese = reader.GetInt32(0);
                    payment.voce_spesa = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    listdata.Add(payment);
                }
                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //Ritorna i dati in lista
            return listdata;

        }

        /// <summary>
        /// Metodo per aggiornare il totale spese mensili
        /// </summary>
        /// <param name="year">Anno per update</param>
        /// <param name="month">Mese per update</param>
        /// <param name="total">Totale spese mensili da aggiornare in DB</param>
        public void updateTotSpend(int year, int month, double total)
        {
            ReadErrorXml xml = new ReadErrorXml();
            try
            {
                //esegue l'update del valore già creato alla generazione di un nuovo anno
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                command.CommandText = $"UPDATE resoconto_mensile SET totale_spese_mese={total} WHERE anno={year} AND id_mese={month};".Replace(',', '.');
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
        }

        /// <summary>
        /// Metodo per salvare i dati nel DB
        /// </summary>
        /// <param name="mese">Mese seleziionato</param>
        /// <param name="year">Anno per mapping</param>
        /// <param name="month">Mese per mapping</param>
        /// <param name="data">List(PaymentSY) con i dati da salvare</param>
        /// <returns>Restituisce true se inserimento ok </returns>
        public bool saveDataSY(string mese, int year, List<PaymentSY> data)
        {
            ReadErrorXml xml = new ReadErrorXml();
            //Lista caricata da DB, valori già presenti
            List<PaymentSY> listdata = new List<PaymentSY>();
            PaymentSY payment;
            bool execute = false;
            int i;
            string import;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);

                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM {mese} WHERE anno={year};";
                var reader = connecting.reader(command, query);
                //Legge i dati presenti su DB
                while (reader.Read())
                {
                    payment.id_tupla_mese = reader.GetInt32(0);
                    payment.voce_spesa = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    listdata.Add(payment);
                }
                reader.Dispose();
                //Algoritmo di confronto tra i dati manipolati in DataGridView e i dati presenti nel DB
                //Se la lista da DataGridView è piu lunga
                if (data.Count >= listdata.Count)
                {//inserisci tutti i nuovi dati
                    for (i = 0; i < data.Count; i++)
                    {//inserisci solo le nuove righe aggiunte
                        if (i >= listdata.Count)
                        {
                            for (i = listdata.Count; i < data.Count; i++)
                            {
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"INSERT INTO {mese}(id_{mese},voce_spesa,importo,anno) VALUES({data[i].id_tupla_mese},'{data[i].voce_spesa}',{import},{year});";
                                command.ExecuteNonQuery();
                            }
                            break;
                        }//se sono state modificate le righe, aggiorna i valori
                        else if (!(listdata[i].voce_spesa == data[i].voce_spesa) || !(listdata[i].importo == data[i].importo))
                        {
                            import = data[i].importo.ToString().Replace(',', '.');
                            command.CommandText = $"UPDATE {mese} SET voce_spesa='{data[i].voce_spesa}',importo={import} WHERE id_{mese}={data[i].id_tupla_mese}";
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
                else //se i dati del DataGridView sono meno, allora sono state eliminate righe
                {//cicla tutti i dati del DataGridView
                    for (i = 0; i < data.Count; i++)
                    {//se i dati non chiave primaria sono diversi
                        if (!(listdata[i].voce_spesa == data[i].voce_spesa) || !(listdata[i].importo == data[i].importo))
                        {//preleva le chiavi primarie da ambo le liste
                            
                            if (listdata[i].id_tupla_mese < data[i].id_tupla_mese)//se la chiave primaria del DB è inferiore alla a quella DataGridView
                            {//allora è stata eliminata una riga, quindi eliminala dal DB
                                command.CommandText = $"DELETE FROM {mese} WHERE id_{mese}={listdata[i].id_tupla_mese}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                                listdata.RemoveAt(i);//rimuovila anche dalla lista

                            }
                            else
                            {//altrimenti aggiorna la voce modificata
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"UPDATE {mese} SET voce_spesa='{data[i].voce_spesa}',importo={import} WHERE id_{mese}={data[i].id_tupla_mese}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }

                        }
                    }
                    //cicla ed elimina le voci aggiuntive
                    for (i = data.Count; i < listdata.Count; i++)
                    {
                        command.CommandText = $"DELETE FROM {mese} WHERE id_{mese}={listdata[i].id_tupla_mese}";
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                    execute = true;
                    return execute;
                }

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
        /// Metodo per modificare una solo riga delle spese mensili
        /// </summary>
        /// <param name="id">Campo PK</param>
        /// <param name="cause">Campo causale</param>
        /// <param name="import">Campo importo</param>
        /// <param name="year">Anno per update</param>
        /// <param name="month">Mese per update</param>
        /// <param name="id_month">Campo FK, selezione mese da modificare</param>
        /// <returns>Restituisce true se modifica ok</returns>
        public bool modifyRow(int id, string cause, string import, int year, string month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                command.CommandText = $"UPDATE {month} SET voce_spesa = '{cause}', importo = {import.Replace(',', '.')} WHERE id_{month} = {id} AND anno = {year}";

                if(command.ExecuteNonQuery() > 0)
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

        /// <summary>
        /// Metodo per salvare il valore da TextBox dello stipendio nel DB
        /// </summary>
        /// <param name="pay">Campo stipendio</param>
        /// <param name="payadd">Campo entrata aggiuntiva</param>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Restituisce true se inserimento ok</returns>
        public bool savePay(double pay, double payadd, int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;
            string pays, payadds;
            double dbPay = 0, dbPayadd = 0;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //ricava i valori di stipendio e ricavo aggiuntivo
                //se il valore è stato modificato salvalo nel DB
                string query = $"SELECT stipendio,ricavo_extra FROM resoconto_mensile WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    dbPay = reader.GetDouble(0);
                    dbPayadd = reader.GetDouble(1);
                }
                reader.Dispose();

                if (!(dbPay == pay) || dbPay == 0 && !(pay == 0))
                {
                    pays = pay.ToString().Replace(',', '.');
                    command.CommandText = $"UPDATE resoconto_mensile SET stipendio={pays} WHERE anno={year} AND id_mese={month};";
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

                if (!(dbPayadd == payadd) || dbPayadd == 0 && !(payadd == 0))
                {
                    payadds = payadd.ToString().Replace(',', '.');
                    reader.Dispose();
                    command.CommandText = $"UPDATE resoconto_mensile SET ricavo_extra={payadds} WHERE anno={year} AND id_mese={month};";
                    command.ExecuteNonQuery();
                }

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
        /// Metodo per caricare lo stipendio da DB
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Restituisce il valore dello  stipendio</returns>
        public double loadPay(int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            double pay = 0;
            try
            {
                //Connessione al DB
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //la query restituisce una sola riga
                string query = $"SELECT * FROM resoconto_mensile WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);

                //Se ha letto un valore assegna il campo stipendio alla variabile pay
                if(reader.Read()) pay = reader.GetDouble(0);

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisce lo stipendio
            return pay;
        }

        /// <summary>
        /// Metodo per caricare il valore di ricavo extra mensile
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Ritorna il valore delle entrate extra mese</returns>
        public double loadPayAdd(int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            double pay = 0;
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //la query restituisce una sola riga
                string query = $"SELECT * FROM resoconto_mensile WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);
                
                //Se ha letto un valore assegna il campo stipendio alla variabile pay
                if (reader.Read()) pay = reader.GetDouble(3);

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisce il ricavo aggiuntivo
            return pay;
        }

        /// <summary>
        /// Metodo per salvare nel DB la voce contanti
        /// </summary>
        /// <param name="money">Campo contanti</param>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Restituisce true se update ok</returns>
        public bool saveMoney(double money, int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;
            double dbMoney = 0;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                
                //Ricava il valore dei contanti
                //se il valore è stato modificato salvalo nel DB
                string query = $"SELECT contanti FROM resoconto_mensile WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);

                if (reader.Read()) dbMoney = reader.GetDouble(0);
                reader.Dispose();

                if (!(dbMoney == money) || dbMoney == 0 && !(money == 0))
                {
                    command.CommandText = $"UPDATE resoconto_mensile SET contanti={money} WHERE anno={year} AND id_mese={month};".Replace(",",".");
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

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
        /// Metodo per caricare i contanti da DB
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Restituisce il valore dei contanti</returns>
        public double loadMoney(int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            double money = 0;
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                string query = $"SELECT * FROM resoconto_mensile WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);

                if (reader.Read()) money = reader.GetDouble(1);

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisce il valore dei contanti
            return money;
        }

        /// <summary>
        /// Mapping su tot cc,libretto,pp,contanti per totale mese precedente all'attuale
        /// utilizzato dal conteggio di contabilità
        /// </summary>
        /// <param name="year">Anno er il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Restituisce il totale mese precedente</returns>
        public double countMonthPre(int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            ReaderXML xmlValIni = new ReaderXML(@"C:\MpFA20\SetIni\SetIni.xml", "setIni");
            double totLib = 0, totCC = 0, totPP = 0, contanti = 0, totMesePre = 0;
            double inipp = Double.Parse(xmlValIni.readNode("tot_pp"));
            double inilib = Double.Parse(xmlValIni.readNode("tot_lib"));

            if (month == 1)
            {
                year = year - 1;
                month = 12;
            }
            else
            {
                month = month - 1;
            }

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connetting = new Connecting(stringConnection);
                var connection = connetting.connection();
                var command = connetting.command(connection);

                //query per totale mese precedente su conto corrente
                string query = $"SELECT totale_mese_cc as totcc FROM totale_mese_cc WHERE anno = {year} AND id_mese = {month};";
                var reader = connetting.reader(command, query);
                if (reader.Read()) totCC = reader.GetDouble(0);
                reader.Dispose();
                
                //query per contanti mese precedente su resoconto mensile
                query = $"SELECT contanti FROM resoconto_mensile WHERE anno = {year} AND id_mese = {month};";
                reader = connetting.reader(command, query);
                if (reader.Read())  contanti = reader.GetDouble(0);
                reader.Dispose();
                
                //query per il totale dei movimenti mese precedente su postpay
                query = $"SELECT sum(importo) FROM postpay WHERE anno = {year} AND id_mese <= {month};";
                reader = connetting.reader(command, query);
                if (reader.Read())
                {//se non c'è valore null in restituzione da DB assegna il valore alla variabile
                    if (reader.IsDBNull(0) == false) totPP = reader.GetDouble(0);
                    else totPP = 0;
                }
                reader.Dispose();
                
                //query per il totale dei movimenti mese precedente su libretto
                query = $"SELECT sum(importo) FROM libretto_postale WHERE anno = {year} AND id_mese <= {month};";
                reader = connetting.reader(command, query);
                if (reader.Read())
                {//se non c'è valore null in restituzione da DB assegna il valore alla variabile
                    if (reader.IsDBNull(0) == false) totLib = reader.GetDouble(0);
                    else totLib = 0;
                }
                reader.Dispose();

                //se l'anno è superiore al 2019 e il mese è febbraio, dovrò prendere come 
                //valori iniziali il saldo dell'anno precendente di libretto e postpay
                //dato che sono gestiti annualmente.
                //non importa per il conto corrente dato che è gestito a saldo mensile
                //da verificare all'inserimento del 2020
                if(year > 2019 && (month + 1) > 1)
                {
                    query = $"SELECT tot_libretto, tot_postpay FROM totale_libretto,totale_postpay " +
                        $"WHERE totale_libretto.anno = {year - 1} AND totale_postpay.anno = {year - 1}";
                    reader = connetting.reader(command, query);
                    if (reader.Read())
                    {
                        inilib = reader.GetDouble(0);
                        inipp = reader.GetDouble(1);
                    }
                    reader.Dispose();
                }

                totMesePre = totCC + (totLib + inilib) + (totPP + inipp) + contanti;
              
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisce il totale mese precedente
            return totMesePre;
        }

        /// <summary>
        /// Metodo per la lettura del totale spese annuali e del totale ricavi annuali
        /// </summary>
        /// <param name="year">anno selezionato per DB</param>
        /// <param name="totSpend">TextBox tot spese annuali</param>
        /// <param name="totRich">TextBox tot ricavi annuali</param>
        public void loadTotRichSpendYear(int year, TextBox totSpend, TextBox totRich)
        {
            ReadErrorXml xml = new ReadErrorXml();
            totSpend.Clear();
            totRich.Clear();
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connetting = new Connecting(stringConnection);
                var connection = connetting.connection();
                var command = connetting.command(connection);
                string query = $"SELECT * FROM resoconto_annuale WHERE anno = {year}";

                var reader = connetting.reader(command, query);
                while (reader.Read())
                {
                    totSpend.Text = reader.GetDouble(0).ToString() + " €";
                    totRich.Text = reader.GetDouble(1).ToString() + " €";
                    
                }
                command.Dispose();
                reader.Dispose();
                connection.Dispose();

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
          
        }

        /// <summary>
        /// Metodo per aggiornare il totale spese annuali e il totale ricavi annuali
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        public void updateTotYears(int year)
        {
            ReadErrorXml xml = new ReadErrorXml();
            
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connetting = new Connecting(stringConnection);
                var connection = connetting.connection();
                var command = connetting.command(connection);
                //eseguo le somme dei valori direttamente nel DB
                string query = $"UPDATE resoconto_annuale SET totale_spese_anno = " +
                    $"(SELECT SUM(totale_spese_mese) FROM resoconto_mensile WHERE anno = {year} " +
                    $"GROUP BY anno), " +
                    $"totale_ricavi_anno =" +
                    $"(SELECT SUM(stipendio) + SUM(ricavo_extra) FROM resoconto_mensile WHERE anno = {year} " +
                    $"GROUP BY anno) " +
                    $"WHERE anno = {year};";

                command.CommandText = query;
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Dispose();

            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
        }


    }

}  


