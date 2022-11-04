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

        //Getter Setter della long description
        public string LongDescription { get; set; }

        //Visualizzazione del form acquisisce il valore della textbox
        private void frmLongDesription_Load(object sender, EventArgs e)
        {
            txtLongDesription.Texts = LongDescription;
        }

        //Setta l'attributo dal valore del textBox e chiude il form
        private void btnClose_Click(object sender, EventArgs e)
        {
            LongDescription = txtLongDesription.Texts;
            Dispose();
        }

        
    }
}
