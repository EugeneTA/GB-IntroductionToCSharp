using System;

namespace Lesson_02
{
    class L02_Task03
    {
        static void Main(string[] args)
        {
            //Урок #2. Базовые типы C#. Операторы ветвления. Область видимости
            //Задача #3. Определить, является ли введённое пользователем число чётным.

            long userNumber = 0;

            Console.WriteLine("Задача 3. Определить, является ли введённое пользователем число чётным.");

            Console.WriteLine("\nВведите целое число: ");

            try
            {
                userNumber = long.Parse(Console.ReadLine());
                 
                if ((userNumber%2) == 0)
                {
                    Console.WriteLine($"Введенное число {userNumber} является четным.");
                }
                else
                {
                    Console.WriteLine($"Введенное число {userNumber} не является четным.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"\nОшибка обработки введенных данных. {e.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();  

        }
    }
}
