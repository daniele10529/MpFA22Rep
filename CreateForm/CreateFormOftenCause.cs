using System;
using System.Drawing;
using System.Windows.Forms;
using GenericModelData;
using RoundendControlCollections;

/// <summary>
/// API per generare Form
/// </summary>
namespace CreateForm
{
    /// <summary>
    /// Classe per la creazione del form di selezione
    /// causali frequenti
    /// </summary>
    public class CreateFormOftenCause
    {
        /// <summary>
        /// Setter per la TextBox di tipo rounded a cui assegnare il valore
        /// </summary>
        public RoundedTextBox OftenCause { get; set; }

        //componenti del form
        private Form frmAddOftenCause = new Form();
        private ListBox listItem = new ListBox();
        private Button btnAdd = new Button();
        private Button btnRemove = new Button();
        private Button btnClose = new Button();
        private ModelOftenElement model = new ModelOftenElement();

        /// <summary>
        /// Classe per la creazione del form di selezione
        /// causali frequenti, inizializza componenti form
        /// </summary>
        public CreateFormOftenCause()
        {
            initializedComponent();
        }

        /// <summary>
        /// Metodo privato per il setting dei componenti del form
        /// </summary>
        private void initializedComponent()
        {
            try
            {
                //Setting Form
                frmAddOftenCause.Size = new Size(400, 300);
                frmAddOftenCause.FormBorderStyle = FormBorderStyle.None;
                frmAddOftenCause.StartPosition = FormStartPosition.CenterScreen;
                frmAddOftenCause.Name = "frmAddOftenCause";
                frmAddOftenCause.Text = "Aggiungi voce frequente";
                frmAddOftenCause.BackColor = Color.DarkSeaGreen;
                frmAddOftenCause.AcceptButton = btnAdd;
                //Setting ListBox
                listItem.BorderStyle = BorderStyle.None;
                listItem.Font = new Font("MS Reference Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                listItem.FormattingEnabled = true;
                listItem.ItemHeight = 16;
                listItem.Location = new Point(5, 12);
                listItem.Name = "listBox1";
                listItem.Size = new Size(390, 200);
                listItem.TabIndex = 0;
                //Setting Button
                btnAdd.Location = new Point(30, 250);
                btnAdd.Name = "btnAdd";
                btnAdd.Size = new Size(115, 23);
                btnAdd.TabIndex = 1;
                btnAdd.Text = "Aggiungi causale";
                btnAdd.UseVisualStyleBackColor = true;
                btnAdd.Click += new EventHandler(btnAdd_Click);
                //Setting Button
                btnRemove.Location = new Point(155, 250);
                btnRemove.Name = "btnRemove";
                btnRemove.Size = new Size(115, 23);
                btnRemove.TabIndex = 1;
                btnRemove.Text = "Elimina causale";
                btnRemove.UseVisualStyleBackColor = true;
                btnRemove.Click += new EventHandler(btnRemove_Click);
                //Setting Button
                btnClose.Location = new Point(280, 250);
                btnClose.Name = "btnClose";
                btnClose.Size = new Size(75, 23);
                btnClose.TabIndex = 2;
                btnClose.Text = "Chiudi";
                btnClose.UseVisualStyleBackColor = true;
                btnClose.Click += new EventHandler(btnClose_Click);
                //Aggiunge i componenti al Form
                frmAddOftenCause.Controls.Add(btnAdd);
                frmAddOftenCause.Controls.Add(btnRemove);
                frmAddOftenCause.Controls.Add(btnClose);
                frmAddOftenCause.Controls.Add(listItem);
                //Carica i dati da DB e li aggiunge alla listbox
                model.loadOftenCause(listItem);
                //Visualizza la finestra
                frmAddOftenCause.Show();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Errore.... " + ex.Message);
            }
        }

        /// <summary>
        /// Metodo interno, gestore degli eventi,
        /// aggiunge lavoce selezionata al TextBox passato al setter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender,EventArgs e)
        {
            //se è stato selezionato un elemento imposta il testo della TextBox
            //come il valore selezionato
            if (listItem.SelectedIndex > -1)
            {
                OftenCause.Texts = listItem.SelectedItem.ToString();
                frmAddOftenCause.Dispose();//chiudi il form
            }
            else return;

        }

        /// <summary>
        /// Metodo interno, gestore degli eventi,
        /// rimuove una voce selezionata dal DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string removeCause = "";
            bool verify = false;
            int index = 0;
            //se è stato selezionato un elemento della listbox
            if (listItem.SelectedIndex > -1)
            {//se si è sicuri di eliminarlo
                if(MessageBox.Show("Sicuro di voler eliminare la voce ?","Attenzione",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //preleva il valore dell'elemento della listbox selezionato
                    //e il suo indice
                    removeCause = listItem.SelectedItem.ToString();
                    index = listItem.SelectedIndex;
                    //rimuovi l'elemento dal DB
                    verify = model.removeOftenCause(removeCause);
                    //se l'eliminazione è andata a buon fine
                    if (verify == true)
                    {
                        //elimina l'elemento dalla listbox
                        listItem.Items.RemoveAt(index);
                        MessageBox.Show("Rimozione avvenuta con successo");
                    }
                }               
            }
            else return;

        }

        /// <summary>
        /// Metodo interno, gestore degli eventi,
        /// chiude il form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {//chiude il form
            frmAddOftenCause.Dispose();
        }


    }
}
