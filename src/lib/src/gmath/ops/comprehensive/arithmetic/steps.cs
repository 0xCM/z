//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static Numeric;

    partial class gmath
    {
        /// <summary>
        /// Populates a memory target with values first, first + 1*step, first + 2*step ... first + (n - 1)*step
        /// </summary>
        /// <param name="first">The first value</param>
        /// <param name="step">The step size</param>
        /// <param name="count">The number of values to produce</param>
        /// <param name="dst">The memory target</param>
        /// <typeparam name="T">The target value type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers)]
        public static void steps<T>(T first, T step, int count, ref T dst)
            where T : unmanaged
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = add(first, mul(force<T>(i),step));
        }

        [MethodImpl(Inline), Op, Closures(Integers)]
        public static T steps<T>(T x0, T x1, T step)
            where T : unmanaged
                => div(sub(x1, x0),step);
    }
}