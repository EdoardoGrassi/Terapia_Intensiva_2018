using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace Terapia_Intensiva_2018
{
    public class SignalDevice
    {
        private List<SignalCouple> signals;
        private System.Timers.Timer[] timers;

        // Declare the event using EventHandler<T>
        public event EventHandler<SignalValue> OnTemporizedSignal;

        public SignalDevice(ICollection<SignalCouple> config)
        {
            this.signals = (List<SignalCouple>)config;
            this.timers = new System.Timers.Timer[config.Count];
            int i = 0;

            foreach (var signal in signals)
            {
                var timer = new System.Timers.Timer(signal.delay);
                timer.Elapsed += (sender, e) =>
                {
                    OnTemporizedSignal?.Invoke(this,
                        new SignalValue(SignalGenerator.genSignal(signal.signalType),
                            signal.signalType));
                };
                timer.Start();
                timers[i] = timer;
                ++i;
            }

        }

        ~SignalDevice()
        {
            foreach (var timer in timers)
            {
                timer.Dispose();
            }
        }

    }
}

