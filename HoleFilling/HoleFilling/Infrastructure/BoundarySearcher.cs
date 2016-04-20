using System.Collections.Generic;
using System.Linq;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class BoundarySearcher : IBoundarySearcher
	{
		private Matrix<int> m_neighborsMatrix = new Matrix<int>(2, 3);

		public IList<Pixel> BoundaryPixels { get; private set; }

		public void Initialize()
		{
			InitializeBoundaryPixels();
			InitializeNeighborsMatrix();
		}

		public void TryAddBoundaryPixels(ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row)
		{
			using (Matrix<int> pixelCoordinates = new Matrix<int>(2, 3))
			{
				pixelCoordinates[0, 0] = pixelCoordinates[0, 1] = pixelCoordinates[0, 2] = column; // neighbor columns stored in row 0
				pixelCoordinates[1, 0] = pixelCoordinates[1, 1] = pixelCoordinates[1, 2] = row; // neighbor rows stored in row 1
				using (Matrix<int> currentNeighbors = m_neighborsMatrix.Add(pixelCoordinates))
				{
					for (int i = 0; i < currentNeighbors.Cols; i++)
					{
						for (int j = 0; j < currentNeighbors.Cols; j++)
						{
							int neighborColumn = currentNeighbors.Data[0, i];
							int neighborRow = currentNeighbors.Data[1, j];
							Pixel boundaryPixel = new Pixel(imageRegion, neighborColumn, neighborRow);

							if (imageRegion.PixelWithinRegion(boundaryPixel))
							{
								float boundaryColor = normalizedImageMatrix.Data[neighborRow, neighborColumn];

								if (boundaryColor != ImageColorsService.WHITE)
								{
									boundaryPixel.Color = boundaryColor;
									BoundaryPixels.Add(boundaryPixel);
								}
							}
						}
					}
				}
			}
		}

		public void TryMarkBoundaryPixels(Matrix<float> imageMatrix)
		{
			BoundaryPixels.All(boundaryPixel =>
			{
				imageMatrix[boundaryPixel.Row, boundaryPixel.Column] = ImageColorsService.BLACK;
				return true;
			});
		}

		private void InitializeBoundaryPixels()
		{
			if (BoundaryPixels == null)
			{
				BoundaryPixels = new List<Pixel>();
			}
			BoundaryPixels.Clear();
		}

		private void InitializeNeighborsMatrix()
		{
			m_neighborsMatrix.Data[0, 0] = m_neighborsMatrix.Data[1, 0] = -1;
			m_neighborsMatrix.Data[0, 1] = m_neighborsMatrix.Data[1, 1] = 0;
			m_neighborsMatrix.Data[0, 2] = m_neighborsMatrix.Data[1, 2] = 1;
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
					BoundaryPixels?.Clear();
				}
				BoundaryPixels = null;
				disposedValue = true;
			}
		}

		#endregion IDisposable Support
	}
}