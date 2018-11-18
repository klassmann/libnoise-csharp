using System;
using System.Drawing;

using noise;

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

        static Color GetTerrainColorRamp(double v) {
            if (v < -0.35) {
                return Color.FromArgb(255, 25, 47, 81);
            } else if (v < -0.25) {
                return Color.FromArgb(255, 36, 79, 147);
            } else if (v < -0.15) {
                return Color.FromArgb(255, 47, 96, 175);
            } else if (v < -0.1) {
                return Color.FromArgb(255, 30, 96, 204);
            } else if (v < 0.0) {
                return Color.FromArgb(255, 42, 117, 237);
            } else if (v < 0.1) {
                return Color.FromArgb(255, 232, 227, 201);
            } else if (v < 0.2) {
                return Color.FromArgb(255, 130, 142, 102);
            } else if (v < 0.5) {
                return Color.FromArgb(255, 89, 132, 71);
            } else if (v < 0.7) {
                return Color.FromArgb(255, 55, 89, 41);
            } else if (v < 0.8) {
                return Color.FromArgb(255, 68, 81, 62);
            } else if (v < 0.85) {
                return Color.FromArgb(255, 90, 91, 89);
            } else if (v < 0.90) {
                return Color.FromArgb(255, 121, 122, 121);
            } else if (v <= 0.9995) {
                return Color.FromArgb(255, 186, 188, 186);
            } else if (v <= 1.0 - 0.000001) {
                return Color.FromArgb(255, 200, 200, 200);
            }
            return Color.FromArgb(255, 242, 242, 242);
        }


        static void checkerBoard() {
            Console.WriteLine("CheckerBoard:");
            noise.module.Module p = new noise.module.CheckerBoard();
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

            noise.module.Module p = new noise.module.Perlin();
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

            noise.module.Module p = new noise.module.Voronoi();
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

        static void generateBitmap(noise.module.Module m, string filename) {
            const int SIZE = 512;
            var r = new Random();
            var output = new ImageGenerator(SIZE, SIZE);
            var colors = new Color[SIZE,SIZE];

            for (int x = 0; x < SIZE; x++) {
                for (int y = 0; y < SIZE; y++) {
                    var v = m.GetValue(x, 0.0, y);
                    colors[x, y] = GetTerrainColorRamp(v);
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
            var m = new noise.module.Billow();

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

        static void generateSphereTerrainExample() {
            const int SIZE = 180;
            var r = new Random();
            var output = new ImageGenerator(SIZE, SIZE);
            var colors = new Color[SIZE,SIZE];
            var m = new noise.module.Billow();
            // m.Frequency = 0.1;
            var model = new noise.model.Sphere(m);


            for (int x = 0; x < SIZE; x++) {
                for (int y = 0; y < SIZE; y++) {
                    var v = model.GetValue(x, y);
                    colors[x, y] = GetTerrainColorRamp(v);
                }
            }
            output.Draw(colors);
            output.SaveToFile("terrain_sphere.bmp");
        }

        static void generateTerrainExperiment() {
            const int SIZE = 128;
            var r = new Random();
            var output = new ImageGenerator(SIZE, SIZE);
            var colors = new Color[SIZE,SIZE];
            var billow = new noise.module.Billow();
            billow.Frequency = 0.01;
            billow.NoiseQuality = NoiseQuality.QUALITY_BEST;
            billow.OctaveCount = 30;
            // billow.Lacunarity = 0.5;
            // billow.Persistence = 0.1;


            var perlin = new noise.module.Perlin();
            perlin.NoiseQuality = NoiseQuality.QUALITY_FAST;
            perlin.Frequency = 0.01;
            perlin.OctaveCount = 12;

            var mul = new noise.module.Multiply();
            mul.InputB = billow;
            mul.InputA = perlin;
            
            var model = new noise.model.Plane(mul);

            for (int x = 0; x < SIZE; x++) {
                for (int y = 0; y < SIZE; y++) {
                    var v = model.GetValue(x, y);

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
                        colors[x, y] = Color.FromArgb(255, 57, 73, 48);
                    } else if (v < 0.9995) {
                        colors[x, y] = Color.FromArgb(255, 82, 89, 57);
                    } else if (v < 1.0 - 0.000001) {
                        colors[x, y] = Color.FromArgb(255, 112, 117, 85);
                    } else if (v < 1.0 - 0.0000001) {
                        colors[x, y] = Color.FromArgb(255, 122, 120, 99);
                    } else if (v < 1.0 - 0.0000000000000000000000000000000001) {
                        colors[x, y] = Color.FromArgb(255, 99, 97, 75);
                    } else {
                        colors[x, y] = Color.FromArgb(255, 120, 120, 120);
                    }
                }
            }
            output.Draw(colors);
            output.SaveToFile("terrain_experiment.bmp");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("LibNoise");

            // var perlin = new noise.module.Perlin();
            // perlin.OctaveCount = 1;
            // perlin.Frequency = 0.05;
            // generateBitmap(perlin, "perlin.bmp");

            // var voronoi = new noise.module.Voronoi();
            // voronoi.Frequency = 0.05;
            // generateBitmap(voronoi, "voronoi.bmp");

            // var checkerBoard = new noise.module.CheckerBoard();
            // generateBitmap(checkerBoard, "checkerboard.bmp");

            // var spheres = new noise.module.Spheres();
            // spheres.Frequency = 0.05;
            // generateBitmap(spheres, "spheres.bmp");

            // generateSphereTerrainExample();
            // generateTerrainExperiment();

            
            // var perlin = new noise.module.Perlin();
            // perlin.OctaveCount = 1;
            // perlin.Frequency = 0.05;
            // generateBitmap(perlin, "perlin.bmp");
            // var ridged = new noise.module.RidgedMulti();
            // var add = new noise.module.Multiply();
            // add.InputA = perlin;
            // add.InputB = ridged;
            // generateBitmap(add, "ridged.bmp");

            // var perlin = new noise.module.Perlin();
            // perlin.OctaveCount = 1;
            // perlin.Frequency = 0.05;
            // generateBitmap(perlin, "perlin.bmp");
            
            // var constM = new noise.module.Const();
            // constM.ConstValue = 0.0;

            // var voronoi = new noise.module.Voronoi();
            // voronoi.Frequency = 0.05;

            // var spheres = new noise.module.Spheres();
            // spheres.Frequency = 0.05;

            // var displace = new noise.module.Displace();
            // displace.Input = perlin;
            // displace.DisplaceX = spheres;
            // displace.DisplaceY = constM;
            // displace.DisplaceZ = spheres;

            // generateBitmap(displace, "displace.bmp");

        }
    }
}
