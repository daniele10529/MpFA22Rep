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

        //Attributo privato
        private static bool isInRunning;

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
        /// <summary>
        /// Stato del processo
        /// </summary>
        public static bool IsInRunning { get => isInRunning; }


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
                //legge il percorso del modulo dal file xml
                string pathProcess = reader.readNodeXmlDoc(PathNodes);
                //Istania la classe process per avviare un processo
                Process process = new Process();
                //Ottiene il nome del processo in esecuzione
                Process[] current = Process.GetProcessesByName(nameProcess);
                //Se il processo è già in stato di running non viene riavviato
                if (!(current.Length > 0))
                {   //Nessun evento alla chiusura del processo
                    process.EnableRaisingEvents = false;
                    //Setta il path del processo da avviare
                    process.StartInfo.FileName = pathProcess;
                    //Avvia il processo
                    process.Start();
                    //Setta lo stato di processo avviato
                    isInRunning = true;
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

        /// <summary>
        /// Metodo per la chiusura di un processo
        /// </summary>
        /// <param name="nameProcess">Nome del processo da chiudere</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void stopProcess(string nameProcess)
        {
            try
            {
                //Ottiene il processo corrente dal nome
                Process[] current = Process.GetProcessesByName(nameProcess);
                //se il processo è in esecuzione chiude il form e termina il processo
                if (current.Length > 0)
                {
                    //Chiusura del form - obbligatorio altrimenti rimane a video
                    current[0].CloseMainWindow();
                    //Chiusura del processo
                    current[0].Close();
                    //Setta lo stato di processo concluso
                    isInRunning = false;
                }

            }
            catch(IOException exc)
            {
                readerError.manageError(5, path, father, featur);
            }
            catch(Exception ex)
            {
                readerError.manageError(14, path, father, featur);
            }
        }


    }
}
