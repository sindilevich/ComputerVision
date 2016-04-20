using HoleFilling.Infrastructure;

namespace HoleFilling.Models
{
	public class Pixel
	{
		private float m_color;

		public Pixel(ImageRegion imageRegion, int column, int row)
		{
			Column = column;
			Row = row;
			DirectLocation = (long)Row * imageRegion.Width + Column;
		}

		public float Color
		{
			get
			{
				return m_color;
			}
			set
			{
				m_color = ImageColors.ScaleDown(value);
			}
		}

		public int Column { get; private set; }

		public long DirectLocation { get; private set; }

		public int Row { get; private set; }
	}
}