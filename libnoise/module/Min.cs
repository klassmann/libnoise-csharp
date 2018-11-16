
using noise.utils;

namespace noise.module
{
    public class Min : Module {

        public override int GetSourceModuleCount()
        {
            return 2;
        }

        public override double GetValue(double x, double y, double z)
        {
            double v0 = _sourceModules[0].GetValue (x, y, z);
            double v1 = _sourceModules[1].GetValue (x, y, z);
            return Utils.GetMin (v0, v1);
        }
    }
}