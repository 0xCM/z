//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMasks
    {
        [MethodImpl(Inline)]
        public static MaskSpec spec<F,D,T>(BitMaskKind m, F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
                => new MaskSpec(m, NumericKinds.kind<T>(), (uint)Typed.value<F>(), (uint)Typed.value<D>());

        [MethodImpl(Inline)]
        public static JsbMask<F,D,T> jsbspec<F,D,T>(F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
                => default;

        [MethodImpl(Inline)]
        public static CentralMask<F,D,T> centralspec<F,D,T>(F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
                => default;

        [MethodImpl(Inline)]
        public static IndexMask<N,T> indexspec<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => default;

        [MethodImpl(Inline)]
        public static MsbMask<F,D,T> msbspec<F,D,T>(F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
                => default;

        [MethodImpl(Inline)]
        public static LsbMask<F,D,T> lsbspec<F,D,T>(F f = default, D d = default, T t = default)
            where F : unmanaged, ITypeNat
            where D : unmanaged, ITypeNat
            where T : unmanaged
                => default;

    }
}