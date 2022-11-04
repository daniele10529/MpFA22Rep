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
    /// Classe per la gestione dati verso il DB di Libretto
    /// </summary>
    public class ModelDataLibNom : ModelDataSY
    {
        /// <summary>
        /// Classe per la gestione dati verso il DB di Libretto, eredita ModelDataSY
        /// </summary>
        public ModelDataLibNom()
        {
            if (testEnvironment) node_connect = "strconnect_test";
            else node_connect = "strconnect";
        }

        /// <summary>
        /// Struttura dati per Libretto
        /// </summary>
        public struct PaymentLibNom
        {
            public int id_libretto;//PK
            public string causale;//causale movimento
            public double importo;//importo versato
            public int id_mese;//mese in formato stringa
        }

        /// <summary>
        /// Metodo per caricare l'albero con solo l'anno
        /// polimorfismo di ModelDataSY.loadTree
        /// </summary>
        /// <param name="tree">TreeView in cui caricare gli anni</param>
        /// <param name="onlyYear">Seleziona solo anno = true</param>
        public void loadTree(TreeView tree, bool onlyYear)
        {
            //verifico se caricare solo l'anno onlyYear = true
            if (!(onlyYear == true)) return;

            //Istanze classi per la lettura da file XML
            ReadErrorXml xml = new ReadErrorXml();
            ReaderXML readerxml = new ReaderXML(pathconn, "string");
            stringConnection = readerxml.readNode(node_connect);
            //Istanza classe connessione e assegnazione icone
            Connecting connecting = new Connecting(stringConnection);
            ImageList imagelist = new ImageList();
            string icons = "Ordina_dx.png";

            try
            {
                //carico le immagini e le aggiungo alla lista
                string ico = pathIco + icons;
                imagelist.Images.Add(Image.FromFile(ico));
                //assegno la lista all'albero
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
                //scarico le risorse
                reader.Dispose();
                command.Dispose();
                connection.Close();

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
        /// Metodo per caricare i dati del libretto nominale da DB
        /// </summary>
        /// <param name="year">Anno per mapping su DB</param>
        /// <returns>Ritorna una list(PaymentLibNom) di dati</returns>
        public List<PaymentLibNom> loadDataLib(int year)
        {
            List<PaymentLibNom> listdata = new List<PaymentLibNom>();
            PaymentLibNom payment;
            ReadErrorXml xml = new ReadErrorXml();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM libretto_postale WHERE anno={year}";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_libretto = reader.GetInt32(0);
                    payment.causale = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    payment.id_mese = reader.GetInt32(3);
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
            return listdata;

        }

        /// <summary>
        /// Metodo per caricare il saldo dell'anno precedente
        /// </summary>
        /// <param name="year">Anno per mapping su DB</param>
        /// <returns>Ritorno il saldo dell'anno precedente</returns>
        public double balanceYearPre(int year)
        {
            ReaderXML readerxml;
            double balancePre = 0;

            //se il primo anno 2019, imposta il valore di partenza
            if (year == 2019)
            {
                readerxml = new ReaderXML(pathSetIni, fatherIni);
                balancePre = Double.Parse(readerxml.readNode("tot_lib"));
            }
            else
            {

                year -= 1;
                ReadErrorXml xml = new ReadErrorXml();

                try
                {
                    readerxml = new ReaderXML(pathconn, "string");
                    stringConnection = readerxml.readNode(node_connect);
                    Connecting connecting = new Connecting(stringConnection);
                    var connection = connecting.connection();
                    var command = connecting.command(connection);
                    string query = $"SELECT * FROM totale_libretto WHERE anno={year};";
                    var reader = connecting.reader(command, query);
                    //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                    //invocare il metodo read()
                    if(reader.Read()) balancePre = reader.GetDouble(1);

                    reader.Dispose();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    xml.manageError(9, path, father, featur);
                }
            }
            //ritorna il saldo anno precedente
            return balancePre;
        }

        /// <summary>
        /// Metodo di salvataggio dei dati Del modulo Libretto
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="data">List(PaymentLibNom) di dati da salvare nel DB</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveDataLib(int year, List<PaymentLibNom> data)
        {
            ReadErrorXml xml = new ReadErrorXml();
            List<PaymentLibNom> listdata = new List<PaymentLibNom>();
            PaymentLibNom payment;
            bool execute = false;
            int i;
            string import;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);

                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM libretto_postale WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_libretto = reader.GetInt32(0);
                    payment.causale = reader.GetString(1);
                    payment.importo = reader.GetDouble(2);
                    payment.id_mese = reader.GetInt32(3);
                    listdata.Add(payment);
                }
                reader.Dispose();
                //Algoritmo commentato nel saveDataSY
                if (data.Count >= listdata.Count)
                {
                    for (i = 0; i < data.Count; i++)
                    {
                        if (i >= listdata.Count)
                        {
                            for (i = listdata.Count; i < data.Count; i++)
                            {
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"INSERT INTO libretto_postale(id_libretto,causale,importo,anno,id_mese) VALUES({data[i].id_libretto},'{data[i].causale}',{import},{year},{data[i].id_mese});";
                                command.ExecuteNonQuery();
                            }
                            break;
                        }
                        else if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].id_mese == data[i].id_mese))
                        {
                            import = data[i].importo.ToString().Replace(',', '.');
                            command.CommandText = $"UPDATE libretto_postale SET causale='{data[i].causale}',importo={import},id_mese={data[i].id_mese} WHERE id_libretto={data[i].id_libretto}";
                            command.ExecuteNonQuery();
                            command.Dispose();
                            if (i == (data.Count - 1) && data.Count == listdata.Count)
                            {
                                connection.Close();
                                execute = true;
                                return execute;
                            }
                        }
                    }
                }
                else
                {
                    for (i = 0; i < data.Count; i++)
                    {
                        if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].importo == data[i].importo))
                        {
                            if (listdata[i].id_libretto < data[i].id_libretto)
                            {
                                command.CommandText = $"DELETE FROM libretto_postale WHERE id_libretto={listdata[i].id_libretto}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                                listdata.RemoveAt(i);
                            }
                            else
                            {
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"UPDATE libretto_postale SET causale='{data[i].causale}',importo={import},id_mese={data[i].id_mese} WHERE id_libretto={data[i].id_libretto}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }

                        }
                    }
                    for (i = data.Count; i < listdata.Count; i++)
                    {
                        command.CommandText = $"DELETE FROM libretto_postale WHERE id_libretto={listdata[i].id_libretto}";
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
        /// Metodo per il salvataggio del saldo annuale libretto
        /// </summary>
        /// <param name="balance">Saldo da salvare sul DB</param>
        /// <param name="year">Anno per il mapping su DB</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveBalanceYear(double balance, int year)
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
                string query = $"UPDATE totale_libretto SET tot_libretto={balance} WHERE anno = {year};".Replace(",", ".");
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
        /// Moetodo per caricare il saldo annuo di Libretto Nominale
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <returns>Restituisce il saldo annuo</returns>
        public double loadBalanceLib(int year)
        {
            ReadErrorXml xml = new ReadErrorXml();
            double balance = 0;
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM totale_libretto WHERE anno={year};";
                var reader = connecting.reader(command, query);
                //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                //invocare il metodo read()
                if(reader.Read()) balance = reader.GetDouble(1);

                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //restituisce il saldo annuo
            return balance;
        }

        /// <summary>
        /// Metodo per la modifica di una solo riga
        /// </summary>
        /// <param name="id">Campo PK</param>
        /// <param name="year">Campo FK per la modifica</param>
        /// <param name="cause">Campo causale</param>
        /// <param name="import">Campo importo</param>
        /// <param name="id_month">Campo mese</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool modifyRow(int id, int year, string cause, string import, int id_month)
        {
            //polimorfismo del motodo di Spese Annuali
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode(node_connect);
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                command.CommandText = $"UPDATE libretto_postale SET causale='{cause}', importo = {import},id_mese = {id_month} WHERE id_libretto = {id} AND anno = {year}";

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
