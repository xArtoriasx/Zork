using System;

namespace Zork
{
    class Program
    {
        private static Room CurrentRoom
        {
            get
            {
                return Rooms[LocationRow, LocationColumn];
            }
        }

        static void Main(string[] args)




        {
            InitializeRoomDescriptions();

            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.WriteLine("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Console.WriteLine(Move(command) ? $"You moved {command}." : "The way is shut!");
                        break;

                    default:
                        Console.WriteLine("Unrecognized command.");
                        break;

                }


            }


        }


        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH when LocationRow < Rooms.GetLength(0) - 1:
                        LocationRow++;
                        didMove = true;
                        break;
                case Commands.SOUTH when LocationRow > 0:
                        LocationRow--;
                        didMove = true;
                        break;

                case Commands.EAST when LocationColumn < Rooms.GetLength(1) - 1:
                        LocationColumn++;
                        didMove = true;
                        break;

                case Commands.WEST when LocationColumn > 0:
                        LocationColumn--;
                        didMove = true;
                        break;

            }

            return didMove;
        }

        private static Commands ToCommand(string commandString)
        {
            return Enum.TryParse(commandString, ignoreCase:true, out Commands result) ? result : Commands.UNKNOWN;
        }

        private static readonly Room[,] Rooms =
        {
            { new Room("Dense Woods"), new Room("North of House"), new Room("Clearing") },
            { new Room("Forest"), new Room("West of House"), new Room("Behind House") },
            { new Room("Rocky Trail"), new Room("South of House"), new Room("Canyon View") },

        };

        private static int LocationRow = 1;
        private static int LocationColumn = 1;
        private static void InitializeRoomDescriptions()
        {
            Rooms[0, 0].Description = "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight.";
            Rooms[0, 1].Description = "You are facing the north side of a white house. There is no door there, and all the windows are barred.";
            Rooms[0, 2].Description = "You are in a cleaing, with a forest surrounding you on the west and south.";

            Rooms[1, 0].Description = "This is a forest, with trees in all directions around you.";
            Rooms[1, 1].Description = "This is an open field west of a white house, with a boarded front door.";
            Rooms[1, 2].Description = "You are behind the white house. In one corner of the house there is a small window that is slightly ajar.";

            Rooms[2, 0].Description = "You are on a rock-strewn trail.";
            Rooms[2, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";
            Rooms[2, 2].Description = "You are at the top of the Great Canyon on its south wall.";
        }

    }
}
