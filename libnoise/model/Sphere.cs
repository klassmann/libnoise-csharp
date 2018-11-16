
using noise.module;
using noise.utils;

namespace noise.model
{
    public class Sphere {

        private Module _module;

        public Sphere(Module m)
        {
            _module = m;
        }

        public double GetValue (double lat, double lon) {
            double x = 0.0, y = 0.0, z = 0.0;
            Utils.LatLonToXYZ(lat, lon, ref x, ref y, ref z);
            return _module.GetValue (x, y, z);
        }
    }
}