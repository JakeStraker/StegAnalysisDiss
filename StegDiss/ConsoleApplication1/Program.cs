using System;

namespace StegDiss
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("This is the start of the program");
            }catch(System.IndexOutOfRangeException e)
            {
                Console.WriteLine("You did not provide the correct input arguments, The correct Syntax is [Method] [Image file]");
            }
        }
    }
}
