using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows
{
    public partial class Sharpering : Form
    {
        Bitmap openImage;
        public Sharpering(Bitmap view)
        {
            openImage = view;
            InitializeComponent();
        }

        private void Sharpering_Load(object sender, EventArgs e)
        {
            if (openImage != null)
            {
                openImagePictureBox.Image = openImage;
            }
        }

        private void ShowResult(int[,] histo)
        {
            int[,] histogram = histo;
            Bitmap image2 = new Bitmap(openImage.Width, openImage.Height);
            for (int i = 0; i < image2.Width; ++i)
            {
                for (int j = 0; j < image2.Height; ++j)
                {
                    image2.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            newImagePictureBox.Image = image2;
        }

        string name;
        string scalingMethod;
        string sharperingMethod;
        private void okButton_Click(object sender, EventArgs e)
        {
            /*scalingMethod*/
            if (scalingMethod1RadioButton.Checked)
            {
                scalingMethod = "ScalingMethod1";
            }

            if (scalingMethod2RadioButton.Checked)
            {
                scalingMethod = "ScalingMethod2";
            }

            if (ScalingMethod3RadioButton.Checked)
            {
                scalingMethod = "ScalingMethod3";
            }
            /*ExtremePixel*/
            if (duplicationRadioButton.Checked)
            {
                name = "Duplication";

            }
            if (unchangedRadioButton.Checked)
            {
                name = "Unchanged";
            }

            if (existingRadioButton.Checked)
            {
                name = "Existing";
            }
            /*Own method*/
            if (ballRadioButton.Checked)
            {
                name = "Ball";
            }
            /*Sharpering method*/
            if (laplacianMask1RadioButton.Checked)
            {
                sharperingMethod = "LaplacianMask1";
            }
            if (laplacianMask2RadioButton.Checked)
            {
                sharperingMethod = "LaplacianMask2";
            }
            if (laplacianMask3RadioButton.Checked)
            {
                sharperingMethod = "LaplacianMask3";
            }
            if (laplacianMask4RadioButton.Checked)
            {
                sharperingMethod = "LaplacianMask4";
            }
            if (laplacianMask5RadioButton.Checked)
            {
                sharperingMethod = "LaplacianMask5";
            }
            if (edgeDetectionMask1RadioButton.Checked)
            {
                sharperingMethod = "EdgeDetectionMask1";
            }
            if (edgeDetectionMask2RadioButton.Checked)
            {
                sharperingMethod = "EdgeDetectionMask2";
            }
            if (edgeDetectionMask3RadioButton.Checked)
            {
                sharperingMethod = "EdgeDetectionMask3";
            }
            int[,] histo = Lab3.Sharpering(openImage, name, sharperingMethod, scalingMethod);
            ShowResult(histo);
        }
    }
}

