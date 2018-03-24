namespace Windows
{
    partial class UniversalPointOperation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.histogramPictureBox = new System.Windows.Forms.PictureBox();
            this.newImagePictureBox = new System.Windows.Forms.PictureBox();
            this.newImagechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagechart)).BeginInit();
            this.SuspendLayout();
            // 
            // histogramPictureBox
            // 
            this.histogramPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.histogramPictureBox.Location = new System.Drawing.Point(362, 12);
            this.histogramPictureBox.Name = "histogramPictureBox";
            this.histogramPictureBox.Size = new System.Drawing.Size(344, 318);
            this.histogramPictureBox.TabIndex = 2;
            this.histogramPictureBox.TabStop = false;
            this.histogramPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.histogramPictureBox_Paint);
            this.histogramPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.histogramPictureBox_MouseClick);
            // 
            // newImagePictureBox
            // 
            this.newImagePictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.newImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.newImagePictureBox.Name = "newImagePictureBox";
            this.newImagePictureBox.Size = new System.Drawing.Size(344, 318);
            this.newImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.newImagePictureBox.TabIndex = 3;
            this.newImagePictureBox.TabStop = false;
            // 
            // newImagechart
            // 
            chartArea1.Name = "ChartArea1";
            this.newImagechart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.newImagechart.Legends.Add(legend1);
            this.newImagechart.Location = new System.Drawing.Point(712, 12);
            this.newImagechart.Name = "newImagechart";
            this.newImagechart.Size = new System.Drawing.Size(300, 318);
            this.newImagechart.TabIndex = 4;
            this.newImagechart.Text = "chart1";
            // 
            // UniversalPointOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 345);
            this.Controls.Add(this.newImagechart);
            this.Controls.Add(this.newImagePictureBox);
            this.Controls.Add(this.histogramPictureBox);
            this.Name = "UniversalPointOperation";
            this.Text = "UniversalPointOperation";
            this.Load += new System.EventHandler(this.UniversalPointOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newImagechart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox histogramPictureBox;
        private System.Windows.Forms.PictureBox newImagePictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart newImagechart;
    }
}