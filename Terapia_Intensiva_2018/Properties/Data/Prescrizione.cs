using System;

namespace Terapia_Intensiva_2018
{
    public class Prescrizione
    {
        private Farmaco farmaco;
        private DateTime data;
        private DateTimeOffset durataGiorni;
        private int dosiGiornaliere;
        private float quantitaDose;
        private Medico responsabile;

        public Prescrizione(Farmaco farmaco, DateTime dataFine, int dosiGiornaliere, float quantitaDose, Medico responsabile)
        {
            this.farmaco = farmaco;
            this.data = DateTime.Now;
            TimeSpan offset = dataFine - data;
            this.durataGiorni = new DateTimeOffset(data, offset);
            this.dosiGiornaliere = dosiGiornaliere;
            this.quantitaDose = quantitaDose;
            this.responsabile = responsabile;
        }

        public Prescrizione(Farmaco farmaco,DateTime dataInizio ,DateTime dataFine, int dosiGiornaliere, float quantitaDose, Medico responsabile)
        {
            this.farmaco = farmaco;
            this.data = dataInizio;
            TimeSpan offset = dataFine - data;
            this.durataGiorni = new DateTimeOffset(data, offset);
            this.dosiGiornaliere = dosiGiornaliere;
            this.quantitaDose = quantitaDose;
            this.responsabile = responsabile;
        }

    }
}

