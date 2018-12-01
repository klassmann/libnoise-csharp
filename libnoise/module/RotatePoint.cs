using System;

using noise.math;

namespace noise.module
{
    public class RotatePoint : Module 
    {
        const double DEFAULT_ROTATE_X = 0.0;
        const double DEFAULT_ROTATE_Y = 0.0;
        const double DEFAULT_ROTATE_Z = 0.0;

        private double X1Matrix;
        private double X2Matrix;
        private double X3Matrix;
        private double XAngle;
        
        private double Y1Matrix;
        private double Y2Matrix;
        private double Y3Matrix;
        private double YAngle;

        private double Z1Matrix;
        private double Z2Matrix;
        private double Z3Matrix;
        private double ZAngle;

        public RotatePoint() 
        {
            SetAngles(DEFAULT_ROTATE_X, DEFAULT_ROTATE_Y, DEFAULT_ROTATE_Z);
        }

        public override int GetSourceModuleCount()
        {
            return 1;
        }

        public void SetXAngle(double angle)
        {
            SetAngles(angle, YAngle, ZAngle);
        }

        public void SetYAngle(double angle)
        {
            SetAngles(XAngle, angle, ZAngle);
        }

        public void SetZAngle(double angle)
        {
            SetAngles(XAngle, YAngle, angle);
        }

        public void SetAngles (double xAngle, double yAngle, double zAngle)
        {
            double xCos, yCos, zCos, xSin, ySin, zSin;
            xCos = Math.Cos(xAngle * MathConst.DEG_TO_RAD);
            yCos = Math.Cos(yAngle * MathConst.DEG_TO_RAD);
            zCos = Math.Cos(zAngle * MathConst.DEG_TO_RAD);
            xSin = Math.Sin(xAngle * MathConst.DEG_TO_RAD);
            ySin = Math.Sin(yAngle * MathConst.DEG_TO_RAD);
            zSin = Math.Sin(zAngle * MathConst.DEG_TO_RAD);

            X1Matrix = ySin * xSin * zSin + yCos * zCos;
            Y1Matrix = xCos * zSin;
            Z1Matrix = ySin * zCos - yCos * xSin * zSin;
            X2Matrix = ySin * xSin * zCos - yCos * zSin;
            Y2Matrix = xCos * zCos;
            Z2Matrix = -yCos * xSin * zCos - ySin * zSin;
            X3Matrix = -ySin * xCos;
            Y3Matrix = xSin;
            Z3Matrix = yCos * xCos;

            XAngle = xAngle;
            YAngle = yAngle;
            ZAngle = zAngle;
        }

        public override double GetValue(double x, double y, double z)
        {
            double nx = (X1Matrix * x) + (Y1Matrix * y) + (Z1Matrix * z);
            double ny = (X2Matrix * x) + (Y2Matrix * y) + (Z2Matrix * z);
            double nz = (X3Matrix * x) + (Y3Matrix * y) + (Z3Matrix * z);
            return _sourceModules[0].GetValue (nx, ny, nz);
        }
    }
}