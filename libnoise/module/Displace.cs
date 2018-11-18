namespace noise.module
{
    public class Displace : Module {

        public Module Input;
        public Module DisplaceX;
        public Module DisplaceY;
        public Module DisplaceZ;

        public override int GetSourceModuleCount()
        {
            return 4;
        }

        public override double GetValue (double x, double y, double z)
        {
            // Get the output values from the three displacement modules.  Add each
            // value to the corresponding coordinate in the input value.
            double xDisplace = x + (DisplaceX.GetValue (x, y, z));
            double yDisplace = y + (DisplaceY.GetValue (x, y, z));
            double zDisplace = z + (DisplaceZ.GetValue (x, y, z));

            // Retrieve the output value using the offsetted input value instead of
            // the original input value.
            return Input.GetValue (xDisplace, yDisplace, zDisplace);
        }
    }
}