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
            model.LoadBankFromFile();

            Console.SetWindowSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);
            Console.SetBufferSize(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT);
            Console.SetWindowPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;

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

                        customerInput = new CustomerInput();
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
                        
                        customerInput = new CustomerInput();
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
                            
                        //customerInput = new CustomerInput();
                        break;

                    case Screens.AccountScreen:
                        customerInput = view.ShowAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);
                        
                        customerInput = new CustomerInput();
                        break;

                    case Screens.CreateAccountScreen:
                        customerInput = view.ShowCreateAccountScreen(model.LoggedInCustomer, model.LoggedInCustomerAccounts);

                        customerInput = new CustomerInput();
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

        // Properties
        public CustomerInput customerInput;

        // Fields
        public Bank model;
        public Screen view;
    }
}
