using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class InsertDiag : TerapiaFormTemplate
    {
        private const String title = "Inserisci diagnosi d'ingresso";
        private const int maxCharPerText = 140;
        private Label assignmentLabel;
        private TextView diagnosisTextInputArea;
        private string diagnosisText;

        public TextView DiagnosisTextInputArea
        { 
            get { return this.diagnosisTextInputArea; } 
            set { this.diagnosisTextInputArea = value; } 
        }

        public String DiagnosisText { get { return this.diagnosisText; } }

        public InsertDiag()
            : base()
        {
            // bg table is 10x4
            this.assignmentLabel = new Label(title + ": ");
            this.bgTable.Attach(assignmentLabel, 0, 3, 0, 1);

            // text area
            this.diagnosisTextInputArea = new TextView();
            this.bgTable.Attach(diagnosisTextInputArea, 0, 4, 1, 5);

            this.submitButton.Clicked += (object sender, EventArgs e) =>
            {
                this.diagnosisText = this.diagnosisTextInputArea.Buffer.Text;
                Console.WriteLine("Diagnosi d'ingresso: \n" + DiagnosisText);
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

