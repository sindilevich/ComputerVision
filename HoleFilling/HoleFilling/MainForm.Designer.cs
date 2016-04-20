namespace HoleFilling
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.originalImage = new Emgu.CV.UI.ImageBox();
			this.originalImageOpener = new System.Windows.Forms.OpenFileDialog();
			this.openOriginalImageButton = new System.Windows.Forms.Button();
			this.originalImageContainer = new System.Windows.Forms.GroupBox();
			this.boundariesImageContainer = new System.Windows.Forms.GroupBox();
			this.boundariesImageIndicatorLabel = new System.Windows.Forms.Label();
			this.boundariesImage = new Emgu.CV.UI.ImageBox();
			this.naivelyFilledImageContainer = new System.Windows.Forms.GroupBox();
			this.naivelyFilledImageIndicatorLabel = new System.Windows.Forms.Label();
			this.naivelyFilledImage = new Emgu.CV.UI.ImageBox();
			this.weightingFunctionLabel = new System.Windows.Forms.Label();
			this.weightingFunctionTextbox = new System.Windows.Forms.TextBox();
			this.zTextbox = new System.Windows.Forms.TextBox();
			this.zLabel = new System.Windows.Forms.Label();
			this.epsilonTextbox = new System.Windows.Forms.TextBox();
			this.epsilonLabel = new System.Windows.Forms.Label();
			this.fillHolesButton = new System.Windows.Forms.Button();
			this.approximatelyFilledImageContainer = new System.Windows.Forms.GroupBox();
			this.approximatelyFilledImageIndicatorLabel = new System.Windows.Forms.Label();
			this.approximatelyFilledImage = new Emgu.CV.UI.ImageBox();
			this.boundaryPixelsSampleSizeTextbox = new System.Windows.Forms.TextBox();
			this.boundaryPixelsSampleSizeLabel = new System.Windows.Forms.Label();
			this.sharedTooltipService = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
			this.originalImageContainer.SuspendLayout();
			this.boundariesImageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.boundariesImage)).BeginInit();
			this.naivelyFilledImageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.naivelyFilledImage)).BeginInit();
			this.approximatelyFilledImageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.approximatelyFilledImage)).BeginInit();
			this.SuspendLayout();
			// 
			// originalImage
			// 
			this.originalImage.Location = new System.Drawing.Point(6, 19);
			this.originalImage.Name = "originalImage";
			this.originalImage.Size = new System.Drawing.Size(320, 240);
			this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.originalImage.TabIndex = 2;
			this.originalImage.TabStop = false;
			// 
			// originalImageOpener
			// 
			this.originalImageOpener.Filter = "BMP files|*.bmp|All files|*.*";
			// 
			// openOriginalImageButton
			// 
			this.openOriginalImageButton.Location = new System.Drawing.Point(13, 13);
			this.openOriginalImageButton.Name = "openOriginalImageButton";
			this.openOriginalImageButton.Size = new System.Drawing.Size(122, 23);
			this.openOriginalImageButton.TabIndex = 0;
			this.openOriginalImageButton.Text = "&Open Original Image";
			this.openOriginalImageButton.UseVisualStyleBackColor = true;
			this.openOriginalImageButton.Click += new System.EventHandler(this.openOriginalImageButton_Click);
			// 
			// originalImageContainer
			// 
			this.originalImageContainer.Controls.Add(this.originalImage);
			this.originalImageContainer.Location = new System.Drawing.Point(12, 42);
			this.originalImageContainer.Name = "originalImageContainer";
			this.originalImageContainer.Size = new System.Drawing.Size(334, 268);
			this.originalImageContainer.TabIndex = 10;
			this.originalImageContainer.TabStop = false;
			this.originalImageContainer.Text = "Original Image";
			// 
			// boundariesImageContainer
			// 
			this.boundariesImageContainer.Controls.Add(this.boundariesImageIndicatorLabel);
			this.boundariesImageContainer.Controls.Add(this.boundariesImage);
			this.boundariesImageContainer.Location = new System.Drawing.Point(378, 42);
			this.boundariesImageContainer.Name = "boundariesImageContainer";
			this.boundariesImageContainer.Size = new System.Drawing.Size(334, 268);
			this.boundariesImageContainer.TabIndex = 11;
			this.boundariesImageContainer.TabStop = false;
			this.boundariesImageContainer.Text = "Boundaries Image";
			// 
			// boundariesImageIndicatorLabel
			// 
			this.boundariesImageIndicatorLabel.AutoSize = true;
			this.boundariesImageIndicatorLabel.Location = new System.Drawing.Point(139, 133);
			this.boundariesImageIndicatorLabel.Name = "boundariesImageIndicatorLabel";
			this.boundariesImageIndicatorLabel.Size = new System.Drawing.Size(51, 13);
			this.boundariesImageIndicatorLabel.TabIndex = 0;
			this.boundariesImageIndicatorLabel.Text = "Loading…";
			this.boundariesImageIndicatorLabel.Visible = false;
			// 
			// boundariesImage
			// 
			this.boundariesImage.Location = new System.Drawing.Point(6, 19);
			this.boundariesImage.Name = "boundariesImage";
			this.boundariesImage.Size = new System.Drawing.Size(320, 240);
			this.boundariesImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.boundariesImage.TabIndex = 2;
			this.boundariesImage.TabStop = false;
			// 
			// naivelyFilledImageContainer
			// 
			this.naivelyFilledImageContainer.Controls.Add(this.naivelyFilledImageIndicatorLabel);
			this.naivelyFilledImageContainer.Controls.Add(this.naivelyFilledImage);
			this.naivelyFilledImageContainer.Location = new System.Drawing.Point(18, 329);
			this.naivelyFilledImageContainer.Name = "naivelyFilledImageContainer";
			this.naivelyFilledImageContainer.Size = new System.Drawing.Size(334, 268);
			this.naivelyFilledImageContainer.TabIndex = 12;
			this.naivelyFilledImageContainer.TabStop = false;
			this.naivelyFilledImageContainer.Text = "Naively Filled Image";
			// 
			// naivelyFilledImageIndicatorLabel
			// 
			this.naivelyFilledImageIndicatorLabel.AutoSize = true;
			this.naivelyFilledImageIndicatorLabel.Location = new System.Drawing.Point(139, 133);
			this.naivelyFilledImageIndicatorLabel.Name = "naivelyFilledImageIndicatorLabel";
			this.naivelyFilledImageIndicatorLabel.Size = new System.Drawing.Size(65, 13);
			this.naivelyFilledImageIndicatorLabel.TabIndex = 0;
			this.naivelyFilledImageIndicatorLabel.Text = "Calculating…";
			this.naivelyFilledImageIndicatorLabel.Visible = false;
			// 
			// naivelyFilledImage
			// 
			this.naivelyFilledImage.Location = new System.Drawing.Point(6, 19);
			this.naivelyFilledImage.Name = "naivelyFilledImage";
			this.naivelyFilledImage.Size = new System.Drawing.Size(320, 240);
			this.naivelyFilledImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.naivelyFilledImage.TabIndex = 2;
			this.naivelyFilledImage.TabStop = false;
			// 
			// weightingFunctionLabel
			// 
			this.weightingFunctionLabel.AutoSize = true;
			this.weightingFunctionLabel.Location = new System.Drawing.Point(152, 18);
			this.weightingFunctionLabel.Name = "weightingFunctionLabel";
			this.weightingFunctionLabel.Size = new System.Drawing.Size(65, 13);
			this.weightingFunctionLabel.TabIndex = 1;
			this.weightingFunctionLabel.Text = "W. function:";
			this.sharedTooltipService.SetToolTip(this.weightingFunctionLabel, "Weighting function");
			// 
			// weightingFunctionTextbox
			// 
			this.weightingFunctionTextbox.Location = new System.Drawing.Point(223, 14);
			this.weightingFunctionTextbox.Name = "weightingFunctionTextbox";
			this.weightingFunctionTextbox.ReadOnly = true;
			this.weightingFunctionTextbox.Size = new System.Drawing.Size(230, 20);
			this.weightingFunctionTextbox.TabIndex = 2;
			this.weightingFunctionTextbox.Text = "(float)1 / Math.Pow(Math.Abs(x - y), z) + epsilon";
			// 
			// zTextbox
			// 
			this.zTextbox.Location = new System.Drawing.Point(480, 14);
			this.zTextbox.Name = "zTextbox";
			this.zTextbox.Size = new System.Drawing.Size(30, 20);
			this.zTextbox.TabIndex = 4;
			this.zTextbox.Text = "3";
			// 
			// zLabel
			// 
			this.zLabel.AutoSize = true;
			this.zLabel.Location = new System.Drawing.Point(459, 18);
			this.zLabel.Name = "zLabel";
			this.zLabel.Size = new System.Drawing.Size(15, 13);
			this.zLabel.TabIndex = 3;
			this.zLabel.Text = "z:";
			// 
			// epsilonTextbox
			// 
			this.epsilonTextbox.Location = new System.Drawing.Point(537, 14);
			this.epsilonTextbox.Name = "epsilonTextbox";
			this.epsilonTextbox.Size = new System.Drawing.Size(30, 20);
			this.epsilonTextbox.TabIndex = 6;
			this.epsilonTextbox.Text = "0.01";
			// 
			// epsilonLabel
			// 
			this.epsilonLabel.AutoSize = true;
			this.epsilonLabel.Location = new System.Drawing.Point(516, 18);
			this.epsilonLabel.Name = "epsilonLabel";
			this.epsilonLabel.Size = new System.Drawing.Size(16, 13);
			this.epsilonLabel.TabIndex = 5;
			this.epsilonLabel.Text = "ε:";
			// 
			// fillHolesButton
			// 
			this.fillHolesButton.Enabled = false;
			this.fillHolesButton.Location = new System.Drawing.Point(637, 13);
			this.fillHolesButton.Name = "fillHolesButton";
			this.fillHolesButton.Size = new System.Drawing.Size(75, 23);
			this.fillHolesButton.TabIndex = 9;
			this.fillHolesButton.Text = "&Fill Holes";
			this.fillHolesButton.UseVisualStyleBackColor = true;
			this.fillHolesButton.Click += new System.EventHandler(this.fillHolesButton_Click);
			// 
			// approximatelyFilledImageContainer
			// 
			this.approximatelyFilledImageContainer.Controls.Add(this.approximatelyFilledImageIndicatorLabel);
			this.approximatelyFilledImageContainer.Controls.Add(this.approximatelyFilledImage);
			this.approximatelyFilledImageContainer.Location = new System.Drawing.Point(378, 331);
			this.approximatelyFilledImageContainer.Name = "approximatelyFilledImageContainer";
			this.approximatelyFilledImageContainer.Size = new System.Drawing.Size(334, 268);
			this.approximatelyFilledImageContainer.TabIndex = 13;
			this.approximatelyFilledImageContainer.TabStop = false;
			this.approximatelyFilledImageContainer.Text = "Approximately Filled Image";
			// 
			// approximatelyFilledImageIndicatorLabel
			// 
			this.approximatelyFilledImageIndicatorLabel.AutoSize = true;
			this.approximatelyFilledImageIndicatorLabel.Location = new System.Drawing.Point(139, 133);
			this.approximatelyFilledImageIndicatorLabel.Name = "approximatelyFilledImageIndicatorLabel";
			this.approximatelyFilledImageIndicatorLabel.Size = new System.Drawing.Size(49, 13);
			this.approximatelyFilledImageIndicatorLabel.TabIndex = 0;
			this.approximatelyFilledImageIndicatorLabel.Text = "Waiting…";
			this.approximatelyFilledImageIndicatorLabel.Visible = false;
			// 
			// approximatelyFilledImage
			// 
			this.approximatelyFilledImage.Location = new System.Drawing.Point(6, 19);
			this.approximatelyFilledImage.Name = "approximatelyFilledImage";
			this.approximatelyFilledImage.Size = new System.Drawing.Size(320, 240);
			this.approximatelyFilledImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.approximatelyFilledImage.TabIndex = 2;
			this.approximatelyFilledImage.TabStop = false;
			// 
			// boundaryPixelsSampleSizeTextbox
			// 
			this.boundaryPixelsSampleSizeTextbox.Location = new System.Drawing.Point(594, 14);
			this.boundaryPixelsSampleSizeTextbox.Name = "boundaryPixelsSampleSizeTextbox";
			this.boundaryPixelsSampleSizeTextbox.Size = new System.Drawing.Size(30, 20);
			this.boundaryPixelsSampleSizeTextbox.TabIndex = 8;
			this.boundaryPixelsSampleSizeTextbox.Text = "100";
			// 
			// boundaryPixelsSampleSizeLabel
			// 
			this.boundaryPixelsSampleSizeLabel.AutoSize = true;
			this.boundaryPixelsSampleSizeLabel.Location = new System.Drawing.Point(573, 18);
			this.boundaryPixelsSampleSizeLabel.Name = "boundaryPixelsSampleSizeLabel";
			this.boundaryPixelsSampleSizeLabel.Size = new System.Drawing.Size(16, 13);
			this.boundaryPixelsSampleSizeLabel.TabIndex = 7;
			this.boundaryPixelsSampleSizeLabel.Text = "k:";
			this.sharedTooltipService.SetToolTip(this.boundaryPixelsSampleSizeLabel, "Boundary pixels sample size");
			// 
			// MainForm
			// 
			this.AcceptButton = this.openOriginalImageButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 611);
			this.Controls.Add(this.boundaryPixelsSampleSizeTextbox);
			this.Controls.Add(this.boundaryPixelsSampleSizeLabel);
			this.Controls.Add(this.approximatelyFilledImageContainer);
			this.Controls.Add(this.fillHolesButton);
			this.Controls.Add(this.epsilonTextbox);
			this.Controls.Add(this.epsilonLabel);
			this.Controls.Add(this.zTextbox);
			this.Controls.Add(this.zLabel);
			this.Controls.Add(this.weightingFunctionTextbox);
			this.Controls.Add(this.weightingFunctionLabel);
			this.Controls.Add(this.naivelyFilledImageContainer);
			this.Controls.Add(this.boundariesImageContainer);
			this.Controls.Add(this.originalImageContainer);
			this.Controls.Add(this.openOriginalImageButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Hole Filling — Matanel Sindilevich";
			((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
			this.originalImageContainer.ResumeLayout(false);
			this.boundariesImageContainer.ResumeLayout(false);
			this.boundariesImageContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.boundariesImage)).EndInit();
			this.naivelyFilledImageContainer.ResumeLayout(false);
			this.naivelyFilledImageContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.naivelyFilledImage)).EndInit();
			this.approximatelyFilledImageContainer.ResumeLayout(false);
			this.approximatelyFilledImageContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.approximatelyFilledImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Emgu.CV.UI.ImageBox originalImage;
		private System.Windows.Forms.OpenFileDialog originalImageOpener;
		private System.Windows.Forms.Button openOriginalImageButton;
		private System.Windows.Forms.GroupBox originalImageContainer;
		private System.Windows.Forms.GroupBox boundariesImageContainer;
		private Emgu.CV.UI.ImageBox boundariesImage;
		private System.Windows.Forms.GroupBox naivelyFilledImageContainer;
		private Emgu.CV.UI.ImageBox naivelyFilledImage;
		private System.Windows.Forms.Label boundariesImageIndicatorLabel;
		private System.Windows.Forms.Label naivelyFilledImageIndicatorLabel;
		private System.Windows.Forms.Label weightingFunctionLabel;
		private System.Windows.Forms.TextBox weightingFunctionTextbox;
		private System.Windows.Forms.TextBox zTextbox;
		private System.Windows.Forms.Label zLabel;
		private System.Windows.Forms.TextBox epsilonTextbox;
		private System.Windows.Forms.Label epsilonLabel;
		private System.Windows.Forms.Button fillHolesButton;
		private System.Windows.Forms.GroupBox approximatelyFilledImageContainer;
		private System.Windows.Forms.Label approximatelyFilledImageIndicatorLabel;
		private Emgu.CV.UI.ImageBox approximatelyFilledImage;
		private System.Windows.Forms.TextBox boundaryPixelsSampleSizeTextbox;
		private System.Windows.Forms.Label boundaryPixelsSampleSizeLabel;
		private System.Windows.Forms.ToolTip sharedTooltipService;
	}
}

