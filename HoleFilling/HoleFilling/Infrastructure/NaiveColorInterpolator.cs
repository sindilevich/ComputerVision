using System.Collections.Generic;
using System.Linq;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class NaiveColorInterpolator : ColorInterpolatorBase
	{
		public NaiveColorInterpolator(WeightingFunction weightingFunction) : base(weightingFunction)
		{
		}

		public override float InterpolateColor(Pixel missingPixel, ICollection<Pixel> boundaryPixels)
		{
			float numerator = 0f;
			float denominator = 0f;

			boundaryPixels
				.All(boundaryPixel =>
				{
					float weight = WeightingFunction.Calculate(boundaryPixel.DirectLocation, missingPixel.DirectLocation);

					numerator += (weight * boundaryPixel.Color);
					denominator += weight;
					return true;
				});
			return numerator / denominator;
		}
	}
}