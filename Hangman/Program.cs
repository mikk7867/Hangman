namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                //variables
                string solution;
                bool gamestate;
                //draws the banner
                Drawing.Banner();
                //instructions
                Console.SetCursorPosition(4, 11);
                solution = Setup();
                char[] word = new char[solution.Length], 
                    answer = new char[solution.Length];
                //string -> char-array (to make it more easilly comparable)
                for (int i = 0; i < solution.Length; i++)
                {
                    word[i] = solution[i];
                }
                //reset graphics, banner and gallow
                Console.Clear();
                Drawing.Banner();
                Drawing.Galge();
                //space for the word to appear as it is guessed
                Drawing.WordSpace(word.Length);
                //loop as long as the game i not won or lost 
                gamestate = Game(word, answer);
                Result(gamestate, solution);
                Replay();
                Console.Clear();
            }
        }
        public static string Setup()
        {
            char input;
            Console.Write("Press '1' for a random word to guess");
            Console.SetCursorPosition(4, 12);
            Console.Write("Press '2' to manually write a word (2-player)");
            //input -> chooce random word or self-written word to guess
            while (true)
            {
                Console.SetCursorPosition(4, 14);
                input = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(4, 14);
                Console.Write(" ");
                if (input == '1')
                {
                    return Words.GetWord();
                }
                else if (input == '2')
                {
                    return Words.WriteWord();
                }
            }
        }
        public static bool Game(char[] word, char[] answer)
        {
            char input;
            int count = 0;
            List<char> tried = new();
            while (!word.SequenceEqual(answer) && count < 8)
            {
                //cursorposition for input, and removal of character from console
                Console.SetCursorPosition(4, 23);
                input = Console.ReadKey().KeyChar;
                Console.SetCursorPosition(4, 23);
                Console.Write(" ");
                Console.SetCursorPosition(6, 22);
                Console.Write(new String(' ', Console.BufferWidth));
                Console.SetCursorPosition(6, 22);
                //'#' to forfeit (i should write instructions for that somewhere)
                if (input == '#')
                {
                    count = 8;
                }
                //if the player presses a non-letter
                else if (!Char.IsLetter(input))
                {
                    //error message
                    Console.WriteLine("That's not a letter, try again");
                }
                //if the player presses an already used letter
                else if (tried.Contains(input))
                {
                    //error message
                    Console.WriteLine("You've already used that one, try another");
                }
                //if the player guesses a letter correct
                else if (word.Contains(input))
                {
                    //adds the letter to the array to match the word and to the list of used letters
                    tried.Add(input);
                    List<int> index = new();
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == input)
                        {
                            answer[i] = input;
                            index.Add(i);
                        }
                    }
                    //writes the letter on the correct spaces
                    Drawing.Right(input, index, word.Length);
                }
                //if the player makes a wrong guess
                else
                {
                    //adds the letter to the list of wrong letter and the list of used letters
                    count++;
                    tried.Add(input);
                    Drawing.Wrong(count, input);
                }
            }
            //if statement for victory og loss
            if (word.SequenceEqual(answer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Result(bool gamestate, string solution)
        {
            //setcursor below game-area
            Console.SetCursorPosition(4, 23);
            if (gamestate)
            {
                //win
                Console.Write("- VICTORY -");
                Console.SetCursorPosition(4, 24);
                Console.Write("You got it right!");
            }
            else
            {
                //lose
                Console.Write("- GAME OVER -");
                Console.SetCursorPosition(4, 24);
                Console.Write($"The word was '{solution}'");
            }
        }
        public static void Replay()
        {
            //option to play again (enter) or shut the program off
            Console.SetCursorPosition(4, 26);
            Console.Write("If you want to play again, press 'enter'");
            Console.SetCursorPosition(4, 27);
            Console.Write("Otherwise press any other key to shut down");
            if (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                System.Environment.Exit(0);
            }
        }
    }
}