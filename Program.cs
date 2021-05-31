using System;
using System.Runtime.InteropServices;

/*

Opgave:

I skal lave en Bank console app eller wpf.
Appen skal give brugeren lov til at se deres konto hæve penge på kontoen og sætte penge ind på kontoen
Opgaven er individuel og den skal aflevereres senest torsdag 07:00. 
1.	En konto med minimum 1 bruger (brugerens navn, brugerens adresse, brugerens konto.nr)
2.	Man skal kunne indsætte penge på kontoen
3.	man skal hæve penge fra kontoen
4.	man skal kunne se hvor mange penge der er på kontoen
5.	I skal kommenter koden. 

til jer der ønsker mere udfordring kan i løse nogle af følgende opgaver

BONUS

Udregn renter over en periode af 3 år
Medregn faste udgifter i et evt. budget
Lav en liste af flere konti for brugeren (f.eks. husholdig, opsparing etc.…)

Kommentar:

Programmet er så vidt muligt selvkommenterende, dvs. classes, properties, methods mv. er 
navngivet så beskrivende, at kommentarer ikke skulle være nødvendige.
Algoritmer inde i Methods er kommeteret linje for linje.
Programmet er opbygget efter MVC princippet med en controller, der styrer og formidler data mellem model(bank) og view(skærm)
Alle data gemmes og hentes fra Bank.json i bin/debug mappen. Man kan tilføje nye kunder og kontoer direkte i filen.

Funktioner:

-Oprette og slette Customers og Accounts uafhængigt af hinanden
-En Customer kan have flere accounts
-Et Account kan være tilknyttet flere Customers (f.eks. fælles budgetkonto)
-Man kan hæve og indsætte penge
-Saldo

Reflektion:

Det var en spændende opgave med mange udfordringer. Appen har stadig en del småbugs og begrænsninger.
Der kan tilføjes en del funktioner, såsom at give andre kunder adgang til ens konti, overføre beløb osv.

Referencer:

https://www.webmatematik.dk/lektioner/matematik-c/funktioner/renteformlen
https://www.newtonsoft.com/json/help/html/SerializeObject.htm
https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0
https://social.microsoft.com/Forums/security/en-SG/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize?forum=csharpgeneral

*/

namespace ConsoleBankingAppMvc
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Console window manipulation (prevent resize and close)
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                //DeleteMenu(sysMenu, Constants.SC_CLOSE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_MINIMIZE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_MAXIMIZE, Constants.MF_BYCOMMAND);
                DeleteMenu(sysMenu, Constants.SC_SIZE, Constants.MF_BYCOMMAND);
            }

            // Create new model, view, and controller
            Bank bank = new Bank();
            Screen screen = new Screen();
            Controller controller = new Controller(bank, screen);

            controller.RunProgram();
        }

        // Console window manipulation (prevent resize and close)
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
    }
}
