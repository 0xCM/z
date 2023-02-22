//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;

    partial struct Perm
    {
        /// <summary>
        /// Creates a fixed 16-bit permutation over a generic permutation over 16 elements
        /// </summary>
        /// <param name="src">The source permutation</param>
        [MethodImpl(Inline), Op]
        public static Perm16 perm16(W128 w, Perm<byte> spec)
            => new Perm16(vcpu.vload(w128, spec.Terms));

        [MethodImpl(Inline), Op]
        public static Perm16 perm16(Vector128<byte> data)
            => new Perm16(vcpu.vand(data, vcpu.vbroadcast(w128, Msb8x8x3)));
    }
}