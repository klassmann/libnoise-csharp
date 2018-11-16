using System;

using noise;
using noise.module;

namespace libnoise_demo
{

    class Program
    {

        static void checkerBoard() {
            Console.WriteLine("CheckerBoard:");
            Module p = new CheckerBoard();
            for (double x = 0.0; x < 15.0; x++) {
                for (double y = 0.0; y < 35.0; y++) {
                    var v = p.GetValue(x, y, 0.0);
                    if (v == 1) {
                        Console.Write("0");
                    } else {
                        Console.Write("X");
                    }
                }
                    
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LibNoise");
            checkerBoard();
        }
    }
}
