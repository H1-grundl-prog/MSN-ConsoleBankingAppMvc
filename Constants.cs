namespace ConsoleBankingAppMvc
{
    public class Constants
    {
        public const int WINDOW_WIDTH = 80;
        public const int WINDOW_HEIGHT = 40;
        public const int CURSOR_X_DEFAULT = 0;
        public const int CURSOR_Y_DEFAULT = 9;
        public const int CURSOR_X_FOOTER = 0;
        public const int CURSOR_Y_FOOTER = WINDOW_HEIGHT - 13;
        public const int CURSOR_X_MENU = 0;
        public const int CURSOR_Y_MENU = WINDOW_HEIGHT - 17;
        public const int CURSOR_X_LOGIN = 0;
        public const int CURSOR_Y_LOGIN = 11;
        public const int CURSOR_X_LOGGEDINUSER = 0;
        public const int CURSOR_Y_LOGGEDINUSER = 6;
        public const int MAX_ACCOUNTS = 9;
        public const int MAX_CUSTOMERS = 9;

        // Console window manipulation (prevent resize and close)
        public const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;
    }
}
