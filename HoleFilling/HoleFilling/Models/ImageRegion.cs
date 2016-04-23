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

		public long GetPixelDirectLocation(int column, int row)
		{
			return (long)row * Width + column;
		}

		public bool PixelWithinRegion(int column, int row)
		{
			return (column >= 0 && column < Width)
				&& (row >= 0 && row < Height);
		}
	}
}