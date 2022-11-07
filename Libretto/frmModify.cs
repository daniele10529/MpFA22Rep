using System;
using System.Windows.Forms;
using GenericModelData;
using Checking;
using System.Drawing;

namespace Libretto
{
    public partial class frmModify : Form
    {
        public frmModify()
        {
            InitializeComponent();
        }

        //Istanza alla classe Libretto
        private frmLibretto fr = new frmLibretto();
        //Istanza alla textbox per la somma o sottrazione
        TextBox txtAdd = new TextBox();
        //Istanza alla classe tooltip, visualizza istruzioni
        ToolTip tip = new ToolTip();

        #region Getter and Setter

        public string setId { get; set; }
        public string setCause { get; set; }
        public string setImport { get; set; }
        public string setMonth { get; set; }
        public int setYear { get; set; }
        public bool verify { get; set; }

        #endregion

        #region Metodi Privati

        /// <summary>
        /// Restituisce il numero del mese selezionato
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private int selmonth(string m)
        {
            int n = 0;
            switch (m)
            {
                case "gennaio":
                    n = 1;
                    break;
                case "febbraio":
                    n = 2;
                    break;
                case "marzo":
                    n = 3;
                    break;
                case "aprile":
                    n = 4;
                    break;
                case "maggio":
                    n = 5;
                    break;
                case "giugno":
                    n = 6;
                    break;
                case "luglio":
                    n = 7;
                    break;
                case "agosto":
                    n = 8;
                    break;
                case "settembre":
                    n = 9;
                    break;
                case "ottobre":
                    n = 10;
                    break;
                case "novembre":
                    n = 11;
                    break;
                case "dicembre":
                    n = 12;
                    break;
            }
            return n;
        }

        #endregion

        #region Form

        private void frmModify_Load(object sender, EventArgs e)
        {
            //assegna i valori dai getter alle textbox
            txtId.Texts = setId;
            txtCause.Texts = setCause;
            txtImport.Texts = setImport;
            txtMonth.Texts = setMonth;
            //assegna alle variabili pubbliche di frmContocorrente i valori passati ai setter.
            //Passaggio necessario per l'aggiornamento del datagridview
            //dato che le variabili si scaricano all'istanza del form, e tornando indietro non c'è 
            //selezione dell'albero
            fr.year_manage = setYear;
        }

        #endregion

        #region Button

        private void btnModify_Click(object sender, EventArgs e)
        {
            string pathxml = Routes.XMLERRORS;
            string cause, import, month;
            int id = 0, id_month = 0;

            //istanze alle classi model e checker
            ModelDataLibNom model = new ModelDataLibNom();
            Checker check = new Checker(pathxml);

            try
            {

                if (!(check.isEmpty(txtMonth.Texts)) && !(check.isEmpty(txtCause.Texts)) && !(check.isEmpty(txtImport.Texts)))
                {
                    if (check.isNumeric(txtImport.Texts))
                    {
                        //setta i parametri per l'inserimento
                        id = Int32.Parse(txtId.Texts);
                        month = txtMonth.Texts;
                        cause = txtCause.Texts;
                        import = txtImport.Texts.Replace(",", ".");

                        //Definisce il numero del mese dal nome
                        id_month = selmonth(month);

                        //modifica il DB e riceve true se tutto ok
                        verify = model.modifyRow(id, setYear, cause, import, id_month);

                        if (verify == true)
                        {
                            MessageBox.Show("Inserimento avvenuto con successo", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //scarica appena fatto.
                        Dispose();
                    }
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            //costruisce la textbox e la visualizza
            txtAdd.Name = "txtAdd";
            txtAdd.Font = new Font("Modern No. 20", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            txtAdd.Size = new Size(50, 50);
            txtAdd.Location = new Point((btnPlus.Location.X) + 10, (btnPlus.Location.Y) + 40);
            txtAdd.Visible = true;
            txtAdd.KeyPress += new KeyPressEventHandler(txtAdd_KeyPress);
            //viene aggiunto il controllo al pannello principale e si visualizza
            pnlMain.Controls.Add(txtAdd);
            //resetta la finestra prima della visualizzazione
            txtAdd.ResetText();
            //ottiene il focus
            txtAdd.Focus();
            //setta il tooltip
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 100;
            tip.ReshowDelay = 500;
            tip.ShowAlways = true;
            tip.IsBalloon = true;
            tip.Show("Inserire la cifra e premere il tasto + per fare la somma", txtAdd, new Point(1, -50));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #endregion

        #region TextBox

        private void txtAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sostituisce il punto con la virgola per il corretto calcolo
            if (e.KeyChar == '.') e.KeyChar = ',';

            //se viene premuto +, keychar = 43 codice ascii tasto +
            if (e.KeyChar == 43)
            {
                string pathxml = Routes.XMLERRORS;

                //istanza alla classe checker per il controllo del valore numerico
                Checker check = new Checker(pathxml);
                //Verifica che il valore inserito obbligatorio sia numerico
                try
                {
                    if (!(check.isEmpty(txtAdd.Text)))
                    {
                        if (check.isNumeric(txtAdd.Text))
                        {
                            //acquisisci i valori e fai la somma
                            double val = Double.Parse(txtImport.Texts);
                            double plus = Double.Parse(txtAdd.Text);
                            txtImport.Texts = (val + plus).ToString();
                            //resetta il testo
                            txtAdd.ResetText();
                            //rendi invisibile la textbox e elimina il controllo per le visualizzazioni future
                            txtAdd.Visible = false;
                            pnlMain.Controls.Remove(txtAdd);
                            tip.RemoveAll();
                        }
                    }

                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        //Setting dei colori sulla casella di testo con il focus
        private void txtMonth_Enter(object sender, EventArgs e)
        {
            txtMonth.BorderColor = Color.FromArgb(161, 223, 239);
            txtMonth.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void txtMonth_Leave(object sender, EventArgs e)
        {
            txtMonth.BorderColor = Color.DimGray;
            txtMonth.BackColor = Color.White;
        }

        private void txtCause_Enter(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.FromArgb(161, 223, 239);
            txtCause.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void txtCause_Leave(object sender, EventArgs e)
        {
            txtCause.BorderColor = Color.DimGray;
            txtCause.BackColor = Color.White;
        }

        private void txtImport_Enter(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.FromArgb(161, 223, 239);
            txtImport.BackColor = Color.FromArgb(243, 221, 247);
        }

        private void txtImport_Leave(object sender, EventArgs e)
        {
            txtImport.BorderColor = Color.DimGray;
            txtImport.BackColor = Color.White;
        }


        #endregion

    }
}
