using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal sealed class HoleFiller : IDisposable
	{
		private const int COLOR_BLACK = 0;
		private const float COLOR_INVALID = -1f;
		private const float COLOR_WHITE = 255;

		private static Lazy<HoleFiller> m_instance = new Lazy<HoleFiller>();

		private IList<Pixel> m_boundaryPixels;
		private Region m_imageRegion;
		private string m_imageUri;
		private IList<Pixel> m_missingPixels;
		private Matrix<int> m_neighborsMatrix = new Matrix<int>(2, 3);
		private Matrix<float> m_normalizedImageMatrix;

		public static HoleFiller Current
		{
			get
			{
				return m_instance.Value;
			}
		}

		public HoleFiller Initialize(string imageUri)
		{
			m_imageUri = imageUri;
			InitializeNeighborsMatrix();
			InitializeImageMatrix();
			return this;
		}

		public async Task<Image<Gray, float>> MarkBoundaries()
		{
			Image<Gray, float> result = null;

			await Task.Run(() =>
			{
				result = new Image<Gray, float>(m_normalizedImageMatrix.Cols, m_normalizedImageMatrix.Rows);

				using (Matrix<float> imageWithMarkedBoundariesMatrix = new Matrix<float>(m_normalizedImageMatrix.Rows, m_normalizedImageMatrix.Cols))
				{
					m_normalizedImageMatrix.CopyTo(imageWithMarkedBoundariesMatrix);
					imageWithMarkedBoundariesMatrix._Mul(COLOR_WHITE);
					m_boundaryPixels.All(boundaryPixel =>
					{
						imageWithMarkedBoundariesMatrix[boundaryPixel.Row, boundaryPixel.Column] = COLOR_BLACK;
						return true;
					});
					m_missingPixels.All(missingPixel =>
					{
						imageWithMarkedBoundariesMatrix[missingPixel.Row, missingPixel.Column] = COLOR_WHITE;
						return true;
					});
					imageWithMarkedBoundariesMatrix.CopyTo(result);
				}
			});
			return result;
		}

		private float AnalyzePixel(int column, int row, float color)
		{
			float squeezedColor = SqueezeColorIntoRange(color);

			TryAddMissingPixel(column, row, squeezedColor);
			return squeezedColor;
		}

		private void InitializeImageMatrix()
		{
			using (Image<Gray, float> image = new Image<Gray, float>(m_imageUri))
			{
				m_normalizedImageMatrix = new Matrix<float>(image.Height, image.Width);
				m_imageRegion = new Region(image.Height, image.Width);
				m_boundaryPixels = new List<Pixel>();
				m_missingPixels = new List<Pixel>();
				image.CopyTo(m_normalizedImageMatrix);
			}
			for (int row = 0; row < m_normalizedImageMatrix.Rows; row++)
			{
				for (int column = 0; column < m_normalizedImageMatrix.Cols; column++)
				{
					float color = m_normalizedImageMatrix.Data[row, column];

					m_normalizedImageMatrix.Data[row, column] = AnalyzePixel(column, row, color);
				}
			}
		}

		private void InitializeNeighborsMatrix()
		{
			m_neighborsMatrix.Data[0, 0] = m_neighborsMatrix.Data[1, 0] = -1;
			m_neighborsMatrix.Data[0, 1] = m_neighborsMatrix.Data[1, 1] = 0;
			m_neighborsMatrix.Data[0, 2] = m_neighborsMatrix.Data[1, 2] = 1;
		}

		private float SqueezeColorIntoRange(float color)
		{
			return color == COLOR_WHITE ?
				COLOR_INVALID :
				color /= COLOR_WHITE;
		}

		private void TryAddBoundaryPixels(int column, int row)
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
							Pixel boundaryPixel = new Pixel
							{
								Column = neighborColumn,
								Row = neighborRow
							};

							if (m_imageRegion.PixelWithinRegion(boundaryPixel))
							{
								float boundaryColor = m_normalizedImageMatrix.Data[neighborRow, neighborColumn];

								if (boundaryColor != COLOR_INVALID && boundaryColor != COLOR_WHITE)
								{
									boundaryPixel.Color = boundaryColor;
									m_boundaryPixels.Add(boundaryPixel);
								}
							}
						}
					}
				}
			}
		}

		private void TryAddMissingPixel(int column, int row, float color)
		{
			if (color == COLOR_INVALID)
			{
				Pixel missing = new Pixel
				{
					Color = color,
					Column = column,
					Row = row
				};

				m_missingPixels.Add(missing);
				TryAddBoundaryPixels(column, row);
			}
		}

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
		}

		private void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					m_neighborsMatrix.Dispose();
					m_normalizedImageMatrix.Dispose();
				}

				m_boundaryPixels = null;
				m_missingPixels = null;
				m_neighborsMatrix = null;
				m_normalizedImageMatrix = null;
				disposedValue = true;
			}
		}

		#endregion IDisposable Support
	}
}