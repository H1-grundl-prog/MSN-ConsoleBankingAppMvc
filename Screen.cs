using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{

    public class Screen
    {
        public Screen() 
        {
            ActiveScreen = Screens.WelcomeScreen;
        }

        public CustomerInput ShowWelcomeScreen()
        {
            
            Console.WriteLine("Welcome!");

            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowLoginScreen()
        {

            Console.WriteLine("Login");

            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowMainMenuScreen(Customer customer, List<Account> accounts)
        {

            Console.WriteLine("Main menu");

            Console.CursorVisible = false;

            

            Console.WriteLine($"\tDescription\t\tBalance");
            int i = 1;
            foreach (Account account in accounts)
            {
                Console.WriteLine($"({i})\t{account.Description}\t\t{account.Balance}");
                i++;
            }

            CustomerInput customerInput = new CustomerInput();

            ConsoleKeyInfo key = Console.ReadKey(false);

            if (char.IsDigit(key.KeyChar))
            {
                //customerInput.keyPress = int.Parse(key.KeyChar.ToString());
            }

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, List<Account> accounts)
        {

            Console.WriteLine("Accounts");

            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowCreateAccountScreen(Customer customer, List<Account> accounts)
        {

            Console.WriteLine("Create new account:");

            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public Screens ActiveScreen { get; set; }
    }
}
