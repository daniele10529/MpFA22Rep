﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using GenericModelData;
using System.Xml;
using LeaderProcess;

namespace MpFA20
{
    public partial class frmSetting : Form
    {
        //percorso del file xml con il path per il dump
        private string pathXML = Routes.XMLDUMP;
        //Variabile di controllo del processo in corso
        private bool isInRunning;
       
        /// <summary>
        /// Getter Setter per il controllo dei processi in running
        /// </summary>
        public bool IsInRunning { get => isInRunning; set => isInRunning = value; }
        
        public frmSetting()
        {
            InitializeComponent();
            isInRunning = false;
            ModelDataSY.TestEnvironment = false;
        }

        /// <summary>
        /// Metodo per modificare lo stato dell'ambiente
        /// </summary>
        private void switchEnvironment(bool testEnvironment)
        {

            //Switch dello stato dell'ambiente in base allo stato attuale
            if (testEnvironment == false)
            {
                 ModelDataSY.TestEnvironment = true;
            }
            else
            {
                ModelDataSY.TestEnvironment = false;
            }

        }

        /// <summary>
        /// Metodo per settare lo stato del pulsante attiva ambiente di test
        /// </summary>
        /// <param name="testEnvironment"></param>
        private void setButtonEnvironment(bool testEnvironment)
        {
            if (testEnvironment)
            {
                btnTestEnvironment.Text = "Ambiente di test attivo";
                btnTestEnvironment.BorderColor = Color.Red;
                btnTestEnvironment.ForeColor = Color.Red;

            }
            else
            {
                btnTestEnvironment.Text = "Abilita ambiente di Test";
                btnTestEnvironment.BorderColor = Color.LightSeaGreen;
                btnTestEnvironment.ForeColor = Color.White;
            }

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            //Rende invisibile la TextBox e il Button
            txtPathDump.Visible = false;
            btnChange.Visible = false;
            lblSetPath.Visible = false;
            //Setta lo stato del pulsante ambiente di test
            setButtonEnvironment(ModelDataSY.TestEnvironment);
        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            bool verify = false;
            //Istanzia la classe per il settaggio dei valori iniziali del DB
            //necessario al fine di far tornare il conteggio allo start del DB
            //non deve più essere utilizzata successivamente
            if(MessageBox.Show("Attenzione deve essere stato generato il primo anno prima di continuare","Attenzione",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SetStart setstart = new SetStart();
                verify = setstart.start();
                if (verify) MessageBox.Show("Inizializzazione avvenuta con successo");
            }
            
        }


        //Legge il percorso salvato per effettuare il dump
        private void btnSetPathDump_Click(object sender, EventArgs e)
        {
            //Se visibile la textbox con il percorso di dump nascondi gli elementi per l'aggiornamento del percorso
            if (txtPathDump.Visible == true)
            {
                txtPathDump.Visible = false;
                btnChange.Visible = false;
                lblSetPath.Visible = false;
                return;
            }
            try
            {
                //Leggo il percorso gerarchico del nodo che contiene il percorso
                XmlDocument xml = new XmlDocument();
                xml.Load(pathXML);
                XmlNodeList nodes = xml.SelectNodes("/path/setpath");

                txtPathDump.Visible = true;
                btnChange.Visible = true;
                lblSetPath.Visible = true;
                txtPathDump.BorderColor = Color.DimGray;
                //Imposta il valore della casella di testo dal nodo xml
                txtPathDump.Texts = nodes.Item(0).InnerText;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore di lettura del File xml  " + ex.Message);
            }
            
        }

        //Cambia il percorso per effetture il dump
        private void btnChange_Click(object sender, EventArgs e)
        {
            string nodespath = "/path/setpath";
            string path = "";
          
            if (txtPathDump.Texts.Length > 0)
            {
                path = txtPathDump.Texts;
                if (Directory.Exists(path))
                {
                    XmlDocument document = new XmlDocument();
                    //leggo il documento in base al percorso
                    document.Load(pathXML);
                    //acquisisco i nodi in pase alla gerarchia passata
                    XmlNodeList nodes = document.SelectNodes(nodespath);
                    //imposto il valore del nodo passato con il valore passato
                    nodes.Item(0).InnerText = path;
                    //salvo il documento in base al percorso salvato
                    document.Save(pathXML);
                    txtPathDump.BorderColor = Color.FromArgb(61,243,146);

                }
                else
                {
                    MessageBox.Show("Directory inesistente","ERRORE",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Immettere un percorso valido","ERRORE",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnDump_Click(object sender, EventArgs e)
        {
            //istanzio la classe process per avviare un processo
            Process process = new Process();
            //ottengo il nome del processo in esecuzione
            Process[] current = Process.GetProcessesByName("DumpExec");
            //se il processo di dump è già in lavoro non eseguo nulla
            if (!(current.Length > 0))
            {   //nessun evento alla chiusura del processo
                process.EnableRaisingEvents = false;
                //set del percorso del processo da avviare
                process.StartInfo.FileName = Routes.DUMPEXE;
                //avvia il processo
                process.Start();
            }
        }

        private void btnTestEnvironment_Click(object sender, EventArgs e)
        {
            //Modifica lo stato dell'ambiente se non ci sono processi in corso
            if(ProcessRunning.IsInRunning == false)
            {
                switchEnvironment(ModelDataSY.TestEnvironment);
                setButtonEnvironment(ModelDataSY.TestEnvironment);

            }
            else //Se un modulo è stato avviato è necessario chiudere l'applicazione per switchare l'ambiente
            {
                MessageBox.Show("Attenzione!! Non è possibile switchare l'ambiente, chiudere l'applicazione per modificare" +
                    " l'ambiente di lavoro.", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txtPathDump_Enter(object sender, EventArgs e)
        {
            txtPathDump.BorderColor = Color.FromArgb(161, 223, 239);
        }

        private void txtPathDump_Leave(object sender, EventArgs e)
        {
            txtPathDump.BorderColor = Color.DimGray;
        }

       
    }
}
