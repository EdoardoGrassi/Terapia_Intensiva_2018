using System;
using Gtk;
using System.Collections.Generic;

namespace Terapia_Intensiva_2018
{
    public class CheckedWindow : TerapiaWindow
    {
        private List<bool> checkList;

        public List<bool> CheckList { get { return this.checkList; } }

        public CheckedWindow()
            : base()
        {
            checkList = new List<bool>();
        }

        //draw an object only if checkList is empty or all true;
        public void Scan(Gtk.Widget widget)
        {
            widget.HideAll();
            if ((CheckList.Capacity == 0) || (!CheckList.Contains(false)))
                widget.ShowAll();
 
            return;
        }
    }
}

