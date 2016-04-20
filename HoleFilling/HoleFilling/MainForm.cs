using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using HoleFilling.Infrastructure;
using HoleFilling.Models;

namespace HoleFilling
{
	public partial class MainForm : Form
	{
		private HoleFiller m_holeFiller;

		public MainForm()
		{
			InitializeComponent();
			FormClosing += (sender, e) => m_holeFiller?.Dispose();
			originalImage.LoadCompleted += async (sender, e) =>
			{
				m_holeFiller?.Dispose();
				m_holeFiller = HoleFiller.Current.Initialize(new MissingPixelsService(), new BoundarySearcher(), originalImage.ImageLocation);
				using (Image<Gray, float> imageWithMarkedBoundaries = await m_holeFiller.MarkBoundaries())
				{
					if (imageWithMarkedBoundaries != null)
					{
						boundariesImage.Image = imageWithMarkedBoundaries;
						ActOnPostImageLoaded();
					}
				}
			};
		}

		private void ActOnPostApproximateFillingHoles(Image<Gray, float> imageWithFilledHoles)
		{
			approximatelyFilledImage.Image = imageWithFilledHoles;
			approximatelyFilledImageIndicatorLabel.Visible = false;
		}

		private void ActOnPostImageLoaded()
		{
			boundariesImageIndicatorLabel.Visible = false;
			fillHolesButton.Enabled = true;
		}

		private void ActOnPostNaiveFillingHoles(Image<Gray, float> imageWithFilledHoles)
		{
			naivelyFilledImage.Image = imageWithFilledHoles;
			naivelyFilledImageIndicatorLabel.Visible = false;
			approximatelyFilledImageIndicatorLabel.Text = "Calculating…";
		}

		private void ActOnPreFillingHoles()
		{
			naivelyFilledImage.Image = null;
			approximatelyFilledImage.Image = null;
			naivelyFilledImageIndicatorLabel.Visible = true;
			approximatelyFilledImageIndicatorLabel.Text = "Waiting…";
			approximatelyFilledImageIndicatorLabel.Visible = true;
		}

		private void ActOnPreImageLoaded()
		{
			boundariesImageIndicatorLabel.Visible = true;
			boundariesImage.Image = null;
			naivelyFilledImage.Image = null;
			approximatelyFilledImage.Image = null;
			fillHolesButton.Enabled = false;
		}

		private string ExtractWeightingFunctionProperties(out int z, out float epsilon, out int boundaryPixelsSampleSize)
		{
			z = 0;
			epsilon = 0f;
			boundaryPixelsSampleSize = 0;
			int.TryParse(zTextbox.Text, out z);
			float.TryParse(epsilonTextbox.Text, out epsilon);
			int.TryParse(boundaryPixelsSampleSizeTextbox.Text, out boundaryPixelsSampleSize);
			return weightingFunctionTextbox.Text;
		}

		private async void fillHolesButton_Click(object sender, EventArgs e)
		{
			string functionBody = string.Empty;
			int z = 0;
			float epsilon = 0f;
			int boundaryPixelsSampleSize = 0;
			ColorExtrapolatorBase colorExtrapolator = null;

			ActOnPreFillingHoles();
			functionBody = ExtractWeightingFunctionProperties(out z, out epsilon, out boundaryPixelsSampleSize);
			colorExtrapolator = new NaiveColorExtrapolator(
				weightingFunction: new WeightingFunction(functionBody, z, epsilon));
			using (Image<Gray, float> imageWithFilledHoles = await m_holeFiller.FillHoles(colorExtrapolator))
			{
				if (imageWithFilledHoles != null)
				{
					ActOnPostNaiveFillingHoles(imageWithFilledHoles);
				}
			}
			colorExtrapolator = new ApproximateColorEtrapolator(
				weightingFunction: new WeightingFunction(functionBody, z, epsilon),
				boundaryPixelsSampleSize: boundaryPixelsSampleSize);
			using (Image<Gray, float> imageWithFilledHoles = await m_holeFiller.FillHoles(colorExtrapolator))
			{
				if (imageWithFilledHoles != null)
				{
					ActOnPostApproximateFillingHoles(imageWithFilledHoles);
				}
			}
		}

		private void openOriginalImageButton_Click(object sender, EventArgs e)
		{
			if (originalImageOpener.ShowDialog() == DialogResult.OK)
			{
				ActOnPreImageLoaded();
				originalImage.ImageLocation = originalImageOpener.FileName;
			}
		}
	}
}