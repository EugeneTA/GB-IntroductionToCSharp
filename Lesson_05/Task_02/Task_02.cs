using System;
using System.IO;

namespace Lesson_05
{
    class Task_02
    {
        static void Main(string[] args)
        {
            // Задание 2.
            // Написать программу, которая при старте дописывает текущее время в файл «startup.txt».

            Lesson05Helper.PrintTaskInfo(2);

            string fileName = "startup.txt";

            try
            {
                File.AppendAllText(fileName, $"{DateTime.Now.TimeOfDay.ToString()}{Environment.NewLine}");
                Console.WriteLine();
                Lesson05Helper.WriteLineWithColor($" Текущее время успешно дописано в файл {fileName}.", ConsoleColor.Green);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($" Ошибка записи в файл. Сообщение: {e.Message}");
            }

            Lesson05Helper.EndOfWork();
        }
    }
}
