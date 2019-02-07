using System;
using System.Threading;
using System.Collections.Generic;
using Gtk;

namespace Terapia_Intensiva_2018
{
    class MainClass
    {
        private const int numberOfBox = 20;

        public static void Main(string[] args)
        {
            //DeviceManager publisher = new DeviceManager();
            //publisher.startSignalAutoma();
            //Console.WriteLine("All threads are initialized. Start printing");

            //PlotBox[] patients = new PlotBox[numberOfBox];
            //for (int i = 0; i < numberOfBox; i++)
            //  patients[i] = new PlotBox(numberOfBox);
            //DeviceSubscriber[] updatePlots = new DeviceSubscriber[publisher.getActiveDevices().Count];


            //for (int i = 0; i < publisher.getActiveDevices().Count; i++)
            //{
            //just testing
            //TestSubscriber tsub = new TestSubscriber(publisher.getActiveDevices()[i]);
            //updatePlots[i] = new DeviceSubscriber(publisher.getActiveDevices()[i], patients[i].getUserInfo()[i]);
            //}

            Application.Init();
            NewMainWindow win = new NewMainWindow();
            win.Show();
            Application.Run();

        }
    }
}
