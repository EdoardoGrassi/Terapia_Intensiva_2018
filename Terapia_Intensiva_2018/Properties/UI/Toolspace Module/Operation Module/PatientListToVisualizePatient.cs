using System;
using System.Collections.Generic;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class PatientListToVisualizePatient : PatientList
    {
        private VisualizePatient visualizePatientForm;

        public PatientListToVisualizePatient()
            : base()
        {
            // TODO: DO NOT INCLUDE THIS IN LATEST VERSION!! 
            // ############
            this.listOfButton = new List<Button>();
            for (int i = 0; i < 200; i++)
            {
                Button buttonInList = new Button("Patient #" + (i + 1).ToString());
                String info = buttonInList.Label.ToString();

                patientContainer.Add(buttonInList);
                buttonInList.Clicked += ButtonInList_CLicked;
                buttonInList.Clicked += (o, args) =>
                {
                    this.visualizePatientForm.UpdateTitle(info);
                    // TODO: da generalizzare qui
                };
            }
            // ######################
            this.ShowAll();
        }

        public Button AllocateBedButton { get { return this.visualizePatientForm.AllocateBedButton; } }

        public override void WindowCloser(object obj, DeleteEventArgs args)
        {
            this.Hide();
        }

        public virtual void ButtonInList_CLicked(object sender, EventArgs e)
        {
            Console.WriteLine("Paziente selezionato");
            // TODO: it should open Visualize Patient Window and hide the list
            this.visualizePatientForm = new VisualizePatient();
            this.Hide();
            this.visualizePatientForm.ShowAll();
            this.visualizePatientForm.SubmitButton.Clicked += (o, args) =>
            {
                this.ShowAll();
                this.visualizePatientForm.Hide();
            };
            this.visualizePatientForm.DeleteEvent += (o, args) =>
            {
                this.ShowAll();
                this.visualizePatientForm.Hide();
            };

        }

    }
}

