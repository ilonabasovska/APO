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
    public partial class OneArgumentOperations : Form
    {
        public Bitmap openImage;
        public string name;
        public OneArgumentOperations(Bitmap view, string opname)
        {
            openImage = view;
            name = opname;
            InitializeComponent();
        }
        public void DrawHisto(Bitmap bmp)
        {
            int[] histo = Lab1.CountHisto(bmp);
            newChart.Series.Add("Gray");
            newChart.Series["Gray"].Points.Clear();
            newChart.Legends.Clear();
            newChart.ChartAreas[0].AxisX.Minimum = 0;
            newChart.ChartAreas[0].AxisX.Maximum = 255;
            newChart.Series["Gray"].BorderWidth = 5;
            newChart.Series["Gray"].ToolTip = "X = #VALX{F1}, Y = #VALY{F1}";
            for (int i = 0; i < histo.Length; ++i)
            {
                newChart.Series["Gray"].Points.AddXY(i, histo[i]);
            }
        }
        public void DrawHistoPQ(string name, int p1, int p2, int p3, int p4, int q2, int q3, int q4)
        {
            int[] histo = Lab2.HistogramDifferences(name, p1, p2, p3, p4, q2, q3, q4);
            pqChart.Series.Add("PQ");
            pqChart.Series["PQ"].Points.Clear();
            pqChart.Legends.Clear();
            pqChart.ChartAreas[0].AxisX.Minimum = 0;
            pqChart.ChartAreas[0].AxisX.Maximum = 255;
            pqChart.ChartAreas[0].AxisY.Minimum = 0;
            pqChart.ChartAreas[0].AxisY.Maximum = 255;
            pqChart.Series["PQ"].BorderWidth = 4;
            pqChart.Series["PQ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            pqChart.Series["PQ"].ToolTip = "X = #VALX{F1}, Y = #VALY{F1}";
            for (int i = 0; i < histo.Length; ++i)
            {
                pqChart.Series["PQ"].Points.AddXY(i, histo[i]);
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
            newPictureBox.Image = image2;
            DrawHisto(image2);
            //pqChart
        }

        private void OneArgumentOperations_Load(object sender, EventArgs e)
        {
            basePictureBox.Image = openImage;
        }

        private void oKButton_Click(object sender, EventArgs e)
        {
            int p1 = Convert.ToInt32(p1TextBox.Text);
            int p2 = Convert.ToInt32(p2TextBox.Text);
            int p3 = Convert.ToInt32(p3TextBox.Text);
            int p4 = Convert.ToInt32(p4TextBox.Text);
            int q2 = Convert.ToInt32(q2TextBox.Text);
            int q3 = Convert.ToInt32(q3TextBox.Text);
            int q4 = Convert.ToInt32(q4TextBox.Text);

            ShowResult(Lab2.OnePointOneArgumentOperation(openImage, name, p1, p2, p3, p4, q2, q3, q4));
            DrawHistoPQ(name, p1, p2, p3, p4, q2, q3, q4);

        }
    }
}
