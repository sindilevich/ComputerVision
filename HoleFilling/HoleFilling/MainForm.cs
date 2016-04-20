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
				m_holeFiller?.Dispose();
				m_holeFiller = HoleFiller.Current.Initialize(new MissingPixelsService(), new BoundarySearcher(), originalImage.ImageLocation);
				using (Image<Gray, float> imageWithMarkedBoundaries = await m_holeFiller.MarkBoundaries())
				{
					if (imageWithMarkedBoundaries != null)
					{
						boundariesImage.Image = imageWithMarkedBoundaries;
						boundariesImageIndicatorLabel.Visible = false;
						fillHolesButton.Enabled = true;
					}
				}
			};
		}

		private string ExtractWeightingFunctionProperties(out int z, out float epsilon)
		{
			z = 0;
			epsilon = 0f;
			int.TryParse(zTextbox.Text, out z);
			float.TryParse(epsilonTextbox.Text, out epsilon);
			return weightingFunctionTextbox.Text;
		}

		private async void fillHolesButton_Click(object sender, EventArgs e)
		{
			string functionBody = string.Empty;
			int z = 0;
			float epsilon = 0f;

			filledImage.Image = null;
			filledImageIndicatorLabel.Visible = true;
			functionBody = ExtractWeightingFunctionProperties(out z, out epsilon);
			using (Image<Gray, float> imageWithFilledHoles = await m_holeFiller.FillHoles(functionBody, z, epsilon))
			{
				if (imageWithFilledHoles != null)
				{
					filledImage.Image = imageWithFilledHoles;
					filledImageIndicatorLabel.Visible = false;
				}
			}
		}

		private void openOriginalImageButton_Click(object sender, EventArgs e)
		{
			if (originalImageOpener.ShowDialog() == DialogResult.OK)
			{
				boundariesImageIndicatorLabel.Visible = true;
				boundariesImage.Image = null;
				filledImage.Image = null;
				fillHolesButton.Enabled = false;
				originalImage.ImageLocation = originalImageOpener.FileName;
			}
		}
	}
}