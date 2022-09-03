//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = System.UInt16;
    using D = CNum.uint16_t;

    partial class CNum
    {
        public struct uint16_t : IEquatable<D>, IComparable<D>
        {
            P Data;

            [MethodImpl(Inline)]
            public uint16_t(P x)
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
            public static explicit operator sbyte(D src)
                => (sbyte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator int8_t(D src)
                => (sbyte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator byte(D src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator uint8_t(D src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator short(D src)
                => (short)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator int(D src)
                => (int)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint(D src)
                => src.Data;

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
            public static D operator ^ (D a, uint8_t b)
                => (D)(a.Data ^ (uint16_t)b);

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
}