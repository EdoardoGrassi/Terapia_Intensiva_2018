using OxyPlot;
using OxyPlot.GtkSharp;
using OxyPlot.Series;
using OxyPlot.Axes;
using Terapia_Intensiva_2018;
using System;

#pragma warning disable CS1701
#pragma warning disable RECS0021
#pragma warning disable IDE0044

namespace Grafici
{
	public abstract class Plot : PlotView
	{
		protected Punto[] dati;
		protected PlotModel model;
		protected LineSeries line;
		protected Axis Xaxis;
		protected Axis Yaxis;
		protected int range;

		public bool Refresh { set; get; }

		public void ShowLast15Min()
		{
			Xaxis.Maximum = 15;
		}

		public void ShowLast120Min()
		{
			Xaxis.Maximum = 120;
		}

		public virtual void InsertData(SignalValue signal)
		{
			for (int i = dati.Length - 1; i >= 1; i--)
			{
				dati[i].Y = dati[i - 1].Y;
			}
			dati[0].Y = signal.Value;

			if (Refresh)
				InvalidatePlot(true);

			GC.Collect();
		}
	}
}
