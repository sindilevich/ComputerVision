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

		public void TryAddMissingPixel(IBoundarySearcher boundarySearcher, ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row, float color)
		{
			if (color == ImageColors.WHITE)
			{
				Pixel missing = new Pixel(imageRegion, column, row)
				{
					Color = color,
				};

				m_missingPixels.Add(missing);
				boundarySearcher.TryAddBoundaryPixels(imageRegion, normalizedImageMatrix, column, row);
			}
		}

		public void TryFillHoles(Matrix<float> normalizedImageMatrix, IBoundarySearcher boundarySearcher, WeightingFunction weightingFunction)
		{
			m_missingPixels.All(missingPixel =>
			{
				float numerator = 0f;
				float denominator = 0f;

				boundarySearcher.BoundaryPixels//.Take(5)
					.All(boundaryPixel =>
					{
						float weight = weightingFunction.Calculate(boundaryPixel.DirectLocation, missingPixel.DirectLocation);

						numerator += (weight * boundaryPixel.Color);
						denominator += weight;
						return true;
					});
				normalizedImageMatrix[missingPixel.Row, missingPixel.Column] = numerator / denominator;
				return true;
			});
		}

		public void TryMarkMissingPixels(Matrix<float> imageMatrix)
		{
			m_missingPixels.All(missingPixel =>
			{
				imageMatrix[missingPixel.Row, missingPixel.Column] = ImageColors.WHITE;
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