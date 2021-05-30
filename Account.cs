using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{
    public class Account
    {
        // Constructors
        public Account() { }

        public Account(string accountNumber)
        {
            Description = "";
            AccountNumber = accountNumber;
            AnnualInterest = 0.0;
            Balance = 0.0;
            UUID = Guid.NewGuid().ToString();
        }
        public Account(string description, string accountNumber)
        {
            Description = description;
            AccountNumber = accountNumber;
            AnnualInterest = 0.0f;
            Balance = 0.0f;
            UUID = Guid.NewGuid().ToString();
        }

        public Account(string description, string accountNumber, double balance, double annualInterest)
        {
            Description = description;
            AccountNumber = accountNumber;
            AnnualInterest = annualInterest;
            Balance = balance;
            UUID = Guid.NewGuid().ToString();
        }

        // Methods
        public double ComputeFutureBalance(int years)
        {
            return Balance * Math.Pow(1 + AnnualInterest, years);
        }

        // roperties
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public double AnnualInterest { get; set; } // Rentesats i %
        public double Balance { get; set; }
        public string UUID { get; set; }
    }
}
