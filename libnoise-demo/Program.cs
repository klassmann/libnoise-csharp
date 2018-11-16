using System;

using noise;
using noise.module;

namespace libnoise_demo
{

    class Program
    {
        static string[] gradient = new string[] {
            "░", "▒", "▓", "█"
        };

        static void draw(int n) {
            Console.Write(gradient[n % 4]);
        }

        static void checkerBoard() {
            Console.WriteLine("CheckerBoard:");
            Module p = new CheckerBoard();
            for (double x = 0.0; x < 10.0; x++) {
                for (double y = 0.0; y < 10.0; y++) {
                    var v = p.GetValue(x, y, 0.0);
                    if (v == 1) {
                        draw(0);
                    } else {
                        draw(2);
                    }
                }
                    
                Console.WriteLine();
            }
        }

        static void perlin() {
            Console.WriteLine("Perlin:");

            Module p = new Perlin();
            var r = new Random();
            for (double x = 0.0; x < 20.0; x++) {
                for (double y = 0.0; y < 80.0; y++) {
                    var v = p.GetValue(x, y, r.NextDouble());
                    if (v < -0.5) {
                        draw(0);
                    } else if (v < 0.0) {
                        draw(1);
                    } else if (v < 0.5) {
                        draw(2);
                    } else {
                        draw(3);
                    }
                }
                    
                Console.WriteLine();
            }
        }

        static void voronoi() {
            Console.WriteLine("Voronoi:");

            Module p = new Voronoi();
            var r = new Random();
            for (double x = 0.0; x < 20.0; x++) {
                for (double y = 0.0; y < 80.0; y++) {
                    var v = p.GetValue(x, y, r.NextDouble());
                    if (v < -0.5) {
                        draw(0);
                    } else if (v < 0.0) {
                        draw(1);
                    } else if (v < 0.5) {
                        draw(2);
                    } else {
                        draw(3);
                    }
                }
                    
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LibNoise");
            checkerBoard();
            perlin();
            voronoi();

        }
    }
}
