using System;

namespace Bankomaten
{
    internal class Program
    {
        static string[] userNames = ["Johan", "Lisa", "Anders", "Rebecca", "Busan"];
        static string[] userPins = ["943", "531", "231", "053", "111"];

        static string[,] johanAccounts = { { "Sparkonto", }, { "73459,85" } };
        static string[,] lisaAccounts = { { "Lönekonto", "Investeringskonto" }, { "79854,45", "1436893,75" } };
        static string[,] andersAccounts = { { "Lönekonto", "Sparkonto", "Djurkonto" }, { "65325,21", "534987,68", "735531,21" } };
        static string[,] rebeccaAccounts = { { "Lönekonto", "Investeringskonto", "Sparkonto", "Huskonto" }, { "68235,00", "1184633,86", "75000,00", "5341,76" } };
        static string[,] busanAccounts = { { "Matkonto", "Uppmärksamhetskonto", "Klappkonto", "Revirkonto", "Sovkonto"  }, { "986351,34", "2381512,64", "631612,85", "561723,84", "1501372,51" } };

        static string[][,] userAccounts = new string[5][,];

        static void Main(string[] args)
        {
            userAccounts = [johanAccounts, lisaAccounts, andersAccounts, rebeccaAccounts, busanAccounts];
            bool active = true;
            do
            {
                Write("Välkommen till DRWHO Bank. \n" +
                    "Vänligen skriv ditt användarnamn.");

                string user = UserNameInput();

                Write($"God dag {user}. \n" +
                    "Vänligen skriv in din pinkod för att logga in.");

                bool loginSuccess = PinCodeInput(user);

                if (loginSuccess)
                {
                    UserInterface(user);
                }
            } while (active);
        }
        
        static string UserNameInput()
        {
            bool validUser = false;
            string userNameInput;

            do
            {
                userNameInput = Console.ReadLine();
                if (userNameInput != "")
                {
                    for(int i = 0; i < userNames.Length; i++)
                    {
                        if (userNames[i].ToUpper().Equals(userNameInput.ToUpper()))
                        {
                            validUser = true;
                        }
                    }

                    if(!validUser)
                    {
                        Write("Användarnamnet finns inte. Försök igen.");
                    }
                }
                else
                {
                    Write("Ogiltlig input, Försök igen.");
                    continue;
                }
            } while (!validUser);

            return userNameInput;
        }

        static bool PinCodeInput(string user)
        {
            bool loginSuccess = false;
            int index = 0;


            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i].ToUpper().Equals(user.ToUpper()))
                {
                    index = i;
                    break;
                }
            }

           for(int i = 3; i > 0; i--)
            {
                Write($"Du har {i} försök kvar.");
                string userInput = Console.ReadLine();

                if(userInput != "")
                {
                    if(userPins[index].Equals(userInput))
                    {
                        loginSuccess = true;
                        break;
                    }
                    else
                    {
                        Write("Din pin är incorrect. Försök igen.");
                        continue;
                    }
                }
                else
                {
                    Write("Ogiltligt input. Försök igen.");
                    continue;
                }

            }

           if(loginSuccess == false)
            {
                Write("Du skrev fel pinkod för många gånger. Vänligen starta om programmet.");
            }

            return loginSuccess;
        }

        static void UserInterface(string user)
        {
            bool logOut = false;
            do
            {
                Console.Clear();

                Write($"Hej {user}. Vänligen välj vad du vill göra. \n" +
                    $"1.Se dina konton och saldo.\n" +
                    $"2.Överföring mellan konton.\n" +
                    $"3.Ta ut pengar.\n" +
                    $"4.Logga ut.");

                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        AccountsMenu(user);
                        break;
                    case "2":
                        AccountMoneyTransfer(user);
                        break;
                    case "3":
                        Write("Klicka enter för att komma till huvudmenyn.");
                        Console.ReadKey();
                        break;
                    case "4":
                        logOut = true;
                        break;
                    default:
                        Write("Ogiltigt val. Tryck enter för att gå tillbaka till menyn.");
                        Console.ReadKey();
                        break;
                }

            } while (!logOut);
        }

        static void AccountsMenu(string user)
        {
            int index = 0;

            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i].ToUpper().Equals(user.ToUpper()))
                {
                    index = i;
                    break;
                }
            }

            string[,] currentUserAccounts = userAccounts[index];

            for(int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i + 1}.{currentUserAccounts[0,i]     }");
                Write($"{i + 1}.{currentUserAccounts[1,i]}kr");
            }

            Console.ReadKey();
        }

        static void AccountMoneyTransfer(string user)
        {
            int index = 0;

            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i].ToUpper().Equals(user.ToUpper()))
                {
                    index = i;
                    break;
                }
            }

            string[,] currentUserAccounts = userAccounts[index];

            Write("Vilket konto vill du överföra pengar från?");

            for(int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i+1}. {currentUserAccounts[0,i]}");
            }

            bool invalidInput = true;
            int accountOut = 0;

            do
            {
                while(!int.TryParse(Console.ReadLine(), out accountOut))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if(accountOut - 1 < currentUserAccounts.GetLength(1) && accountOut - 1 >= 0 )
                {
                    invalidInput = false;
                    accountOut--;
                }
                else
                {
                    Write("Ogiltligt val, försök igen.");
                }

            } while (invalidInput);

            Write("Vilket konto vill du överföra pengar till?");

            for (int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i + 1}. {currentUserAccounts[0, i]}");
            }

            int accountIn = 0;
            invalidInput = true;

            do
            {
                while (!int.TryParse(Console.ReadLine(), out accountIn))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if (accountIn - 1 < currentUserAccounts.GetLength(1) && accountIn - 1 >= 0)
                {
                    invalidInput = false;
                    accountIn--;
                }
                else
                {
                    Write("Ogiltligt val, försök igen.");
                }

            } while (invalidInput);

            Write("Hur mycket vill du överföra?");

            double amount = 0;
            invalidInput = true;

            do
            {
                while (!double.TryParse(Console.ReadLine(), out amount))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if(amount <= double.Parse(currentUserAccounts[1,(accountOut)]))
                {
                    invalidInput = false;
                }
                else
                {
                    Write("Det finns inte tillräckligt med pengar på kontot för att överföra den summan. Försök med en lägre summa.");
                }

            } while (invalidInput);

            SelfMoneyTransfer(user, accountOut, accountIn, amount);

            Write("Överföring klar. Tryck en tangent för att gå tillbaka till menyn.");
            Console.ReadKey();

        }

        static void SelfMoneyTransfer(string user, int accountOutIndex, int accountInIndex, double amount)
        { 
            int index = 0;

            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i].ToUpper().Equals(user.ToUpper()))
                {
                    index = i;
                    break;
                }
            }

            string[,] currentUserAccounts = userAccounts[index];

            double tempSum = 0;

            tempSum = double.Parse(currentUserAccounts[1, accountOutIndex]) - amount;

            currentUserAccounts[1, accountOutIndex] = tempSum.ToString();

            tempSum = double.Parse(currentUserAccounts[1, accountInIndex]) + amount;

            currentUserAccounts[1, accountInIndex] = tempSum.ToString();
        }

        /// <summary>
        /// Prints out a string of text in a rainbowlike pattern
        /// </summary>
        /// <param name="text"></param>
        static void Write(string text)
        {
            ConsoleColor[] pallette = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Magenta };
            int color = 0;

            foreach (char c in text)
            {
                Console.ForegroundColor = pallette[color];
                Console.Write(c);

                if (char.IsWhiteSpace(c) == false)
                {
                    color++;
                }
                if (color > 4)
                {
                    color = 0;
                }
            }
            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
