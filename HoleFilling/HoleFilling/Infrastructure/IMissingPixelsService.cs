using System;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal interface IMissingPixelsService : IDisposable
	{
		void Initialize();

		void TryAddMissingPixel(IBoundarySearcher boundarySearcher, ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row, float color);

		void TryMarkMissingPixels(Matrix<float> imageMatrix);
	}
}