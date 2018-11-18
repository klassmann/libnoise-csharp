namespace noise.module
{
    public class Const : Module {
        
        public double ConstValue;
        
        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public override double GetValue(double x, double y, double z)
        {
            return ConstValue;
        }
    }
}