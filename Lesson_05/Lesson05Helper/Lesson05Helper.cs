using System;

namespace Lesson_05
{
    static public class Lesson05Helper
    {
        static Lesson05Helper()
        {
        }

        // Ввыводит в консоль информацию по задачам домашнего задания.
        static public void PrintTaskInfo(int task)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            switch (task)
            {
                case (1):
                    {
                        Console.WriteLine(" Задание 1:");
                        Console.WriteLine();
                        Console.WriteLine(" Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.");
                        break;
                    }

                case (2):
                    {
                        Console.WriteLine(" Задание 2:");
                        Console.WriteLine();
                        Console.WriteLine(" Написать программу, которая при старте дописывает текущее время в файл «startup.txt».");
                        break;
                    }
                case (3):
                    {
                        Console.WriteLine(" Задание 3:");
                        Console.WriteLine();
                        Console.WriteLine(" Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.");
                        break;
                    }
                case (4):
                    {
                        Console.WriteLine(" Задание 4:");
                        Console.WriteLine();
                        Console.WriteLine(" (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.");
                        break;
                    }
                case (5):
                    {
                        Console.WriteLine(" Задание 5:");
                        Console.WriteLine();
                        Console.WriteLine(" (*) Список задач(ToDo-list):");
                        Console.WriteLine(" - написать приложение для ввода списка задач; ");
                        Console.WriteLine(" - задачу описать классом ToDo с полями Title и IsDone;");
                        Console.WriteLine(" - на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;");
                        Console.WriteLine(" - если задача выполнена, вывести перед её названием строку «[x]»;");
                        Console.WriteLine(" - вывести порядковый номер для каждой задачи;");
                        Console.WriteLine(" - при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;");
                        Console.WriteLine(" - записать актуальный массив задач в файл tasks.json / xml / bin.");
                        break;
                    }

            }
        }

        // выводит в консоль заданную строку нужным цветом, без перевода на новую строку.
        static public void WriteWithColor(string toPrint, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.Write(toPrint);
            Console.ForegroundColor = defaultColor;
        }

        static public void WriteLineWithColor(string toPrint, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(toPrint);
            Console.ForegroundColor = defaultColor;
        }

        static public void EndOfWork()
        {
            Console.WriteLine();
            Console.Write(" Нажмите любую клавишу для завершения работы ...");
            Console.ReadKey();
            Console.WriteLine();
        }

    }
}

