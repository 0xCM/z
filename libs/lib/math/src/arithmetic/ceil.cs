//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        /// <summary>
        /// Computes the smallest integral value greater than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Ceil]
        public static float ceil(float src)
            => MathF.Ceiling(src);

        /// <summary>
        /// Computes the smallest integral value greater than or equal to the source value
        /// </summary>
        /// <param name="src">The source value</param>
        [MethodImpl(Inline), Ceil]
        public static double ceil(double src)
            => Math.Ceiling(src);
    }
}