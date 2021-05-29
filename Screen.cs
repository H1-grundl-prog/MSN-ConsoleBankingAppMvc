using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{

    public class Screen
    {
        public Screen() { }

        public CustomerInput ShowWelcomeScreen()
        {
            // Display screen
            Console.WriteLine("Welcome!");

            // Customer input
            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowLoginScreen()
        {
            // Display screen
            Console.WriteLine("Login");

            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowMainMenuScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            Console.WriteLine("Main menu");

            Console.CursorVisible = false;

            

            Console.WriteLine($"\tDescription\t\tBalance");
            int i = 1;
            foreach (Account account in accounts)
            {
                Console.WriteLine($"({i})\t{account.Description}\t\t{account.Balance}");
                i++;
            }

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            Console.WriteLine("Accounts");

            // Customer input
            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowCreateAccountScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            Console.WriteLine("Create new account:");


            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowDepositScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            Console.WriteLine("Deposit:");

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowWithdrawScreen(Customer customer, List<Account> accounts)
        {
            ShowHeader(ActiveScreen);

            // Display screen
            Console.WriteLine("Withdraw:");

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public void ShowHeader(Screens screen)
        {

        }

        public void ShowFooter(Screens screen)
        {

        }

        public void ShowMenu(Screens screen)
        {

        }

        public Screens ActiveScreen { get; set; }
    }
}
