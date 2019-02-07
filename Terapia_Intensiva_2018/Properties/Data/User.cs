using System;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace Terapia_Intensiva_2018
{
    [DataContract]
    public abstract class User
    {
        private const String idCounterPath = "../../Properties/Archive/IdCounter.xml";
        [DataMember]
        protected String username;
        [DataMember]
        protected int id;
        [DataMember]
        //hash code of the password
        protected int psw;

        public int Id { get { return id; } }

        public int Psw { get { return psw; } }


        public User(String password)
        {


            if (File.Exists(idCounterPath))
            {
                DataReader<int> reader = new DataReader<int>();
                DataSaver<int> saver = new DataSaver<int>();
                this.id = reader.readXML(idCounterPath) + 1;
                saver.save(this.id, idCounterPath);
            }
            else
                this.id = 0;
            
            this.psw = password.GetHashCode();

        }

        public String GetUsername()
        {
            return this.username;
        }
    }
}

