//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class GridPatterns
    {
        [MethodImpl(Inline)]
        public static SubGrid256<M,N,T> bars<M,N,T>(N256 w, M m = default, N n = default, T t = default)
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
            where T : unmanaged
        {
            var sep = nat8u(n);
            var pattern = BitMasks.lo<ulong>(sep) << sep;
            return generic<T>(cpu.vbroadcast(w, gbits.replicate(pattern)));
        }
    }
}