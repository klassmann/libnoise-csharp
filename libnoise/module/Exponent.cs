using System;

namespace noise.module
{
    public class Exponent : Module {

        public Module Input;
        public double ExponentValue;

        public override int GetSourceModuleCount()
        {
            return 1;
        }

        public override double GetValue (double x, double y, double z)
        {
            double value = Input.GetValue (x, y, z);
            return (Math.Pow (Math.Abs ((value + 1.0) / 2.0), ExponentValue) * 2.0 - 1.0);
        }
    }
}