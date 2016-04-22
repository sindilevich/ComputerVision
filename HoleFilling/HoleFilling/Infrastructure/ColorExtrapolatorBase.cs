using System.Collections.Generic;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal abstract class ColorExtrapolatorBase
	{
		protected ColorExtrapolatorBase(WeightingFunction weightingFunction)
		{
			WeightingFunction = weightingFunction;
		}

		protected WeightingFunction WeightingFunction { get; private set; }

		public abstract float ExtrapolateColor(Pixel missingPixel, ICollection<Pixel> boundaryPixels);
	}
}