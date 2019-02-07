using System;

namespace Terapia_Intensiva_2018
{
    public struct IdHash
    {
        public int id;
        public int hash;

        public IdHash(int id, int hash)
        {
            this.id = id;
            this.hash = hash; 
        }
    }
}

