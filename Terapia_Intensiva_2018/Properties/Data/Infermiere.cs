using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Terapia_Intensiva_2018
{
    [DataContract]
    public class Infermiere : PersonaleMedico
    {
        [DataMember]
        private const String qualification = "Infermiere";

       

        public Infermiere(String username, String password, String name, String surname)
            : base(password)
        {
            this.surname = surname;
            this.name = name;
            this.surname = surname;
            this.username = username.ToLower().Replace(" ", "");
        }


        public override String getQualification()
        {
            return qualification;
        }
    }
}

