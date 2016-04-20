using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class MissingPixelsService : IMissingPixelsService
	{
		private IList<Pixel> m_missingPixels;

		public void Initialize()
		{
			m_missingPixels = new List<Pixel>();
		}

		public bool TryAddMissingPixel(IBoundarySearcher boundarySearcher, ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row, float color)
		{
			bool foundMissingPixel = false;

			if (color == ImageColorsService.WHITE)
			{
				Pixel missing = new Pixel(imageRegion, column, row)
				{
					Color = color,
				};

				m_missingPixels.Add(missing);
				foundMissingPixel = true;
				boundarySearcher.TryAddBoundaryPixels(imageRegion, normalizedImageMatrix, column, row);
			}
			return foundMissingPixel;
		}

		public void TryFillHoles(Matrix<float> normalizedImageMatrix, IBoundarySearcher boundarySearcher, ColorExtrapolatorBase colorExtrapolator)
		{
			m_missingPixels.All(missingPixel =>
			{
				normalizedImageMatrix[missingPixel.Row, missingPixel.Column] = ImageColorsService.ExtrapolateColor(missingPixel, boundarySearcher.BoundaryPixels, colorExtrapolator);
				return true;
			});
		}

		public void TryMarkMissingPixels(Matrix<float> imageMatrix)
		{
			m_missingPixels.All(missingPixel =>
			{
				imageMatrix[missingPixel.Row, missingPixel.Column] = ImageColorsService.WHITE;
				return true;
			});
		}

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					m_missingPixels?.Clear();
				}
				m_missingPixels = null;
				disposedValue = true;
			}
		}

		#endregion IDisposable Support
	}
}