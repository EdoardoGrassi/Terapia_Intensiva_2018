using System;
using Gtk;
using GLib;
using NPlot.Gtk;


namespace Terapia_Intensiva_2018
{
    public class MainWindow : TerapiaWindow
    {
        private const string loginText = "Login";
        private const string loginButtonText = "Check";
        private const string warningFillerText = "This is a filler text";
        private const int cellX = 10;
        private const int cellY = 10;
        private const int numberOfBox = 20;

        private Table background;

        private Frame monitorFrame;
        private VBox monitor;
        private VBox monitorDeck;

        private Frame toolbarFrame;
        private VBox toolbar;

        private Frame loginFrame;
        private VBox loginBox;
        private Label loginLabel;
        private HButtonBox loginButtonBox;
        private Button loginButton;

        private Image accountImage;
        private HBox imageBox;

        private Frame warningFrame;
        private VBox warningBox;
        private Label warningLabel;

        private Authentication Login;
        private MonitorScrollableSpace monitorSpace;

        //It represents User Info Box --> connection throught backend and frontend

        private PlotBox[] graphs;

        //Data Consistency and funcionalities
        private AddNewDataFrame newDataFrame;

        public MainWindow(PlotBox[] graphs)
            : base()
        {

            //MainWindow Proprieties
            this.SetDefaultSize(400, 400);
            //this.SetIconFromFile ("../../icons/main_icon.ico");
            this.BorderWidth = 4;

            //background
            this.background = new Table(cellX, cellY, false);
            this.Add(background);
            background.RowSpacing = 10;
            background.ColumnSpacing = 10;

            //monitor
            this.monitorFrame = new Frame();
            background.Attach(monitorFrame, 0, cellX - 1, 0, cellY - 1);
            this.monitor = new VBox();
            monitorFrame.Add(monitor);
            this.monitorDeck = new VBox();
            monitor.Add(monitorDeck);

            this.monitorSpace = new MonitorScrollableSpace(monitorDeck);

            //this.surface2d = new PlotSurface2D();
      
            //int[] x = { 1, 3, 5, 7, 9, 11, 13 };
            //int[] y = { 3, 4, 10, 11, 34, 1, 0 };


            //test filler
            //Image[] prova = new Image[20];
            //PlotWindow[] graphs = new PlotWindow[20];
            this.graphs = graphs;

            for (int i = 0; i < numberOfBox; i++)
            {
                //prova[i] = new Image("../../icons/Heartbeat.jpg");
                graphs[i] = new PlotBox(i + 1);
                monitorSpace.getContainer().PackStart(graphs[i], true, true, 4);
                monitorSpace.getContainer().Add(graphs[i]);

            }

            //warning
            this.warningFrame = new Frame();
            background.Attach(warningFrame, 0, cellX, cellY - 1, cellY);
            this.warningBox = new VBox();
            warningFrame.Add(warningBox);
            this.warningLabel = new Label(warningFillerText);
            warningBox.Add(warningLabel);

            //toolbar
            this.toolbarFrame = new Frame("Toolbar");
            this.toolbar = new VBox();
            background.Attach(toolbarFrame, cellX - 1, cellX, 0, cellY - 1);
            toolbarFrame.Add(toolbar);
            toolbar.Spacing = 10;

            //login
            this.loginFrame = new Frame("Account");
            loginFrame.BorderWidth = 10;
            this.loginBox = new VBox();
            this.loginButtonBox = new HButtonBox();
            this.loginButton = new Button();
            toolbar.PackStart(loginFrame, false, false, 20);
            toolbar.Add(loginFrame);
            loginFrame.Add(loginBox);
            loginBox.PackStart(loginButtonBox, false, false, 10);
            loginBox.Add(loginButtonBox);
            loginButtonBox.PackStart(loginButton, false, false, 0);
            loginButtonBox.Add(loginButton);

            //image button
            this.imageBox = new HBox();
            this.accountImage = new Image("../../icons/account.png");
                
            loginButton.Add(imageBox);
            imageBox.PackStart(accountImage, false, false, 3);
            imageBox.Add(accountImage);
            //accountImage.SetSizeRequest(128, 128);

            this.loginLabel = new Label(loginText);
            imageBox.PackStart(loginLabel, false, false, 0);
            imageBox.Add(loginLabel);

            //Buttons
            loginButton.Clicked += new EventHandler(OpenLoginWindow);


        }

        public Authentication getLogin()
        {
            if (this.Login != null)
                return Login;
            else
            {
                this.Login = new Authentication();
                return Login;
            }
        }


        public static void WindowCloser(object obj, DeleteEventArgs args)
        {
            SignalArgs sa = (SignalArgs)args;
            Application.Quit();
            sa.RetVal = true;
        }

        public void OpenLoginWindow(object obj, EventArgs args)
        {
            this.getLogin().Show();
            this.PlotBoxes[1] = new PlotBox(1);
            //this.Hide ();
        }

        public VBox getToolbar()
        {
            return this.toolbar;
        }

        public PlotBox[] PlotBoxes
        {
            get { return this.graphs; }
        }

    }
}
