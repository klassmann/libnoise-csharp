
using noise.utils;

namespace noise.module
{
    public class Blend : Module {
        public override int GetSourceModuleCount()
        {
            return 3;
        }

        public override double GetValue (double x, double y, double z)
        {
            double v0 = _sourceModules[0].GetValue (x, y, z);
            double v1 = _sourceModules[1].GetValue (x, y, z);
            double alpha = (_sourceModules[2].GetValue (x, y, z) + 1.0) / 2.0;
            return Utils.LinearInterp (v0, v1, alpha);
        }
    }
}