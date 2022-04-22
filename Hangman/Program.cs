namespace Hangman
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                //variabler og test
                int count = 0;
                char input;
                List<char> tried = new();
                string solution;
                //tegner banneret?
                Drawing.Banner();
                //finder frem til et ord der skal gættes
                Console.SetCursorPosition(4, 11);
                Console.Write("Tryk '1' for at få et tilfældigt ord");
                Console.SetCursorPosition(4, 12);
                Console.Write("Tryk '2' for manuelt at indtaste et ord (2-player)");
                //input -> skriv ord selv eller få et tilfældigt
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
                        //nececary fix to remove red underline, has no functionality
                        solution = "";
                        //this code has functionality
                        Console.SetCursorPosition(4, 13);
                        Console.Write("Invalid input, try again");

                    }
                } while (input != '1' && input != '2');
                char[] word = new char[solution.Length], 
                    answer = new char[solution.Length];
                //smider ordet ind i et array ét tegn ad gangen så det nemmere kan sammenlignes
                for (int i = 0; i < solution.Length; i++)
                {
                    word[i] = solution[i];
                }
                //reset graphics
                Console.Clear();
                Drawing.Banner();
                //tegner selve galgen og layoutet
                Drawing.Galge();
                //tegner ord-feltet
                Drawing.WordSpace(word.Length);
                //loop så længe spiller er i gang 
                while (!word.SequenceEqual(answer) && count < 8)
                {
                    //cursorposition?
                    Console.SetCursorPosition(4, 23);
                    input = Console.ReadKey().KeyChar;
                    Console.SetCursorPosition(4, 23);
                    Console.Write(" ");
                    //hvis man taster '#' for at afslutte
                    if (input == '#')
                    {
                        count = 8;
                    }
                    //hvis man taster et ikke-bogstav
                    else if (!Char.IsLetter(input))
                    {
                        //fejlmeddelelse
                        Console.WriteLine("fejl 1");
                    }
                    //hvis man allerede har indtastet bogstavet
                    else if (tried.Contains(input))
                    {
                        //fejlmeddelelse
                        Console.WriteLine("fejl 2");
                    }
                    //hvis man taster et bogstav det er med i ordet
                    else if (word.Contains(input))
                    {
                        //føjer rigtige bogstaver til array og tager værdier med til at pinpointe printet
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
                        //overskriver bogstavet de rigtige steder
                        Drawing.Right(input, index, word.Length);
                    }
                    //hvis man taster et bogstav der ikke er med i ordet
                    else
                    {
                        //føjer forkert bogstav til liste og tegner mere af galgen
                        count++;
                        tried.Add(input);
                        Drawing.Wrong(count, input);
                    }
                }
                //setcursor under spilområdet
                Console.SetCursorPosition(4, 23);
                if (count >= 8)
                {
                    //du har tabt. evt print ordet?
                    Console.Write("Du har tabt");
                    Console.SetCursorPosition(4, 24);
                    Console.Write($"The word was '{solution}'");
                }
                else
                {
                    //du har vundet, yada yada
                    Console.Write("Du har vundet");
                }
                //tag input til og man vil fortsætte, hvis input er en bestemt værdi -> sluk programmet
                Console.SetCursorPosition(4, 26);
                Console.Write("Hvis du ønsker at spille igen, tast 'enter'");
                Console.SetCursorPosition(4, 27);
                Console.Write("Ellers tryk på en anden tast for at afslutte");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    System.Environment.Exit(0);
                }
                Console.Clear();
            }
        }
    }
}