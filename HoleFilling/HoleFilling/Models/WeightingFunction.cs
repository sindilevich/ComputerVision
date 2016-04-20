using System;

namespace HoleFilling.Models
{
	public class WeightingFunction
	{
		private const float DEFAULT_EPSILON = 0.01f;
		private const int DEFAULT_Z = 3;

		private readonly float m_epsilon;
		private readonly int m_z;
		private Func<long, long, float> m_function;
		private object m_lock = new object();

		public WeightingFunction(string functionBody, int z, float epsilon)
		{
			m_z = z < 1 ?
				DEFAULT_Z :
				z;
			m_epsilon = epsilon < 0f + float.Epsilon || float.IsInfinity(epsilon)
				? DEFAULT_EPSILON :
				epsilon;
		}

		public Func<long, long, float> Calculate
		{
			get
			{
				if (m_function == null)
				{
					lock (m_lock)
					{
						if (m_function == null)
						{
							m_function = (y, x) =>
							{
								return DefaultWeightingFunction(y, x);
							};
						}
					}
				}
				return m_function;
			}
		}

		private float DefaultWeightingFunction(long y, long x)
		{
			// Per C# specification Math.Pow(0d, 0d) == 1
			float exponent = (float)Math.Pow(Math.Abs(x - y), m_z);
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
		}
	}
}