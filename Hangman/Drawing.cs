namespace Hangman
{
    internal class Drawing
    {
        public static void Banner()
        {
            //tegner banneret
            //h .1
            Console.SetCursorPosition(6, 1);
            Console.Write("_");
            //h .2
            Console.SetCursorPosition(5, 2);
            Console.Write("| |");
            //h .3
            Console.SetCursorPosition(5, 3);
            Console.Write("| |__");
            //a .3
            Console.SetCursorPosition(13, 3);
            Console.Write("__ _");
            //n .3
            Console.SetCursorPosition(18, 3);
            Console.Write("_ __");
            //g .3
            Console.SetCursorPosition(24, 3);
            Console.Write("__ _");
            //m .3
            Console.SetCursorPosition(29, 3);
            Console.Write("_ __ ___");
            //a .3
            Console.SetCursorPosition(40, 3);
            Console.Write("__ _");
            //n .3
            Console.SetCursorPosition(45, 3);
            Console.Write("_ __");
            //h .4
            Console.SetCursorPosition(5, 4);
            Console.Write("| '_ \\");
            //a .4
            Console.SetCursorPosition(12, 4);
            Console.Write("/ _' |");
            //n .4
            Console.SetCursorPosition(19, 4);
            Console.Write("'_ \\");
            //g .4
            Console.SetCursorPosition(23, 4);
            Console.Write("/ _' |");
            //m .4
            Console.SetCursorPosition(30, 4);
            Console.Write("'_ ' _ \\");
            //a .4
            Console.SetCursorPosition(39, 4);
            Console.Write("/ _' _");
            //n .4
            Console.SetCursorPosition(46, 4);
            Console.Write("'_ \\");
            //h .5
            Console.SetCursorPosition(5, 5);
            Console.Write("| | | |");
            //a .5
            Console.SetCursorPosition(13, 5);
            Console.Write("(_| |");
            //n .5
            Console.SetCursorPosition(19, 5);
            Console.Write("| | |");
            //g .5
            Console.SetCursorPosition(24, 5);
            Console.Write("(_| |");
            //m .5
            Console.SetCursorPosition(30, 5);
            Console.Write("| | | | |");
            //a .5
            Console.SetCursorPosition(40, 5);
            Console.Write("(_| |");
            //n .5
            Console.SetCursorPosition(46, 5);
            Console.Write("| | |");
            //h .6
            Console.SetCursorPosition(5, 6);
            Console.Write("|_| |_|");
            //a .6
            Console.SetCursorPosition(12, 6);
            Console.Write("\\__,_|");
            //n .6
            Console.SetCursorPosition(18, 6);
            Console.Write("_| |_|");
            //g .6
            Console.SetCursorPosition(23, 6);
            Console.Write("\\__, |");
            //m .6
            Console.SetCursorPosition(29, 6);
            Console.Write("_| |_| |_|");
            //a .6
            Console.SetCursorPosition(39, 6);
            Console.Write("\\__,_|");
            //n .6
            Console.SetCursorPosition(45, 6);
            Console.Write("_| |_|");
            //g .7
            Console.SetCursorPosition(24, 7);
            Console.Write("__/ |");
            //g .8
            Console.SetCursorPosition(23, 8);
            Console.Write("|___/");
        }
        public static void Galge()
        {
            //tegner galgen når programmet starter
            //gallow construction.
            Console.SetCursorPosition(6, 10);
            Console.Write("________");
            Console.SetCursorPosition(5, 11);
            Console.Write("| /     |");
            Console.SetCursorPosition(5, 12);
            Console.Write("|/");
            Console.SetCursorPosition(5, 13);
            Console.Write("|");
            Console.SetCursorPosition(5, 14);
            Console.Write("|");
            Console.SetCursorPosition(5, 15);
            Console.Write("|");
            Console.SetCursorPosition(5, 16);
            Console.Write("|   _________");
            Console.SetCursorPosition(4, 17);
            Console.Write("_|__/_|__|__|_\\_");
            Console.WriteLine("\n");
        }
        public static void WordSpace(int length)
        {
            //right letter zone
            Console.SetCursorPosition(6, 19);
            Console.Write("The word:");
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition((i * 2) + 5, 20);
                Console.Write("_ ");
            }
            //wrong letter zone
            Console.SetCursorPosition(25, 11);
            Console.Write("Wrong letters:");
        }
        public static void Right(char input, List<int> index, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (index.Contains(i))
                {
                    //setcoursor baseret på i og print char input (som uppercase?)
                    Console.SetCursorPosition((i * 2) + 5, 20);
                    Console.Write(input.ToString().ToUpper());
                }
            }
            //hvis man skriver rigtigt input
        }
        public static void Wrong(int count, char input)
        {
            //hvis man skriver forkert input
            if (count == 1)
            {
                Console.SetCursorPosition(13, 12);
                Console.Write("|");//rope
            }
            else if (count == 2)
            {
                Console.SetCursorPosition(13, 13);
                Console.Write("O");//head
            }
            else if (count == 3)
            {
                Console.SetCursorPosition(13, 14);
                Console.Write("|");//torso
            }
            else if (count == 4)
            {
                Console.SetCursorPosition(12, 14);
                Console.Write("/");//left arm
            }
            else if (count == 5)
            {
                Console.SetCursorPosition(14, 14);
                Console.Write("\\");//right arm
            }
            else if (count == 6)
            {
                Console.SetCursorPosition(12, 15);
                Console.Write("/");//left leg
            }
            else if (count == 7)
            {
                Console.SetCursorPosition(14, 15);
                Console.Write("\\");//right leg
            }
            else if (count == 8)
            {
                Console.SetCursorPosition(13, 15);
                Console.Write("'");//that's a *****
            }
            else
            {
                //fejl??? how did we get here
            }
            //føjer til liste med forkerte bogstaver
            Console.SetCursorPosition(38 + (count * 2), 11);
            Console.Write(input.ToString().ToUpper());           
        }
    }
}