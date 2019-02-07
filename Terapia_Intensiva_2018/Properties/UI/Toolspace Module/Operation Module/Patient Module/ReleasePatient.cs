using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class ReleasePatient : TerapiaFormTemplate
    {
        private const String title = "Inserisci lettera di dimissioni";
        private Label assignmentLabel;
        private TextView letterTextInputArea;
        private string letterText;

        public TextView DiagnosisTextInputArea
        { 
            get { return this.letterTextInputArea; } 
            set { this.letterTextInputArea = value; } 
        }

        public String DiagnosisText { get { return this.letterText; } }

        public ReleasePatient()
            : base()
        {
            // bg table is 10x4
            this.assignmentLabel = new Label(title + ": ");
            this.bgTable.Attach(assignmentLabel, 0, 3, 0, 1);

            // text area
            this.letterTextInputArea = new TextView();
            this.bgTable.Attach(letterTextInputArea, 0, 4, 1, 5);

            this.submitButton.Clicked += (object sender, EventArgs e) =>
            {
                this.letterText = this.letterTextInputArea.Buffer.Text;
                Console.WriteLine("Lettera di dimissione: \n" + DiagnosisText);
                this.Hide();
            };

            this.ShowAll();
        }

        public void UpdateTitle(string patient)
        {
            this.Title = title + ": " + patient;
        }


    }


}

