using System;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal sealed class HoleFiller : IDisposable
	{
		private static Lazy<HoleFiller> m_instance = new Lazy<HoleFiller>();

		private IBoundarySearcher m_boundarySearher;
		private ImageRegion m_imageRegion;
		private string m_imageUri;
		private IMissingPixelsService m_missingPixelsService;
		private Matrix<float> m_normalizedImageMatrix;

		public static HoleFiller Current
		{
			get
			{
				return m_instance.Value;
			}
		}

		public async Task<Image<Gray, float>> FillHoles(ColorExtrapolatorBase colorExtrapolator, bool markBoundary)
		{
			Image<Gray, float> result = null;

			await Task.Run(() =>
			{
				result = new Image<Gray, float>(m_normalizedImageMatrix.Cols, m_normalizedImageMatrix.Rows);

				using (Matrix<float> filledImageMatrix = new Matrix<float>(m_normalizedImageMatrix.Rows, m_normalizedImageMatrix.Cols))
				{
					m_normalizedImageMatrix.CopyTo(filledImageMatrix);
					m_missingPixelsService.TryFillHoles(filledImageMatrix, m_boundarySearher, colorExtrapolator);
					ImageColorsService.ScaleUp(filledImageMatrix);
					if (markBoundary)
					{
						m_boundarySearher.TryMarkBoundaryPixels(filledImageMatrix);
					}
					filledImageMatrix.CopyTo(result);
				}
			});
			return result;
		}

		public HoleFiller Initialize(IMissingPixelsService missingPixelsService, IBoundarySearcher boundarySearcher, string imageUri)
		{
			m_imageUri = imageUri;
			InitializeBoundarySearcher(boundarySearcher);
			InitializeMissingPixelsService(missingPixelsService);
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
					ImageColorsService.ScaleUp(imageWithMarkedBoundariesMatrix);
					m_boundarySearher.TryMarkBoundaryPixels(imageWithMarkedBoundariesMatrix);
					m_missingPixelsService.TryMarkMissingPixels(imageWithMarkedBoundariesMatrix);
					imageWithMarkedBoundariesMatrix.CopyTo(result);
				}
			});
			return result;
		}

		private bool AnalyzePixel(int column, int row, float color)
		{
			return m_missingPixelsService.TryAddMissingPixel(m_boundarySearher, m_imageRegion, m_normalizedImageMatrix, column, row, color);
		}

		private void FindBoundaryAndHole()
		{
			bool foundHole = false;

			for (int row = 0; row < m_normalizedImageMatrix.Rows; row++)
			{
				bool foundHoleInTheRow = false;

				for (int column = 0; column < m_normalizedImageMatrix.Cols; column++)
				{
					float color = m_normalizedImageMatrix.Data[row, column];

					foundHoleInTheRow = AnalyzePixel(column, row, color);
				}
				// TODO: Heads up, optimization based on fact there is only a single hole in the image
				if (foundHoleInTheRow)
				{
					foundHole = true;
				}
				else if (foundHole)
				{
					return;
				}
				// TODO: Heads up, end of optimization based on fact there is only a single hole in the image
			}
		}

		private void InitializeBoundarySearcher(IBoundarySearcher boundarySearcher)
		{
			m_boundarySearher = boundarySearcher;
			m_boundarySearher.Initialize();
		}

		private void InitializeImageMatrix()
		{
			using (Image<Gray, float> image = new Image<Gray, float>(m_imageUri))
			{
				m_normalizedImageMatrix = new Matrix<float>(image.Height, image.Width);
				m_imageRegion = new ImageRegion(image.Height, image.Width);
				image.CopyTo(m_normalizedImageMatrix);
			}
			FindBoundaryAndHole();
			ImageColorsService.ScaleDown(m_normalizedImageMatrix);
		}

		private void InitializeMissingPixelsService(IMissingPixelsService missingPixelsService)
		{
			m_missingPixelsService = missingPixelsService;
			m_missingPixelsService.Initialize();
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
					m_boundarySearher?.Dispose();
					m_missingPixelsService?.Dispose();
					m_normalizedImageMatrix?.Dispose();
				}

				m_boundarySearher = null;
				m_missingPixelsService = null;
				m_normalizedImageMatrix = null;
				disposedValue = true;
			}
		}

		#endregion IDisposable Support
	}
}