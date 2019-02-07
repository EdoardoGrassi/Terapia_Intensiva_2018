using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class VisualizePatient : TerapiaFormTemplate
    {

        // Title
        private const string title = "Visualizza Paziente";

        // Strings for Labels
        private const string name = "Nome Paziente";
        private const string surname = "Cognome Paziente";
        private const string idCode = "Codice Fiscale";
        private const string birthDate = "Data Di Nascita Paziente";
        private const string birthPlace = "Luogo Di Nascita Paziente";
        private const string allocateBed = "Alloca postazione";

        // Strings for Buttons
        private const string prescriptions = "Prescrizioni";

        // Labels
        private Label nameLabel;
        private Label surnameLabel;
        private Label idCodLabel;
        private Label birthDateLabel;
        private Label birthPlaceLabel;
        private Label allocateBedLabel;

        // Buttons

        private Button allocateBedButton;
        public Button AllocateBedButton { get { return this.allocateBedButton; } }
        private Button prescriptionButton;

        public Button PrescriptionButton { get { return prescriptionButton; } }

        public Button SubmitButton { get { return submitButton; } }

        public VisualizePatient()
            : base()
        {
            // Window settings
            this.Title = title;
            //this.SetSizeRequest(300, 300);

            this.nameLabel = new Label(name);
            bgTable.Attach(nameLabel, 0, 3, 0, 1);

            // Label

            // Surname
            this.surnameLabel = new Label(surname);
            bgTable.Attach(surnameLabel, 0, 3, 1, 2);

            // idCode ( = codice fiscale)
            this.idCodLabel = new Label(idCode);
            bgTable.Attach(idCodLabel, 0, 3, 2, 3);

            // birthDate
            this.birthDateLabel = new Label(birthDate);
            bgTable.Attach(birthDateLabel, 0, 3, 3, 4);

            // birthPlace
            this.birthPlaceLabel = new Label(birthPlace);
            bgTable.Attach(birthPlaceLabel, 0, 3, 4, 5);

            // see prescriptionButton

            this.prescriptionButton = new Button(prescriptions);
            bgTable.Attach(prescriptionButton, 0, 2, 9, 10);

            // allocateBedButton
            this.allocateBedLabel = new Label(allocateBed);
            this.allocateBedButton = new Button(allocateBedLabel);
            bgTable.Attach(allocateBedButton, 0, 2, 8, 9);

            // events
            this.prescriptionButton.Clicked += ( o, args) =>
            {
                // TODO:if there's no prescprition show a popup
                NoPrescpriptionShoutOut();
                // TODO:else, open prescription window
            };

            

            this.ShowAll();
            
        }


        public void UpdateTitle(string patient)
        {
            this.Title = title + ": " + patient;
        }

        public void NoPrescpriptionShoutOut()
        {
            var msg = new MessageDialog(
                          null,
                          DialogFlags.Modal,
                          MessageType.Warning,
                          ButtonsType.None,
                          "Nessuna prescrizione!");
            msg.ShowAll();

        }

    }
}

