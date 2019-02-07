using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    // Define a class to hold custom event info --> Generated Signal Value
    public class PatientInfo : EventArgs
    {
        private String info;

        public String Info { get { return this.info; } }

        public PatientInfo(string info)
            : base()
        {
            this.info = info;
        }
    }
}


