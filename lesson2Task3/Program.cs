using System;
using System.Collections.Generic;

namespace lesson2Task3
{
    class Program
    {
        static void Main()
        {
            var bankAccounts = new List<BankAccount>();

            var bankAccount1 = new BankAccount();
            bankAccounts.Add(bankAccount1);

            var bankAccount2 = new BankAccount(balance: 100);
            bankAccounts.Add(bankAccount2);

            var bankAccount3 = new BankAccount(type: TypeOfBankAccount.DepositAccount);
            bankAccounts.Add(bankAccount3);

            var bankAccount4 = new BankAccount(200, TypeOfBankAccount.PaymentAccount);
            bankAccounts.Add(bankAccount4);

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
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public BankAccount()
        {
            Number = _number++;
            Balance = 0;
            Type = TypeOfBankAccount.OtherAccount;
        }

        /// <summary>
        /// Конструктор для заполнения поля баланс
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(int balance)
        {
            Number = _number++;
            Balance = balance;
            Type = TypeOfBankAccount.OtherAccount;
        }

        /// <summary>
        /// Конструктор для заполнения поля тип банковского счета
        /// </summary>
        /// <param name="type"></param>
        public BankAccount(TypeOfBankAccount type)
        {
            Number = _number++;
            Balance = 0;
            Type = type;
        }

        /// <summary>
        /// Конструктор для заполнения баланса и типа банковского счета
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="type"></param>
        public BankAccount(int balance, TypeOfBankAccount type)
        {
            Number = _number++;
            Balance = balance;
            Type = type;
        }

        private static int _number = 1;
        private int Number;
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

    }

    public enum TypeOfBankAccount
    {
        DepositAccount = 1, // Депозитный счет
        PaymentAccount = 2, // Расчетный счет
        CurrencyAccount = 3, // Валютный счет
        OtherAccount = 4 // Другое
    }
}
