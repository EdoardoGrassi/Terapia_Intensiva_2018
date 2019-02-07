using System;

namespace Terapia_Intensiva_2018
{
    public class Somministrazione
    {
        private Prescrizione prescrizione;
        private DateTime data;
        private TimeSpan ora;
        private PersonaleMedico addetto;
        private float dose;
        private String note;

        public Somministrazione(Prescrizione prescrizione, DateTime dataOra, PersonaleMedico addetto, float dose, String note)
        {
            this.prescrizione = prescrizione;
            this.data = dataOra.Date;
            this.ora = dataOra.TimeOfDay;
            this.addetto = addetto;
            this.dose = dose;
            this.note = note;
        }

        public Somministrazione(Prescrizione prescrizione, DateTime dataOra, PersonaleMedico addetto, float dose)
        {
            this.prescrizione = prescrizione;
            this.data = dataOra.Date;
            this.ora = dataOra.TimeOfDay;
            this.addetto = addetto;
            this.dose = dose;
            this.note = "";
        }

        public Somministrazione(Prescrizione prescrizione, PersonaleMedico addetto, float dose, String note)
        {
            this.prescrizione = prescrizione;
            DateTime dataOra = DateTime.Now;
            this.data = dataOra.Date;
            this.ora = dataOra.TimeOfDay;
            this.addetto = addetto;
            this.dose = dose;
            this.note = note;
        }

        public Somministrazione(Prescrizione prescrizione, PersonaleMedico addetto, float dose)
        {
            this.prescrizione = prescrizione;
            DateTime dataOra = DateTime.Now;
            this.data = dataOra.Date;
            this.ora = dataOra.TimeOfDay;
            this.addetto = addetto;
            this.dose = dose;
            this.note = "";
        }

    }
}

