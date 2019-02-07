using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class InsertPatient : TerapiaFormTemplate
    {
        private const string title = "Nuovo Paziente";
        private const string confirm = "Conferma";
        private const string name = "Nome";
        private const string surname = "Cognome";
        private const string idCode = "Codice Fiscale";
        private const string birthDate = "Data Di Nascita";
        private const string birthPlace = "Luogo Di Nascita";

        private Label nameLabel;
        private Label surnameLabel;
        private Label idCodLabel;
        private Label birthDateLabel;
        private Label birthPlaceLabel;

        private Entry nameEntry;
        private Entry surnameEntry;
        private Entry idCodEntry;
        private Entry birthDateEntry;
        private Entry birthPlaceEntry;

        public InsertPatient()
            : base()
        {
            // Window settings
            this.Title = title;
            this.Resizable = false;
            this.SetSizeRequest(width, height);
            this.BorderWidth = 10;

            // Background
            //this.bgTable = new Table(10, 4, true);
            bgTable.ColumnSpacing = 10;
            bgTable.RowSpacing = 20;
            //this.Add(bgTable);

            // --> Label + Entry <--
            // Name
            this.nameLabel = new Label(name);
            bgTable.Attach(nameLabel, 0, 2, 0, 1);
            this.nameEntry = new Entry();
            nameEntry.MaxLength = 30;
            bgTable.Attach(nameEntry, 2, 4, 0, 1);

            // Surname
            this.surnameLabel = new Label(surname);
            bgTable.Attach(surnameLabel, 0, 2, 1, 2);
            this.surnameEntry = new Entry();
            bgTable.Attach(surnameEntry, 2, 4, 1, 2);

            // idCode ( = codice fiscale)
            this.idCodLabel = new Label(idCode);
            bgTable.Attach(idCodLabel, 0, 2, 2, 3);
            this.idCodEntry = new Entry();
            bgTable.Attach(idCodEntry, 2, 4, 2, 3);

            // birthDate
            this.birthDateLabel = new Label(birthDate);
            bgTable.Attach(birthDateLabel, 0, 2, 3, 4);
            this.birthDateEntry = new Entry();
            bgTable.Attach(birthDateEntry, 2, 4, 3, 4);

            // birthPlace
            this.birthPlaceLabel = new Label(birthPlace);
            bgTable.Attach(birthPlaceLabel, 0, 2, 4, 5);
            this.birthPlaceEntry = new Entry();
            bgTable.Attach(birthPlaceEntry, 2, 4, 4, 5);

            // Buttons
            this.submitButton = new Button(confirm);
            bgTable.Attach(submitButton, 2, 4, 9, 10);

            // Events
            this.submitButton.Clicked += SubmitButton_Clicked;

            // Show Settings
            this.ShowAll();
        }

        public override void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if ((nameEntry.Text.ToString() == "") || (surnameEntry.Text.ToString() == "") ||
                (idCodEntry.Text.ToString() == "") || (birthDateEntry.Text.ToString() == "") ||
                (birthPlaceEntry.Text.ToString() == ""))
            {

                var msg = new MessageDialog(
                              null,
                              DialogFlags.Modal,
                              MessageType.Info,
                              ButtonsType.None,
                              "Riempire tutte le entry");
                msg.ShowAll();
            }
            else
            {
                // Insert here some code to save patient data in the database

                // then this window will close ( hide in truth)
                WindowCloser();
            }
        }

        public void WindowCloser()
        {
            this.Hide();
        }

    }
}

