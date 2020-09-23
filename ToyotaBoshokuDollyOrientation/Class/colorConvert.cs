using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ToyotaBoshokuDollyOrientation
{
    class colorConvert
    {

        public Bitmap resimCevir(Bitmap image,string modelKodu)
        {
            Bitmap bmp=null ;

            int x, y;

            for ( x= 0; x < image.Width; x++)
            {

                for ( y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
             
                    if (pixelColor.ToArgb()==Color.White.ToArgb()&&modelKodu!="290B")
                    {
                        Color newColor = Color.PowderBlue;
                        image.SetPixel(x, y, newColor);
                        bmp = image;
                    }
                    else if (pixelColor.ToArgb() == Color.Black.ToArgb() && modelKodu == "290B")
                    {
                        Color newColor = Color.PowderBlue;
                        image.SetPixel(x, y, newColor);
                        bmp = image;
                    }

                }
            }

            return bmp;

        }

        public Bitmap resimCevir(Bitmap image)
        {
            Bitmap bmp = null;

            int x, y;

            for (x = 0; x < image.Width; x++)
            {

                for (y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    if (pixelColor.ToArgb() == Color.White.ToArgb() )
                    {
                        Color newColor = Color.PowderBlue;
                        image.SetPixel(x, y, newColor);
                        bmp = image;
                    }
                  

                }
            }

            return bmp;

        }
    }
}
