using System;
using System.Windows.Forms;
using System.Drawing;
using GenericModelData;

/// <summary>
/// API per la gestione di Menu
/// </summary>
namespace MenuGenerator
{
    /// <summary>
    /// Classe per la creazione di un ContextMenu da tasto DX in un DataGridView
    /// </summary>
    public class CreateContexMenu
    {
        private DataGridView grid;
        //Istanza al menu del tasto DX e istanza ai suoi elementi
        private ContextMenu grdMenu = new ContextMenu();
        private MenuItem copy = new MenuItem();
        private MenuItem cut = new MenuItem();
        private MenuItem paste = new MenuItem();
        private MenuItem delete = new MenuItem();
        private MenuItem modifyIt = new MenuItem();
        private MenuItem oftenVal = new MenuItem();
        private MenuItem moveUp = new MenuItem();
        private MenuItem moveDown = new MenuItem();

        /// <summary>
        /// Classe per la creazione di un ContextMenu da tasto DX in un DataGridView
        /// </summary>
        /// <param name="grid">DataGridView in cui applicare il ContextMenu</param>
        public CreateContexMenu(DataGridView grid)
        {
            this.grid = grid;
            //Inserisco il testo agli elementi del ContexMenu
            copy.Text = "Copia";
            cut.Text = "Taglia";
            paste.Text = "Incolla";
            delete.Text = "Elimina riga";
            modifyIt.Text = "Modifica riga";
            oftenVal.Text = "Aggiungi a causale frequente";
            moveUp.Text = "Sposta su";
            moveDown.Text = "Sposta giu";
           
            //aggiiungo gli elementi al ContexMenu
            grdMenu.MenuItems.AddRange(new MenuItem[] { copy, cut, paste, delete, modifyIt, oftenVal, moveUp, moveDown });

        }

        /// <summary>
        /// Metodo per settare l'evento click dei pulsanti nel ContextMenu,
        /// solo per i pulsanti delete, modifyIt, moveUp, moveDown
        /// </summary>
        /// <param name="button">Nome del pulsante dove aggiungere l'evento</param>
        /// <param name="e">Evento da aggiungere al click</param>
        public void setEvents(string button, EventHandler e)
        {
            switch (button)
            {
                case "delete":
                    delete.Click += new EventHandler(e);
                    break;
                case "modifyIt":
                    modifyIt.Click += new EventHandler(e);
                    break;
                case "moveUp":
                    moveUp.Click += new EventHandler(e);
                    break;
                case "moveDown":
                    moveDown.Click += new EventHandler(e);
                    break;
            }

        }

        /// <summary>
        /// Metodo per visualizzare il menu
        /// </summary>
        /// <param name="e">Evento del click del mouse</param>
        public void showContextMenu(MouseEventArgs e)
        {
            //binding eventi copia, taglia, incolla
            copy.Click += new EventHandler(copy_Click);
            cut.Click += new EventHandler(cut_Click);
            paste.Click += new EventHandler(paste_Click);
            oftenVal.Click += new EventHandler(saveOftenCauseInDB);

            int returnValue;

            //se la clipboard è vuota disabilita il tasto incolla
            if (Clipboard.GetText().Equals("")) paste.Enabled = false;
            
            //acquisisce la posizione del mouse nel DataGridView
            returnValue = grid.HitTest(e.X, e.Y).RowIndex;
            //se la posizione è su di una riga della tabella visualizza il menu
            //se non ci sono righe non mostra nulla
            if (returnValue >= 0)
            {
                //mostra il menu all'interno del DataGridView al punto dove è stato cliccato il mouse
                grdMenu.Show(grid, new Point(e.X, e.Y));
            }
        }

        //grdMenu - menu del tasto DX, eventi click

        /// <summary>
        /// Metodo per copiare i valori da clipboard
        /// La clipboard consente di copiare e incollare il testo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copy_Click(object sender, EventArgs e)
        {
            //pulisce la clipboard
            Clipboard.Clear();
            //copia il testo della casella selezionata
            Clipboard.SetText(grid.CurrentCell.Value.ToString());
            //abilita l'incolla
            paste.Enabled = true;
        }

        /// <summary>
        ///  Metodo per tagliare i valori da clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cut_Click(object sender, EventArgs e)
        {
            //pulisce la clipboard
            Clipboard.Clear();
            //seleziona la cella corrente in cui si è cliccato
            grid.CurrentCell.Selected = true;
            //copia il testo della casella selezionata
            Clipboard.SetText(grid.CurrentCell.Value.ToString());
            //elimina il testo della casella
            grid.CurrentCell.Value = null;
            //abilita l'incolla
            paste.Enabled = true;
        }

        /// <summary>
        /// Metodo per incollare i valori da clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paste_Click(object sender, EventArgs e)
        {
            //imposta il valore della casella selezionata 
            //con il valore prelevato dalla clipboard
            grid.CurrentCell.Value = Clipboard.GetText();
            //ripulisce la clipboard
            Clipboard.Clear();
            //disabilita l'incolla
            paste.Enabled = false;
        }

        /// <summary>
        /// Metodo privato per il salvataggio di causali frequenti
        /// </summary>
        private void saveOftenCauseInDB(object sender, EventArgs e)
        {
            //istanza alla classe per il salvataggio nel DB
            ModelOftenElement model = new ModelOftenElement();
            bool verify = false;
            //ottengo i dati della colonna relativa alla cella selezionata
            DataGridViewColumn col = grid.CurrentCell.OwningColumn;

            //se il nome della colonna contiene la parola CAUSALE, salva il valore nel DB
            if (col.Name.Contains("CAUSALE"))
            {
                //ottiene il valore della cella
                string val = grid.CurrentCell.Value.ToString();
                //invoca il metodo per il salvataggio
                verify = model.saveOftenCause(val);
                if (verify == true) //verifica il salvataggio ok
                {
                    MessageBox.Show("Salvataggio avvenuto con successo");
                }
                else
                {
                    MessageBox.Show("Causale già presente nel DataBase");
                }
            }

        }

    }
}
