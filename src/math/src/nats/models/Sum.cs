//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class TypeNats
{
    /// <summary>
    /// Encodes a natural number k := k1 + k2
    /// </summary>
    public readonly struct Sum<A,B> : INatSum<A,B>
        where A : unmanaged, ITypeNat
        where B : unmanaged, ITypeNat
    {
        static A k1 => default;

        static B k2 => default;

        public static Sum<A,B> Rep => default;

        public static ulong Value => TypeNats.add(k1,k2);

        static string description => $"{k1} + {k2} = {Value}";

        public static byte[] Digits => TypeNats.digits(Value);

        public static INatSeq Seq => TypeNats.seq(Digits);

        [MethodImpl(Inline)]
        public static implicit operator int(Sum<A,B> src)
            => (int)src.NatValue;

        public ulong NatValue
        {
            [MethodImpl(Inline)]
            get => TypeNats.add(k1,k2);
        }

        public bool Equals(Pow<A,B> other)
            => Value == other.NatValue;

        public bool Equals(INatSeq other)
            => Value == other.NatValue;

        public override string ToString()
            => description;

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object rhs)
            => Value.Equals(rhs);
    }
    
}
