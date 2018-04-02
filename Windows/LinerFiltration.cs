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
    public partial class LinerFiltration : Form
    {
        Bitmap openImage;
        public LinerFiltration(Bitmap view)
        {
            openImage = view;
            InitializeComponent();

        }

        private void LinerFiltration_Load(object sender, EventArgs e)
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
            // DrawHisto(image2);
            //pqChart
        }
        string name;
        string method;
        private void okButton_Click(object sender, EventArgs e)
        {
            /*Mask*/
            if (k9RadioButton.Checked)
            {
                method = "1/9";
            }

            if (k10RadioButton.Checked)
            {
                method = "1/10";
            }

            if (k16RadioButton.Checked)
            {
                method = "1/16";
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
            int[,] histo = Lab3.LinearFiltration3x3(openImage, name, method);
            ShowResult(histo);

        }
    }
}
