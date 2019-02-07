using System;
using Gtk;

namespace Terapia_Intensiva_2018
{
	public class MainWindow : Gtk.Window
	{
		private const string mainTitle = "Terapia Intensiva";
		private HBox background;
		private VBox monitor;
		private VBox tools;


		public MainWindow()
			: base(WindowType.Toplevel)
		{
			//MainWindow
			this.Title = mainTitle;
			this.SetDefaultSize(800, 400);
			this.SetPosition(WindowPosition.CenterAlways);
			this.SetIconFromFile("../../icons/main_icon.ico");

			//background
			this.background = new HBox();
			background.BorderWidth = 0;
			background.Spacing = 0;
			this.Add(background);

			//background -> monitor
			this.monitor = new VBox();
			monitor.BorderWidth = 4;
			monitor.Spacing = 10;
			background.Add(monitor);

			//background -> separator
			VSeparator separator1 = new VSeparator();
			background.Add(separator1);

			//background -> tools
			this.tools = new VBox();
			tools.BorderWidth = 4;
			tools.Spacing = 2;
			background.Add(tools);

			//background -> tools -> Logging


			this.ShowAll();
			this.DeleteEvent += new DeleteEventHandler(WindowCloser);
		}

		//events

		/*
		 * 	@brief This method is an event-handler function -> it should close the window.
		 * 
		 */
		public static void WindowCloser(object obj, DeleteEventArgs args)
		{
			Application.Quit();
		}

	}
}

