namespace noise.module
{
    public class Const : Module
    {
        private const double DEFAULT_CONST_VALUE = 0.0;
        private const int ModuleCount = 0;
        private double _constValue;

        public Const() : base(ModuleCount)
        {
            _constValue = DEFAULT_CONST_VALUE;
        }

        public double GetConstValue()
        {
            return _constValue;
        }

        public void SetConstValue(double value)
        {
            _constValue = value;
        }

        public override int GetSourceModuleCount()
        {
            return ModuleCount;
        }

        public override double GetValue(double x, double y, double z)
        {
            return _constValue;
        }
    }
}