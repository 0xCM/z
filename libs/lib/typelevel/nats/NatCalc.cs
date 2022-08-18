//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static TypeNats;

    public static partial class NatCalc
    {
        [MethodImpl(Inline)]
        static ulong bitcount<T>(T t = default)
            where T : unmanaged
                => (ulong)Unsafe.SizeOf<T>() * 8;

        /// <summary>
        /// Computes b := k1 * k2 <= k3
        /// </summary>
        [MethodImpl(Inline)]
        static bool prodlteq<K1,K2,K3>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => mul(k1,k2) <= value(k3);

        /// <summary>
        /// Computes b := k1 * k2 >= k3
        /// </summary>
        [MethodImpl(Inline)]
        static bool prodgteq<K1,K2,K3>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => mul(k1,k2) >= value(k3);

        /// <summary>
        /// Computes b := k1 * k2 == k3
        /// </summary>
        [MethodImpl(Inline)]
        static bool prodeq<K1,K2,K3>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
            where K1 : unmanaged, ITypeNat
            where K2 : unmanaged, ITypeNat
            where K3 : unmanaged, ITypeNat
                => mul(k1,k2) == value(k3);
    }
}