//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.C
{
    using P = System.UInt32;
    using D = __uint32;

    public struct __uint32 : IEquatable<D>, IComparable<D>
    {
        P Data;

        [MethodImpl(Inline)]
        public __uint32(P x)
            => Data = x;

        [MethodImpl(Inline)]
        public bool Equals(D b)
            => Data == b.Data;

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object b)
            => b is D a && Equals(a);

        public override string ToString()
            => Data.ToString();
        [MethodImpl(Inline)]
        public static D @bool(bool x)
            => x ? one : zero;

        [MethodImpl(Inline)]
        public static bool operator true(D x)
            => x.Data != 0;

        [MethodImpl(Inline)]
        public static bool operator false(D x)
            => x.Data == 0;

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
        public static explicit operator byte(D src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(D src)
            => (sbyte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator short(D src)
            => (short)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator ushort(D src)
            => (ushort)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator int(D src)
            => (int)src.Data;

        [MethodImpl(Inline)]
        public static implicit operator ulong(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator float(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator double(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static D operator == (D a, D b)
            => @bool(a.Data == b.Data);

        [MethodImpl(Inline)]
        public static D operator != (D a, D b)
            => @bool(a.Data != b.Data);

        [MethodImpl(Inline)]
        public static D operator + (D a, D b)
            => a.Data + b.Data;

        [MethodImpl(Inline)]
        public static D operator - (D a, D b)
            => a.Data - b.Data;

        [MethodImpl(Inline)]
        public static D operator * (D a, D b)
            => a.Data * b.Data;

        [MethodImpl(Inline)]
        public static D operator / (D a, D b)
            => a.Data / b.Data;

        [MethodImpl(Inline)]
        public static D operator % (D a, D b)
            => a.Data % b.Data;

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
            => a.Data & b.Data;

        [MethodImpl(Inline)]
        public static D operator | (D a, D b)
            => a.Data | b.Data;

        [MethodImpl(Inline)]
        public static D operator ^ (D a, D b)
            => a.Data ^ b.Data;

        [MethodImpl(Inline)]
        public static D operator ~ (D x)
            => ~ x.Data;

        [MethodImpl(Inline)]
        public static D operator - (D src)
            => ~src.Data + 1;

        [MethodImpl(Inline)]
        public static D operator >> (D a, int b)
            => a.Data >> b;

        [MethodImpl(Inline)]
        public static D operator << (D a, int b)
            => a.Data << b;

        [MethodImpl(Inline)]
        public static D operator -- (D x)
            =>  --x.Data;

        [MethodImpl(Inline)]
        public static D operator ++ (D x)
            => ++x.Data;

        public static D zero => 0;

        public static D one => 1;
    }
}