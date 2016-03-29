using System;
using System.Text;
using System.Drawing;

namespace StegDiss
{
    class PVD
    {
        public static Bitmap Encode(Image img, String cText)
        {
            return (Bitmap) img;
        }
        public static Bitmap Decode(Image img, String cText)
        {
            return (Bitmap)img;
        }
    }
}
