using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Terapia_Intensiva_2018
{
    [DataContract]
    public class Medico : PersonaleMedico
    {
        [DataMember]
        protected String specializzazione;


        public Medico(String username, String Password, String name, String surname, String specializzazione)
            : base(Password)
        {
            this.surname = surname;
            this.name = name;
            this.surname = surname;
            this.specializzazione = specializzazione;
            this.username = username.ToLower().Replace(" ", "");
        }

        public override String getQualification()
        {
            return this.specializzazione;
        }
    }
}

