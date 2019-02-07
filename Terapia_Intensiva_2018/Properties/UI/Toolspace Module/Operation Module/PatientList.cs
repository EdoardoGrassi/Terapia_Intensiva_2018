using System;
using System.Collections.Generic;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class PatientList : TerapiaWindow
    {
        protected VBox background;

        protected ScrolledWindow patientScrollableSpace;
        protected Viewport patientViewport;
        protected VBox patientContainer;

        protected List<Button> listOfButton;

        public PatientList()
            : base()
        {
            this.SetSizeRequest(500, 500);
            this.background = new VBox();
            this.Add(background);
            this.Resizable = false;

            this.patientScrollableSpace = new ScrolledWindow();
            background.Add(patientScrollableSpace);

            this.patientViewport = new Viewport();
            patientScrollableSpace.Add(patientViewport);

            this.patientContainer = new VBox();
            patientViewport.Add(patientContainer);

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

        }

        public Viewport getViewport()
        {
            return this.patientViewport;
        }

        public VBox getContainer()
        {
            return this.patientContainer;
        }
   

    }
}
