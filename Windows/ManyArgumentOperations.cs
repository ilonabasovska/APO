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
    public partial class ManyArgumentOperations : Form
    {
        private Bitmap openImage1;
        private Bitmap openImage2;

        public ManyArgumentOperations()
        {
            InitializeComponent();
        }
        private void openImage1Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImageDialog = new OpenFileDialog();
            openImageDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                openImage1 = new Bitmap(openImageDialog.FileName);
                image1PictureBox.Image = openImage1;
            }
        }

        private void openImage2Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openImageDialog = new OpenFileDialog();
            openImageDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openImageDialog.ShowDialog() == DialogResult.OK)
            {
                openImage2 = new Bitmap(openImageDialog.FileName);
                image2PictureBox.Image = openImage2;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    histogram[x, y] = (((pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000) + ((pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000)) / 2;
                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }

        private void SubButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    histogram[x, y] = Math.Abs(((pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000) - ((pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000));
                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }

        private void multButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    int h1 = (pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000;
                    int h2 = (pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000;
                    histogram[x, y] = Math.Min(h1 * h2 / 255, 255);
                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }

        private void andButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    int h1 = (pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000;
                    int h2 = (pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000;
                    histogram[x, y] = Math.Min(h1 & h2, 255);
                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }

        private void orButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    int h1 = (pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000;
                    int h2 = (pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000;
                    histogram[x, y] = Math.Min(h1 | h2, 255);

                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }

        private void xorButton_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(image1PictureBox.Image);
            Bitmap image2 = new Bitmap(image2PictureBox.Image);
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor1 = new Color();
            Color pixelColor2 = new Color();
            int[,] histogram = new int[image1.Width, image1.Width];
            for (int x = 0; x < image1.Width; ++x)
            {
                for (int y = 0; y < image1.Height; ++y)
                {
                    pixelColor1 = image1.GetPixel(x, y);
                    pixelColor2 = image2.GetPixel(x, y);
                    int h1 = (pixelColor1.R * 299 + pixelColor1.G * 587 + pixelColor1.B * 114) / 1000;
                    int h2 = (pixelColor2.R * 299 + pixelColor2.G * 587 + pixelColor2.B * 114) / 1000;
                    histogram[x, y] = Math.Min(h1 ^ h2, 255);

                }
            }
            for (int i = 0; i < image1.Width; ++i)
            {
                for (int j = 0; j < image1.Height; ++j)
                {
                    image3.SetPixel(i, j, Color.FromArgb(histogram[i, j], histogram[i, j], histogram[i, j]));
                }
            }
            imageResultPictureBox.Image = image3;
        }
    }
}

