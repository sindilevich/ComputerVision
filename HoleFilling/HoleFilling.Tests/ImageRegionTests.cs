using System;
using HoleFilling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoleFilling.Tests
{
	[TestClass]
	public class ImageRegionTests
	{
		private const int DEFAULT_HEIGHT = 480;
		private const int DEFAULT_WIDTH = 640;

		private ImageRegion m_region;

		[TestMethod]
		public void Pixels_Are_OutOfLowerBoundaries()
		{
			Assert.IsFalse(m_region.PixelWithinRegion(column: -1, row: 1));
			Assert.IsFalse(m_region.PixelWithinRegion(column: 1, row: -1));
		}

		[TestMethod]
		public void Pixels_Are_OutOfUpperBoundaries()
		{
			Assert.IsFalse(m_region.PixelWithinRegion(column: DEFAULT_WIDTH, row: 1));
			Assert.IsFalse(m_region.PixelWithinRegion(column: 1, row: DEFAULT_HEIGHT));
		}

		[TestMethod]
		public void Pixels_Are_WithinBoundaries()
		{
			Assert.IsTrue(m_region.PixelWithinRegion(column: 0, row: 0));
			Assert.IsTrue(m_region.PixelWithinRegion(column: DEFAULT_WIDTH - 1, row: DEFAULT_HEIGHT - 1));
			Assert.IsTrue(m_region.PixelWithinRegion(column: DEFAULT_WIDTH / 2, row: DEFAULT_HEIGHT / 2));
		}

		[TestMethod]
		public void Pixels_Have_CorrectEuclideanDistance()
		{
			Pixel atBeginning = new Pixel(m_region, 0, 0);
			Pixel atEnd = new Pixel(m_region, DEFAULT_WIDTH - 1, DEFAULT_HEIGHT - 1);

			Assert.AreEqual(Math.Sqrt(Math.Pow(DEFAULT_HEIGHT - 1, 2d) + Math.Pow(DEFAULT_WIDTH - 1, 2d)), m_region.CalculateEuclideanDistance(atBeginning, atEnd));
		}

		[TestInitialize]
		public void TestInitialize()
		{
			m_region = new ImageRegion(DEFAULT_HEIGHT, DEFAULT_WIDTH);
		}
	}
}