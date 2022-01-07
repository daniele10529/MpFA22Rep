using System;
using System.Windows.Forms;
using LeaderProcess;

namespace MpFA20
{
    /// <summary>
    /// Modulo principale del software MpFA22
    /// </summary>
    public partial class frmMain : Form
    {
        //Istanza alla classe ProcessRunning
        private ProcessRunning processRunning;

        public frmMain()
        {
            InitializeComponent();
            //Inizializzazione per la lettura file XML contenente percorsi degli errori e dei processi
            processRunning = new ProcessRunning();
            processRunning.path = @"C:\MpFA22\ErrorList\XMLErrorList.xml";
            processRunning.father = "ListError";
            processRunning.featur = "ErrorTitle";
            processRunning.XMlpathConteinerFile = @"C:\MpFA22\RunPath\RunPath.xml";
        }

        public void btnSpeseAnnuali_Click(object sender, EventArgs e)
        {
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/speseannuali", "SpeseAnnuali");
        }

        public void btnContoCorrente_Click(object sender, EventArgs e) 
        {
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/contocorrente", "ContoCorrente");
        }

        public void btnMantenimento_Click(object sender, EventArgs e)
        {
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/mantenimento", "Mantenimento");
        }

        public void btnPPlibretto_Click(object sender, EventArgs e)
        {
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/libretto", "Libretto");
        }

        private void btnPP_Click(object sender, EventArgs e)
        {
            processRunning.runProcess("/runpath/postpay", "PostPay");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        
    }
}
