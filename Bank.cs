using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleBankingAppMvc
{
    public class Bank
    {
        // Constructors
        public Bank()
        {
            nextValidAccountNumber = 1234567890;

            LoggedInCustomer = null;

            accounts = new List<Account>();
            customers = new List<Customer>();
        }

        // Destructor


        // Methods
        public Customer AttemptToLoginCustomer(CustomerInput customerInput)
        {
            Customer customer = customers.FindLast(c => c.Name == customerInput.textField1 && c.Password == customerInput.textField2);

            return customer != null ? customer : null;
        }
        public string GenerateAccountNumber()
        {
            return (++nextValidAccountNumber).ToString();
        }

        public List<Account> GetCustomerAccountList(Customer customer)
        {
            // Get list of account numbers from customer
            List<string> accountNumbers = customer.accountNumbers;

            List<Account> accountList = new List<Account>();

            // Get list of Accounts assigned to customer
            foreach (string accountNumber in accountNumbers)
            {
                accountList.Add(accounts.FindLast(a => a.AccountNumber == accountNumber));
            }

            return accountList;
        }

        public void LoadBankFromFile()
        {
            // Load from file
            string json = File.ReadAllText($@"Bank.json");

            // Deserialize
            Bank tempBank = JsonConvert.DeserializeObject<Bank>(json);

            // Assign
            this.nextValidAccountNumber = tempBank.nextValidAccountNumber;

            this.accounts = tempBank.accounts;
            this.customers = tempBank.customers;
        }

        public void SaveBankToFile()
        {
            // 
            LoggedInCustomer = null;

            // Serialize
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Save to file
            File.WriteAllText($@"Bank.json", json);
        }

        // Properties
        public int nextValidAccountNumber { get; set; }
        public Customer LoggedInCustomer { get; set; }
        public List<Account> LoggedInCustomerAccounts { get; set; }

        // Containers
        public List<Account> accounts { get; set; }
        public List<Customer> customers { get; set; }
    }
}
