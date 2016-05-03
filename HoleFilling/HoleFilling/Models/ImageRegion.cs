using System;

namespace HoleFilling.Models
{
	public class ImageRegion
	{
		public ImageRegion(int height, int width)
		{
			Height = height;
			Width = width;
		}

		public int Height { get; private set; }

		public int Width { get; private set; }

		public double CalculateEuclideanDistance(Pixel a, Pixel b)
		{
			return Math.Sqrt(Math.Pow(a.Column - b.Column, 2d) + Math.Pow(a.Row - b.Row, 2d));
		}

		public bool PixelWithinRegion(int column, int row)
		{
			return (column >= 0 && column < Width)
				&& (row >= 0 && row < Height);
		}
	}
}