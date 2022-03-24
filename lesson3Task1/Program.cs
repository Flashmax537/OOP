using System;

namespace lesson3Task1
{
    class Program
    {
        static void Main()
        {
            var bankAccountOne = new BankAccount()
            {
                Balance = 100,
                Type = TypeOfBankAccount.DepositAccount
            };
            var bankAccountTwo = new BankAccount()
            {
                Balance = 200,
                Type = TypeOfBankAccount.PaymentAccount
            };
            var bankAccountThree = new BankAccount()
            {
                Balance = 300,
                Type = TypeOfBankAccount.CurrencyAccount
            };

            int tableSize = 100; // Размер таблицы
            PrintAccountInfo(tableSize, bankAccountOne, bankAccountTwo, bankAccountThree);

            bankAccountTwo.MoneyTransfer(150, bankAccountThree);
            PrintAccountInfo(tableSize, bankAccountOne, bankAccountTwo, bankAccountThree);

            bankAccountTwo.MoneyTransfer(500, bankAccountThree);
            PrintAccountInfo(tableSize, bankAccountOne, bankAccountTwo, bankAccountThree);
        }

        /// <summary>
        /// Отрисовка нижний границы таблицы
        /// </summary>
        /// <param name="tableSize">Размер таблицы</param>
        public static void PrintLowerBound(int tableSize)
        {
            Console.Write("└");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┴");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┴");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┴");
            Console.Write(new string('─', (tableSize / 4)));
            Console.WriteLine("┘");
        }

        /// <summary>
        /// Отрисовка верхней границы таблицы
        /// </summary>
        /// <param name="tableSize">Размер таблицы</param>
        public static void PrintUpperBound(int tableSize)
        {
            Console.Write("┌");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┬");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┬");
            Console.Write(new string('─', (tableSize / 4) - 1));
            Console.Write("┬");
            Console.Write(new string('─', (tableSize / 4)));
            Console.WriteLine("┐");
        }

        /// <summary>
        /// Отрисовка текста внутри таблицы
        /// </summary>
        /// <param name="tableSize">Размер таблицы</param>
        /// <param name="textInСolumnOne">Текст из первого столбца</param>
        /// <param name="textInСolumnTwo">Текст из второго столбца</param>
        /// <param name="textInСolumnThree">Текст из третьего столбца</param>
        /// <param name="textInСolumnFour">Текст из четвертого столбца</param>
        public static void PrintText(int tableSize, string textInСolumnOne, string textInСolumnTwo,
            string textInСolumnThree, string textInСolumnFour)
        {
            Console.Write($"│ {{0, {-tableSize + 77}}}", textInСolumnOne);
            Console.Write($"│ {{0, {-tableSize + 77}}}", textInСolumnTwo);
            Console.Write($"│ {{0, {-tableSize + 77}}}", textInСolumnThree);
            Console.WriteLine($"│ {{0, {-tableSize + 76}}}│", textInСolumnFour);
        }

        /// <summary>
        /// Преобразование <see cref="TypeOfBankAccount" /> в наиенование типа счета
        /// </summary>
        /// <param name="type">Тип счета</param>
        /// <returns></returns>
        public static string TypeOfBankAccountToString(TypeOfBankAccount type)
        {
            return type == TypeOfBankAccount.DepositAccount ? "Депозитный счет" :
                type == TypeOfBankAccount.PaymentAccount ? "Расчетный счет" :
                type == TypeOfBankAccount.CurrencyAccount ? "Валютный счет" : "-";
        }

        /// <summary>
        /// Вывод тыблицы с информацией о счетах
        /// </summary>
        /// <param name="tableSize">Размер таблицы</param>
        /// <param name="bankAccountOne">Первый счет</param>
        /// <param name="bankAccountTwo">Второй счет</param>
        /// <param name="bankAccountThree">Третий счет</param>
        public static void PrintAccountInfo(int tableSize, BankAccount bankAccountOne,
            BankAccount bankAccountTwo, BankAccount bankAccountThree)
        {
            PrintUpperBound(tableSize);
            PrintText(tableSize, "Номер счета", bankAccountOne.Number, bankAccountTwo.Number, bankAccountThree.Number);
            PrintText(tableSize, "Баланс", $"{bankAccountOne.Balance} у.е.", $"{bankAccountTwo.Balance} у.е.", $"{bankAccountThree.Balance} у.е.");
            PrintText(tableSize, "Тип банковского счета", TypeOfBankAccountToString(bankAccountOne.Type),
                TypeOfBankAccountToString(bankAccountTwo.Type), TypeOfBankAccountToString(bankAccountThree.Type));
            PrintLowerBound(tableSize);
        }
    }

    /// <summary>
    /// Счет в банке
    /// </summary>
    public class BankAccount
    {
        public BankAccount()
        {
            Number = (_number++).ToString("D8");
        }
        private static int _number = 1;
        public string Number { get; }

        public int Balance { get; set; }
        public TypeOfBankAccount Type { get; set; }

        /// <summary>
        /// Снять со счета
        /// </summary>
        /// <param name="sum">Сумма</param>
        public void WithdrawFromAccount(int sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                Console.WriteLine($"С счета '{Number}' списано {sum} у.е.");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств для списания {sum} у.е. со счета '{Number}'!\n" +
                    $"Текущий баланс: {Balance} у.е.");
            }
        }

        /// <summary>
        /// Положить на счет
        /// </summary>
        /// <param name="sum">Сумма</param>
        public void PutItOnAccount(int sum)
        {
            Balance += sum;
            Console.WriteLine($"Счет '{Number}' пополнен на {sum} у.е.");
        }

        /// <summary>
        /// Перевод денег с одного счета на другой
        /// </summary>
        /// <param name="sum">Сумма</param>
        /// <param name="fromBankAccount">Объект класса банковский счет откуда снимаются деньги</param>
        public void MoneyTransfer(int sum, BankAccount fromBankAccount)
        {
            if (fromBankAccount.Balance >= sum)
            {
                fromBankAccount.Balance -= sum;
                Balance += sum;
                Console.WriteLine($"С счета '{fromBankAccount.Number}' переведено {sum} у.е. на счет '{Number}'");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств для перевода {sum} у.е. со счета '{fromBankAccount.Number}'!\n" +
                    $"Текущий баланс: {fromBankAccount.Balance} у.е.");
            }
        }
    }

    public enum TypeOfBankAccount
    {
        /// <summary>
        /// Депозитный счет
        /// </summary>
        DepositAccount = 1,
        /// <summary>
        /// Расчетный счет
        /// </summary>
        PaymentAccount = 2,
        /// <summary>
        /// Валютный счет
        /// </summary>
        CurrencyAccount = 3
    }
}
