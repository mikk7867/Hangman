namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                //variables
                int count = 0;
                char input;
                List<char> tried = new();
                string solution;
                //draws the banner
                Drawing.Banner();
                //instructions
                Console.SetCursorPosition(4, 11);
                Console.Write("Press '1' for a random word to guess");
                Console.SetCursorPosition(4, 12);
                Console.Write("Press '2' to manually write a word (2-player)");
                //input -> chooce random word or self-written word to guess
                do
                {
                    Console.SetCursorPosition(4, 14);
                    input = Console.ReadKey().KeyChar;
                    Console.SetCursorPosition(4, 14);
                    Console.Write(" ");
                    if (input == '1')
                    {
                        solution = Words.GetWord();
                    }
                    else if (input == '2')
                    {
                        solution = Words.WriteWord();
                    }
                    else
                    {
                        //nececary fix to remove red underline, has no functionality :P
                        solution = "";
                        //this code has functionality
                        Console.SetCursorPosition(4, 13);
                        Console.Write("Invalid input, try again");
                    }
                } while (input != '1' && input != '2');
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
                //setcursor below game-area
                Console.SetCursorPosition(4, 23);
                if (count >= 8)
                {
                    //lose
                    Console.Write("- GAME OVER -");
                    Console.SetCursorPosition(4, 24);
                    Console.Write($"The word was '{solution}'");
                }
                else
                {
                    //win
                    Console.Write("- VICTORY -");
                    Console.SetCursorPosition(4, 24);
                    Console.Write("You got it right!");
                }
                //option to play again (enter) or shut the program off
                Console.SetCursorPosition(4, 26);
                Console.Write("If you want to play again, press 'enter'");
                Console.SetCursorPosition(4, 27);
                Console.Write("Otherwise press any other key to shut down");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    System.Environment.Exit(0);
                }
                Console.Clear();
            }
        }
    }
}