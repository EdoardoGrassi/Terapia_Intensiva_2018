using System;
using System.Threading;
using Grafici;

namespace Terapia_Intensiva_2018
{
    //Class that subscribes to an event
    class TestSubscriber
    {
		private Quadro quadro;

        public TestSubscriber(SignalDevice pub, Quadro inputQuadro) 
        {
			//quadro = inputQuadro;
			quadro = inputQuadro;
            // Subscribe to the event using C# 2.0 syntax
            pub.OnTemporizedSignal += HandleCustomEvent;
        }

        public void Unsubscribe(SignalDevice pub)
        {
            pub.OnTemporizedSignal -= HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, SignalValue e)
        {
            Console.WriteLine("Signal received: " + e.Type + " " + e.Value);
			switch (e.Type)
			{
				case SignalType.HR:
					{
						if(e.Value > 100)
						{
							// ---- Lancia allarme Tachicardia ----
						}
						break;
					}
				case SignalType.T:
					{
						if (e.Value > 39)
						{
							// ---- Lancia allarme Ipertermia ----
						}
						if (e.Value < 35)
						{
							// ---- Lancia allarme Ipotermia ----
						}
						break;
					}
				case SignalType.SBP:
					{
						if (e.Value > 140)
						{
							// ---- Lancia allarme Ipertensione SBP ----
						}
						if (e.Value < 100)
						{
							// ---- Lancia allarme Ipotensione SBP ----
						}
						break;
					}
				case SignalType.DBP:
					{
						if (e.Value > 90)
						{
							// ---- Lancia allarme Ipertensione DBP----
						}
						if (e.Value < 70)
						{
							// ---- Lancia allarme Ipotensione DBP ----
						}
						break;
					}
			}

			quadro.Update(e);
		}
    }
}

