using HoleFilling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoleFilling.Tests
{
	[TestClass]
	public class RegionTests
	{
		private const int DEFAULT_HEIGHT = 480;
		private const int DEFAULT_WIDTH = 640;

		private Region m_region;

		[TestMethod]
		public void Pixels_Are_OutOfLowerBoundaries()
		{
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel
			{
				Column = -1,
				Row = 1
			}));
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel
			{
				Column = 1,
				Row = -1
			}));
		}

		[TestMethod]
		public void Pixels_Are_OutOfUpperBoundaries()
		{
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel
			{
				Column = DEFAULT_WIDTH,
				Row = 1
			}));
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel
			{
				Column = 1,
				Row = DEFAULT_HEIGHT
			}));
		}

		[TestMethod]
		public void Pixels_Are_WithinBoundaries()
		{
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel
			{
				Column = 0,
				Row = 0
			}));
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel
			{
				Column = DEFAULT_WIDTH - 1,
				Row = DEFAULT_HEIGHT - 1
			}));
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel
			{
				Column = DEFAULT_WIDTH / 2,
				Row = DEFAULT_HEIGHT / 2
			}));
		}

		[TestInitialize]
		public void TestInitialize()
		{
			m_region = new Region(DEFAULT_HEIGHT, DEFAULT_WIDTH);
		}
	}
}