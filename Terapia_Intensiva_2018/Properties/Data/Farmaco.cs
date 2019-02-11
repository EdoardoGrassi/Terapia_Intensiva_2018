using System;

namespace Terapia_Intensiva_2018
{
    public class Farmaco
    {
        public readonly uint AicCode;

        public readonly string CommercialName;


        public Farmaco(uint code, string name)
        {
            this.AicCode = code;
            this.CommercialName = name;
        }
    }
}

