using Connection;
using ReadXML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericModelData
{
    /// <summary>
    /// Classe per la gestione dati verso il DB di PostPay
    /// </summary>
    public class ModelDataPostPay : ModelDataLibNom
    {
        public struct RecordPostPay
        {
            public int id_postpay;//PK
            public string causale;//causale movimento
            public double importo;//importo versato
            public int id_mese;//mese in formato stringa
            public int anno;
        }

        /// <summary>
        /// Classe per la gestione dati verso il DB di PostPay eredita da ModelDataLibNom
        /// </summary>
        public ModelDataPostPay() { }

        //Attributi
        public const int MAXROW = 20;
        private int currentPage;
        private int pages;
        private int numberRows;
        private int minRow;

        //Getter Setter
        /// <summary>
        /// Pagina corrente per la paginazione della tabella
        /// </summary>
        public int CurrentPage { get { return currentPage; } }
        /// <summary>
        /// Numero di pagine necessarie alla paginazione
        /// </summary>
        public int Pages { get { return pages; } }


        /// <summary>
        /// Restituisce il mese in stringa in base al suo numero
        /// necessario alla visualizzazione
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string selmonth(int m)
        {
            string n = "";
            switch (m)
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

        /// <summary>
        /// Metodo pe popolare la tabella
        /// </summary>
        /// <param name="r">ADT</param>
        /// <param name="t">Tabella</param>
        private void populate(RecordPostPay r, DataTable t)
        {
            DataRow row = t.NewRow();
            row["ID"] = r.id_postpay;
            row["CAUSALE DEL MOVIMENTO"] = r.causale;
            row["IMPORTO"] = r.importo;
            row["MESE"] = selmonth(r.id_mese);
            t.Rows.Add(row);
            t.AcceptChanges();
        }

        /// <summary>
        /// Metodo per ricavare tutti i dati da PostPay in base all'anno selezionato
        /// </summary>
        /// <param name="record">ADT contenente l'anno da cui caricare i dati</param>
        /// <returns>Restituisce DataTable con tutte i dati ricavati</returns>
        public DataTable getAll(RecordPostPay record)
        {
            ReadErrorXml xml = new ReadErrorXml();
            DataTable table = new DataTable();
            double numPages = 0;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                string query = $"SELECT * FROM postpay WHERE anno={record.anno}";
                var command = connecting.command(connection, query);
                connecting.reader(command, table);
                
                if(table.Rows.Count > 0)
                {
                    //Preleva il numer odi righe dalla tabella
                    numberRows = table.Rows.Count;
                    //Calcola il numero di pagine necessarie
                    numPages = (double)numberRows / (double)MAXROW;
                    //Arrotonda la cifra all'intero
                    pages = (int)Math.Ceiling(numPages);

                }
                
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

            //Restituisce il DataTable, utilizzabile per creare il PDF e
            //definire le righe totali
            return table;

        }

        /// <summary>
        /// Metodo per mapping sul DB e binding table-grid. Pagination su prima pagina
        /// </summary>
        /// <param name="grid">DataGridView per il binding</param>
        /// <param name="table">DataTable da popolare</param>
        /// <param name="record">Record da cui prelevare l'anno selezionato</param>
        public void selectData(DataGridView grid, DataTable table, RecordPostPay record, int index = 0)
        {
            ReadErrorXml xml = new ReadErrorXml();
            RecordPostPay recordPP = new RecordPostPay();

            //Definisce l'intervallo di righe della prima pagina
            minRow = index;
            //Definisce la pagina corrente, alla prima pagina
            currentPage = (index + MAXROW) / MAXROW;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM postpay WHERE anno={record.anno} LIMIT {minRow},{MAXROW}";
                var reader = connecting.reader(command, query);

                //Ripulisce le righe della tabella
                table.Rows.Clear();

                //Legge i dati dal DB e li assegna all'ADT per popolare la tabella
                while (reader.Read())
                {
                    recordPP.id_postpay = reader.GetInt32("id_postpay");
                    recordPP.causale = reader.GetString("causale");
                    recordPP.importo = reader.GetDouble("importo");
                    recordPP.id_mese = reader.GetInt32("id_mese");
                    populate(recordPP, table);
                }

                //Binding dati
                grid.DataSource = table;

                //Scarica le risorse
                command.Dispose();
                reader.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            
        }

        /// <summary>
        /// Metodo per l'avanzamento della paginazione
        /// </summary>
        /// <param name="grid">DataGridView per il binding</param>
        /// <param name="table">DataTable da popolare</param>
        /// <param name="record">Record da cui prelevare l'anno selezionato</param>
        public void forward(DataGridView grid, DataTable table, RecordPostPay record)
        {
            //Incrementa l'intervallo minimo
            minRow = minRow + MAXROW;

            //Se il minimo delle righe è arrivato al massimo delle righe contenute esce
            if (minRow == MAXROW - 1) return;

            //Legge i nuovi dati
            ReadErrorXml xml = new ReadErrorXml();
            RecordPostPay recordPP = new RecordPostPay();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM postpay WHERE anno={record.anno} LIMIT {minRow},{MAXROW}";
                var reader = connecting.reader(command, query);

                //Ripulisce le righe della tabella
                table.Rows.Clear();

                //Legge i dati dal DB e li assegna all'ADT per popolare la tabella
                while (reader.Read())
                {
                    recordPP.id_postpay = reader.GetInt32("id_postpay");
                    recordPP.causale = reader.GetString("causale");
                    recordPP.importo = reader.GetDouble("importo");
                    recordPP.id_mese = reader.GetInt32("id_mese");
                    populate(recordPP, table);
                }

                //Incrementa la pagina corrente, alla prima pagina
                currentPage++;

                //Binding dati
                grid.DataSource = table;

                //Scarica le risorse
                command.Dispose();
                reader.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

        }

        /// <summary>
        /// Metodo per l'avanzamento della paginazione
        /// </summary>
        /// <param name="grid">DataGridView per il binding</param>
        /// <param name="table">DataTable da popolare</param>
        /// <param name="record">Record da cui prelevare l'anno selezionato</param>
        public void back(DataGridView grid, DataTable table, RecordPostPay record)
        {
            //Decrementa l'intervallo minimo
            minRow = minRow - MAXROW;

            //Se il minimo delle righe è arrivato al massimo delle righe contenute esce
            if (minRow < 0) return;

            //Legge i nuovi dati
            ReadErrorXml xml = new ReadErrorXml();
            RecordPostPay recordPP = new RecordPostPay();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM postpay WHERE anno={record.anno} LIMIT {minRow},{MAXROW}";
                var reader = connecting.reader(command, query);

                //Ripulisce le righe della tabella
                table.Rows.Clear();

                //Legge i dati dal DB e li assegna all'ADT per popolare la tabella
                while (reader.Read())
                {
                    recordPP.id_postpay = reader.GetInt32("id_postpay");
                    recordPP.causale = reader.GetString("causale");
                    recordPP.importo = reader.GetDouble("importo");
                    recordPP.id_mese = reader.GetInt32("id_mese");
                    populate(recordPP, table);
                }

                //Incrementa la pagina corrente, alla prima pagina
                currentPage--;

                //Binding dati
                grid.DataSource = table;

                //Scarica le risorse
                command.Dispose();
                reader.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }

        }

        /// <summary>
        ///  Metodo per caricare il saldo anno precedente PP
        /// </summary>
        /// <param name="record">ADT da cui ricavare l'anno caricato</param>
        /// <returns>Ritorna il saldo dell'anno precedente</returns>
        public double getBalanceYearPrev(RecordPostPay record)
        {
           
            ReaderXML readerxml;
            double balancePre = 0;
            //se il primo anno 2019, imposta il valore di partenza
            if (record.anno == 2019)
            {
                readerxml = new ReaderXML(pathSetIni, fatherIni);
                balancePre = Double.Parse(readerxml.readNode("tot_pp"));
            }
            else
            {

                record.anno -= 1;
                ReadErrorXml xml = new ReadErrorXml();

                try
                {
                    readerxml = new ReaderXML(pathconn, "string");
                    stringConnection = readerxml.readNode("strconnect");
                    Connecting connecting = new Connecting(stringConnection);
                    var connection = connecting.connection();
                    var command = connecting.command(connection);
                    string query = $"SELECT * FROM totale_postpay WHERE anno={record.anno};";
                    var reader = connecting.reader(command, query);
                    //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                    //invocare il metodo read()
                    if (reader.Read()) balancePre = reader.GetDouble(1);

                    reader.Dispose();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    xml.manageError(9, path, father, featur);
                }
            }
            //ritorna il valore di saldo anno precedente
            return balancePre;
        }

        /// <summary>
        ///  Metodo per il salvataggio del saldo annuale di PP
        /// </summary>
        /// <param name="balance">Saldo da salvare</param>
        /// <param name="record">ADT per l'anno selezionato</param>
        /// <returns>Ritorna true se insert ok</returns>
        public bool saveBalanceYear(double balance, RecordPostPay record)
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
                string query = $"UPDATE totale_postpay SET tot_postpay={balance} WHERE anno = {record.anno};".Replace(",", ".");
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
        /// Metodo per la chiusura dell'anno in corso, inserisce il saldo nell'anno successivo
        /// </summary>
        /// <param name="balance">Valore di saldo da salvare</param>
        /// <param name="year">Anno per il mapping</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveBalanceYear(double balance, int year)
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
                string query = $"UPDATE totale_postpay SET tot_postpay={balance} WHERE anno = {year};".Replace(",", ".");
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
        /// Metodo per inserire un record nel DB
        /// </summary>
        /// <param name="record">Record da inserire</param>
        /// <returns>Ritorna true se inserito correttamente</returns>
        public bool insert(RecordPostPay record)
        {
            bool insert = false;

            ReadErrorXml xml = new ReadErrorXml();
            try
            {
                //Inserisce il record nella tabella postpay
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string import = record.importo.ToString().Replace(',', '.');
                string query = $"INSERT INTO postpay(causale,importo,anno,id_mese) VALUES('{record.causale}',{import},{record.anno},{record.id_mese});";
                command.CommandText = query;

                //Verifica ci sia stato l'inserimento e restituisce true
                if (command.ExecuteNonQuery() > 0)
                {
                    insert = true;
                }

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            return insert;

        }

    }
}
