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
        private void okButton_Click(object sender, EventArgs e)
        {
            string name;
            int k1 = Convert.ToInt32(k1TextBox.Text);
            int k2 = Convert.ToInt32(k2TextBox.Text);
            int k3 = Convert.ToInt32(k3TextBox.Text);
            int k4 = Convert.ToInt32(k4TextBox.Text);
            int k5 = Convert.ToInt32(k5TextBox.Text);
            int k6 = Convert.ToInt32(k6TextBox.Text);
            int k7 = Convert.ToInt32(k7TextBox.Text);
            int k8 = Convert.ToInt32(k8TextBox.Text);
            int k9 = Convert.ToInt32(k9TextBox.Text);
            if (duplicationRadioButton.Checked)
            {
                name = "Duplication";
                int[,] histo = Lab2.LinearFiltration3x3(openImage, name, k1, k2, k3, k4, k5, k6, k7, k8, k9);
                ShowResult(histo);
            }
            if (unchangedRadioButton.Checked)
            {
                name = "Unchanged";
                int[,] histo = Lab2.LinearFiltration3x3(openImage, name, k1, k2, k3, k4, k5, k6, k7, k8, k9);
                ShowResult(histo);
            }
            if (existingRadioButton.Checked)
            {
                name = "Existing";
                int[,] histo = Lab2.LinearFiltration3x3(openImage, name, k1, k2, k3, k4, k5, k6, k7, k8, k9);
                ShowResult(histo);
            }
           

        }
    }
}
