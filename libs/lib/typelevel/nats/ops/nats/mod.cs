//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static TypeNats;

    partial class NatCalc
    {
        /// <summary>
        /// Computes k := k1 % k2
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong mod<K1,K2>(K1 k1 = default, K2 k2 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, INonZeroNat
                => value(k1) % value(k2);

        /// <summary>
        /// Computes k := value[N] % bitsize[T]
        /// </summary>
        /// <param name="n">The natural representative</param>
        /// <param name="t">A type representative</param>
        /// <typeparam name="N">The natural type</typeparam>
        /// <typeparam name="T">The bit width type</typeparam>
        [MethodImpl(Inline)]
        public static ulong modT<N,T>(N n = default, T t = default)
            where N : unmanaged, ITypeNat
            where T : unmanaged
                => value<N>() % (ulong)bitsize<T>();

        /// <summary>
        /// Computes k := (k1*k2) % k3
        /// </summary>
        [MethodImpl(Inline)]
        public static ulong modprod<K1,K2,K3>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => mul(k1,k2) % value(k3);
    }
}