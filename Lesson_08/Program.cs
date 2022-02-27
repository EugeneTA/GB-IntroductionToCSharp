using System;
using System.IO;

namespace Lesson_08
{
    class Program
    {
        static void Main(string[] args)
        {

            // Урок 8. Основные сущности проекта .Net
            // Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках приложения(application - scope).
            // Запросить у пользователя имя, возраст и род деятельности, а затем сохранить данные в настройках.
            // При следующем запуске отобразить эти сведения.
            // Задать приложению версию и описание.


            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Greetings) == false)
            {
                Console.WriteLine($" {Properties.Settings.Default.Greetings}");

                // Если в настройках приложения не задано имя пользователя, то запрашиваем
                // имя, возраст и род деятельности у пользователя.

                if (string.IsNullOrEmpty(Properties.Settings.Default.UserName))
                {
                    Console.WriteLine();
                    Console.WriteLine(" Как вас зовут?");
                    Console.Write(" > ");
                    Properties.Settings.Default.UserName = Console.ReadLine();

                    int userAge = -1;
                    
                    while(userAge < 0)
                    {
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine(" Сколько вам полных лет?");
                            Console.Write(" > ");
                            userAge = Convert.ToUInt16(Console.ReadLine());

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(" Возраст введен неверно. Используйте только числа для ввода возраста, например 33.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine(" Возраст введен неверно. Введенное число слишком большое или меньше 0.");
                        }
                    }

                    Properties.Settings.Default.UserAge = Convert.ToUInt32(userAge);

                    Console.WriteLine();
                    Console.WriteLine(" Кем вы работаете?");
                    Console.Write(" > ");
                    Properties.Settings.Default.UserOccupation = Console.ReadLine();

                    try
                    {
                        Properties.Settings.Default.Save();
                        Console.WriteLine();
                        Console.WriteLine(" Данные успешно сохранены в настройках.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Не удалось сохранить настройки. Ошибка: {e.Message}");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($" Здравствуйте, {Properties.Settings.Default.UserName}!");
                    Console.WriteLine($" Ваш возраст - {Properties.Settings.Default.UserAge} {GetAgeWord(Properties.Settings.Default.UserAge)}.");
                    Console.WriteLine($" Ваша профессия -  {Properties.Settings.Default.UserOccupation}.");
                }
            }

            Console.WriteLine();
            Console.Write(" Нажмите любую клавишу для завершения работы ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Возвращает слова "год", "года" или "лет" в зависимости от возраста.
        /// Например для 11 вернет "лет", а для 1 - "год".
        /// </summary>
        /// <param name="age">возраст</param>
        /// <returns></returns>
        static public string GetAgeWord(uint age)
        {
            string result = "";

            if (0 <= age)
            {
                if ((age%10 == 1) && (age != 11))
                {
                    result = "год";
                }
                else if (((age % 10 == 2) || (age % 10 == 3) || (age % 10 == 4)) && (age != 12) && (age != 13) && (age != 14))
                {
                    result = "года";
                }
                else
                {
                    result = "лет";
                }
            }

            return result;
        }

    }
}
