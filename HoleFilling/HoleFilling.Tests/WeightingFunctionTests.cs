using HoleFilling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoleFilling.Tests
{
	[TestClass]
	public class WeightingFunctionTests
	{
		private const int DEFAULT_HEIGHT = 480;
		private const int DEFAULT_WIDTH = 640;
		private const float EPSILON = 0.01f;

		private ImageRegion m_region;

		[TestInitialize]
		public void TestInitialize()
		{
			m_region = new ImageRegion(DEFAULT_HEIGHT, DEFAULT_WIDTH);
		}

		[TestMethod]
		public void WeightingFunction_IsCorrect()
		{
			WeightingFunction function = new WeightingFunction(m_region, string.Empty, 4, EPSILON);
			Pixel a = new Pixel(m_region, 480, 0);
			Pixel b = new Pixel(m_region, 640, 0);

			Assert.AreEqual(0.0000000015258789062267169356f, function.Calculate(a, b));
		}

		[TestMethod]
		public void WeightingFunction_IsCorrect_Z0_E0_X0_Y0()
		{
			WeightingFunction function = new WeightingFunction(m_region, string.Empty, 0, 0f);
			Pixel a = new Pixel(m_region, 0, 0);
			Pixel b = new Pixel(m_region, 0, 0);

			Assert.AreEqual(1f, function.Calculate(a, b));
		}

		[TestMethod]
		public void WeightingFunction_IsCorrect_Z0_X0_Y0()
		{
			WeightingFunction function = new WeightingFunction(m_region, string.Empty, 0, EPSILON);
			Pixel a = new Pixel(m_region, 0, 0);
			Pixel b = new Pixel(m_region, 0, 0);

			Assert.AreEqual(1f, function.Calculate(a, b));
		}
	}
}