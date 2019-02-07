using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public partial class MyToolbar : Gtk.Table
    {
        private const int x = 3;
        private const int y = 4;
        private const int numberOfIcons = x*y;
        private Gtk.Image[] icons;


        public MyToolbar()
            : base(x, y, true)
        {
            this.icons = new Image[numberOfIcons];

            int k = 0;
            for(int i = 0; i<x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    icons[k] = new Image("options");
                    this.Attach(icons[k], i, i + 1, j, j + 1);
                }
                      k++;
            }
            
        }
    }
}

