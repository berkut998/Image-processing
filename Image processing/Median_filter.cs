using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing
{
    class Median_filter
    {
        public static int totalProgress;
        public static int currentProgress;
        public static Bitmap MediaFilter(Bitmap inputImage, int sizeMatrix)
        {
            totalProgress = inputImage.Width * inputImage.Height;
            int quadroMatrixSize = Convert.ToInt32(Math.Pow(sizeMatrix + sizeMatrix, 2));
            Bitmap output = new Bitmap(inputImage.Width, inputImage.Height);
                for (int x = sizeMatrix; x < inputImage.Width - sizeMatrix; x++)
                    for (int y = sizeMatrix; y < inputImage.Height - sizeMatrix; y++)
                    {
                        Color[] Pixel = new Color[quadroMatrixSize];
                        int[] RedChanelArray = new int[quadroMatrixSize];
                        int[] BlueChanelArray = new int[quadroMatrixSize];
                        int[] GreenChanelArray = new int[quadroMatrixSize];
                        int count = 0;
                        for (int i = x - sizeMatrix; i < x + sizeMatrix; i++)
                        {

                            for (int j = y - sizeMatrix; j < y + sizeMatrix; j++)
                            {
                                Pixel[count] = inputImage.GetPixel(i, j);
                                RedChanelArray[count] = inputImage.GetPixel(i, j).R;
                                BlueChanelArray[count] = inputImage.GetPixel(i, j).G;
                                GreenChanelArray[count] = inputImage.GetPixel(i, j).B;
                                count++;
                            }
                        }
                        Array.Sort(RedChanelArray);
                        Array.Sort(BlueChanelArray);
                        Array.Sort(GreenChanelArray);
                        int redChanel = RedChanelArray[quadroMatrixSize / 2];
                        int greenChanel = BlueChanelArray[quadroMatrixSize / 2];
                        int blueChanel = GreenChanelArray[quadroMatrixSize / 2];
                        Color colorOutputPixel = Color.FromArgb(redChanel, greenChanel, blueChanel);
                        output.SetPixel(x, y, colorOutputPixel);
                        currentProgress++;
    }
            currentProgress = 0;
            return output;
        }
    }
}
