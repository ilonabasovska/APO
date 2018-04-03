namespace Windows
{
    partial class UniversalMedianFiltration
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
            this.okButton = new System.Windows.Forms.Button();
            this.extremPixelMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.ballRadioButton = new System.Windows.Forms.RadioButton();
            this.existingRadioButton = new System.Windows.Forms.RadioButton();
            this.duplicationRadioButton = new System.Windows.Forms.RadioButton();
            this.unchangedRadioButton = new System.Windows.Forms.RadioButton();
            this.maskSizegroupBox = new System.Windows.Forms.GroupBox();
            this.x7x7RadioButton = new System.Windows.Forms.RadioButton();
            this.x3x3RadioButton = new System.Windows.Forms.RadioButton();
            this.x5x5RadioButton = new System.Windows.Forms.RadioButton();
            this.x3x5RadioButton = new System.Windows.Forms.RadioButton();
            this.x5x3RadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).BeginInit();
            this.extremPixelMethodGroupBox.SuspendLayout();
            this.maskSizegroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagePictureBox
            // 
            this.openImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.openImagePictureBox.Name = "openImagePictureBox";
            this.openImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.openImagePictureBox.TabIndex = 10;
            this.openImagePictureBox.TabStop = false;
            // 
            // newImagePictureBox
            // 
            this.newImagePictureBox.Location = new System.Drawing.Point(418, 12);
            this.newImagePictureBox.Name = "newImagePictureBox";
            this.newImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.newImagePictureBox.TabIndex = 11;
            this.newImagePictureBox.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(856, 365);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(146, 47);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // extremPixelMethodGroupBox
            // 
            this.extremPixelMethodGroupBox.Controls.Add(this.ballRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.existingRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.duplicationRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.unchangedRadioButton);
            this.extremPixelMethodGroupBox.Location = new System.Drawing.Point(824, 176);
            this.extremPixelMethodGroupBox.Name = "extremPixelMethodGroupBox";
            this.extremPixelMethodGroupBox.Size = new System.Drawing.Size(193, 123);
            this.extremPixelMethodGroupBox.TabIndex = 22;
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
            // maskSizegroupBox
            // 
            this.maskSizegroupBox.Controls.Add(this.x7x7RadioButton);
            this.maskSizegroupBox.Controls.Add(this.x3x3RadioButton);
            this.maskSizegroupBox.Controls.Add(this.x5x5RadioButton);
            this.maskSizegroupBox.Controls.Add(this.x3x5RadioButton);
            this.maskSizegroupBox.Controls.Add(this.x5x3RadioButton);
            this.maskSizegroupBox.Location = new System.Drawing.Point(824, 12);
            this.maskSizegroupBox.Name = "maskSizegroupBox";
            this.maskSizegroupBox.Size = new System.Drawing.Size(195, 158);
            this.maskSizegroupBox.TabIndex = 22;
            this.maskSizegroupBox.TabStop = false;
            this.maskSizegroupBox.Text = "Mask size";
            // 
            // x7x7RadioButton
            // 
            this.x7x7RadioButton.AutoSize = true;
            this.x7x7RadioButton.Location = new System.Drawing.Point(7, 129);
            this.x7x7RadioButton.Name = "x7x7RadioButton";
            this.x7x7RadioButton.Size = new System.Drawing.Size(51, 21);
            this.x7x7RadioButton.TabIndex = 7;
            this.x7x7RadioButton.TabStop = true;
            this.x7x7RadioButton.Text = "7x7";
            this.x7x7RadioButton.UseVisualStyleBackColor = true;
            // 
            // x3x3RadioButton
            // 
            this.x3x3RadioButton.AutoSize = true;
            this.x3x3RadioButton.Location = new System.Drawing.Point(6, 21);
            this.x3x3RadioButton.Name = "x3x3RadioButton";
            this.x3x3RadioButton.Size = new System.Drawing.Size(51, 21);
            this.x3x3RadioButton.TabIndex = 3;
            this.x3x3RadioButton.TabStop = true;
            this.x3x3RadioButton.Text = "3x3";
            this.x3x3RadioButton.UseVisualStyleBackColor = true;
            // 
            // x5x5RadioButton
            // 
            this.x5x5RadioButton.AutoSize = true;
            this.x5x5RadioButton.Location = new System.Drawing.Point(7, 102);
            this.x5x5RadioButton.Name = "x5x5RadioButton";
            this.x5x5RadioButton.Size = new System.Drawing.Size(51, 21);
            this.x5x5RadioButton.TabIndex = 6;
            this.x5x5RadioButton.TabStop = true;
            this.x5x5RadioButton.Text = "5x5";
            this.x5x5RadioButton.UseVisualStyleBackColor = true;
            // 
            // x3x5RadioButton
            // 
            this.x3x5RadioButton.AutoSize = true;
            this.x3x5RadioButton.Location = new System.Drawing.Point(7, 48);
            this.x3x5RadioButton.Name = "x3x5RadioButton";
            this.x3x5RadioButton.Size = new System.Drawing.Size(51, 21);
            this.x3x5RadioButton.TabIndex = 4;
            this.x3x5RadioButton.TabStop = true;
            this.x3x5RadioButton.Text = "3x5";
            this.x3x5RadioButton.UseVisualStyleBackColor = true;
            // 
            // x5x3RadioButton
            // 
            this.x5x3RadioButton.AutoSize = true;
            this.x5x3RadioButton.Location = new System.Drawing.Point(7, 75);
            this.x5x3RadioButton.Name = "x5x3RadioButton";
            this.x5x3RadioButton.Size = new System.Drawing.Size(51, 21);
            this.x5x3RadioButton.TabIndex = 5;
            this.x5x3RadioButton.TabStop = true;
            this.x5x3RadioButton.Text = "5x3";
            this.x5x3RadioButton.UseVisualStyleBackColor = true;
            // 
            // UniversalMedianFiltration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 419);
            this.Controls.Add(this.maskSizegroupBox);
            this.Controls.Add(this.extremPixelMethodGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.newImagePictureBox);
            this.Controls.Add(this.openImagePictureBox);
            this.Name = "UniversalMedianFiltration";
            this.Text = "UniversalMedianFiltration";
            this.Load += new System.EventHandler(this.UniversalMedianFiltration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).EndInit();
            this.extremPixelMethodGroupBox.ResumeLayout(false);
            this.extremPixelMethodGroupBox.PerformLayout();
            this.maskSizegroupBox.ResumeLayout(false);
            this.maskSizegroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox openImagePictureBox;
        private System.Windows.Forms.PictureBox newImagePictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox extremPixelMethodGroupBox;
        private System.Windows.Forms.RadioButton ballRadioButton;
        private System.Windows.Forms.RadioButton existingRadioButton;
        private System.Windows.Forms.RadioButton duplicationRadioButton;
        private System.Windows.Forms.RadioButton unchangedRadioButton;
        private System.Windows.Forms.GroupBox maskSizegroupBox;
        private System.Windows.Forms.RadioButton x7x7RadioButton;
        private System.Windows.Forms.RadioButton x3x3RadioButton;
        private System.Windows.Forms.RadioButton x5x5RadioButton;
        private System.Windows.Forms.RadioButton x3x5RadioButton;
        private System.Windows.Forms.RadioButton x5x3RadioButton;
    }
}