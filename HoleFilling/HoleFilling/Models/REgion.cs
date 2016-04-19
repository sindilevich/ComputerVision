namespace HoleFilling.Models
{
	public class Region
	{
		public Region(int height, int width)
		{
			Height = height;
			Width = width;
		}

		public int Height { get; private set; }

		public int Width { get; private set; }

		public bool PixelWithinRegion(Pixel pixel)
		{
			return (pixel.Column >= 0 && pixel.Column < Width)
				&& (pixel.Row >= 0 && pixel.Row < Height);
		}
	}
}