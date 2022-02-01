using System;

namespace Lesson_02
{
    class L02_Task05
    {
        static void Main(string[] args)
        {
            //Урок #2. Базовые типы C#. Операторы ветвления. Область видимости
            //Задача #5. Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».

            Lesson_02.AverageDayTemp averageTemperature = new Lesson_02.AverageDayTemp();   // Для расчета среднесуточной температуры по данным пользователя
            Lesson_02.CurrentMonth currentMonth = new Lesson_02.CurrentMonth();          // Для получения номера текущего месяца от пользователя

            Console.WriteLine("Задача 5. Вывести сообщение «Дождливая зима», если пользователь указал месяц из зимнего периода, а средняя температура > 0.");

            try
            {
                if (averageTemperature.GetTempsFromConsole())
                {
                    currentMonth.GetCurrentMonthFromConsole();

                    currentMonth.ShowResult();
                    averageTemperature.ShowResult();

                    switch (currentMonth.MonthNumber)
                    {
                        case 1:
                        case 2:
                        case 12:
                            {
                                if (0 < averageTemperature.DayAverageTemp)
                                {
                                    Console.WriteLine("\nДождливая зима.");
                                }
                                break;
                            }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка. {e.Message}");
            }


             Console.WriteLine("\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();

        }
    }
}