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
	public class DBPPlot : Plot
	{
		public DBPPlot()
		{
			ShowAll();
			range = 60;

			HeightRequest = 150;
			WidthRequest = 300;

			dati = new Punto[range];
			for (int i = 0; i <= dati.Length - 1; i++)
				dati[i] = new Punto(i * (120 / range), 0);

			model = new PlotModel
			{
				Title = "Pressione Diastolica",
				TitleFontSize = 10,
				Padding = new OxyThickness(-10, 5, 5, -10),
				IsLegendVisible = false
			};

			line = new LineSeries
			{
				Title = "DBP",
				Background = OxyColors.White,
				Color = OxyColors.Orange,
				LineStyle = LineStyle.Solid,
				ItemsSource = dati,
			};
			model.Series.Add(line);

			LineAnnotation topGuide = new LineAnnotation
			{
				Text = "Ipertensione",
				TextVerticalAlignment = VerticalAlignment.Bottom,
				TextColor = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 90
			};
			model.Annotations.Add(topGuide);

			LineAnnotation bottomGuide = new LineAnnotation
			{
				Text = "Ipotensione",
				TextVerticalAlignment = VerticalAlignment.Top,
				TextColor = OxyColors.Blue,
				Type = LineAnnotationType.Horizontal,
				LineStyle = LineStyle.Solid,
				Y = 70
			};
			model.Annotations.Add(bottomGuide);

			Xaxis = new LinearAxis
			{
				Title = "min",
				Position = AxisPosition.Bottom,
				Maximum = 120,
				IsPanEnabled = false,
				IsZoomEnabled = false,
				/*
				MajorGridlineStyle = LineStyle.Solid,
				MajorGridlineColor = OxyColors.Gray,
				MinorGridlineStyle = LineStyle.Dot,
				MinorGridlineColor = OxyColors.Gray,
				*/			
			};
			model.Axes.Add(Xaxis);

			Yaxis = new LinearAxis
			{
				Title = "mmHg",
				TitleColor = OxyColors.White,
				Position = AxisPosition.Left,
				Maximum = 200,
				AbsoluteMinimum = 0,
				/*
				MajorGridlineStyle = LineStyle.Solid,
				MajorGridlineColor = OxyColors.Gray,
				MinorGridlineStyle = LineStyle.Dot,
				MinorGridlineColor = OxyColors.Gray,
				*/			
				Angle = 90
			};
			model.Axes.Add(Yaxis);
			
			Model = model;
		}
	}
}
