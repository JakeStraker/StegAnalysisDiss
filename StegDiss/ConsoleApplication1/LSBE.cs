using System;
using System.Text;
using System.Drawing;

namespace StegDiss
{
    class LSBE
    {
        public static Bitmap encode(String text, Bitmap image)
        {
            int imWidth = 0, imHeight = 0, bitCount = 0, textCount = 0;
            int count = 0, asciiVal = 0, charcounter = 0;
            imWidth = image.Width;
            imHeight = image.Height;
            asciiVal = text[charcounter++];
            for (int y = 0; y < imHeight; y++)
            {
                // pass through each column
                for (int x = 0; x < imWidth - 1; x += 2)
                {   // Each pixel will contain multiple colours, so we need an object (a colour in this case) to manipulate
                    //MixedColours will hold the values of pixel currently being used
                    Color pixel = image.GetPixel(x, y);
                    Color pixel2 = image.GetPixel(x + 1, y);
                    int[] yn = new int[6];
                    int[] xn = new int[6];
                    int[] bn = new int[6];
                    xn[1] = pixel.R;
                    xn[2] = pixel.G;
                    xn[3] = pixel.B;
                    xn[4] = pixel2.R;
                    xn[5] = pixel2.G;
                    xn[6] = pixel2.B;
                    for (int k = 0; k < 6; k++)
                    {
                        nextCharbit(ref asciiVal, ref bitCount, text, charcounter);
                        bn[k] = asciiVal % 2;
                        yn[k] = xn[k];
                    }
                    for (int k = 1; k < 6; k += 2)
                    {
                        if ((xn[k] % 2) == bn[k] && (xn[k + 1] % 2) == bn[k + 1])
                        {
                            if (((xn[k] / 2) % 2) == 0)
                            {
                                yn[k] = (yn[k] - (yn[k] % 2)) + invertBit(bn[k]);
                            }
                            else
                            {
                                yn[k + 1] = (yn[k + 1] - (yn[k + 1] % 2)) + invertBit(bn[k + 1]);
                            }
                        }
                        else if ((xn[k] % 2) != bn[k] && (xn[k + 1] % 2 != bn[k + 1]))
                        {
                            if (((xn[k] / 2) % 2) == 0)
                            {
                                yn[k + 1] = (yn[k + 1] - (yn[k + 1] % 2)) + invertBit(bn[k + 1]);
                            }
                            else
                            {
                                yn[k] = (yn[k] - (yn[k] % 2)) + invertBit(bn[k]);
                            }
                        }
                        else if ((xn[k] % 2) == bn[k] && (xn[k + 1] % 2) != bn[k + 1])
                        {
                            int temp = yn[k] % 2;
                            if ((yn[k] / 2) % 2 != 1)
                            {
                                yn[k] = (2 * ((yn[k] / 2) + 1)) + temp;
                            }
                        }
                        else if ((xn[k] % 2) != bn[k] && (xn[k + 1] % 2) == bn[k + 1])
                        {
                            int temp = yn[k] % 2;
                            if ((yn[k] / 2) % 2 == 1)
                            {
                                yn[k] = (2 * ((yn[k] / 2) - 1)) + temp;
                            }
                        }
                        }
                    image.SetPixel(x, y, Color.FromArgb(yn[1], yn[2], yn[3]));
                    image.SetPixel(x + 1, y, Color.FromArgb(yn[3], yn[4], yn[6]));
                }

                }
                return image;
            }
        
        public static void nextCharbit(ref int ascii, ref int bitC, string tx, int charcount)
        {
            if (bitC < 8)
            {
                ascii = ascii / 2;
                bitC++;
            }
            else
            {
                ascii = tx[charcount++];
                bitC = 0;
            }
        }
       static int invertBit(int b)
        {
            if (b == 1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
