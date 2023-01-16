using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace labirintus_Gameplay
{
    class Program
    {
        static int NumberOfRooms(List<string> map)
        {
            int count = 0;
            for (int i = 0; i < map.Count; i++)
            {
                for (int x = 0; x < map[0].Length; x++)
                {
                    if (map[i][x] == '█')
                    {
                        count++;
                    }
                }
            }
            return count;
        }


        static List<string> CreateMap(string path)
        {
            List<string> map = new List<string>();
            map = File.ReadAllLines(path).ToList();
            return map;
        }


        static void Timer()
        {
            for (int a = 0; a <= 999; a++)
            {
                Console.Write("\rYour time: {0:000}", a);           
                System.Threading.Thread.Sleep(1000);
            }
        }


        static int[] StartingPosition(List<string> map)
        {
            int[] startingPosition = new int[2];

            Random rand = new Random();
            do
            {
                startingPosition[0] = rand.Next(0, map.Count);
                startingPosition[1] = rand.Next(0, map[0].Length);
                if (map[startingPosition[0]][startingPosition[1]] != '.')   //van hibás generálás, de nem találom az okát
                {
                    break;
                }
            } while (true);

            return startingPosition;
        }


        static void DrawMap(List<string> map)
        {

            for (int x = 0; x < map.Count; x++)
            {
                for (int y = 0; y < map[0].Length; y++)
                {
                    Console.Write(map[x][y]);
                }
                Console.Write("\n");
            }
        }


        static void Game()
        {

            string LoadInMap;
            do
            {
                Console.Write("Load in your map(e.g. example.txt): ");
                LoadInMap = Console.ReadLine();
            } while (!File.Exists(LoadInMap));

            var path = Directory.GetCurrentDirectory() + $"\\{LoadInMap}";
            List<string> map = CreateMap(path);
            Console.Clear();

            DrawMap(map);
            int top = StartingPosition(map)[0];
            int left = StartingPosition(map)[1];

            bool isGameGoing = true;
            int numberOfRooms = NumberOfRooms(map);
            int foundRooms = 0;

            Console.WriteLine("\nMovement\t[W][A][S][D]");
            Console.WriteLine("Quit    \t[Esc]");

            do
            {
                Console.SetCursorPosition(left, top);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);                 //╬═╦╩║╣╠╗╝╚╔█.
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (top != 0)
                        {
                            if (map[top - 1][left] == '║' || map[top - 1][left] == '╗' || map[top - 1][left] == '╔' || map[top - 1][left] == '╣' ||
                            map[top - 1][left] == '╠' || map[top - 1][left] == '╦' || map[top - 1][left] == '╬' || map[top - 1][left] == '█')
                            {
                                top--;
                                Console.SetCursorPosition(left, top);
                                Console.Write(map[top][left]);
                            }
                        }
                        
                        break;

                    case ConsoleKey.A:
                        if (left != 0)
                        {
                            if (map[top][left - 1] == '═' || map[top][left - 1] == '╚' || map[top][left - 1] == '╔' || map[top][left - 1] == '╠'
                            || map[top][left - 1] == '╦' || map[top][left - 1] == '╩' || map[top][left - 1] == '╬' || map[top][left - 1] == '█')
                            {
                                left--;
                                Console.SetCursorPosition(left, top);
                                Console.Write(map[top][left]);
                            }
                        }
                        break;

                    case ConsoleKey.S:
                        if (top != map.Count - 1)
                        {
                            if (map[top + 1][left] == '║' || map[top + 1][left] == '╚' || map[top + 1][left] == '╝' || map[top + 1][left] == '╣'
                            || map[top + 1][left] == '╠' || map[top + 1][left] == '╩' || map[top + 1][left] == '╬' || map[top + 1][left] == '█')
                            {
                                top++;
                                Console.SetCursorPosition(left, top);
                                Console.Write(map[top][left]);


                            }
                        }
                        break;

                    case ConsoleKey.D:
                        if (left != map[0].Length - 1)
                        {
                            if (map[top][left + 1] == '═' || map[top][left + 1] == '╗' || map[top][left + 1] == '╝' || map[top][left + 1] == '╣'
                            || map[top][left + 1] == '╦' || map[top][left + 1] == '╩' || map[top][left + 1] == '╬' || map[top][left + 1] == '█')
                            {
                                left++;
                                Console.SetCursorPosition(left, top);
                                Console.Write(map[top][left]);
                            }
                        }
                        break;

                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0, map.Count + 3);
                        Environment.Exit(0);
                        break;
                }

                if (map[top][left] == '█')
                {
                    foundRooms++;
                    if (foundRooms == numberOfRooms)
                    {
                        isGameGoing = false;
                    }
                }

            } while (isGameGoing);

            Console.Clear();
            Console.WriteLine("\n\n\t\tYOU WON!");
        }
        static void Main(string[] args)
        {
            Game(); //a Labirintus Projekt\Labirintus Projekt\bin\Debug\netcoreapp3.1 mappába tegye a pálya txt file-ját
            
            
            
            
            
            //List<string> map = CreateMap(Directory.GetCurrentDirectory() + "\\minta.txt");
            //DrawMap(map);
            //int[] starting = StartingPosition(map);
            //int SPT = starting[0];
            //int SPL = starting[1];
            //Console.WriteLine($"{StartingPosition(map)[0]}  {StartingPosition(map)[1]}");
            //Console.WriteLine(map[SPT][SPL]);
            //Console.SetCursorPosition(SPL, SPT);

            //System.Threading.Thread.Sleep(5000);
            //Console.SetCursorPosition(10, 10);
        }

    }
}
