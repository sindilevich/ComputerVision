using System;
using System.Collections.Generic;
using Emgu.CV;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal interface IBoundarySearcher : IDisposable
	{
		ICollection<Pixel> BoundaryPixels { get; }

		void Initialize();

		void TryAddBoundaryPixels(ImageRegion imageRegion, Matrix<float> normalizedImageMatrix, int column, int row);

		void TryMarkBoundaryPixels(Matrix<float> imageMatrix);
	}
}