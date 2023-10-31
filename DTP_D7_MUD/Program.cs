namespace DTP_D7_MUD
{
    public class Room
    {
        public int number { get; set; }
        public string name { get; set; }
        public string presentation { get; set; }
        public int north { get; set; }
        public int east { get; set; }
        public int south {get;set;}
        public int west {get;set;}
        public Room(int number, string name, string presentation,
            int N, int E, int S, int W)
        {
            this.number = number; this.name = name; this.presentation = presentation;
            north = N; east = E; south = S; west = W;
        }

    }
    public class MudEngine
    {
        // Det som ska hanteras här:
        //Rum, kommandon, spellogiken
        
        public static void PrintCommands()
        {
            Console.WriteLine("ladda /file/   ladda en fil med rum");
            Console.WriteLine("spara          spara en fil med rum");
            Console.WriteLine("starta         gå till rum 0");
            Console.WriteLine("n              gå norrut");
            Console.WriteLine("s              gå söderut");
            Console.WriteLine("e/ö            gå österut");
            Console.WriteLine("v/w            gå västerut");
        }

        //Skapa lista med rum
        
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("      Välkommen till LudMUD      ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            MudEngine.PrintCommands(); //Printa hjälpkommandon
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            string[] command;
            do
            {
                Console.Write("> ");
                command = Console.ReadLine().Split(' ');

                if (command[0] == "ladda")
                {
                    Console.Write("Ladda spelfil: ");
                    string gameFile = Console.ReadLine(); //FIXME: Vad händer om filen inte finns?
                    Console.WriteLine($"{gameFile} laddad!");
                    string[] worldArr = File.ReadAllLines(gameFile);
                    //LISTA List<Room> grotta = new List<Room>()
                    foreach (string line in worldArr)
                    {

                        ///VARJE LINJE/RUM DELAS UPP HÄR
                        ///NÄST PÅ TUR ÄR ATT DELA UPP VARJE
                        ///RUM I DE OLIKA ELEMENTEN
                        ///NÅGRA RADER UPP LIGGER EN LISTA SOM
                        ///KANSKE KAN ANVÄNDAS SENARE NÄR RUMMEN
                        ///SKA KONSTRUERAS. GODNATT
                    }
                }
                else if(command[0] == "spara")
                {
                    Console.WriteLine("NYI");
                }
                else if (command[0] == "starta")
                {
                    Console.WriteLine("NYI");
                }
                else if (command[0] == "avsluta")
                {
                    Console.WriteLine("Avslutar. Tack för nu :)");
                }

            } while (command[0] != "avsluta");

        }
    }
}