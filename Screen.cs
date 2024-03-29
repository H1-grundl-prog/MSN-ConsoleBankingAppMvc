﻿using System;
using System.Collections.Generic;

namespace ConsoleBankingAppMvc
{
    // This is the MVC View class
    public class Screen
    {
        // Constructors
        public Screen() { }

        // Methods
        public void InitScreen()
        {
            // Initial tasks for all screens
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "Weyland-Yutani Corp - >> Building Better Worlds << - Interplanetary Banking System";
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
            ShowLoggedInCustomerName(null);

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
            CustomerInput customerInput = new CustomerInput();

            CursorX = Constants.CURSOR_X_LOGIN;
            CursorY = Constants.CURSOR_Y_LOGIN;

            Console.SetCursorPosition(nameString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            CursorY++;

            Console.SetCursorPosition(passwordString.Length + 1, CursorY);
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowMainMenuScreen(Customer customer, List<Account> accounts)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            Console.CursorVisible = false;

            Console.WriteLine($" > Choose bank account:");
            Console.WriteLine($" > ");
            int i = 1;
            foreach (Account account in accounts)
            {
                Console.WriteLine($" > ({i})\t{account.Description}");
                i++;
            }

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            customerInput.keyPress = Console.ReadKey(false);

            return customerInput;
        }

        public CustomerInput ShowAccountScreen(Customer customer, Account SelectedAccount, List<Customer> customersWithAccess)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);

            string descriptStr = "Description";
            string balanceStr = "Balance";
            string interestStr = "Interest (%)";
            string accountStr = "Account No.";

            string outputHeader = String.Format(" > {0,17}{1,21}{2,19}{3,19}", descriptStr, balanceStr, interestStr, accountStr);
            string outputAccount = String.Format(" > {0,17}{1,21:n2}{2,19:n1}{3,19}", SelectedAccount.Description, SelectedAccount.Balance, SelectedAccount.AnnualInterest, SelectedAccount.AccountNumber);

            Console.WriteLine(outputHeader);
            Console.WriteLine(" > ");
            Console.WriteLine(outputAccount);

            ShowCustomersWithAccess(customersWithAccess);

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
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string nameString = " > Account description:";

            Console.WriteLine(nameString);

            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(nameString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowCreateCustomerScreen()
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(null);

            Console.SetCursorPosition(CursorX, CursorY);
            string nameString = " > Name:";
            string passwordString = " > Password:";

            Console.WriteLine(" > Create customer.");
            Console.WriteLine(" > ");
            Console.WriteLine(" > Please enter new customer login credentials:");
            Console.WriteLine(" > ");
            Console.WriteLine(nameString);
            Console.WriteLine(passwordString);

            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;
            Console.SetCursorPosition(Constants.CURSOR_X_LOGIN, Constants.CURSOR_Y_LOGIN);

            CustomerInput customerInput = new CustomerInput();

            CursorY += 4;

            Console.SetCursorPosition(nameString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            CursorY++;

            Console.SetCursorPosition(passwordString.Length + 1, CursorY);
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowDeleteCustomerScreen()
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(null);

            Console.SetCursorPosition(CursorX, CursorY);
            string nameString = " > Name:";
            string passwordString = " > Password:";

            Console.WriteLine(" > Delete customer.");
            Console.WriteLine(" > ");
            Console.WriteLine(" > Please enter customer login credentials:");
            Console.WriteLine(" > ");
            Console.WriteLine(nameString);
            Console.WriteLine(passwordString);

            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;
            Console.SetCursorPosition(Constants.CURSOR_X_LOGIN, Constants.CURSOR_Y_LOGIN);

            CustomerInput customerInput = new CustomerInput();

            CursorY += 4;

            Console.SetCursorPosition(nameString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            CursorY++;

            Console.SetCursorPosition(passwordString.Length + 1, CursorY);
            customerInput.textField2 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowDepositScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string depositString = $" > Deposit amount:";

            Console.WriteLine(depositString);

            ShowMenu();
            ShowFooter();

            // Customer input
            Console.CursorVisible = true;

            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(depositString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

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
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string withdrawString = $" > Withdraw amount:";

            Console.WriteLine(withdrawString);

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(withdrawString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowTransferScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            Console.CursorVisible = true;
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string withdrawString = $" > Transfer amount:";

            Console.WriteLine(withdrawString);

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(withdrawString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowGrantAccessScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            Console.CursorVisible = true;
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string accessString = $" > Give account access to customer:";

            Console.WriteLine(accessString);

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(accessString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

            return customerInput;
        }

        public CustomerInput ShowRemoveAccessScreen(Customer customer, Account account)
        {
            int CursorX = Constants.CURSOR_X_DEFAULT;
            int CursorY = Constants.CURSOR_Y_DEFAULT;

            // Display screen
            Console.CursorVisible = true;
            InitScreen();
            ShowHeader(ActiveScreen);
            ShowLoggedInCustomerName(customer);

            Console.SetCursorPosition(CursorX, CursorY);
            string accessString = $" > Remove account access from customer:";

            Console.WriteLine(accessString);

            ShowMenu();
            ShowFooter();

            // Customer input
            CustomerInput customerInput = new CustomerInput();

            Console.SetCursorPosition(accessString.Length + 1, CursorY);
            customerInput.textField1 = Console.ReadLine();

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

        public void ShowCustomersWithAccess(List<Customer> customers)
        {
            Console.WriteLine(" > ");
            Console.WriteLine(" > ");
            Console.WriteLine(" > Customers with access to this account:");
            Console.WriteLine(" > ");

            foreach (Customer customer in customers)
            {
                Console.WriteLine($" > {customer.Name}");
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
                    Console.WriteLine(" >                                                                              ");
                    Console.WriteLine(" > Welcome to the Weyland-Yutani interplanetary banking system.                 ");

                    break;

                default:

                    Console.WriteLine("                    W E Y L A N D  -  Y U T A N I   C O R P                     ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine("                          B A N K I N G   S Y S T E M                           ");
                    Console.WriteLine("                                                                                ");
                    Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
                    break;

            }
        }

        public void ShowFooter()
        {
            Console.SetCursorPosition(Constants.CURSOR_X_FOOTER, Constants.CURSOR_Y_FOOTER);
            Console.WriteLine(new string(' ', Constants.WINDOW_WIDTH));
            Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
        }

        public void ShowLoggedInCustomerName(Customer customer)
        {
            Console.SetCursorPosition(Constants.CURSOR_X_LOGGEDINUSER, Constants.CURSOR_Y_LOGGEDINUSER);

            if (customer == null)
            {
                Console.WriteLine("");
                Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
            }
            else
            {
                Console.WriteLine($" Logged in as: {customer.Name}");
                Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));
            }
        }

        public void ShowMenu()
        {
            Console.SetCursorPosition(Constants.CURSOR_X_MENU, Constants.CURSOR_Y_MENU);

            Console.WriteLine(new string('*', Constants.WINDOW_WIDTH));

            switch (ActiveScreen)
            {
                case Screens.WelcomeScreen:

                    Console.WriteLine(" (E)xit - (L)ogin\n");
                    Console.WriteLine(" (N)ew customer - (D)elete customer");
                    break;

                case Screens.LoginScreen:

                    break;

                case Screens.MainMenuScreen:

                    Console.WriteLine(" (E)xit - (L)ogout\n");
                    Console.WriteLine(" (N)ew account - (D)elete account - (1-9) Account details");
                    break;

                case Screens.AccountScreen:

                    Console.WriteLine(" (E)xit - (L)ogout - (M)ain menu\n");
                    Console.WriteLine(" (D)eposit - (W)ithdraw - (T)ransfer - (G)ive access - (R)emove access");
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

    public enum Screens
    {
        WelcomeScreen,
        LoginScreen,
        MainMenuScreen,
        AccountScreen,
        CreateAccountScreen,
        DeleteAccountScreen,
        CreateCustomerScreen,
        DeleteCustomerScreen,
        DepositScreen,
        WithdrawScreen,
        TransferScreen,
        GiveAccessScreen,
        RemoveAccessScreen
    }
}
