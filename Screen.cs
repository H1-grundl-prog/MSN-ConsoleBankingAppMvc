using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{

    public class Screen
    {
        public Screen() { }

        public void InitScreen()
        {
            Console.Clear();
        }

        public CustomerInput ShowWelcomeScreen()
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowLoginScreen()
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

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
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            Console.CursorVisible = false;

            

            Console.WriteLine($"\tDescription\t\tBalance");
            int i = 1;
            foreach (Account account in accounts)
            {
                Console.WriteLine($"({i})\t{account.Description}\t\t{account.Balance}");
                i++;
            }

            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = false;

            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowCreateAccountScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowDepositScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowWithdrawScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public void ShowHeader(Screens screen)
        {
            Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
            //Console.WriteLine(new string(' ', Constants.WINDOW_WIDTH));

            switch (screen)
            {
                case Screens.WelcomeScreen:

                    Console.WriteLine("                    W E Y L A N D  -  Y U T A N I   C O R P                     ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine("  ▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒  ");
                    Console.WriteLine("  ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒  ");
                    Console.WriteLine("    ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒    ");
                    Console.WriteLine("      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒      ");
                    Console.WriteLine("        ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒▒   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒        ");
                    Console.WriteLine("          ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒          ");
                    Console.WriteLine("            ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒            ");
                    Console.WriteLine("              ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒              ");
                    Console.WriteLine("                ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   ▓▓▓▓▓▓▓▓▓▓▓▓▓   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒                ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine("               >>  B U I L D I N G   B E T T E R   B A N K S  <<                ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(" > Please insert credit card.                                                   ");
                    break;

                default:

                    Console.WriteLine("                    W E Y L A N D  -  Y U T A N I   C O R P                     ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine("               >>  B U I L D I N G   B E T T E R   B A N K S  <<                ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
                    break;

            }
        }

        public void ShowFooter()
        {
            Console.WriteLine(new string(' ', Constants.WINDOW_WIDTH));
            Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
        }

        public void ShowMenu()
        {
            switch(ActiveScreen)
            {
                case Screens.WelcomeScreen:

                    break;

                case Screens.LoginScreen:

                    break;

                case Screens.MainMenuScreen:

                    break;

                case Screens.AccountScreen:

                    break;

                case Screens.CreateAccountScreen:

                    break;

                case Screens.DepositScreen:

                    break;

                case Screens.WithdrawScreen:

                    break;

                default:
                    break;
            }
        }

        // Properties
        public Screens ActiveScreen { get; set; }
    }
}
