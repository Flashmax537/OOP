using System;

namespace lesson2Task5
{
    class Program
    {
        static void Main()
        {
            var bankAccount = new BankAccount();
            bankAccount.Balance = 100;
            bankAccount.Type = TypeOfBankAccount.DepositAccount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("До изменений.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Номер счета: {bankAccount.Number}\n" +
                $"Баланс: {bankAccount.Balance} у.е.\n" +
                $"Тип банковского счета: {bankAccount.Type}\n");
            bankAccount.PutItOnAccount(500);
            bankAccount.WithdrawFromAccount(550);
            bankAccount.WithdrawFromAccount(100); 
        }
    }

    /// <summary>
    /// Счет в банке
    /// </summary>
    public class BankAccount
    {
        private static int _number = 1;
        public string Number { get { return (_number++).ToString("D8"); } }

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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"После снятия с баланса {sum} у.е.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"Номер счета: {Number}\n" +
                    $"Баланс: {Balance} у.е.\n" +
                    $"Тип банковского счета: {Type}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Не удалось снять сумму: {sum} у.е.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Недостаточно средств на счете!\n" +
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"После пополнения баланса на {sum} у.е.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Номер счета: {Number}\n" +
                $"Баланс: {Balance} у.е.\n" +
                $"Тип банковского счета: {Type}\n");
        }
    }

    public enum TypeOfBankAccount
    {
        DepositAccount = 1, // Депозитный счет
        PaymentAccount = 2, // Расчетный счет
        CurrencyAccount = 3 // Валютный счет
    }
}
