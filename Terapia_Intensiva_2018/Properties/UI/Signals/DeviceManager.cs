using System;
using System.Threading;
using System.Collections.Generic;

namespace Terapia_Intensiva_2018
{
    public class DeviceManager
    {
        public SignalCouple[] config = new[]
        { 
            new SignalCouple() { signalType = SignalType.DBP, delay = 1200 },
            new SignalCouple() { signalType = SignalType.SBP, delay = 1200 },
            new SignalCouple() { signalType = SignalType.HR, delay = 3000 },
            new SignalCouple() { signalType = SignalType.T, delay = 1800 }
        };					

        private SignalDevice[] activeDevices;

        public DeviceManager(int numberOfPatients)
        {
            activeDevices = new SignalDevice[numberOfPatients];
        }

        public SignalDevice getDeviceN(int deviceIndex)
        {
            return this.activeDevices[deviceIndex];
        }

        public void startSignalAutoma(int deviceIndex)
        {
            Console.WriteLine("I'm second thread i generate signals! *Beep! Beep!*");
            List<SignalCouple> configList = new List<SignalCouple>();

            for (int i = 0; i < 4; i++)
                configList.Add(config[i]);

            activeDevices[deviceIndex] = new SignalDevice(configList);
        }
    }
}

