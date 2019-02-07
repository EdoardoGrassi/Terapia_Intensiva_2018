using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class TerapiaWindow : Gtk.Window
    {
        public TerapiaWindow()
            : base(Gtk.WindowType.Toplevel)
        {
            this.SetIconFromFile("../../icons/main_icon.ico");


            //Events
            this.DeleteEvent += new DeleteEventHandler(WindowCloser);


        }

        public virtual void WindowCloser(object obj, DeleteEventArgs args)
        {
            Application.Quit();
        }

    }
}

