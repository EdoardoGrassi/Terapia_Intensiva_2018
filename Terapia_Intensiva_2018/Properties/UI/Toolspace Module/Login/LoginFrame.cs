using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
    public class LoginFrame : Frame
    {
        private const string loginText = "Login";
        private const string subscribeText = "Registrazione";
        private const string loginButtonText = "Check";

        private VBox loginBox;
        private VButtonBox loginButtonBox;
        private Button loginButton;
        private HBox imageBox;
        private Image accountImage;
        private Label loginLabel;
        private Authentication LoginWindow;

        // Define a logout button
        private Button logoutButton;
        private Label logoutLabel;

        public Button LogoutButton { get { return logoutButton; } }

        public VButtonBox LoginButtonBox { get { return loginButtonBox; } }

        public Button LoginButton { get { return loginButton; } }

        public Authentication Login
        {
            get
            {
                if (LoginWindow.isInstantiated)
                    return LoginWindow;
                else
                    return getLogin();
            }    
        }

        private Button subscribeButton;

        public Button SubscribeButton { get { return subscribeButton; } }

        private Label subscribeLabel;
        private Subscription SubscriptionWindow;


        public LoginFrame()
            : base("Account")
        {
            this.BorderWidth = 10;
            this.loginBox = new VBox();
            this.loginButtonBox = new VButtonBox();
            this.loginButton = new Button();
            this.subscribeButton = new Button();

            // Button Box
            this.Add(loginBox);
            loginBox.PackStart(loginButtonBox, false, false, 10);
            loginBox.Add(loginButtonBox);


            // Login button
            loginButtonBox.PackStart(loginButton, true, true, 0);
            loginButtonBox.Add(loginButton);

            // Login Image button
            this.imageBox = new HBox();
            this.accountImage = new Image("../../icons/account.png");

            loginButton.Add(imageBox);
            imageBox.PackStart(accountImage, false, false, 3);
            imageBox.Add(accountImage);

            this.loginLabel = new Label(loginText);
            imageBox.PackStart(loginLabel, false, false, 0);
            imageBox.Add(loginLabel);

            // subscribe Button
            loginButtonBox.PackStart(subscribeButton, true, true, 0);
            loginButtonBox.Add(subscribeButton);

            // logout button
            this.logoutLabel = new Label("Logout");
            this.logoutButton = new Button();
            logoutButton.Add(logoutLabel);

            // subscribe Label Button
            this.subscribeLabel = new Label(subscribeText);
            subscribeButton.Add(subscribeLabel);


            //Buttons
            loginButton.Clicked += new EventHandler(OpenLoginWindow);
            subscribeButton.Clicked += new EventHandler(OpenSubscribeWindow);

            logoutButton.Clicked += new EventHandler(Logout);

            this.LoginWindow = new Authentication();
            this.LoginWindow.HideAll();

            this.SubscriptionWindow = new Subscription();
            this.SubscriptionWindow.HideAll();

        }


        public Authentication getLogin()
        {
            if (this.LoginWindow.isInstantiated == true)
                return LoginWindow;
            else
            {
                this.LoginWindow = new Authentication();
                return LoginWindow;
            }
        }


        public Subscription getSubscription()
        {
            if (this.SubscriptionWindow.isInstantiated == true)
                return SubscriptionWindow;
            else
            {
                this.SubscriptionWindow = new Subscription();
                return SubscriptionWindow;
            }
        }

        public void OpenLoginWindow(object obj, EventArgs args)
        {
            this.getLogin().ShowAll();
        }

        public void OpenSubscribeWindow(object obj, EventArgs args)
        {
            this.getSubscription().ShowAll();
        }

        public void Logout(object obj, EventArgs args)
        {
            this.loginButtonBox.Remove(LogoutButton);
            this.LoginButtonBox.Add(loginButton);
            this.LoginButtonBox.Add(subscribeButton);
            this.LoginButtonBox.ShowAll();
            this.Login.resetText();
        }
    }
}

