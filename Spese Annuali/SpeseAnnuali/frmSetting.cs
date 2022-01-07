using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using GenericModelData;
using System.Xml;

namespace SpeseAnnuali
{
    public partial class frmSetting : Form
    {
        //percorso del file xml con il path per il dump
        private string pathXML = @"C:\MpFA22\PathDump\PathDump.xml";
        
        public frmSetting()
        {
            InitializeComponent();
        }


        private void frmSetting_Load(object sender, EventArgs e)
        {//rende invisibile la TextBox e il Button
            txPathDump.Visible = false;
            btnChange.Visible = false;
        }

        private void btnSetStart_Click(object sender, EventArgs e)
        {
            bool verify = false;
            //istanzio la classe per il settaggio dei valori iniziali del DB
            //necessario al fine di far tornare il conteggio allo start del DB
            //non deve più essere utilizzata successivamente
            if(MessageBox.Show("Attenzione deve essere stato generato il primo anno prima di continuare","Attenzione",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SetStart setstart = new SetStart();
                verify = setstart.start();
                if (verify) MessageBox.Show("Inizializzazione avvenuta con successo");
            }
            
        }


        //leggo il percorso salvato per effettuare il dump
        private void btnSetPathDump_Click(object sender, EventArgs e)
        {
            //sen i pulsanti sono visibili nascondili
            if (txPathDump.Visible == true && btnChange.Visible == true)
            {
                txPathDump.Visible = false;
                btnChange.Visible = false;
                return;
            }
            try
            {
                //leggo il percorso gerarchico del nodo che contiene il percorso
                XmlDocument xml = new XmlDocument();
                xml.Load(pathXML);
                XmlNodeList nodes = xml.SelectNodes("/path/setpath");

                txPathDump.Visible = true;
                btnChange.Visible = true;
                //imposto il valore della casella di testo dal nodo xml
                txPathDump.Text = nodes.Item(0).InnerText;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore di lettura del File xml  " + ex.Message);
            }
            
        }

        //cambio il percorso per effetture il dump
        private void btnChange_Click(object sender, EventArgs e)
        {
            string nodespath = "/path/setpath";
            string path = "";
          
            if (txPathDump.Text.Length > 0)
            {
                path = txPathDump.Text;
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
                    txPathDump.ForeColor = Color.Green;

                }
                else
                {
                    MessageBox.Show("Directory inesistente");
                }
            }
            else
            {
                MessageBox.Show("Immettere un percorso valido");
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
                process.StartInfo.FileName = @"C:\MpFA22\Dumper\DumpExec.exe";
                //avvia il processo
                process.Start();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }


        private void txPathDump_TextChanged(object sender, EventArgs e)
        {
            //reimposto il calore quando scrivo
            txPathDump.ForeColor = Color.Teal;
        }

    }
}
