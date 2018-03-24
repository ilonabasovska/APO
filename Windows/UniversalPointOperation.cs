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
    public partial class UniversalPointOperation : Form
    {
        int x1;
        int y1;
        private PointF[] histo = new PointF[256];
        private List<PointF> point = new List<PointF>();
        private List<PointF> pointBezier = new List<PointF>();
        private PointF[] pointsForBezierCurves = new PointF[7];
        private Point[] histoBezier = new Point[256];
        public Bitmap openImage;
        public UniversalPointOperation()
        {
            InitializeComponent();
        }
        public UniversalPointOperation(Bitmap view)
        {
            openImage = view;
            MakeHisto();
            point.Add(new PointF() { X = 0, Y = 0 });
            point.Add(new PointF() { X = 255, Y = 255 });
            InitializeComponent();
        }
        private void MakeHisto()
        {
            for (int i = 0; i < 256; ++i)
            {
                histo[i] = new PointF(i, i);
            }
        }
        private void ChangeImage(int x, float y)
        {
            point.Add(new PointF() { X = x1, Y = y1 });
            point = point.OrderBy(p => p.X).ToList();

            for (int c = 0; c < point.Count - 1; ++c)
            {
                for (int i = (int)point[c].X; i <= point[c + 1].X; ++i)
                {
                    histo[i] = new PointF(i, ((((i - point[c + 1].X) / (point[c].X - point[c + 1].X)) * (point[c].Y - point[c + 1].Y)) + point[c + 1].Y));
                }
            }
        }

        private void MakeNewImage()
        {
            Bitmap bitmap = new Bitmap(newImagePictureBox.Image);
            Bitmap bitmapNewImage = new Bitmap(bitmap.Width, bitmap.Height);
            int[,] histogram = new int[bitmap.Width, bitmap.Height];
            int[,] histoNewImage = new int[bitmap.Width, bitmap.Height];
            Color pixelColor = new Color();
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    pixelColor = bitmap.GetPixel(x, y);
                    histogram[x, y] = ((pixelColor.R * 229 + pixelColor.G * 589 + pixelColor.B * 114) / 1000);
                }
            }
            
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    for (int c = 0; c < histo.Length; ++c)
                    {
                        if (histogram[x, y] == histo[c].X)
                        {
                            histoNewImage[x, y] = (int)histo[c].Y;
                        }
                    }
                }
            }
            for (int x = 0; x < bitmap.Width; ++x)
            {
                for (int y = 0; y < bitmap.Height; ++y)
                {
                    bitmapNewImage.SetPixel(x, y, Color.FromArgb(histoNewImage[x, y], histoNewImage[x, y], histoNewImage[x, y]));
                }
            }
            newImagePictureBox.Image = bitmapNewImage;
        }

        public void DrawHisto(int[] histoLut)
        {
            int[] histo = histoLut;
            newImagechart.Series.Add("Gray");
            newImagechart.Series["Gray"].Points.Clear();
            newImagechart.Legends.Clear();
            newImagechart.ChartAreas[0].AxisX.Minimum = 0;
            newImagechart.ChartAreas[0].AxisX.Maximum = 255;
            newImagechart.Series["Gray"].ToolTip = "X = #VALX{F1}, Y = #VALY{F1}";
            for (int i = 0; i < histo.Length; ++i)
            {
                newImagechart.Series["Gray"].Points.AddXY(i, histo[i]);
            }
        }
        private void UniversalPointOperation_Load(object sender, EventArgs e)
        {
            if (openImage != null)
            {
                newImagePictureBox.Image = openImage;
            }
        }

        private void histogramPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            ChangeImage(x1, y1);
            MakeNewImage();
            newImagechart.Series.Clear();
            int[] histogr = Lab1.CountHisto(new Bitmap(newImagePictureBox.Image));
            DrawHisto(histogr);
            histogramPictureBox.Invalidate();
        }

        private void histogramPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, 255, 255);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), rectangle);

            e.Graphics.DrawLines(new Pen(Color.Magenta, 2), histo);

            e.Graphics.DrawBeziers(new Pen(Color.Blue, 2), pointsForBezierCurves);
        }
    }
}
