// using System;

// using noise.module;
// using noise.math;

// namespace noise.model
// {
//     public class Cylinder
//     {

//         private Module _m;
//         public Cylinder(Module m)
//         {
//             _m = m;
//         }

//         public double GetValue(double angle, double height)
//         {
//             // assert (m_pModule != NULL);

//             double x, y, z;
//             x = Math.Cos(angle * MathConst::DEG_TO_RAD);
//             y = height;
//             z = Math.Sin(angle * MathConst::DEG_TO_RAD);
//             return m_pModule->GetValue(x, y, z);
//         }
//     }
// }
