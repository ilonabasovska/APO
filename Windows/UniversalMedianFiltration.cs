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
    public partial class UniversalMedianFiltration : Form
    {
        Bitmap openImage;
        public UniversalMedianFiltration(Bitmap view)
        {
            openImage = view;
            InitializeComponent();
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

        private void UniversalMedianFiltration_Load(object sender, EventArgs e)
        {
            if (openImage != null)
            {
                openImagePictureBox.Image = openImage;
            }
        }
        string extremeName;
        string maskSize;
        private void okButton_Click(object sender, EventArgs e)
        {
            /*scalingMethod*/
            if (x3x3RadioButton.Checked)
            {
                maskSize = "3x3";
            }

            if (x3x5RadioButton.Checked)
            {
                maskSize = "3x5";
            }

            if (x5x3RadioButton.Checked)
            {
                maskSize = "5x3";
            }

            if (x5x5RadioButton.Checked)
            {
                maskSize = "5x5";
            }

            if (x7x7RadioButton.Checked)
            {
                maskSize = "7x7";
            }
            /*ExtremePixel*/
            if (duplicationRadioButton.Checked)
            {
                extremeName = "Duplication";

            }
            if (unchangedRadioButton.Checked)
            {
                extremeName = "Unchanged";
            }

            if (existingRadioButton.Checked)
            {
                extremeName = "Existing";
            }
            /*Own method*/
            if (ballRadioButton.Checked)
            {
                extremeName = "Ball";
            }
            int[,] histo = Lab3.UniversalMedianOperation(openImage, extremeName, maskSize);
            ShowResult(histo);
        }
    }
}
