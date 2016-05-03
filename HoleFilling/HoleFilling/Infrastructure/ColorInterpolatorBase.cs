using System.Collections.Generic;
using HoleFilling.Models;

namespace HoleFilling.Infrastructure
{
	internal abstract class ColorInterpolatorBase
	{
		protected ColorInterpolatorBase(WeightingFunction weightingFunction)
		{
			WeightingFunction = weightingFunction;
		}

		protected WeightingFunction WeightingFunction { get; private set; }

		public abstract float InterpolateColor(Pixel missingPixel, ICollection<Pixel> boundaryPixels);
	}
}