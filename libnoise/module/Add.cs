namespace noise.module
{
    public class Add : Module
    {
        private const int ModuleCount = 2;

        public Add() : base(ModuleCount)
        {
        }

        public override int GetSourceModuleCount()
        {
            return ModuleCount;
        }

        public override double GetValue(double x, double y, double z)
        {
            return GetSourceModule(0).GetValue(x, y, z) +
                    GetSourceModule(0).GetValue(x, y, z);
        }
    }
}