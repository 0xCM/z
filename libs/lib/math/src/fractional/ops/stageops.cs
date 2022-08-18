//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class fmath
    {
        partial struct StageOps
        {
            /// <summary>
            ///
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <remarks>
            /// Taken from https://stackoverflow.com/questions/46790237/vectorization-of-modulo-multiplication
            /// </remarks>
            [MethodImpl(Inline), Mod]
            public static float mod(float a, float b)
                => sub(a, mul(div(a, b), b));

            /// <summary>
            ///
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <remarks>
            /// Taken from https://stackoverflow.com/questions/46790237/vectorization-of-modulo-multiplication
            /// </remarks>
            [MethodImpl(Inline), Mod]
            public static double mod(double a, double b)
                => sub(a, mul(div(a, b), b));
        }
    }
}