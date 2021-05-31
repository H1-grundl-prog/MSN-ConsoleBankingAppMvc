using System;

namespace ConsoleBankingAppMvc
{
    public class CustomerInput
    {
        public CustomerInput()
        {
            textField1 = new string("");
            textField2 = new string("");
            keyPress = new ConsoleKeyInfo();
        }

        public string textField1 { get; set; }
        public string textField2 { get; set; }
        public ConsoleKeyInfo keyPress { get; set; }
    }
}
