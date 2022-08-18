//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class fmath
    {
        partial struct RefOps
        {
            /// <summary>
            /// Computes the modulus of the first operand over the second
            /// </summary>
            /// <param name="a">The first operand</param>
            /// <param name="b">The second operand</param>
            [MethodImpl(Inline), Mod]
            public static float mod(float a, float b)
                => a % b;

            /// <summary>
            /// Computes the modulus of the first operand over the second
            /// </summary>
            /// <param name="a">The first operand</param>
            /// <param name="b">The second operand</param>
            [MethodImpl(Inline), Mod]
            public static double mod(double a, double b)
                => a % b;

            /// <summary>
            /// Computes dst = (div(a,b), mod(a,b))
            /// </summary>
            /// <param name="a">The dividend</param>
            /// <param name="b">The divisor</param>
            [MethodImpl(Inline), DivMod]
            public static ConstPair<float> divmod(float a, float b)
                => (div(a,b), mod(a,b));

            /// <summary>
            /// Computes dst = (div(a,b), mod(a,b))
            /// </summary>
            /// <param name="a">The dividend</param>
            /// <param name="b">The divisor</param>
            [MethodImpl(Inline), DivMod]
            public static ConstPair<double> divmod(double a, double b)
                => (div(a,b), mod(a,b));
        }
    }
}