using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Defusing_The_Bomb___Easy
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file = File.ReadAllLines("input.txt");
            bool defused = true;

            string prevCable = "";

            foreach (string cable in file)
            {
                if (cable.Equals(file[0])) //first 
                {
                    continue;
                }
                else
                {
                    switch (prevCable)
                    {
                        case "white": //can't be white or black
                            if (cable.Equals("white") || cable.Equals("black"))
                            {
                                defused = false;
                            }
                            break;
                        case "red": //must be green
                            if (!cable.Equals("green"))
                            {
                                defused = false;
                            }
                            break;
                        case "black": //can't be white, green or orange
                            if (cable.Equals("white") || cable.Equals("green") || cable.Equals("orange"))
                            {
                                defused = false;
                            }
                            break;
                        case "orange": //must be red or black
                            if (!cable.Equals("red") && !(cable.Equals("black")))
                            {
                                defused = false;
                            }
                            break;
                        case "green": //must be orange or white
                            if (!cable.Equals("orange") && !(cable.Equals("white")))
                            {
                                defused = false;
                            }
                            break;
                        case "purple": //can't be purple, green, orange or white
                            if (cable.Equals("purple") || cable.Equals("green") || cable.Equals("orange") || cable.Equals("white"))
                            {
                                defused = false;
                            }
                            break;
                        default: break;
                    }

                    if (!defused)
                    {
                        Console.WriteLine("Boom");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        prevCable = cable;
                    }
                }
            }

            if (defused)
            {
                Console.WriteLine("Bomb defused");
                Console.ReadKey();
            }
        }
    }
}
