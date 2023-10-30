namespace DTP_D7_MUD
{
    class Room
    {
        private string name;
        private string presentation;
        private int number;
        private int north;
        private int east;
        private int south;
        private int west;

        public static void PrintCommands()
        {
            Console.WriteLine("ladda /file/   ladda en fil med rum");
            Console.WriteLine("spara          spara en fil med rum");
            Console.WriteLine("starta         gå till rum 0");
            Console.WriteLine("n              gå norrut");
            Console.WriteLine("s              gå söderut");
            Console.WriteLine("e              gå österut");
            Console.WriteLine("ö              gå österut");
            Console.WriteLine("v              gå västerut");
            Console.WriteLine("w              gå västerut");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Room.PrintCommands();
        }
    }
}