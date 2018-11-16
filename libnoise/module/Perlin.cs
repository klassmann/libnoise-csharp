
using noise.utils;

namespace noise.module
{
    public class Perlin : Module {

        const double DEFAULT_PERLIN_FREQUENCY = 1.0;
        const double DEFAULT_PERLIN_LACUNARITY = 2.0;
        const int DEFAULT_PERLIN_OCTAVE_COUNT = 6;
        const double DEFAULT_PERLIN_PERSISTENCE = 0.5;
        const NoiseQuality DEFAULT_PERLIN_QUALITY = NoiseQuality.QUALITY_STD;
        const int DEFAULT_PERLIN_SEED = 0;
        const int PERLIN_MAX_OCTAVE = 30;

        public double Frequency = DEFAULT_PERLIN_FREQUENCY;
        public double Lacunarity = DEFAULT_PERLIN_LACUNARITY;
        public NoiseQuality NoiseQuality = DEFAULT_PERLIN_QUALITY;
        public int OctaveCount = DEFAULT_PERLIN_OCTAVE_COUNT;
        public double Persistence = DEFAULT_PERLIN_PERSISTENCE;
        public int Seed = DEFAULT_PERLIN_SEED;

        public override int GetSourceModuleCount()
        {
            return 0;
        }

        public override double GetValue(double x, double y, double z)
        {
            double value = 0.0;
            double signal = 0.0;
            double curPersistence = 1.0;
            double nx, ny, nz;
            int seed;

            x *= Frequency;
            y *= Frequency;
            z *= Frequency;

            for (int curOctave = 0; curOctave < OctaveCount; curOctave++) {

                // Make sure that these floating-point values have the same range as a 32-
                // bit integer so that we can pass them to the coherent-noise functions.
                nx = Utils.MakeInt32Range (x);
                ny = Utils.MakeInt32Range (y);
                nz = Utils.MakeInt32Range (z);

                // Get the coherent-noise value from the input value and add it to the
                // final result.
                seed = (int)((Seed + curOctave) & 0xffffffff);
                signal = Utils.GradientCoherentNoise3D (nx, ny, nz, seed, NoiseQuality);
                value += signal * curPersistence;

                // Prepare the next octave.
                x *= Lacunarity;
                y *= Lacunarity;
                z *= Lacunarity;
                curPersistence *= Persistence;
            }

            return value;
        }
    }
}