using System;

using noise;
using noise.module;

namespace libnoise_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Perlin p = new Perlin();
            for (double x = 0.0; x < 15.0; x++) {
                for (double y = 0.0; y < 35.0; y++)
                    Console.Write(p.GetValue(x, y, 1.0));
                Console.WriteLine();
            }
        }
    }
}
