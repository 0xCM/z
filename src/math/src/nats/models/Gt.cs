//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    /// <summary>
    /// Captures evidence that k1 > k2
    /// </summary>
    /// <typeparam name="K1">The larger nat type</typeparam>
    /// <typeparam name="K2">The smaller nat type</typeparam>
    public readonly struct Gt<K1,K2> : INatGt<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static K1 k1 => default;

        static K2 k2 => default;

        public static string Description => $"{k1} > {k2}";

        [MethodImpl(Inline)]
        public Gt(K1 k1, K2 k2)
            => Require.invariant(NatCalc.gt(k1,k2), () => Description);

        public override string ToString()
            => Description;
    }
 
}
