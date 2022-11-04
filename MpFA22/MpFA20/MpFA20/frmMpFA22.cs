using System;
using System.Windows.Forms;
using LeaderProcess;
using GenericModelData;

namespace MpFA20
{
    /// <summary>
    /// Modulo principale del software MpFA22 V3.5
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
            processRunning.path = Routes.XMLERRORS;
            processRunning.father = "ListError";
            processRunning.featur = "ErrorTitle";
            processRunning.XMlpathConteinerFile = Routes.RUNPATH;
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
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/postpay", "PostPay");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //chiamata al processo, eccezione gestita dal chiamante
            processRunning.runProcess("/runpath/report", "RunningReports");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Termina tutti i processi in esecuzione
            processRunning.stopProcess("SpeseAnnuali");
            processRunning.stopProcess("ContoCorrente");
            processRunning.stopProcess("Mantenimento");
            processRunning.stopProcess("Libretto");
            processRunning.stopProcess("PostPay");
            processRunning.stopProcess("RunningReports");
            Dispose();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            //Visualizza il form di setting
            frmSetting frm = new frmSetting();
            //Visualiza il form
            frm.Show();

        }
    }
}
