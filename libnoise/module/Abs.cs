namespace noise.module
{
    public class Abs : Module {
        public override int GetSourceModuleCount() {
            return 1;
        }

        public override double GetValue(double x, double y, double z) {
            return _sourceModules[0].GetValue(x, y, z);
        }
    }
}