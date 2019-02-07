using System;

namespace Terapia_Intensiva_2018
{
    // Define a class to hold custom event info --> Generated Signal Value
    public class SignalValue : EventArgs
    {
        public SignalValue(double signalValue, SignalType typeOfSignal)
        {
            value = signalValue;
            type = typeOfSignal;
        }
        private double value;
        public double Value
        {
            get { return value; }
        }

        private SignalType type;
        public SignalType Type
        {
            get { return type; }
        }
    }
}

