using Connection;
using System;
using System.Collections.Generic;
using ReadXML;


namespace GenericModelData
{
    /// <summary>
    /// Classe per la gestione dati verso il DB ContoCorrente
    /// </summary>
    public class ModelDataCC : ModelDataSY
    {
        /// <summary>
        /// Classe per la gestione dati verso il DB ContoCorrente, eredita ModelDataSY
        /// </summary>
        public ModelDataCC() { }

        /// <summary>
        /// Struttura dati per CC
        /// </summary>
        public struct PaymentCC
        {
            public int id_tupla_mese;
            public int giorno;
            public string causale;
            public double importo;
        }

        /// <summary>
        /// Metodo per caricare i dati del conto corrente da DB
        /// </summary>
        /// <param name="mese">Mese da caricare da DB in formato stringa</param>
        /// <param name="month">Mese per mapping su DB</param>
        /// <param name="year">Anno per mapping su DB</param>
        /// <returns>Ritorna una list(PaymentCC) di dati</returns>
        public List<PaymentCC> loadDataCC(string mese, int year)
        {
            List<PaymentCC> listdata = new List<PaymentCC>();
            PaymentCC payment;
            ReadErrorXml xml = new ReadErrorXml();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM {mese}_cc WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_tupla_mese = reader.GetInt32(0);
                    payment.giorno = reader.GetInt32(1);
                    payment.causale = reader.GetString(2);
                    payment.importo = reader.GetDouble(3);
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
        /// Metodo per salvare i dati del conto corrente su DB
        /// </summary>
        /// <param name="mese">Mese su DB in formato stringa</param>
        /// <param name="year">Anno per update su DB</param>
        /// <param name="month">Mese per update su DB</param>
        /// <param name="data">List(PaymentCC) con i dati da salvare</param>
        /// <returns>Ritorna true se il salvataggio è ok</returns>
        public bool saveDataCC(string mese, int year, List<PaymentCC> data)
        {
            ReadErrorXml xml = new ReadErrorXml();
            List<PaymentCC> listdata = new List<PaymentCC>();
            PaymentCC payment;
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
                string query = $"SELECT * FROM {mese}_cc WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_tupla_mese = reader.GetInt32(0);
                    payment.giorno = reader.GetInt32(1);
                    payment.causale = reader.GetString(2);
                    payment.importo = reader.GetDouble(3);
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
                                command.CommandText = $"INSERT INTO {mese}_cc(id_{mese}_cc,giorno,causale,importo,anno) VALUES({data[i].id_tupla_mese},{data[i].giorno},'{data[i].causale}',{import},{year});";
                                command.ExecuteNonQuery();
                            }
                            break;
                        }
                        else if (!(listdata[i].giorno == data[i].giorno) || !(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo))
                        {
                            import = data[i].importo.ToString().Replace(',', '.');
                            command.CommandText = $"UPDATE {mese}_cc SET giorno={data[i].giorno},causale='{data[i].causale}',importo={import} WHERE id_{mese}_cc={data[i].id_tupla_mese}";
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
                        if (!(listdata[i].giorno == data[i].giorno) || !(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo))
                        {
                            if (listdata[i].id_tupla_mese < data[i].id_tupla_mese)
                            {
                                command.CommandText = $"DELETE FROM {mese}_cc WHERE id_{mese}_cc={listdata[i].id_tupla_mese}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                                listdata.RemoveAt(i);

                            }
                            else
                            {
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"UPDATE {mese}_cc SET giorno={data[i].giorno},causale='{data[i].causale}',importo={import} WHERE id_{mese}_cc={data[i].id_tupla_mese}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }

                        }
                    }
                    for (i = data.Count; i < listdata.Count; i++)
                    {
                        command.CommandText = $"DELETE FROM {mese}_cc WHERE id_{mese}_cc={listdata[i].id_tupla_mese}";
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
        /// Metodo per caricare il valore di saldo CC del mese precedente
        /// </summary>
        /// <param name="year">Anno per update su DB</param>
        /// <param name="month">Mese per update su DB</param>
        /// <returns>Ritorna il valore del saldo</returns>
        public double balanceMonthPre(int year, int month)
        {
            ReaderXML readerxml;
            double balancePre = 0;

            //se il primo anno 2019, imposta il valore di partenza
            if (month == 1 && year == 2019)
            {
                readerxml = new ReaderXML(pathSetIni, fatherIni);
                balancePre = Double.Parse(readerxml.readNode("tot_cc"));
            }
            else
            {
                //imposta il mese al mese precedente
                if (month > 1) month -= 1;
                else
                {//dicembre dell'anno prima se siamo al primo mese dell'anno
                    month = 12;
                    year -= 1;
                }
                ReadErrorXml xml = new ReadErrorXml();

                try
                {
                    readerxml = new ReaderXML(pathconn, "string");
                    stringConnection = readerxml.readNode("strconnect");
                    Connecting connecting = new Connecting(stringConnection);
                    var connection = connecting.connection();
                    var command = connecting.command(connection);
                    string query = $"SELECT * FROM totale_mese_cc WHERE anno={year} AND id_mese={month};";
                    var reader = connecting.reader(command, query);
                    //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                    //invocare il metodo read()
                    if(reader.Read()) balancePre = reader.GetDouble(0);

                    //scarica le risorse
                    reader.Dispose();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    xml.manageError(9, path, father, featur);
                }
            }
            //ritorna il saldo mese precedente
            return balancePre;
        }

        /// <summary>
        /// Metodo per aggiornare il saldo CC del mese su DB
        /// </summary>
        /// <param name="balance">Valore di saldo da salvare</param>
        /// <param name="year">Anno per update su DB</param>
        /// <param name="month">Mese per update su DB</param>
        /// <returns>Restituisce true se salvataggio ok</returns>
        public bool saveBalanceMonth(double balance, int year, int month)
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
                string query = $"UPDATE totale_mese_cc SET totale_mese_cc={balance} WHERE anno = {year} AND id_mese = {month};".Replace(",", ".");
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
            //ritorna l'esito del salvataggio
            return save;
        }

        /// <summary>
        /// Motodo per caricare il saldo del conto corrente del mese in corso
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="month">Mese per il mapping</param>
        /// <returns>Ritorna il saldo cc</returns>
        public double loadBalanceCC(int year, int month)
        {
            ReadErrorXml xml = new ReadErrorXml();
            double balance = 0;
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM totale_mese_cc WHERE anno={year} AND id_mese={month};";
                var reader = connecting.reader(command, query);
                //non è necessario il ciclo dato che estrae una sola riga, ma è necessario
                //invocare il metodo read()
                if (reader.Read() == true) balance = reader.GetDouble(0);

                reader.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                xml.manageError(9, path, father, featur);
            }
            //ritorna il saldo attuale
            return balance;
        }

        /// <summary>
        /// Metodo per la modifica di una sola riga di Conto Corrente
        /// </summary>
        /// <param name="id">Campo PK</param>
        /// <param name="day">Campo giorno</param>
        /// <param name="cause">Campo causale</param>
        /// <param name="import">Campo importo</param>
        /// <param name="year">Anno per update</param>
        /// <param name="month">Mese per update</param>
        /// <param name="id_month">FK per update in DB</param>
        /// <returns>Ritorna true se la modifica è ok</returns>
        public bool modifyRow(int id, int day, string cause, string import, int year, string month)
        {
            //polimorfismo del motodo di Spese Annuali
            ReadErrorXml xml = new ReadErrorXml();
            bool execute = false;

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);

                command.CommandText = $"UPDATE {month}_cc SET giorno={day},causale='{cause}', importo = {import} WHERE id_{month}_cc = {id} AND anno = {year}";

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
