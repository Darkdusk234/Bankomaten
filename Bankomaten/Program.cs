namespace Bankomaten
{
    internal class Program
    {
        static string[] userNames = ["Johan", "Lisa", "Anders", "Rebecca", "Busan"];
        static string[] userPins = ["943", "531", "231", "053", "111"];

        static void Main(string[] args)
        {
            Write("Välkommen till DRWHO Bank. \n" +
                "Vänligen skriv ditt användarnamn.");

            string user = UserNameInput();

            Write($"God dag {user}. \n" +
                "Vänligen skriv in din pinkod för att logga in.");

            bool loginSucess = PinCodeInput(user);
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
