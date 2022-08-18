//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NatSum<K> : INatSum<K>
        where K : unmanaged, ITypeNat
    {
        public static K Rep => default;

        public NatSum(ITypeNat lhs, ITypeNat rhs)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public ITypeNat Lhs {get;}

        public ITypeNat Rhs {get;}

        public ulong NatValue
            => Rep.NatValue;
    }

    /// <summary>
    /// Encodes a natural number k := k1 + k2
    /// </summary>
    public readonly struct NatSum<K1,K2> : INatSum<K1,K2>
        where K1 : unmanaged, ITypeNat
        where K2 : unmanaged, ITypeNat
    {
        static K1 k1 => default;

        static K2 k2 => default;

        public static NatSum<K1,K2> Rep => default;

        public static ulong Value => TypeNats.add(k1,k2);

        static string description => $"{k1} + {k2} = {Value}";

        public static byte[] Digits => TypeNats.digits(Value);

        public static INatSeq Seq => TypeNats.seq(Digits);

        [MethodImpl(Inline)]
        public static implicit operator int(NatSum<K1,K2> src)
            => (int)src.NatValue;

        public ulong NatValue
        {
            [MethodImpl(Inline)]
            get => TypeNats.add(k1,k2);
        }

        public bool Equals(NatPow<K1,K2> other)
            => Value == other.NatValue;

        public bool Equals(INatSeq other)
            => Value == other.NatValue;

        public override string ToString()
            => description;

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object rhs)
            => Value.Equals(rhs);

        [MethodImpl(Inline)]
        public NatSum<K> Reduce<K>(K target = default)
            where K : unmanaged, ITypeNat
        {
            if(Value == target.NatValue)
                return new NatSum<K>(k1,k2);
            else
                throw new Exception($"{k1} + {k2} != {target}");
        }
    }
}