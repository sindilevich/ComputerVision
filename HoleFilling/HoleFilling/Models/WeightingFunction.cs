using System;

namespace HoleFilling.Models
{
	public class WeightingFunction
	{
		private const float DEFAULT_EPSILON = 0.01f;
		private const int DEFAULT_Z = 3;

		private readonly float m_epsilon;
		private readonly string m_functionBody;
		private readonly ImageRegion m_imageRegion;
		private readonly int m_z;
		private Func<Pixel, Pixel, float> m_function;
		private object m_lock = new object();

		public WeightingFunction(ImageRegion imageRegion, string functionBody, int z, float epsilon)
		{
			m_imageRegion = imageRegion;
			m_functionBody = functionBody;
			m_z = z < 1 ?
				DEFAULT_Z :
				z;
			m_epsilon = epsilon < 0f + float.Epsilon || float.IsInfinity(epsilon)
				? DEFAULT_EPSILON :
				epsilon;
		}

		public Func<Pixel, Pixel, float> Calculate
		{
			get
			{
				if (m_function == null)
				{
					lock (m_lock)
					{
						if (m_function == null)
						{
							m_function = CreateWeightingFunctionDynamically() ?? DefaultWeightingFunction();
						}
					}
				}
				return m_function;
			}
		}

		private Func<Pixel, Pixel, float> CreateWeightingFunctionDynamically()
		{
			// TODO: Add magic to convert function body from text to executable code
			return null;
		}

		private Func<Pixel, Pixel, float> DefaultWeightingFunction()
		{
			return (y, x) =>
			{
				// Per C# specification Math.Pow(0d, 0d) == 1
				float exponent = (float)Math.Pow(m_imageRegion.CalculateEuclideanDistance(x, y), m_z);
				float result = 0f;

				if (float.IsNegativeInfinity(exponent))
				{
					exponent = float.MinValue;
				}
				else if (float.IsPositiveInfinity(exponent))
				{
					exponent = float.MaxValue;
				}
				result = 1f / (exponent + m_epsilon);
				return result > 1 ?
					1 :
					result;
			};
		}
	}
}