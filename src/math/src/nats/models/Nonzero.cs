//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    /// <summary>
    /// Captures evidence that k != 0
    /// </summary>
    /// <typeparam name="K">A nonzero natural type</typeparam>
    public readonly struct Nonzero<K> : INonZeroNat<K>
        where K: unmanaged, ITypeNat
    {
        static K k => default;

        public static string Description => $"{k} != 0";

        public ulong NatValue => TypeNats.value(k);

        [MethodImpl(Inline)]
        public Nonzero(K n)
            => Require.invariant(n.NatValue != 0, () => Description);

        public override string ToString()
            => Description;
    }
    
}
