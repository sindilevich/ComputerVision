using System.Collections.Generic;
using System.Linq;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal class NaiveColorExtrapolator : ColorExtrapolatorBase
	{
		public NaiveColorExtrapolator(WeightingFunction weightingFunction) : base(weightingFunction)
		{
		}

		public override float ExtrapolateColor(Pixel missingPixel, IList<Pixel> boundaryPixels)
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