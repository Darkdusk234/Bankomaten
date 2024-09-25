namespace Bankomaten
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Write("Välkommen till DRWHO Bank. \n" +
                "Vänligen skriv ditt användarnamn.");          

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
