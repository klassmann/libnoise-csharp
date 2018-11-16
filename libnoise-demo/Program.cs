using System;
using System.Drawing;

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

        static void generateBitmap(Module m, string filename) {
            const int SIZE = 512;
            var r = new Random();
            var output = new ImageGenerator(SIZE, SIZE);
            var colors = new Color[SIZE,SIZE];

            for (int x = 0; x < SIZE; x++) {
                for (int y = 0; y < SIZE; y++) {
                    var v = m.GetValue(x, y, 0.5);//r.NextDouble());
                    colors[x, y] = Color.FromArgb(255, 125, 255 - (int)(((2.0 + v) * 125) % 200), 125);
                }
            }
            output.Draw(colors);
            output.SaveToFile(filename);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LibNoise");
            // checkerBoard();
            // perlin();
            // voronoi();
            var perlin = new Perlin();
            perlin.OctaveCount = 3;
            perlin.Frequency = 0.14;
            generateBitmap(perlin, "perlin.bmp");

            var voronoi = new Voronoi();
            voronoi.Frequency = 0.3;
            generateBitmap(voronoi, "voronoi.bmp");

            var checkerBoard = new CheckerBoard();
            generateBitmap(checkerBoard, "checkerboard.bmp");

            var spheres = new Spheres();
            spheres.Frequency = 0.3;
            generateBitmap(spheres, "spheres.bmp");

        }
    }
}
