using System;
using System.IO;
using System.Text;

namespace Labirintus
{
    class Program
    {
        static void Main(string[] args)
        {
            //Betöltés
            Console.WriteLine("[1] 1. pálya");
            Console.WriteLine("[2] 2. pálya");
            Console.WriteLine("[3] 3. pálya");

            int kulsoValtozo = 0;

            while (true)
            {

                Console.Write("Melyik pályát szeretné betölteni:");
                int kivalasztott = Convert.ToInt32(Console.ReadLine());

                if (kivalasztott == 1 || kivalasztott == 2 || kivalasztott == 3)
                {
                    kulsoValtozo = kivalasztott;
                    break;
                }

                else
                {
                    Console.WriteLine("Hibás Bevitel!");
                }
            }

            Console.Clear();

            var path = "Maps/map" + kulsoValtozo + ".txt";

            string map = File.ReadAllText(path, Encoding.UTF8);

            Console.WriteLine(map);


            //Mentés
            Console.Write("Kérem adja meg  pálya nevét:");
            string mapName = Console.ReadLine();

            string save = File.WriteAllLines();
        }
    }
}
