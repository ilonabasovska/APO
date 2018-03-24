using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Windows
{

    public partial class OpenForm : Form
    {
        public OpenForm()
        {
            InitializeComponent();
        }
        public Bitmap openImage;
        public OpenForm(Bitmap view)
        {
            openImage = view;
            InitializeComponent();

        }
        public void DrawHisto(int[] histoLut)
        {
            int[] histo = histoLut;
            chart1.Series.Add("Gray");
            chart1.Series["Gray"].Points.Clear();
            chart1.Legends.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.Series["Gray"].ToolTip = "X = #VALX{F1}, Y = #VALY{F1}";
            for (int i = 0; i < histo.Length; ++i)
            {
                chart1.Series["Gray"].Points.AddXY(i, histo[i]);
            }
        }
        private void OpenForm_Load(object sender, EventArgs e)
        {
            if (openImage != null)
            {
                pictureBox1.Image = openImage;
                int[] histo = Lab1.CountHisto(openImage);
                DrawHisto(histo);
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            //    if (chart1 != null)
            //    {
            //        ChartArea chartArea1 = chart1.Series["Gray"];
            //       //  chart1.ChartAreas["Gray"];
            //        chartArea1.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);
            //        chartArea1.CursorY.SetCursorPixelPosition(new Point(e.X, e.Y), true);

            //        double pX = chartArea1.CursorX.Position; //X Axis Coordinate of your mouse cursor
            //        double pY = chartArea1.CursorY.Position; //Y Axis Coordinate of your mouse cursor

            //        label1.Text = pX.ToString();
            //        label2.Text = pY.ToString();
            //    }
            
           
        }
    }
}

