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
    public partial class UniversalLinieOperation : Form
    {
        Bitmap openImage;
        public UniversalLinieOperation(Bitmap view)
        {
            openImage = view;
            InitializeComponent();
        }

        private void UniversalLinieOperation_Load(object sender, EventArgs e)
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
        int[] k = new int[10];
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
            k[1] = Convert.ToInt32(k1TextBox.Text);
            k[2] = Convert.ToInt32(k2TextBox.Text);
            k[3] = Convert.ToInt32(k3TextBox.Text);
            k[4] = Convert.ToInt32(k4TextBox.Text);
            k[5] = Convert.ToInt32(k5TextBox.Text);
            k[6] = Convert.ToInt32(k6TextBox.Text);
            k[7] = Convert.ToInt32(k7TextBox.Text);
            k[8] = Convert.ToInt32(k8TextBox.Text);
            k[9] = Convert.ToInt32(k9TextBox.Text);
            k[0] = k[1] + k[2] + k[3] + k[4] + k[5] + k[6] + k[7] + k[8] + k[9] ;
            int[,] histo = Lab3.UniversalPointOperations(openImage, name,  scalingMethod, k);
            ShowResult(histo);
        }
            
    }
}
