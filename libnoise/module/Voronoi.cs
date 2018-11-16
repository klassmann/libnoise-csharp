
using System;
using noise.utils;
using noise.math;

namespace noise.module
{
    public class Voronoi : Module {

        const double DEFAULT_VORONOI_DISPLACEMENT = 1.0;
        const double DEFAULT_VORONOI_FREQUENCY = 1.0;
        const int DEFAULT_VORONOI_SEED = 0;

        public double Displacement = DEFAULT_VORONOI_DISPLACEMENT;
        public bool EnableDistance;
        public double Frequency = DEFAULT_VORONOI_FREQUENCY;
        public int Seed = DEFAULT_VORONOI_SEED;

        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public override double GetValue(double x, double y, double z)
        {
            // This method could be more efficient by caching the seed values.  Fix
            // later.

            x *= Frequency;
            y *= Frequency;
            z *= Frequency;

            int xInt = (x > 0.0? (int)x: (int)x - 1);
            int yInt = (y > 0.0? (int)y: (int)y - 1);
            int zInt = (z > 0.0? (int)z: (int)z - 1);

            double minDist = 2147483647.0;
            double xCandidate = 0;
            double yCandidate = 0;
            double zCandidate = 0;

            // Inside each unit cube, there is a seed point at a random position.  Go
            // through each of the nearby cubes until we find a cube with a seed point
            // that is closest to the specified position.
            for (int zCur = zInt - 2; zCur <= zInt + 2; zCur++) {
                for (int yCur = yInt - 2; yCur <= yInt + 2; yCur++) {
                for (int xCur = xInt - 2; xCur <= xInt + 2; xCur++) {

                    // Calculate the position and distance to the seed point inside of
                    // this unit cube.
                    double xPos = xCur + Utils.ValueNoise3D (xCur, yCur, zCur, Seed    );
                    double yPos = yCur + Utils.ValueNoise3D (xCur, yCur, zCur, Seed + 1);
                    double zPos = zCur + Utils.ValueNoise3D (xCur, yCur, zCur, Seed + 2);
                    double xDist = xPos - x;
                    double yDist = yPos - y;
                    double zDist = zPos - z;
                    double dist = xDist * xDist + yDist * yDist + zDist * zDist;

                    if (dist < minDist) {
                    // This seed point is closer to any others found so far, so record
                    // this seed point.
                    minDist = dist;
                    xCandidate = xPos;
                    yCandidate = yPos;
                    zCandidate = zPos;
                    }
                }
                }
            }

            double value;
            if (EnableDistance) {
                // Determine the distance to the nearest seed point.
                double xDist = xCandidate - x;
                double yDist = yCandidate - y;
                double zDist = zCandidate - z;
                value = (Math.Sqrt(xDist * xDist + yDist * yDist + zDist * zDist)
                ) * MathConst.SQRT_3 - 1.0;
            } else {
                value = 0.0;
            }

            // Return the calculated distance with the displacement value applied.
            return value + (Displacement * (double)Utils.ValueNoise3D (
                (int)(Math.Floor (xCandidate)),
                (int)(Math.Floor (yCandidate)),
                (int)(Math.Floor (zCandidate))));
        }

    }
}