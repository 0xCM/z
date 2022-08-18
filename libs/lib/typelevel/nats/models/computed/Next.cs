//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// When closed over a natural K, encodes a natural number k:K such that k1:K1 & k2:K2 => k = k1 + 1
    /// </summary>
    public readonly struct Next<K> : ITypeNat
        where K : unmanaged, ITypeNat
    {
        static K k => default;

        public static Next<K> Rep => default;

        public static ulong Value => k.NatValue + 1u;

        static string description => $"++{k.NatValue} = {Value}";

        public static byte[] Digits => TypeNats.digits(Value);

        public static INatSeq Seq => TypeNats.seq(Digits);

        public ITypeNat rep
            => Rep;

        public INatSeq Sequence
            => Seq;

        public ulong NatValue
            => Value;

        public INatSeq natseq()
            => Seq;

        [MethodImpl(Inline)]
        public bool Equals(Next<K> rhs)
            => Value == rhs.NatValue;

        [MethodImpl(Inline)]
        public bool Equals(INatSeq rhs)
            => Value == rhs.NatValue;

        [MethodImpl(Inline)]
        public string Format()
            => description;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object rhs)
            => Value.Equals(rhs);
    }

    /// <summary>
    /// Captures evidence that k1 + 1 = k2
    /// </summary>
    /// <typeparam name="K1">The first nat type</typeparam>
    /// <typeparam name="K2">The second nat type</typeparam>
    public readonly struct NatNext<K1,K2> : INatNext<K1,K2>
        where K1: unmanaged, ITypeNat
        where K2: unmanaged, ITypeNat
    {
        static readonly K1 k1 = default;

        static readonly K2 k2 = default;

        public static string Description => $"++{k1} = {k2}";

        public NatNext(K1 n1, K2 n2)
        {
            Require.invariant(n1.NatValue + 1 == n2.NatValue, () => Description);
            valid = true;
        }

        public bool valid {get;}

        public override string ToString()
            => Description;
    }
}