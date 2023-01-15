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


        static void Timer(int time)
        {
            for (int a = time; a >= 0; a--)
            {
                Console.Write("\rHátralévő idő: {0:000}", a);
                System.Threading.Thread.Sleep(1000);
            }
        }


        static int[] StartingPosition(List<string> map)
        {
            DrawMap(map);

            int[] startingPosition = new int[2];

            for (int height = 0; height < map.Count; height++)
            {
                for (int width = 0; width < map[0].Length; width++)
                {
                    if (
                        (height != 0 && height != map.Count && width == map[0].Length && map[height][width] == '═' || map[height][width] == '╚' || map[height][width] == '╔' || map[height][width] == '╩' || map[height][width] == '╦') || //jobb oldal

                        (height != 0 && height != map.Count && width == 0 && map[height][width] == '═' || map[height][width] == '╗' || map[height][width] == '╝' || map[height][width] == '╩' || map[height][width] == '╦') || //bal oldal

                        (height == map.Count && width == 0 && map[height][width] == '═' || map[height][width] == '╗' || map[height][width] == '╚' || map[height][width] == '╩' || map[height][width] == '║') || //jobb alsó sarok

                        (height == map.Count && width == 0 && map[height][width] == '═' || map[height][width] == '╝' || map[height][width] == '╔' || map[height][width] == '╩' || map[height][width] == '║') || //bal alsó sarok

                        (height == map.Count && width != 0 && width != map[0].Length && map[height][width] == '║' || map[height][width] == '╗' || map[height][width] == '╔' || map[height][width] == '╦') ||  //alsó rész

                        (height == 0 && width == map[0].Length && map[height][width] == '═' || map[height][width] == '╝' || map[height][width] == '╔' || map[height][width] == '╦' || map[height][width] == '║') || //jobb felso sarok

                        (height == 0 && width == 0 && map[height][width] == '═' || map[height][width] == '╗' || map[height][width] == '╚' || map[height][width] == '╦' || map[height][width] == '║') ||  //bal felso sarok

                        (height == 0 && width != 0 && width != map[0].Length && map[height][width] == '║' || map[height][width] == '╝' || map[height][width] == '╚' || map[height][width] == '╩'))   //felső rész
                    {
                        Console.SetCursorPosition(width, height);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(map[height][width]);
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 20);
                        startingPosition[0] = height;
                        startingPosition[1] = width;

                        return startingPosition;
                    }
                }
            }
            startingPosition[0] = -1;
            startingPosition[1] = -1;

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
            List<string> map = CreateMap("C:\\Users\\Tamás\\source\\repos\\Labirintus\\map.txt");
            DrawMap(map);
            int left = 15;
            int top = 3;

            bool isGameGoing = true;


            do
            {
                Console.SetCursorPosition(left,top);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                switch(keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (top != 0 && map[top-1][left] != '.')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;

                            top--;
                            Console.SetCursorPosition(left, top);
                            Console.Write(map[top][left]);
                            Console.ResetColor();

                        }
                        break;

                    case ConsoleKey.A:
                        if (left != 0 && map[top][left-1] != '.')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            left--;
                            Console.SetCursorPosition(left, top);
                            Console.Write(map[top][left]);
                            Console.ResetColor();

                        }
                        break;

                    case ConsoleKey.S:
                        if (top != map.Count - 1 && map[top + 1][left] != '.')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;

                            top++;
                            Console.SetCursorPosition(left, top);
                            Console.Write(map[top][left]);
                            Console.ResetColor();

                        }
                        break;

                    case ConsoleKey.D:
                        if (left != map[0].Length - 1 && map[top][left + 1] != '.')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            left++;
                            Console.SetCursorPosition(left, top);
                            Console.Write(map[top][left]);
                            Console.ResetColor();
                        }
                        break;

                    case ConsoleKey.Escape:
                        Console.SetCursorPosition(0, map.Count + 3);
                        isGameGoing = false;
                        break;
                }

            } while (isGameGoing);
        }
        static void Main(string[] args)
        {
            Game();
        }

    }
}


