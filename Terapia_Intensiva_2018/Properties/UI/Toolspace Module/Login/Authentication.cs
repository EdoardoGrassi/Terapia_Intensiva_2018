using System;
using Gtk;
using GLib;
using System.Collections.Generic;


namespace Terapia_Intensiva_2018
{
    
    public class Authentication : CheckedWindow
    {
        public bool isInstantiated = false;

        private VBox mainBox;
        private Frame formFrame;
        private Label userInfo;
        private Entry username;
        private Entry password;
        private Label usernameLabel;
        private Label passwordLabel;
        private VBox entryBox;
        private VBox labelEntryBox;
        private HBox loginBox;
        private HButtonBox commitBox;
        private Button commit;

        public Button GetCommit
        {
            get{ return commit; }
        }

        private Button cancel;

        private CheckButton isMedic;
        private bool showMedic;

        public bool ShowMedic
        { 
            get { return this.showMedic; }
            set{ this.showMedic = value; } 
        }
        //cose che forse non dovrebbero essere qui
        private Window dialog;

        private bool isOk;

        public bool IsOk
        {
            get { return isOk; }
            set { isOk = value; }
        }

        public Authentication()
            : base()
        {

            //this.SetIconFromFile ("../../icons/main_icon.ico");
            this.Title = "Login";
            this.BorderWidth = 10;
            //this.SetDefaultSize (200, 200);
            this.Resizable = false;

            isOk = false;

            mainBox = new VBox();
            formFrame = new Frame(); //only container in this window to have a frame -> aesthetic purpose
            //Start with labels
            userInfo = new Label("Benvenuto! Autenticati per ottenere l'accesso: ");
            //labelFrame.Add (userInfo);
            mainBox.Add(userInfo);

            //entries
            username = new Entry();
            this.CheckList.Add(false);
            password = new Entry();
            this.CheckList.Add(false);

            password.Visibility = false;

            usernameLabel = new Label("Username");
            passwordLabel = new Label("Password");

            entryBox = new VBox(); 
            labelEntryBox = new VBox();

            //continue with login entries
            entryBox.Add(username);
            entryBox.Add(password);
            labelEntryBox.Add(usernameLabel);
            labelEntryBox.Add(passwordLabel);

            loginBox = new HBox();
            loginBox.Add(labelEntryBox);
            loginBox.Add(entryBox);

            formFrame.Add(loginBox);
            mainBox.Add(formFrame);

            //finish adding buttons
            commitBox = new HButtonBox();

            commit = new Button("Ok");
            cancel = new Button("Annulla");
            isMedic = new CheckButton("Medico");

            commit.Show();
            cancel.Show();
            isMedic.Show();
            commitBox.Add(isMedic);
            commitBox.Add(commit);
            commitBox.Add(cancel);


            mainBox.Add(commitBox);
            //buttonBoxFrame.Add (commitBox);

            this.Add(mainBox);

            //button funzionality implementation
            cancel.Clicked += new EventHandler(CancelWindowCloser);
            commit.Clicked += Commit_Clicked;

            isMedic.Toggled += (object sender, EventArgs e) => showMedic = true;

            //Events
            this.DeleteEvent += new DeleteEventHandler(WindowCloser);
            // CheckList
            /*this.username.FocusInEvent += new FocusInEventHandler(UsernameTestAndScan);*/


            //last window settings
            this.SetPosition(WindowPosition.CenterAlways);
            this.ShowAll();
            isInstantiated = true;
            //commit.HideAll();
        }

        void Commit_Clicked(object sender, EventArgs e)
        {
            //try to log in
            //DataReader<List<IdHash>> reader = new DataReader<List<IdHash>>();
            //List<IdHash> list = reader.readXML("../../Properties/Archive/HashList.xml");
            if (password.Text.ToString() == "" || password.Text.ToString() == "")
            {
                var msg = new MessageDialog(
                              null,
                              DialogFlags.Modal,
                              MessageType.Info,
                              ButtonsType.None,
                              "Riempire tutte le entry");
                msg.ShowAll();
            }
            else
            {
                isOk = true;
                this.Hide();
            }
        }
        //events

        /*
		 * 	@brief This method is an event-handler called function -> it should close the window.
		 * 
		 */

        public override void WindowCloser(object obj, DeleteEventArgs args)
        {
            SignalArgs sa = (SignalArgs)args;
            this.Hide();
            sa.RetVal = true;
        }

        /*
		 * 	@brief This method is an event-handler-called function -> it should close the window by pressing cancel
		 * 
		 */
        public void CancelWindowCloser(object obj, EventArgs args)
        {
            this.Hide();
        }

        public void UsernameTestAndScan(object obj, EventArgs args)
        {
            if (username.Text.ToString() != "")
            {
                CheckList.Remove(CheckList.Find(x => x.Equals(false)));
                CheckList.Add(true);
            }
            else
            {
                CheckList.Remove(CheckList.Find(x => x.Equals(true)));
                CheckList.Add(false);
            }
            Scan(this.commit);
        }

        public void PasswordTestAndScan(object obj, EventArgs args)
        {
            if (password.Text.ToString() != "")
            {
                CheckList.Remove(CheckList.Find(x => x.Equals(false)));
                CheckList.Add(true);
            }
            else
            {
                CheckList.Remove(CheckList.Find(x => x.Equals(true)));
                CheckList.Add(false);
            }
            Scan(this.commit);
        }

        public void Commit(object obj, EventArgs args) //EventArgs
        {
            this.HideAll();
            //MAKE SOMETHING RELATED WITH COMMITTING LOGIN DATA
            string pswStored = "ciaone";
            int pswHashStored = pswStored.GetHashCode();
            String avviso;
            if (this.password.Text.GetHashCode() == pswHashStored)
                avviso = "Password corretta";
            else
            {
                avviso = "Password errata";
                password.Text = "";
            }
            Console.WriteLine(avviso);

            dialog = new Window(WindowType.Toplevel);
            dialog.Resize(200, 100);
            dialog.BorderWidth = 20;
            VBox dialogBox = new VBox();
            Label labelDialog = new Label(avviso);
            Button okPop = new Button("Ok");
            HButtonBox dialogButtonBox = new HButtonBox();
            dialogButtonBox.Add(okPop);
            dialogBox.Add(labelDialog);
            dialogBox.Add(dialogButtonBox);
            dialog.Add(dialogBox);
            dialog.SetPosition(WindowPosition.CenterAlways);
            dialog.ShowAll();

            if (avviso.Equals("Password corretta"))
                okPop.Clicked += CancelWindowCloser;
            else
            {
                okPop.Clicked += Revealer;

            }
            //THEN QUIT
        }

        public void Revealer(object obj, EventArgs args)
        {
            Console.WriteLine("Reveal");
            this.ShowAll();
            this.dialog.HideAll();
        }

        public void resetText()
        {
            this.username.Text = "";
            this.password.Text = "";
        }

    }
    //end of class
}
//end of the mainspace



