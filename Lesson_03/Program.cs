using System;

namespace Lesson_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Урок 3. Массивы и строки. Операторы цикла.
            // 1.Написать программу, выводящую элементы двухмерного массива по диагонали.
            // 2.Написать программу — телефонный справочник — создать двумерный массив 5 * 2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/ e - mail.
            // 3.Написать программу, выводящую введенную пользователем строку в обратном порядке(olleH вместо Hello).
            // 4. (*)«Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.


            var consoleDefaultColor = Console.ForegroundColor;

            #region Task 1. Написать программу, выводящую элементы двухмерного массива по диагонали.

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("\nЗадание 1. Написать программу, выводящую элементы двухмерного массива по диагонали.");
            Console.ForegroundColor = consoleDefaultColor;

            int[,] array2D = new int[10, 10];

            if (array2D.Rank == 2)
            {
                int arrayRows = array2D.GetUpperBound(0) + 1;
                int arrayColumns = array2D.Length / arrayRows;

                Console.WriteLine($"\nМассив [{arrayRows},{arrayColumns}]");

                Console.WriteLine("\nЭлементы массива:");
                // Цикл для задания значений элементам массива и вывод значений всего массива в консоль 
                for (int i = 0; i < arrayRows; i++)
                {
                    for (int j = 0; j < arrayColumns; j++)
                    {
                        if (((j - i) == 0) || ((i + j + 1) == arrayColumns))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = consoleDefaultColor;
                        }
                        array2D[i,j] = i * 10 + j;
                        Console.Write($"{array2D[i,j]:d2} ");
                    }
                    Console.Write("\n");
                }

                Console.ForegroundColor = consoleDefaultColor;

                // Вывод элементов массива расположеных на диагонали
                if (arrayRows == arrayColumns)
                {
                    Console.WriteLine("\nЗначения, находящиеся на первой диагонали:");
                    // Вывод элементов массива расположеных на диагонали если массив квадратный
                    for (int i = 0; i < arrayRows; i++)
                    {
                        Console.Write($"{array2D[i,i]:d2} ");
                    }

                    Console.Write("\n");

                    Console.WriteLine("\nЗначения, находящиеся на второй диагонали:");
                    // Вывод элементов массива расположеных на диагонали если массив квадратный
                    for (int i = 0; i < arrayRows; i++)
                    {
                        Console.Write($"{array2D[i, (arrayRows-1)-i]:d2} ");
                    }

                    Console.Write("\n");
                }
                else
                {
                    // Если массив не квадратный
                    Console.WriteLine("\nМассив не квадратный. Нельзя однозначно определить диагональ.");
                }


            }
            else
            {
                Console.WriteLine("Заданный массимв не является двухмерным.");
            }

            #endregion


            #region Task.02 Написать программу — телефонный справочник — создать двумерный массив 5 * 2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/ e - mail.

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("\nЗадание 2. Написать программу — телефонный справочник — создать двумерный массив 5 * 2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/ e - mail.");
            Console.ForegroundColor = consoleDefaultColor;

            const char dataSplitSymbol = '/';

            string[,] phoneBook = new string[5,2] {
                { "Иван", $"79161234567{dataSplitSymbol}ivan!email.com"},
                { "Пётр", $"+74991234567{dataSplitSymbol}ptr@gmail.com"},
                { "Марина", $"+74959685678{dataSplitSymbol}marine@yandex.ru"},
                { "Антон", $"+79161234567{dataSplitSymbol}"},
                { "Spyderman", $"{dataSplitSymbol}spyderman@meta.com"}
            };

            int phbRow = phoneBook.GetUpperBound(0) + 1;
            int phbColumn = phoneBook.Length / phbRow;

            Console.WriteLine("\nТелефонный справочник: ");
            for (int i= 0; i < phbRow; i++)
            {
                for (int j = 0; j < phbColumn; j++)
                {
                    switch (j)
                    {
                        case (0):
                            {
                                // В первой колонке хранится имя контакта 
                                if (phoneBook[i, j] != null)
                                {
                                    Console.ForegroundColor = consoleDefaultColor;
                                    Console.Write("\nИмя: ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($"{phoneBook[i, j]}");
                                }
                                break;
                            }
                        case (1):
                            {
                                // Во второй колонке хранятся данные контакта (телефон, почта, какие-то другие данные) разделенные "/"
                                if (!string.IsNullOrWhiteSpace(phoneBook[i, j]))
                                {
                                    // Разбираем данные контакта на телефон и почту.
                                    string[] phbData = phoneBook[i, j].Split(dataSplitSymbol);
                                    string tempAdditionalInfo = "";

                                    for (int dataIndex = 0; dataIndex < phbData.Length; dataIndex++)
                                    {
                                        if (!string.IsNullOrWhiteSpace(phbData[dataIndex]))
                                        {
                                            if (phbData[dataIndex].StartsWith("+"))
                                            {
                                                // если строка содержит "+" вначале, то предполагаем, что это номер телефона
                                                Console.ForegroundColor = consoleDefaultColor;
                                                Console.Write(" Телефон: ");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write($"{phbData[dataIndex]} ");
                                            }
                                            else if (phbData[dataIndex].Contains("@"))
                                            {
                                                // если строка содержит "@", то предполагаем, что это почта
                                                Console.ForegroundColor = consoleDefaultColor;
                                                Console.Write(" E-mail: ");
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.Write($"{phbData[dataIndex]} ");
                                            }
                                            else
                                            {
                                                //иначе выводим значение как дополнительная информация
                                                if (string.IsNullOrEmpty(tempAdditionalInfo))
                                                {
                                                    tempAdditionalInfo += phbData[dataIndex];
                                                }
                                                else
                                                {
                                                    tempAdditionalInfo += (", " + phbData[dataIndex]);
                                                }
                                            }
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(tempAdditionalInfo))
                                    {
                                        Console.ForegroundColor = consoleDefaultColor;
                                        Console.Write(" Доп. иформация: ");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write(tempAdditionalInfo);

                                    }

                                }
                                break;
                            }
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = consoleDefaultColor;

            #endregion


            #region Task.03 Написать программу, выводящую введенную пользователем строку в обратном порядке(olleH вместо Hello).

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("\nЗадание 3. Написать программу, выводящую введенную пользователем строку в обратном порядке(olleH вместо Hello).");
            Console.ForegroundColor = consoleDefaultColor;

            Console.WriteLine("\nВведите строку:");
            Console.WriteLine();
            Console.Write(">");
            string userString = Console.ReadLine();

            Console.WriteLine();
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = userString.Length-1; i >= 0; i--)
            {
                Console.Write(userString[i].ToString());
            }
            Console.WriteLine();
            Console.ForegroundColor = consoleDefaultColor;

            #endregion


            #region Task.04  (*)«Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("===============================================================================================================");
            Console.WriteLine("\nЗадание 4. «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и 0, где Х — элементы кораблей, а 0 — свободные клетки.");
            Console.ForegroundColor = consoleDefaultColor;

            string[,] seaTable = new string[10,10]
            {
                {"0","X","0","0","0","0","0","X","0","0" },
                {"0","X","0","0","0","0","0","0","0","0" },
                {"0","X","0","0","0","0","0","X","0","X" },
                {"0","X","0","X","X","X","0","X","0","0" },
                {"0","0","0","0","0","0","0","0","0","0" },
                {"0","0","0","0","0","0","0","0","0","0" },
                {"0","0","X","X","0","0","0","X","0","X" },
                {"X","0","0","0","0","0","0","X","0","X" },
                {"0","0","0","0","0","0","0","X","0","0" },
                {"0","0","0","0","X","0","0","0","0","0" }
            };

            int seaTableRow = seaTable.GetUpperBound(0) + 1;
            int seaTableColumn = seaTable.Length / seaTableRow;

            Console.WriteLine();


            for (int i = 0; i < seaTableRow; i++)
            {
                for(int j = 0; j < seaTableColumn; j++)
                {
                    if (seaTable[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = consoleDefaultColor;
                    }
                    Console.Write($"{seaTable[i,j]} ");
                }
                Console.WriteLine();
            }

            #endregion


            Console.WriteLine("\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();

        }
    }
}
