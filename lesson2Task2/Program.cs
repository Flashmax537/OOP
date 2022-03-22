using System;
using System.Collections.Generic;

namespace lesson2Task2
{
    class Program
    {
        static void Main()
        {
            var bankAccounts = new List<BankAccount>();

            var bankAccount1 = new BankAccount();
            bankAccount1.SetBalance(100);
            bankAccount1.SetType(TypeOfBankAccount.DepositAccount);
            bankAccounts.Add(bankAccount1);

            var bankAccount2 = new BankAccount();
            bankAccount2.SetBalance(200);
            bankAccount2.SetType(TypeOfBankAccount.PaymentAccount);
            bankAccounts.Add(bankAccount2);

            var bankAccount3 = new BankAccount();
            bankAccount3.SetBalance(300);
            bankAccount3.SetType(TypeOfBankAccount.CurrencyAccount);
            bankAccounts.Add(bankAccount3);

            foreach (var account in bankAccounts)
            {
                Console.WriteLine($"Номер счета: {account.GetNumber()}\n" +
                    $"Баланс: {account.GetBalance()} у.е.\n" +
                    $"Тип банковского счета: {account.GetTypeOfBankAccount()}\n");
            }
        }
    }

    /// <summary>
    /// Счет в банке
    /// </summary>
    public class BankAccount
    {
        private static int _number = 1;
        private int Number = _number++;
        private int Balance;
        private TypeOfBankAccount Type;

        public string GetNumber()
        {
            return Number.ToString("D8"); ;
        }

        public int GetBalance()
        {
            return Balance;
        }

        public TypeOfBankAccount GetTypeOfBankAccount()
        {
            return Type;
        }

        public void SetBalance(int balance)
        {
            Balance = balance;
        }

        public void SetType(TypeOfBankAccount type)
        {
            Type = type;
        }
    }

    public enum TypeOfBankAccount
    {
        DepositAccount = 1, // Депозитный счет
        PaymentAccount = 2, // Расчетный счет
        CurrencyAccount = 3 // Валютный счет
    }
}
