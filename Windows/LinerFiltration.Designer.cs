namespace Windows
{
    partial class LinerFiltration
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
            this.ResetButton = new System.Windows.Forms.Button();
            this.duplicationRadioButton = new System.Windows.Forms.RadioButton();
            this.unchangedRadioButton = new System.Windows.Forms.RadioButton();
            this.existingRadioButton = new System.Windows.Forms.RadioButton();
            this.k9RadioButton = new System.Windows.Forms.RadioButton();
            this.k10RadioButton = new System.Windows.Forms.RadioButton();
            this.k16RadioButton = new System.Windows.Forms.RadioButton();
            this.extremPixelMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.maskGroupBox = new System.Windows.Forms.GroupBox();
            this.ballRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).BeginInit();
            this.extremPixelMethodGroupBox.SuspendLayout();
            this.maskGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagePictureBox
            // 
            this.openImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.openImagePictureBox.Name = "openImagePictureBox";
            this.openImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.openImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.openImagePictureBox.TabIndex = 0;
            this.openImagePictureBox.TabStop = false;
            // 
            // newImagePictureBox
            // 
            this.newImagePictureBox.Location = new System.Drawing.Point(418, 12);
            this.newImagePictureBox.Name = "newImagePictureBox";
            this.newImagePictureBox.Size = new System.Drawing.Size(400, 400);
            this.newImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newImagePictureBox.TabIndex = 1;
            this.newImagePictureBox.TabStop = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(830, 296);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(143, 40);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(832, 360);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(141, 40);
            this.ResetButton.TabIndex = 12;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
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
            // k9RadioButton
            // 
            this.k9RadioButton.AutoSize = true;
            this.k9RadioButton.Location = new System.Drawing.Point(6, 21);
            this.k9RadioButton.Name = "k9RadioButton";
            this.k9RadioButton.Size = new System.Drawing.Size(49, 21);
            this.k9RadioButton.TabIndex = 19;
            this.k9RadioButton.TabStop = true;
            this.k9RadioButton.Text = "1/9";
            this.k9RadioButton.UseVisualStyleBackColor = true;
            // 
            // k10RadioButton
            // 
            this.k10RadioButton.AutoSize = true;
            this.k10RadioButton.Location = new System.Drawing.Point(6, 48);
            this.k10RadioButton.Name = "k10RadioButton";
            this.k10RadioButton.Size = new System.Drawing.Size(57, 21);
            this.k10RadioButton.TabIndex = 20;
            this.k10RadioButton.TabStop = true;
            this.k10RadioButton.Text = "1/10";
            this.k10RadioButton.UseVisualStyleBackColor = true;
            // 
            // k16RadioButton
            // 
            this.k16RadioButton.AutoSize = true;
            this.k16RadioButton.Location = new System.Drawing.Point(6, 75);
            this.k16RadioButton.Name = "k16RadioButton";
            this.k16RadioButton.Size = new System.Drawing.Size(57, 21);
            this.k16RadioButton.TabIndex = 21;
            this.k16RadioButton.TabStop = true;
            this.k16RadioButton.Text = "1/16";
            this.k16RadioButton.UseVisualStyleBackColor = true;
            // 
            // extremPixelMethodGroupBox
            // 
            this.extremPixelMethodGroupBox.Controls.Add(this.ballRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.existingRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.duplicationRadioButton);
            this.extremPixelMethodGroupBox.Controls.Add(this.unchangedRadioButton);
            this.extremPixelMethodGroupBox.Location = new System.Drawing.Point(824, 12);
            this.extremPixelMethodGroupBox.Name = "extremPixelMethodGroupBox";
            this.extremPixelMethodGroupBox.Size = new System.Drawing.Size(169, 174);
            this.extremPixelMethodGroupBox.TabIndex = 19;
            this.extremPixelMethodGroupBox.TabStop = false;
            this.extremPixelMethodGroupBox.Text = "Extreme pixels";
            // 
            // maskGroupBox
            // 
            this.maskGroupBox.Controls.Add(this.k16RadioButton);
            this.maskGroupBox.Controls.Add(this.k9RadioButton);
            this.maskGroupBox.Controls.Add(this.k10RadioButton);
            this.maskGroupBox.Location = new System.Drawing.Point(824, 192);
            this.maskGroupBox.Name = "maskGroupBox";
            this.maskGroupBox.Size = new System.Drawing.Size(169, 98);
            this.maskGroupBox.TabIndex = 20;
            this.maskGroupBox.TabStop = false;
            this.maskGroupBox.Text = "Mask";
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
            // LinerFiltration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 436);
            this.Controls.Add(this.maskGroupBox);
            this.Controls.Add(this.extremPixelMethodGroupBox);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.newImagePictureBox);
            this.Controls.Add(this.openImagePictureBox);
            this.Name = "LinerFiltration";
            this.Text = "LinerFiltration";
            this.Load += new System.EventHandler(this.LinerFiltration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).EndInit();
            this.extremPixelMethodGroupBox.ResumeLayout(false);
            this.extremPixelMethodGroupBox.PerformLayout();
            this.maskGroupBox.ResumeLayout(false);
            this.maskGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox openImagePictureBox;
        private System.Windows.Forms.PictureBox newImagePictureBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.RadioButton duplicationRadioButton;
        private System.Windows.Forms.RadioButton unchangedRadioButton;
        private System.Windows.Forms.RadioButton existingRadioButton;
        private System.Windows.Forms.RadioButton k16RadioButton;
        private System.Windows.Forms.RadioButton k10RadioButton;
        private System.Windows.Forms.RadioButton k9RadioButton;
        private System.Windows.Forms.GroupBox extremPixelMethodGroupBox;
        private System.Windows.Forms.GroupBox maskGroupBox;
        private System.Windows.Forms.RadioButton ballRadioButton;
    }
}