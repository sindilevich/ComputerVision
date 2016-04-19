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
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: -1, row: 1)));
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: 1, row: -1)));
		}

		[TestMethod]
		public void Pixels_Are_OutOfUpperBoundaries()
		{
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: DEFAULT_WIDTH, row: 1)));
			Assert.IsFalse(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: 1, row: DEFAULT_HEIGHT)));
		}

		[TestMethod]
		public void Pixels_Are_WithinBoundaries()
		{
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: 0, row: 0)));
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: DEFAULT_WIDTH - 1, row: DEFAULT_HEIGHT - 1)));
			Assert.IsTrue(m_region.PixelWithinRegion(new Pixel(imageRegion: m_region, column: DEFAULT_WIDTH / 2, row: DEFAULT_HEIGHT / 2)));
		}

		[TestInitialize]
		public void TestInitialize()
		{
			m_region = new ImageRegion(DEFAULT_HEIGHT, DEFAULT_WIDTH);
		}
	}
}