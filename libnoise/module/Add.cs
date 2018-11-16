namespace noise.module
{
    public class Add : Module {
        public Module InputA;
        public Module InputB;

        public override int GetSourceModuleCount()
        {
          return 2;
        }

        public override double GetValue (double x, double y, double z) 
        {
            return InputA.GetValue (x, y, z) + InputB.GetValue (x, y, z);
        }
    }
}