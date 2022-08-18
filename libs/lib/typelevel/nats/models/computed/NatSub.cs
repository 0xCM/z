//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Encodes a natural number k := k1 - k2
    /// </summary>
    public readonly struct NatSub<K1,K2> : INatDifference<NatSub<K1,K2>, K1,K2>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {
        static K1 k1 => default;

        static K2 k2 => default;

        public static string Description => $"{k1} - {k2} = {Value}";

        public static ulong Value
            => NatCalc.sub(k1,k2);

        public static byte[] Digits
            => TypeNats.digits(Value);

        public static INatSeq Seq
            => TypeNats.seq(Digits);

        ulong ITypeNat.NatValue
            => Value;

        public bool Equals(NatPow<K1,K2> other)
            => Value == other.NatValue;

        public bool Equals(INatSeq other)
            => Value == other.NatValue;

        public override string ToString()
            => Description;

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object rhs)
            => Value.Equals(rhs);
    }
}