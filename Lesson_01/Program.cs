using System;

namespace Lesson_01
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "";                                               // Будет содержать введенное пользователем имя
            ConsoleColor defaultConsoleTextColor = Console.ForegroundColor;     // Запоминаем цвет текста консоли по умолчанию

            // Выводим пользователю приглашение представиться.
            Console.WriteLine("Как вас зовут?");
            Console.WriteLine();
            Console.Write("> ");

            // Выделяем текст, вводимый пользователем, ввод зеленым цветом
            Console.ForegroundColor = ConsoleColor.Green;

            // Ожидаем ввода имени от пользователя.
            // Если имя не было введено (пустая строка) или состоит из пробелов, то запрашиваем ввод имени еще раз.

            while (string.IsNullOrWhiteSpace(userName = Console.ReadLine()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Недопустимое имя. Возможно вы ввели пустую строку или имя состоит из одних пробелов.");
                Console.WriteLine();

                Console.ForegroundColor = defaultConsoleTextColor;
                Console.WriteLine("Введите ваше имя еще раз:");
                Console.WriteLine();
                Console.Write("> ");

                Console.ForegroundColor = ConsoleColor.Green;
            }

            // Выводим приветствие пользователю
            Console.ForegroundColor = defaultConsoleTextColor;
            Console.WriteLine();
            Console.WriteLine($"Привет, {userName.Trim()}, сегодня {DateTime.Today:D}");

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для завершения работы...");
            Console.ReadKey();
        }
    }
}
