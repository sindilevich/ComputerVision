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

		public int Row { get; private set; }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Pixel pixel = obj as Pixel;

			return pixel != null &&
				Column == pixel.Column &&
				Row == pixel.Row &&
				Color == pixel.Color;
		}

		public override int GetHashCode()
		{
			return new { Color, Column, Row }.GetHashCode();
		}
	}
}