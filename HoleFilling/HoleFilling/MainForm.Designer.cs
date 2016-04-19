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
			this.boundariesImageLoadingLabel = new System.Windows.Forms.Label();
			this.boundariesImage = new Emgu.CV.UI.ImageBox();
			this.filledImageContainer = new System.Windows.Forms.GroupBox();
			this.filledImageLoadingLabel = new System.Windows.Forms.Label();
			this.filledImage = new Emgu.CV.UI.ImageBox();
			((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
			this.originalImageContainer.SuspendLayout();
			this.boundariesImageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.boundariesImage)).BeginInit();
			this.filledImageContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.filledImage)).BeginInit();
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
			this.openOriginalImageButton.TabIndex = 3;
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
			this.originalImageContainer.TabIndex = 6;
			this.originalImageContainer.TabStop = false;
			this.originalImageContainer.Text = "Original Image";
			// 
			// boundariesImageContainer
			// 
			this.boundariesImageContainer.Controls.Add(this.boundariesImageLoadingLabel);
			this.boundariesImageContainer.Controls.Add(this.boundariesImage);
			this.boundariesImageContainer.Location = new System.Drawing.Point(378, 42);
			this.boundariesImageContainer.Name = "boundariesImageContainer";
			this.boundariesImageContainer.Size = new System.Drawing.Size(334, 268);
			this.boundariesImageContainer.TabIndex = 7;
			this.boundariesImageContainer.TabStop = false;
			this.boundariesImageContainer.Text = "Boundaries Image";
			// 
			// boundariesImageLoadingLabel
			// 
			this.boundariesImageLoadingLabel.AutoSize = true;
			this.boundariesImageLoadingLabel.Location = new System.Drawing.Point(139, 133);
			this.boundariesImageLoadingLabel.Name = "boundariesImageLoadingLabel";
			this.boundariesImageLoadingLabel.Size = new System.Drawing.Size(54, 13);
			this.boundariesImageLoadingLabel.TabIndex = 3;
			this.boundariesImageLoadingLabel.Text = "Loading...";
			this.boundariesImageLoadingLabel.Visible = false;
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
			// filledImageContainer
			// 
			this.filledImageContainer.Controls.Add(this.filledImageLoadingLabel);
			this.filledImageContainer.Controls.Add(this.filledImage);
			this.filledImageContainer.Location = new System.Drawing.Point(18, 329);
			this.filledImageContainer.Name = "filledImageContainer";
			this.filledImageContainer.Size = new System.Drawing.Size(334, 268);
			this.filledImageContainer.TabIndex = 7;
			this.filledImageContainer.TabStop = false;
			this.filledImageContainer.Text = "Filled Image";
			// 
			// filledImageLoadingLabel
			// 
			this.filledImageLoadingLabel.AutoSize = true;
			this.filledImageLoadingLabel.Location = new System.Drawing.Point(139, 133);
			this.filledImageLoadingLabel.Name = "filledImageLoadingLabel";
			this.filledImageLoadingLabel.Size = new System.Drawing.Size(54, 13);
			this.filledImageLoadingLabel.TabIndex = 4;
			this.filledImageLoadingLabel.Text = "Loading...";
			this.filledImageLoadingLabel.Visible = false;
			// 
			// filledImage
			// 
			this.filledImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
			this.filledImage.Location = new System.Drawing.Point(6, 19);
			this.filledImage.Name = "filledImage";
			this.filledImage.Size = new System.Drawing.Size(320, 240);
			this.filledImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.filledImage.TabIndex = 2;
			this.filledImage.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 611);
			this.Controls.Add(this.filledImageContainer);
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
			this.filledImageContainer.ResumeLayout(false);
			this.filledImageContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.filledImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Emgu.CV.UI.ImageBox originalImage;
		private System.Windows.Forms.OpenFileDialog originalImageOpener;
		private System.Windows.Forms.Button openOriginalImageButton;
		private System.Windows.Forms.GroupBox originalImageContainer;
		private System.Windows.Forms.GroupBox boundariesImageContainer;
		private Emgu.CV.UI.ImageBox boundariesImage;
		private System.Windows.Forms.GroupBox filledImageContainer;
		private Emgu.CV.UI.ImageBox filledImage;
		private System.Windows.Forms.Label boundariesImageLoadingLabel;
		private System.Windows.Forms.Label filledImageLoadingLabel;
	}
}

