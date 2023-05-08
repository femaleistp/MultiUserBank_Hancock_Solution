// Brittany Hancock
// IT112
// NOTES: none
// BEHAVIORS NOT IMPLEMENTED AND WHY: n/a
namespace MultiUserBank_Hancock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal balance = 10000;
            Bank bank = new Bank(10000);


            string entry;
            int index;

            do
            {
                MainMenu();

                entry = ValidateUsername();

                index = MatchPassword(entry);

                Submenu(index);
            } while (true);

            void Message(int i)
            {
                if (i == 0)
                {
                    Console.WriteLine("\nWell done, " + bank.GetUsername(index) + " !");
                }
                if (i != 0)
                {
                    Console.Clear();
                    Console.WriteLine("\nSuccess! \nNew account balance: " + bank.UserBalance(index).ToString("C"));
                }
            }

            void Submenu(int index)
            {
                Console.Clear();
                string option;
                int i = 0;
                do
                {
                    i++;

                    do
                    {
                        if (i == 1)
                        {
                            Console.WriteLine("\n" + bank.GetUsername(index));
                            Console.WriteLine("\nBank's total balance: " + bank.BankBalance.ToString("C"));
                        }
                        Console.WriteLine("\nPress: \n1 - to DEPOSIT\n2 - to WITHDRAWAL\n3 - to CHECK BALANCE\n" +
                            "4 - to LOG OFF");
                        option = Console.ReadLine();
                    } while (option != "1" && option != "2" && option != "3" && option != "4");

                    if (option == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername(index));
                        Console.Write("Enter deposit amount: ");
                        string amount = Console.ReadLine();
                        bank.Deposit(index, decimal.Parse(amount));
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername(index));
                        Console.WriteLine("Your current balance: " + bank.UserBalance(index).ToString("C") + "\n");
                        Console.WriteLine("\nBank's total balance: " + bank.BankBalance.ToString("C"));
                    }
                    if (option == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername(index));
                        Console.Write("Enter withdrawal amount: ");
                        string amount = Console.ReadLine();
                        bank.Withdrawal(index, decimal.Parse(amount));
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername(index));
                        Console.WriteLine("Your current balance: " + bank.UserBalance(index).ToString("C") + "\n");
                        Console.WriteLine("\nBank's total balance: " + bank.BankBalance.ToString("C"));
                    }
                    if (option == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername(index));
                        Console.WriteLine("Your current balance: " + bank.UserBalance(index).ToString("C") + "\n");
                        Console.WriteLine("\nBank's total balance: " + bank.BankBalance.ToString("C"));
                    }
                } while (option != "4");
                Console.Clear();
                Console.WriteLine("Logging off...");
                Thread.Sleep(900);
            }

            string ValidateUsername()
            {
                Console.Clear();
                do
                {
                    entry = string.Empty;
                    Console.Write("\nEnter username: ");
                    entry = Console.ReadLine();
                    entry = bank.CheckUsername(entry);
                } while (entry == "account does not exist");
                return entry;
            }



            int MatchPassword(string username)
            {
                string input;
                int index;
                do
                {
                    Console.Write("Enter password: ");
                    input = Console.ReadLine();
                    index = bank.UserPassword(input, username);
                } while (index == -1);

                return index;
            }

            void MainMenu()
            {
                Console.Clear();
                string input;
                int i = -1;
                do
                {
                    i++;
                    input = string.Empty;
                    if (i == 0)
                    {
                        Console.WriteLine("\nGreetings, esteemed customer !");
                    }
                    Console.WriteLine("\nPress:\n1 - to LOG IN\n2 - to EXIT");
                    input = Console.ReadLine();
                    if (input == "2")
                    {
                        ExitMode();
                    }
                } while (input != "1");
                return;
            }

            void ExitMode()
            {
                Console.Clear();
                Console.WriteLine("\nIt was our privelege to serve you !");
                Thread.Sleep(2500);
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}