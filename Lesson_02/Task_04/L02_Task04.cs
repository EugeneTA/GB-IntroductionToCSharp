using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02
{
    class L02_Task04
    {
        static void Main(string[] args)
        {
            //Урок #2. Базовые типы C#. Операторы ветвления. Область видимости
            //
            //Задача #4. Для полного закрепления понимания простых типов найдите любой чек,
            //          либо фотографию этого чека в интернете и схематично нарисуйте его в консоли,
            //          только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок)
            //          подставляйте переменные, которые были заранее заготовлены до вывода на консоль.

            PrintHorizontalLine(60, '-');

            string storeName = "ЗАО 'МОСКВА-МАКДОНАЛДС'";
            PrintTextCenter(60, storeName);

            string storeAddress = "г. Москва, Волгоградский проспект, 5 владение 7";
            PrintTextCenter(60, storeAddress);

            string storeWEB = "www.macdonalds.ru";
            PrintTextCenter(60, storeWEB);

            uint storeCountryCode = 7;
            uint storePhoneAreaCode = 495;
            uint storePhoneNumber = 7442999;
            byte storeOpenHour = 9;
            byte storeCloseHour = 21;
            PrintTextCenter(60, $"Контакт центр  +{storeCountryCode}({storePhoneAreaCode}){storePhoneNumber} c {storeOpenHour} до {storeCloseHour}");

            PrintHorizontalLine(60, '=');
            PrintEmptyLine(60);

            ulong storeKKTNumber = 9007214;
            ulong storeINN = 7710044132;

            Console.Write("| ");
            PrintTextAlignLeft(30, $"ККТ № {storeKKTNumber:d9}");
            PrintTextAlignRight(30, $"ИНН: {storeINN}");
            Console.Write(" |\n");

            PrintEmptyLine(60);

            ulong checkID = 146;
            Console.Write("| ");
            PrintTextAlignLeft(60, $"Заказ № {checkID}");
            Console.Write(" |\n");

            PrintHorizontalLine(60, '_');
            PrintEmptyLine(60);
            PrintTextCenter(60, "* КАССОВЫЙ ЧЕК *");
            PrintTextCenter(60, "* ПРИХОД *");
            PrintEmptyLine(60);

            float NDS = 0.18f;

            string goodName1 = "ЛАТТЕ";
            decimal goodAmount1 = 2;
            decimal goodPrice1 = 99.00m;

            Console.Write("| ");
            PrintTextAlignLeft(23, $" {goodName1}");
            PrintTextAlignLeft(7, $"НДС {NDS * 100}%");
            PrintTextAlignRight(30, $"{goodAmount1} X {goodPrice1}  =  {goodAmount1 * goodPrice1:F2}");
            Console.Write(" |\n");

            PrintHorizontalLine(60, '-');

            string goodName2 = "ФИШ РОЛЛ";
            decimal goodAmount2 = 3;
            decimal goodPrice2 = 160.00m;

            Console.Write("| ");
            PrintTextAlignLeft(23, $" {goodName2}");
            PrintTextAlignLeft(7, $"НДС {NDS * 100}%");
            PrintTextAlignRight(30, $"{goodAmount2} X {goodPrice2}  =  {goodAmount2 * goodPrice2:F2}");
            Console.Write(" |\n");

            PrintHorizontalLine(60, '-');

            PrintEmptyLine(60);

            decimal totalAmount = (goodPrice1 * goodAmount1) + (goodPrice2 * goodAmount2);
            Console.Write("| ");
            PrintTextAlignRight(60, $"ИТОГ * {totalAmount:F2}");
            Console.Write(" |\n");

            PrintEmptyLine(60);

            decimal totalTax = totalAmount * (decimal)NDS;
            Console.Write("| ");
            PrintTextAlignLeft(23, $" в том числе налоги");
            PrintTextAlignLeft(7, $"НДС {NDS * 100}%");
            PrintTextAlignRight(30, $"{totalTax:F2}");
            Console.Write(" |\n");

            PrintHorizontalLine(60, '_');
            PrintEmptyLine(60);

            Console.Write("| ");
            PrintTextAlignLeft(30, $" Оплата картой");
            PrintTextAlignRight(30, $"{totalAmount:F2}");
            Console.Write(" |\n");

            PrintEmptyLine(60);
            PrintHorizontalLine(60, '_');
            PrintEmptyLine(60);

            string personalName = "Иванов И.И.";
            Console.Write("| ");
            PrintTextAlignLeft(60, $" Кассир {personalName}");
            Console.Write(" |\n");

            Console.Write("| ");
            PrintTextAlignLeft(60, $" ДАТА {DateTime.Today:dd.MM.yyyy}   ВРЕМЯ {DateTime.Now:hh:mm}");
            Console.Write(" |\n");

            ulong documentNumber = 4377;
            ulong incomeNumber = 47;

            Console.Write("| ");
            PrintTextAlignLeft(30, $" ДОКУМЕНТ № {documentNumber:d6}");
            PrintTextAlignRight(30, $"ПРИХОД № {incomeNumber:d4}");
            Console.Write(" |\n");

            uint boxOfficeNumber = 27;
            ulong fnNumber = 8710000100388825;

            Console.Write("| ");
            PrintTextAlignLeft(15, $" Касса № {boxOfficeNumber}");
            PrintTextAlignRight(45, $"ФН: ЭКЗ. № {fnNumber}");
            Console.Write(" |\n");

            ulong regNumber = 338862018416;
            uint smenaNumber = 8;
            Console.Write("| ");
            PrintTextAlignLeft(45, $" РЕГ. № {regNumber:d16}");
            PrintTextAlignRight(15, $"СМЕНА № {smenaNumber:d4}");
            Console.Write(" |\n");

            string taxType = "ОБЩАЯ";
            Console.Write("| ");
            PrintTextAlignLeft(60, $" СИСТ. НАЛОГООБЛ.: {taxType}");
            Console.Write(" |\n");

            ulong fdNumber = 1472;
            ulong fpNumber = 1421230762;
            Console.Write("| ");
            PrintTextAlignLeft(30, $"   ФД: {fdNumber:d4}");
            PrintTextAlignLeft(30, $" ФП={fpNumber:d10}");
            Console.Write(" |\n");

            PrintEmptyLine(60);
            PrintHorizontalLine(60, '-');


            Console.WriteLine("\nНажмите любую клавишу для завершения работы ...");
            System.Console.ReadKey();

            void PrintHorizontalSymbol(byte lineWidth, char symbolToPrint)
            {
                for (int i = 0; i < lineWidth; i++)
                {
                    Console.Write(symbolToPrint);
                }
            }

            void PrintEmptyLine(byte lineWidth)
            {
                Console.Write("| ");
                PrintHorizontalSymbol(lineWidth, '\x20');
                Console.Write(" |\n");
            }

            void PrintHorizontalLine(byte lineWidth, char symbolToPrint)
            {
                Console.Write("| ");
                PrintHorizontalSymbol(lineWidth, symbolToPrint);
                Console.Write(" |\n");
            }

            void PrintTextCenter(byte lineWidth, string textToPrint)
            {
                if (!string.IsNullOrWhiteSpace(textToPrint))
                {
                    Console.Write("| ");
                    if (textToPrint.Length > lineWidth)
                    {
                        Console.Write($"{textToPrint.Remove(0, lineWidth)}");
                    }
                    else
                    {
                        byte leadingSpaces = Convert.ToByte((lineWidth - textToPrint.Length) / 2);
                        byte tailSpaces = Convert.ToByte((((lineWidth - textToPrint.Length) % 2) > 0) ? leadingSpaces + 1 : leadingSpaces);

                        PrintHorizontalSymbol(leadingSpaces, '\x20');
                        Console.Write(textToPrint);
                        PrintHorizontalSymbol(tailSpaces, '\x20');
                    }
                    Console.Write(" |\n");
                }
            }

            void PrintTextAlignLeft(byte lineWidth, string textToPrint)
            {
                if (!string.IsNullOrWhiteSpace(textToPrint))
                {
                    if (textToPrint.Length > lineWidth)
                    {
                        Console.Write($"{textToPrint.Remove(0, lineWidth)}");
                    }
                    else
                    {
                        Console.Write(textToPrint);
                        PrintHorizontalSymbol((byte)(lineWidth - textToPrint.Length), '\x20');
                    }
                }
            }

            void PrintTextAlignRight(byte lineWidth, string textToPrint)
            {
                if (!string.IsNullOrWhiteSpace(textToPrint))
                {
                    if (textToPrint.Length > lineWidth)
                    {
                        Console.Write($"{textToPrint.Remove(0, lineWidth)}");
                    }
                    else
                    {
                        PrintHorizontalSymbol((byte)(lineWidth - textToPrint.Length), '\x20');
                        Console.Write(textToPrint);
                    }
                }
            }

        }
    }
}
