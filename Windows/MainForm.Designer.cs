namespace Windows
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oPERATIONSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodAverageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodNeighborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.methodRandomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneArgumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.identityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inversenegationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdbinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseThresholdbinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalThresholdingbinaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalInverseThresholdingbinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdWithGrayLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseThresholdGrayLevelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reducingGrayLevelsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaCorrectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoArgumentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neighborOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonlinearFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laplasianFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.oPERATIONSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // oPERATIONSToolStripMenuItem
            // 
            this.oPERATIONSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extensionHistogramToolStripMenuItem,
            this.onePointToolStripMenuItem,
            this.neighborOperationsToolStripMenuItem});
            this.oPERATIONSToolStripMenuItem.Name = "oPERATIONSToolStripMenuItem";
            this.oPERATIONSToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.oPERATIONSToolStripMenuItem.Text = "OPERATIONS";
            // 
            // extensionHistogramToolStripMenuItem
            // 
            this.extensionHistogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.methodAverageToolStripMenuItem,
            this.methodNeighborToolStripMenuItem,
            this.methodRandomToolStripMenuItem});
            this.extensionHistogramToolStripMenuItem.Name = "extensionHistogramToolStripMenuItem";
            this.extensionHistogramToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.extensionHistogramToolStripMenuItem.Text = "Extension histogram";
            // 
            // methodAverageToolStripMenuItem
            // 
            this.methodAverageToolStripMenuItem.Name = "methodAverageToolStripMenuItem";
            this.methodAverageToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.methodAverageToolStripMenuItem.Text = "Method average";
            this.methodAverageToolStripMenuItem.Click += new System.EventHandler(this.methodAverageToolStripMenuItem_Click);
            // 
            // methodNeighborToolStripMenuItem
            // 
            this.methodNeighborToolStripMenuItem.Name = "methodNeighborToolStripMenuItem";
            this.methodNeighborToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.methodNeighborToolStripMenuItem.Text = "Method neighbor";
            this.methodNeighborToolStripMenuItem.Click += new System.EventHandler(this.methodNeighborToolStripMenuItem_Click);
            // 
            // methodRandomToolStripMenuItem
            // 
            this.methodRandomToolStripMenuItem.Name = "methodRandomToolStripMenuItem";
            this.methodRandomToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.methodRandomToolStripMenuItem.Text = "Method random";
            this.methodRandomToolStripMenuItem.Click += new System.EventHandler(this.methodRandomToolStripMenuItem_Click);
            // 
            // onePointToolStripMenuItem
            // 
            this.onePointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oneArgumentToolStripMenuItem,
            this.twoArgumentsToolStripMenuItem,
            this.uPOToolStripMenuItem});
            this.onePointToolStripMenuItem.Name = "onePointToolStripMenuItem";
            this.onePointToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.onePointToolStripMenuItem.Text = "One point";
            // 
            // oneArgumentToolStripMenuItem
            // 
            this.oneArgumentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.identityToolStripMenuItem,
            this.inversenegationToolStripMenuItem1,
            this.thresholdbinaryToolStripMenuItem,
            this.inverseThresholdbinaryToolStripMenuItem,
            this.intervalThresholdingbinaryToolStripMenuItem1,
            this.intervalInverseThresholdingbinaryToolStripMenuItem,
            this.thresholdWithGrayLevelsToolStripMenuItem,
            this.inverseThresholdGrayLevelsToolStripMenuItem,
            this.stretchingToolStripMenuItem1,
            this.reducingGrayLevelsToolStripMenuItem1,
            this.brightnessToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.gammaCorrectionToolStripMenuItem});
            this.oneArgumentToolStripMenuItem.Name = "oneArgumentToolStripMenuItem";
            this.oneArgumentToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.oneArgumentToolStripMenuItem.Text = "One argument";
            // 
            // identityToolStripMenuItem
            // 
            this.identityToolStripMenuItem.Name = "identityToolStripMenuItem";
            this.identityToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.identityToolStripMenuItem.Text = "Identity";
            this.identityToolStripMenuItem.Click += new System.EventHandler(this.identityToolStripMenuItem_Click);
            // 
            // inversenegationToolStripMenuItem1
            // 
            this.inversenegationToolStripMenuItem1.Name = "inversenegationToolStripMenuItem1";
            this.inversenegationToolStripMenuItem1.Size = new System.Drawing.Size(325, 26);
            this.inversenegationToolStripMenuItem1.Text = "Inverse (negation)";
            this.inversenegationToolStripMenuItem1.Click += new System.EventHandler(this.inversenegationToolStripMenuItem1_Click);
            // 
            // thresholdbinaryToolStripMenuItem
            // 
            this.thresholdbinaryToolStripMenuItem.Name = "thresholdbinaryToolStripMenuItem";
            this.thresholdbinaryToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.thresholdbinaryToolStripMenuItem.Text = "Threshold (binary)";
            this.thresholdbinaryToolStripMenuItem.Click += new System.EventHandler(this.thresholdbinaryToolStripMenuItem_Click);
            // 
            // inverseThresholdbinaryToolStripMenuItem
            // 
            this.inverseThresholdbinaryToolStripMenuItem.Name = "inverseThresholdbinaryToolStripMenuItem";
            this.inverseThresholdbinaryToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.inverseThresholdbinaryToolStripMenuItem.Text = "Inverse threshold (binary)";
            this.inverseThresholdbinaryToolStripMenuItem.Click += new System.EventHandler(this.inverseThresholdbinaryToolStripMenuItem_Click);
            // 
            // intervalThresholdingbinaryToolStripMenuItem1
            // 
            this.intervalThresholdingbinaryToolStripMenuItem1.Name = "intervalThresholdingbinaryToolStripMenuItem1";
            this.intervalThresholdingbinaryToolStripMenuItem1.Size = new System.Drawing.Size(325, 26);
            this.intervalThresholdingbinaryToolStripMenuItem1.Text = "Interval thresholding (binary)";
            this.intervalThresholdingbinaryToolStripMenuItem1.Click += new System.EventHandler(this.intervalThresholdingbinaryToolStripMenuItem1_Click);
            // 
            // intervalInverseThresholdingbinaryToolStripMenuItem
            // 
            this.intervalInverseThresholdingbinaryToolStripMenuItem.Name = "intervalInverseThresholdingbinaryToolStripMenuItem";
            this.intervalInverseThresholdingbinaryToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.intervalInverseThresholdingbinaryToolStripMenuItem.Text = "Interval inverse thresholding (binary)";
            this.intervalInverseThresholdingbinaryToolStripMenuItem.Click += new System.EventHandler(this.intervalInverseThresholdingbinaryToolStripMenuItem_Click);
            // 
            // thresholdWithGrayLevelsToolStripMenuItem
            // 
            this.thresholdWithGrayLevelsToolStripMenuItem.Name = "thresholdWithGrayLevelsToolStripMenuItem";
            this.thresholdWithGrayLevelsToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.thresholdWithGrayLevelsToolStripMenuItem.Text = "Threshold with gray levels";
            this.thresholdWithGrayLevelsToolStripMenuItem.Click += new System.EventHandler(this.thresholdWithGrayLevelsToolStripMenuItem_Click);
            // 
            // inverseThresholdGrayLevelsToolStripMenuItem
            // 
            this.inverseThresholdGrayLevelsToolStripMenuItem.Name = "inverseThresholdGrayLevelsToolStripMenuItem";
            this.inverseThresholdGrayLevelsToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.inverseThresholdGrayLevelsToolStripMenuItem.Text = "Inverse threshold gray levels";
            this.inverseThresholdGrayLevelsToolStripMenuItem.Click += new System.EventHandler(this.inverseThresholdGrayLevelsToolStripMenuItem_Click);
            // 
            // stretchingToolStripMenuItem1
            // 
            this.stretchingToolStripMenuItem1.Name = "stretchingToolStripMenuItem1";
            this.stretchingToolStripMenuItem1.Size = new System.Drawing.Size(325, 26);
            this.stretchingToolStripMenuItem1.Text = "Stretching";
            this.stretchingToolStripMenuItem1.Click += new System.EventHandler(this.stretchingToolStripMenuItem1_Click);
            // 
            // reducingGrayLevelsToolStripMenuItem1
            // 
            this.reducingGrayLevelsToolStripMenuItem1.Name = "reducingGrayLevelsToolStripMenuItem1";
            this.reducingGrayLevelsToolStripMenuItem1.Size = new System.Drawing.Size(325, 26);
            this.reducingGrayLevelsToolStripMenuItem1.Text = "Reducing gray levels";
            this.reducingGrayLevelsToolStripMenuItem1.Click += new System.EventHandler(this.reducingGrayLevelsToolStripMenuItem1_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.brightnessToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.contrastToolStripMenuItem.Text = "Contrast ";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // gammaCorrectionToolStripMenuItem
            // 
            this.gammaCorrectionToolStripMenuItem.Name = "gammaCorrectionToolStripMenuItem";
            this.gammaCorrectionToolStripMenuItem.Size = new System.Drawing.Size(325, 26);
            this.gammaCorrectionToolStripMenuItem.Text = "Gamma correction";
            this.gammaCorrectionToolStripMenuItem.Click += new System.EventHandler(this.gammaCorrectionToolStripMenuItem_Click);
            // 
            // twoArgumentsToolStripMenuItem
            // 
            this.twoArgumentsToolStripMenuItem.Name = "twoArgumentsToolStripMenuItem";
            this.twoArgumentsToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.twoArgumentsToolStripMenuItem.Text = "Two arguments";
            this.twoArgumentsToolStripMenuItem.Click += new System.EventHandler(this.twoArgumentsToolStripMenuItem_Click);
            // 
            // uPOToolStripMenuItem
            // 
            this.uPOToolStripMenuItem.Name = "uPOToolStripMenuItem";
            this.uPOToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.uPOToolStripMenuItem.Text = "UPO";
            this.uPOToolStripMenuItem.Click += new System.EventHandler(this.uPOToolStripMenuItem_Click);
            // 
            // neighborOperationsToolStripMenuItem
            // 
            this.neighborOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothingToolStripMenuItem,
            this.sharpeningToolStripMenuItem});
            this.neighborOperationsToolStripMenuItem.Name = "neighborOperationsToolStripMenuItem";
            this.neighborOperationsToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.neighborOperationsToolStripMenuItem.Text = "Neighbor operations";
            // 
            // smoothingToolStripMenuItem
            // 
            this.smoothingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearFiltrationToolStripMenuItem,
            this.nonlinearFiltrationToolStripMenuItem});
            this.smoothingToolStripMenuItem.Name = "smoothingToolStripMenuItem";
            this.smoothingToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.smoothingToolStripMenuItem.Text = "Smoothing";
            // 
            // linearFiltrationToolStripMenuItem
            // 
            this.linearFiltrationToolStripMenuItem.Name = "linearFiltrationToolStripMenuItem";
            this.linearFiltrationToolStripMenuItem.Size = new System.Drawing.Size(347, 26);
            this.linearFiltrationToolStripMenuItem.Text = "Linear filtration(convolutional methods)";
            this.linearFiltrationToolStripMenuItem.Click += new System.EventHandler(this.linearFiltrationToolStripMenuItem_Click);
            // 
            // nonlinearFiltrationToolStripMenuItem
            // 
            this.nonlinearFiltrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logicalFiltrationToolStripMenuItem,
            this.medianFiltrationToolStripMenuItem});
            this.nonlinearFiltrationToolStripMenuItem.Name = "nonlinearFiltrationToolStripMenuItem";
            this.nonlinearFiltrationToolStripMenuItem.Size = new System.Drawing.Size(347, 26);
            this.nonlinearFiltrationToolStripMenuItem.Text = "Nonlinear filtration";
            // 
            // logicalFiltrationToolStripMenuItem
            // 
            this.logicalFiltrationToolStripMenuItem.Name = "logicalFiltrationToolStripMenuItem";
            this.logicalFiltrationToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.logicalFiltrationToolStripMenuItem.Text = "Logical filtration ";
            // 
            // medianFiltrationToolStripMenuItem
            // 
            this.medianFiltrationToolStripMenuItem.Name = "medianFiltrationToolStripMenuItem";
            this.medianFiltrationToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.medianFiltrationToolStripMenuItem.Text = "Median filtration";
            // 
            // sharpeningToolStripMenuItem
            // 
            this.sharpeningToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradientFiltrationToolStripMenuItem,
            this.laplasianFiltrationToolStripMenuItem});
            this.sharpeningToolStripMenuItem.Name = "sharpeningToolStripMenuItem";
            this.sharpeningToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.sharpeningToolStripMenuItem.Text = "Sharpening";
            // 
            // gradientFiltrationToolStripMenuItem
            // 
            this.gradientFiltrationToolStripMenuItem.Name = "gradientFiltrationToolStripMenuItem";
            this.gradientFiltrationToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.gradientFiltrationToolStripMenuItem.Text = "Gradient filtration";
            // 
            // laplasianFiltrationToolStripMenuItem
            // 
            this.laplasianFiltrationToolStripMenuItem.Name = "laplasianFiltrationToolStripMenuItem";
            this.laplasianFiltrationToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.laplasianFiltrationToolStripMenuItem.Text = "Laplasian filtration";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "APO IB";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oPERATIONSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extensionHistogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodAverageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodNeighborToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem methodRandomToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem onePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneArgumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem identityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inversenegationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thresholdbinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverseThresholdbinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalThresholdingbinaryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thresholdWithGrayLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reducingGrayLevelsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem twoArgumentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaCorrectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neighborOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonlinearFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervalInverseThresholdingbinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverseThresholdGrayLevelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplasianFiltrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uPOToolStripMenuItem;
    }
}

