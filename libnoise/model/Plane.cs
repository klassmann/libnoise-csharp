using noise.module;

namespace noise.model
{
    public class Plane {
        private Module _module;
        
        public Plane(Module m)
        {
            _module = m;
        }

        public double GetValue(double x, double z) {
              return _module.GetValue(x, 0.0, z);
        }
    }
}