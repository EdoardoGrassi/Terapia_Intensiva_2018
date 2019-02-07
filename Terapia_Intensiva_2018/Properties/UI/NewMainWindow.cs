using System;
using Gtk;


namespace Terapia_Intensiva_2018
{
    public class NewMainWindow : TerapiaWindow
    {
        private const int cellX = 10;
        private const int cellY = 10;

        private Table background;
        private Monitor monitor;

        public Monitor Monitor { get { return this.monitor; } set { this.monitor = value; } }

        private Toolspace toolspace;

        public Toolspace Toolspace { get; private set; }

        private WarningBar warning;


        public NewMainWindow()
            : base()
        {
            // Set Screen size --> WARNING: this block works only on linux
            /*int actualWidth, actualHeight;
            Screen.ActiveWindow.GetSize(out actualWidth, out actualHeight);
            this.SetDefaultSize(actualWidth, actualHeight);
            */

            // Background table
            this.background = new Table(cellX, cellY, false);
            this.Add(background);
            background.RowSpacing = 10;
            background.ColumnSpacing = 10;

            // Monitor
            this.monitor = new Monitor();
            background.Attach(monitor, 0, cellX - 1, 0, cellY - 1);

            // Toolspace
            this.toolspace = new Toolspace();
            background.Attach(toolspace, cellX - 1, cellX, 0, cellY - 1);

            // Warning
            this.warning = new WarningBar();
            background.Attach(warning, 0, cellX, cellY - 1, cellY);

            

            // Set Visibility: Show Everything
            this.ShowAll();

        }
            

    }
}

