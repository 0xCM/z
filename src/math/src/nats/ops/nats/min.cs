//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static TypeNats;

partial class NatCalc
{
    /// <summary>
    /// Computes k := k1 + k2
    /// </summary>
    [MethodImpl(Inline)]
    public static ulong min<K1,K2>(K1 k1 = default, K2 k2 = default)
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
            => sys.min(value(k1), value(k2));
}
