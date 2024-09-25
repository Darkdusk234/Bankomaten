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
        }
        
        static string UserNameInput()
        {
            bool validUser = false;
            string userNameInput;

            do
            {
                userNameInput = Console.ReadLine();
                if (userNameInput != null)
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

            do
            {
                string userInput = Console.ReadLine();

                if(userInput != null)
                {
                    if(userPins[index].Equals(userInput))
                    {
                        loginSuccess = true;
                    }
                    else
                    {
                        Write("Din pin är incorrect. Försök igen.");
                    }
                }
                else
                {
                    Write("Ogiltligt input. Försök igen.");
                    continue;
                }

            } while (!loginSuccess);

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
