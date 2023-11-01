using System;
using System.IO;
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
            //TODO: TA BORT VISA-KOMMANDO EFTER TEST
            Console.WriteLine("visa rum //KOMMANDO/FUNKTION SKA TAS BORT SEDAN. DETTA ÄR  BARA TEST");   
            Console.WriteLine("ladda /file/   ladda en fil med rum");
            Console.WriteLine("spara          spara en fil med rum");
            Console.WriteLine("starta         gå till rum 0");
            Console.WriteLine("n              gå norrut");
            Console.WriteLine("s              gå söderut");
            Console.WriteLine("e/ö            gå österut");
            Console.WriteLine("v/w            gå västerut");
        }

        //Skapa lista med rum
        static public List<Room> map = new List<Room>() { };

        //Nuvarande rum
        public static Room currentRoom;

        //Flytta mellan rum
        public static void Move(string direction)
        {
            //TODO: Exception om inget rum är laddat
            //TODO: Inget rum är låst så man kan bara spamma n och 
            //      komma till slutet
            switch (direction)
            {
                case "n":
                    if (MudEngine.currentRoom.north != -1)
                    {
                        MudEngine.currentRoom = MudEngine.map.FirstOrDefault(room => room.number == MudEngine.currentRoom.north);
                    }
                    else
                    {
                        Console.WriteLine("Du gick in i väggen");
                    }
                    break;
                case "s":
                    if (MudEngine.currentRoom.south != -1)
                    {
                        MudEngine.currentRoom = MudEngine.map.FirstOrDefault(room => room.number == MudEngine.currentRoom.south);
                    }
                    else
                    {
                        Console.WriteLine("Du gick in i väggen");
                    }
                    break;
                case "e":
                    if (MudEngine.currentRoom.east != -1)
                    {
                        MudEngine.currentRoom = MudEngine.map.FirstOrDefault(room => room.number == MudEngine.currentRoom.east);
                    }
                    else
                    {
                        Console.WriteLine("Du gick in i väggen");
                    }
                    break;
                case "w":
                    if (MudEngine.currentRoom.west != -1)
                    {
                        MudEngine.currentRoom = MudEngine.map.FirstOrDefault(room => room.number == MudEngine.currentRoom.west);
                    }
                    else
                    {
                        Console.WriteLine("Du gick in i väggen");
                    }
                    break;
                default:
                    Console.WriteLine("Ogiltig riktning");
                    break;
            }
        }
        public static void DisplayCurrentRoom()
        {
            Console.WriteLine($"Du befinner dig i rum: {MudEngine.currentRoom.name}");
            Console.WriteLine(MudEngine.currentRoom.presentation);
        }
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
                    string gameFile = Console.ReadLine().ToLower(); //FIXME: Vad händer om filen inte finns?
                    Console.WriteLine($"{gameFile} laddad!");
                    string[] worldArr = File.ReadAllLines(gameFile);
                    //TODO: FÖRENKLA. FÖR MÅNGA STEG ATM?
                    //För varje sak i worldArr så läggs det som en rad i listan

                    for (int i = 0; i < worldArr.Length; i++)
                    {
                        string[] roomInfo = worldArr[i].Split(';');
                        if (roomInfo.Length == 7)
                        {
                            int number = int.Parse(roomInfo[0]);
                            string name = roomInfo[1];
                            string presentation = roomInfo[2];
                            int north = int.Parse(roomInfo[3]);
                            int east = int.Parse(roomInfo[4]);
                            int south = int.Parse(roomInfo[5]);
                            int west = int.Parse(roomInfo[6]);

                            Room newRoom = new Room(number, name, presentation, north, east, south, west);
                            MudEngine.map.Add(newRoom);
                        }
                    }

                }
                //TEST: SKRIV UT RUM, TA BORT DETTA KOMMANDO SEDAN
                else if (command[0] == "visa" || command[0] == "visa" && command[1] == "rum")
                {
                    foreach (var room in MudEngine.map)
                    {
                        Console.WriteLine($"Rumnummer: {room.number}");
                        Console.WriteLine($"Namn: {room.name}");
                        Console.WriteLine($"Presentation: {room.presentation}");
                        Console.WriteLine($"Norr: {room.north}");
                        Console.WriteLine($"Öster: {room.east}");
                        Console.WriteLine($"Söder: {room.south}");
                        Console.WriteLine($"Väster: {room.west}");
                        Console.WriteLine("------------------------------");
                    }
                }
                else if (command[0] == "spara")
                {
                    Console.WriteLine("NYI");
                }
                else if (command[0] == "starta")
                {
                    MudEngine.currentRoom = MudEngine.map.FirstOrDefault(room => room.number == 0);
                }
                else if (command[0] == "n" || command[0] == "s" || command[0] == "e" || command[0] == "w")
                {
                    MudEngine.Move(command[0]);
                    MudEngine.DisplayCurrentRoom();
                }
                else if (command[0] == "avsluta")
                {
                    Console.WriteLine("Avslutar. Tack för nu :)");
                }

            } while (command[0] != "avsluta");

        }
    }
}