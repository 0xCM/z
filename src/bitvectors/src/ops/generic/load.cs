//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static vcpu;

    partial class BitVectors
    {
        [MethodImpl(Inline), Op]
        public static BitVector128<ulong> load(W128 w, ulong a, ulong b)
            => vparts(w,a,b);

        [MethodImpl(Inline), Op]
        public static BitVector128<uint> load(W128 w, uint a0, uint a1, uint a2, uint a3)
            => vparts(w,a0,a1,a2,a3);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector128<T> load<T>(W128 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vgcpu.vload(w,src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitVector256<T> load<T>(W256 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => vgcpu.vload(w,src);
    }
}