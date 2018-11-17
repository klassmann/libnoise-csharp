namespace noise.module
{
    public class Clamp : Module {
        const double DEFAULT_CLAMP_LOWER_BOUND = -1.0;
        const double DEFAULT_CLAMP_UPPER_BOUND = 1.0;

        public double LowerBound = DEFAULT_CLAMP_LOWER_BOUND;
        public double UpperBound = DEFAULT_CLAMP_UPPER_BOUND;

        public override int GetSourceModuleCount()
        {
            return 1;
        }

        public override double GetValue (double x, double y, double z)
        {
            double value = _sourceModules[0].GetValue (x, y, z);
            if (value < LowerBound) {
                return LowerBound;
            } else if (value > UpperBound) {
                return UpperBound;
            } else {
                return value;
            }
        }
    }
}