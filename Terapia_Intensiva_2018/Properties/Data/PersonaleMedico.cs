using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Terapia_Intensiva_2018
{
    [DataContract]
    public abstract class PersonaleMedico : User
    {
        [DataMember]
        protected String name;
        [DataMember]
        protected String surname;

        public PersonaleMedico(String password)
            : base(password)
        {
        }

        public String getName()
        {
            return this.name;
        }

        public String getSurname()
        {
            return this.surname;
        }

        public abstract String getQualification();

    }
}

