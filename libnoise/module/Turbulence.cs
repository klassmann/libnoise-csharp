// namespace noise.module
// {
//     public class Turbulence : Module {

//         // const double DEFAULT_TURBULENCE_FREQUENCY = DEFAULT_PERLIN_FREQUENCY;
//         // const double DEFAULT_TURBULENCE_POWER = 1.0;
//         // const int DEFAULT_TURBULENCE_ROUGHNESS = 3;
//         // const int DEFAULT_TURBULENCE_SEED = DEFAULT_PERLIN_SEED;

//         public override int GetSourceModuleCount()
//         {
//           return 1;
//         }

//         public override double GetValue (double x, double y, double z)
//         {

//             double x0, y0, z0;
//             double x1, y1, z1;
//             double x2, y2, z2;
//             x0 = x + (12414.0 / 65536.0);
//             y0 = y + (65124.0 / 65536.0);
//             z0 = z + (31337.0 / 65536.0);
//             x1 = x + (26519.0 / 65536.0);
//             y1 = y + (18128.0 / 65536.0);
//             z1 = z + (60493.0 / 65536.0);
//             x2 = x + (53820.0 / 65536.0);
//             y2 = y + (11213.0 / 65536.0);
//             z2 = z + (44845.0 / 65536.0);
//             double xDistort = x + (m_xDistortModule.GetValue (x0, y0, z0)
//                 * m_power);
//             double yDistort = y + (m_yDistortModule.GetValue (x1, y1, z1)
//                 * m_power);
//             double zDistort = z + (m_zDistortModule.GetValue (x2, y2, z2)
//                 * m_power);

//             // Retrieve the output value at the offsetted input value instead of the
//             // original input value.
//             return _sourceModules[0].GetValue (xDistort, yDistort, zDistort);
//         }
//     }
// }