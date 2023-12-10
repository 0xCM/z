//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

partial class TypeNats
{

    /// <summary>
    /// Encodes a natural number k := b^e
    /// </summary>
    public readonly struct Pow<B,E> : INatPow<Pow<B,E>,B,E>
        where B : unmanaged, ITypeNat
        where E : unmanaged, ITypeNat
    {
        public static Pow<B,E> Rep => default;

        public static  ITypeNat[] Operands => new ITypeNat[] {new B(), new E()};

        [MethodImpl(Inline)]
        static T[] repeat<T>(T value, ulong count)
        {
            var dst = new T[count];
            for(var idx = 0U; idx < count; idx ++)
                dst[idx] = value;
            return dst;
        }

        [MethodImpl(Inline)]
        static K nat<K>(K k = default)
            where K : unmanaged, ITypeNat
                => default;

        /// <summary>
        /// Raises a baise to a power
        /// </summary>
        /// <param name="@base">The base value</param>
        /// <param name="exp">The exponent value</param>
        [MethodImpl(Inline)]
        static ulong pow(ulong @base, ulong exp)
            => repeat(@base, exp).Aggregate((x,y) => x * y);

        public static ulong Value
            => pow(nat<B>().NatValue, nat<E>().NatValue);

        public static byte[] Digits => TypeNats.digits(Value);

        public static INatSeq Seq => TypeNats.seq(Digits);

        public INatSeq Sequence
            => Seq;

        public ulong NatValue
            => Value;

        public INatSeq natseq()
            => Seq;

        public E Exponent
            => new ();

        public string format()
            => Value.ToString();

        public override string ToString()
            => format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object rhs)
            => Value.Equals(rhs);

        public bool Equals(Pow<B, E> other)
            => Value == other.NatValue;

        public bool Equals(INatSeq other)
            => Value == other.NatValue;
    }   
}