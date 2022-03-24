using System;

namespace lesson3Task2
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите строку: ");
            var str = Console.ReadLine();
            var strReversed = GetStringReverse(str);
            Console.WriteLine($"Строка в обратном порядке: {strReversed}");
            if (str == GetStringReverse(strReversed))
                Console.WriteLine("Строка успешно реверсирована!");
            else
                Console.WriteLine("Строку реверсировать не удалось!");
        }

        /// <summary>
        /// Возвращает строку, буквы в которой идут в обратном порядке
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns></returns>
        public static string GetStringReverse(string str)
        {
            var result = "";
            var strToCharArr = str.ToCharArray();
            for (int i = strToCharArr.Length - 1; i != -1; i--)
            {
                result += strToCharArr[i];
            }
            return result;
        }
    }
}
