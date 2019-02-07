using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Terapia_Intensiva_2018
{
    public class DataSaver<T>
    {
        private DataContractSerializer writer;

        public DataSaver()
        {
            this.writer = new DataContractSerializer(typeof(T));
        }

        public void save(T toBeSaved)
        {
            var path = "../../XmlData/" + toBeSaved.GetType().ToString();
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.WriteObject(file, toBeSaved);  
            file.Close(); 
        }

        public void save(T toBeSaved, String path)
        {
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.WriteObject(file, toBeSaved);  
            file.Close(); 
        }

    }
}

