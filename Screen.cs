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
            ActiveScreen = Screens.WelcomeScreen;
            
            Console.WriteLine("Welcome!");

            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowLoginScreen()
        {
            ActiveScreen = Screens.LoginScreen;

            Console.WriteLine("Login");

            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowMainMenuScreen(Customer customer, List<Account> accounts)
        {
            ActiveScreen = Screens.MainMenuScreen;

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

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, List<Account> accounts)
        {
            ActiveScreen = Screens.AccountScreen;

            Console.WriteLine("Accounts");

            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public Screens ActiveScreen { get; set; }

        public Bank bank;
    }
}
