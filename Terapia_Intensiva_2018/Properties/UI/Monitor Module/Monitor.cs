using System;
using Gtk;
using Grafici;
using System.Collections.Generic;

namespace Terapia_Intensiva_2018
{
    public class Monitor : Frame
    {
        private const int row = 10;
        private const int col = 10;
        private const bool homogeneous = true;
        private const int numberOfPatients = 20;
        private const string add = "+";
        private const string remove = "-";

        private bool[] activePatients;
        private int patientDisplayedIndex;
        private string[] beds;
        private Table bg;
        private ComboBox menu;

        private Label addLabel;
        private Button addButton;
        private Label removeLabel;
        private Button removeButton;

        private DeviceManager publisher;
        private Quadro[] patients;
        private TestSubscriber[] subscribers;

        private PatientListToVisualizePatient archiveOfPatient;

        public Monitor()
            : base("Monitor")
        {
            this.bg = new Table(row, col, homogeneous);
            this.Add(bg);

            this.activePatients = new bool[numberOfPatients];
            this.beds = new string[numberOfPatients];

            for(int i=0; i<numberOfPatients; i++)
            {
                this.beds[i] = "Bed #" + i.ToString();
                this.activePatients[i] = false;
            }

            this.menu = new ComboBox(beds);
            this.bg.Attach(this.menu, 0, 5, 0, 1);

            this.addLabel = new Label(add);
            this.addButton = new Button(addLabel);
            this.bg.Attach(this.addButton, 5, 6, 0, 1);

            this.removeLabel = new Label(remove);
            this.removeButton = new Button(removeLabel);
            this.bg.Attach(this.removeButton, 7, 8, 0, 1);

            this.publisher = new DeviceManager(numberOfPatients);

            this.patients = new Quadro[numberOfPatients];
            this.subscribers = new TestSubscriber[numberOfPatients];

            // Events

            this.menu.Changed += Menu_Changed;
            this.menu.Changed += (object o, EventArgs e) => {
                Console.WriteLine("Changed!");
            };

            this.addButton.Clicked += AllocatePatient;

            this.ShowAll();
        }

        private void AllocatePatient(object sender, EventArgs e)
        {
            this.archiveOfPatient = new PatientListToVisualizePatient();
            this.archiveOfPatient.AllocateBedButton.Clicked += AddActivePatient;
        }

        private void Menu_Changed(object sender, EventArgs e)
        {
            if (this.menu.Active is int) DisplayQuadro(this.menu.Active);
            else Console.WriteLine("Seleziona un paziente!");
        }

        public void DisplayQuadro(int numberOfTheQuadro) //numeration range:[0..19]
        {
            if (!activePatients[numberOfTheQuadro]) Console.WriteLine("Nessun paziente da visualizzare!"); // TODO: Make a message alert 
            else
            {
                this.patients[patientDisplayedIndex].Hide();
                this.patients[numberOfTheQuadro].Show();
                this.patientDisplayedIndex = numberOfTheQuadro;
            }
            
        }

        public void AddActivePatient(object sender, EventArgs e)
        {
            // Iterate on active patients, find an empty bed
            // stop on found and initialize patient things
            for(int i=0; i<patients.Length; i++)
            {
                if (!activePatients[i])
                { 
                    this.patients[i] = new Quadro();
                    this.publisher.startSignalAutoma(i);
                    this.subscribers[i] = new TestSubscriber(publisher.getDeviceN(i), patients[i]);
                    this.patients[i].Hide();
                    this.bg.Attach(this.patients[i], 0, 10, 1, 10);
                    //this.patients[i].Hide();
                    this.activePatients[i] = true;
                    return;
                }
            }
            // TODO: implementa l'alert
            Console.WriteLine("Tutte le postazioni sono piene!");
        }

        private void RemovePatient(int i)
        {
            this.activePatients[i] = false;
            this.patients[i].Hide();
            this.subscribers[i].Unsubscribe(this.publisher.getDeviceN(i));
        }
    }

    
}

