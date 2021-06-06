using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;

namespace Plugin
{
    [Version(1,0)]
    public class MatrixPlugin : IPlugin
    {
        public string Name => "Матричный медианный фильтр";

        public string Author => "Вадим Максимов";

        public void Transform(System.Drawing.Bitmap bitmap)
        {
            if (bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            System.Drawing.Bitmap dopBitmap = (System.Drawing.Bitmap)bitmap.Clone();

            for(int i=1; i< bitmap.Width-2; i++)
                for (int j=1; j<bitmap.Height-2; j++)
                {
                    int[] pixelsRed = new int[9],
                        pixelsGreen = new int[9],
                        pixelsBlue = new int[9];
                    for (int k=i-1, pos=0; k<=i+1; k++)
                        for(int z=j-1; z<=j+1; z++, pos++)
                        {
                            var color = dopBitmap.GetPixel(k, z);
                            pixelsRed[pos] = color.R;
                            pixelsBlue[pos] = color.B;
                            pixelsGreen[pos] = color.G;
                        }

                    Array.Sort(pixelsRed);
                    Array.Sort(pixelsGreen);
                    Array.Sort(pixelsBlue);

                    bitmap.SetPixel(i, j, System.Drawing.Color.FromArgb(pixelsRed[4], pixelsGreen[4], pixelsBlue[4]));
                }
        }
    }
}
