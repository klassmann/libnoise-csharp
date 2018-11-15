namespace noise.module
{
    public class Add : Module {
        public override int GetSourceModuleCount()
        {
          return 2;
        }

        public override double GetValue (double x, double y, double z) 
        {
            return _sourceModules[0].GetValue (x, y, z)
                + _sourceModules[1].GetValue (x, y, z);
        }
    }
}