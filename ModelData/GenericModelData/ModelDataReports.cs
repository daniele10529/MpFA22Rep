using System;
using System.Collections.Generic;
using System.Data;
using ReadXML;
using Connection;

namespace GenericModelData
{   

    /// <summary>
    /// Classe per la gestione dati verso il DB di RunReports
    /// </summary>
    public class ModelDataReports : ModelDataSY
    {
        /// <summary>
        /// Struttura di rappresentazione dei dati per il report
        /// </summary>
        public struct RunReports
        {
            //Valori statici
            public const string columnYear = "ANNO";
            //Anno da reportare, statico per il passaggio dati tra form
            public static int year;
            /// <summary>
            /// Struttura dei dati di report del singolo mese
            /// </summary>
            public struct dataMounth { public double pay; public double spend; public double safe; }
            //Lista report mensili, tot entrate, tot spese, risparmio
            public List<dataMounth> reportMounth;
            //Totali annui
            public double tot_year_gain;
            public double tot_year_spend;
        }

        public struct RunReportsSpends
        {
            public string mese;
            public List<string> oftenCauses;
            public string oftenCause;
            public double import;
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public ModelDataReports() { }

        /// <summary>
        /// Metodo per il caricamento degli anni presenti nel DB
        /// </summary>
        /// <returns>Datatable da passare al DataGridView</returns>
        public DataTable loadYar()
        {
            //Istanze agli oggetti
            //Tabella contenente la lista anni del DB
            DataTable table = new DataTable();
            ReadErrorXml xmlErrors = new ReadErrorXml();

            try
            {

                //Carica gli anni prenseti nel DB
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                string query = "SELECT * FROM anni";
                var command = connecting.command(connection, query);
                //Utilizza il DataAdapter per inserire i dati in tabella
                connecting.reader(command, table);

                //Scarica le risorse
                command.Dispose();
                connection.Dispose();

            }
            catch(Exception ex)
            {
                xmlErrors.manageError(9, path, father, featur);
            }

            //Restituisce la lista con gli anni
            return table;
        }

        /// <summary>
        /// Motodo per l'acquisizione di tutti i valori del report da DB
        /// </summary>
        /// <param name="year">Anno su cui fare il report</param>
        /// <returns>ADT con i valori del report</returns>
        public RunReports getReport(int year)
        {
            //Istanza agli oggetti
            RunReports runRports = new RunReports();
            ReadErrorXml xmlErrors = new ReadErrorXml();
            runRports.reportMounth = new List<RunReports.dataMounth>();

            try
            {
                //Carica gli anni prenseti nel DB
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT stipendio + ricavo_extra as ricavo_tot, totale_spese_mese, " +
                    $"cast((stipendio + ricavo_extra)-totale_spese_mese as decimal(16,2)) as risparmio " +
                    $"FROM resoconto_mensile WHERE anno = {year};";
                var reader = connecting.reader(command, query);

                while(reader.Read())
                {
                    RunReports.dataMounth dataMounth = new RunReports.dataMounth();
                    dataMounth.pay = reader.GetDouble("ricavo_tot");
                    dataMounth.spend = reader.GetDouble("totale_spese_mese");
                    dataMounth.safe = reader.GetDouble("risparmio");
                    runRports.reportMounth.Add(dataMounth);
                }
                reader.Dispose();

                query = $"SELECT totale_ricavi_anno, totale_spese_anno FROM resoconto_annuale WHERE anno = {year};";
                reader = connecting.reader(command, query);

                while(reader.Read())
                {
                    runRports.tot_year_gain = reader.GetDouble("totale_ricavi_anno");
                    runRports.tot_year_spend = reader.GetDouble("totale_spese_anno");
                }

                //Scarica le risorse
                reader.Dispose();
                command.Dispose();
                connection.Dispose();

            }
            catch(Exception ex)
            {
                xmlErrors.manageError(9, path, father, featur);
            }

            return runRports;
        }

        /// <summary>
        /// Metodo per ottenere la lista delle causali frequenti dal DB
        /// </summary>
        /// <returns>Oggetto RunReportsSpend con la lista delle causali frequenti</returns>
        public RunReportsSpends getOftenCauses()
        {
            //Oggetto ADT contenente la lista di stringhe
            RunReportsSpends spends = new RunReportsSpends();
            //Istanza a una nuova lista
            spends.oftenCauses = new List<string>();
            //Classe per la gestione degli errori da file XML
            ReadErrorXml xmlErrors = new ReadErrorXml();
            string value = "";

            try
            {
                //Carica gli anni prenseti nel DB
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM causali_frequenti;";
                var reader = connecting.reader(command, query);
                
                //Assegna alla lista ogni valore del DB
                while (reader.Read())
                {
                    value = reader.GetString("often_cause");
                    spends.oftenCauses.Add(value);
                }

                //Scarica le risorse
                reader.Dispose();
                command.Dispose();
                connection.Dispose();

            }
            catch (Exception ex)
            {
                xmlErrors.manageError(9, path, father, featur);
            }

            return spends;
        }

        public List<RunReportsSpends> getOftenSpendsList(string cause, int year)
        {
            RunReportsSpends runReportsSpend;
            //Lista di oggetti ADT contenenti le voci di spesa
            List<RunReportsSpends> listReports = new List<RunReportsSpends>();
            //Classe per la gestione degli errori da file XML
            ReadErrorXml xmlErrors = new ReadErrorXml();

            try
            {
                //Carica gli anni prenseti nel DB
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                //information_schema.tables => ricava le informazioni del database, preleva e verifica 
                //il nome della tabella dal parametro TABLE_NAME
                string query = 
                    $"SELECT DISTINCT gennaio.*, TABLE_NAME as TableName FROM gennaio " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'gennaio';"+
                    $"SELECT DISTINCT febbraio.*, TABLE_NAME as TableName FROM febbraio " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'febbraio';" +
                    $"SELECT DISTINCT marzo.*, TABLE_NAME as TableName FROM marzo " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'marzo';"+
                    $"SELECT DISTINCT aprile.*, TABLE_NAME as TableName FROM aprile " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'aprile';"+
                    $"SELECT DISTINCT maggio.*, TABLE_NAME as TableName FROM maggio " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'maggio';"+
                    $"SELECT DISTINCT giugno.*, TABLE_NAME as TableName FROM giugno " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'giugno';"+
                    $"SELECT DISTINCT luglio.*, TABLE_NAME as TableName FROM luglio " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'luglio';"+
                    $"SELECT DISTINCT agosto.*, TABLE_NAME as TableName FROM agosto " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'agosto';"+
                    $"SELECT DISTINCT settembre.*, TABLE_NAME as TableName FROM settembre " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'settembre';"+
                    $"SELECT DISTINCT ottobre.*, TABLE_NAME as TableName FROM ottobre " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'ottobre';"+
                    $"SELECT DISTINCT novembre.*, TABLE_NAME as TableName FROM novembre " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'novembre';"+
                    $"SELECT DISTINCT dicembre.*, TABLE_NAME as TableName FROM dicembre " +
                       $"INNER JOIN information_schema.tables ON anno={year} AND voce_spesa='{cause}' AND TABLE_NAME = 'dicembre';";


                var reader = connecting.reader(command, query);
                
                //Cicla il risultato di tutte le tabelle trovate
                //NextResult() salta alla tabella successiva finché ne sono presenti
                do
                {
                    //Assegna alla lista ogni valore del DB
                    while (reader.Read())
                    {
                        runReportsSpend = new RunReportsSpends();
                        runReportsSpend.mese = reader.GetString("TableName");
                        runReportsSpend.oftenCause = reader.GetString("voce_spesa");
                        runReportsSpend.import = reader.GetDouble("importo");
                        listReports.Add(runReportsSpend);
                    }
                } while (reader.NextResult()); //Cicla fintanto che c'è una tabella


                //Scarica le risorse
                reader.Dispose();
                command.Dispose();
                connection.Dispose();

            }
            catch (Exception ex)
            {
                xmlErrors.manageError(9, path, father, featur);
            }

            //Ritorna la lista di ADT
            return listReports;

        }

    }
}
