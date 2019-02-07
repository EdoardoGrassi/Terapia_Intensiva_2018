using System;

namespace Terapia_Intensiva_2018
{
    public class Primario : Medico
    {
        private String reparto;


        public Primario(String username, String password, String name, String surname, String specializzazione, String reparto)
            : base(username, password, name, surname, specializzazione)
        {
            this.reparto = reparto;
        }

        public String getReparto()
        {
            return this.reparto;
        }

    }
}

