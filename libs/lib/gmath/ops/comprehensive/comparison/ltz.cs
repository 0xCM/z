//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class gmath
    {
        /// <summary>
        /// Defines the operator ltz:T = lt(a,b) ? ones[T] : zero[T]
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Ltz, Closures(Integers)]
        public static T ltz<T>(T a, T b)
            where T : unmanaged
                => gmath.mul(Numeric.force<T>((uint)gmath.lt(a,b)), core.ones<T>());
    }
}