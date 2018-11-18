
using System;
using noise.utils;

namespace noise.module
{
    public class RidgedMulti : Module
    {
        const double DEFAULT_RIDGED_FREQUENCY = 1.0;
        const double DEFAULT_RIDGED_LACUNARITY = 2.0;
        const int DEFAULT_RIDGED_OCTAVE_COUNT = 6;
        const NoiseQuality DEFAULT_RIDGED_QUALITY = NoiseQuality.QUALITY_STD;
        const int DEFAULT_RIDGED_SEED = 0;
        const int RIDGED_MAX_OCTAVE = 30;

        public double Frequency;
        public double Lacunarity;
        public NoiseQuality NoiseQuality;
        public int OctaveCount;
        public double[] PSpectralWeights = new double[RIDGED_MAX_OCTAVE];
        public int Seed;

        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public void CalculateSpectralWeights()
        {
            double h = 1.0;
            double frequency = 1.0;
            for (int i = 0; i < RIDGED_MAX_OCTAVE; i++)
            {
                // Compute weight for each frequency.
                PSpectralWeights[i] = Math.Pow(frequency, -h);
                frequency *= Lacunarity;
            }
        }

        public override double GetValue(double x, double y, double z)
        {
            x *= Frequency;
            y *= Frequency;
            z *= Frequency;

            double signal = 0.0;
            double value = 0.0;
            double weight = 1.0;
            double offset = 1.0;
            double gain = 2.0;

            for (int curOctave = 0; curOctave < OctaveCount; curOctave++)
            {

                // Make sure that these floating-point values have the same range as a 32-
                // bit integer so that we can pass them to the coherent-noise functions.
                double nx, ny, nz;
                nx = Utils.MakeInt32Range(x);
                ny = Utils.MakeInt32Range(y);
                nz = Utils.MakeInt32Range(z);

                // Get the coherent-noise value.
                int seed = (Seed + curOctave) & 0x7fffffff;
                signal = Utils.GradientCoherentNoise3D(nx, ny, nz, seed, NoiseQuality);

                // Make the ridges.
                signal = Math.Abs(signal);
                signal = offset - signal;

                // Square the signal to increase the sharpness of the ridges.
                signal *= signal;

                // The weighting from the previous octave is applied to the signal.
                // Larger values have higher weights, producing sharp points along the
                // ridges.
                signal *= weight;

                // Weight successive contributions by the previous signal.
                weight = signal * gain;
                if (weight > 1.0)
                {
                    weight = 1.0;
                }
                if (weight < 0.0)
                {
                    weight = 0.0;
                }

                // Add the signal to the output value.
                value += (signal * PSpectralWeights[curOctave]);

                // Go to the next octave.
                x *= Lacunarity;
                y *= Lacunarity;
                z *= Lacunarity;
            }

            return (value * 1.25) - 1.0;
        }

    }
}