//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    /// <summary>
    /// Captures evidence that k1 != k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="N2">The second nat type</typeparam>
    public readonly struct Ne<K1,K2> : INatNEq<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static K1 k1 => default;

        static K2 k2 => default;

        public static string Description => $"{k1} != {k2}";

        [MethodImpl(Inline)]
        public Ne(K1 n1, K2 n2)
            => Require.invariant(n1.NatValue != n2.NatValue, () => Description);

        public override string ToString()
            => Description;
    }    
}
