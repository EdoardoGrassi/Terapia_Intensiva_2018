using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class WarningBar : Frame
    {
        private VBox warningBox;
        private Label warningLabel;

        public Label WarningLabel { get; set; }

        public WarningBar()
            : base("Warnings")
        {
            this.warningBox = new VBox();
            this.warningLabel = new Gtk.Label("No warnings detected.");

            this.Add(warningBox);
            this.warningBox.Add(warningLabel);

        }
    }
}

