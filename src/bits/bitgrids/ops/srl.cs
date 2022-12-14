//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitGrid
    {
        [MethodImpl(Inline)]
        public static BitGrid16<M,N,T> srl<M,N,T>(BitGrid16<M,N,T> g, byte shift)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => gmath.srl(g.Content,shift);

        [MethodImpl(Inline)]
        public static BitGrid32<M,N,T> srl<M,N,T>(BitGrid32<M,N,T> g, byte shift)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => gmath.srl(g.Content,shift);

        [MethodImpl(Inline)]
        public static BitGrid64<M,N,T> srl<M,N,T>(BitGrid64<M,N,T> g, byte shift)
            where T : unmanaged
            where M : unmanaged, ITypeNat
            where N : unmanaged, ITypeNat
                => gmath.srl(g.Content,shift);

        [MethodImpl(Inline)]
        public static BitGrid128<M,N,T> srl<M,N,T>(in BitGrid128<M,N,T> g, byte shift)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vsrl<T>(g,shift);

        [MethodImpl(Inline)]
        public static BitGrid256<M,N,T> srl<M,N,T>(in BitGrid256<M,N,T> g, byte shift)
            where T : unmanaged
            where N : unmanaged, ITypeNat
            where M : unmanaged, ITypeNat
                => gcpu.vsrl<T>(g,shift);
    }
}