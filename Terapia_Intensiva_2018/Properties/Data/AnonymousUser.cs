using System;
using System.Runtime.Serialization;
using System.Xml;

namespace Terapia_Intensiva_2018
{
    [DataContract]
    public class AnonymousUser : User
    {
        [DataMember]
        private int id;

        public AnonymousUser(String password)
            : base(password)
        {
            this.username = "No Username";
            int id = Int32.MaxValue;
        }

        public AnonymousUser(String username, int id, String password)
            : base(password)
        {
            this.username = username;
        }
    }
}

