namespace Windows
{
    partial class Sharpering
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
            this.openImagePictureBox = new System.Windows.Forms.PictureBox();
            this.newImagePictureBox = new System.Windows.Forms.PictureBox();
            this.sharperingMethodgroupBox = new System.Windows.Forms.GroupBox();
            this.edgeDetectionMask3RadioButton = new System.Windows.Forms.RadioButton();
            this.laplacianMask5RadioButton = new System.Windows.Forms.RadioButton();
            this.edgeDetectionMask2RadioButton = new System.Windows.Forms.RadioButton();
            this.laplacianMask1RadioButton = new System.Windows.Forms.RadioButton();
            this.edgeDetectionMask1RadioButton = new System.Windows.Forms.RadioButton();
            this.laplacianMask4RadioButton = new System.Windows.Forms.RadioButton();
            this.laplacianMask2RadioButton = new System.Windows.Forms.RadioButton();
            this.laplacianMask3RadioButton = new System.Windows.Forms.RadioButton();
            this.scalingMethodgroupBox = new System.Windows.Forms.GroupBox();
            this.ScalingMethod3RadioButton = new System.Windows.Forms.RadioButton();
            this.scalingMethod2RadioButton = new System.Windows.Forms.RadioButton();
            this.scalingMethod1RadioButton = new System.Windows.Forms.RadioButton();
            this.extremPixelMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.ballRadioButton = new System.Windows.Forms.RadioButton();
            this.existingRadioButton = new System.Windows.Forms.RadioButton();
            this.duplicationRadioButton = new System.Windows.Forms.RadioButton();
            this.unchangedRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).BeginInit();
            this.sharperingMethodgroupBox.SuspendLayout();
            this.scalingMethodgroupBox.SuspendLayout();
            this.extremPixelMethodGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagePictureBox
            // 
            this.openImagePictureBox.Location = new System.Drawing.Point(13, 13);
            this.openImagePictureBox.Name = "openImagePictureBox";
            this.openImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.openImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.openImagePictureBox.TabIndex = 0;
            this.openImagePictureBox.TabStop = false;
            // 
            // newImagePictureBox
            // 
            this.newImagePictureBox.Location = new System.Drawing.Point(419, 13);
            this.newImagePictureBox.Name = "newImagePictureBox";
            this.newImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.newImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newImagePictureBox.TabIndex = 1;
            this.newImagePictureBox.TabStop = false;
            // 
            // sharperingMethodgroupBox
            // 
            this.sharperingMethodgroupBox.Controls.Add(this.edgeDetectionMask3RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.laplacianMask5RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.edgeDetectionMask2RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.laplacianMask1RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.edgeDetectionMask1RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.laplacianMask4RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.laplacianMask2RadioButton);
            this.sharperingMethodgroupBox.Controls.Add(this.laplacianMask3RadioButton);
            this.sharperingMethodgroupBox.Location = new System.Drawing.Point(825, 13);
            this.sharperingMethodgroupBox.Name = "sharperingMethodgroupBox";
            this.sharperingMethodgroupBox.Size = new System.Drawing.Size(193, 247);
            this.sharperingMethodgroupBox.TabIndex = 3;
            this.sharperingMethodgroupBox.TabStop = false;
            this.sharperingMethodgroupBox.Text = "Sharpering method";
            // 
            // edgeDetectionMask3RadioButton
            // 
            this.edgeDetectionMask3RadioButton.AutoSize = true;
            this.edgeDetectionMask3RadioButton.Location = new System.Drawing.Point(7, 210);
            this.edgeDetectionMask3RadioButton.Name = "edgeDetectionMask3RadioButton";
            this.edgeDetectionMask3RadioButton.Size = new System.Drawing.Size(173, 21);
            this.edgeDetectionMask3RadioButton.TabIndex = 5;
            this.edgeDetectionMask3RadioButton.TabStop = true;
            this.edgeDetectionMask3RadioButton.Text = "Edge detection mask 3";
            this.edgeDetectionMask3RadioButton.UseVisualStyleBackColor = true;
            // 
            // laplacianMask5RadioButton
            // 
            this.laplacianMask5RadioButton.AutoSize = true;
            this.laplacianMask5RadioButton.Location = new System.Drawing.Point(7, 129);
            this.laplacianMask5RadioButton.Name = "laplacianMask5RadioButton";
            this.laplacianMask5RadioButton.Size = new System.Drawing.Size(139, 21);
            this.laplacianMask5RadioButton.TabIndex = 7;
            this.laplacianMask5RadioButton.TabStop = true;
            this.laplacianMask5RadioButton.Text = "Laplacian mask 5";
            this.laplacianMask5RadioButton.UseVisualStyleBackColor = true;
            // 
            // edgeDetectionMask2RadioButton
            // 
            this.edgeDetectionMask2RadioButton.AutoSize = true;
            this.edgeDetectionMask2RadioButton.Location = new System.Drawing.Point(7, 183);
            this.edgeDetectionMask2RadioButton.Name = "edgeDetectionMask2RadioButton";
            this.edgeDetectionMask2RadioButton.Size = new System.Drawing.Size(173, 21);
            this.edgeDetectionMask2RadioButton.TabIndex = 4;
            this.edgeDetectionMask2RadioButton.TabStop = true;
            this.edgeDetectionMask2RadioButton.Text = "Edge detection mask 2";
            this.edgeDetectionMask2RadioButton.UseVisualStyleBackColor = true;
            // 
            // laplacianMask1RadioButton
            // 
            this.laplacianMask1RadioButton.AutoSize = true;
            this.laplacianMask1RadioButton.Location = new System.Drawing.Point(6, 21);
            this.laplacianMask1RadioButton.Name = "laplacianMask1RadioButton";
            this.laplacianMask1RadioButton.Size = new System.Drawing.Size(139, 21);
            this.laplacianMask1RadioButton.TabIndex = 3;
            this.laplacianMask1RadioButton.TabStop = true;
            this.laplacianMask1RadioButton.Text = "Laplacian mask 1";
            this.laplacianMask1RadioButton.UseVisualStyleBackColor = true;
            // 
            // edgeDetectionMask1RadioButton
            // 
            this.edgeDetectionMask1RadioButton.AutoSize = true;
            this.edgeDetectionMask1RadioButton.Location = new System.Drawing.Point(6, 156);
            this.edgeDetectionMask1RadioButton.Name = "edgeDetectionMask1RadioButton";
            this.edgeDetectionMask1RadioButton.Size = new System.Drawing.Size(173, 21);
            this.edgeDetectionMask1RadioButton.TabIndex = 3;
            this.edgeDetectionMask1RadioButton.TabStop = true;
            this.edgeDetectionMask1RadioButton.Text = "Edge detection mask 1";
            this.edgeDetectionMask1RadioButton.UseVisualStyleBackColor = true;
            // 
            // laplacianMask4RadioButton
            // 
            this.laplacianMask4RadioButton.AutoSize = true;
            this.laplacianMask4RadioButton.Location = new System.Drawing.Point(7, 102);
            this.laplacianMask4RadioButton.Name = "laplacianMask4RadioButton";
            this.laplacianMask4RadioButton.Size = new System.Drawing.Size(139, 21);
            this.laplacianMask4RadioButton.TabIndex = 6;
            this.laplacianMask4RadioButton.TabStop = true;
            this.laplacianMask4RadioButton.Text = "Laplacian mask 4";
            this.laplacianMask4RadioButton.UseVisualStyleBackColor = true;
            // 
            // laplacianMask2RadioButton
            // 
            this.laplacianMask2RadioButton.AutoSize = true;
            this.laplacianMask2RadioButton.Location = new System.Drawing.Point(7, 48);
            this.laplacianMask2RadioButton.Name = "laplacianMask2RadioButton";
            this.laplacianMask2RadioButton.Size = new System.Drawing.Size(139, 21);
            this.laplacianMask2RadioButton.TabIndex = 4;
            this.laplacianMask2RadioButton.TabStop = true;
            this.laplacianMask2RadioButton.Text = "Laplacian mask 2";
            this.laplacianMask2RadioButton.UseVisualStyleBackColor = true;
            // 
            // laplacianMask3RadioButton
            // 
            this.laplacianMask3RadioButton.AutoSize = true;
            this.laplacianMask3RadioButton.Location = new System.Drawing.Point(7, 75);
            this.laplacianMask3RadioButton.Name = "laplacianMask3RadioButton";
            this.laplacianMask3RadioButton.Size = new System.Drawing.Size(139, 21);
            this.laplacianMask3RadioButton.TabIndex = 5;
            this.laplacianMask3RadioButton.TabStop = true;
            this.laplacianMask3RadioButton.Text = "Laplacian mask 3";
            this.laplacianMask3RadioButton.UseVisualStyleBackColor = true;
            // 
            // scalingMethodgroupBox
            // 
            this.scalingMethodgroupBox.Controls.Add(this.ScalingMethod3RadioButton);
            this.scalingMethodgroupBox.Controls.Add(this.scalingMethod2RadioButton);
            this.scalingMethodgroupBox.Controls.Add(this.scalingMethod1RadioButton);
            this.scalingMethodgroupBox.Location = new System.Drawing.Point(825, 393);
            this.scalingMethodgroupBox.Name = "scalingMethodgroupBox";
            this.scalingMethodgroupBox.Size = new System.Drawing.Size(193, 102);
            this.scalingMethodgroupBox.TabIndex = 5;
            this.scalingMethodgroupBox.TabStop = false;
            this.scalingMethodgroupBox.Text = "Scaling method";
            // 
            // ScalingMethod3RadioButton
            // 
            this.ScalingMethod3RadioButton.AutoSize = true;
            this.ScalingMethod3RadioButton.Location = new System.Drawing.Point(7, 75);
            this.ScalingMethod3RadioButton.Name = "ScalingMethod3RadioButton";
            this.ScalingMethod3RadioButton.Size = new System.Drawing.Size(88, 21);
            this.ScalingMethod3RadioButton.TabIndex = 3;
            this.ScalingMethod3RadioButton.TabStop = true;
            this.ScalingMethod3RadioButton.Text = "Method 3";
            this.ScalingMethod3RadioButton.UseVisualStyleBackColor = true;
            // 
            // scalingMethod2RadioButton
            // 
            this.scalingMethod2RadioButton.AutoSize = true;
            this.scalingMethod2RadioButton.Location = new System.Drawing.Point(6, 48);
            this.scalingMethod2RadioButton.Name = "scalingMethod2RadioButton";
            this.scalingMethod2RadioButton.Size = new System.Drawing.Size(88, 21);
            this.scalingMethod2RadioButton.TabIndex = 2;
            this.scalingMethod2RadioButton.TabStop = true;
            this.scalingMethod2RadioButton.Text = "Method 2";
            this.scalingMethod2RadioButton.UseVisualStyleBackColor = true;
            // 
            // scalingMethod1RadioButton
            // 
            this.scalingMethod1RadioButton.AutoSize = true;
            this.scalingMethod1RadioButton.Location = new System.Drawing.Point(6, 21);
            this.scalingMethod1RadioButton.Name = "scalingMethod1RadioButton";
            this.scalingMethod1RadioButton.Size = new System.Drawing.Size(88, 21);
            this.scalingMethod1RadioButton.TabIndex = 1;
            this.scalingMethod1RadioButton.TabStop = true;
            this.scalingMethod1RadioButton.Text = "Method 1";
            this.scalingMethod1RadioButton.UseVisualStyleBackColor = true;
            // 
            // extremPixelMethodGroupBox
            // 
            this.extremPixelMethodGroupBox.Controls.Add(this.ballRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.existingRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.duplicationRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.unchangedRadioButton);
            this.extremPixelMethodGroupBox.Location = new System.Drawing.Point(825, 266);
            this.extremPixelMethodGroupBox.Name = "extremPixelMethodGroupBox";
            this.extremPixelMethodGroupBox.Size = new System.Drawing.Size(193, 123);
            this.extremPixelMethodGroupBox.TabIndex = 20;
            this.extremPixelMethodGroupBox.TabStop = false;
            this.extremPixelMethodGroupBox.Text = "Extreme pixels";
            // 
            // ballRadioButton
            // 
            this.ballRadioButton.AutoSize = true;
            this.ballRadioButton.Location = new System.Drawing.Point(6, 100);
            this.ballRadioButton.Name = "ballRadioButton";
            this.ballRadioButton.Size = new System.Drawing.Size(52, 21);
            this.ballRadioButton.TabIndex = 21;
            this.ballRadioButton.TabStop = true;
            this.ballRadioButton.Text = "Ball";
            this.ballRadioButton.UseVisualStyleBackColor = true;
            // 
            // existingRadioButton
            // 
            this.existingRadioButton.AutoSize = true;
            this.existingRadioButton.Location = new System.Drawing.Point(6, 73);
            this.existingRadioButton.Name = "existingRadioButton";
            this.existingRadioButton.Size = new System.Drawing.Size(77, 21);
            this.existingRadioButton.TabIndex = 18;
            this.existingRadioButton.TabStop = true;
            this.existingRadioButton.Text = "Existing";
            this.existingRadioButton.UseVisualStyleBackColor = true;
            // 
            // duplicationRadioButton
            // 
            this.duplicationRadioButton.AutoSize = true;
            this.duplicationRadioButton.Location = new System.Drawing.Point(6, 21);
            this.duplicationRadioButton.Name = "duplicationRadioButton";
            this.duplicationRadioButton.Size = new System.Drawing.Size(99, 21);
            this.duplicationRadioButton.TabIndex = 16;
            this.duplicationRadioButton.TabStop = true;
            this.duplicationRadioButton.Text = "Duplication";
            this.duplicationRadioButton.UseVisualStyleBackColor = true;
            // 
            // unchangedRadioButton
            // 
            this.unchangedRadioButton.AutoSize = true;
            this.unchangedRadioButton.Location = new System.Drawing.Point(6, 46);
            this.unchangedRadioButton.Name = "unchangedRadioButton";
            this.unchangedRadioButton.Size = new System.Drawing.Size(102, 21);
            this.unchangedRadioButton.TabIndex = 17;
            this.unchangedRadioButton.TabStop = true;
            this.unchangedRadioButton.Text = "Unchanged";
            this.unchangedRadioButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(93, 432);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(108, 45);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Sharpering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 501);
            this.Controls.Add(this.extremPixelMethodGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.scalingMethodgroupBox);
            this.Controls.Add(this.sharperingMethodgroupBox);
            this.Controls.Add(this.newImagePictureBox);
            this.Controls.Add(this.openImagePictureBox);
            this.Name = "Sharpering";
            this.Text = "Sharpering";
            this.Load += new System.EventHandler(this.Sharpering_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).EndInit();
            this.sharperingMethodgroupBox.ResumeLayout(false);
            this.sharperingMethodgroupBox.PerformLayout();
            this.scalingMethodgroupBox.ResumeLayout(false);
            this.scalingMethodgroupBox.PerformLayout();
            this.extremPixelMethodGroupBox.ResumeLayout(false);
            this.extremPixelMethodGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox openImagePictureBox;
        private System.Windows.Forms.PictureBox newImagePictureBox;
        private System.Windows.Forms.GroupBox sharperingMethodgroupBox;
        private System.Windows.Forms.RadioButton edgeDetectionMask3RadioButton;
        private System.Windows.Forms.RadioButton edgeDetectionMask2RadioButton;
        private System.Windows.Forms.RadioButton edgeDetectionMask1RadioButton;
        private System.Windows.Forms.RadioButton laplacianMask5RadioButton;
        private System.Windows.Forms.RadioButton laplacianMask4RadioButton;
        private System.Windows.Forms.RadioButton laplacianMask3RadioButton;
        private System.Windows.Forms.RadioButton laplacianMask2RadioButton;
        private System.Windows.Forms.RadioButton laplacianMask1RadioButton;
        private System.Windows.Forms.GroupBox scalingMethodgroupBox;
        private System.Windows.Forms.RadioButton ScalingMethod3RadioButton;
        private System.Windows.Forms.RadioButton scalingMethod2RadioButton;
        private System.Windows.Forms.RadioButton scalingMethod1RadioButton;
        private System.Windows.Forms.GroupBox extremPixelMethodGroupBox;
        private System.Windows.Forms.RadioButton ballRadioButton;
        private System.Windows.Forms.RadioButton existingRadioButton;
        private System.Windows.Forms.RadioButton duplicationRadioButton;
        private System.Windows.Forms.RadioButton unchangedRadioButton;
        private System.Windows.Forms.Button okButton;
    }
}