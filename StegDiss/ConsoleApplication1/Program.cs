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
                bool validIn = false;
                int chosen = 0;
                while (validIn == false)
                {
                    Console.WriteLine("Please Select an embedding type\n1.LSB Original\n2.LSB Enhanced");
                    string choice = Console.ReadLine();
                    switch(choice)
                    {
                        case "1":
                            chosen = 1;
                            validIn = true;
                            break;
                        case "2":
                            chosen = 2;
                            validIn = true;
                            break;
                        default:
                            break;
                        
                    }
                }
                if (chosen == 1)
                {
                    filepath = filepath.Remove(filepath.Length - 4, 4) + "LSBE.bmp";
                    currImg = LSBE.encode("hellomate", currImg);
                }
                if (chosen == 2)
                {
                    filepath = filepath.Remove(filepath.Length - 4, 4) + "LSBO.bmp";
                    currImg = LSB.encode("hellomate", currImg);
                }

                currImg.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);

            }
            catch(System.IndexOutOfRangeException e)
            {
                Console.WriteLine("You did not provide the correct input arguments, The correct Syntax is [Method] [Image file]");
            }
        }
    }
}
