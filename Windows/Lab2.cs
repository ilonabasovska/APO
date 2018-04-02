using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    class Lab2
    {
        public static int[,] OnePointOneArgumentOperation(Bitmap bmp, string name, int downLevel, int upLevel, int p3Level, int p4Level, int q2Level, int q3Level, int q4Level)
        {
            int p1 = downLevel;
            int p2 = upLevel;
            int p3 = p3Level;
            int p4 = p4Level;
            int q2 = q2Level;
            int q3 = q3Level;
            int q4 = q4Level;

            Bitmap image1 = new Bitmap(bmp);
            Bitmap image2 = new Bitmap(image1.Width, image1.Height);
            Color pixelColor = new Color();
            int[,] histogram = new int[image1.Width, image1.Height];
            int[,] histogramNew = new int[image1.Width, image1.Height];
            int[] histoGC = new int[256];
            for (int i = 0; i < 256; ++i)
            {
                int pos = (int)((255 * Math.Pow((double)i / 255.0, 1.0 / 255.0)) + 0.5);
                pos = Math.Min(Math.Max(pos, 0), 255);
                histoGC[i] = (int)pos;
            }
            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    pixelColor = image1.GetPixel(x, y);
                    histogram[x, y] = (pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000;

                    switch (name)
                    {
                        case "Identity":
                            histogramNew[x, y] = histogram[x, y];
                            break;

                        case "Negation":
                            histogramNew[x, y] = 255 - histogram[x, y];
                            break;

                        case "ThresholdBinary":
                            if (histogram[x, y] <= p1)
                                histogramNew[x, y] = 0;
                            else
                                histogramNew[x, y] = 255;
                            break;

                        case "IntervalThresholdgBinary":
                            if (histogram[x, y] > p1 && histogram[x, y] <= p2)
                                histogramNew[x, y] = 255;
                            else
                                histogramNew[x, y] = 0;
                            break;

                        case "InverseThresholdBinary":
                            if (histogram[x, y] <= p1)
                                histogramNew[x, y] = 255;
                            else
                                histogramNew[x, y] = 0;
                            break;

                        case "InverseIntervalTresholdBinary":
                            if (histogram[x, y] > p1 && histogram[x, y] <= p2)
                                histogramNew[x, y] = 0;
                            else
                                histogramNew[x, y] = 255;
                            break;

                        case "ThresholdGrayLevels":
                            if (p1 <= histogram[x, y] && histogram[x, y] <= p2)
                                histogramNew[x, y] = histogram[x, y];
                            else
                                histogramNew[x, y] = 0;
                            break;

                        case "InverseThresholdGrayLevels":
                            if (p1 <= histogram[x, y] && histogram[x, y] <= p2)
                                histogramNew[x, y] = 255 - histogram[x, y];
                            else
                                histogramNew[x, y] = 0;
                            break;

                        case "Stretching":
                            if (histogram[x, y] > p1 && histogram[x, y] <= p2)
                                histogramNew[x, y] = (histogram[x, y] - p1) * (255 / (p2 - p1));
                            else
                                histogramNew[x, y] = 0;
                            break;

                        case "ReducingGrayLevels":
                            if (histogram[x, y] <= p1)
                            {
                                histogramNew[x, y] = 0;
                            }
                            else if (histogram[x, y] > p1 && histogram[x, y] <= p2)
                            {
                                histogramNew[x, y] = q2;
                            }
                            else if (histogram[x, y] > p2 && histogram[x, y] <= p3)
                            {
                                histogramNew[x, y] = q3;
                            }
                            else if (histogram[x, y] > p3 && histogram[x, y] <= p4)
                            {
                                histogramNew[x, y] = q4;
                            }
                            else
                                histogramNew[x, y] = 255;
                            break;

                        case "Brightness":
                            histogramNew[x, y] = pixelColor.R + p1;
                            if (histogramNew[x, y] >= 255)
                            {
                                histogramNew[x, y] = 255;
                            }
                            else if (histogramNew[x, y] <= 0)
                            {
                                histogramNew[x, y] = 0;
                            }
                            break;

                        case "Contrast":
                            double multiplier = (100.0 + (double)p1) / 100.0;
                            double temp = (double)((pixelColor.R / 255.0) - 0.5);
                            temp = (temp * multiplier + 0.5);
                            histogramNew[x, y] = (int)Math.Max(0, Math.Min(255, (int)(temp * 255)));
                            break;

                        case "GammaCorrection":

                            histogramNew[x, y] = (histoGC[pixelColor.R]);
                            break;


                        default:
                            break;
                    }
                }
            }
            return histogramNew;
        }
        public static int[] HistogramDifferences(string name, int downLevel, int upLevel, int p3Level, int p4Level, int q2Level, int q3Level, int q4Level)
        {
            int p1 = downLevel;
            int p2 = upLevel;
            int p3 = p3Level;
            int p4 = p4Level;
            int q2 = q2Level;
            int q3 = q3Level;
            int q4 = q4Level;

            int[] histogramP = new int[256];
            int[] histogramQ = new int[256];
            double multiplier = (100.0 + (double)p1) / 100.0;

            for (int i = 0; i < 256; i++)
            {
                switch (name)
                {
                    case "Identity":
                        histogramQ[i] = i;
                        break;

                    case "Negation":
                        histogramQ[i] = 255 - i;
                        break;

                    case "ThresholdBinary":
                        if (i <= p1)
                            histogramQ[i] = 0;
                        else
                            histogramQ[i] = 255;
                        break;

                    case "IntervalThresholdgBinary":
                        if (i > p1 && i <= p2)
                            histogramQ[i] = 255;
                        else
                            histogramQ[i] = 0;
                        break;

                    case "InverseThresholdBinary":
                        if (i <= p1)
                            histogramQ[i] = 255;
                        else
                            histogramQ[i] = 0;
                        break;

                    case "InverseIntervalTresholdBinary":
                        if (i > p1 && i <= p2)
                            histogramQ[i] = 0;
                        else
                            histogramQ[i] = 255;
                        break;

                    case "ThresholdGrayLevels":
                        if (p1 <= i && i <= p2)
                            histogramQ[i] = i;
                        else
                            histogramQ[i] = 0;
                        break;

                    case "InverseThresholdGrayLevels":
                        if (p1 <= i && i <= p2)
                            histogramQ[i] = 255 - i;
                        else
                            histogramQ[i] = 0;
                        break;

                    case "Stretching":
                        if (i > p1 && i <= p2)
                            histogramQ[i] = (255 * (i - p1) / (p2 - p1));
                        else
                            histogramQ[i] = 0;
                        break;

                    case "ReducingGrayLevels":
                        if (i <= p1)
                        {
                            histogramQ[i] = 0;
                        }
                        else if (i > p1 && i <= p2)
                        {
                            histogramQ[i] = q2;
                        }
                        else if (i > p2 && i <= p3)
                        {
                            histogramQ[i] = q3;
                        }
                        else if (i > p3 && i <= p4)
                        {
                            histogramQ[i] = q4;
                        }
                        else
                            histogramQ[i] = 255;
                        break;

                    case "Brightness":
                        histogramQ[i] = i + p1;
                        if (histogramQ[i] >= 255)
                        {
                            histogramQ[i] = 255;
                        }
                        else if (histogramQ[i] <= 0)
                        {
                            histogramQ[i] = 0;
                        }
                        break;

                    case "Contrast":
                        double temp = (double)((i / 255.0) - 0.5);
                        temp = (temp * multiplier + 0.5);
                        histogramQ[i] = (int)Math.Max(0, Math.Min(255, (int)(temp * 255)));
                        break;

                    case "GammaCorrection":
                        break;


                    default:
                        break;
                }
            }
            return histogramQ;
        }
       
    }
}



