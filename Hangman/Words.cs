namespace Hangman
{
    internal class Words
    {
        public static string WriteWord()
        {
            string word = "";
            Console.SetCursorPosition(4, 11);
            Console.Write("Please write a word of at least 4 characters");
            Console.SetCursorPosition(4, 12);
            Console.Write(new String(' ', Console.BufferWidth));
            while (word.Length < 4)
            {
                Console.SetCursorPosition(4, 13);
                word = Console.ReadLine().ToLower();
                if (word.Length < 4)
                {
                    Console.SetCursorPosition(4, 12);
                    Console.Write("Word is too short. Please try again");
                }
            }
            return word;
        }
        public static string GetWord()
        {
            //collection af ord
            string longlongman = "absurd,awkward,banjo,bagpipes,buffoon,dwarves,fiskhook,galaxy," +
                "gizmo,injury,jackpot,jigsaw,keyhole,lucky,microwave,numbskull,oxidize,pixel," +
                "polka,puppy,quartz,quiz,rhythm,scratch,strength,stronghold,swivel,topaz," +
                "unknown,unzip,vortex,walkway,whiskey,witchcraft,wyvern,yummy,zodiac,zombie";
            string[] manywords = longlongman.Split(',');
            //vælg et ord fra collection
            Random randy = new();
            string word = manywords[randy.Next(manywords.Length)];
            //evt hav undermetoder med forskellige kategorier --- nope
            return word;
        }
    }
}