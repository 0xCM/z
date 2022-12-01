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
        /// Defines the operator eqz:T = eq(a,b) ? ones[T] : zero[T]
        /// </summary>
        /// <param name="a">The first operand</param>
        /// <param name="b">The second operand</param>
        /// <typeparam name="T">The numeric type</typeparam>
        [MethodImpl(Inline), Eqz, Closures(AllNumeric)]
        public static T eqz<T>(T a, T b)
            where T : unmanaged
                => gmath.mul(Numeric.force<T>((uint)eq(a,b)), ones<T>());
    }
}