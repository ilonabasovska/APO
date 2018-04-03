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
                    //lef top angle
                    imageNew[0, 0] = ((((mask[5] * imageOld[0, 0]) / mask[0]) + ((mask[6] * imageOld[1, 0]) / mask[0])
                                     + ((mask[8] * imageOld[0, 1]) / mask[0]) + ((mask[9] * imageOld[1, 1]) / mask[0])));

                    //rigth top angle
                    imageNew[image.Width - 1, 0] = ((((mask[4] * imageOld[image.Width - 2, 0]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, 0]) / mask[0]) +
                                                     ((mask[7] * imageOld[image.Width - 2, 1]) / mask[0]) + ((mask[8] * imageOld[image.Width - 1, 1]) / mask[0])));
                    //lef bottom angle
                    imageNew[0, image.Height - 1] = ((((mask[2] * imageOld[0, image.Height - 2]) / mask[0]) + ((mask[3] * imageOld[1, image.Height - 2]) / mask[0])
                                                    + ((mask[5] * imageOld[0, image.Height - 1]) / mask[0]) + ((mask[6] * imageOld[1, image.Height - 1]) / mask[0])));
                    //rigth bottom angle
                    imageNew[image.Width - 1, image.Height - 1] = ((((mask[1] * imageOld[image.Width - 2, image.Height - 2]) / mask[0]) + ((mask[2] * imageOld[image.Width - 1, image.Height - 2]) / mask[0]) +
                                                                    ((mask[4] * imageOld[image.Width - 2, image.Height - 1]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, image.Height - 1]) / mask[0])));

                    //top && bottom lines
                    for (int x = 1; x < image.Width - 1; ++x)
                    {
                        image3x3[x, 0] = ((((mask[4] * imageOld[x - 1, 0]) / mask[0]) + ((mask[5] * imageOld[x, 0]) / mask[0]) + ((mask[6] * imageOld[x + 1, 0]) / mask[0]) +
                                               ((mask[7] * imageOld[x - 1, 1]) / mask[0]) + ((mask[8] * imageOld[x, 1]) / mask[0]) + ((mask[9] * imageOld[x + 1, 1]) / mask[0])));
                        ;
                        image3x3[x, image.Width - 1] = ((((mask[1] * imageOld[x - 1, image.Height - 2]) / mask[0]) + ((mask[2] * imageOld[x, image.Height - 2]) / mask[0]) + ((mask[3] * imageOld[x + 1, image.Height - 2]) / mask[0]) +
                                                         ((mask[4] * imageOld[x - 1, image.Height - 1]) / mask[0]) + ((mask[5] * imageOld[x, image.Height - 1]) / mask[0]) + ((mask[6] * imageOld[x + 1, image.Height - 1]) / mask[0])));

                    }
                    //left & right columns
                    for (int y = 1; y < image.Height - 1; ++y)
                    {
                        imageNew[0, y] = ((((mask[2] * imageOld[0, y - 1]) / mask[0]) + ((mask[3] * imageOld[1, y - 1]) / mask[0]) +
                                           ((mask[5] * imageOld[0, y]) / mask[0]) + ((mask[6] * imageOld[1, y]) / mask[0]) +
                                           ((mask[8] * imageOld[0, y + 1]) / mask[0]) + ((mask[9] * imageOld[1, y + 1]) / mask[0])));

                        imageNew[image.Width - 1, y] = ((((mask[1] * imageOld[image.Width - 2, y - 1]) / mask[0]) + ((mask[2] * imageOld[image.Width - 1, y - 1]) / mask[0]) +
                                                         ((mask[4] * imageOld[image.Width - 2, y]) / mask[0]) + ((mask[5] * imageOld[image.Width - 1, y]) / mask[0]) +
                                                         ((mask[7] * imageOld[image.Width - 2, y + 1]) / mask[0]) + ((mask[8] * imageOld[image.Width - 1, y + 1]) / mask[0])));
                    }
                    for (int x = 1; x < image.Width - 2; ++x)
                    {
                        for (int y = 1; y < image.Height - 2; ++y)
                        {
                            imageNew[x, y] = imageOld[x, y];
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

        public static int[,] scalingMethod(int[,] bmp, string methodScaling)
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
                            int b = histoMax - histoMin + 1;
                            histoNew[x, y] = 255 * a / b;
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
                            else if (bmp[x, y] > 255)
                            {
                                histoNew[x, y] = 255;
                            }
                            else
                            {
                                histoNew[x, y] = bmp[x, y];
                            }
                        }
                    }
                    break;

            }
            return histoNew;
        }

        public static int[,] medianExtreme(Bitmap bmp, string extremePixels, string maskSize)
        {
            Bitmap image = new Bitmap(bmp);
            int newWidth3x3 = image.Width + 2;
            int newHeight3x3 = image.Height + 2;
            int[,] image3x3 = new int[(image.Width + 2), (image.Height + 2)];
            int[,] image3x5 = new int[(image.Width + 2), (image.Height + 4)];
            int[,] image5x3 = new int[(image.Width + 4), (image.Height + 2)];
            int[,] image5x5 = new int[image.Width + 4, image.Height + 4];
            int[,] image7x7 = new int[(image.Width + 6), (image.Height + 6)];
            int[,] imageOld = new int[image.Width, image.Height];
            int[,] imageNew = new int[image.Width, image.Height];
            List<int> pixel3x3 = new List<int>();

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    imageOld[x, y] = ((pixelColor.R * 299 + pixelColor.G * 587 + pixelColor.B * 114) / 1000);
                }
            }
            switch (maskSize)
            {
                case "3x3":
                    switch (extremePixels)
                    {
                        case "Duplication":
                            //left top angle
                            image3x3[0, 0] = imageOld[0, 0];
                            //right top angle
                            image3x3[image.Width + 1, 0] = imageOld[image.Width - 1, 0];
                            // left bottom angle
                            image3x3[0, image.Height + 1] = imageOld[0, image.Height - 1];
                            //right bottom angle
                            image3x3[image.Width + 1, image.Height + 1] = imageOld[image.Width - 1, image.Height - 1];
                            //top & bottom lines
                            for (int x = 1; x < image.Width + 1; ++x)
                            {
                                image3x3[x, 0] = imageOld[x - 1, 0];
                                image3x3[x, image.Height + 1] = imageOld[x - 1, image.Height - 1];
                            }
                            //left & right columns
                            for (int y = 1; y < image.Width + 1; ++y)
                            {
                                image3x3[0, y] = imageOld[0, y - 1];

                                image3x3[image.Width + 1, y] = imageOld[image.Width - 1, y - 1];
                            }
                            for (int x = 1; x < image.Width + 1; ++x)
                            {
                                for (int y = 1; y < image.Height + 1; ++y)
                                {
                                    image3x3[x, y] = imageOld[x - 1, y - 1];
                                }
                            }

                            for (int x = 1; x < image.Width + 1; ++x)
                            {
                                for (int y = 1; y < image.Height + 1; ++y)
                                {
                                    pixel3x3.Add(image3x3[x - 1, y - 1]);
                                    pixel3x3.Add(image3x3[x, y - 1]);
                                    pixel3x3.Add(image3x3[x + 1, y - 1]);

                                    pixel3x3.Add(image3x3[x - 1, y]);
                                    pixel3x3.Add(image3x3[x, y]);
                                    pixel3x3.Add(image3x3[x + 1, y]);

                                    pixel3x3.Add(image3x3[x - 1, y + 1]);
                                    pixel3x3.Add(image3x3[x, y + 1]);
                                    pixel3x3.Add(image3x3[x + 1, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x - 1, y - 1] = pixel3x3[4];

                                    pixel3x3.Clear();
                                }
                            }
                            break;

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
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);

                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);

                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[4];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Existing":
                            //lef top angle
                            pixel3x3.Add(imageOld[0, 0]);
                            pixel3x3.Add(imageOld[1, 0]);
                            pixel3x3.Add(imageOld[0, 1]);
                            pixel3x3.Add(imageOld[1, 1]);

                            pixel3x3.Sort();

                            imageNew[0, 0] = (int)((pixel3x3[1] + pixel3x3[2]) / 2);

                            pixel3x3.Clear();

                            //rigth top angle
                            pixel3x3.Add(imageOld[image.Width - 2, 0]);
                            pixel3x3.Add(imageOld[image.Width - 1, 0]);
                            pixel3x3.Add(imageOld[image.Width - 2, 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, 0] = (int)((pixel3x3[1] + pixel3x3[2]) / 2);

                            pixel3x3.Clear();

                            //lef bottom angle
                            pixel3x3.Add(imageOld[0, image.Height - 2]);
                            pixel3x3.Add(imageOld[1, image.Height - 2]);
                            pixel3x3.Add(imageOld[0, image.Height - 1]);
                            pixel3x3.Add(imageOld[1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[0, image.Height - 1] = (int)((pixel3x3[1] + pixel3x3[2]) / 2);

                            pixel3x3.Clear();

                            //rigth bottom angle
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, image.Height - 1] = (int)((pixel3x3[1] + pixel3x3[2]) / 2);

                            pixel3x3.Clear();

                            //top && bottom lines
                            for (int x = 1; x < image.Width - 1; ++x)
                            {
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);

                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);

                                pixel3x3.Sort();

                                imageNew[x, 0] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                                pixel3x3.Clear();

                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 1] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                                pixel3x3.Clear();
                            }
                            //left & right columns
                            for (int y = 1; y < image.Height - 1; ++y)
                            {
                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);

                                pixel3x3.Sort();

                                imageNew[0, y] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                                pixel3x3.Clear();

                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 1, y] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                                pixel3x3.Clear();
                            }

                            for (int x = 1; x < image.Width - 1; ++x)
                            {
                                for (int y = 1; y < image.Height - 1; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);

                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x, y + 1]);

                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[4];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                    }
                    break;
                case "3x5":
                    switch (extremePixels)
                    {
                        case "Duplication":
                            //left top angle
                            image3x5[0, 0] = imageOld[0, 0];
                            image3x5[0, 1] = imageOld[0, 0];

                            //right top angle
                            image3x5[image.Width + 1, 0] = imageOld[image.Width - 1, 0];
                            image3x5[image.Width + 1, 1] = imageOld[image.Width - 1, 0];

                            // left bottom angle
                            image3x5[0, image.Height + 2] = imageOld[0, image.Height - 1];
                            image3x5[0, image.Height + 3] = imageOld[0, image.Height - 1];

                            //right bottom angle
                            image3x5[image.Width + 1, image.Height + 2] = imageOld[image.Width - 1, image.Height - 1];
                            image3x5[image.Width + 1, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];

                            //top & bottom lines
                            for (int x = 1; x < image.Width; ++x)
                            {
                                image3x5[x, 0] = imageOld[x - 1, 0];
                                image3x5[x, 1] = imageOld[x - 1, 1];

                                image3x5[x, image.Height + 2] = imageOld[x - 1, image.Height - 1];
                                image3x5[x, image.Height + 3] = imageOld[x - 1, image.Height - 2];
                            }
                            //left & right columns
                            for (int y = 2; y < image.Height + 2; ++y)
                            {
                                image3x5[0, y] = imageOld[0, y - 2];

                                image3x5[image.Width + 1, y] = imageOld[image.Width - 1, y - 2];
                            }
                            for (int x = 1; x < image.Width + 1; ++x)
                            {
                                for (int y = 2; y < image.Height + 2; ++y)
                                {
                                    image3x5[x, y] = imageOld[x - 1, y - 2];
                                }
                            }

                            for (int x = 1; x < image.Width + 1; ++x)
                            {
                                for (int y = 2; y < image.Height + 2; ++y)
                                {
                                    pixel3x3.Add(image3x5[x - 1, y - 2]);
                                    pixel3x3.Add(image3x5[x, y - 2]);
                                    pixel3x3.Add(image3x5[x + 1, y - 2]);

                                    pixel3x3.Add(image3x5[x - 1, y - 1]);
                                    pixel3x3.Add(image3x5[x, y - 1]);
                                    pixel3x3.Add(image3x5[x + 1, y - 1]);

                                    pixel3x3.Add(image3x5[x - 1, y]);
                                    pixel3x3.Add(image3x5[x, y]);
                                    pixel3x3.Add(image3x5[x + 1, y]);

                                    pixel3x3.Add(image3x5[x - 1, y + 1]);
                                    pixel3x3.Add(image3x5[x, y + 1]);
                                    pixel3x3.Add(image3x5[x + 1, y + 1]);

                                    pixel3x3.Add(image3x5[x - 1, y - +2]);
                                    pixel3x3.Add(image3x5[x, y + 2]);
                                    pixel3x3.Add(image3x5[x + 1, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x - 1, y - 2] = pixel3x3[6];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Unchanged":
                            // 2up & 2bottom lines
                            for (int x = 0; x < image.Width; ++x)
                            {
                                imageNew[x, 0] = imageOld[x, 0];
                                imageNew[x, 1] = imageOld[x, 1];

                                imageNew[x, image.Height - 2] = imageOld[x, image.Height - 2];
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
                                for (int y = 2; y < image.Height - 2; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 2]);

                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);

                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);

                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);

                                    pixel3x3.Add(imageOld[x + 1, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[6];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Existing":
                            //lef top angle
                            pixel3x3.Add(imageOld[0, 0]);
                            pixel3x3.Add(imageOld[1, 0]);

                            pixel3x3.Add(imageOld[0, 1]);
                            pixel3x3.Add(imageOld[1, 1]);

                            pixel3x3.Add(imageOld[0, 2]);
                            pixel3x3.Add(imageOld[1, 2]);

                            pixel3x3.Sort();

                            imageNew[0, 0] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //rigth top angle
                            pixel3x3.Add(imageOld[image.Width - 2, 0]);
                            pixel3x3.Add(imageOld[image.Width - 1, 0]);

                            pixel3x3.Add(imageOld[image.Width - 2, 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, 1]);

                            pixel3x3.Add(imageOld[image.Width - 2, 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, 2]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, 0] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //lef bottom angle
                            pixel3x3.Add(imageOld[0, image.Height - 3]);
                            pixel3x3.Add(imageOld[1, image.Height - 3]);

                            pixel3x3.Add(imageOld[0, image.Height - 2]);
                            pixel3x3.Add(imageOld[1, image.Height - 2]);

                            pixel3x3.Add(imageOld[0, image.Height - 1]);
                            pixel3x3.Add(imageOld[1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[0, image.Height - 1] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //rigth bottom angle
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 3]);

                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 2]);

                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, image.Height - 1] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //2top && 2bottom lines
                            for (int x = 1; x < image.Width - 1; ++x)
                            {
                                /*0 top*/
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);

                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);

                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);

                                pixel3x3.Sort();

                                imageNew[x, 0] = pixel3x3[4];
                                /*1 top*/
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);

                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);

                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);

                                pixel3x3.Add(imageOld[x - 1, 3]);
                                pixel3x3.Add(imageOld[x, 3]);
                                pixel3x3.Add(imageOld[x + 1, 3]);

                                pixel3x3.Sort();

                                imageNew[x, 1] = (int)((pixel3x3[5] + pixel3x3[6]) / 2);

                                pixel3x3.Clear();
                                /*last-1*/
                                pixel3x3.Add(imageOld[x - 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 4]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[x, image.Height - 2] = (int)((pixel3x3[5] + pixel3x3[6]) / 2);

                                pixel3x3.Clear();
                                /*last*/
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[x, image.Height - 1] = pixel3x3[4];

                                pixel3x3.Clear();
                            }
                            //left & right columns
                            for (int y = 2; y < image.Height - 2; ++y)
                            {
                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);

                                pixel3x3.Sort();

                                imageNew[0, y] = (int)((pixel3x3[4] + pixel3x3[5]) / 2);

                                pixel3x3.Clear();

                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 1, y] = (int)((pixel3x3[4] + pixel3x3[5]) / 2);

                                pixel3x3.Clear();
                            }
                            for (int x = 1; x < image.Width - 1; ++x)
                            {
                                for (int y = 2; y < image.Height - 2; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 2]);

                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);

                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);

                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);

                                    pixel3x3.Add(imageOld[x - 1, y + 2]);
                                    pixel3x3.Add(imageOld[x, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[7];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                    }
                    break;
                case "5x3":
                    switch (extremePixels)
                    {
                        case "Duplication":
                            //left top angle
                            image5x3[0, 0] = imageOld[0, 0];
                            image5x3[1, 0] = imageOld[0, 0];

                            //right top angle
                            image5x3[image.Width + 2, 0] = imageOld[image.Width - 1, 0];
                            image5x3[image.Width + 3, 0] = imageOld[image.Width - 1, 0];

                            // left bottom angle
                            image5x3[0, image.Height + 1] = imageOld[0, image.Height - 1];
                            image5x3[1, image.Height + 1] = imageOld[0, image.Height - 1];

                            //right bottom angle
                            image5x3[image.Width + 2, image.Height + 1] = imageOld[image.Width - 1, image.Height - 1];
                            image5x3[image.Width + 3, image.Height + 1] = imageOld[image.Width - 1, image.Height - 1];

                            //top & bottom lines
                            for (int x = 2; x < image.Width + 1; ++x)
                            {
                                image5x3[x, 0] = imageOld[x - 2, 0];

                                image5x3[x, image.Height + 1] = imageOld[x - 2, image.Height - 1];
                            }
                            //2left & 2right columns
                            for (int y = 1; y < image.Height + 1; ++y)
                            {
                                image5x3[0, y] = imageOld[0, y - 1];
                                image5x3[1, y] = imageOld[1, y - 1];

                                image5x3[image.Width + 2, y] = imageOld[image.Width - 2, y - 1];
                                image5x3[image.Width + 3, y] = imageOld[image.Width - 1, y - 1];
                            }
                            for (int x = 2; x < image.Width + 2; ++x)
                            {
                                for (int y = 1; y < image.Height + 1; ++y)
                                {
                                    image5x3[x, y] = imageOld[x - 2, y - 1];
                                }
                            }

                            for (int x = 2; x < image.Width + 2; ++x)
                            {
                                for (int y = 1; y < image.Height + 1; ++y)
                                {

                                    pixel3x3.Add(image5x3[x - 2, y - 1]);
                                    pixel3x3.Add(image5x3[x - 1, y - 1]);
                                    pixel3x3.Add(image5x3[x, y - 1]);
                                    pixel3x3.Add(image5x3[x + 1, y - 1]);
                                    pixel3x3.Add(image5x3[x + 2, y - 1]);

                                    pixel3x3.Add(image5x3[x - 2, y]);
                                    pixel3x3.Add(image5x3[x - 1, y]);
                                    pixel3x3.Add(image5x3[x, y]);
                                    pixel3x3.Add(image5x3[x + 1, y]);
                                    pixel3x3.Add(image5x3[x + 2, y]);

                                    pixel3x3.Add(image5x3[x - 2, y + 1]);
                                    pixel3x3.Add(image5x3[x - 1, y + 1]);
                                    pixel3x3.Add(image5x3[x, y + 1]);
                                    pixel3x3.Add(image5x3[x + 1, y + 1]);
                                    pixel3x3.Add(image5x3[x + 2, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x - 2, y - 1] = pixel3x3[6];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Unchanged":
                            // up & bottom lines
                            for (int x = 0; x < image.Width; ++x)
                            {
                                imageNew[x, 0] = imageOld[x, 0];

                                imageNew[x, image.Height - 1] = imageOld[x, image.Height - 1];
                            }
                            //2left & 2right columns
                            for (int y = 0; y < image.Height; ++y)
                            {
                                imageNew[0, y] = imageOld[0, y];
                                imageNew[1, y] = imageOld[1, y];

                                imageNew[image.Width - 2, y] = imageOld[image.Width - 2, y];
                                imageNew[image.Width - 1, y] = imageOld[image.Width - 1, y];
                            }
                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                for (int y = 1; y < image.Height - 1; ++y)
                                {

                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);

                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 2, y]);

                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[6];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Existing":
                            //lef top angle
                            pixel3x3.Add(imageOld[0, 0]);
                            pixel3x3.Add(imageOld[1, 0]);
                            pixel3x3.Add(imageOld[2, 0]);

                            pixel3x3.Add(imageOld[0, 1]);
                            pixel3x3.Add(imageOld[1, 1]);
                            pixel3x3.Add(imageOld[2, 1]);

                            pixel3x3.Sort();

                            imageNew[0, 0] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //rigth top angle
                            pixel3x3.Add(imageOld[image.Width - 3, 0]);
                            pixel3x3.Add(imageOld[image.Width - 2, 0]);
                            pixel3x3.Add(imageOld[image.Width - 1, 0]);

                            pixel3x3.Add(imageOld[image.Width - 3, 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, 0] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //lef bottom angle
                            pixel3x3.Add(imageOld[0, image.Height - 2]);
                            pixel3x3.Add(imageOld[1, image.Height - 2]);
                            pixel3x3.Add(imageOld[2, image.Height - 2]);

                            pixel3x3.Add(imageOld[0, image.Height - 1]);
                            pixel3x3.Add(imageOld[1, image.Height - 1]);
                            pixel3x3.Add(imageOld[2, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[0, image.Height - 1] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //rigth bottom angle
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 2]);

                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, image.Height - 1] = (int)((pixel3x3[2] + pixel3x3[3]) / 2);

                            pixel3x3.Clear();

                            //top && bottom lines
                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                /* top*/
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);

                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);

                                pixel3x3.Sort();

                                imageNew[x, 0] = (int)((pixel3x3[4] + pixel3x3[5]) / 2);

                                /*last*/
                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[x, image.Height - 1] = (int)((pixel3x3[4] + pixel3x3[5]) / 2);

                                pixel3x3.Clear();
                            }
                            //2left & 2right columns
                            for (int y = 2; y < image.Height - 2; ++y)
                            {   /*0 left                                */

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);

                                pixel3x3.Sort();

                                imageNew[0, y] = pixel3x3[4];

                                pixel3x3.Clear();

                                /*1 left*/
                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);
                                pixel3x3.Add(imageOld[3, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);
                                pixel3x3.Add(imageOld[3, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);
                                pixel3x3.Add(imageOld[3, y + 1]);

                                pixel3x3.Sort();

                                imageNew[1, y] = (int)((pixel3x3[5] + pixel3x3[6]) / 2);

                                pixel3x3.Clear();
                                /*0right*/
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 1, y] = pixel3x3[4];

                                pixel3x3.Clear();
                                /*1right*/
                                pixel3x3.Add(imageOld[image.Width - 4, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 43, y]);
                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 2, y] = (int)((pixel3x3[5] + pixel3x3[6]) / 2);

                                pixel3x3.Clear();
                            }
                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                for (int y = 1; y < image.Height - 1; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);

                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 2, y]);

                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[7];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                    }
                    break;
                case "5x5":
                    switch (extremePixels)
                    {
                        case "Duplication":
                            //left top angle
                            image5x5[0, 0] = imageOld[0, 0];
                            image5x5[0, 1] = imageOld[0, 0];
                            image5x5[1, 0] = imageOld[0, 0];
                            image5x5[1, 1] = imageOld[0, 0];
                            //right top angle
                            image5x5[image.Width + 2, 0] = imageOld[image.Width - 1, 0];
                            image5x5[image.Width + 3, 0] = imageOld[image.Width - 1, 0];
                            image5x5[image.Width + 2, 1] = imageOld[image.Width - 1, 0];
                            image5x5[image.Width + 3, 1] = imageOld[image.Width - 1, 0];
                            // left bottom angle
                            image5x5[0, image.Height + 2] = imageOld[0, image.Height - 1];
                            image5x5[1, image.Height + 2] = imageOld[0, image.Height - 1];
                            image5x5[0, image.Height + 3] = imageOld[0, image.Height - 1];
                            image5x5[1, image.Height + 3] = imageOld[0, image.Height - 1];
                            //right bottom angle
                            image5x5[image.Width + 2, image.Height + 2] = imageOld[image.Width - 1, image.Height - 1];
                            image5x5[image.Width + 2, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];
                            image5x5[image.Width + 3, image.Height + 2] = imageOld[image.Width - 1, image.Height - 1];
                            image5x5[image.Width + 3, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];

                            //2top & 2bottom lines
                            for (int x = 2; x < image.Width + 2; ++x)
                            {
                                image5x5[x, 0] = imageOld[x - 2, 0];
                                image5x5[x, 1] = imageOld[x - 2, 1];

                                image5x5[x, image.Height + 2] = imageOld[x - 2, image.Height - 2];
                                image5x5[x, image.Height + 3] = imageOld[x - 2, image.Height - 1];
                            }
                            //2left & 2right columns
                            for (int y = 2; y < image.Width + 2; ++y)
                            {
                                image5x5[0, y] = imageOld[0, y - 2];
                                image5x5[1, y] = imageOld[1, y - 2];

                                image5x5[image.Width + 2, y] = imageOld[image.Width - 2, y - 2];
                                image5x5[image.Width + 3, y] = imageOld[image.Width - 1, y - 2];
                            }
                            for (int x = 2; x < image.Width + 2; ++x)
                            {
                                for (int y = 2; y < image.Height + 2; ++y)
                                {
                                    image5x5[x, y] = imageOld[x - 2, y - 2];
                                }
                            }

                            for (int x = 2; x < image.Width + 2; ++x)
                            {
                                for (int y = 2; y < image.Height + 2; ++y)
                                {
                                    pixel3x3.Add(image5x5[x - 2, y - 2]);
                                    pixel3x3.Add(image5x5[x - 1, y - 2]);
                                    pixel3x3.Add(image5x5[x, y - 2]);
                                    pixel3x3.Add(image5x5[x + 1, y - 2]);
                                    pixel3x3.Add(image5x5[x + 2, y - 2]);

                                    pixel3x3.Add(image5x5[x - 2, y - 1]);
                                    pixel3x3.Add(image5x5[x - 1, y - 1]);
                                    pixel3x3.Add(image5x5[x, y - 1]);
                                    pixel3x3.Add(image5x5[x + 1, y - 1]);
                                    pixel3x3.Add(image5x5[x + 2, y - 1]);

                                    pixel3x3.Add(image5x5[x - 2, y]);
                                    pixel3x3.Add(image5x5[x - 1, y]);
                                    pixel3x3.Add(image5x5[x, y]);
                                    pixel3x3.Add(image5x5[x + 1, y]);
                                    pixel3x3.Add(image5x5[x + 2, y]);

                                    pixel3x3.Add(image5x5[x - 2, y + 1]);
                                    pixel3x3.Add(image5x5[x - 1, y + 1]);
                                    pixel3x3.Add(image5x5[x, y + 1]);
                                    pixel3x3.Add(image5x5[x + 1, y + 1]);
                                    pixel3x3.Add(image5x5[x + 2, y + 1]);

                                    pixel3x3.Add(image5x5[x - 2, y + 2]);
                                    pixel3x3.Add(image5x5[x - 1, y + 2]);
                                    pixel3x3.Add(image5x5[x, y + 2]);
                                    pixel3x3.Add(image5x5[x + 1, y + 2]);
                                    pixel3x3.Add(image5x5[x + 2, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x - 2, y - 2] = pixel3x3[12];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Unchanged":
                            for (int x = 0; x < image.Width; ++x)
                            {
                                imageNew[x, 0] = imageOld[x, 0];
                                imageNew[x, 1] = imageOld[x, 1];

                                imageNew[x, image.Height - 2] = imageOld[x, image.Height - 2];
                                imageNew[x, image.Height - 1] = imageOld[x, image.Height - 1];
                            }
                            //left & right columns
                            for (int y = 0; y < image.Height; ++y)
                            {
                                imageNew[0, y] = imageOld[0, y];
                                imageNew[1, y] = imageOld[1, y];

                                imageNew[image.Width - 2, y] = imageOld[image.Width - 2, y];
                                imageNew[image.Width - 1, y] = imageOld[image.Width - 1, y];
                            }

                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                for (int y = 2; y < image.Height - 2; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 2, y - 2]);
                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 2]);
                                    pixel3x3.Add(imageOld[x + 2, y - 2]);

                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);

                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 2, y]);

                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);

                                    pixel3x3.Add(imageOld[x - 2, y + 2]);
                                    pixel3x3.Add(imageOld[x - 1, y + 2]);
                                    pixel3x3.Add(imageOld[x, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);
                                    pixel3x3.Add(imageOld[x + 2, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[12];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Existing":
                            //lef top angle
                            pixel3x3.Add(imageOld[0, 0]);
                            pixel3x3.Add(imageOld[1, 0]);
                            pixel3x3.Add(imageOld[2, 0]);
                            pixel3x3.Add(imageOld[0, 1]);
                            pixel3x3.Add(imageOld[1, 1]);
                            pixel3x3.Add(imageOld[2, 1]);
                            pixel3x3.Add(imageOld[0, 2]);
                            pixel3x3.Add(imageOld[1, 2]);
                            pixel3x3.Add(imageOld[2, 2]);
                            pixel3x3.Sort();

                            imageNew[0, 0] = pixel3x3[4];

                            pixel3x3.Clear();

                            //rigth top angle
                            pixel3x3.Add(imageOld[image.Width - 3, 0]);
                            pixel3x3.Add(imageOld[image.Width - 2, 0]);
                            pixel3x3.Add(imageOld[image.Width - 1, 0]);
                            pixel3x3.Add(imageOld[image.Width - 3, 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, 1]);
                            pixel3x3.Add(imageOld[image.Width - 3, 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, 2]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, 0] = pixel3x3[4];

                            pixel3x3.Clear();

                            //lef bottom angle
                            pixel3x3.Add(imageOld[0, image.Height - 3]);
                            pixel3x3.Add(imageOld[1, image.Height - 3]);
                            pixel3x3.Add(imageOld[2, image.Height - 3]);
                            pixel3x3.Add(imageOld[0, image.Height - 2]);
                            pixel3x3.Add(imageOld[1, image.Height - 2]);
                            pixel3x3.Add(imageOld[2, image.Height - 2]);
                            pixel3x3.Add(imageOld[0, image.Height - 1]);
                            pixel3x3.Add(imageOld[1, image.Height - 1]);
                            pixel3x3.Add(imageOld[2, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[0, image.Height - 1] = pixel3x3[4];

                            pixel3x3.Clear();

                            //rigth bottom angle
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, image.Height - 1] = pixel3x3[4];

                            pixel3x3.Clear();

                            //2top && 2bottom lines
                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                /*0-line*/
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);

                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);

                                pixel3x3.Add(imageOld[x - 2, 2]);
                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);
                                pixel3x3.Add(imageOld[x + 2, 2]);

                                pixel3x3.Sort();

                                imageNew[x, 0] = pixel3x3[7];

                                pixel3x3.Clear();

                                /*1-line*/
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);

                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);

                                pixel3x3.Add(imageOld[x - 2, 2]);
                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);
                                pixel3x3.Add(imageOld[x + 2, 2]);

                                pixel3x3.Add(imageOld[x - 2, 3]);
                                pixel3x3.Add(imageOld[x - 1, 3]);
                                pixel3x3.Add(imageOld[x, 3]);
                                pixel3x3.Add(imageOld[x + 1, 3]);
                                pixel3x3.Add(imageOld[x + 2, 3]);

                                pixel3x3.Sort();

                                imageNew[x, 1] = (int)((pixel3x3[9] + pixel3x3[10]) / 2);

                                pixel3x3.Clear();

                                /*last-1*/
                                pixel3x3.Add(imageOld[x - 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 4]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 2] = (int)((pixel3x3[9] + pixel3x3[10]) / 2);

                                pixel3x3.Clear();
                                /*last*/
                                pixel3x3.Add(imageOld[x - 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 1] = pixel3x3[12];

                                pixel3x3.Clear();
                            }
                            //left & right columns
                            for (int y = 2; y < image.Height - 2; ++y)
                            {
                                /*0-left*/
                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);
                                pixel3x3.Add(imageOld[2, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);
                                pixel3x3.Add(imageOld[2, y + 2]);

                                pixel3x3.Sort();

                                imageNew[0, y] = pixel3x3[7];

                                pixel3x3.Clear();

                                /*1-left*/
                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);
                                pixel3x3.Add(imageOld[2, y - 2]);
                                pixel3x3.Add(imageOld[3, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);
                                pixel3x3.Add(imageOld[3, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);
                                pixel3x3.Add(imageOld[3, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);
                                pixel3x3.Add(imageOld[3, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);
                                pixel3x3.Add(imageOld[2, y + 2]);
                                pixel3x3.Add(imageOld[3, y + 2]);

                                pixel3x3.Sort();

                                imageNew[1, y] = (int)((pixel3x3[9] + pixel3x3[10]) / 2);

                                pixel3x3.Clear();
                                /*1-right*/
                                pixel3x3.Add(imageOld[image.Width - 4, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 4, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 4, y]);
                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 2, y] = (int)((pixel3x3[9] + pixel3x3[10]) / 2);

                                pixel3x3.Clear();

                                /*0-right*/
                                pixel3x3.Add(imageOld[image.Width - 3, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 3, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 1, y] = pixel3x3[7];

                                pixel3x3.Clear();
                            }

                            for (int x = 2; x < image.Width - 2; ++x)
                            {
                                for (int y = 2; y < image.Height - 2; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 2, y - 2]);
                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 2, y + 2]);

                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 2]);

                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 2]);

                                    pixel3x3.Add(imageOld[x + 1, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);

                                    pixel3x3.Add(imageOld[x + 2, y - 2]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 2]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[12];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                    }
                    break;
                case "7x7":
                    switch (extremePixels)
                    {
                        case "Duplication":
                            //left top angle
                            // for
                            image7x7[0, 0] = imageOld[0, 0];
                            image7x7[0, 1] = imageOld[0, 0];
                            image7x7[0, 2] = imageOld[0, 0];
                            image7x7[1, 0] = imageOld[0, 0];
                            image7x7[1, 1] = imageOld[0, 0];
                            image7x7[1, 2] = imageOld[0, 0];
                            image7x7[2, 0] = imageOld[0, 0];
                            image7x7[2, 1] = imageOld[0, 0];
                            image7x7[2, 2] = imageOld[0, 0];
                            //right top angle
                            image7x7[image.Width + 3, 0] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 4, 0] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 5, 0] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 3, 1] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 4, 1] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 5, 1] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 3, 2] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 4, 2] = imageOld[image.Width - 1, 0];
                            image7x7[image.Width + 5, 2] = imageOld[image.Width - 1, 0];
                            // left bottom angle
                            image7x7[0, image.Height + 3] = imageOld[0, image.Height - 1];
                            image7x7[1, image.Height + 3] = imageOld[0, image.Height - 1];
                            image7x7[2, image.Height + 3] = imageOld[0, image.Height - 1];
                            image7x7[0, image.Height + 4] = imageOld[0, image.Height - 1];
                            image7x7[1, image.Height + 4] = imageOld[0, image.Height - 1];
                            image7x7[2, image.Height + 4] = imageOld[0, image.Height - 1];
                            image7x7[0, image.Height + 5] = imageOld[0, image.Height - 1];
                            image7x7[1, image.Height + 5] = imageOld[0, image.Height - 1];
                            image7x7[2, image.Height + 5] = imageOld[0, image.Height - 1];
                            //right bottom angle
                            image7x7[image.Width + 3, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 3, image.Height + 4] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 3, image.Height + 5] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 4, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 4, image.Height + 4] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 4, image.Height + 5] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 5, image.Height + 3] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 5, image.Height + 4] = imageOld[image.Width - 1, image.Height - 1];
                            image7x7[image.Width + 5, image.Height + 5] = imageOld[image.Width - 1, image.Height - 1];
                            //3top & 3bottom lines
                            for (int x = 3; x < image.Width + 3; ++x)
                            {
                                image7x7[x, 0] = imageOld[x - 3, 0];
                                image7x7[x, 1] = imageOld[x - 3, 1];
                                image7x7[x, 2] = imageOld[x - 3, 2];

                                image7x7[x, image.Height + 3] = imageOld[x - 3, image.Height - 3];
                                image7x7[x, image.Height + 4] = imageOld[x - 3, image.Height - 2];
                                image7x7[x, image.Height + 5] = imageOld[x - 3, image.Height - 1];
                            }
                            //3left & 3right columns
                            for (int y = 3; y < image.Width + 3; ++y)
                            {
                                image7x7[0, y] = imageOld[0, y - 3];
                                image7x7[1, y] = imageOld[1, y - 3];
                                image7x7[2, y] = imageOld[2, y - 3];

                                image7x7[image.Width + 3, y] = imageOld[image.Width - 3, y - 3];
                                image7x7[image.Width + 4, y] = imageOld[image.Width - 2, y - 3];
                                image7x7[image.Width + 5, y] = imageOld[image.Width - 1, y - 3];
                            }

                            for (int x = 3; x < image.Width + 3; ++x)
                            {
                                for (int y = 3; y < image.Height + 3; ++y)
                                {
                                    image7x7[x, y] = imageOld[x - 3, y - 3];
                                }
                            }

                            for (int x = 3; x < image.Width + 3; ++x)
                            {
                                for (int y = 3; y < image.Height + 3; ++y)
                                {
                                    pixel3x3.Add(image7x7[x - 3, y - 3]);
                                    pixel3x3.Add(image7x7[x - 2, y - 3]);
                                    pixel3x3.Add(image7x7[x - 1, y - 3]);
                                    pixel3x3.Add(image7x7[x, y - 3]);
                                    pixel3x3.Add(image7x7[x + 1, y - 3]);
                                    pixel3x3.Add(image7x7[x + 2, y - 3]);
                                    pixel3x3.Add(image7x7[x + 3, y - 3]);

                                    pixel3x3.Add(image7x7[x - 3, y - 2]);
                                    pixel3x3.Add(image7x7[x - 2, y - 2]);
                                    pixel3x3.Add(image7x7[x - 1, y - 2]);
                                    pixel3x3.Add(image7x7[x, y - 2]);
                                    pixel3x3.Add(image7x7[x + 1, y - 2]);
                                    pixel3x3.Add(image7x7[x + 2, y - 2]);
                                    pixel3x3.Add(image7x7[x + 3, y - 2]);

                                    pixel3x3.Add(image7x7[x - 3, y - 1]);
                                    pixel3x3.Add(image7x7[x - 2, y - 1]);
                                    pixel3x3.Add(image7x7[x - 1, y - 1]);
                                    pixel3x3.Add(image7x7[x, y - 1]);
                                    pixel3x3.Add(image7x7[x + 1, y - 1]);
                                    pixel3x3.Add(image7x7[x + 2, y - 1]);
                                    pixel3x3.Add(image7x7[x + 3, y - 1]);

                                    pixel3x3.Add(image7x7[x - 3, y]);
                                    pixel3x3.Add(image7x7[x - 2, y]);
                                    pixel3x3.Add(image7x7[x - 1, y]);
                                    pixel3x3.Add(image7x7[x, y]);
                                    pixel3x3.Add(image7x7[x + 1, y]);
                                    pixel3x3.Add(image7x7[x + 2, y]);
                                    pixel3x3.Add(image7x7[x + 3, y]);

                                    pixel3x3.Add(image7x7[x - 3, y + 1]);
                                    pixel3x3.Add(image7x7[x - 2, y + 1]);
                                    pixel3x3.Add(image7x7[x - 1, y + 1]);
                                    pixel3x3.Add(image7x7[x, y + 1]);
                                    pixel3x3.Add(image7x7[x + 1, y + 1]);
                                    pixel3x3.Add(image7x7[x + 2, y + 1]);
                                    pixel3x3.Add(image7x7[x + 3, y + 1]);

                                    pixel3x3.Add(image7x7[x - 3, y + 2]);
                                    pixel3x3.Add(image7x7[x - 2, y + 2]);
                                    pixel3x3.Add(image7x7[x - 1, y + 2]);
                                    pixel3x3.Add(image7x7[x, y + 2]);
                                    pixel3x3.Add(image7x7[x + 1, y + 2]);
                                    pixel3x3.Add(image7x7[x + 2, y + 2]);
                                    pixel3x3.Add(image7x7[x + 3, y + 2]);

                                    pixel3x3.Add(image7x7[x - 3, y + 3]);
                                    pixel3x3.Add(image7x7[x - 2, y + 3]);
                                    pixel3x3.Add(image7x7[x - 1, y + 3]);
                                    pixel3x3.Add(image7x7[x, y + 3]);
                                    pixel3x3.Add(image7x7[x + 1, y + 3]);
                                    pixel3x3.Add(image7x7[x + 2, y + 3]);
                                    pixel3x3.Add(image7x7[x + 3, y + 3]);

                                    pixel3x3.Sort();

                                    imageNew[x - 3, y - 3] = pixel3x3[24];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Unchanged":
                            for (int x = 0; x < image.Width; ++x)
                            {
                                imageNew[x, 0] = imageOld[x, 0];
                                imageNew[x, 1] = imageOld[x, 1];
                                imageNew[x, 2] = imageOld[x, 2];

                                imageNew[x, image.Height - 3] = imageOld[x, image.Height - 3];
                                imageNew[x, image.Height - 2] = imageOld[x, image.Height - 2];
                                imageNew[x, image.Height - 1] = imageOld[x, image.Height - 1];
                            }
                            //left & right columns
                            for (int y = 0; y < image.Height; ++y)
                            {
                                imageNew[0, y] = imageOld[0, y];
                                imageNew[1, y] = imageOld[1, y];
                                imageNew[2, y] = imageOld[2, y];

                                imageNew[image.Width - 3, y] = imageOld[image.Width - 3, y];
                                imageNew[image.Width - 2, y] = imageOld[image.Width - 2, y];
                                imageNew[image.Width - 1, y] = imageOld[image.Width - 1, y];
                            }

                            for (int x = 3; x < image.Width - 3; ++x)
                            {
                                for (int y = 3; y < image.Height - 3; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 3, y - 3]);
                                    pixel3x3.Add(imageOld[x - 2, y - 3]);
                                    pixel3x3.Add(imageOld[x - 1, y - 3]);
                                    pixel3x3.Add(imageOld[x, y - 3]);
                                    pixel3x3.Add(imageOld[x + 1, y - 3]);
                                    pixel3x3.Add(imageOld[x + 2, y - 3]);
                                    pixel3x3.Add(imageOld[x + 3, y - 3]);

                                    pixel3x3.Add(imageOld[x - 3, y - 2]);
                                    pixel3x3.Add(imageOld[x - 2, y - 2]);
                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 2]);
                                    pixel3x3.Add(imageOld[x + 2, y - 2]);
                                    pixel3x3.Add(imageOld[x + 3, y - 2]);

                                    pixel3x3.Add(imageOld[x - 3, y - 1]);
                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);
                                    pixel3x3.Add(imageOld[x + 3, y - 1]);

                                    pixel3x3.Add(imageOld[x - 3, y]);
                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 2, y]);
                                    pixel3x3.Add(imageOld[x + 3, y]);

                                    pixel3x3.Add(imageOld[x - 3, y + 1]);
                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);
                                    pixel3x3.Add(imageOld[x + 3, y + 1]);

                                    pixel3x3.Add(imageOld[x - 3, y + 2]);
                                    pixel3x3.Add(imageOld[x - 2, y + 2]);
                                    pixel3x3.Add(imageOld[x - 1, y + 2]);
                                    pixel3x3.Add(imageOld[x, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);
                                    pixel3x3.Add(imageOld[x + 2, y + 2]);
                                    pixel3x3.Add(imageOld[x + 3, y + 2]);

                                    pixel3x3.Add(imageOld[x - 3, y + 3]);
                                    pixel3x3.Add(imageOld[x - 2, y + 3]);
                                    pixel3x3.Add(imageOld[x - 1, y + 3]);
                                    pixel3x3.Add(imageOld[x, y + 3]);
                                    pixel3x3.Add(imageOld[x + 1, y + 3]);
                                    pixel3x3.Add(imageOld[x + 2, y + 3]);
                                    pixel3x3.Add(imageOld[x + 3, y + 3]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[24];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                        case "Existing":
                            //lef top angle
                            pixel3x3.Add(imageOld[0, 0]);
                            pixel3x3.Add(imageOld[1, 0]);
                            pixel3x3.Add(imageOld[2, 0]);
                            pixel3x3.Add(imageOld[3, 0]);

                            pixel3x3.Add(imageOld[0, 1]);
                            pixel3x3.Add(imageOld[1, 1]);
                            pixel3x3.Add(imageOld[2, 1]);
                            pixel3x3.Add(imageOld[3, 1]);

                            pixel3x3.Add(imageOld[0, 2]);
                            pixel3x3.Add(imageOld[1, 2]);
                            pixel3x3.Add(imageOld[2, 2]);
                            pixel3x3.Add(imageOld[3, 2]);

                            pixel3x3.Add(imageOld[0, 3]);
                            pixel3x3.Add(imageOld[1, 3]);
                            pixel3x3.Add(imageOld[2, 3]);
                            pixel3x3.Add(imageOld[3, 3]);

                            pixel3x3.Sort();

                            imageNew[0, 0] = (int)((pixel3x3[7] + pixel3x3[8]) / 2);

                            pixel3x3.Clear();

                            //rigth top angle
                            pixel3x3.Add(imageOld[image.Width - 4, 0]);
                            pixel3x3.Add(imageOld[image.Width - 3, 0]);
                            pixel3x3.Add(imageOld[image.Width - 2, 0]);
                            pixel3x3.Add(imageOld[image.Width - 1, 0]);

                            pixel3x3.Add(imageOld[image.Width - 4, 1]);
                            pixel3x3.Add(imageOld[image.Width - 3, 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, 1]);

                            pixel3x3.Add(imageOld[image.Width - 4, 2]);
                            pixel3x3.Add(imageOld[image.Width - 3, 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, 2]);

                            pixel3x3.Add(imageOld[image.Width - 4, 3]);
                            pixel3x3.Add(imageOld[image.Width - 3, 3]);
                            pixel3x3.Add(imageOld[image.Width - 2, 3]);
                            pixel3x3.Add(imageOld[image.Width - 1, 3]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, 0] = (int)((pixel3x3[7] + pixel3x3[8]) / 2);

                            pixel3x3.Clear();

                            //lef bottom angle
                            pixel3x3.Add(imageOld[0, image.Height - 4]);
                            pixel3x3.Add(imageOld[1, image.Height - 4]);
                            pixel3x3.Add(imageOld[2, image.Height - 4]);
                            pixel3x3.Add(imageOld[3, image.Height - 4]);

                            pixel3x3.Add(imageOld[0, image.Height - 3]);
                            pixel3x3.Add(imageOld[1, image.Height - 3]);
                            pixel3x3.Add(imageOld[2, image.Height - 3]);
                            pixel3x3.Add(imageOld[3, image.Height - 3]);

                            pixel3x3.Add(imageOld[0, image.Height - 2]);
                            pixel3x3.Add(imageOld[1, image.Height - 2]);
                            pixel3x3.Add(imageOld[2, image.Height - 2]);
                            pixel3x3.Add(imageOld[3, image.Height - 2]);

                            pixel3x3.Add(imageOld[0, image.Height - 1]);
                            pixel3x3.Add(imageOld[1, image.Height - 1]);
                            pixel3x3.Add(imageOld[2, image.Height - 1]);
                            pixel3x3.Add(imageOld[3, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[0, image.Height - 1] = (int)((pixel3x3[7] + pixel3x3[8]) / 2);

                            pixel3x3.Clear();

                            //rigth bottom angle
                            pixel3x3.Add(imageOld[image.Width - 4, image.Height - 4]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 4]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 4]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 4]);

                            pixel3x3.Add(imageOld[image.Width - 4, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 3]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 3]);

                            pixel3x3.Add(imageOld[image.Width - 4, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 2]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 2]);

                            pixel3x3.Add(imageOld[image.Width - 4, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 3, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 2, image.Height - 1]);
                            pixel3x3.Add(imageOld[image.Width - 1, image.Height - 1]);

                            pixel3x3.Sort();

                            imageNew[image.Width - 1, image.Height - 1] = (int)((pixel3x3[7] + pixel3x3[8]) / 2);

                            pixel3x3.Clear();

                            //3top && 3bottom lines
                            for (int x = 3; x < image.Width - 3; ++x)
                            {
                                /*0-line*/
                                pixel3x3.Add(imageOld[x - 3, 0]);
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);
                                pixel3x3.Add(imageOld[x + 3, 0]);

                                pixel3x3.Add(imageOld[x - 3, 1]);
                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);
                                pixel3x3.Add(imageOld[x + 3, 1]);

                                pixel3x3.Add(imageOld[x - 3, 2]);
                                pixel3x3.Add(imageOld[x - 2, 2]);
                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);
                                pixel3x3.Add(imageOld[x + 2, 2]);
                                pixel3x3.Add(imageOld[x + 3, 2]);

                                pixel3x3.Add(imageOld[x - 3, 3]);
                                pixel3x3.Add(imageOld[x - 2, 3]);
                                pixel3x3.Add(imageOld[x - 1, 3]);
                                pixel3x3.Add(imageOld[x, 3]);
                                pixel3x3.Add(imageOld[x + 1, 3]);
                                pixel3x3.Add(imageOld[x + 2, 3]);
                                pixel3x3.Add(imageOld[x + 3, 3]);

                                pixel3x3.Sort();

                                imageNew[x, 0] = (int)((pixel3x3[13] + pixel3x3[14]) / 2);

                                pixel3x3.Clear();

                                /*1-line*/
                                pixel3x3.Add(imageOld[x - 3, 0]);
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);
                                pixel3x3.Add(imageOld[x + 3, 0]);

                                pixel3x3.Add(imageOld[x - 3, 1]);
                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);
                                pixel3x3.Add(imageOld[x + 3, 1]);

                                pixel3x3.Add(imageOld[x - 3, 2]);
                                pixel3x3.Add(imageOld[x - 2, 2]);
                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);
                                pixel3x3.Add(imageOld[x + 2, 2]);
                                pixel3x3.Add(imageOld[x + 3, 2]);

                                pixel3x3.Add(imageOld[x - 3, 3]);
                                pixel3x3.Add(imageOld[x - 2, 3]);
                                pixel3x3.Add(imageOld[x - 1, 3]);
                                pixel3x3.Add(imageOld[x, 3]);
                                pixel3x3.Add(imageOld[x + 1, 3]);
                                pixel3x3.Add(imageOld[x + 2, 3]);
                                pixel3x3.Add(imageOld[x + 3, 3]);

                                pixel3x3.Add(imageOld[x - 3, 4]);
                                pixel3x3.Add(imageOld[x - 2, 4]);
                                pixel3x3.Add(imageOld[x - 1, 4]);
                                pixel3x3.Add(imageOld[x, 4]);
                                pixel3x3.Add(imageOld[x + 1, 4]);
                                pixel3x3.Add(imageOld[x + 2, 4]);
                                pixel3x3.Add(imageOld[x + 3, 4]);

                                pixel3x3.Sort();

                                imageNew[x, 1] = pixel3x3[17];

                                pixel3x3.Clear();

                                /*2-line*/
                                pixel3x3.Add(imageOld[x - 3, 0]);
                                pixel3x3.Add(imageOld[x - 2, 0]);
                                pixel3x3.Add(imageOld[x - 1, 0]);
                                pixel3x3.Add(imageOld[x, 0]);
                                pixel3x3.Add(imageOld[x + 1, 0]);
                                pixel3x3.Add(imageOld[x + 2, 0]);
                                pixel3x3.Add(imageOld[x + 3, 0]);

                                pixel3x3.Add(imageOld[x - 3, 1]);
                                pixel3x3.Add(imageOld[x - 2, 1]);
                                pixel3x3.Add(imageOld[x - 1, 1]);
                                pixel3x3.Add(imageOld[x, 1]);
                                pixel3x3.Add(imageOld[x + 1, 1]);
                                pixel3x3.Add(imageOld[x + 2, 1]);
                                pixel3x3.Add(imageOld[x + 3, 1]);

                                pixel3x3.Add(imageOld[x - 3, 2]);
                                pixel3x3.Add(imageOld[x - 2, 2]);
                                pixel3x3.Add(imageOld[x - 1, 2]);
                                pixel3x3.Add(imageOld[x, 2]);
                                pixel3x3.Add(imageOld[x + 1, 2]);
                                pixel3x3.Add(imageOld[x + 2, 2]);
                                pixel3x3.Add(imageOld[x + 3, 2]);

                                pixel3x3.Add(imageOld[x - 3, 3]);
                                pixel3x3.Add(imageOld[x - 2, 3]);
                                pixel3x3.Add(imageOld[x - 1, 3]);
                                pixel3x3.Add(imageOld[x, 3]);
                                pixel3x3.Add(imageOld[x + 1, 3]);
                                pixel3x3.Add(imageOld[x + 2, 3]);
                                pixel3x3.Add(imageOld[x + 3, 3]);

                                pixel3x3.Add(imageOld[x - 3, 4]);
                                pixel3x3.Add(imageOld[x - 2, 4]);
                                pixel3x3.Add(imageOld[x - 1, 4]);
                                pixel3x3.Add(imageOld[x, 4]);
                                pixel3x3.Add(imageOld[x + 1, 4]);
                                pixel3x3.Add(imageOld[x + 2, 4]);
                                pixel3x3.Add(imageOld[x + 3, 4]);

                                pixel3x3.Add(imageOld[x - 3, 5]);
                                pixel3x3.Add(imageOld[x - 2, 5]);
                                pixel3x3.Add(imageOld[x - 1, 5]);
                                pixel3x3.Add(imageOld[x, 5]);
                                pixel3x3.Add(imageOld[x + 1, 5]);
                                pixel3x3.Add(imageOld[x + 2, 5]);
                                pixel3x3.Add(imageOld[x + 3, 5]);

                                pixel3x3.Sort();

                                imageNew[x, 2] = (int)((pixel3x3[20] + pixel3x3[21]) / 2);

                                pixel3x3.Clear();

                                /*las-2*/
                                pixel3x3.Add(imageOld[x - 3, image.Height - 6]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 6]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 6]);
                                pixel3x3.Add(imageOld[x, image.Height - 6]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 6]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 6]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 6]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 5]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 5]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 5]);
                                pixel3x3.Add(imageOld[x, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 5]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 4]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 3] = (int)((pixel3x3[20] + pixel3x3[21]) / 2);

                                pixel3x3.Clear();

                                /*last-1*/
                                pixel3x3.Add(imageOld[x - 3, image.Height - 5]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 5]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 5]);
                                pixel3x3.Add(imageOld[x, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 5]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 5]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 4]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 2] = pixel3x3[17];

                                pixel3x3.Clear();
                                /*last*/
                                pixel3x3.Add(imageOld[x - 3, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 4]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 4]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 3]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 3]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 2]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 2]);

                                pixel3x3.Add(imageOld[x - 3, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x - 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 1, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 2, image.Height - 1]);
                                pixel3x3.Add(imageOld[x + 3, image.Height - 1]);

                                pixel3x3.Sort();

                                imageNew[0, image.Height - 1] = (int)((pixel3x3[13] + pixel3x3[14]) / 2);

                                pixel3x3.Clear();
                            }
                            //3left & right 3columns
                            for (int y = 3; y < image.Height - 3; ++y)
                            {
                                /*0-left*/
                                pixel3x3.Add(imageOld[0, y - 3]);
                                pixel3x3.Add(imageOld[1, y - 3]);
                                pixel3x3.Add(imageOld[2, y - 3]);
                                pixel3x3.Add(imageOld[3, y - 3]);

                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);
                                pixel3x3.Add(imageOld[2, y - 2]);
                                pixel3x3.Add(imageOld[3, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);
                                pixel3x3.Add(imageOld[3, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);
                                pixel3x3.Add(imageOld[3, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);
                                pixel3x3.Add(imageOld[3, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);
                                pixel3x3.Add(imageOld[2, y + 2]);
                                pixel3x3.Add(imageOld[3, y + 2]);

                                pixel3x3.Add(imageOld[0, y + 3]);
                                pixel3x3.Add(imageOld[1, y + 3]);
                                pixel3x3.Add(imageOld[2, y + 3]);
                                pixel3x3.Add(imageOld[3, y + 3]);

                                pixel3x3.Sort();

                                imageNew[0, y] = (int)((pixel3x3[13] + pixel3x3[14]) / 2);

                                pixel3x3.Clear();

                                /*1-left*/
                                pixel3x3.Add(imageOld[0, y - 3]);
                                pixel3x3.Add(imageOld[1, y - 3]);
                                pixel3x3.Add(imageOld[2, y - 3]);
                                pixel3x3.Add(imageOld[3, y - 3]);
                                pixel3x3.Add(imageOld[4, y - 3]);

                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);
                                pixel3x3.Add(imageOld[2, y - 2]);
                                pixel3x3.Add(imageOld[3, y - 2]);
                                pixel3x3.Add(imageOld[4, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);
                                pixel3x3.Add(imageOld[3, y - 1]);
                                pixel3x3.Add(imageOld[4, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);
                                pixel3x3.Add(imageOld[3, y]);
                                pixel3x3.Add(imageOld[4, y]);


                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);
                                pixel3x3.Add(imageOld[3, y + 1]);
                                pixel3x3.Add(imageOld[4, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);
                                pixel3x3.Add(imageOld[2, y + 2]);
                                pixel3x3.Add(imageOld[3, y + 2]);
                                pixel3x3.Add(imageOld[4, y + 2]);

                                pixel3x3.Add(imageOld[0, y + 3]);
                                pixel3x3.Add(imageOld[1, y + 3]);
                                pixel3x3.Add(imageOld[2, y + 3]);
                                pixel3x3.Add(imageOld[3, y + 3]);
                                pixel3x3.Add(imageOld[4, y + 3]);

                                pixel3x3.Sort();

                                imageNew[1, y] = pixel3x3[17];

                                pixel3x3.Clear();

                                /*2-left*/
                                pixel3x3.Add(imageOld[0, y - 3]);
                                pixel3x3.Add(imageOld[1, y - 3]);
                                pixel3x3.Add(imageOld[2, y - 3]);
                                pixel3x3.Add(imageOld[3, y - 3]);
                                pixel3x3.Add(imageOld[4, y - 3]);
                                pixel3x3.Add(imageOld[5, y - 3]);

                                pixel3x3.Add(imageOld[0, y - 2]);
                                pixel3x3.Add(imageOld[1, y - 2]);
                                pixel3x3.Add(imageOld[2, y - 2]);
                                pixel3x3.Add(imageOld[3, y - 2]);
                                pixel3x3.Add(imageOld[4, y - 2]);
                                pixel3x3.Add(imageOld[5, y - 2]);

                                pixel3x3.Add(imageOld[0, y - 1]);
                                pixel3x3.Add(imageOld[1, y - 1]);
                                pixel3x3.Add(imageOld[2, y - 1]);
                                pixel3x3.Add(imageOld[3, y - 1]);
                                pixel3x3.Add(imageOld[4, y - 1]);
                                pixel3x3.Add(imageOld[5, y - 1]);

                                pixel3x3.Add(imageOld[0, y]);
                                pixel3x3.Add(imageOld[1, y]);
                                pixel3x3.Add(imageOld[2, y]);
                                pixel3x3.Add(imageOld[3, y]);
                                pixel3x3.Add(imageOld[4, y]);
                                pixel3x3.Add(imageOld[5, y]);

                                pixel3x3.Add(imageOld[0, y + 1]);
                                pixel3x3.Add(imageOld[1, y + 1]);
                                pixel3x3.Add(imageOld[2, y + 1]);
                                pixel3x3.Add(imageOld[3, y + 1]);
                                pixel3x3.Add(imageOld[4, y + 1]);
                                pixel3x3.Add(imageOld[5, y + 1]);

                                pixel3x3.Add(imageOld[0, y + 2]);
                                pixel3x3.Add(imageOld[1, y + 2]);
                                pixel3x3.Add(imageOld[2, y + 2]);
                                pixel3x3.Add(imageOld[3, y + 2]);
                                pixel3x3.Add(imageOld[4, y + 2]);
                                pixel3x3.Add(imageOld[5, y + 2]);

                                pixel3x3.Add(imageOld[0, y + 3]);
                                pixel3x3.Add(imageOld[1, y + 3]);
                                pixel3x3.Add(imageOld[2, y + 3]);
                                pixel3x3.Add(imageOld[3, y + 3]);
                                pixel3x3.Add(imageOld[4, y + 3]);
                                pixel3x3.Add(imageOld[5, y + 3]);

                                pixel3x3.Sort();

                                imageNew[2, y] = (int)((pixel3x3[20] + pixel3x3[21]) / 2);

                                pixel3x3.Clear();

                                /*2-right*/
                                pixel3x3.Add(imageOld[image.Width - 6, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 5, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 3]);

                                pixel3x3.Add(imageOld[image.Width - 6, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 5, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 6, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 5, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 6, y]);
                                pixel3x3.Add(imageOld[image.Width - 5, y]);
                                pixel3x3.Add(imageOld[image.Width - 4, y]);
                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 6, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 5, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 6, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 5, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Add(imageOld[image.Width - 6, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 5, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 3]);

                                pixel3x3.Sort();

                                imageNew[image.Width -3, y] = (int)((pixel3x3[20] + pixel3x3[21]) / 2);

                                pixel3x3.Clear();

                                /*1-right*/
                                pixel3x3.Add(imageOld[image.Width - 5, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 3]);

                                pixel3x3.Add(imageOld[image.Width - 5, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 5, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 4, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 5, y]);
                                pixel3x3.Add(imageOld[image.Width - 4, y]);
                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 5, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 5, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Add(imageOld[image.Width - 5, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 4, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 3]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 2, y] = pixel3x3[17];

                                pixel3x3.Clear();

                                /*0-right*/
                                pixel3x3.Add(imageOld[image.Width - 4, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 3]);

                                pixel3x3.Add(imageOld[image.Width - 4, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 2]);

                                pixel3x3.Add(imageOld[image.Width - 4, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y - 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y - 1]);

                                pixel3x3.Add(imageOld[image.Width - 4, y]);
                                pixel3x3.Add(imageOld[image.Width - 3, y]);
                                pixel3x3.Add(imageOld[image.Width - 2, y]);
                                pixel3x3.Add(imageOld[image.Width - 1, y]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 1]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 1]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 2]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 2]);

                                pixel3x3.Add(imageOld[image.Width - 4, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 3, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 2, y + 3]);
                                pixel3x3.Add(imageOld[image.Width - 1, y + 3]);

                                pixel3x3.Sort();

                                imageNew[image.Width - 1, y] = (int)((pixel3x3[13] + pixel3x3[14]) / 2);

                                pixel3x3.Clear();
                            }

                            for (int x = 3; x < image.Width -3; ++x)
                            {
                                for (int y = 3; y < image.Height - 3; ++y)
                                {
                                    pixel3x3.Add(imageOld[x - 3, y - 3]);
                                    pixel3x3.Add(imageOld[x - 3, y - 2]);
                                    pixel3x3.Add(imageOld[x - 3, y - 1]);
                                    pixel3x3.Add(imageOld[x - 3, y]);
                                    pixel3x3.Add(imageOld[x - 3, y + 1]);
                                    pixel3x3.Add(imageOld[x - 3, y + 2]);
                                    pixel3x3.Add(imageOld[x - 3, y + 3]);

                                    pixel3x3.Add(imageOld[x - 2, y - 3]);
                                    pixel3x3.Add(imageOld[x - 2, y - 2]);
                                    pixel3x3.Add(imageOld[x - 2, y - 1]);
                                    pixel3x3.Add(imageOld[x - 2, y]);
                                    pixel3x3.Add(imageOld[x - 2, y + 1]);
                                    pixel3x3.Add(imageOld[x - 2, y + 2]);
                                    pixel3x3.Add(imageOld[x - 2, y + 3]);

                                    pixel3x3.Add(imageOld[x - 1, y - 3]);
                                    pixel3x3.Add(imageOld[x - 1, y - 2]);
                                    pixel3x3.Add(imageOld[x - 1, y - 1]);
                                    pixel3x3.Add(imageOld[x - 1, y]);
                                    pixel3x3.Add(imageOld[x - 1, y + 1]);
                                    pixel3x3.Add(imageOld[x - 1, y + 2]);
                                    pixel3x3.Add(imageOld[x - 1, y + 3]);

                                    pixel3x3.Add(imageOld[x, y - 3]);
                                    pixel3x3.Add(imageOld[x, y - 2]);
                                    pixel3x3.Add(imageOld[x, y - 1]);
                                    pixel3x3.Add(imageOld[x, y]);
                                    pixel3x3.Add(imageOld[x, y + 1]);
                                    pixel3x3.Add(imageOld[x, y + 2]);
                                    pixel3x3.Add(imageOld[x, y + 3]);

                                    pixel3x3.Add(imageOld[x + 1, y - 3]);
                                    pixel3x3.Add(imageOld[x + 1, y - 2]);
                                    pixel3x3.Add(imageOld[x + 1, y - 1]);
                                    pixel3x3.Add(imageOld[x + 1, y]);
                                    pixel3x3.Add(imageOld[x + 1, y + 1]);
                                    pixel3x3.Add(imageOld[x + 1, y + 2]);
                                    pixel3x3.Add(imageOld[x + 1, y + 3]);

                                    pixel3x3.Add(imageOld[x + 2, y -3]);
                                    pixel3x3.Add(imageOld[x + 2, y - 2]);
                                    pixel3x3.Add(imageOld[x + 2, y - 1]);
                                    pixel3x3.Add(imageOld[x + 2, y]);
                                    pixel3x3.Add(imageOld[x + 2, y + 1]);
                                    pixel3x3.Add(imageOld[x + 2, y + 2]);
                                    pixel3x3.Add(imageOld[x + 2, y + 3]);

                                    pixel3x3.Add(imageOld[x + 3, y - 3]);
                                    pixel3x3.Add(imageOld[x + 3, y - 2]);
                                    pixel3x3.Add(imageOld[x + 3, y - 1]);
                                    pixel3x3.Add(imageOld[x + 3, y]);
                                    pixel3x3.Add(imageOld[x + 3, y + 1]);
                                    pixel3x3.Add(imageOld[x + 3, y + 2]);
                                    pixel3x3.Add(imageOld[x + 3, y + 3]);

                                    pixel3x3.Sort();

                                    imageNew[x, y] = pixel3x3[24];

                                    pixel3x3.Clear();
                                }
                            }
                            break;
                    }
                    break;
            }
            return imageNew;
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
        public static int[,] UniversalPointOperations(Bitmap bmp, string extremePixels, string methodScaling, int[] mask)
        {
            return scalingMethod(exstremeMethod(bmp, extremePixels, mask), methodScaling);
        }

        public static int[,] UniversalMedianOperation(Bitmap bmp, string extremePixels, string maskSize)
        {
            return medianExtreme(bmp, extremePixels, maskSize);
        }
    }
}