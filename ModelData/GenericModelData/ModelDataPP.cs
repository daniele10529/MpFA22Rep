using Connection;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using ReadXML;
using System.IO;

namespace GenericModelData
{
    /// <summary>
    /// Classe per la gestione dati verso il DB di PostPay
    /// </summary>
    public class ModelDataPP : ModelDataLibNom
    {
        /// <summary>
        /// Classe per la gestione dati verso il DB di PostPay eredita da ModelDataLibNom
        /// </summary>
        public ModelDataPP() { }

        /// <summary>
        /// Struttura di dati per PP
        /// </summary>
        public struct PaymentPP
        {
            public int id_postpay;//PK
            public string causale;//causale movimento
            public double importo;//importo versato
            public int id_mese;//mese in formato stringa
        }

        /// <summary>
        /// Metodo per caricare i dati di PP
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <returns>Restituisce la lista di dati</returns>
        public List<PaymentPP> loadDataPP(int year)
        {
            List<PaymentPP> listdata = new List<PaymentPP>();
            PaymentPP payment;
            ReadErrorXml xml = new ReadErrorXml();

            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM postpay WHERE anno={year}";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_postpay = reader.GetInt32(0);
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
        /// Metodo per caricare il saldo anno precedente PP
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="isPP">Discriminante per PP, true PP</param>
        /// <returns>Ritorna il valore di saldo dell'anno precedente</returns>
        public double balanceYearPre(int year, bool isPP)
        {
            //polimorfismo di ModelDataLibNom
            if (!(isPP == true)) return 0;

            ReaderXML readerxml;
            double balancePre = 0;
            //se il primo anno 2019, imposta il valore di partenza
            if (year == 2019)
            {
                readerxml = new ReaderXML(pathSetIni, fatherIni);
                balancePre = Double.Parse(readerxml.readNode("tot_pp"));
            }
            else
            {

                year -= 1;
                ReadErrorXml xml = new ReadErrorXml();

                try
                {
                    readerxml = new ReaderXML(pathconn, "string");
                    stringConnection = readerxml.readNode("strconnect");
                    Connecting connecting = new Connecting(stringConnection);
                    var connection = connecting.connection();
                    var command = connecting.command(connection);
                    string query = $"SELECT * FROM totale_postpay WHERE anno={year};";
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
            //ritorna il valore di saldo anno precedente
            return balancePre;
        }

        /// <summary>
        /// Metodo per il salvataggio dei dati di PP
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="data">List(PaymentLibPP) di dati da salvare nel DB</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveDataPP(int year, List<PaymentPP> data)
        {
            ReadErrorXml xml = new ReadErrorXml();
            List<PaymentPP> listdata = new List<PaymentPP>();
            PaymentPP payment;
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
                string query = $"SELECT * FROM postpay WHERE anno={year};";
                var reader = connecting.reader(command, query);

                while (reader.Read())
                {
                    payment.id_postpay = reader.GetInt32(0);
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
                                command.CommandText = $"INSERT INTO postpay(id_postpay,causale,importo,anno,id_mese) VALUES({data[i].id_postpay},'{data[i].causale}',{import},{year},{data[i].id_mese});";
                                command.ExecuteNonQuery();
                            }
                            break;
                        }
                        else if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].id_mese == data[i].id_mese))
                        {
                            import = data[i].importo.ToString().Replace(',', '.');
                            command.CommandText = $"UPDATE postpay SET causale='{data[i].causale}',importo={import},id_mese={data[i].id_mese} WHERE id_postpay={data[i].id_postpay}";
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
                        if (!(listdata[i].causale == data[i].causale) || !(listdata[i].importo == data[i].importo) || !(listdata[i].id_mese == data[i].id_mese))
                        {
                            if (listdata[i].id_postpay < data[i].id_postpay)
                            {
                                command.CommandText = $"DELETE FROM postpay WHERE id_postpay={listdata[i].id_postpay}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                                listdata.RemoveAt(i);

                            }
                            else
                            {
                                import = data[i].importo.ToString().Replace(',', '.');
                                command.CommandText = $"UPDATE postpay SET causale='{data[i].causale}',importo={import},id_mese={data[i].id_mese} WHERE id_postpay={data[i].id_postpay}";
                                command.ExecuteNonQuery();
                                command.Dispose();
                            }

                        }
                    }
                    for (i = data.Count; i < listdata.Count; i++)
                    {
                        command.CommandText = $"DELETE FROM postpay WHERE id_postpay={listdata[i].id_postpay}";
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
        /// Metodo per il salvataggio del saldo annuale di PP
        /// </summary>
        /// <param name="balance">Valore di saldo da salvare</param>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="isPP">Discriminante per PP, true PP</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool saveBalanceYear(double balance, int year, bool isPP)
        {
            //polimorfismo del metodo di ModelDataLibNom
            if (!(isPP == true)) return false;

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
        /// Metodo per il caricamento del saldo annuo Postpay
        /// polimorfismo del metodo di ModelDataLibNom
        /// </summary>
        /// <param name="year">Anno per il mapping</param>
        /// <param name="isPP">Discriminante di PP, true se PP</param>
        /// <returns>Ritorna il saldo annuo</returns>
        public double loadBalanceLib(int year, bool isPP)
        {
            //polimorfismo del metodo di ModelDataLibNom, 
            if (!(isPP == true)) return 0;

            ReadErrorXml xml = new ReadErrorXml();
            double balance = 0;
            try
            {
                ReaderXML readerxml = new ReaderXML(pathconn, "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
                var connection = connecting.connection();
                var command = connecting.command(connection);
                string query = $"SELECT * FROM totale_postpay WHERE anno={year};";
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
            return balance;
        }

        /// <summary>
        /// Metodo per la modifica di una sola riga, polimorfismo di spese annuali
        /// </summary>
        /// <param name="id">Campo PK</param>
        /// <param name="year">Campo FK per la modifica</param>
        /// <param name="cause">Campo causale</param>
        /// <param name="import">Campo importo</param>
        /// <param name="id_month">Campo id_mese</param>
        /// <param name="isPP">Discriminante per PP, true PP</param>
        /// <returns>Ritorna true se salvataggio ok</returns>
        public bool modifyRow(int id, int year, string cause, string import, int id_month, bool isPP = false)
        {
            if (isPP == false) return false;

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

                command.CommandText = $"UPDATE postpay SET causale='{cause}', importo = {import},id_mese = {id_month} WHERE id_postpay = {id} AND anno = {year}";

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
