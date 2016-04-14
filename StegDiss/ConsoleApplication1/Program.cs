using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace StegDiss
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // Set filter options and filter index.
                openFileDialog1.Filter = "Bitmap Pictures (.bmp)|*.bmp";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.ShowDialog();
                string filepath = openFileDialog1.FileName;
                FileStream fs = new FileStream(filepath, FileMode.Open);
                Bitmap currImg = (Bitmap)Image.FromStream(fs);
                fs.Close();
                filepath = filepath.Remove(filepath.Length - 4, 4) + "LSBE.bmp";
                currImg = LSBE.encode("hellomate", currImg);
                currImg.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);

            }
            catch(System.IndexOutOfRangeException e)
            {
                Console.WriteLine("You did not provide the correct input arguments, The correct Syntax is [Method] [Image file]");
            }
        }
    }
}
