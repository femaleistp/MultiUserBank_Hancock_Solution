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
            string[] username = { "jlennon", "pmccartney", "gharrison", "rstarr" };
            string[] userPassword = { "johnny", "pauly", "georgy", "ringoy" };
            decimal[] userBalance = { 1250, 2500, 3000, 1000 };
            Bank bank = new Bank(balance, username, userPassword, userBalance);

            string entry;
            string loggedIn;

            do
            {
                MainMenu();

                ValidateUsername();

                loggedIn = MatchPassword();

                Submenu();
            } while (true);

            void MainMenu()
            {
                Console.Clear();
                string input = String.Empty;
                do
                {
                    Console.Clear();
                    if (input != "1" && input != "2")
                    {
                        Console.WriteLine("\nGreetings, esteemed customer !");
                        Console.WriteLine("\nBank's total balance: " + bank.GetBankBalance.ToString("C"));
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

            void ValidateUsername()
            {
                int userIndex;
                Console.Clear();
                do
                {
                    entry = string.Empty;
                    Console.Write("\nEnter username: ");
                    entry = Console.ReadLine();
                    userIndex = bank.CheckUsername(entry);
                } while (userIndex == -1);
            }

            string MatchPassword()
            {
                string input;
                do
                {
                    Console.Write("Enter password: ");
                    input = Console.ReadLine();
                    loggedIn = bank.CheckUserPassword(input);
                } while (loggedIn == "false");
                return loggedIn;
            }

            void Submenu()
            {
                string option = String.Empty;

                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\n" + bank.GetUsername);
                        if (option == "1" || option == "2" || option == "3")
                        {
                            Console.WriteLine("\nYour balance is " + bank.GetUserBalance.ToString("C"));
                        }
                        Console.WriteLine("\nPress: \n1 - to DEPOSIT\n2 - to WITHDRAWAL\n3 - to CHECK BALANCE\n" +
                            "4 - to LOG OFF");
                        option = Console.ReadLine();

                    } while (option != "1" && option != "2" && option != "3" && option != "4");

                    Transaction(option);

                } while (option != "4");

                Console.Clear();
                Console.WriteLine("Logging off...");
                Thread.Sleep(900);
            }

            void Transaction(string option)
            {
                string amount = String.Empty;
                decimal result = -1;
                Console.Clear();
                Console.WriteLine("\n" + bank.GetUsername);
                if (option == "1")
                {
                    do
                    {
                        Console.Write("\nEnter deposit amount: ");
                        amount = Console.ReadLine();
                        if (decimal.TryParse(amount, out result))
                        {
                            if (result >= 0)
                            {
                                bank.Deposit(result);
                            }
                            else
                            {
                                result = NoNegatives();
                            }
                        }
                        else
                        {
                            FixInput();
                        }
                    } while (result == -1);
                }
                else if (option == "2")
                {
                    do
                    {
                        Console.Write("\nEnter withdrawal amount: ");
                        amount = Console.ReadLine();
                        if (decimal.TryParse(amount, out result))
                        {
                            if (result >= 0)
                            {
                                bank.Withdrawal(result);
                            }
                            else
                            {
                                NoNegatives();
                                result = -1;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            FixInput();
                        }
                    } while (result == -1);
                }
            }

            int NoNegatives()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No negative numbers");
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }

            void FixInput()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Numbers and decimal point only.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            void Message()
            {
                Console.Clear();
                Console.WriteLine("\n" + bank.GetUsername);
                Console.WriteLine("\nYour current balance: " + bank.GetUserBalance.ToString("C"));
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