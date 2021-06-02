using System;

namespace ConsoleBankingAppMvc
{
    // This is the MVC controller class.
    public class Controller
    {
        public Controller(Bank bank, Screen screen)
        {
            model = bank;
            view = screen;
        }

        // Methods
        public void RunProgram()
        {
            ProgramInit();
            ProgramMainLoop();
            ProgramShutDown();
        }

        public void ProgramInit()
        {
            // Only run for first-time setup
            //SetupCustomersAndAccounts();
            //model.SaveBankToFile();

            model.LoadBankFromFile();

            Console.SetWindowSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);
            Console.SetBufferSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);
            Console.SetWindowPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.CursorVisible = false;

            view.ActiveScreen = Screens.WelcomeScreen;
        }

        public void ProgramMainLoop()
        {
            while (true)
            {

                // Show screens and execute tasks based on customer input
                switch (view.ActiveScreen)
                {
                    case Screens.WelcomeScreen:

                        CustomerInput = view.ShowWelcomeScreen();

                        switch (CustomerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;

                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.LoginScreen;
                                break;

                            case ConsoleKey.N:
                                view.ActiveScreen = Screens.CreateCustomerScreen;
                                break;
                        }

                        break;

                    case Screens.LoginScreen:

                        CustomerInput = view.ShowLoginScreen(model.Customers);

                        model.SelectedAccount = null;
                        model.LoggedInCustomer = null;
                        model.LoggedInCustomerAccounts = null;

                        model.LoggedInCustomer = model.AttemptToLoginCustomer(CustomerInput);

                        if (model.LoggedInCustomer != null)
                        {
                            model.LoggedInCustomerAccounts = model.GetCustomerAccountList(model.LoggedInCustomer);

                            view.ActiveScreen = Screens.MainMenuScreen;
                        }

                        switch (CustomerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;
                        }

                        break;

                    case Screens.MainMenuScreen:

                        model.SelectedAccount = null;

                        CustomerInput = view.ShowMainMenuScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);


                        int numAccounts = model.LoggedInCustomerAccounts.Count;

                        switch (CustomerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;

                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.WelcomeScreen;
                                break;

                            case ConsoleKey.N:
                                view.ActiveScreen = Screens.CreateAccountScreen;
                                break;

                            case ConsoleKey.D1:

                                view.ActiveScreen = Screens.AccountScreen;
                                if (numAccounts >= 0)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[0];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                break;

                            case ConsoleKey.D2:
                                if (numAccounts >= 1)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[1];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                view.ActiveScreen = Screens.AccountScreen;
                                break;

                            case ConsoleKey.D3:
                                if (numAccounts >= 2)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[2];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                view.ActiveScreen = Screens.AccountScreen;
                                break;

                            case ConsoleKey.D4:
                                if (numAccounts >= 3)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[3];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                view.ActiveScreen = Screens.AccountScreen;
                                break;

                            case ConsoleKey.D5:
                                if (numAccounts >= 4)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[4];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                view.ActiveScreen = Screens.AccountScreen;
                                break;

                            case ConsoleKey.D6:
                                if (numAccounts >= 5)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[5];
                                }
                                else
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen;
                                }
                                view.ActiveScreen = Screens.AccountScreen;
                                break;
                        }

                        break;

                    case Screens.AccountScreen:

                        CustomerInput = view.ShowAccountScreen(model.LoggedInCustomer, model.SelectedAccount);

                        switch (CustomerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;

                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.WelcomeScreen;
                                break;

                            case ConsoleKey.M:
                                view.ActiveScreen = Screens.MainMenuScreen;
                                break;

                            case ConsoleKey.D:
                                view.ActiveScreen = Screens.DepositScreen;
                                break;

                            case ConsoleKey.W:
                                view.ActiveScreen = Screens.WithdrawScreen;
                                break;

                            case ConsoleKey.G:
                                view.ActiveScreen = Screens.GiveAccessScreen;
                                break;
                        }

                        break;

                    case Screens.CreateAccountScreen:

                        CustomerInput = view.ShowCreateAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

                        model.CreateAccountForCustomer(model.LoggedInCustomer.Name, CustomerInput.textField1, 0.0, 0.0);

                        model.SaveBankToFile();

                        model.LoggedInCustomerAccounts = model.GetCustomerAccountList(model.LoggedInCustomer);

                        view.ActiveScreen = Screens.MainMenuScreen;

                        break;

                    case Screens.CreateCustomerScreen:

                        CustomerInput = view.ShowCreateCustomerScreen();

                        model.CreateCustomer(CustomerInput.textField1, CustomerInput.textField2);

                        model.SaveBankToFile();

                        view.ActiveScreen = Screens.WelcomeScreen;

                        break;

                    case Screens.DepositScreen:

                        CustomerInput = view.ShowDepositScreen(model.LoggedInCustomer, model.SelectedAccount);

                        double depositAmount = double.Parse(CustomerInput.textField1);

                        if (depositAmount >= 0.0)
                        {
                            model.SelectedAccount.Balance += depositAmount;

                            model.SaveBankToFile();
                        }

                        view.ActiveScreen = Screens.AccountScreen;

                        break;

                    case Screens.WithdrawScreen:

                        CustomerInput = view.ShowWithdrawScreen(model.LoggedInCustomer, model.SelectedAccount);

                        double withdrawAmount = double.Parse(CustomerInput.textField1);

                        if (withdrawAmount >= 0.0 && withdrawAmount <= model.SelectedAccount.Balance)
                        {
                            model.SelectedAccount.Balance -= withdrawAmount;

                            model.SaveBankToFile();
                        }

                        view.ActiveScreen = Screens.AccountScreen;

                        break;
                    
                    case Screens.GiveAccessScreen:

                        CustomerInput = view.ShowGrantAccessScreen(model.LoggedInCustomer, model.SelectedAccount);

                        string accountUuid = model.SelectedAccount.UUID;

                        Customer grantedCustomer = model.Customers.FindLast(c => c.Name == CustomerInput.textField1);

                        string customerUuid = grantedCustomer.UUID;

                        model.AssignAccountToCustomer(accountUuid, customerUuid);

                        view.ActiveScreen = Screens.AccountScreen;

                        break;

                    default:

                        break;
                }
            }
        }

        public void ProgramShutDown()
        {
            model.SaveBankToFile();
            Console.ResetColor();
            Console.Clear();
            Environment.Exit(0);
        }

        public void SetupCustomersAndAccounts()
        {
            // First-time setup of customers and accounts

            // Customers
            model.CreateCustomer("Arthur Dallas", "1234");
            model.CreateCustomer("Ellen Ripley", "1234");
            model.CreateCustomer("Joan Lambert", "1234");
            model.CreateCustomer("Samuel Brett", "1234");
            model.CreateCustomer("Gilbert Kane", "1234");
            model.CreateCustomer("Dennis Parker", "1234");
            model.CreateCustomer("Ash", "1234");

            // Accounts
            model.CreateAccountForCustomer("Arthur Dallas", "Payroll", 27000.00, 0.0);
            model.CreateAccountForCustomer("Ellen Ripley", "Payroll", 12000.00, 0.0);
            model.CreateAccountForCustomer("Joan Lambert", "Payroll", 7000.00, 0.0);
            model.CreateAccountForCustomer("Samuel Brett", "Payroll", 11000.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane", "Payroll", 16035.00, 0.0);
            model.CreateAccountForCustomer("Dennis Parker", "Payroll", -87000.00, 0.0);

            model.CreateAccountForCustomer("Arthur Dallas", "Bonus", 4000.00, 0.0);
            model.CreateAccountForCustomer("Ellen Ripley", "Bonus", 3000.00, 0.0);
            model.CreateAccountForCustomer("Joan Lambert", "Bonus", 2000.00, 0.0);
            model.CreateAccountForCustomer("Samuel Brett", "Bonus", 0.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane", "Bonus", 2000.00, 0.0);
            model.CreateAccountForCustomer("Dennis Parker", "Bonus", 0.00, 0.0);

            model.CreateAccountForCustomer("Arthur Dallas", "Air duct cleanup", 200.00, 0.2);
            model.CreateAccountForCustomer("Ellen Ripley", "Savings Amanda", 27005.00, 0.5);
            model.CreateAccountForCustomer("Joan Lambert", "Surgery", 7000.00, 0.4);
            model.CreateAccountForCustomer("Samuel Brett", "Right!", 22000.00, 0.6);
            model.CreateAccountForCustomer("Ash", "Maintenance", 11000.00, 0.0);
            model.CreateAccountForCustomer("Ash", "Bribe", 150000.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane", "Child support", 2000.00, 0.3);
            model.CreateAccountForCustomer("Dennis Parker", "Vacation", 12000.00, 0.1);
        }

        // Properties
        public CustomerInput CustomerInput { get; set; }

        // Fields
        public Bank model;
        public Screen view;
    }
}
