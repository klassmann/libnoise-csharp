using System;
using noise.utils;

namespace noise.module
{
    public class CheckerBoard : Module {
        
        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public override double GetValue (double x, double y, double z)
        {
            int ix = (int)(Math.Floor(Utils.MakeInt32Range (x)));
            int iy = (int)(Math.Floor(Utils.MakeInt32Range (y)));
            int iz = (int)(Math.Floor(Utils.MakeInt32Range (z)));
            return (ix & 1 ^ iy & 1 ^ iz & 1) == 1 ? -1.0 : 1.0;
        }
    }
}