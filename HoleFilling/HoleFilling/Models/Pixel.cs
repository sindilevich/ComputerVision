namespace HoleFilling.Models
{
	public class Pixel
	{
		public Pixel(ImageRegion imageRegion, int column, int row)
		{
			Column = column;
			Row = row;
			DirectLocation = (long)Row * imageRegion.Width + Column;
		}

		public float Color { get; set; }

		public int Column { get; private set; }

		public long DirectLocation { get; private set; }

		public int Row { get; private set; }
	}
}