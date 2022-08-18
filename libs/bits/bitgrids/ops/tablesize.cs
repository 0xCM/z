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
    using static gmath;

    partial class BitGrid
    {
        /// <summary>
        /// Computes the number of bytes required to cover a grid, predicated on row/col counts
        /// </summary>
        /// <param name="rows">The number of grid rows</param>
        /// <param name="cols">The number of grid columns</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T tablesize<T>(T rows, T cols)
            where T : unmanaged
        {
            var points = mul(rows, cols);
            var module = mod(points, Numeric.force<T>(8));
            var remains = nonz(module) ? one<T>() : core.zero<T>();
            return add(gmath.srl(points, 3), remains);
        }

        [MethodImpl(Inline), Op]
        public static ulong tablesize(ulong rows, ulong cols)
        {
            var points = rows*cols;
            var mod = math.mod(points, 8ul);
            var rem = math.nonz(mod) ? 1ul : 0ul;
            return math.add(math.srl(points, 3), rem);
        }
    }
}