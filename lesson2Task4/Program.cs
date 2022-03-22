using System;
using System.Collections.Generic;

namespace lesson2Task4
{
    class Program
    {
        static void Main()
        {
            var bankAccounts = new List<BankAccount>();

            var bankAccount1 = new BankAccount();
            bankAccount1.Balance = 100;
            bankAccount1.Type = TypeOfBankAccount.DepositAccount;
            bankAccounts.Add(bankAccount1);

            var bankAccount2 = new BankAccount();
            bankAccount2.Balance = 200;
            bankAccount2.Type = TypeOfBankAccount.PaymentAccount;
            bankAccounts.Add(bankAccount2);

            var bankAccount3 = new BankAccount();
            bankAccount3.Balance = 300;
            bankAccount3.Type = TypeOfBankAccount.CurrencyAccount;
            bankAccounts.Add(bankAccount3);

            foreach (var account in bankAccounts)
            {
                Console.WriteLine($"Номер счета: {account.Number}\n" +
                    $"Баланс: {account.Balance} у.е.\n" +
                    $"Тип банковского счета: {account.Type}\n");
            }
        }
    }

    /// <summary>
    /// Счет в банке
    /// </summary>
    public class BankAccount
    {
        private static int _number = 1;
        public string Number { get { return (_number++).ToString("D8"); ; } }

        public int Balance { get; set; }
        public TypeOfBankAccount Type { get; set; }
    }

    public enum TypeOfBankAccount
    {
        DepositAccount = 1, // Депозитный счет
        PaymentAccount = 2, // Расчетный счет
        CurrencyAccount = 3 // Валютный счет
    }
}
