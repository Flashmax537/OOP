using System;

namespace lesson6Task1
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
                Balance = 100,
                Type = TypeOfBankAccount.CurrencyAccount
            };
            var bankAccountThree = new BankAccount()
            {
                Balance = 100,
                Type = TypeOfBankAccount.CurrencyAccount
            };

            Console.WriteLine($"Счет №{bankAccountOne.Number} == Счет №{bankAccountThree.Number}: {bankAccountOne == bankAccountThree}");
            Console.WriteLine($"Счет №{bankAccountTwo.Number} == Счет №{bankAccountThree.Number}: {bankAccountTwo == bankAccountThree}");
            Console.WriteLine($"Счет №{bankAccountOne.Number} != Счет №{bankAccountThree.Number}: {bankAccountOne != bankAccountThree}");
            Console.WriteLine($"Счет №{bankAccountTwo.Number} != Счет №{bankAccountThree.Number}: {bankAccountTwo != bankAccountThree}");
            Console.WriteLine();
            Console.WriteLine($"(Счет №{bankAccountOne.Number}).Equals(Счет №{bankAccountThree.Number}): {bankAccountOne.Equals(bankAccountThree)}");
            Console.WriteLine($"(Счет №{bankAccountTwo.Number}).Equals(Счет №{bankAccountThree.Number}): {bankAccountTwo.Equals(bankAccountThree)}");
            Console.WriteLine();
            Console.WriteLine($"(Счет №{bankAccountOne.Number}).GetHashCode(): {bankAccountOne.GetHashCode()}");
            Console.WriteLine($"(Счет №{bankAccountTwo.Number}).GetHashCode(): {bankAccountTwo.GetHashCode()}");
            Console.WriteLine($"(Счет №{bankAccountThree.Number}).GetHashCode(): {bankAccountThree.GetHashCode()}");
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

        public static bool operator ==(BankAccount bankAccountOne, BankAccount bankAccountTwo)
        {
            return bankAccountOne.Balance == bankAccountTwo.Balance && bankAccountOne.Type == bankAccountTwo.Type;
        }

        public static bool operator !=(BankAccount bankAccountOne, BankAccount bankAccountTwo)
        {
            return bankAccountOne.Balance != bankAccountTwo.Balance && bankAccountOne.Type != bankAccountTwo.Type;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BankAccount);
        }

        public bool Equals(BankAccount bankAccount)
        {
            return bankAccount.Balance == Balance && bankAccount.Type == Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Balance, Type);
        }

        public override string ToString()
        {
            return $"Номер счета: {Number}\n" +
                $"Баланс: {Balance}\n" +
                $"Тип банковского счета: {Type}";
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
