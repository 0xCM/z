//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static BitMaskLiterals;
    using static Root;

    partial struct Perm
    {
        /// <summary>
        /// Creates a fixed 16-bit permutation over a generic permutation over 16 elements
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm16 perm16(W128 w, Perm<byte> spec)
            => new Perm16(gcpu.vload(w128, spec.Terms));

        [MethodImpl(Inline), Op]
        public static Perm16 perm16(Vector128<byte> data)
            => new Perm16(cpu.vand(data, cpu.vbroadcast(w128, Msb8x8x3)));
    }
}