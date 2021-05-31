using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleBankingAppMvc
{
    // This is the MVC Model class
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

        // Methods
        public bool AssignAccountToCustomer(string accountUuid, string customerUuid)
        {
            // Check that account and customer exist
            int ai = -1;
            int ci = -1;

            ai = GetIndexFromAccountUuid(accountUuid);
            ci = GetIndexFromCustomerUuid(customerUuid);

            // If yes, assign account to user
            // (Note: One account can be assigned to several users!)
            if (ai != -1 && ci != -1)
            {
                customers[ci].accountNumbers.Add(accounts[ai].AccountNumber);
                return true;
            }
            return false;
        }

        public Customer AttemptToLoginCustomer(CustomerInput customerInput)
        {
            Customer customer = customers.FindLast(c => c.Name == customerInput.textField1 && c.Password == customerInput.textField2);

            return customer != null ? customer : null;
        }
        public string GenerateAccountNumber()
        {
            return (++nextValidAccountNumber).ToString();
        }

        public void CreateCustomer(string name, string password)
        {
            Customer newCustomer = new Customer(name, password);
            customers.Add(newCustomer);
        }

        public void CreateAccountForCustomer(string customerName, string accountDescription, double balance, double annualInterest)
        {
            // Check if customer exists
            Customer customer = customers.FindLast(c => c.Name == customerName);

            // If yes, create new account
            Account tempAccount = new Account(accountDescription, GenerateAccountNumber(), balance, annualInterest);

            // Add to accounts List
            accounts.Add(tempAccount);

            // Assign account to customer
            customer.accountNumbers.Add(tempAccount.AccountNumber);
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

        public int GetIndexFromAccountUuid(string accountUuid)
        {
            int index = -1;

            index = accounts.FindIndex(a => a.UUID == accountUuid);

            return index >= 0 ? index : -1;
        }
        public int GetIndexFromCustomerUuid(string userUuid)
        {
            int index = -1;

            index = customers.FindIndex(a => a.UUID == userUuid);

            return index >= 0 ? index : -1;
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
            // Serialize
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Save to file
            File.WriteAllText($@"Bank.json", json);
        }

        // Properties
        public int nextValidAccountNumber { get; set; }
        public Customer LoggedInCustomer { get; set; }
        public Account SelectedAccount { get; set; }
        public List<Account> LoggedInCustomerAccounts { get; set; }

        // Containers
        public List<Account> accounts { get; set; }
        public List<Customer> customers { get; set; }
    }
}
