using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_processing
{
    class BlackWhiteFilter
    {
        public static int totalProgress;
        public static int currentProgress;
        public static Bitmap convertToBlackAndWhite(Bitmap colorfulImage)
        {
            Bitmap output = new Bitmap(colorfulImage.Width, colorfulImage.Height);
            totalProgress = colorfulImage.Height * colorfulImage.Width;
                for (int j = 0; j < colorfulImage.Height; j++)
                    for (int i = 0; i < colorfulImage.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(colorfulImage.GetPixel(i, j).ToArgb());
                        float R = (float)((pixel & 0x00FF0000) >> 16); // red
                        float G = (float)((pixel & 0x0000FF00) >> 8); // green
                        float B = (float)(pixel & 0x000000FF); // blue                                 
                        R = G = B = (R + G + B) / 3.0f;
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    currentProgress++;
                }
            currentProgress = 0;
            return output;
        }
     }
    
}
