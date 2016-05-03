using System.Collections.Generic;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class ImageColorsService
	{
		public const float BLACK = 0f;
		public const float WHITE = 255;
		private const float INVALID = -1f;

		/// <summary>
		/// Interpolates color value for a missing pixel <paramref name="x"/> using the set of boundary pixels <paramref name="y"/>,
		/// according to the <paramref name="colorInterpolator"/> algorithm.
		/// </summary>
		/// <param name="missingPixel">Pixel that missing color in the image.</param>
		/// <param name="boundaryPixels">Set of boundary pixels.</param>
		/// <param name="colorInterpolator">Color interpolation algorithm.</param>
		/// <returns></returns>
		public static float InterpolateColor(Pixel missingPixel, ICollection<Pixel> boundaryPixels, ColorInterpolatorBase colorInterpolator)
		{
			return colorInterpolator.InterpolateColor(missingPixel, boundaryPixels);
		}

		/// <summary>
		/// Scales a [0...255] color value down to [0...1] range.
		/// </summary>
		/// <param name="color">Color value in [0...255] range.</param>
		/// <returns></returns>
		public static float ScaleColorDown(float color)
		{
			return color == WHITE ?
				INVALID :
				color /= WHITE;
		}

		/// <summary>
		/// Scales [0...255] color values in a matrix lineary down to [0...1] range.
		/// Scaling down performed in-place and the modified matrix returned to allow chaining.
		/// </summary>
		/// <param name="matrix">Matrix with color values in [0...255] range.</param>
		/// <returns></returns>
		public static Matrix<float> ScaleColorsDown(Matrix<float> matrix)
		{
			matrix._Mul(1d / WHITE);
			return matrix;
		}

		/// <summary>
		/// Scales [0...1] color values in a matrix lineary up to [0...255] range.
		/// Scaling up performed in-place and the modified matrix returned to allow chaining.
		/// </summary>
		/// <param name="matrix">Matrix with color values in [0...1] range.</param>
		/// <returns></returns>
		public static Matrix<float> ScaleColorsUp(Matrix<float> matrix)
		{
			matrix._Mul(WHITE);
			return matrix;
		}
	}
}