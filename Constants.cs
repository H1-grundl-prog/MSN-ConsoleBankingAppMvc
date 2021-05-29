using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankingAppMvc
{
    public class Constants
    {
        public const int WINDOW_WIDTH = 82;
        public const int WINDOW_HEIGHT = 40;
        public const int CURSOR_X_DEFAULT = 1;
        public const int CURSOR_Y_DEFAULT = 1;

        // Console window manipulation (prevent resize and close)
        public const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;
    }
    
    public enum Screens
    {
        WelcomeScreen,
        LoginScreen,
        MainMenuScreen,
        AccountScreen
    }
}
