using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;
using Terapia_Intensiva_2018;
using System;

#pragma warning disable CS1701
#pragma warning disable RECS0021
#pragma warning disable IDE0044

namespace Grafici
{
	public class BPPlot : Plot
	{
		private Punto[] dati2;
		private LineSeries line2;

		public BPPlot()
		{
			ShowAll();
			range = 60;

			HeightRequest = 250;
			WidthRequest = 300;

			dati = new Punto[range];
			dati2 = new Punto[range];
			for (int i = 0; i <= dati.Length - 1; i++)
			{
				dati[i] = new Punto(i * (120 / range), 0);
				dati2[i] = new Punto(i * (120 / range), 0);
			}

			model = new PlotModel
			{
				Title = "Pressione Sistolica/Diastolica(mmHg)",
				TitleFontSize = 10,
				LegendTextColor = OxyColors.White
			};
			Model = model;

			line = new LineSeries
			{
				Title = "SBP",
				Background = OxyColors.Black,
				Color = OxyColors.Red,
				LineStyle = LineStyle.Solid,
				ItemsSource = dati,
			};
			model.Series.Add(line);

			line2 = new LineSeries
			{
				Title = "DBP",
				Color = OxyColors.Blue,
				LineStyle = LineStyle.Solid,
				ItemsSource = dati2,
			};
			model.Series.Add(line2);

			LineAnnotation topGuideSBP = new LineAnnotation
			{
				Text = "Ipertensione",
				TextVerticalAlignment = VerticalAlignment.Bottom,
				TextColor = OxyColors.Red,
				Color = OxyColors.Red,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 140
			};
			model.Annotations.Add(topGuideSBP);

			LineAnnotation bottomGuideSBP = new LineAnnotation
			{
				Text = "Ipotensione",
				TextVerticalAlignment = VerticalAlignment.Bottom,
				TextColor = OxyColors.Red,
				Color = OxyColors.Red,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 100
			};
			model.Annotations.Add(bottomGuideSBP);

			LineAnnotation topGuideDBP = new LineAnnotation
			{
				Text = "Ipertensione",
				TextVerticalAlignment = VerticalAlignment.Top,
				TextColor = OxyColors.Blue,
				Color = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 90
			};
			model.Annotations.Add(topGuideDBP);

			LineAnnotation bottomGuideDBP = new LineAnnotation
			{
				Text = "Ipotensione",
				TextVerticalAlignment = VerticalAlignment.Top,
				TextColor = OxyColors.Blue,
				Color = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 70
			};
			model.Annotations.Add(bottomGuideDBP);

			Xaxis = new LinearAxis
			{
				Title = "min",
				Position = AxisPosition.Bottom,
				Maximum = 120,
				IsPanEnabled = false,
				IsZoomEnabled = false,		
			};
			model.Axes.Add(Xaxis);

			Yaxis = new LinearAxis
			{
				Title = "mmHg",
				TitleColor = OxyColors.White,
				Position = AxisPosition.Left,
				Maximum = 200,
				AbsoluteMinimum = 0,			
				Angle = 90
			};
			model.Axes.Add(Yaxis);

			Refresh = true;
		}

		public override void InsertData(SignalValue signal)
		{
			if (signal.Type == SignalType.SBP)
			{
				for (int i = dati.Length - 1; i >= 1; i--)
				{
					dati[i].Y = dati[i - 1].Y;
				}
				dati[0].Y = signal.Value;
			}
			else
			{
				for (int i = dati2.Length - 1; i >= 1; i--)
				{
					dati2[i].Y = dati2[i - 1].Y;
				}
				dati2[0].Y = signal.Value;
			}

			if (Refresh)
				InvalidatePlot(true);

			GC.Collect();
		}
	}
}
