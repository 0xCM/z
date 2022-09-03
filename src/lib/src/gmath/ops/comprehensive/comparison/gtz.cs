//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class gmath
    {
        /// <summary>
        /// Defines the operator gtz:T = gt(a,b) ? ones[T] : zero[T]
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Gtz, Closures(Integers)]
        public static T gtz<T>(T a, T b)
            where T : unmanaged
                => gmath.mul(Numeric.force<T>((uint)gt(a,b)), ones<T>());
    }
}