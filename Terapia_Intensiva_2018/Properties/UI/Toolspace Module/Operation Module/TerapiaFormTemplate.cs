using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public abstract class TerapiaFormTemplate : TerapiaWindow
    {
        //private string title;
        private const string conferma = "Conferma";

        public bool isInstantiated = false;
        protected const int width = 350;
        protected const int height = 500;

        protected Table bgTable;


        protected Button submitButton;

        public Button SubmitButton { get { return submitButton; } }

        public TerapiaFormTemplate()
            : base()
        {
            // Window settings
            //this.Title = title;
            this.Resizable = false;
            this.SetSizeRequest(width, height);
            this.BorderWidth = 10;

            // Background
            this.bgTable = new Table(10, 4, true);
            bgTable.ColumnSpacing = 10;
            bgTable.RowSpacing = 20;
            this.Add(bgTable);

            // Buttons
            this.submitButton = new Button(conferma);
            bgTable.Attach(submitButton, 2, 4, 9, 10);

            // Events
            this.submitButton.Clicked += SubmitButton_Clicked;

            // Show Settings
            this.ShowAll();

        }

        public virtual void SubmitButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Override me!!");
        }

        public override void WindowCloser(object obj, DeleteEventArgs args)
        {
            this.Hide();
        }
    }
}
