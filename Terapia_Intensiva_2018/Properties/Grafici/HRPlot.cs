using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;
using Terapia_Intensiva_2018;

#pragma warning disable CS1701
#pragma warning disable RECS0021
#pragma warning disable IDE0044

namespace Grafici
{
	public class HRPlot : Plot
	{
		public HRPlot()
		{
			ShowAll();
			range = 24;

			HeightRequest = 250;
			WidthRequest = 300;

			dati = new Punto[range];
			for (int i = 0; i <= dati.Length - 1; i++)
				dati[i] = new Punto(i * (120 / range), 0);

			model = new PlotModel
			{
				Title = "Frequenza Cardiaca(bpm)",
				TitleFontSize = 10,
				IsLegendVisible = false,
			};
			Model = model;

			line = new LineSeries
			{
				Title = "BPM",
				Background = OxyColors.Black,
				Color = OxyColors.Green,
				LineStyle = LineStyle.Solid,
				ItemsSource = dati
			};
			model.Series.Add(line);

			LineAnnotation bottomGuide = new LineAnnotation
			{
				Text = "Tachicardia",
				TextColor = OxyColors.Blue,
				TextVerticalAlignment = VerticalAlignment.Top,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 100
			};
			model.Annotations.Add(bottomGuide);

			Xaxis = new LinearAxis
			{
				Title = "min",
				Position = AxisPosition.Bottom,
				Maximum = 120,
				IsPanEnabled = false,
				IsZoomEnabled = false	
			};
			model.Axes.Add(Xaxis);

			Yaxis = new LinearAxis
			{
				Title = "BPM",
				TitleColor = OxyColors.White,
				Position = AxisPosition.Left,
				Maximum = 210,
				AbsoluteMinimum = 0,		
				Angle = 90
			};
			model.Axes.Add(Yaxis);

			Refresh = true;
		}
		/* ----- Rilevamento Aritimia -----
		public override void InsertData(SignalValue signal)
		{
			base.InsertData(signal);
			if((dati[0].Y - dati[1].Y) > 30)
				// Lancia allarme tachicardia
		}
		*/
	}
}
