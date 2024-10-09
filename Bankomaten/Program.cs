namespace Bankomaten
{
    internal class Program
    {
        //Creates arrays with user account info at start of program
        static string[] userNames = ["Johan", "Lisa", "Anders", "Rebecca", "Busan"];
        static string[] userPins = ["943", "531", "231", "053", "111"];

        static string[,] johanAccounts = { { "Sparkonto", }, { "73459,85" } };
        static string[,] lisaAccounts = { { "Lönekonto", "Investeringskonto" }, { "79854,45", "1436893,75" } };
        static string[,] andersAccounts = { { "Lönekonto", "Sparkonto", "Djurkonto" }, { "65325,21", "534987,68", "735531,21" } };
        static string[,] rebeccaAccounts = { { "Lönekonto", "Investeringskonto", "Sparkonto", "Huskonto" }, { "68235,00", "1184633,86", "75000,00", "5341,76" } };
        static string[,] busanAccounts = { { "Matkonto", "Uppmärksamhetskonto", "Klappkonto", "Revirkonto", "Sovkonto"  }, { "986351,34", "2381512,64", "631612,85", "561723,84", "1501372,51" } };

        static string[][,] userAccounts = new string[5][,];

        //Variable of the index of current user
        static int index = 0;

        static void Main(string[] args)
        {
            userAccounts = [johanAccounts, lisaAccounts, andersAccounts, rebeccaAccounts, busanAccounts];
            bool active = true;
            do
            {
                /*Asks for the username of the user and calls on UserNameInput method to take user input and
                checks if it is a valid username*/
                Write("Välkommen till DRWHO Bank. \n" +
                    "Vänligen skriv ditt användarnamn.");

                string user = UserNameInput();

                index = UserIndex(user);

                /*Asks for the pincode of the user and calls on the PinCodeInput method to take the user input
                and check if it is the correct code*/
                Write($"God dag {user}. \n" +
                    "Vänligen skriv in din pinkod för att logga in.");

                bool loginSuccess = PinCodeInput(user);

                //If login was successful calls on UserInterface method otherwise it sets active to false to stop program.
                if (loginSuccess)
                {
                    UserInterface(user);
                }
                else
                {
                    active = false;
                }
            } while (active);
        }
        
        /// <summary>
        /// Takes in user input and checks if it is a valid username and loops until a valid username is given.
        /// Returns string with username inputted.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Takes in user input and checks if it is the correct pincode to the username that is trying to login.
        /// Gives three tries before sending back boolean with false value.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        static bool PinCodeInput(string user)
        {
            bool loginSuccess = false;

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
                    i++;
                    continue;
                }

            }

           if(loginSuccess == false)
            {
                Write("Du skrev fel pinkod för många gånger. Vänligen starta om programmet.");
            }

            return loginSuccess;
        }

        /// <summary>
        /// Prints out a menu with choices for the user to interact with their accounts with.
        /// Loops until logout option is chosen.
        /// </summary>
        /// <param name="user"></param>
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
                        MoneyWithdraw(user);
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

        /// <summary>
        /// Prints out all accounts belonging to logged in user, also prints out balance of corresponding account.
        /// </summary>
        /// <param name="user"></param>
        static void AccountsMenu(string user)
        {
            string[,] currentUserAccounts = userAccounts[index];

            for(int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i + 1}.{currentUserAccounts[0,i]     }");
                Write($"{i + 1}.{currentUserAccounts[1,i]}kr");
            }

            Write("Tryck på en tangent för att gå tillbaka till menyn.");
            Console.ReadKey();
        }

        /// <summary>
        /// Asks user what account to transfer money from and to, also asks for the amount, then calls on SelfMoneyTransfer
        /// to transfer the amount.
        /// </summary>
        /// <param name="user"></param>
        static void AccountMoneyTransfer(string user)
        {
            string[,] currentUserAccounts = userAccounts[index];

            Write("Vilket konto vill du överföra pengar från?");

            //Prints what accounts are available
            for(int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i+1}. {currentUserAccounts[0,i]}");
            }

            bool invalidInput = true;
            int accountOut = 0;

            //Takes in user input about which account to transfer money from. Loops until valid input is given.
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

            //Takes in user input about which account to transfer money to. Loops until valid input is given.
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

            decimal amount = 0;
            invalidInput = true;

            /*Takes in user input about how much money is to be transferred, and checks if there is enough money to transfer.
            Loops until valid input is given.*/
            do
            {
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if(amount <= decimal.Parse(currentUserAccounts[1,(accountOut)]))
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

        /// <summary>
        /// Transfers a specified amount of money between two accounts belonging to logged in user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="accountOutIndex"></param>
        /// <param name="accountInIndex"></param>
        /// <param name="amount"></param>
        static void SelfMoneyTransfer(string user, int accountOutIndex, int accountInIndex, decimal amount)
        {
            string[,] currentUserAccounts = userAccounts[index];

            decimal tempSum = 0;

            tempSum = decimal.Parse(currentUserAccounts[1, accountOutIndex]) - amount;

            //Rounds number so it only has 2 decimals
            tempSum = Math.Truncate(tempSum * 100) / 100;

            currentUserAccounts[1, accountOutIndex] = tempSum.ToString();

            tempSum = decimal.Parse(currentUserAccounts[1, accountInIndex]) + amount;

            //Rounds number so it only has 2 decimals
            tempSum = Math.Truncate(tempSum * 100) / 100; 

            currentUserAccounts[1, accountInIndex] = tempSum.ToString();
        }

        /// <summary>
        /// Asks user what account to withdraw money from, also asks how much money to withdraw.
        /// Then asks for pincode to confirm the withdrawl. Loops until valid input is given.
        /// </summary>
        /// <param name="user"></param>
        static void MoneyWithdraw(string user)
        {
            string[,] currentUserAccounts = userAccounts[index];

            Write("Vilket konto vill du ta ut pengar från?");

            for (int i = 0; i < currentUserAccounts.GetLength(1); i++)
            {
                Write($"{i + 1}. {currentUserAccounts[0, i]}");
            }

            int account = 0;
            bool invalidInput = true;

            //Takes in user input about which account to withdraw from. Loops until valid input is given.
            do
            {
                while (!int.TryParse(Console.ReadLine(), out account))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if (account - 1 < currentUserAccounts.GetLength(1) && account - 1 >= 0)
                {
                    invalidInput = false;
                    account--;
                }
                else
                {
                    Write("Ogiltligt val, försök igen.");
                }

            } while (invalidInput);

            Write("Hur mycket pengar vill du ta ut?");

            decimal amount = 0;
            invalidInput = true;

            //Takes in user input on how much money is to be withdrawn. Loops until valid input is given.
            do
            {
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Write("Ogiltligt inmatning, skriv endast siffror.");
                }

                if (amount <= decimal.Parse(currentUserAccounts[1, (account)]))
                {
                    invalidInput = false;
                }
                else
                {
                    Write("Det finns inte tillräckligt med pengar på kontot för att ta ut den summan. Försök med en lägre summa.");
                }

            } while (invalidInput);

            Write("Skriv din pinkod för att konfirmera att du vill ta ut pengarna.");

            invalidInput = true;

            //Takes in user input of pincode and checks if it is the correct pincode of logged in user. Loops until correct input is given.
            do
            {
                string pinCodeInput = Console.ReadLine();

                if(pinCodeInput == userPins[index])
                {
                    invalidInput = false;
                }
                else
                {
                    Write("Incorrect Pin försök igen.");
                }

            } while (invalidInput);

            decimal tempSum = 0;

            tempSum = decimal.Parse(currentUserAccounts[1, account]) - amount;

            //Rounds number so it only has 2 decimals
            tempSum = Math.Truncate(tempSum * 100) / 100;

            currentUserAccounts[1, account] = tempSum.ToString();

            Write($"Din uttagning lyckades. Ditt nya saldo på kontot är {currentUserAccounts[1, account]}." +
                $"\nTryck på en tangent för att komma tillbaka till menyn.");
            Console.ReadKey();

        }

        /// <summary>
        /// Gets the array index of user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        static int UserIndex(string user)
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

            return index;
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
