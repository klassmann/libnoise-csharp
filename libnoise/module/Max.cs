
using noise.utils;

namespace noise.module
{
    public class Max : Module {

        public Module InputA;
        public Module InputB;

        public override int GetSourceModuleCount()
        {
            return 2;
        }

        public override double GetValue (double x, double y, double z)
        {
            double v0 = InputA.GetValue (x, y, z);
            double v1 = InputB.GetValue (x, y, z);
            return Utils.GetMax(v0, v1);
        }
    }
}