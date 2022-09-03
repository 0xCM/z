//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.dsl.C
{
    using P = System.Int16;
    using D = __int16;

    public struct __int16 : IEquatable<D>, IComparable<D>
    {
        P Data;

        [MethodImpl(Inline)]
        public __int16(P x)
            => Data =x;

        [MethodImpl(Inline)]
        public bool Equals(D src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(D src)
            => Data.CompareTo(src.Data);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is D a && Equals(a);

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
        public static implicit operator int(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator float(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator double(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator __int32(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator __int64(D src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator byte(D src)
            => (byte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(D src)
            => (sbyte)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator ushort(D src)
            => (ushort)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator uint(D src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator ulong(D src)
            => (ulong)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator __uint32(D src)
            => (uint)src.Data;

        [MethodImpl(Inline)]
        public static explicit operator __uint64(D src)
            => (ulong)src.Data;

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
        public static D operator >> (D a, int b)
            => (D)(a.Data >> b);

        [MethodImpl(Inline)]
        public static D operator << (D a, int b)
            => (D)(a.Data << b);

        [MethodImpl(Inline)]
        public static D operator ~ (D src)
            => (D)~ src.Data;

        [MethodImpl(Inline)]
        public static D operator - (D src)
            => (D)(-src.Data);

        [MethodImpl(Inline)]
        public static D operator -- (D src)
            =>  --src.Data;

        [MethodImpl(Inline)]
        public static D operator ++ (D src)
            =>  ++src.Data;

        public static D zero => 0;

        public static D one => 1;
    }

}