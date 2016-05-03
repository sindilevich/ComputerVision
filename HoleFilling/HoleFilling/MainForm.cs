using System;
using System.Diagnostics;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using HoleFilling.Infrastructure;
using HoleFilling.Infrastructure.Logging;
using HoleFilling.Models;

namespace HoleFilling
{
	public partial class MainForm : Form
	{
		private readonly Stopwatch m_stopwatch;
		private HoleFiller m_holeFiller;

		public MainForm()
		{
			InitializeComponent();
			m_stopwatch = new Stopwatch();

			FormClosing += (sender, e) => m_holeFiller?.Dispose();
			originalImage.LoadCompleted += async (sender, e) =>
			{
				LoggingTask logger = null;

				m_holeFiller?.Dispose();
				logger = LoggingTask.Start(LoggingTaskType.FindHolesAndBoundaries, "Finding holes and their boundaries");

				m_holeFiller = HoleFiller.Current.Initialize(new MissingPixelsService(), new BoundarySearcher(), originalImage.ImageLocation);

				logger.Finish();
				logger = LoggingTask.Start(LoggingTaskType.MarkBoundary, "Marking holes boundaries");

				using (Image<Gray, float> imageWithMarkedBoundaries = await m_holeFiller.MarkBoundaries())
				{
					logger.Finish();

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

		private void ExtractVisualizationProperties(out bool markBoundary)
		{
			markBoundary = markBoundaryOnFilledImages.Checked;
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
			bool markBoundary = false;
			ColorInterpolatorBase colorInterpolator = null;
			LoggingTask logger = null;

			ActOnPreFillingHoles();
			functionBody = ExtractWeightingFunctionProperties(out z, out epsilon, out boundaryPixelsSampleSize);
			ExtractVisualizationProperties(out markBoundary);
			colorInterpolator = new NaiveColorInterpolator(
				weightingFunction: new WeightingFunction(functionBody, z, epsilon));

			logger = LoggingTask.Start(LoggingTaskType.FillHoles, "Naively filling holes");

			using (Image<Gray, float> imageWithFilledHoles = await m_holeFiller.FillHoles(colorInterpolator, markBoundary))
			{
				logger.Finish();

				if (imageWithFilledHoles != null)
				{
					ActOnPostNaiveFillingHoles(imageWithFilledHoles);
				}
			}
			colorInterpolator = new ApproximateColorInterpolator(
				weightingFunction: new WeightingFunction(functionBody, z, epsilon),
				boundaryPixelsSampleSize: boundaryPixelsSampleSize);

			logger = LoggingTask.Start(LoggingTaskType.FillHoles, "Approximately filling holes");

			using (Image<Gray, float> imageWithFilledHoles = await m_holeFiller.FillHoles(colorInterpolator, markBoundary))
			{
				logger.Finish();

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