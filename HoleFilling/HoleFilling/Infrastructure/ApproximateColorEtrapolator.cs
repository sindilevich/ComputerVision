using System.Collections.Generic;
using System.Linq;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class ApproximateColorEtrapolator : ColorExtrapolatorBase
	{
		private readonly int m_boundaryPixelsSampleSize;

		public ApproximateColorEtrapolator(WeightingFunction weightingFunction, int boundaryPixelsSampleSize) : base(weightingFunction)
		{
			m_boundaryPixelsSampleSize = boundaryPixelsSampleSize;
		}

		public override float ExtrapolateColor(Pixel missingPixel, ICollection<Pixel> boundaryPixels)
		{
			float numerator = 0f;
			float denominator = 0f;

			GetRandomSubset(boundaryPixels)
				.All(boundaryPixel =>
				{
					float weight = WeightingFunction.Calculate(boundaryPixel.DirectLocation, missingPixel.DirectLocation);

					numerator += (weight * boundaryPixel.Color);
					denominator += weight;
					return true;
				});
			return numerator / denominator;
		}

		private ICollection<Pixel> GetRandomSubset(ICollection<Pixel> set)
		{
			return set
				.Shuffle()
				.Take(m_boundaryPixelsSampleSize)
				.ToList();
		}
	}
}