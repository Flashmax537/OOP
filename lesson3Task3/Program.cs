using System;
using System.IO;

namespace lesson3Task3
{
    class Program
    {
        static void Main()
        {
            File.AppendAllText("fioAndEmails.txt", "Кучма Андрей Витальевич & Kuchma@mail.ru\r\n" +
                "Мизинцев Павел Николаевич & Pasha@mail.ru\r\nИванов Иван Иванович & III@mail.ru"); // создал файл, содержащий ФИО и e-mail адреса

            string[] fioAndEmails = { };
            if (File.Exists("fioAndEmails.txt"))
            {
                string textInFile = File.ReadAllText(("fioAndEmails.txt"));
                fioAndEmails = textInFile.Split("\r\n"); // записал массив строк из файла
            }

            for (int i = 0; i < fioAndEmails.Length; i++)
            {
                string s = fioAndEmails[i];
                SearchMail(ref s);
                File.AppendAllText("email.txt", $"{s}\n"); // создание файла и запись email-ов
            }
        }

        /// <summary>
        /// Метод, выделяющий из строки адрес почты
        /// </summary>
        /// <param name="s">Символьная строка</param>
        public static void SearchMail(ref string s)
        {
            s = s.Split(" & ")[1];
        }
    }
}
