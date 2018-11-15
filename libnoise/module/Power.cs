using System;

namespace noise.module
{
    public class Power : Module {
        public int GetSourceModuleCount()
        {
            return 2;
        }

        public double GetValue(double x, double y, double z)
        {
            return Math.Pow(_sourceModules[0].GetValue (x, y, z),
                _sourceModules[1].GetValue (x, y, z));
        }

    }
}