using System;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Terapia_Intensiva_2018
{
    public class DataReader<T>
    {
        private DataContractSerializer reader;

        public DataReader()
        {
            this.reader = new DataContractSerializer(typeof(T));
        }

        public T readXML(T toBeRead)
        {
            var path = "../../XmlData/" + toBeRead.GetType().ToString();
            FileStream file = new FileStream(path, FileMode.Open);  

            T fileRead = (T)reader.ReadObject(file);

            file.Close(); 
            return fileRead;
        }

        public T readXML(String path)
        {
            FileStream file;
            T fileRead;
            file = new FileStream(path, FileMode.Open);  
            fileRead = (T)reader.ReadObject(file);
            file.Close();
            
            return fileRead;
        }


    }
}

