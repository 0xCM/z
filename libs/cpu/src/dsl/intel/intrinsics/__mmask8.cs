//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.intel
{
    using P = System.Byte;
    using D = __mmask8;

    using C;

    public struct __mmask8 : IEquatable<D>, IComparable<D>
    {
        P Data;

        [MethodImpl(Inline)]
        public __mmask8(P x)
            => Data =x;

        [MethodImpl(Inline)]
        public bool Equals(D src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Data.CompareTo(src.Data);


        public override int GetHashCode()
            => Data;

        public override bool Equals(object src)
            => src is D a && Equals(a);

        [MethodImpl(Inline)]
        public static D @bool(bool x)
            => x ? one : zero;

        [MethodImpl(Inline)]
        public static bool operator true(D src)
            => src.Data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(D src)
            => src.Data == 0;

        [MethodImpl(Inline)]
        public static implicit operator bool(D src)
            => src.Data != 0;

        [MethodImpl(Inline)]
        public static implicit operator D(bool src)
            => src ? one : zero;

        [MethodImpl(Inline)]
        public static implicit operator D(P src)
            => new D(src);

        [MethodImpl(Inline)]
        public static implicit operator P(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator D(int src)
            => new D((byte)src);

        [MethodImpl(Inline)]
        public static explicit operator __uint8(D src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator uint(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static D operator == (D a, D b)
            => @bool(a.Data == b.Data);

        [MethodImpl(Inline)]
        public static D operator != (D a, D b)
            => @bool(a.Data != b.Data);

        [MethodImpl(Inline)]
        public static D operator + (D a, D b)
            => (D)(a.Data + b.Data);

        [MethodImpl(Inline)]
        public static D operator - (D a, D b)
            => (D)(a.Data - b.Data);

        [MethodImpl(Inline)]
        public static D operator * (D a, D b)
            => (D)(a.Data * b.Data);

        [MethodImpl(Inline)]
        public static D operator / (D a, D b)
            => (D)(a.Data / b.Data);

        [MethodImpl(Inline)]
        public static D operator % (D a, D b)
            => (D)(a.Data % b.Data);

        [MethodImpl(Inline)]
        public static D operator < (D a, D b)
            => @bool(a.Data < b.Data);

        [MethodImpl(Inline)]
        public static D operator <= (D a, D b)
            => @bool(a.Data <= b.Data);

        [MethodImpl(Inline)]
        public static D operator > (D a, D b)
            => @bool(a.Data > b.Data);

        [MethodImpl(Inline)]
        public static D operator >= (D a, D b)
            => @bool(a.Data >= b.Data);

        [MethodImpl(Inline)]
        public static D operator & (D a, D b)
            => (D)(a.Data & b.Data);

        [MethodImpl(Inline)]
        public static D operator | (D a, D b)
            => (D)(a.Data | b.Data);

        [MethodImpl(Inline)]
        public static D operator ^ (D a, D b)
            => (D)(a.Data ^ b.Data);

        [MethodImpl(Inline)]
        public static D operator ~ (D x)
            => (D)~ x.Data;

        [MethodImpl(Inline)]
        public static D operator - (D src)
            => (D)(~src.Data + 1);

        [MethodImpl(Inline)]
        public static D operator >> (D a, int b)
            => (D)(a.Data >> b);

        [MethodImpl(Inline)]
        public static D operator << (D a, int b)
            => (D)(a.Data << b);

        [MethodImpl(Inline)]
        public static D operator -- (D x)
            =>  --x.Data;

        [MethodImpl(Inline)]
        public static D operator ++ (D x)
            =>  ++x.Data;

        public static D zero => 0;

        public static D one => 1;
    }    
}