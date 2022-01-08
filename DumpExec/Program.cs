using System;
using System.Xml;
using System.IO;
using Connection;
using ReadXML;
using MySql.Data.MySqlClient;

namespace DumpExec
{
    class Program
    {
        static void Main(string[] args)
        {
            //percorso del file xml per il dump
            string pathXML = @"C:\MpFA22\PathDump\PathDump.xml";
            string pathDump = "";
            string finalPath = "";
            string namefile = "";
            string estensione = "";
            string stringConnection = "";
            int anno = 0, mese = 0;

            try
            {
                //ottengo la data odierna
                DateTime date = DateTime.Now;
                //carico il file xml e leggo il percorso gerarchico del nodo che contiene il percorso
                XmlDocument xml = new XmlDocument();
                xml.Load(pathXML);
                XmlNodeList nodes = xml.SelectNodes("/path/setpath");

                //imposto il valore dal nodo xml per eseguire il dump
                pathDump = nodes.Item(0).InnerText;
                //prelevo mese e anno dalla data odierna
                mese = date.Month;
                anno = date.Year;
                //formo il nome del file in modalità stringa
                namefile = mese.ToString() + anno.ToString();
                
                //se la directori non esiste la creo
                if (!(Directory.Exists(pathDump + @"\" + namefile)))
                {
                    Directory.CreateDirectory(pathDump + @"\" + namefile);
                    //setto il percorso finale per il dump
                    finalPath = pathDump + @"\" + namefile + @"\" + namefile + ".sql";
                }
                else //se esiste già la directory
                {
                    do
                    {   //faccio scegliere un estensione che non esista già
                        Console.Write("Scegli un estensione per la cartella : ");
                        estensione = Console.ReadLine();
                        //se non esiste la creo
                        if (!(Directory.Exists(pathDump + namefile + estensione)))
                        {
                            Directory.CreateDirectory(pathDump + @"\" + namefile + estensione);
                            //setto il percorso finale per il dump
                            finalPath = pathDump + @"\" + namefile + estensione + @"\" + namefile + ".sql";
                        }
                        //cicla finche non è scelta un estensione valida
                    } while (Directory.Exists(pathDump + namefile + estensione));

                }

                //connessione al DB essenziale per il dump attraverso la classe  MySqlBackup
                ReaderXML readerxml = new ReaderXML(@"C:\MpFA22\StrConnect\strConnect.xml", "string");
                stringConnection = readerxml.readNode("strconnect");
                Connecting connecting = new Connecting(stringConnection);
               
                var connection = connecting.connection();
                var command = connecting.command(connection);
                //istanzio la classe dopo aver aggiunto la referenza dal pacchetto nuget MySqlBackup.NET 2.3.3.1
                MySqlBackup backup = new MySqlBackup(command);
                //esporto il DB aperto in connessione
                backup.ExportToFile(finalPath);
                
                //scarico le risorse
                command.Dispose();
                backup.Dispose();
                Console.WriteLine("dump eseguito con successo..!!");
                //attendo un tasto premuto per chiudere
                Console.ReadKey();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }
    }
}
