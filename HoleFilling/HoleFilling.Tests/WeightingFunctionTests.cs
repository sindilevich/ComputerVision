using HoleFilling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoleFilling.Tests
{
	[TestClass]
	public class WeightingFunctionTests
	{
		private const float EPSILON = 0.01f;

		[TestMethod]
		public void WeightingFunction_IsCorrect()
		{
			WeightingFunction function = new WeightingFunction(string.Empty, 4, EPSILON);

			Assert.AreEqual(0.0000000015258789062267169356f, function.Calculate(480L, 640L));
		}

		[TestMethod]
		public void WeightingFunction_IsCorrect_Z0_E0_X0_Y0()
		{
			WeightingFunction function = new WeightingFunction(string.Empty, 0, 0f);

			Assert.AreEqual(1f, function.Calculate(0L, 0L));
		}

		[TestMethod]
		public void WeightingFunction_IsCorrect_Z0_X0_Y0()
		{
			WeightingFunction function = new WeightingFunction(string.Empty, 0, EPSILON);

			Assert.AreEqual(1f, function.Calculate(0L, 0L));
		}
	}
}