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
			DirectLocation = imageRegion.GetPixelDirectLocation(Column, Row);
		}

		public float Color
		{
			get
			{
				return m_color;
			}
			set
			{
				m_color = ImageColorsService.ScaleColorDown(value);
			}
		}

		public int Column { get; private set; }

		public long DirectLocation { get; private set; }

		public int Row { get; private set; }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Pixel p = obj as Pixel;

			return p != null &&
				DirectLocation == p.DirectLocation &&
				Color == p.Color;
		}

		public override int GetHashCode()
		{
			return new { Color, Column, DirectLocation, Row }.GetHashCode();
		}
	}
}