using noise.module;

namespace noise.model
{
    public class Line {
        private Module _module;

        private double _x0;
        private double _x1;
        private double _y0;
        private double _y1;
        private double _z0;
        private double _z1;

        public bool Attenuate;

        public Line(Module m)
        {
            _module = m;
        }

        public void SetStartPoint(double x, double y, double z)
        {
            _x0 = x;
            _y0 = y;
            _z0 = z;
        }

        public void SetEndPoint(double x, double y, double z)
        {
            _x1 = x;
            _y1 = y;
            _z1 = z;
        }

        public double GetValue(double p) {
            double x = (_x1 - _x0) * p + _x0;
            double y = (_y1 - _y0) * p + _y0;
            double z = (_z1 - _z0) * p + _z0;
            double value = _module.GetValue(x, y, z);

            if (Attenuate) {
                return p * (1.0 - p) * 4 * value;
            } else {
                return value;
            }
        }

    }
}