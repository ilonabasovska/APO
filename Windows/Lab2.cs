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
        /************************************************************************************/
        /****************Neighbor***************************/
        /****************1. powiekszanie skrajnych pikseli*/

        public static int[,] LinearFiltration3x3(Bitmap bmp, string extremePixels, int k1, int k2, int k3, int k4, int k5, int k6, int k7, int k8, int k9)
        {
            int K = (k1 + k2 + k3 + k4 + k5 + k6 + k7 + k8 + k9);
            Bitmap image = new Bitmap(bmp);
            int newWidth3x3 = image.Width + 2;
            int newHeigyt3x3 = image.Height + 2;
            int[,] image3x3 = new int[(newWidth3x3), (newHeigyt3x3)];
            // int[,] image5x5 = new int[image.Width + 4, image.Height + 4];
            int[,] imageOld = new int[image.Width, image.Height];
            int[,] imageNew = new int[image.Width, image.Height];
            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    imageOld[x, y] = ((pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000);
                }
            }
            switch (extremePixels)
            {
                case "Duplication":
                    //left top angle
                    image3x3[0, 0] = imageOld[0, 0];
                    //right top angle
                    image3x3[newWidth3x3 - 1, 0] = imageOld[image.Width - 1, 0];
                    // left bottom angle
                    image3x3[0, newHeigyt3x3 - 1] = imageOld[0, image.Height - 1];
                    //right bottom angle
                    image3x3[newWidth3x3 - 1, newHeigyt3x3 - 1] = imageOld[image.Width - 1, image.Height - 1];
                    //top & bottom lines
                    for (int x = 1; x < newWidth3x3 - 1; ++x)
                    {
                        image3x3[x, 0] = imageOld[x - 1, 0];
                        image3x3[x, newHeigyt3x3 - 1] = imageOld[x - 1, image.Height - 1];
                    }
                    //left & right columns
                    for (int y = 1; y < newHeigyt3x3 - 1; ++y)
                    {
                        image3x3[0, y] = imageOld[0, y - 1];
                        image3x3[newWidth3x3 - 1, y] = imageOld[image.Width - 1, y - 1];
                    }
                    for (int x = 1; x < newWidth3x3 - 1; ++x)
                    {
                        for (int y = 1; y < newHeigyt3x3 - 1; ++y)
                        {
                            image3x3[x, y] = imageOld[x - 1, y - 1];
                        }
                    }
                    for (int x = 1; x <= image.Width; ++x)
                    {
                        for (int y = 1; y <= image.Height; ++y)
                        {
                            imageNew[x - 1, y - 1] = ((((k1 * image3x3[x - 1, y - 1]) / K) + ((k2 * image3x3[x - 1, y]) / K) + ((k3 * image3x3[x - 1, y + 1]) / K) + ((k4 * image3x3[x, y - 1])/K) + ((k5 * image3x3[x, y])/K) + ((k6 * image3x3[x, y + 1])/K) + ((k7  * image3x3[x + 1, y - 1])/K) + ((k8  * image3x3[x + 1, y])/K) + ((k9  * image3x3[x + 1, y + 1])/K)));
                        }
                    }
                    break;
                /****************2. pozostawienei bez zmian*/
                case "Unchanged":
                    for (int x = 0; x < image.Width; ++x)
                    {
                        imageNew[x, 0] = imageOld[x, 0];
                        imageNew[x, image.Height - 1] = imageOld[x, image.Height - 1];
                    }
                    //left & right columns
                    for (int y = 0; y < image.Height; ++y)
                    {
                        imageNew[0, y] = imageOld[0, y];
                        imageNew[image.Width - 1, y] = imageOld[image.Width - 1, y];
                    }
                    for (int x = 1; x < image.Width - 1; ++x)
                    {
                        for (int y = 1; y < image.Height - 1; ++y)
                        {
                            imageNew[x, y] =  ((((k1 * imageOld[x - 1, y - 1]) / K) + ((k2 * imageOld[x - 1, y]) / K) + ((k3 * imageOld[x - 1, y + 1]) / K) + ((k4 * imageOld[x, y - 1]) / K) + ((k5 * imageOld[x, y]) / K) + ((k6 * imageOld[x, y + 1]) / K) + ((k7 * imageOld[x + 1, y - 1]) / K) + ((k8 * imageOld[x + 1, y]) / K) + ((k9 * imageOld[x + 1, y + 1]) / K)));
                        }
                    }
                    break;
                /****************3.istniejące sąsiedstwo*/
                case "Existing":
                    //top && bottom lines
                    for (int x = 0; x < newWidth3x3; ++x)
                    {
                        image3x3[x, 0] = 0;
                        image3x3[x, newHeigyt3x3-1] = 0;
                    }
                    //left & right columns
                    for (int y = 1; y < newWidth3x3; ++y)
                    {
                        image3x3[0, y] = 0;
                        image3x3[newWidth3x3-1, y] = 0;
                    }
                    for (int x = 1; x < image.Width+1; ++x)
                    {
                        for (int y = 1; y < image.Height+1; ++y)
                        {
                            image3x3[x, y] = imageOld[x - 1, y - 1];
                        }
                    }
                    for (int x = 1; x <=image.Width; ++x)
                    {
                        for (int y = 1; y <= image.Height; ++y)
                        {
                            imageNew[x - 1, y - 1] = ((((k1 * image3x3[x - 1, y - 1]) / K) + ((k2 * image3x3[x - 1, y]) / K) + ((k3 * image3x3[x - 1, y + 1]) / K) + ((k4 * image3x3[x, y - 1]) / K) + ((k5 * image3x3[x, y]) / K) + ((k6 * image3x3[x, y + 1]) / K) + ((k7 * image3x3[x + 1, y - 1]) / K) + ((k8 * image3x3[x + 1, y]) / K) + ((k9 * image3x3[x + 1, y + 1]) / K)));
                        }
                    }
                    break;
                default:
                    break;
            }
            return imageNew;
        }
    }
}



