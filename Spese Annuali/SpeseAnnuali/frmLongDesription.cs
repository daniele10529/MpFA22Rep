using System;
using System.Windows.Forms;

namespace MpFA20
{
    public partial class frmLongDesription : Form
    {
        public frmLongDesription()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Getter Setter della long description
        /// </summary>
        public string LongDescription { get; set; }
        /// <summary>
        /// Getter and Setter per la modifica delle note
        /// </summary>
        public bool TextChanched { get; set; }

        //Visualizzazione del form acquisisce il valore della textbox
        private void frmLongDesription_Load(object sender, EventArgs e)
        {
            //Setta i tooltip dei pulsanti
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.SetToolTip(btnInsert, "Modifica la long description");
            tip.SetToolTip(btnClose, "Chiudi la finestra senza modificare la long description");

            //Passa alla TextBox il valore del Getter
            txtLongDesription.Texts = LongDescription;

        }

        //Definisce che non c'è stata modifica e chiude il Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            TextChanched = false;
            Dispose();
        }
        //Setta l'attributo Long Description e chiude il form
        //Definisce l'avvenuta modifica
        private void btnInsert_Click(object sender, EventArgs e)
        {
            LongDescription = txtLongDesription.Texts;
            TextChanched = true;
            Dispose();
        }
    }
}
