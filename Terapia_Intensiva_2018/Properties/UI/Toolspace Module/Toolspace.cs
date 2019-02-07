using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class Toolspace : Frame
    {
        private VBox toolspace;
        private LoginFrame loginModule;
        private OperationFrame operationModule;

        public Toolspace()
            : base("Toolspace")
        {
            this.toolspace = new VBox();
            this.Add(toolspace);

            this.loginModule = new LoginFrame();
            this.operationModule = new OperationFrame();

            toolspace.PackStart(loginModule, false, false, 10);
            toolspace.Add(loginModule);


            this.operationModule.HideAll();

            loginModule.Login.GetCommit.Clicked += new EventHandler(ShowThings);
            loginModule.LogoutButton.Clicked += new EventHandler(HideThings);
        }

        public void ShowThings(object obj, EventArgs args)
        {
            Console.WriteLine("Authentication: Ok Clicked");
            if (loginModule.Login.IsOk)
            {
                operationModule.ShowAll();
                this.toolspace.PackStart(operationModule, false, false, 10);
                this.toolspace.Add(operationModule);
                Console.WriteLine("Authentication Approved, showing things");
                loginModule.LoginButtonBox.Remove(loginModule.LoginButton);
                loginModule.LoginButtonBox.Remove(loginModule.SubscribeButton);
                loginModule.LoginButtonBox.Add(loginModule.LogoutButton);
                operationModule.Login();
                loginModule.ShowAll();
            }
        }

        public void HideThings(object obj, EventArgs args)
        {
            this.loginModule.Login.IsOk = false;
            operationModule.Logout();
        }




    }



}

