using System;
using System.Diagnostics;
using System.Linq;

namespace Lesson_06
{
    class Program
    {
        // Задаем ширину колонок в таблице в символах 
        public const int tableColumn1Width = 35;
        public const int tableColumn2Width = 12;
        public const int tableColumn3Width = 12;
        public const int tableColumn4Width = 15;

        static void Main(string[] args)
        {

            //Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.
            //Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.
            //В качестве примера можно использовать консольные утилиты Windows tasklist и taskkill.


            

            switch (args.Length)
            {
                case 1:
                    {
                        if (args[0].ToLower() == "-l" || args[0].ToLower() == "-list")
                        {
                            ShowProcesses();
                            break;
                        }

                        ShowHelp();
                        break;
                    }
                case 2:
                    {
                        if (args[0].ToLower() == "-killpid")
                        {
                            KillByPID(args[1]);
                            break;
                        }
                        else if (args[0].ToLower() == "-killname")
                        {
                            KillByName(args[1]);
                            break;
                        }

                        
                        ShowHelp();
                        break;
                    }
                        
                default:
                    {
                        ShowHelp();
                        break;
                    }
            }

            Console.WriteLine();
        }
        
        /// <summary>
        /// Вывод справки по параметрам запуска приложения
        /// </summary>
        static void ShowHelp()
        {
            Console.WriteLine();
            Console.WriteLine(" Урок 6.");
            Console.WriteLine(" Написать консольное приложение Task Manager,");
            Console.WriteLine(" которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.");
            Console.WriteLine(" Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" LESSON_06 [-?] [-LIST] [-KILLPID <ID процесса>] [-KILLNAME <имя процесса>]");
            Console.WriteLine();
            Console.WriteLine(" показывает список запущенных процессов и позволяет завершить указанный процесс");
            Console.WriteLine();
            Console.WriteLine(" Описание параметров:");
            Console.WriteLine();
            Console.WriteLine(String.Format("\t{0,-30} - {1,-50}","LIST, -L", "показывет список запущенных процессов"));
            Console.WriteLine();
            Console.WriteLine(String.Format("\t{0,-30} - {1,-50}", "-KILLPID <ID процесса>", "завершает процесс с указанным идентификатором"));
            Console.WriteLine();
            Console.WriteLine(String.Format("\t{0,-30} - {1,-50}", "-KILLNAME <имя процесса>", "завершает процессы с указанным именем"));
            Console.WriteLine();
            Console.WriteLine(String.Format("\t{0,-30} - {1,-50}", "-?", "показ справки"));
        }

        /// <summary>
        /// Вывод информации в консоль в виде таблице из 4-х колонок
        /// </summary>
        /// <param name="c1">Данные 1-ой колонки</param>
        /// <param name="c2">Данные 2-ой колонки</param>
        /// <param name="c3">Данные 3-ей колонки</param>
        /// <param name="c4">Данные 4-ой колонки</param>
        static void WriteTableToConsole(string c1, string c2, string c3, string c4)
        {
            Console.Write($"{c1,-tableColumn1Width}  {c2,tableColumn2Width}  {c3,tableColumn3Width}  {c4,tableColumn4Width}{Environment.NewLine}");
        }

        static void WriteTableHeader()
        {
            Console.WriteLine();
            WriteTableToConsole("Имя процесса", "PID", "№ сеанса", "Память");
            WriteTableToConsole(
                                new String('=', tableColumn1Width),
                                new String('=', tableColumn2Width),
                                new String('=', tableColumn3Width),
                                new String('=', tableColumn4Width)
                                );
            Console.WriteLine();
        }

        static void WriteProcessInfo(Process process)
        {
            if (process != null)
            {
                WriteTableToConsole(    (process.ProcessName.Length> tableColumn1Width ? process.ProcessName.Substring(0, tableColumn1Width) : process.ProcessName), 
                                        process.Id.ToString(), 
                                        $"{process.SessionId}", 
                                        $"{(process.WorkingSet64 / 1024):### ### ###} КБ"
                                        );
            }
        }

        /// <summary>
        /// Вывод в консоль список запущенных процессов
        /// </summary>
        static void ShowProcesses()
        {
            try
            {
                Process[] processes = Process.GetProcesses().OrderBy(process => process.ProcessName).ToArray();

                if (processes == null)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Не удалось получить ниодного процесса.");
                }
                else
                {
                    WriteTableHeader();

                    for (int i = 0; i < processes.Length; i++)
                    {
                        WriteProcessInfo(processes[i]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка. {e.Message}");
            }
        }

        /// <summary>
        ///  Завершение процесса по его PID
        /// </summary>
        /// <param name="processID">ID процесса</param>
        static void KillByPID(string processID)
        {
            
            if (string.IsNullOrWhiteSpace(processID) == false)
            {
                try
                {
                    int pID = Convert.ToInt32(processID);

                    if (pID < 1)
                    {
                        Console.WriteLine($" ID {processID} процесса указан неверно. Номер процесса должен быть больше 0.") ;
                    }
                    else
                    {
                        Process process = Process.GetProcessById(pID);

                        if (process == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($" Процесс с ID '{processID}' не найден.");
                        }
                        else
                        {
                            process.Kill();
                            process.WaitForExit(1000);
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($" Процесс с ID '{processID}' не найден.");
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($" При выполнении операции возникла ошибка: {e.Message}");
                }
            }
        }

        /// <summary>
        ///  Завершение процесса по его имени. Завершает все процессы с указанным именем.
        /// </summary>
        /// <param name="processName">имя процесса</param>
        static void KillByName(string processName)
        {
            if (string.IsNullOrWhiteSpace(processName) == false)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName(processName);

                    if (processes == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Процессы с  именем '{processName}' не найдены.");
                    }
                    else
                    {
                        if (processes.Length == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine($" Процесс с именем '{processName}' не найден.");
                        }
                        else
                        {
                            for (int i = 0; i < processes.Length; i++)
                            {
                                if (processes[i] != null)
                                {
                                    processes[i].Kill();
                                    processes[i].WaitForExit(1000);
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine($" При выполнении операции завершения процесса возникла ошибка: {e.Message}");
                }
            }
        }
    }
}