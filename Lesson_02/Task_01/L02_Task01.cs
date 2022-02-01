using System;

namespace Lesson_02
{
    public class AverageDayTemp
    {
        private float _dayLowTemp;
        private float _dayHighTemp;
        private float _dayAverageTemp;

        public AverageDayTemp()
        {
            this._dayHighTemp = -500;
            this._dayLowTemp = -500;
            this._dayAverageTemp = -500;
        }

        public float DayLowTemp
        {
            get
            {
                if (this._dayLowTemp == -500)
                {
                    throw new Exception("Day low temperature parameter is undefined.");
                }
                else
                {
                    return this._dayLowTemp;
                }
            }
            set
            {

            }
        }

        public float DayHighTemp
        {
            get
            {
                if (this._dayHighTemp == -500)
                {
                    throw new Exception("Day high temperature parameter is undefined.");
                }
                else
                {
                    return this._dayHighTemp;
                }
            }
            set
            {

            }
        }

        public float DayAverageTemp
        {
            get
            {
                if (this._dayAverageTemp == -500)
                {
                    throw new Exception("Day average temperature parameter is not calculated yet.");
                }
                else
                {
                    return this._dayAverageTemp;
                }
            }
            set
            {

            }
        }

        /// <summary>
        /// Запрашивает у пользователя минимальную и максимальную температуру за сутки и рассчитывает среднесуточную температуру
        /// Возвращает True, если результат подсчитан успешно.
        /// Если возникли ошибки при обработке, возвращает False
        /// </summary>
        public bool GetTempsFromConsole()
        {
            float tempDayHigh;          // Максимальная температура за сутки
            float tempDayLow;           // Минимальная температура за сутки
            float tempDayAverage;       // Среднесуточная температура

            try
            {
                Console.WriteLine("\nВведите минимальную температуру за сутки (в °C). Для разделения целой и дробной части используйте ',':");
                Console.Write("> ");
                tempDayLow = float.Parse(Console.ReadLine());

                // По шкале Цельсия абсолютному нулю соответствует температура −273,15 °C или −459,67 °F (по Фаренгейту) или 0 Кельвинов
                while (tempDayLow < -273.15)
                {
                    Console.WriteLine($"\nВведенная температура {tempDayLow}°C слишком низкая. Считается, что абсолютный ноль это -273,15°C.");
                    Console.WriteLine("Попробуйте ввести минимальную температуру за сутки еще раз:");
                    Console.Write("> ");
                    tempDayLow = float.Parse(Console.ReadLine());
                }

                Console.WriteLine("\nВведите максимальную температуру за сутки (в °C). Для разделения целой и дробной части используйте ',':");
                Console.Write("> ");
                tempDayHigh = float.Parse(Console.ReadLine());

                // Запрашиваем макимальную суточную температуру у пользователя до тех пор, пока она не будет больше или равна минимальной суточной температуре.
                while (tempDayHigh < tempDayLow)
                {
                    Console.WriteLine($"\nВведенная температура {tempDayHigh}°C ниже минимальной суточной температуры {tempDayLow}°C введенной вами ранее.");
                    Console.WriteLine("Попробуйте ввести максимальную температуру за сутки еще раз:");
                    Console.Write("> ");
                    tempDayHigh = float.Parse(Console.ReadLine());
                }


                // Считаем среднесуточную температуру и выводим результат
                if (tempDayLow == tempDayHigh)
                {
                    tempDayAverage = tempDayLow;
                }
                else
                {
                    tempDayAverage = (tempDayLow + tempDayHigh) / 2;
                }

            }
            catch (Exception e)
            {
                System.Console.WriteLine($"\nОшибка обработки введенных данных. {e.Message}");
                return false;
            }

            this._dayLowTemp = tempDayLow;
            this._dayHighTemp = tempDayHigh;
            this._dayAverageTemp = tempDayAverage;

            return true;
        }

        /// <summary>
        /// Выводит суточные параметры температуры в консоль
        /// </summary>
        public void ShowResult()
        {
            try
            {
                Console.WriteLine($"\nМинимальная суточная температура:      {this.DayLowTemp}°C.");
                Console.WriteLine($"Максимальная суточная температура:     {this.DayHighTemp}°C.");
                Console.WriteLine($"Среднесуточная температура:            {this.DayAverageTemp}°C.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nОшибка вывода результата. {e.Message}");
            }
        }
    }

    public class L02_Task01
    {
        static void Main(string[] args)
        {

            //Урок #2. Базовые типы C#. Операторы ветвления. Область видимости
            //Задача #1. Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.

            AverageDayTemp Lesson02Task01 = new AverageDayTemp();

            Console.WriteLine("Задача 1. Подсчет среднесуточной температуры на основе данных пользователя");

            try
            {
                Lesson02Task01.GetTempsFromConsole();
                Lesson02Task01.ShowResult();
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
