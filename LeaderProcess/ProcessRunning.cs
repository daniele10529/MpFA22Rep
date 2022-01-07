using System;
using System.Diagnostics;
using ReadXML;
using System.Runtime.CompilerServices;
using System.IO;

namespace LeaderProcess
{
    /// <summary>
    /// Classe per l'avvio di processi
    /// </summary>
    public class ProcessRunning
    {
        /// <summary>
        /// Percorso file XML con il percorso dei processi da avviare
        /// </summary>
        public string XMlpathConteinerFile { get; set; }
        /// <summary>
        ///Percorso file con lista errori 
        /// </summary>
        public string path { get; set; }
        /// <summary>
        /// Nome del nodo
        /// </summary>
        public string father { get; set; }
        /// <summary>
        /// Nome dell'attributo
        /// </summary>
        public string featur { get; set; }

        //istanza alla classe ReaderXML per la lettura dei percorsi dove avviare i moduli
        private ReaderXML reader;
        //istanza della classe per il messaggio nella gestione eccezione
        private ReadErrorXml readerError = new ReadErrorXml();

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public ProcessRunning () { }

        /// <summary>
        /// Metodo sincronizzato al multithreading per avviare i processi
        /// </summary>
        /// <param name="PathNodes">Percorso di nodi contenente la posizione del processo da avviare</param>
        /// <param name="nameProcess">Nome del processo da avviare</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void runProcess(string PathNodes, string nameProcess)
        {
           
            try
            {

                //Istanza alla classe ReaderXML
                reader = new ReaderXML(XMlpathConteinerFile);
                //leggo il percorso del modulo dal file xml
                string pathProcess = reader.readNodeXmlDoc(PathNodes);
                //istanzio la classe process per avviare un processo
                Process process = new Process();
                //ottengo il nome del processo in esecuzione
                Process[] current = Process.GetProcessesByName(nameProcess);
                //se il processo di dump è già in lavoro non eseguo nulla
                if (!(current.Length > 0))
                {   //nessun evento alla chiusura del processo
                    process.EnableRaisingEvents = false;
                    //set del percorso del processo da avviare
                    process.StartInfo.FileName = pathProcess;
                    //avvia il processo
                    process.Start();
                }
            }
            catch(IOException exc)
            {
                readerError.manageError(5, path, father, featur);
            }
            catch (Exception ex)
            {
                readerError.manageError(14, path, father, featur);
            }

        }

    }
}
