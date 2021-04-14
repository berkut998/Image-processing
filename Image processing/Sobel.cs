using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing
{
    class Sobel
    {
        public static int totalProgress;
        public static int currentProgress;

        public static Bitmap SobelEdgeDetection(Bitmap inputImage)
        {
                Bitmap outPutImage = inputImage;
                int width = inputImage.Width;
                int height = inputImage.Height;
            totalProgress = inputImage.Width * inputImage.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
                int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

                int[,] allPixR = new int[width, height];
                int[,] allPixG = new int[width, height];
                int[,] allPixB = new int[width, height];

                int limit = 128 * 128;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        allPixR[i, j] = inputImage.GetPixel(i, j).R;
                        allPixG[i, j] = inputImage.GetPixel(i, j).G;
                        allPixB[i, j] = inputImage.GetPixel(i, j).B;
                    }
                }

                int new_rx = 0, new_ry = 0;
                int new_gx = 0, new_gy = 0;
                int new_bx = 0, new_by = 0;
                int rc, gc, bc;
                for (int i = 1; i < inputImage.Width - 1; i++)
                {
                    for (int j = 1; j < inputImage.Height - 1; j++)
                    {

                        new_rx = 0;
                        new_ry = 0;
                        new_gx = 0;
                        new_gy = 0;
                        new_bx = 0;
                        new_by = 0;
                        rc = 0;
                        gc = 0;
                        bc = 0;

                        for (int wi = -1; wi < 2; wi++)
                        {
                            for (int hw = -1; hw < 2; hw++)
                            {
                                rc = allPixR[i + hw, j + wi];
                                new_rx += gx[wi + 1, hw + 1] * rc;
                                new_ry += gy[wi + 1, hw + 1] * rc;

                                gc = allPixG[i + hw, j + wi];
                                new_gx += gx[wi + 1, hw + 1] * gc;
                                new_gy += gy[wi + 1, hw + 1] * gc;

                                bc = allPixB[i + hw, j + wi];
                                new_bx += gx[wi + 1, hw + 1] * bc;
                                new_by += gy[wi + 1, hw + 1] * bc;
                            }
                        }
                        if (new_rx * new_rx + new_ry * new_ry > limit || new_gx * new_gx + new_gy * new_gy > limit || new_bx * new_bx + new_by * new_by > limit)
                            outPutImage.SetPixel(i, j, Color.Black);
                        //outPutImage.SetPixel (i, j, Color.FromArgb(allPixR[i,j],allPixG[i,j],allPixB[i,j]));
                        else
                            outPutImage.SetPixel(i, j, Color.White);
                    currentProgress++;
                    }
                }
            currentProgress = 0;
            return outPutImage;
            
        }
    }
}
