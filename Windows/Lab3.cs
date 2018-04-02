using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    internal class Lab3
    {
        /************************************************************************************/
        /****************Neighbor***************************/

        public static int[] maskFiltration(string methodSmoothing)
        {
            int[] k = new int[10];
            k[1] = 1;
            k[3] = 1;
            k[7] = 1;
            k[9] = 1;

            switch (methodSmoothing)
            {
                case "1/9":
                    k[2] = 1;
                    k[4] = 1;
                    k[5] = 1;
                    k[6] = 1;
                    k[8] = 1;
                    k[0] = k[1] + k[2] + k[3] + k[4] + k[5] + k[6] + k[7] + k[8] + k[9];
                    break;
                case "1/10":
                    k[2] = 1;
                    k[4] = 1;
                    k[5] = 2;
                    k[6] = 1;
                    k[8] = 1;
                    k[0] = k[1] + k[2] + k[3] + k[4] + k[5] + k[6] + k[7] + k[8] + k[9];
                    break;
                case "1/16":
                    k[2] = 2;
                    k[4] = 2;
                    k[5] = 4;
                    k[6] = 2;
                    k[8] = 2;
                    k[0] = k[1] + k[2] + k[3] + k[4] + k[5] + k[6] + k[7] + k[8] + k[9];
                    break;
            }

            return k;
        }


        public static int[,] exstremeMethod(Bitmap bmp, string extremePixels, int[] mask)
        {
            Bitmap image = new Bitmap(bmp);
            // int[,] image5x5 = new int[image.Width + 4, image.Height + 4];
            int[,] imageOld = new int[image.Width, image.Height];
            int[,] imageNew = new int[image.Width, image.Height];
            int newWidth3x3 = image.Width + 2;
            int newHeight3x3 = image.Height + 2;
            int[,] image3x3 = new int[(newWidth3x3), (newHeight3x3)];
            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    imageOld[x, y] = ((pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000);
                }
            }
            /****************1. powiekszanie skrajnych pikseli*/
            switch (extremePixels)
            {
                case "Duplication":
                    //left top angle
                    image3x3[0, 0] = imageOld[0, 0];
                    //right top angle
                    image3x3[newWidth3x3 - 1, 0] = imageOld[image.Width - 1, 0];
                    // left bottom angle
                    image3x3[0, newHeight3x3 - 1] = imageOld[0, image.Height - 1];
                    //right bottom angle
                    image3x3[newWidth3x3 - 1, newHeight3x3 - 1] = imageOld[image.Width - 1, image.Height - 1];
                    //top & bottom lines
                    for (int x = 1; x < newWidth3x3 - 1; ++x)
                    {
                        image3x3[x, 0] = imageOld[x - 1, 0];
                        image3x3[x, newHeight3x3 - 1] = imageOld[x - 1, image.Height - 1];
                    }
                    //left & right columns
                    for (int y = 1; y < newHeight3x3 - 1; ++y)
                    {
                        image3x3[0, y] = imageOld[0, y - 1];
                        image3x3[newWidth3x3 - 1, y] = imageOld[image.Width - 1, y - 1];
                    }
                    for (int x = 1; x < newWidth3x3 - 1; ++x)
                    {
                        for (int y = 1; y < newHeight3x3 - 1; ++y)
                        {
                            image3x3[x, y] = imageOld[x - 1, y - 1];
                        }
                    }
                    for (int x = 1; x <= image.Width; ++x)
                    {
                        for (int y = 1; y <= image.Height; ++y)
                        {
                            imageNew[x - 1, y - 1] = ((((mask[1] * image3x3[x - 1, y - 1]) / mask[0]) + ((mask[2] * image3x3[x, y - 1]) / mask[0]) + ((mask[3] * image3x3[x + 1, y - 1]) / mask[0]) +
                                                       ((mask[4] * image3x3[x - 1, y]) / mask[0]) + ((mask[5] * image3x3[x, y]) / mask[0]) + ((mask[6] * image3x3[x + 1, y]) / mask[0]) +
                                                       ((mask[7] * image3x3[x - 1, y + 1]) / mask[0]) + ((mask[8] * image3x3[x, y + 1]) / mask[0]) + ((mask[9] * image3x3[x + 1, y + 1]) / mask[0])));
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
                            imageNew[x, y] = ((((mask[1] * imageOld[x - 1, y - 1]) / mask[0]) + ((mask[2] * imageOld[x, y - 1]) / mask[0]) + ((mask[3] * imageOld[x + 1, y - 1]) / mask[0]) +
                                               ((mask[4] * imageOld[x - 1, y]) / mask[0]) + ((mask[5] * imageOld[x, y]) / mask[0]) + ((mask[6] * imageOld[x + 1, y]) / mask[0]) +
                                               ((mask[7] * imageOld[x - 1, y + 1]) / mask[0]) + ((mask[8] * imageOld[x, y + 1]) / mask[0]) + ((mask[9] * imageOld[x + 1, y + 1]) / mask[0])));
                        }
                    }
                    break;
                /****************3.istniejące sąsiedstwo*/
                case "Existing":
                    //top && bottom lines
                    for (int x = 0; x < newWidth3x3; ++x)
                    {
                        image3x3[x, 0] = 0;
                        image3x3[x, newHeight3x3 - 1] = 0;
                    }
                    //left & right columns
                    for (int y = 1; y < newWidth3x3; ++y)
                    {
                        image3x3[0, y] = 0;
                        image3x3[newWidth3x3 - 1, y] = 0;
                    }
                    for (int x = 1; x < image.Width + 1; ++x)
                    {
                        for (int y = 1; y < image.Height + 1; ++y)
                        {
                            image3x3[x, y] = imageOld[x - 1, y - 1];
                        }
                    }
                    for (int x = 1; x <= image.Width; ++x)
                    {
                        for (int y = 1; y <= image.Height; ++y)
                        {
                            imageNew[x - 1, y - 1] = ((((mask[1] * image3x3[x - 1, y - 1]) / mask[0]) + ((mask[2] * image3x3[x, y - 1]) / mask[0]) + ((mask[3] * image3x3[x + 1, y - 1]) / mask[0]) +
                                                       ((mask[4] * image3x3[x - 1, y]) / mask[0]) + ((mask[5] * image3x3[x, y]) / mask[0]) + ((mask[6] * image3x3[x + 1, y]) / mask[0]) +
                                                       ((mask[7] * image3x3[x - 1, y + 1]) / mask[0]) + ((mask[8] * image3x3[x, y + 1]) / mask[0]) + ((mask[9] * image3x3[x + 1, y + 1]) / mask[0])));
                        }
                    }
                    break;

                /**metoda własna jako piłka, 
                 * dla pixela [0,0] sąsiadami są    1 - pixel po przekątnej [image.Width-1, image.Height-1]
                                                    2 - [0, image.Height-1]
                                                    3 - [1,image.Height-1]
                                                    4 - [image.Weigth-1,0]
                                                    5 - [0,0]
                                                    6 - [1,0]
                                                    7 - [image.Width-1,1]
                                                    8 - [0,1]
                                                    9 - [1,1]

                * dla pixela [image.Width-1, image.Height-1] sąsiadami są 1 - [image.Width-2, image.Height-2]
                                                                          2 - [image.Width-1, image.Height-2]
                                                                          3 - [0, image.Height-2]
                                                                          4 - [image.Width-2, image.Height-1]
                                                                          5 - [image.Width-1, image.Height-1]
                                                                          6 - [0, image.Height-1]
                                                                          7 - [image.Width-2,0]
                                                                          8 - [image.Width-1,0]
                                                                          9 - [0,0]

                 * dla pixela [image.Weigth-1,0] sąsiadami są    1 - [image.Width-2, image.Height-1]
                                                                 2 - [mage.Width-1, image.Height-1]
                                                                 3 - [0,image.Height-1]
                                                                 4 - [image.Weigth-2,0]
                                                                 5 - [image.Weigth-1,0]
                                                                 6 - [0,0]
                                                                 7 - image.Weigth-2,1]
                                                                 8 - [image.Weigth-1,1]
                                                                 9 - [0,1]

                * dla pixela [0, image.Height-1] sąsiadami są             1 - [image.Width-1, image.Height-2]
                                                                          2 - [0, image.Height-2]
                                                                          3 - [1, image.Height-2]
                                                                          4 - [image.Width-1, image.Height-1]
                                                                          5 - [0, image.Height-1]
                                                                          6 - [1, image.Height-1]
                                                                          7 - [image.Width-1, image.Height-1]
                                                                          8 - [0,0]
                                                                          9 - [0,1]


               * dla pikseli w 0 wierszy sąsiadamy są pikseli w  [x, image.Height - 1]
                                                                [x, 0]
                                                                [x, 1]
               * dla pikseli w ostatnim wierszy(czyli w wieszu image.Height -1 )
                                      sąsiadamy są pikseli w    [x, image.Height - 2]
                                                                [x, image.Height - 1]
                                                                [x, 0]
               * dla pikseli w 0 kolumnie sąsiadamy są pikseli w [image.Weight - 1,y]
                                                                [0, y]
                                                                [1, y]
                * dla pikseli w ostatnim kolumnie(czyli w kolumnie image.Weight -1)
                                      sąsiadamy są pikseli w    [image.Weight -2, y]
                                                                [image.Weight -1, y]
                                                                [0, y]
                                        */
                case "Ball":
                    imageNew[0, 0] = ((((mask[1] * imageOld[image.Width - 1, image.Height - 1]) / mask[0]) + ((mask[2] * imageOld[0, image.Height - 1]) / mask[0]) + ((mask[3] * imageOld[1, image.Height - 1]) / mask[0]) +
                                     ((mask[4] * imageOld[image.Width - 1, 0]) / mask[0]) + ((mask[5] * imageOld[0, 0]) / mask[0]) + ((mask[6] * imageOld[1, 0]) / mask[0]) +
                                     ((mask[7] * imageOld[image.Width - 1, 1]) / mask[0]) + ((mask[8] * imageOld[1, 0]) / mask[0]) + ((mask[9] * imageOld[1, 1]) / mask[0])));


                    imageNew[image.Width - 1, 0] = ((((mask[1] * imageOld[image.Width - 2, image.Height - 1]) / mask[0]) + ((mask[2] * imageOld[image.Width - 1, image.Height - 1]) / mask[0]) + ((mask[3] * imageOld[0, image.Height - 1]) / mask[0]) +
                                                     ((mask[4] * imageOld[image.Width - 2, 0]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, 0]) / mask[0]) + ((mask[6] * imageOld[0, 0]) / mask[0]) +
                                                     ((mask[7] * imageOld[image.Width - 2, 1]) / mask[0]) + ((mask[8] * imageOld[image.Width - 1, 1]) / mask[0]) + ((mask[9] * imageOld[01, 1]) / mask[0])));

                    imageNew[0, image.Height - 1] = ((((mask[1] * imageOld[image.Width - 1, image.Height - 2]) / mask[0]) + ((mask[2] * imageOld[0, image.Height - 2]) / mask[0]) + ((mask[3] * imageOld[1, image.Height - 2]) / mask[0]) +
                                                      ((mask[4] * imageOld[image.Width - 1, image.Height - 1]) / mask[0]) + ((mask[5] * imageOld[0, image.Height - 1]) / mask[0]) + ((mask[6] * imageOld[1, image.Height - 1]) / mask[0]) +
                                                      ((mask[7] * imageOld[image.Width - 1, 0]) / mask[0]) + ((mask[8] * imageOld[0, 0]) / mask[0]) + ((mask[9] * imageOld[0, 1]) / mask[0])));

                    imageNew[image.Width - 1, image.Height - 1] = ((((mask[1] * imageOld[image.Width - 2, image.Height - 2]) / mask[0]) + ((mask[2] * imageOld[image.Width - 1, image.Height - 2]) / mask[0]) + ((mask[3] * imageOld[0, image.Height - 2]) / mask[0]) +
                                                                    ((mask[4] * imageOld[image.Width - 2, image.Height - 1]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, image.Height - 1]) / mask[0]) + ((mask[6] * imageOld[0, image.Height - 1]) / mask[0]) +
                                                                    ((mask[7] * imageOld[image.Width - 2, 0]) / mask[0]) + ((mask[8] * imageOld[image.Width - 1, 0]) / mask[0]) + ((mask[9] * imageOld[0, 0]) / mask[0])));

                    for (int x = 1; x < image.Width - 1; ++x)
                    {
                        /*0-wy wiersz*/
                        imageNew[x, 0] = ((((mask[1] * imageOld[x - 1, image.Height - 1]) / mask[0]) + ((mask[2] * imageOld[x, image.Height - 1]) / mask[0]) + ((mask[3] * imageOld[x + 1, image.Height - 1]) / mask[0]) +
                                            ((mask[4] * imageOld[x - 1, 0]) / mask[0]) + ((mask[5] * imageOld[x, 0]) / mask[0]) + ((mask[6] * imageOld[x + 1, 0]) / mask[0]) +
                                            ((mask[7] * imageOld[x - 1, 1]) / mask[0]) + ((mask[8] * imageOld[x, 1]) / mask[0]) + ((mask[9] * imageOld[x + 1, 1]) / mask[0])));
                        /*image.Height - 1 wiersz*/
                        imageNew[x, image.Height - 1] = ((((mask[1] * imageOld[x - 1, image.Height - 2]) / mask[0]) + ((mask[2] * imageOld[x, image.Height - 2]) / mask[0]) + ((mask[3] * imageOld[x + 1, image.Height - 2]) / mask[0]) +
                                                          ((mask[4] * imageOld[x - 1, image.Height - 1]) / mask[0]) + ((mask[5] * imageOld[x, image.Height - 1]) / mask[0]) + ((mask[6] * imageOld[x + 1, image.Height - 1]) / mask[0]) +
                                                          ((mask[7] * imageOld[x - 1, 0]) / mask[0]) + ((mask[8] * imageOld[x, 0]) / mask[0]) + ((mask[9] * imageOld[x + 1, 0]) / mask[0])));
                    }
                    //left & right columns
                    for (int y = 1; y < image.Height - 1; ++y)
                    {
                        /*0-wa kolumna*/
                        imageNew[0, y] = ((((mask[1] * imageOld[image.Width - 1, y - 1]) / mask[0]) + ((mask[2] * imageOld[0, y - 1]) / mask[0]) + ((mask[3] * imageOld[1, y - 1]) / mask[0]) +
                                            ((mask[4] * imageOld[image.Width - 1, y]) / mask[0]) + ((mask[5] * imageOld[0, y]) / mask[0]) + ((mask[6] * imageOld[1, y]) / mask[0]) +
                                            ((mask[7] * imageOld[image.Width - 1, y + 1]) / mask[0]) + ((mask[8] * imageOld[0, y + 1]) / mask[0]) + ((mask[9] * imageOld[1, y + 1]) / mask[0])));
                        /*image.Height - 1 - ostatnia kolumna*/
                        imageNew[image.Width - 1, y] = ((((mask[1] * imageOld[image.Width - 2, y - 1]) / mask[0]) + ((mask[2] * imageOld[image.Width - 1, y - 1]) / mask[0]) + ((mask[3] * imageOld[0, y - 1]) / mask[0]) +
                                                          ((mask[4] * imageOld[image.Width - 2, y]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, y]) / mask[0]) + ((mask[6] * imageOld[0, y]) / mask[0]) +
                                                          ((mask[7] * imageOld[image.Width - 2, y + 1]) / mask[0]) + ((mask[8] * imageOld[image.Width - 1, y + 1]) / mask[0]) + ((mask[9] * imageOld[0, y + 1]) / mask[0])));
                    }
                    for (int x = 1; x < image.Width - 1; ++x)
                    {
                        for (int y = 1; y < image.Height - 1; ++y)
                        {
                            imageNew[x, y] = ((((mask[1] * imageOld[x - 1, y - 1]) / mask[0]) + ((mask[2] * imageOld[x, y - 1]) / mask[0]) + ((mask[3] * imageOld[x + 1, y - 1]) / mask[0]) +
                                               ((mask[4] * imageOld[x - 1, y]) / mask[0]) + ((mask[5] * imageOld[x, y]) / mask[0]) + ((mask[6] * imageOld[x, y - 1]) / mask[0]) +
                                               ((mask[7] * imageOld[x - 1, y + 1]) / mask[0]) + ((mask[8] * imageOld[x, y + 1]) / mask[0]) + ((mask[9] * imageOld[x + 1, y + 1]) / mask[0])));
                        }
                    }

                    break;
                default:
                    break;
            }
            return imageNew;
        }
        public static int[] maskSharpering(string methodSharpering)
        {
            int[] mask = new int[10];
            mask[0] = 1;
            switch (methodSharpering)
            {
                case "LaplacianMask1":
                    mask[1] = 0;
                    mask[2] = 1;
                    mask[3] = 0;
                    mask[4] = 1;
                    mask[5] = -4;
                    mask[6] = 1;
                    mask[7] = 0;
                    mask[8] = 1;
                    mask[9] = 0;
                    break;
                case "LaplacianMask2":
                    mask[1] = 0;
                    mask[2] = -1;
                    mask[3] = 0;
                    mask[4] = -1;
                    mask[5] = 4;
                    mask[6] = -1;
                    mask[7] = 0;
                    mask[8] = -1;
                    mask[9] = 0;
                    break;
                case "LaplacianMask3":
                    mask[1] = -1;
                    mask[2] = -1;
                    mask[3] = -1;
                    mask[4] = -1;
                    mask[5] = 8;
                    mask[6] = -1;
                    mask[7] = -1;
                    mask[8] = -1;
                    mask[9] = -1;
                    break;
                case "LaplacianMask4":
                    mask[1] = 1;
                    mask[2] = -2;
                    mask[3] = 1;
                    mask[4] = -2;
                    mask[5] = 4;
                    mask[6] = -2;
                    mask[7] = 1;
                    mask[8] = -2;
                    mask[9] = 1;
                    break;
                case "LaplacianMask5":
                    mask[1] = -1;
                    mask[2] = -1;
                    mask[3] = -1;
                    mask[4] = -1;
                    mask[5] = 9;
                    mask[6] = -1;
                    mask[7] = -1;
                    mask[8] = -1;
                    mask[9] = -1;
                    break;
                case "EdgeDetectionMask1":
                    mask[1] = 1;
                    mask[2] = -2;
                    mask[3] = 1;
                    mask[4] = -2;
                    mask[5] = 5;
                    mask[6] = -2;
                    mask[7] = 1;
                    mask[8] = -2;
                    mask[9] = 1;
                    break;
                case "EdgeDetectionMask2":
                    mask[1] = -1;
                    mask[2] = -1;
                    mask[3] = -1;
                    mask[4] = -1;
                    mask[5] = 9;
                    mask[6] = -1;
                    mask[7] = -1;
                    mask[8] = -1;
                    mask[9] = -1;
                    break;
                case "EdgeDetectionMask3":
                    mask[1] = 0;
                    mask[2] = -1;
                    mask[3] = 0;
                    mask[4] = -1;
                    mask[5] = 5;
                    mask[6] = -1;
                    mask[7] = 0;
                    mask[8] = -1;
                    mask[9] = 0;
                    break;
            }
            return mask;
        }

        public static int[,] scalingMethod(int [,] bmp, string methodScaling)
        {
            int bmpWidth = bmp.GetUpperBound(0) + 1;
            int bmpHeight = bmp.GetUpperBound(1) + 1;
           // int[,] histo = new int[bmpWidth, bmpHeight];
            int[,] histoNew = new int[bmpWidth, bmpHeight];
            int histoMax = 0;
            int histoMin = 255;

            switch (methodScaling)
            {
                case "ScalingMethod1":
                    /*MIN*/
                    for (int x = 0; x < bmpWidth; ++x)
                    {
                        for (int y = 0; y < bmpHeight; ++y)
                        {
                            if (bmp[x, y] < histoMin)
                            {
                                histoMin = bmp[x, y];
                            }
                        }
                    }

                    /*MAX*/
                    for (int x = 0; x < bmpWidth; ++x)
                    {
                        for (int y = 0; y < bmpHeight; ++y)
                        {
                            if (bmp[x, y] > histoMax)
                            {
                                histoMax = bmp[x, y];
                            }
                        }
                    }
                    for (int x = 0; x < bmpWidth; ++x)
                    {
                        for (int y = 0; y < bmpHeight; ++y)
                        {
                            int a = bmp[x, y] - histoMin;
                            int b = histoMax - histoMin+1;
                            histoNew[x, y] = 255*a/b;
                        }
                    }
                    break;
                case "ScalingMethod2":
                    for (int x = 0; x < bmpWidth; ++x)
                    {
                        for (int y = 0; y < bmpHeight; ++y)
                        {
                            if (bmp[x, y] < 0)
                            {
                                histoNew[x, y] = 0;
                            }
                            else if (bmp[x, y] == 0)
                            {
                                histoNew[x, y] = 127;
                            }
                            else
                            {
                                histoNew[x, y] = 255;
                            }
                        }
                    }
                    break;
                case "ScalingMethod3":
                    for (int x = 0; x < bmpWidth; ++x)
                    {
                        for (int y = 0; y < bmpHeight; ++y)
                        {
                            if (bmp[x, y] < 0)
                            {
                                histoNew[x, y] = 0;
                            }
                            else if (bmp[x, y] >255)
                            {
                                histoNew[x, y] = 255;
                            }
                            else
                            {
                                histoNew[x, y] = bmp[x,y];
                            }
                        }
                    }
                    break;

            }
            return histoNew;
        }

        public static int[,] LinearFiltration3x3(Bitmap bmp, string extremePixels, string methodSmoothing)
        {
            int[] K = new int[10];

            K = maskFiltration(methodSmoothing);

            return exstremeMethod(bmp, extremePixels, K);
        }

         public static int[,] Sharpering(Bitmap bmp, string extremePixels, string methodSharpering, string methodScaling)
         {
            int[] maskSharper = new int[10];
            maskSharper = maskSharpering(methodSharpering);
            return scalingMethod(exstremeMethod(bmp, extremePixels, maskSharper), methodScaling);
        }
    }
}