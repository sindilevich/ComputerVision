using HoleFilling.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoleFilling.Tests
{
	[TestClass]
	public class PixelTests
	{
		private const int DEFAULT_HEIGHT = 480;
		private const int DEFAULT_WIDTH = 640;

		private ImageRegion m_region;

		[TestMethod]
		public void Pixels_DirectLocation_IsCorrect()
		{
			Assert.AreEqual(0, new Pixel(imageRegion: m_region, column: 0, row: 0).DirectLocation);
			Assert.AreEqual((long)DEFAULT_HEIGHT * DEFAULT_WIDTH - 1, new Pixel(imageRegion: m_region, column: DEFAULT_WIDTH - 1, row: DEFAULT_HEIGHT - 1).DirectLocation);
			Assert.AreEqual((long)(DEFAULT_HEIGHT / 2) * m_region.Width + DEFAULT_WIDTH / 2, new Pixel(imageRegion: m_region, column: DEFAULT_WIDTH / 2, row: DEFAULT_HEIGHT / 2).DirectLocation);
		}

		[TestInitialize]
		public void TestInitialize()
		{
			m_region = new ImageRegion(DEFAULT_HEIGHT, DEFAULT_WIDTH);
		}
	}
}