using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;

#pragma warning disable CS1701
#pragma warning disable RECS0021
#pragma warning disable IDE0044

namespace Grafici
{
	public class TPlot : Plot
	{ 
		public TPlot()
		{
			ShowAll();
			range = 40;

			HeightRequest = 250;
			WidthRequest = 300;

			dati = new Punto[range];
			for (int i = 0; i <= dati.Length - 1; i++)
				dati[i] = new Punto(i * (120 / range), 0);

			model = new PlotModel
			{
				Title = "Temperatura(°C)",
				TitleFontSize = 10,
				IsLegendVisible = false
			};
			Model = model;

			line = new LineSeries
			{
				Title = "Temperatura",
				Background = OxyColors.Black,
				Color = OxyColors.Red,
				LineStyle = LineStyle.Solid,
				ItemsSource = dati
			};
			model.Series.Add(line);

			LineAnnotation topGuide = new LineAnnotation
			{
				Text = "Ipertermia",
				TextVerticalAlignment = VerticalAlignment.Bottom,
				TextColor = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 39
			};
			model.Annotations.Add(topGuide);

			LineAnnotation bottomGuide = new LineAnnotation
			{
				Text = "Ipotermia",
				TextVerticalAlignment = VerticalAlignment.Top,
				TextColor = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 35
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
				Title = "°C",
				TitleColor = OxyColors.White,
				Position = AxisPosition.Left,
				Maximum = 50,
				AbsoluteMinimum = 0,	
				Angle = 90
			};
			model.Axes.Add(Yaxis);

			Refresh = true;
		}
	}
}
