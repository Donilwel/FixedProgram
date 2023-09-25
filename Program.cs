namespace Смена_верхних_и_нижних_индексов_или_если_произошел_косяк_с_клавой;
using System;

class Program
{
    /// <summary>
    /// Функция для изменения регистра букв русского и английского алфавитов с АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ на абвгдеёжзийклмнопрстуфхцчшщъыьэюя и обратно.
    /// </summary>
    /// <param name="stroka">Строка, которую нужно изменить.</param>
    /// <returns>Измененная строка.</returns>
    public static char[] MakeAbC(char[] stroka)
    {
        // Определяем массивы символов для русских и английских букв в верхнем и нижнем регистре
        char[] rusStrokaUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        char[] rusStrokaLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        char[] engStrokaUpper = "F,DULT\\;PBQRKVYJGHCNEA[WXIO]SM'.Z".ToCharArray();
        char[] engStrokaLower = "f,dult\\;pbqrkvyjghcnea[wxio]sm'.z".ToCharArray();

        // Счетчик для определения четности символа
        int counter = 0;
        for (int i = 0; i < stroka.Length; ++i)
        {
            // Если символ не пробел, увеличиваем счетчик
            if (stroka[i] != ' ') ++counter;

            // Если счетчик нечетный, меняем регистр символа
            if (counter % 2 != 0)
            {
                // Меняем регистр русских букв
                for (int j = 0; j < rusStrokaLower.Length; ++j)
                {
                    if (rusStrokaLower[j] == stroka[i])
                    {
                        stroka[i] = rusStrokaUpper[j];
                    }
                    else if (rusStrokaUpper[j] == stroka[i])
                    {
                        stroka[i] = rusStrokaLower[j];
                    }
                }

                // Меняем регистр английских букв
                for (int j = 0; j < engStrokaLower.Length; ++j)
                {
                    if (engStrokaLower[j] == stroka[i])
                    {
                        stroka[i] = engStrokaUpper[j];
                    }
                    else if (engStrokaUpper[j] == stroka[i])
                    {
                        stroka[i] = engStrokaLower[j];
                    }
                }
            }
        }
        return stroka;
    }

    /// <summary>
    /// Функция для изменения регистра букв русского и английского алфавитов с ghbdtn на привычный вид.
    /// </summary>
    /// <param name="stroka">Строка, которую нужно изменить.</param>
    /// <returns>Измененная строка.</returns>
    public static char[] MakeGhbd(char[] stroka)
    {
        // Определяем массивы символов для русских и английских букв в верхнем и нижнем регистре
        char[] rusStrokaUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ".ToCharArray();
        char[] rusStrokaLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя".ToCharArray();
        char[] engStrokaUpper = "F,DULT\\;PBQRKVYJGHCNEA[WXIO]SM'.Z".ToCharArray();
        char[] engStrokaLower = "f,dult\\;pbqrkvyjghcnea[wxio]sm'.z".ToCharArray();

        // Меняем символы в строке соответствующие ghbdtn на привычный вид
        for (int i = 0; i < stroka.Length; ++i)
        {
            for (int j = 0; j < rusStrokaUpper.Length; ++j)
            {
                if (engStrokaLower[j] == stroka[i])
                {
                    stroka[i] = rusStrokaLower[j];
                }
                else if (engStrokaUpper[j] == stroka[i])
                {
                    stroka[i] = rusStrokaUpper[j];
                }
                else if (rusStrokaLower[j] == stroka[i])
                {
                    stroka[i] = engStrokaLower[j];
                }
                else if (rusStrokaUpper[j] == stroka[i])
                {
                    stroka[i] = engStrokaUpper[j];
                }
            }
        }
        return stroka;
    }

    /// <summary>
    /// Функция для удаления всех символов в строке, кроме заглавных букв.
    /// </summary>
    /// <param name="stroka">Строка, которую нужно изменить.</param>
    /// <returns>Измененная строка.</returns>
    public static char[] DeliteOnlyCaps(char[] stroka)
    {
        return Array.ConvertAll(stroka, Char.ToLower);
    }

    /// <summary>
    /// Функция для преобразования всех символов в строке к заглавным буквам.
    /// </summary>
    /// <param name="stroka">Строка, которую нужно изменить.</param>
    /// <returns>Измененная строка.</returns>
    public static char[] OnlyCaps(char[] stroka)
    {
        return Array.ConvertAll(stroka, Char.ToUpper);
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Что нужно?\n 1. Если сделать текст вида АбВгДеЁжЗ\n 2. Если перепутал и написал ghbdtn.\n 3. Если написал ЗАГЛАВНЫМИ буквами\n 4. До связи\n 5. Если хочешь В о т  т а к  з а п и с а т ь\n 6. Если хочется наорать на человека через сообщения");
            int.TryParse(Console.ReadLine(), out int input);
            char[] stroka;
            if (input == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Введите строку для фикса");
                stroka = Console.ReadLine().ToCharArray();
                switch (input)
                {
                    case 1:
                        Console.WriteLine(MakeAbC(stroka));
                        break;
                    case 2:
                        Console.WriteLine(MakeGhbd(stroka));
                        break;
                    case 3:
                        Console.WriteLine(DeliteOnlyCaps(stroka));
                        break;
                    case 5:
                        Console.WriteLine(string.Join(" ", stroka));
                        break;
                    case 6:
                        Console.WriteLine(OnlyCaps(stroka));
                        break;
                }
            }
        }
    }
}