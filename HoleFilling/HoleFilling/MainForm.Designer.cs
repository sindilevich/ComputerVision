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
			this.filledImageContainer = new System.Windows.Forms.GroupBox();
			this.filledImageIndicatorLabel = new System.Windows.Forms.Label();
			this.filledImage = new Emgu.CV.UI.ImageBox();
			this.weightingFunctionLabel = new System.Windows.Forms.Label();
			this.weightingFunctionTextbox = new System.Windows.Forms.TextBox();
			this.zTextbox = new System.Windows.Forms.TextBox();
			this.zLabel = new System.Windows.Forms.Label();
			this.epsilonTextbox = new System.Windows.Forms.TextBox();
			this.epsilonLabel = new System.Windows.Forms.Label();
			this.fillHolesButton = new System.Windows.Forms.Button();
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
			this.boundariesImageContainer.Controls.Add(this.boundariesImageIndicatorLabel);
			this.boundariesImageContainer.Controls.Add(this.boundariesImage);
			this.boundariesImageContainer.Location = new System.Drawing.Point(378, 42);
			this.boundariesImageContainer.Name = "boundariesImageContainer";
			this.boundariesImageContainer.Size = new System.Drawing.Size(334, 268);
			this.boundariesImageContainer.TabIndex = 7;
			this.boundariesImageContainer.TabStop = false;
			this.boundariesImageContainer.Text = "Boundaries Image";
			// 
			// boundariesImageIndicatorLabel
			// 
			this.boundariesImageIndicatorLabel.AutoSize = true;
			this.boundariesImageIndicatorLabel.Location = new System.Drawing.Point(139, 133);
			this.boundariesImageIndicatorLabel.Name = "boundariesImageIndicatorLabel";
			this.boundariesImageIndicatorLabel.Size = new System.Drawing.Size(54, 13);
			this.boundariesImageIndicatorLabel.TabIndex = 3;
			this.boundariesImageIndicatorLabel.Text = "Loading...";
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
			// filledImageContainer
			// 
			this.filledImageContainer.Controls.Add(this.filledImageIndicatorLabel);
			this.filledImageContainer.Controls.Add(this.filledImage);
			this.filledImageContainer.Location = new System.Drawing.Point(18, 329);
			this.filledImageContainer.Name = "filledImageContainer";
			this.filledImageContainer.Size = new System.Drawing.Size(334, 268);
			this.filledImageContainer.TabIndex = 7;
			this.filledImageContainer.TabStop = false;
			this.filledImageContainer.Text = "Filled Image";
			// 
			// filledImageIndicatorLabel
			// 
			this.filledImageIndicatorLabel.AutoSize = true;
			this.filledImageIndicatorLabel.Location = new System.Drawing.Point(139, 133);
			this.filledImageIndicatorLabel.Name = "filledImageIndicatorLabel";
			this.filledImageIndicatorLabel.Size = new System.Drawing.Size(68, 13);
			this.filledImageIndicatorLabel.TabIndex = 4;
			this.filledImageIndicatorLabel.Text = "Calculating...";
			this.filledImageIndicatorLabel.Visible = false;
			// 
			// filledImage
			// 
			this.filledImage.Location = new System.Drawing.Point(6, 19);
			this.filledImage.Name = "filledImage";
			this.filledImage.Size = new System.Drawing.Size(320, 240);
			this.filledImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.filledImage.TabIndex = 2;
			this.filledImage.TabStop = false;
			// 
			// weightingFunctionLabel
			// 
			this.weightingFunctionLabel.AutoSize = true;
			this.weightingFunctionLabel.Location = new System.Drawing.Point(152, 18);
			this.weightingFunctionLabel.Name = "weightingFunctionLabel";
			this.weightingFunctionLabel.Size = new System.Drawing.Size(99, 13);
			this.weightingFunctionLabel.TabIndex = 8;
			this.weightingFunctionLabel.Text = "Weighting function:";
			// 
			// weightingFunctionTextbox
			// 
			this.weightingFunctionTextbox.Location = new System.Drawing.Point(257, 14);
			this.weightingFunctionTextbox.Name = "weightingFunctionTextbox";
			this.weightingFunctionTextbox.ReadOnly = true;
			this.weightingFunctionTextbox.Size = new System.Drawing.Size(230, 20);
			this.weightingFunctionTextbox.TabIndex = 9;
			this.weightingFunctionTextbox.Text = "(float)1 / Math.Pow(Math.Abs(x - y), z) + epsilon";
			// 
			// zTextbox
			// 
			this.zTextbox.Location = new System.Drawing.Point(514, 14);
			this.zTextbox.Name = "zTextbox";
			this.zTextbox.Size = new System.Drawing.Size(45, 20);
			this.zTextbox.TabIndex = 11;
			this.zTextbox.Text = "0";
			// 
			// zLabel
			// 
			this.zLabel.AutoSize = true;
			this.zLabel.Location = new System.Drawing.Point(493, 18);
			this.zLabel.Name = "zLabel";
			this.zLabel.Size = new System.Drawing.Size(15, 13);
			this.zLabel.TabIndex = 10;
			this.zLabel.Text = "z:";
			// 
			// epsilonTextbox
			// 
			this.epsilonTextbox.Location = new System.Drawing.Point(586, 14);
			this.epsilonTextbox.Name = "epsilonTextbox";
			this.epsilonTextbox.Size = new System.Drawing.Size(45, 20);
			this.epsilonTextbox.TabIndex = 13;
			this.epsilonTextbox.Text = "0.1";
			// 
			// epsilonLabel
			// 
			this.epsilonLabel.AutoSize = true;
			this.epsilonLabel.Location = new System.Drawing.Point(565, 18);
			this.epsilonLabel.Name = "epsilonLabel";
			this.epsilonLabel.Size = new System.Drawing.Size(16, 13);
			this.epsilonLabel.TabIndex = 12;
			this.epsilonLabel.Text = "ε:";
			// 
			// fillHolesButton
			// 
			this.fillHolesButton.Enabled = false;
			this.fillHolesButton.Location = new System.Drawing.Point(637, 13);
			this.fillHolesButton.Name = "fillHolesButton";
			this.fillHolesButton.Size = new System.Drawing.Size(75, 23);
			this.fillHolesButton.TabIndex = 14;
			this.fillHolesButton.Text = "&Fill Holes";
			this.fillHolesButton.UseVisualStyleBackColor = true;
			this.fillHolesButton.Click += new System.EventHandler(this.fillHolesButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(724, 611);
			this.Controls.Add(this.fillHolesButton);
			this.Controls.Add(this.epsilonTextbox);
			this.Controls.Add(this.epsilonLabel);
			this.Controls.Add(this.zTextbox);
			this.Controls.Add(this.zLabel);
			this.Controls.Add(this.weightingFunctionTextbox);
			this.Controls.Add(this.weightingFunctionLabel);
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
			this.PerformLayout();

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
		private System.Windows.Forms.Label boundariesImageIndicatorLabel;
		private System.Windows.Forms.Label filledImageIndicatorLabel;
		private System.Windows.Forms.Label weightingFunctionLabel;
		private System.Windows.Forms.TextBox weightingFunctionTextbox;
		private System.Windows.Forms.TextBox zTextbox;
		private System.Windows.Forms.Label zLabel;
		private System.Windows.Forms.TextBox epsilonTextbox;
		private System.Windows.Forms.Label epsilonLabel;
		private System.Windows.Forms.Button fillHolesButton;
	}
}

