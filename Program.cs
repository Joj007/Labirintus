using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Labirintus_Projekt
{
    class Program
    {
        static List<string> CreateMap(string path)
        {
            List<string> map = new List<string>();
            map = File.ReadAllLines(path).ToList();
            return map;
        }
        static bool IsMovementAvailable(char movementKey, int[] coordinate)
        {
            if (movementKey == 'w')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Movement(int[] currentPosition)
        {
            char input = '´';
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                //Char keyChar = Convert.ToChar(key);
                if (key.KeyChar == 'w' || key.KeyChar == 'a' || key.KeyChar == 's' || key.KeyChar == 'd')
                {
                    input = key.KeyChar;
                    break;
                }
            } while (true);

            if (input == 'w')
            {
                Console.SetCursorPosition(currentPosition[0], currentPosition[1]);
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(currentPosition[0] + 1, currentPosition[1]);
                Console.ResetColor();

            }

            //if (IsMovementAvailable(input))
            //{
            //
            //}


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

        static void Main(string[] args)
        {
            StartingPosition(CreateMap("path"));
            
        }

    }
}
