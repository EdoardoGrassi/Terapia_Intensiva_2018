﻿using System;
using System.Collections.Generic;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class PatientListToInsertDiag : PatientList
    {
        private InsertDiag insertDiagform;

        public PatientListToInsertDiag()
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
                    this.insertDiagform.UpdateTitle(info);
                };
            }
            // ############
            this.ShowAll();
        }

        public override void WindowCloser(object obj, DeleteEventArgs args)
        {
            this.Hide();
        }

        public virtual void ButtonInList_CLicked(object sender, EventArgs e)
        {
            Console.WriteLine("Paziente selezionato");
            // TODO: it should open Visualize Patient Window and hide the list
            this.insertDiagform = new InsertDiag();
            this.Hide();
            this.insertDiagform.ShowAll();
            this.insertDiagform.SubmitButton.Clicked += (o, args) =>
            {
                this.ShowAll();
                this.insertDiagform.Hide();
            };
            this.insertDiagform.DeleteEvent += (o, args) =>
            {
                this.ShowAll();
                this.insertDiagform.Hide();
            };

            this.insertDiagform.SubmitButton.Clicked += (object sender2, EventArgs e2) =>
            {
                this.Hide();
            };

        }

    }
}

