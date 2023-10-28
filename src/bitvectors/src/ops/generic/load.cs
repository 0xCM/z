//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial class BitVectors
{
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitVector128<T> load<T>(W128 w, ReadOnlySpan<T> src)
        where T : unmanaged
            => vgcpu.vload(w,src);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitVector256<T> load<T>(W256 w, ReadOnlySpan<T> src)
        where T : unmanaged
            => vgcpu.vload(w,src);
}
