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
                    var v = m.GetValue(x, 0.0, y);//r.NextDouble());
                    colors[x, y] = Color.FromArgb(255, 125, 255 - (int)(((2.0 + v) * 125) % 200), 125);
                }
            }
            output.Draw(colors);
            output.SaveToFile(filename);
        }

        static void generateTerrainExample() {
            const int SIZE = 1024;
            var r = new Random();
            var output = new ImageGenerator(SIZE, SIZE);
            var colors = new Color[SIZE,SIZE];
            var m = new Billow();

            for (int x = 0; x < SIZE; x++) {
                for (int y = 0; y < SIZE; y++) {
                    var v = m.GetValue(x, 0.0, y);

                    if (v < -0.35) {
                        colors[x, y] = Color.FromArgb(255, 25, 47, 81);
                    } else if (v < -0.25) {
                        colors[x, y] = Color.FromArgb(255, 36, 79, 147);
                    } else if (v < -0.15) {
                        colors[x, y] = Color.FromArgb(255, 47, 96, 175);
                    } else if (v < -0.1) {
                        colors[x, y] = Color.FromArgb(255, 30, 96, 204);
                    } else if (v < 0.0) {
                        colors[x, y] = Color.FromArgb(255, 42, 117, 237);
                    } else if (v < 0.1) {
                        colors[x, y] = Color.FromArgb(255, 232, 227, 201);
                    } else if (v < 0.2) {
                        colors[x, y] = Color.FromArgb(255, 130, 142, 102);
                    } else if (v < 0.5) {
                        colors[x, y] = Color.FromArgb(255, 89, 132, 71);
                    } else if (v < 0.7) {
                        colors[x, y] = Color.FromArgb(255, 55, 89, 41);
                    } else if (v < 0.8) {
                        colors[x, y] = Color.FromArgb(255, 68, 81, 62);
                    } else if (v < 0.85) {
                        colors[x, y] = Color.FromArgb(255, 90, 91, 89);
                    } else if (v < 0.90) {
                        colors[x, y] = Color.FromArgb(255, 121, 122, 121);
                    } else if (v <= 0.9995) {
                        colors[x, y] = Color.FromArgb(255, 186, 188, 186);
                    } else if (v <= 1.0 - 0.000001) {
                        colors[x, y] = Color.FromArgb(255, 200, 200, 200);
                    } else {
                        colors[x, y] = Color.FromArgb(255, 242, 242, 242);
                    }
                }
            }
            output.Draw(colors);
            output.SaveToFile("terrain.bmp");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LibNoise");

            var perlin = new Perlin();
            perlin.OctaveCount = 1;
            perlin.Frequency = 0.05;
            generateBitmap(perlin, "perlin.bmp");

            var voronoi = new Voronoi();
            voronoi.Frequency = 0.05;
            generateBitmap(voronoi, "voronoi.bmp");

            var checkerBoard = new CheckerBoard();
            generateBitmap(checkerBoard, "checkerboard.bmp");

            var spheres = new Spheres();
            spheres.Frequency = 0.05;
            generateBitmap(spheres, "spheres.bmp");

        }
    }
}
