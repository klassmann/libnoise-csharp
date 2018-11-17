using System;
using noise.utils;

namespace noise.module
{
    public class Cylinders : Module
    {
        public double Frequency;

        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public override double GetValue(double x, double y, double z)
        {
            x *= Frequency;
            z *= Frequency;

            double distFromCenter = Math.Sqrt(x * x + z * z);
            double distFromSmallerSphere = distFromCenter - Math.Floor(distFromCenter);
            double distFromLargerSphere = 1.0 - distFromSmallerSphere;
            double nearestDist = Utils.GetMin(distFromSmallerSphere, distFromLargerSphere);
            return 1.0 - (nearestDist * 4.0); // Puts it in the -1.0 to +1.0 range.
        }
    }
}