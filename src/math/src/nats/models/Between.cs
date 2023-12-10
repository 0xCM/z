//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    /// <summary>
    /// Captures evidence that k1 <= k <= k2
    /// </summary>
    /// <typeparam name="K1">The lower bound type</typeparam>
    /// <typeparam name="K2">The upper bound type</typeparam>
    public readonly struct Between<K,K1,K2> : INatBetween<K,K1,K2>
        where K: unmanaged, ITypeNat
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static K k => default;

        static K1 k1 => default;

        static K2 k2 => default;

        public static string Description => $"{k1} <= {k} <= {k2}";

        [MethodImpl(Inline)]
        public Between(K k, K1 k1, K2 k2)
            => Require.invariant(NatCalc.between(k, k1, k2), () => Description);

        public override string ToString()
            => Description;
    }

}
