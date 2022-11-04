using Connection;
using System;
using ReadXML;


namespace GenericModelData
{
    /// <summary>
    /// Classe per la gestione di start DB, set iniziale valori
    /// </summary>
    public class SetStart : ModelDataSY
    {
        //Attributi privati
        private const string pathconn = Routes.XMLCONNECTION;
        private const string path = Routes.XMLERRORS;
        private const string father = "ListError";
        private const string featur = "ErrorTitle";
        private const string pathSetIni = Routes.XMLSETINI;

        /// <summary>
        ///Costruttore void 
        /// </summary>
        public SetStart()
        {
            if (testEnvironment) node_connect = "strconnect_test";
            else node_connect = "strconnect";
        }

        /// <summary>
        /// Metodo di inizializzazione dei valori di CC,Lib,PP
        /// </summary>
        /// <returns>Ritorna true se inserimento ok</returns>
        public bool start()
        {
            ReadErrorXml xml = new ReadErrorXml();
            ReaderXML readerxml = new ReaderXML(pathconn, "string");
            string stringConnection = readerxml.readNode(node_connect);
            //Istanza classe connessione 
            Connecting connecting = new Connecting(stringConnection);
            bool starting = false;
            double tot_cc = 0, tot_lib = 0, tot_pp = 0;

            try
            {
                //setting dei valori iniziali
                var connection = connecting.connection();
                var command = connecting.command(connection);

                //legge i valori dal file xml di settaggio
                readerxml = new ReaderXML(pathSetIni, "setIni");
                tot_cc = Double.Parse(readerxml.readNode("tot_cc"));
                tot_lib = Double.Parse(readerxml.readNode("tot_lib"));
                tot_pp = Double.Parse(readerxml.readNode("tot_pp"));
                //inserisce i valori nel DB
                command.Parameters.AddWithValue("@tot_cc", tot_cc);
                command.Parameters.AddWithValue("@tot_lib", tot_lib);
                command.Parameters.AddWithValue("@tot_pp", tot_pp);
                command.CommandText = "UPDATE totale_mese_cc SET totale_mese_cc = @tot_cc WHERE anno=2019 AND id_mese=1; " +
                    "UPDATE totale_libretto SET tot_libretto = @tot_lib WHERE anno=2019; " +
                    "UPDATE totale_postpay SET tot_postpay = @tot_pp WHERE anno=2019;";
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Dispose();
                starting = true;

            }
            catch (Exception ex)
            {
                xml.manageError(11, path, father, featur);
            }
            //restituisce true se inserimento ok
            return starting;
        }
    }
}
