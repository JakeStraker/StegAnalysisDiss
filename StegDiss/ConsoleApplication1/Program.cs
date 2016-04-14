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
                string data = "";
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
                Console.WriteLine("Please input text to be embedded or leave blank to load from file");
                data = Console.ReadLine();
                if (data == "")
                {
                    OpenFileDialog openFileDialog2 = new OpenFileDialog();
                    openFileDialog2.Filter = "Text Files (.txt)|*.txt";
                    openFileDialog2.FilterIndex = 1;
                    openFileDialog2.ShowDialog();
                    string txtpath = openFileDialog1.FileName;
                    StreamReader sr = new StreamReader(txtpath);
                    data = sr.ReadToEnd();
                }

                if (chosen == 2)
                {
                    filepath = filepath.Remove(filepath.Length - 4, 4) + "LSBE.bmp";
                    currImg = LSBE.encode(data, currImg);
                    currImg.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                if (chosen == 1)
                {
                    Console.WriteLine("Would you like to 1.Encode or 2.Decode?");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        filepath = filepath.Remove(filepath.Length - 4, 4) + "LSBO.bmp";
                        currImg = LSB.encode(data, currImg);
                        currImg.Save(filepath, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine(LSB.decode(currImg));
                    }
                }

                
            }
            catch(System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
