//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 4040
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Enums;

    /// <summary>
    /// Defines a model of an enum literal that is parametric in both the declaring enum
    /// and the underlying primal type it refines
    /// </summary>
    public readonly struct @enum<E,T> : IEnumMember<@enum<E,T>,E,T>, IEquatable<@enum<E,T>>
        where E : unmanaged
        where T : unmanaged
    {
        public E Literal {get;}

        [MethodImpl(Inline)]
        public @enum(E literal)
            => Literal = literal;

        [MethodImpl(Inline)]
        public @enum(T scalar)
            => Literal = literal<E,T>(scalar);

        public T Scalar
        {
            [MethodImpl(Inline)]
            get => @as<E,T>(Literal);
        }

        public DataWidth Width
        {
            [MethodImpl(Inline)]
            get => (DataWidth)width<T>();
        }

        [MethodImpl(Inline)]
        public bool Equals(E src)
            => Literal.Equals(src);

        [MethodImpl(Inline)]
        public bool Equals(@enum<E,T> src)
            => Literal.Equals(src.Literal);

        public override bool Equals(object src)
            => src is @enum<E,T> x && Equals(x);

        public override int GetHashCode()
            => Literal.GetHashCode();
        public string Format()
            => $"{Literal}";

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator E(@enum<E,T> src)
            => src.Literal;

        [MethodImpl(Inline)]
        public static implicit operator T(@enum<E,T> src)
            => src.Scalar;

        [MethodImpl(Inline)]
        public static implicit operator @enum<E,T>(E src)
            => new @enum<E,T>(src);

        [MethodImpl(Inline)]
        public static implicit operator @enum<E,T>(T src)
            => new @enum<E,T>(src);

        [MethodImpl(Inline)]
        public static bool operator ==(@enum<E,T> a, @enum<E,T> b)
            => emath.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(@enum<E,T> a, @enum<E,T> b)
            => emath.neq(a,b);

        [MethodImpl(Inline)]
        public static bool operator ==(@enum<E,T> a,T b)
            => emath.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(@enum<E,T> a, T b)
            => emath.neq(a,b);

        [MethodImpl(Inline)]
        public static bool operator ==(T a, @enum<E,T> b)
            => emath.eq(a,b);

        [MethodImpl(Inline)]
        public static bool operator !=(T a, @enum<E,T> b)
            => emath.neq(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(@enum<E,T> a, @enum<E,T> b)
            => emath.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(@enum<E,T> a, @enum<E,T> b)
            => emath.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(@enum<E,T> a, T b)
            => emath.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(@enum<E,T> a, T b)
            => emath.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <(T a, @enum<E,T> b)
            => emath.lt(a,b);

        [MethodImpl(Inline)]
        public static bool operator >(T a, @enum<E,T> b)
            => emath.gt(a,b);

        [MethodImpl(Inline)]
        public static bool operator <=(@enum<E,T> a, @enum<E,T> b)
            => emath.lteq(a,b);

        [MethodImpl(Inline)]
        public static bool operator >=(@enum<E,T> a, @enum<E,T> b)
            => emath.gteq(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator +(@enum<E,T> a, @enum<E,T> b)
            => emath.add(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator +(T a, @enum<E,T> b)
            => emath.add(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator +(@enum<E,T> a, T b)
            => emath.add(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator -(@enum<E,T> a, @enum<E,T> b)
            => emath.sub(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator -(@enum<E,T> a, T b)
            => emath.sub(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator -(T a, @enum<E,T> b)
            => emath.sub(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator *(@enum<E,T> a, @enum<E,T> b)
            => emath.mul(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator *(@enum<E,T> a, T b)
            => emath.mul(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator *(T a, @enum<E,T> b)
            => emath.mul(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator /(@enum<E,T> a, @enum<E,T> b)
            => emath.div(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator /(@enum<E,T> a, T b)
            => emath.div(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator /(T a, @enum<E,T> b)
            => emath.div(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator %(@enum<E,T> a, @enum<E,T> b)
            => emath.mod(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator %(@enum<E,T> a, T b)
            => emath.mod(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator %(T a, @enum<E,T> b)
            => emath.mod(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator -(@enum<E,T> a)
            => emath.negate(a);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator &(@enum<E,T> a, @enum<E,T> b)
            => emath.and(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator &(@enum<E,T> a, T b)
            => emath.and(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator &(T a, @enum<E,T> b)
            => emath.and(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator |(@enum<E,T> a, @enum<E,T> b)
            => emath.or(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator |(@enum<E,T> a, T b)
            => emath.or(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator |(T a, @enum<E,T> b)
            => emath.or(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator ^(@enum<E,T> a, @enum<E,T> b)
            => emath.xor(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator ^(@enum<E,T> a, T b)
            => emath.xor(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator ^(T a, @enum<E,T> b)
            => emath.xor(a,b);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator >>(@enum<E,T> a, int offset)
            => emath.srl(a,(byte)offset);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator <<(@enum<E,T> a, int offset)
            => emath.sll(a,(byte)offset);

        [MethodImpl(Inline)]
        public static @enum<E,T> operator ~(@enum<E,T> a)
            => emath.not(a);
    }
}