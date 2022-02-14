# GB-IntroductionToCSharp
## Урок 1. Знакомство с Microsoft Visual Studio и языком C#.
1. Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%, сегодня %дата%». Имя пользователя сохранить из консоли в промежуточную переменную. Поставить точку останова и посмотреть значение этой переменной в режиме отладки. Запустить исполняемый файл через системный терминал.

## Урок 2. Базовые типы C#. Операторы ветвления. Область видимости.
1. Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
2. Запросить у пользователя порядковый номер текущего месяца и вывести его название.
3. Определить, является ли введённое пользователем число чётным.
4. Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые были заранее заготовлены до вывода на консоль.
5. (*)Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
6. (*)Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса. Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья и выведите его на экран консоли.

## Урок 3. Массивы и строки. Операторы цикла.
1. Написать программу, выводящую элементы двухмерного массива по диагонали.
2. Написать программу — телефонный справочник — создать двумерный массив 5*2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/e-mail.
3. Написать программу, выводящую введенную пользователем строку в обратном порядке (olleH вместо Hello).
4. (*)«Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.

## Урок 4. Методы стандартных классов .NET
1. Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
2. Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. Ввести данные с клавиатуры и вывести результат на экран.
3. Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
4. (*)Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом.

## Урок 5. Работа с файловой подсистемой. Сериализация.
1. Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
2. Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
3. Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
4. (*)Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
5. (*)Список задач (ToDo-list):
        - написать приложение для ввода списка задач;
        - задачу описать классом ToDo с полями Title и IsDone;
        - на старте, если есть файл tasks.json/xml/bin (выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
        - если задача выполнена, вывести перед её названием строку «[x]»;
        - вывести порядковый номер для каждой задачи;
        - при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
        - записать актуальный массив задач в файл tasks.json/xml/bin.