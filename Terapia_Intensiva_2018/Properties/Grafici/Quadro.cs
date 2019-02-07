using Gtk;
using System.Threading;
using Terapia_Intensiva_2018;

#pragma warning disable CS1701
#pragma warning disable RECS0021
#pragma warning disable IDE0044

namespace Grafici
{
	public class Quadro : Table
	{
		private Widget[] plots;
		private Mutex mut = new Mutex();

		public Quadro() : base(2, 2, true)
		{
			plots = new Plot[3];
			plots[0] = new HRPlot();
			Attach(plots[0], 0, 1, 0, 1);
			plots[1] = new TPlot();
			Attach(plots[1], 1, 2, 0, 1);
			plots[2] = new BPPlot();
			Attach(plots[2], 0, 1, 1, 2);

			Show();
		}

		public void Update(SignalValue signal)
		{
			mut.WaitOne();
			switch (signal.Type)
			{
				case SignalType.HR:
					{
						((HRPlot)plots[0]).InsertData(signal);
						break;
					}
				case SignalType.T:
					{
						((TPlot)plots[1]).InsertData(signal);
						break;
					}
				case SignalType.SBP:
					{
						((BPPlot)plots[2]).InsertData(signal);
						break;
					}
				case SignalType.DBP:
					{
						((BPPlot)plots[2]).InsertData(signal);
						break;
					}
			}
			mut.ReleaseMutex();
		}

		public void ShowLast15()
		{
			foreach (Plot plot in plots)
				plot.ShowLast15Min();
		}

		public void ShowLast120()
		{
			foreach (Plot plot in plots)
				plot.ShowLast120Min();
		}
	}
}
