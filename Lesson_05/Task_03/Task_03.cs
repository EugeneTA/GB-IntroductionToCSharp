using System;
using System.IO;

namespace Lesson_05
{
    class Task_03
    {
        static void Main(string[] args)
        {
            // Задание 3
            //
            // Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.

            Lesson05Helper.PrintTaskInfo(3);


            Console.WriteLine();
            Console.WriteLine(" Введите числа от 0 до 255, разделяя их пробелом:");
            Console.Write(" > ");

            string userData = Console.ReadLine();
            string fileName = "bytes.txt";
            string wordsSeparator = "\x20";

            byte[] result = GetNumbersFromString(userData, wordsSeparator);

            if (result != null)
            {
                File.WriteAllBytes(fileName, result);
                Console.WriteLine();
                Lesson05Helper.WriteLineWithColor($" Данные успешно сохранены в файл {fileName}.", ConsoleColor.Green);
            }
            else
            {
                Lesson05Helper.WriteLineWithColor(" Вы не задали ниодного числа. Нечего сохранять.", ConsoleColor.Red);
            }



            /// <summary>
            /// Возвращает массив чисел от 0 до 255, если такие числа встречаются в строке 
            /// Если числа не встречаются, то возвращает NULL
            /// </summary>
            /// <param name="inputString">строка с произвольным набором чисел от 0 до 255</param>
            /// <param name="wordsSeparator"разделитель чисел в передаваемой строке</param>
            ///
            
            static byte[] GetNumbersFromString(string dataString, string wordsSeparator)
            {
                string[] splitResultArray = dataString.Split(wordsSeparator);
                byte[] tempNumbersArray = new byte[splitResultArray.Length];
                int numbersIndex = -1;

                for (int i = 0; i < splitResultArray.Length; i++)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(splitResultArray[i]) == false)
                        {
                            try
                            {
                                // Если удалось преобразовать полученную последовательность в чмисло,
                                // то добавляем его в массив.
                                byte userDigit = Convert.ToByte(splitResultArray[i]);
                                Console.WriteLine();
                                Console.Write(" Найдено число: ");
                                Lesson05Helper.WriteLineWithColor(userDigit.ToString(), ConsoleColor.Red);
                                tempNumbersArray[++numbersIndex] = userDigit;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine();
                                Console.WriteLine($" Невозможно преобразовать '{splitResultArray[i]}' в Byte.");
                                Console.WriteLine();
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine();
                                Console.WriteLine($" Введенное число '{splitResultArray[i]}' больше диапазона Byte.");
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($" Ошибка при обработке строки. Сообщение: {e.Message}");
                    }
                }

                if (numbersIndex > -1)
                {
                    byte[] resultArray = new byte[numbersIndex+1];

                    for (int i=0; i <= numbersIndex; i++)
                    {
                        resultArray[i] = tempNumbersArray[i];
                    }

                    return resultArray;
                }
                else
                {
                    byte[] resultArray = null;
                    return resultArray;
                }

            }


            Lesson05Helper.EndOfWork();
        }
    }
}
