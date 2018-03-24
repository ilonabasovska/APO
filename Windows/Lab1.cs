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
    class Lab1
    {
         public enum Methods
        {
            Average,
            Random,
            Neighbor,
            Own
        }
        public static int[] CountHisto(Bitmap bmp)
        {
            Bitmap image1 = new Bitmap(bmp);
            int x, y;
            int[] histogramLUT = new int[256];
            int[,] imageInt = new int[image1.Width, image1.Height];
            Color pixelColor = new Color();
            for (x = 0; x < image1.Width; x++)
            {
                for (y = 0; y < image1.Height; y++)
                {
                    pixelColor = image1.GetPixel(x, y);
                    imageInt[x, y] = (pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000;
                    histogramLUT[(imageInt[x, y])]++;
                }
            }
            return histogramLUT;
        }
        public static int[,] Extension(Bitmap bmp, Methods method)
        {
            Bitmap openImage = bmp;
            // if (openImage != null)
            //{
            // int[] histogramLUT = CountHisto(openImage);
            Bitmap image1 = new Bitmap(openImage);
            Bitmap image2 = new Bitmap(image1.Width, image1.Height);
            int suma = 0;
            int histogramAvg = 0;
            int histogramInt = 0;
            int r = 0;
            int[] histogramLeft = new int[256];
            int[] histogramRight = new int[256];
            int[] histogramLUT = new int[256];
            int[] histogramNew = new int[256];
            int[,] histogram = new int[image1.Width, image1.Height];
            Color pixelColor = new Color();
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    pixelColor = image1.GetPixel(x, y);
                    histogram[x, y] = (pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000;
                    histogramLUT[(histogram[x, y])]++;

                }
            }
            //suma/ilość wszystkich pikseli w obrazie
            for (int i = 0; i < histogramLUT.Length; ++i)
            {
                suma = suma + histogramLUT[i];
            }

            histogramAvg = suma / histogramLUT.Length;
            int z = 0;
            Random randomZ = new Random();
            for (z = 0; z < histogramLUT.Length; ++z)
            {
                // Podstaw left(Z)= R i dodaj H(Z) do Hint . 
                histogramLeft[z] = r;
                histogramInt = histogramInt + histogramLUT[z];
                //Hint jest większe od Havg 
                while (histogramInt > histogramAvg)
                {
                    histogramInt = histogramInt - histogramAvg;
                    r = r + 1;
                }
                if (r > histogramLUT.Length - 1)
                {
                    r = histogramLUT.Length - 1;
                }
                histogramRight[z] = r;

                if (r > histogramLUT.Length - 1)
                {
                    r = histogramLUT.Length - 1;
                }
                switch (method)
                {
                    case Methods.Average:
                        histogramNew[z] = (histogramLeft[z] + histogramRight[z]) / 2;
                        break;
                    case Methods.Neighbor:
                        histogramNew[z] = histogramRight[z] - histogramLeft[z];
                        break;
                    case Methods.Random:
                        histogramNew[z] = histogramRight[z] - histogramLeft[z];
                        break;
                }
            }

            for (int y = 0; y < image1.Height; ++y)
            {
                for (int x = 0; x < image1.Width; ++x)
                {
                    int color = 0;
                    int pixel = (histogram[x, y]);
                    int avgPixel;
                    int a = image1.Width - 1;
                    if (histogramLeft[pixel] == histogramRight[pixel])
                    {
                        color = histogramLeft[pixel];
                    }
                    else
                    {
                        switch (method)
                        {
                            case Methods.Average:
                                color = histogramNew[pixel];
                                // histogram[x, y] = color;
                                break;

                            case Methods.Neighbor:
                                if (x == a)
                                {
                                    avgPixel = (pixel + histogram[0, y]) / 2;
                                }
                                else
                                {
                                    avgPixel = (pixel + histogram[x + 1, y]) / 2;
                                }
                                if (avgPixel > histogramRight[pixel])
                                    color = histogramRight[pixel];
                                if (avgPixel < histogramLeft[pixel])
                                    color = histogramLeft[pixel];
                                else
                                    color = avgPixel;
                                //histogram[x, y] = color;
                                break;
                            case Methods.Random:
                                int rndm = randomZ.Next(0, histogramNew[pixel]);
                                color = (histogramLeft[pixel]) + rndm;
                                //histogram[x, y] = color;
                                break;
                        }
                    }
                    histogram[x, y] = color;
                }
            }
            return histogram;
        }
    }
}

/*public void DrawHisto(Chart ch, int[] histoLut)
{
    //Chart chart1 = new Chart();
    Chart chart1 = ch;
    int[] histo = histoLut;
    chart1.Series.Add("Gray");
    chart1.Series["Gray"].Points.Clear();
    //chart1.ChartAreas[0].AxisX.Minimum = 0;
    // chart1.ChartAreas[0].AxisX.Maximum = 256;
    //chart1.ChartAreas[0].AxisX.Interval = 64;
    for (int i = 0; i < histo.Length; ++i)
    {
        chart1.Series["Gray"].Points.AddXY(i, histo[i]);
    }
}*/

