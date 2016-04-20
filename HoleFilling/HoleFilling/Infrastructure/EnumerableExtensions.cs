using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace HoleFilling.Infrastructure
{
	internal static class EnumerableExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.Shuffle(new Random((int)DateTime.UtcNow.Ticks));
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
		{
			Contract.Assert(source != null);
			Contract.Assert(rng != null);

			return source.ShuffleIterator(rng);
		}

		private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
		{
			IList<T> buffer = source.ToList();

			for (int i = 0; i < buffer.Count; i++)
			{
				int j = rng.Next(i, buffer.Count);

				yield return buffer[j];
				buffer[j] = buffer[i];
			}
		}
	}
}