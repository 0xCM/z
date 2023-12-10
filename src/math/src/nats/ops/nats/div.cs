//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static TypeNats;

partial class NatCalc
{
    /// <summary>
    /// Computes k := k1 / k2
    /// </summary>
    [MethodImpl(Inline)]
    public static ulong div<K1,K2>(K1 k1 = default, K2 k2 = default)
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
            => value(k1) / value(k2);

    /// <summary>
    /// Computes k := k1 / k2
    /// </summary>
    [MethodImpl(Inline)]
    public static ulong wdiv<W,K2>(W w = default, K2 k2 = default)
        where W : unmanaged, IDataWidth
        where K2 : unmanaged, ITypeNat
            => (ulong)DataWidths.measure<W>() / value(k2);

    /// <summary>
    /// Computes k := (k1*k2) / k3
    /// </summary>
    [MethodImpl(Inline)]
    public static ulong divprod<K1,K2,K3>(K1 k1 = default, K2 k2 = default, K3 k3 = default)
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
        where K3 : unmanaged, ITypeNat
            => mul(k1,k2) / value(k3);

    /// <summary>
    /// Computes k := value[N] / bitsize[T]
    /// </summary>
    /// <param name="n">The natural representative</param>
    /// <param name="t">A type representative</param>
    /// <typeparam name="N">The natural type</typeparam>
    /// <typeparam name="T">The bit width type</typeparam>
    [MethodImpl(Inline)]
    public static ulong divT<N,T>(N n = default, T t = default)
        where N : unmanaged, ITypeNat
        where T : unmanaged
            => value<N>() / (ulong)bitsize<T>();

    /// <summary>
    /// Computes k := (k1 / k2) / bitsize[t]
    /// </summary>
    [MethodImpl(Inline)]
    public static ulong divT<K1,K2,T>(K1 k1 = default, K2 k2 = default, T t = default)
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, INonZeroNat
        where T : unmanaged
            => div(k1,k2)/(ulong)bitsize<T>();
}
