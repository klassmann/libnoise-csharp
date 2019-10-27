
using System;

namespace noise.module
{
    public class Abs : Module
    {
        private const int ModuleCount = 1;

        public Abs() : base(ModuleCount)
        {

        }

        public override int GetSourceModuleCount()
        {
            return ModuleCount;
        }

        public override double GetValue(double x, double y, double z)
        {
            return Math.Abs(GetSourceModule(0).GetValue(x, y, z));
        }
    }
}