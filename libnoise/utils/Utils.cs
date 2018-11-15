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

    }
}