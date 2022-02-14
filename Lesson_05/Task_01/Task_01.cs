using System;
using System.IO;


namespace Lesson_05
{

    class Task_01
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.");

            Lesson05Helper.PrintTaskInfo(1);

            Console.WriteLine();
            Console.WriteLine(" Введите данные, которые надо сохранить:");
            Console.WriteLine();
            Console.Write(" > ");

            string userData = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(" Введите имя файла:");
            Console.WriteLine();
            Console.Write(" > ");

            string fileName = Console.ReadLine();

            try
            {
                File.WriteAllText(fileName, userData);
                Console.WriteLine();
                Lesson05Helper.WriteLineWithColor($" Данные успешно сохранены в файл '{fileName}'.", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($" Ошибка при сохранении файла. Сообщение: {e.Message}");
            }


            Lesson05Helper.EndOfWork();
        }
    }
}
