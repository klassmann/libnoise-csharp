
using System;

namespace noise.module
{
    public class ScaleBias : Module {
        const double DEFAULT_BIAS = 0.0;
        const double DEFAULT_SCALE = 1.0;

        double Bias;
        double Scale;

        public override int GetSourceModuleCount()
        {
            return 1;
        }

        public override double GetValue(double x, double y, double z)
        {
            return _sourceModules[0].GetValue(x, y, z) * Scale + Bias;
        }
    }
    
}