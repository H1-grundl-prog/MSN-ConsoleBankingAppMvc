using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

            //SetupCustomersAndAccounts(); // Only run once
        }

        public void ProgramMainLoop()
        {
            while(true)
            {

                // Show screens and execute tasks based on customer input
                switch (view.ActiveScreen)
                {
                    case Screens.WelcomeScreen:
                        customerInput = view.ShowWelcomeScreen();

                        switch (customerInput.keyPress.Key)
                        {
                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.LoginScreen;
                                break;
                        }

                        break;

                    case Screens.LoginScreen :
                        customerInput = view.ShowLoginScreen(model.customers);

                        model.SelectedAccount = null;
                        model.LoggedInCustomer = null;
                        model.LoggedInCustomerAccounts = null;

                        model.LoggedInCustomer = model.AttemptToLoginCustomer(customerInput);

                        if (model.LoggedInCustomer != null)
                        {
                            model.LoggedInCustomerAccounts = model.GetCustomerAccountList(model.LoggedInCustomer);

                            view.ActiveScreen = Screens.MainMenuScreen;
                        }
                        
                        switch (customerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;
                        }

                        break;

                    case Screens.MainMenuScreen :

                        model.SelectedAccount = null;

                        customerInput = view.ShowMainMenuScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);


                        int numAccounts = model.LoggedInCustomerAccounts.Count;

                        switch (customerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;

                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.WelcomeScreen;
                                break;

                            case ConsoleKey.D1:

                                view.ActiveScreen = Screens.AccountScreen;
                                if (numAccounts >= 1)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[0];
                                } 
                                else 
                                {
                                    view.ActiveScreen = Screens.MainMenuScreen; 
                                }
                                break;
                            
                            case ConsoleKey.D2:
                                if (numAccounts >= 2)
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
                                if (numAccounts >= 3)
                                {
                                    model.SelectedAccount = model.LoggedInCustomerAccounts[2];
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
                        customerInput = view.ShowAccountScreen(model.LoggedInCustomer, model.SelectedAccount);

                        switch (customerInput.keyPress.Key)
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
                        }

                        break;

                    case Screens.CreateAccountScreen:
                        customerInput = view.ShowCreateAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

                        switch (customerInput.keyPress.Key)
                        {
                            case ConsoleKey.E:
                                ProgramShutDown();
                                break;

                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.WelcomeScreen;
                                break;
                        }

                        break;

                    case Screens.DepositScreen:
                        customerInput = view.ShowDepositScreen(model.LoggedInCustomer, model.SelectedAccount);

                        double depositAmount = double.Parse(customerInput.textField1);

                        if(depositAmount >= 0.0)
                        {
                            model.SelectedAccount.Balance += depositAmount;

                            model.SaveBankToFile();
                        }

                        view.ActiveScreen = Screens.AccountScreen;

                        break;

                    case Screens.WithdrawScreen:
                        customerInput = view.ShowWithdrawScreen(model.LoggedInCustomer, model.SelectedAccount);

                        double withdrawAmount = double.Parse(customerInput.textField1);

                        if (withdrawAmount >= 0.0 && withdrawAmount <= model.SelectedAccount.Balance)
                        {
                            model.SelectedAccount.Balance -= withdrawAmount;

                            model.SaveBankToFile();
                        }

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
            // Customers
            model.CreateCustomer("Arthur Dallas", "1234");
            model.CreateCustomer("Ellen Ripley", "1234");
            model.CreateCustomer("Joan Lambert", "1234");
            model.CreateCustomer("Samuel Brett", "1234");
            model.CreateCustomer("Gilbert Kane", "1234");
            model.CreateCustomer("Dennis Parker", "1234");
            model.CreateCustomer("Ash", "1234");

            // Accounts
            model.CreateAccountForCustomer("Arthur Dallas", "Payroll", 500.00, 0.0);
            model.CreateAccountForCustomer("Ellen Ripley" , "Payroll", 120000.00, 0.0);
            model.CreateAccountForCustomer("Joan Lambert" , "Payroll", 12000.00, 0.0);
            model.CreateAccountForCustomer("Samuel Brett" , "Payroll", 1200.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane" , "Payroll", 120.00, 0.0);
            model.CreateAccountForCustomer("Dennis Parker", "Payroll", 12.00, 0.0);

            model.CreateAccountForCustomer("Arthur Dallas", "Bonus", 500.00, 0.0);
            model.CreateAccountForCustomer("Ellen Ripley" , "Bonus", 120000.00, 0.0);
            model.CreateAccountForCustomer("Joan Lambert" , "Bonus", 12000.00, 0.0);
            model.CreateAccountForCustomer("Samuel Brett" , "Bonus", 1200.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane" , "Bonus", 120.00, 0.0);
            model.CreateAccountForCustomer("Dennis Parker", "Bonus", 12.00, 0.0);
        }

        // Properties
        public CustomerInput customerInput { get; set; }

        // Fields
        public Bank model;
        public Screen view;
    }
}
