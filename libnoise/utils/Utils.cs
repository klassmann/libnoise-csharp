using System;
using System.Collections;
using System.Collections.Generic;

namespace noise.utils
{
    public static class Utils {

        public static double GetMax(double a, double b) {
            return (a > b? a: b);
        }

        public static double GetMin(double a, double b) {
            return (a < b? a: b);
        }

        public static void SwapValues(ref double a, ref double b) {
            double c = a;
            a = b;
            b = c;
        }

        public static double LinearInterp (double n0, double n1, double a)
        {
            return ((1.0 - a) * n0) + (a * n1);
        }

        public static double MakeInt32Range (double n)
        {
            if (n >= 1073741824.0) {
                return (2.0 * fmod (n, 1073741824.0)) - 1073741824.0;
            } else if (n <= -1073741824.0) {
                return (2.0 * fmod (n, 1073741824.0)) + 1073741824.0;
            } else {
                return n;
            }
        }

    }
}