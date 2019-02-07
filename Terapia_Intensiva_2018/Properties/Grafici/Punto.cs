using OxyPlot;

namespace Grafici
{
	public class Punto : IDataPointProvider
	{
		public double X { set; get; }
		public double Y { set; get; }

		public Punto() { }

		public Punto(double x, double y)
		{
			X = x;
			Y = y;
		}

		public DataPoint GetDataPoint()
		{
			return new DataPoint(X, Y);
		}
	}
}
