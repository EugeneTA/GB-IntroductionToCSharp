using System;
using System.IO;

namespace Lesson_05
{
    class Task_04
    {

        static void Main(string[] args)
        {
            // Задание 4
            // (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.


            string fileNameRecursive = "dirRecursive.txt";
            string fileNameLoop = "dirLoop.txt";

            Lesson05Helper.PrintTaskInfo(4);

            Console.WriteLine();
            Console.WriteLine(" Введите путь к директории:");
            Console.WriteLine();
            Console.Write(" > ");

            string userPath = Console.ReadLine();

            string[] dirStructure = GetDirectoryStructureR1(userPath);

            Console.WriteLine();
            Lesson05Helper.WriteLineWithColor(" -- Получение дерева каталогов и файлов методом рекурсии --", ConsoleColor.Red);
            Console.WriteLine();

            SaveResults(dirStructure, fileNameRecursive);
            dirStructure = null;
            GC.Collect();

            dirStructure = GetDirectoryStructureL1(userPath);

            Console.WriteLine();
            Lesson05Helper.WriteLineWithColor(" -- Получение дерева каталогов и файлов без рекурсии --", ConsoleColor.Red);
            Console.WriteLine();

            SaveResults(dirStructure, fileNameLoop);
            dirStructure = null;
            GC.Collect();


            /// <summary>
            /// запись структуры каталога в файл
            /// </summary>
            /// <param name="data">структура каталога</param>
            /// <param name="fileName">имя файла для сохранения</param>
            static void SaveResults(string[] data, string fileName)
            {
                if (data != null)
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        Console.WriteLine($" {data[i]}");
                    }

                    try
                    {
                        File.WriteAllLines(fileName, data);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка записи файла {fileName}: {e.Message}.");
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Lesson05Helper.WriteLineWithColor($" Результаты успешно сохранены в файл '{fileName}'.", ConsoleColor.Green);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($" Неверно задан путь, либо доступ к папке запрещен.");
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// Возвращает результат объединения двух массивов
            /// </summary>
            /// <param name="array1">первый массив</param>
            /// <param name="array2">второй массив</param>
            static string[] JoinTwoArrays(string[] array1, string[] array2)
            {
                if (array1 == null)
                {
                    if (array2 == null)
                    {
                        return null;
                    }
                    else
                    {
                        return array2;
                    }
                }
                else
                {
                    if (array2 == null)
                    {
                        return array1;
                    }
                    else
                    {
                        string[] result = new string[array1.Length + array2.Length];
                        array1.CopyTo(result, 0);
                        array2.CopyTo(result, array1.Length);
                        return result;
                    }
                }
            }

            /// <summary>
            /// Добавляет новый элемент в конец массыва
            /// </summary>
            /// <param name="array1">массив</param>
            /// <param name="stringToAppend">добавляемый элемент</param>
            static string[] AppendToArray(string[] array1, string stringToAppend)
            {
                if (array1 == null)
                {
                    if (string.IsNullOrEmpty(stringToAppend))
                    {
                        return null;
                    }
                    else
                    {
                        return (new string[1] { stringToAppend });
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(stringToAppend))
                    {
                        return array1;
                    }
                    else
                    {
                        string[] result = new string[array1.Length + 1];
                        array1.CopyTo(result, 0);
                        result[array1.Length] = stringToAppend;
                        return result;
                    }
                }
            }

            /// <summary>
            /// Получение дерева каталогов и файлов без рекурсии
            /// </summary>
            /// <param name="path">путь к каталогу</param>
            static string[] GetDirectoryStructureL1(string path)
            {
                string[] result = null;             // Хранит результат возвращаемый методом
                string[] directories = null;        // Список директорий
                int dirCount = 0;                   // Счетчик просканированых директорий

                if (string.IsNullOrWhiteSpace(path) == false)
                {
                    try
                    {
                        // Пытаемся получить список папок по указанному пользователем пути.
                        string[] dirs = Directory.GetDirectories(path);

                        // Если данный путь существует, то добавляем название пути к реузультату.
                        result = AppendToArray(result, path);

                        // обновляем список директорий
                        directories = dirs;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        result = AppendToArray(result, path);
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка. Невозможно получить доступ к директории.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка. {e.Message}");
                    }


                    if (directories != null)
                    {
                        // Если список каталогов не пустой, то запускаем цикл их обхода, пока не обойдем все директории из списка
                        while (dirCount < directories.Length)
                        {
                            try
                            {
                                // Пытаемся получить список поддиректорий для директории из списка
                                string[] dirs = Directory.GetDirectories(directories[dirCount]);

                                // Добавляем текущую директорию из списка в итоговый результат
                                result = AppendToArray(result, directories[dirCount]);

                                // Если текущяя директория из списка содержит поддиректории,
                                // то добавляем эти директории в список просматриваемых директорий сразу за текущей директорией,
                                // Если есть еще директории далее в этом списке, то они сдвигаются дальше.
                                if (dirs != null)
                                {
                                    // Создаем временный список большего размера
                                    string[] tmpDirs = new string[directories.Length + dirs.Length];

                                    // Добавляем в него все данный из списка до текущей директории включительно
                                    for (int i = 0; i <= dirCount; i++)
                                    {
                                        tmpDirs[i] = directories[i];
                                    }

                                    // Добавляем найденные поддиректории
                                    dirs.CopyTo(tmpDirs, dirCount + 1);

                                    // Добавляем оставшиеся директории из списка
                                    for (int i = dirCount + 1; i < directories.Length; i++)
                                    {
                                        tmpDirs[dirs.Length + i] = directories[i];
                                    }

                                    // обновляем список директорий
                                    directories = tmpDirs;
                                    tmpDirs = null;
                                }

                                // Получаем информацию о файлах в данной директории и добавляем информацию о нихх к результату
                                string[] files = Directory.GetFiles(directories[dirCount]);
                                result = JoinTwoArrays(result, files);
                                files = null;
                            }
                            catch (Exception e)
                            {
                                // Добавляем текущую директорию из списка в итоговый результат, если не смогли ее открыть
                                result = AppendToArray(result, directories[dirCount]);
                                Console.WriteLine();
                                Console.WriteLine($" Ошибка. {e.Message}");
                            }
                            finally
                            {
                                // В конце увеличиваем счетчик просмотренных директорий
                                dirCount++;
                            }
                        }
                    }


                    // В конце проверяем, есть ли файлы в корневой директории, указанной пользователем.
                    // Если есть, то добавляем их в конец результата
                    try
                    {
                        string[] files = Directory.GetFiles(path);
                        result = JoinTwoArrays(result, files);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка. {e.Message}");
                    }

                }

                return result;

            }

            /// <summary>
            /// Получение дерева каталогов и файлов методом рекурсии
            /// </summary>
            /// <param name="path">путь к каталогу</param>
            static string[] GetDirectoryStructureR1(string path)
            {
                string[] result = null;     // Хранит результат возвращаемый методом

                if (string.IsNullOrWhiteSpace(path) == false)
                {
                    try
                    {
                        // Пытаемся получить список папок по указанному пути.
                        string[] dirs = Directory.GetDirectories(path);

                        // Добавляем текущую директорию к итоговому результату

                        result = AppendToArray(result, path);

                        // Если в данной директории есть поддиректории, то запускаем цикл обхода по данным поддиректориям
                        if (dirs != null)
                        {
                            for (int i = 0; i < dirs.Length; i++)
                            {
                                // Запускаем рекурсию и сохраняем полученный результат
                                string[] subDirStructure = GetDirectoryStructureR1(dirs[i]);
                                result = JoinTwoArrays(result, subDirStructure);
                                subDirStructure = null;
                            }
   
                            dirs = null;
                        }

                        // Проверяем, есть ли файлы в данной директории.
                        // если есть, то сохраняем их итоговый реультат
                        string[] files = Directory.GetFiles(path);
                        result = JoinTwoArrays(result, files);
                        files = null;

                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Добавляем текущую директорию из списка в итоговый результат, если не смогли ее открыть
                        result = AppendToArray(result, path);
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка. Невозможно получить доступ к директории {path}.");
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Ошибка. {e.Message}");
                    }
                }

                return result;
            }

            Lesson05Helper.EndOfWork();
        }
    }
}
