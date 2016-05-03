using System;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal interface IMissingPixelsService : IDisposable
	{
		void Initialize();

		bool TryAddMissingPixel(IBoundarySearcher boundarySearcher, ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row, float color);

		void TryFillHoles(Matrix<float> normalizedImageMatrix, IBoundarySearcher boundarySearcher, ColorInterpolatorBase colorInterpolator);

		void TryMarkMissingPixels(Matrix<float> imageMatrix);
	}
}