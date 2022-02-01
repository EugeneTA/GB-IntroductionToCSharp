using System;

namespace Lesson_02
{
    class L02_Task06
    {
        [Flags]
        public enum WeekDays
        {
            Undefined = 0b_00000000,
            Monday    = 0b_00000001,
            Tuesday   = 0b_00000010,
            Wednesday = 0b_00000100,
            Thursday  = 0b_00001000,
            Friday    = 0b_00010000,
            Saturday  = 0b_00100000,
            Sunday    = 0b_01000000,
        }

        static void Main(string[] args)
        {
            //Урок #2.      Базовые типы C#. Операторы ветвления. Область видимости

            //Задача #6.    Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру,
            //              чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы,
            //              офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.

            WeekDays maskWorkingDays = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday;
            WeekDays maskWeekend = WeekDays.Saturday | WeekDays.Sunday;
            WeekDays maskFullWeek = maskWorkingDays | maskWeekend;


            WeekDays office01Timetable = maskWorkingDays;
            WeekDays office02Timetable = maskFullWeek;
            WeekDays office03Timetable = (maskWorkingDays | WeekDays.Saturday) ^ WeekDays.Monday;
            WeekDays office04Timetable = maskWorkingDays ^ WeekDays.Friday;
            WeekDays office05Timetable = maskFullWeek ^ WeekDays.Monday ^ WeekDays.Wednesday ^ WeekDays.Saturday;
            WeekDays office06Timetable = WeekDays.Undefined;


            string office01Name = "ООО 'Рога и копыта'";
            string office02Name = "УВД Измайлово";
            string office03Name = "ООО 'Небеса'";
            string office04Name = "ПАО 'Микрософт'";
            string office05Name = "ООО 'Иванов и Ко'";
            string office06Name = "ООО 'Пустота'";

            Console.WriteLine($"Рабочие часы офисов:");
            
            Console.WriteLine($"\nМаска офиса {office01Name}: {office01Timetable}");
            PrintTimetable(office01Timetable, office01Name);

            Console.WriteLine($"\n\nМаска офиса {office02Name}: {office02Timetable}");
            PrintTimetable(office02Timetable, office02Name);

            Console.WriteLine($"\n\nМаска офиса {office03Name}: {office03Timetable}");
            PrintTimetable(office03Timetable, office03Name);

            Console.WriteLine($"\n\nМаска офиса {office04Name}: {office04Timetable}");
            PrintTimetable(office04Timetable, office04Name);

            Console.WriteLine($"\n\nМаска офиса {office05Name}: {office05Timetable}");
            PrintTimetable(office05Timetable, office05Name);

            Console.WriteLine($"\n\nМаска офиса {office06Name}: {office06Timetable}");
            PrintTimetable(office06Timetable, office06Name);


            void PrintTimetable(WeekDays timetable, string officeName)
            {
                string dayStart = null;     // Хранит начало рабочего периода
                string dayEnd = null;       // Хранит временное окончание рабочего периода
                string result = null;       // Промежуточный результат расписания работы офиса
                bool isWorking = false;     // Флаг того, что в предыдущий день офис работал.  
               

                if (timetable != WeekDays.Undefined)
                {
                    WeekDays day = WeekDays.Monday;

                    while(day <= WeekDays.Sunday)
                    {
                        // Если текущий день является рабочим днем компании, то
                        if ((timetable & day) == day)
                        {
                            // Если предыдущий день был первым рабочим днем в периоде (если dayEnd = null), то меняем форму записи начала рабочего периода.
                            // Записываем текущий день во временное окончание рабочего периода.
                            if (isWorking)
                            {
                                switch (day)
                                {
                                    case WeekDays.Monday:
                                        {
                                            dayStart = "в понедельник";
                                            break;
                                        }
                                    case WeekDays.Tuesday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "с понедельника по";
                                            }
                                            dayEnd = " вторник";
                                            break;
                                        }
                                    case WeekDays.Wednesday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "со вторника по";
                                            }
                                            dayEnd = " среду";
                                            break;
                                        }
                                    case WeekDays.Thursday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "со среды по";
                                            }
                                            dayEnd = " четверг";
                                            break;
                                        }
                                    case WeekDays.Friday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "с четверга по";
                                            }
                                            dayEnd = " пятницу";
                                            break;
                                        }
                                    case WeekDays.Saturday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "с пятницы по";
                                            }
                                            dayEnd = " субботу";
                                            break;
                                        }
                                    case WeekDays.Sunday:
                                        {
                                            if (string.IsNullOrEmpty(dayEnd))
                                            {
                                                dayStart = "с субботы по";
                                            }
                                            dayEnd = " воскресенье";
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                // Если же предыдущий день был не рабочим, то записываем в начало рабочего периода сегодняшний день.
                                switch (day)
                                {
                                    case WeekDays.Monday:
                                        {
                                            dayStart = "в понедельник";
                                            break;
                                        }
                                    case WeekDays.Tuesday:
                                        {
                                            dayStart = "во вторник";
                                            break;
                                        }
                                    case WeekDays.Wednesday:
                                        {
                                            dayStart = "в среду";
                                            break;
                                        }
                                    case WeekDays.Thursday:
                                        {
                                            dayStart = "в четверг";
                                            break;
                                        }
                                    case WeekDays.Friday:
                                        {
                                            dayStart = "в пятницу";
                                            break;
                                        }
                                    case WeekDays.Saturday:
                                        {

                                            dayStart = "в субботу";
                                            break;
                                        }
                                    case WeekDays.Sunday:
                                        {
                                            dayStart = "в воскресенье";
                                            break;
                                        }
                                }
                                dayEnd = null;
                                isWorking = true;
                            }
                        }
                        else
                        {
                            // Если текущий день не рабочий, то
                            if (isWorking)
                            {
                                // если предыдущий день был рабочий, сохраняем предыдущий рабочий период в переменную для промежуточного результата.
                                if (!string.IsNullOrEmpty(result))
                                {
                                    result = result + ", ";
                                }

                                result = result + dayStart + dayEnd;

                                dayStart = null;
                                dayEnd = null;
                                isWorking = false;
                            }
                        }

                        // Переходим к следующему дню сдвига бит влево
                        day = (WeekDays)((uint)day << 1);
                    }

                    // Проверяем после цикла, что если работали в воскресенье, то сохранаяем последний рабочий период.
                    if (isWorking)
                    {
                        if (!string.IsNullOrEmpty(result))
                        {
                            result = result + ", ";
                        }

                        result = result + dayStart + dayEnd;

                        dayStart = null; 
                        dayEnd = null;
                        isWorking = false;
                    }
                }

                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine($"\nОфис {officeName} не работает.");
                }
                else
                {
                    Console.WriteLine($"\nОфис {officeName} работает {result}.");
                }

            }

            Console.WriteLine("\n\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();


        }
    }
}
