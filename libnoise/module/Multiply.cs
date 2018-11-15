namespace noise.module
{
    public class Multiply : Module {

        public int GetSourceModuleCount()
        {
            return 2;
        }

        public double GetValue (double x, double y, double z)
        {
            return _sourceModules[0].GetValue (x, y, z)
                * _sourceModules[1].GetValue (x, y, z);
        }

    }
}