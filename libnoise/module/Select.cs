using System;

using noise.utils;

namespace noise.module
{
    public class Select : Module {
        const double DEFAULT_SELECT_EDGE_FALLOFF = 0.0;
        const double DEFAULT_SELECT_LOWER_BOUND = -1.0;
        const double DEFAULT_SELECT_UPPER_BOUND = 1.0;

        private double EdgeFalloff;
        private double LowerBound;
        private double UpperBound;

        public override int GetSourceModuleCount()
        {
            return 3;
        }
        public void SetBounds(double lowerBound, double upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            SetEdgeFalloff(EdgeFalloff);
        }

        public void SetEdgeFalloff(double edgeFalloff)
        {
            double boundSize = UpperBound - LowerBound;
            EdgeFalloff = (edgeFalloff > boundSize / 2)? boundSize / 2: edgeFalloff;
        }

        public override double GetValue(double x, double y, double z)
        {
            double controlValue = _sourceModules[2].GetValue (x, y, z);
            double alpha;

            if (EdgeFalloff > 0.0) {
                if (controlValue < (LowerBound - EdgeFalloff)) {
                    return _sourceModules[0].GetValue (x, y, z);
                } else if (controlValue < (LowerBound + EdgeFalloff)) {
                    double lowerCurve = (LowerBound - EdgeFalloff);
                    double upperCurve = (LowerBound + EdgeFalloff);
                    alpha = Utils.SCurve3((controlValue - lowerCurve) / (upperCurve - lowerCurve));
                    return Utils.LinearInterp (_sourceModules[0].GetValue (x, y, z),
                        _sourceModules[1].GetValue (x, y, z),
                        alpha);
                } else if (controlValue < (UpperBound - EdgeFalloff)) {
                    return _sourceModules[1].GetValue(x, y, z);
                } else if (controlValue < (UpperBound + EdgeFalloff)) {
                    double lowerCurve = (UpperBound - EdgeFalloff);
                    double upperCurve = (UpperBound + EdgeFalloff);
                    alpha = Utils.SCurve3 (
                        (controlValue - lowerCurve) / (upperCurve - lowerCurve));
                    return Utils.LinearInterp (_sourceModules[1].GetValue(x, y, z),
                        _sourceModules[0].GetValue (x, y, z),
                        alpha);
                } else {
                    return _sourceModules[0].GetValue(x, y, z);
                }
            } else {
                if (controlValue < LowerBound || controlValue > UpperBound) {
                    return _sourceModules[0].GetValue (x, y, z);
                } else {
                    return _sourceModules[1].GetValue (x, y, z);
                }
            }
        }
    }
}