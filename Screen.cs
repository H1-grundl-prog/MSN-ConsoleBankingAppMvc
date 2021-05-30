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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
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

        public CustomerInput ShowLoginScreen(List<Customer> customers)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);

            Console.SetCursorPosition(CursorX, CursorY);
            string nameString = " > Name:";
            string passwordString = " > Password:";

            Console.WriteLine(" > Please enter login credentials:");
            Console.WriteLine(" > ");
            Console.WriteLine(nameString);
            Console.WriteLine(passwordString);

            ShowMenu();
            ShowFooter();

            ShowCustomers(customers);

            // Customer input
            Console.CursorVisible = true;
            Console.SetCursorPosition(Constants.CURSOR_X_LOGIN, Constants.CURSOR_Y_LOGIN);

            CustomerInput customerInput = new CustomerInput();

            CursorY += 2;

            Console.SetCursorPosition(nameString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            CursorY++;

            Console.SetCursorPosition(passwordString.Length + 1, CursorY);
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowMainMenuScreen(Customer customer, List<Account> accounts)
        {
            // Display screen
            Console.CursorVisible = false;
            InitScreen();
            ShowHeader(ActiveScreen);

            Console.WriteLine($" > Bank accounts:\n");
            int i = 1;
            foreach (Account account in accounts)
            {
                Console.WriteLine($"({i})\t{account.Description}");
                i++;
            }

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, Account SelectedAccount)
        {
            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);

            Console.WriteLine($"{SelectedAccount.Description}, {SelectedAccount.Balance}, {SelectedAccount.AnnualInterest}, {SelectedAccount.AccountNumber}");

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

        public CustomerInput ShowDepositScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);

            Console.SetCursorPosition(CursorX, CursorY);
            string depositString = $"> Deposit amount:";

            Console.WriteLine(depositString);

            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(depositString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            Console.CursorVisible = false;

            //customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowWithdrawScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            Console.CursorVisible = true;
            InitScreen();
            ShowHeader(ActiveScreen);

            Console.SetCursorPosition(CursorX, CursorY);
            string withdrawString = $"> Withdraw amount:";

            Console.WriteLine(withdrawString);

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(withdrawString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            Console.CursorVisible = false;

            //customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }
        
        public void ShowCustomers(List<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            
            int n = 1;
            Console.WriteLine(" Choose Customer:\n");
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"({n}) Name: {customer.Name}, Password: { customer.Password}");
                n++;
            }
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
                    Console.WriteLine("              >>  B U I L D I N G   B E T T E R   W O R L D S  <<               ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(" > Welcome to the Weyland-Yutani banking service.                               ");

                    break;

                default:

                    Console.WriteLine("                    W E Y L A N D  -  Y U T A N I   C O R P                     ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine("              >>  B U I L D I N G   B E T T E R   W O R L D S  <<               ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
                    break;

            }
        }

        public void ShowFooter()
        {

            Console.SetCursorPosition( Constants.CURSOR_X_FOOTER, Constants.CURSOR_Y_FOOTER );
            Console.WriteLine(new string(' ', Constants.WINDOW_WIDTH));
            Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
        }

        public void ShowMenu()
        {
            Console.SetCursorPosition(Constants.CURSOR_X_MENU, Constants.CURSOR_Y_MENU);

            switch (ActiveScreen)
            {
                case Screens.WelcomeScreen:

                    Console.WriteLine(" (L) Login menu");
                    break;

                case Screens.LoginScreen:

                    Console.WriteLine(" (E) Exit");
                    break;

                case Screens.MainMenuScreen:

                    Console.WriteLine(" (E) Exit - (L) Logout - (1-9) Account");
                    break;

                case Screens.AccountScreen:

                    Console.WriteLine(" (E) Exit - (L) Logout - (M) Main menu - (D) Deposit - (W) Withdraw");
                    break;

                case Screens.CreateAccountScreen:

                    break;

                case Screens.DepositScreen:

                    //Console.WriteLine(" (E) Exit - (L) Logout - (M) Main menu - (A) Account");
                    break;

                case Screens.WithdrawScreen:

                    //Console.WriteLine(" (E) Exit - (L) Logout - (M) Main menu - (A) Account");
                    break;

                default:
                    break;
            }
        }

        // Properties
        public Screens ActiveScreen { get; set; }
    }
}
