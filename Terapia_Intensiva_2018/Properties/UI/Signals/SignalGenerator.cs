using System;

namespace Terapia_Intensiva_2018
{
    public class SignalGenerator
    {
        //Pressione Sistolica SBP e Diastolica DBP
        private const double lowerBoundSBP = 100;
        private const double upperBoundSBP = 140;
        private const double lowerBoundDBP = 70;
        private const double upperBoundDBP = 90;

        //Frequenza cardiaca - Heart Rate --> HR
        private const double lowerBoundHR = 60;
        private const double upperBoundHR = 100;

        //Temperatura T
        private const double lowerBoundT = 35;
        private const double upperBoundT = 39;

        //Offset
        private const double offset = 5;

        //Randomizzatore
        private static Random generator = new Random();

        /*
        public SignalGenerator()
        {
            this.generator = new Random();
        }
        */

        public static double genSignal(SignalType typeOfSignal)
        {
            switch (typeOfSignal)
            {
                case SignalType.SBP:
                    {
                        return (generator.NextDouble()*(upperBoundSBP+offset-lowerBoundSBP+offset)+lowerBoundSBP-offset);
                    }
                case SignalType.DBP:
                    {
                        return (generator.NextDouble()*(upperBoundDBP+offset-lowerBoundDBP+offset)+lowerBoundDBP-offset);
                    }
                case SignalType.HR:
                    {
                        return (generator.NextDouble()*(upperBoundHR+offset-lowerBoundHR+offset)+lowerBoundHR-offset);
                    }
                case SignalType.T:
                    {
                        return (generator.NextDouble()*(upperBoundT+offset-lowerBoundT+offset)+lowerBoundT-offset);
                    }
                default:
                    throw new ArgumentException("Invalid Signal: " + typeOfSignal.ToString());
                
            }
        }

    }
}

