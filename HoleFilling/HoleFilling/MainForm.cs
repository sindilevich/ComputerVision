using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using HoleFilling.Infrastructure;

namespace HoleFilling
{
	public partial class MainForm : Form
	{
		private HoleFiller m_holeFiller;

		public MainForm()
		{
			InitializeComponent();
			Shown += (sender, e) => openOriginalImageButton.Focus();
			FormClosing += (sender, e) => m_holeFiller.Dispose();
			originalImage.LoadCompleted += async (sender, e) =>
			{
				m_holeFiller = HoleFiller.Current.Initialize(new MissingPixelsService(), new BoundarySearcher(), originalImage.ImageLocation);
				using (Image<Gray, float> imageWithMarkedBoundaries = await m_holeFiller.MarkBoundaries())
				{
					if (imageWithMarkedBoundaries != null)
					{
						boundariesImage.Image = imageWithMarkedBoundaries;
						boundariesImageLoadingLabel.Visible = false;
					}
				}
			};
		}

		private void openOriginalImageButton_Click(object sender, EventArgs e)
		{
			if (originalImageOpener.ShowDialog() == DialogResult.OK)
			{
				boundariesImageLoadingLabel.Visible = true;
				boundariesImage.Image = null;
				originalImage.ImageLocation = originalImageOpener.FileName;
			}
		}
	}
}