using System;

namespace Lesson_07
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showVSMessage = true;
            string helloMessage = " Lesson 7. This is the base project for ildasm.";
            
            if (showVSMessage)
            {
                Console.WriteLine(helloMessage);
            }

            Console.WriteLine();
            Console.Write(" Hit any key to finish ...");
            Console.ReadKey();
        }
    }
}
