using System;

namespace Lesson_02
{
    public enum MonthRU
    {
        Udefined = 0,
        Январь = 1,
        Февраль = 2,
        Март = 3,
        Апрель = 4,
        Май = 5,
        Июнь = 6,
        Июль = 7,
        Август = 8,
        Сентябрь = 9,
        Октябрь = 10,
        Ноябрь = 11,
        Декабрь = 12
    }

    public class CurrentMonth
    {
        private int _monthNumber;

        public CurrentMonth()
        {
            _monthNumber = 0;
        }

        public int MonthNumber
        {
            get
            {
                if (this._monthNumber == 0)
                {
                    throw new Exception("Month number is undefined");
                }
                else
                {
                    return this._monthNumber;
                }
            }
            set
            {

            }
        }

        public MonthRU MonthName
        {
            get
            {
                if (this._monthNumber == 0)
                {
                    throw new Exception("Month number is undefined");
                }
                else
                {
                    return (MonthRU)this._monthNumber;
                }
            }
            set
            {

            }
        }
        
        /// <summary>
        /// Запрашивает порядковый номер текущего месяца у пользователя
        /// </summary>
        /// <returns>Возвращает true в случае успешного ввода пользователем порядкового номера текущего месяца (от 1 до 12) или false в случае ошибки</returns>
        public bool GetCurrentMonthFromConsole()
        {
            int userMonthNumber = 0;

            try
            {
                // Запрашиваем порядковы номер текущего месяца у пользователя до тех пор, пока он не введет значение от 1 до 12.
                while (true)
                {
                    Console.WriteLine("\nВведите порядковый номер текущего месяца (допустимые значения от 1 до 12):");
                    Console.Write("> ");
                    userMonthNumber = int.Parse(Console.ReadLine());

                    if ((0 < userMonthNumber) && (userMonthNumber < 13))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\nПорядковый номер месяца введен неверно.");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"\nОшибка обработки введенных данных. {e.Message}");
                return false;
            }

            this._monthNumber = userMonthNumber;

            return true;
        }

        public void ShowResult()
        {
            try
            {
                Console.WriteLine($"\nТекущий месяц - {this.MonthName}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка вывода результата. {e.Message}");
            }

        }

    }

 
    public class L02_Task02
    {

        //Урок #2. Базовые типы C#. Операторы ветвления. Область видимости
        //Задача #2. Запросить у пользователя порядковый номер текущего месяца и вывести его название.

        static void Main(string[] args)
        {
            CurrentMonth Lesson02Task02 = new CurrentMonth();

            if (Lesson02Task02.GetCurrentMonthFromConsole())
            {
                Console.WriteLine($"\nТекущий месяц - {Lesson02Task02.MonthName}.");
            }
          
            Console.WriteLine("\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();
        }
    }
}
