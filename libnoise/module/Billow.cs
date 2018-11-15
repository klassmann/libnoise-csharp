namespace noise.module
{
    public class Billow : Module {
        private const double DEFAULT_BILLOW_FREQUENCY = 1.0;
        private const double DEFAULT_BILLOW_LACUNARITY = 2.0;
        private const int DEFAULT_BILLOW_OCTAVE_COUNT = 6;
        private const double DEFAULT_BILLOW_PERSISTENCE = 0.5;
        private const NoiseQuality DEFAULT_BILLOW_QUALITY = NoiseQuality.QUALITY_STD;
        private const int DEFAULT_BILLOW_SEED = 0;
        private const int BILLOW_MAX_OCTAVE = 30;

        public double Frequency = DEFAULT_BILLOW_FREQUENCY;
        public double Lacunarity = DEFAULT_BILLOW_LACUNARITY;
        public NoiseQuality NoiseQuality = DEFAULT_BILLOW_QUALITY;
        public int OctaveCount = DEFAULT_BILLOW_OCTAVE_COUNT;
        public double Persistence = DEFAULT_BILLOW_PERSISTENCE;
        public int Seed = DEFAULT_BILLOW_SEED;

        public override int GetSourceModuleCount()
        {
          return 0;
        }

        public double GetValue (double x, double y, double z)
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
                nx = MakeInt32Range (x);
                ny = MakeInt32Range (y);
                nz = MakeInt32Range (z);

                // Get the coherent-noise value from the input value and add it to the
                // final result.
                seed = (m_seed + curOctave) & 0xffffffff;
                signal = GradientCoherentNoise3D (nx, ny, nz, seed, m_noiseQuality);
                signal = 2.0 * fabs (signal) - 1.0;
                value += signal * curPersistence;

                // Prepare the next octave.
                x *= Lacunarity;
                y *= Lacunarity;
                z *= Lacunarity;
                curPersistence *= Persistence;
            }
            value += 0.5;

            return value;
        }
    }
}