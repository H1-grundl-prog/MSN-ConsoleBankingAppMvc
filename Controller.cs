using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleBankingAppMvc
{
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
            SetupCustomersAndAccounts();

            //model.LoadBankFromFile();

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

                        switch(customerInput.keyPress.Key)
                        {
                            case ConsoleKey.L :
                                view.ActiveScreen = Screens.LoginScreen;
                                break;
                        }

                        break;

                    case Screens.LoginScreen :
                        customerInput = view.ShowLoginScreen();

                        model.LoggedInCustomer = null;
                        model.LoggedInCustomerAccounts = null;

                        model.LoggedInCustomer = model.AttemptToLoginCustomer(customerInput);

                        if (model.LoggedInCustomer != null)
                        {
                            model.LoggedInCustomerAccounts = model.GetCustomerAccountList(model.LoggedInCustomer);

                            view.ActiveScreen = Screens.MainMenuScreen;
                        }
                        
                        break;

                    case Screens.MainMenuScreen :
                        
                        if (model.LoggedInCustomer != null)
                        {
                            customerInput = view.ShowMainMenuScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);
                        }
                        else
                        {
                            view.ActiveScreen = Screens.LoginScreen;
                        }

                        switch (customerInput.keyPress.Key)
                        {
                            case ConsoleKey.L:
                                view.ActiveScreen = Screens.LoginScreen;
                                break;
                        }
                        
                        break;

                    case Screens.AccountScreen:
                        customerInput = view.ShowAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);
                        
                        break;

                    case Screens.CreateAccountScreen:
                        customerInput = view.ShowCreateAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

                        break;

                    case Screens.DepositScreen:
                        customerInput = view.ShowDepositScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

                        break;

                    case Screens.WithdrawScreen:
                        customerInput = view.ShowWithdrawScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

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
            model.CreateAccountForCustomer("Arthur Dallas", "1234", "Payroll", 500.00, 0.0);
            model.CreateAccountForCustomer("Ellen Ripley" , "1234", "Payroll", 120000.00, 0.0);
            model.CreateAccountForCustomer("Joan Lambert" , "1234", "Payroll", 12000.00, 0.0);
            model.CreateAccountForCustomer("Samuel Brett" , "1234", "Payroll", 1200.00, 0.0);
            model.CreateAccountForCustomer("Gilbert Kane" , "1234", "Payroll", 120.00, 0.0);
            model.CreateAccountForCustomer("Dennis Parker", "1234", "Payroll", 12.00, 0.0);

            // Assign accounts to customers
        }

        // Properties
        public CustomerInput customerInput { get; set; }

        // Fields
        public Bank model;
        public Screen view;
    }
}
