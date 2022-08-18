//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class gbits
    {
        /// <summary>
        /// Defines a mask that disables a sequence of bits
        /// </summary>
        /// <param name="start">The index at which to begin</param>
        /// <param name="count">The number of bits to disable</param>
        /// <typeparam name="T">The primal type over which the mask is defined</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T eraser<T>(byte start, byte count)
            where T : unmanaged
                => gmath.xor(Limits.maxval<T>(), gmath.sll(BitMasks.lo<T>((byte)(count - 1)), start));
    }
}