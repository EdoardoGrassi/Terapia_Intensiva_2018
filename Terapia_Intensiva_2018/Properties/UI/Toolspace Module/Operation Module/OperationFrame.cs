using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class OperationFrame : Frame
    {
        private const string inserisciPaziente = "Inserisci paziente";
        private const string inserisciDiagnosiIngr = 
            "Inserisci diagnosi di ingresso";
        private const string somministrazione = "Registra somministrazione";
        private const string prescrizioneFarmaco = "Prescrizione";
        private const string archivioPazienti = "Archivio Pazienti";
        private const string dimettiPaziente = "Dimetti Paziente";

        private Label insertPatientLabel;
        private Label insertDiagLabel;
        private Label distributionLabel;
        private Label prescriptionLabel;
        private Label patientArchiveLabel;
        private Label dismissPatientLabel;

        private Button insertPatientButton;
        private Button insertDiagButton;
        private Button distributionButton;
        private Button prescriptionButton;
        private Button patientArchiveButton;
        private Button dismissPatientButton;

        private VButtonBox buttonBox;
        private InsertPatient insertPatientForm;
        private PatientListToInsertDiag insertDiagForm;
        private PatientListToVisualizePatient listOfPatient;
        private PatientListToReleasePatient releasePatient;

        public OperationFrame()
            : base("Personale Medico")
        {
            this.BorderWidth = 10;

            this.buttonBox = new VButtonBox();
            this.buttonBox.BorderWidth = 20;

            this.insertPatientLabel = new Label(inserisciPaziente);
            this.insertDiagLabel = new Label(inserisciDiagnosiIngr);
            this.distributionLabel = new Label(somministrazione);
            this.prescriptionLabel = new Label(prescrizioneFarmaco);
            this.patientArchiveLabel = new Label(archivioPazienti);
            this.dismissPatientLabel = new Label(dimettiPaziente);

            this.insertPatientButton = new Button();
            this.insertDiagButton = new Button();
            this.distributionButton = new Button();
            this.prescriptionButton = new Button();
            this.patientArchiveButton = new Button();
            this.dismissPatientButton = new Button();

            insertPatientButton.Add(insertPatientLabel);
            insertDiagButton.Add(insertDiagLabel);
            distributionButton.Add(distributionLabel);
            prescriptionButton.Add(prescriptionLabel);
            patientArchiveButton.Add(patientArchiveLabel);
            dismissPatientButton.Add(dismissPatientLabel);

            this.buttonBox.PackStart(insertPatientButton, false, false, 20);
            this.buttonBox.Add(insertPatientButton);
            this.buttonBox.PackStart(insertDiagButton, false, false, 20);
            this.buttonBox.Add(insertDiagLabel);
            this.buttonBox.PackStart(distributionButton, false, false, 20);
            this.buttonBox.Add(distributionButton);
            this.buttonBox.PackStart(prescriptionButton, false, false, 20);
            this.buttonBox.Add(prescriptionButton);
            this.buttonBox.PackStart(patientArchiveButton, false, false, 20);
            this.buttonBox.Add(patientArchiveButton);
            this.buttonBox.PackStart(dismissPatientButton, false, false, 20);
            this.buttonBox.Add(dismissPatientButton);

            insertPatientButton.Clicked += InsertPatientButton_Clicked;

            insertDiagButton.Clicked += InsertDiagButton_Clicked;

            patientArchiveButton.Clicked += PatientArchiveButton_Clicked;

            dismissPatientButton.Clicked += DismissPatient_Clicked;

            this.buttonBox.ShowAll();

        }

        void PatientArchiveButton_Clicked(object sender, EventArgs e)
        {
            this.listOfPatient = new PatientListToVisualizePatient();
            this.listOfPatient.DeleteEvent += (o, args) =>
            {
                this.listOfPatient.Dispose();
            };
            listOfPatient.ShowAll();
        }

        void InsertDiagButton_Clicked(object sender, EventArgs e)
        {
            
            this.insertDiagForm = new PatientListToInsertDiag();
            this.insertDiagForm.DeleteEvent += (o, args) =>
            {
                this.insertDiagForm.Dispose();
            };
            insertDiagForm.ShowAll();


        }

        void DismissPatient_Clicked(object sender, EventArgs e)
        {

            this.releasePatient = new PatientListToReleasePatient();
            this.releasePatient.DeleteEvent += (o, args) =>
            {
                this.releasePatient.Dispose();
            };
            releasePatient.ShowAll();


        }


        void InsertPatientButton_Clicked(object sender, EventArgs e)
        {
            this.insertPatientForm = new InsertPatient();
            this.insertPatientForm.DeleteEvent += (o, args) =>
            {
                this.insertPatientForm.Dispose();
            };
            insertPatientForm.ShowAll();
        }

        public void Login()
        {
            this.ShowAll();
            this.Add(buttonBox);
        }

        public void Logout()
        {
            Console.WriteLine("Omegalul");

            this.Remove(buttonBox);
            this.HideAll();

        }
    }
}
