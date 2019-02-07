using System;
using Gtk;
using System.Collections.Generic;
using System.IO;

namespace Terapia_Intensiva_2018
{
    public class Subscription : TerapiaWindow
    {
        public bool isInstantiated = false;
        private const int width = 350;
        private const int height = 500;

        private Table bgTable;

        private const String name = "Nome";
        private Label nameLabel;
        private Entry nameEntry;

        private const String surname = "Cognome";
        private Label surnameLabel;
        private Entry surnameEntry;

        private const String spec = "Specializzazione";
        private Label specLabel;
        private Entry specEntry;

        public Label SpecLabel { get { return specLabel; } }

        public Entry SpecEntry { get { return specEntry; } }

        private const String medico = "Medico";
        private CheckButton isMedic;
        private bool toggledArgs;

        private const String psw = "Password";
        private const String pswConferma = "Conferma\nPassword";
        private Label pswLabel;
        private Entry pswEntry;
        private Label pswLabel2;
        private Entry pswEntry2;

        private Button submitButton;

        //methods

        public Subscription()
            : base()
        {
            // Window Settings
            this.Title = "Registrazione";
            this.BorderWidth = 10;
            this.DefaultWidth = 100;
            //this.SetDefaultSize(width, height);

            // Background
            this.bgTable = new Table(10, 4, true);
            bgTable.ColumnSpacing = 10;
            bgTable.RowSpacing = 20;
            this.Add(bgTable);

            // --> Label + Entry <--
            // Name
            this.nameLabel = new Label(name);
            bgTable.Attach(nameLabel, 0, 1, 0, 1);
            this.nameEntry = new Entry();
            nameEntry.MaxLength = 30;
            bgTable.Attach(nameEntry, 1, 4, 0, 1);

            // Surname
            this.surnameLabel = new Label(surname);
            bgTable.Attach(surnameLabel, 0, 1, 1, 2);
            this.surnameEntry = new Entry();
            bgTable.Attach(surnameEntry, 1, 4, 1, 2);

            // Check Spec
            this.isMedic = new CheckButton(medico);
            bgTable.Attach(isMedic, 1, 4, 2, 3);
            this.toggledArgs = true;
            isMedic.Toggled += IsMedic_Toggled;

            // Spec
            this.specLabel = new Label(spec);

            //bgTable.Attach(specLabel, 0, 1, 3, 4);
            this.specEntry = new Entry();
            //bgTable.Attach(specEntry, 1, 4, 3, 4);

            // Password 
            this.pswLabel = new Label(psw);
            this.pswEntry = new Entry();
            bgTable.Attach(pswLabel, 0, 1, 5, 6);
            bgTable.Attach(pswEntry, 1, 4, 5, 6);
            pswEntry.Visibility = false;

            // Confirm Password
            this.pswLabel2 = new Label(pswConferma);
            this.pswEntry2 = new Entry();
            bgTable.Attach(pswLabel2, 0, 1, 6, 7);
            bgTable.Attach(pswEntry2, 1, 4, 6, 7);
            pswEntry2.Visibility = false;

            pswEntry2.TextInserted += PswEntry2_TextInserted;

            //Submit
            this.submitButton = new Button("Submit");
            bgTable.Attach(submitButton, 1, 3, 8, 9);
            submitButton.Clicked += SubmitButton_Clicked;
           

            this.ShowAll();
            this.isInstantiated = true;

            this.WidthRequest = 350;
            this.HeightRequest = 500;
            this.Resizable = false;
            this.submitButton.Hide();
        }

        void PswEntry2_TextInserted(object o, TextInsertedArgs args)
        {
            if (pswEntry.Text != pswEntry2.Text)
                this.submitButton.Hide();
            else
                this.submitButton.Show();
        }

        void SubmitButton_Clicked(object sender, EventArgs e)
        {
            PersonaleMedico userToBeSaved;


            if (!this.toggledArgs)
            {
                userToBeSaved = new Medico(nameEntry.Text.ToString() + "."
                    + surnameEntry.Text.ToString(),
                    pswEntry.Text.ToString(),
                    nameEntry.Text.ToString(),
                    surnameEntry.Text.ToString(),
                    specEntry.Text.ToString());
                List<Medico> list;

                String path = "../../Properties/Archive/ListaMedici.xml";
                if (File.Exists(path))
                {
                    DataReader<List<Medico>> reader = new DataReader<List<Medico>>();
                    list = reader.readXML(path);
                }
                else
                    list = new List<Medico>();
                
                list.Add((Medico)userToBeSaved);

                DataSaver<List<Medico>> saver = new DataSaver<List<Medico>>();
                saver.save(list, path);

            }
            else
            {
                userToBeSaved = new Infermiere(nameEntry.Text.ToString() + "."
                    + surnameEntry.Text.ToString(),
                    pswEntry.Text.ToString(),
                    nameEntry.Text.ToString(),
                    surnameEntry.Text.ToString());
                String path = "../../Properties/Archive/ListaInfermieri.xml";
                List<Infermiere> list;
                if (File.Exists(path))
                {
                    DataReader<List<Infermiere>> reader = new DataReader<List<Infermiere>>();
                    list = reader.readXML(path);
                }
                else
                {
                    list = new List<Infermiere>();
                }
                list.Add((Infermiere)userToBeSaved);

                DataSaver<List<Infermiere>> saver = new DataSaver<List<Infermiere>>();
                saver.save(list, path);
            }

            Console.WriteLine(userToBeSaved.GetUsername());
            this.Hide();
            this.isInstantiated = false;   
        }


        void IsMedic_Toggled(object sender, EventArgs e)
        {
            if (this.toggledArgs)
            {
                bgTable.Attach(specLabel, 0, 2, 3, 4);
                bgTable.Attach(specEntry, 2, 4, 3, 4);
                this.ShowAll();
                this.SetSizeRequest(width, height);
                this.toggledArgs = !(this.toggledArgs);
            }
            else
            {
                specLabel.Hide();
                specEntry.Hide();
                this.SetSizeRequest(width, height);
                this.toggledArgs = !(this.toggledArgs);
            }
        }

       

        public override void WindowCloser(object obj, DeleteEventArgs args)
        {

            this.Hide();
            this.isInstantiated = false;
        }
            

    }
}

