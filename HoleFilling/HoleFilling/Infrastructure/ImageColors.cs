using Emgu.CV;

namespace HoleFilling.Infrastructure
{
	internal class ImageColors
	{
		public const float BLACK = 0f;
		public const float WHITE = 255;
		private const float INVALID = -1f;

		public static float ScaleDown(float color)
		{
			return color == WHITE ?
				INVALID :
				color /= WHITE;
		}

		public static Matrix<float> ScaleDown(Matrix<float> matrix)
		{
			matrix._Mul(1d / WHITE);
			return matrix;
		}

		public static Matrix<float> ScaleUp(Matrix<float> matrix)
		{
			matrix._Mul(WHITE);
			return matrix;
		}
	}
}