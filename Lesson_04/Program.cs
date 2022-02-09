using System;

namespace Lesson_04
{
    class Program
    {
        enum Seasons
        {
            Undefined = 0,
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Autumn = 4,
        }

        static void Main(string[] args)
        {
            // Ввыводит в консоль информацию по задачам домашнего задания.
            static void PrintTaskInfo(int task)
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
                            Console.WriteLine(" Написать метод GetFullName(string firstName, string lastName, string patronymic),");
                            Console.WriteLine(" принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО.");
                            Console.WriteLine(" Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.");
                            break;
                        }

                    case (2):
                        {
                            Console.WriteLine(" Задание 2:");
                            Console.WriteLine();
                            Console.WriteLine(" Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом,");
                            Console.WriteLine(" и возвращающую число — сумму всех чисел в строке.");
                            Console.WriteLine(" Ввести данные с клавиатуры и вывести результат на экран.");
                            break;
                        }
                    case (3):
                        {
                            Console.WriteLine(" Задание 3:");
                            Console.WriteLine();
                            Console.WriteLine(" Написать метод по определению времени года.");
                            Console.WriteLine(" На вход подаётся число – порядковый номер месяца.");
                            Console.WriteLine(" На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.");
                            Console.WriteLine(" Написать метод, принимающий на вход значение из этого перечисления");
                            Console.WriteLine(" и возвращающий название времени года(зима, весна, лето, осень).");
                            Console.WriteLine(" Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.");
                            Console.WriteLine(" Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».");
                            break;
                        }
                    case (4):
                        {
                            Console.WriteLine(" Задание 4:");
                            Console.WriteLine();
                            Console.WriteLine(" (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.");
                            break;
                        }

                }
            }

            // выводит в консоль заданную строку нужным цветом, без перевода на новую строку.
            static void WriteWithColor(string toPrint, ConsoleColor color)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;

                Console.ForegroundColor = color;
                Console.Write(toPrint);
                Console.ForegroundColor = defaultColor;
            }

            static void WriteLineWithColor(string toPrint, ConsoleColor color)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;

                Console.ForegroundColor = color;
                Console.WriteLine(toPrint);
                Console.ForegroundColor = defaultColor;
            }

            #region Task.01 
            //  Написать метод GetFullName(string firstName, string lastName, string patronymic), 
            //  принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО.
            //  Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.

            PrintTaskInfo(1);

            Console.WriteLine();
            WriteLineWithColor($" 1. {GetFullName("Иван", "Иванов", "Иванович")}", ConsoleColor.Red);
            WriteLineWithColor($" 2. {GetFullName("Сергей", "Цветков", "Эдуардович")}", ConsoleColor.Red);
            WriteLineWithColor($" 3. {GetFullName("Мария", "Петрова", "Матвеевна")}", ConsoleColor.Red);
            WriteLineWithColor($" 4. {GetFullName("Петр", "Девятов", "")}", ConsoleColor.Red);


            static string GetFullName(string firstName, string lastName, string patronymic)
            {
                return $"{lastName} {firstName} {patronymic}";
            }


            #endregion

            #region Task.02
            // Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом,
            // и возвращающую число — сумму всех чисел в строке.
            // Ввести данные с клавиатуры и вывести результат на экран.

            PrintTaskInfo(2);

            Console.WriteLine();
            Console.WriteLine(" Введите числа, разделяя их пробелом:");
            Console.Write(" > ");

            (bool isCalculateOK, double sum) result = CalculateNumbersInSentence(Console.ReadLine());

            if (result.isCalculateOK)
            {
                Console.WriteLine();
                Console.Write(" Сумма: ");
                WriteLineWithColor($"{result.sum}", ConsoleColor.Red);
            }
            else
            {
                Console.WriteLine();
                WriteLineWithColor(" Невозможно подсчитать сумму так как не задано ниодного числа.", ConsoleColor.Red);
            }



            /// <summary>
            /// Метод подсчета всех чисел в строке разделенных пробелом.
            /// Возвращает кортеж (bool isCalculateOK, double sum)
            /// isCalculateOK - true, если удалось подсчитать сумму.
            /// sum - полученная сумма
            /// </summary>
            /// <param name="inputString">строка, в которой нужно подсчитать все символы</param>
            
            static (bool isCalculateOK, double sum) CalculateNumbersInSentence(string inputString)
            {
                double sum = 0;
                bool isCalculateOK = false;

                try
                {
                    if (string.IsNullOrWhiteSpace(inputString) == false)
                    {
                        string tempWord = ""; // хранить временный данные разделенные пробелом.

                        Console.WriteLine();

                        for (int i = 0; i < inputString.Length; i++)
                        {
                            // Если символ не пробел, то добавляем его ко временной последовательности символов.
                            if (inputString[i] != '\x20')
                            {
                                tempWord += inputString[i];
                            }

                            // Если временная последовательность символов не пустая (отсекаем ситуацию, когда входная строка может начинаться с пробела) и текущий символ является пробелом
                            // или дошли до конца строки, то пытаемя преобразовать полученную последовательность в число
                            if (!string.IsNullOrEmpty(tempWord) && ((inputString[i] == '\x20') || (i + 1 == inputString.Length)))
                            {
                                try
                                {
                                    // Если удалось преобразовать полученную последовательность в чмисло,
                                    // то добавляем его к текущей сумме и устанавливаем флаг успешного выполнения суммирования.
                                    sum += Convert.ToDouble(tempWord);
                                    Console.Write(" Найдено число: ");
                                    WriteLineWithColor(tempWord, ConsoleColor.Red);
                                    Console.WriteLine();
                                    if (isCalculateOK == false)
                                    {
                                        isCalculateOK = true;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine($" Невозможно преобразовать '{tempWord}' в Double.");
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine($" Введенное число '{tempWord}' больше диапазона Double.");
                                }
                                finally
                                {
                                    tempWord = "";
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($" Ошибка при обработке введенной строки. Сообщение: {e.Message}");
                    return (false, 0);
                }

                return (isCalculateOK, sum);
            }

            #endregion

            #region Task.03
            //  Написать метод по определению времени года.
            //  На вход подаётся число – порядковый номер месяца.На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.
            //  Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень).
            //  Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года.
            //  Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».

            PrintTaskInfo(3);

            byte month = 0;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(" Введите номер месяца:");
                Console.Write(" > ");


                try
                {
                    month = Convert.ToByte(Console.ReadLine());

                    if ((month < 1) || (month > 12))
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка: введите число от 1 до 12");
                    }
                    else
                    {
                        Console.WriteLine();
                        WriteLineWithColor($" Время года - {GetSeasonName(GetSeason(month))}.", ConsoleColor.Red);
                        break;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Невозможно преобразовать введенную строку в Byte.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Введенное число больше диапазона Byte.");
                }

            }


            static Seasons GetSeason(int month)
            {
                switch (month)
                {
                    case (12):
                    case (1):
                    case (2):
                        {
                            return Seasons.Winter;
                        }

                    case (3):
                    case (4):
                    case (5):
                        {
                            return Seasons.Spring;
                        }
                    case (6):
                    case (7):
                    case (8):
                        {
                            return Seasons.Summer;
                        }
                    case (9):
                    case (10):
                    case (11):
                        {
                            return Seasons.Autumn;
                        }
                    default:
                        {
                            return Seasons.Undefined;
                        }
                }

            }

            static string GetSeasonName(Seasons season)
            {
                switch (season)
                {
                    case Seasons.Winter:
                        {
                            return "зима";
                        }
                    case Seasons.Spring:
                        {
                            return "весна";
                        }
                    case Seasons.Summer:
                        {
                            return "лето";
                        }
                    case Seasons.Autumn:
                        {
                            return "осень";
                        }
                    default:
                        {
                            return "";
                        }
                }
            }

            #endregion

            #region Task.04
            // (*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.

            PrintTaskInfo(4);
            
            try
            {
                Console.WriteLine();
                Console.WriteLine(" Введите число:");
                Console.Write(" > ");

                int fib = Convert.ToInt32(Console.ReadLine());
                double[] fibResult = new double[Math.Abs(fib)+1];   // Массив будет хранить уже вычисленные значения для чисел Фибоначчи, чтобы не вычислять их повторно
                                                                    // т.к. Фибоначчи для 0 равно 0, то создаем массив с числом элементов на 1 больше числа введенного пользователем

                Console.WriteLine();
                Console.Write($" Число Фибоначчи для числа '{fib}':  ");
                WriteLineWithColor($" {Fibonacci(fib)}", ConsoleColor.Red);

                Console.WriteLine();
                Console.WriteLine($" Последовательность Фибоначчи для числа '{fib}':");
                Console.WriteLine();

                // Выводим последовательность Фибоначчи.
                if (fib > -1)
                {
                    for (int i = 0; i < fibResult.Length; i++)
                    {
                        WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }
                else
                {
                    for (int i = Math.Abs(fib) ; i >= 0; i--)
                    {
                        WriteWithColor($" {fibResult[i]}", ConsoleColor.Red);
                    }
                }


                double Fibonacci(int number)
                {
                    // Для числа 0 возвращаем 0, для  1 возвращаем 1, для -1 возвращаем -1
                    if (number == 0)
                    {
                        fibResult[0] = 0;
                        return 0;
                    }
                    else if (number == 1)
                    {
                        fibResult[1] = 1;
                        return 1;
                    }
                    else if (number == -1)
                    {
                        fibResult[1] = -1;
                        return -1;
                    }
                    else
                    {
                        if (number > -1)
                        {
                            // Вычисление для положительных чисел
                            // Если число Фибоначчи еще не подсчитано (чило Фибоначчи равно 0 только для числа 0), то вычисляем число Фибоначчи
                            if (fibResult[number] == 0)
                            {
                                fibResult[number] = Fibonacci(number - 1) + Fibonacci(number - 2);
                            }

                            return fibResult[number];

                        }
                        else
                        {
                            // Вычисление для отрицательных чисел
                            if (fibResult[Math.Abs(number)] == 0)
                            {
                                fibResult[Math.Abs(number)] = Fibonacci(number + 1) + Fibonacci(number + 2);
                            }

                            return fibResult[Math.Abs(number)];
                        }
                    }
                }

            }
            catch (FormatException)
            {
                Console.WriteLine($" Невозможно преобразовать введенное число в Int32.");
            }
            catch (OverflowException)
            {
                Console.WriteLine($" Введенное число больше диапазона Int32.");
            }


            #endregion


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для завершения работы ....");
            Console.ReadKey();
        }
    }
}