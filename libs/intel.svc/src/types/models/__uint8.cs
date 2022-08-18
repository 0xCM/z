//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = System.Byte;
    using D = intel.__uint8;

    partial class intel
    {
        public struct __uint8 : IEquatable<D>, IComparable<D>
        {
            P Data;

            [MethodImpl(Inline)]
            public __uint8(P x)
                => Data =x;

            [MethodImpl(Inline)]
            public bool Equals(D b)
                => Data == b.Data;

            [MethodImpl(Inline)]
            public int CompareTo(D src)
                => Data.CompareTo(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object b)
                => Data.Equals(b);

            public override string ToString()
                => Data.ToString();

            [MethodImpl(Inline)]
            public static implicit operator P(D src)
                => src.Data;

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
            public static implicit operator D(byte src)
                => new D(src);

            [MethodImpl(Inline)]
            public static explicit operator sbyte(D src)
                => (sbyte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator short(D src)
                => (short)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator ushort(D src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator __uint16(D src)
                => (ushort)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator __uint32(D src)
                => (uint)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator __uint64(D src)
                => (ulong)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator int(D src)
                => (int)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator uint(D src)
                => src.Data;

            [MethodImpl(Inline)]
            public static explicit operator long(D src)
                => (long)src.Data;

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
                => a.Data == b.Data;

            [MethodImpl(Inline)]
            public static D operator != (D a, D b)
                => a.Data != b.Data;

            [MethodImpl(Inline)]
            public static D operator + (D a, D b)
                => wrap(a.Data + b.Data);

            [MethodImpl(Inline)]
            public static D operator - (D a, D b)
                => wrap(a.Data - b.Data);

            [MethodImpl(Inline)]
            public static D operator * (D a, D b)
                => wrap(a.Data * b.Data);

            [MethodImpl(Inline)]
            public static D operator / (D a, D b)
                => wrap(a.Data / b.Data);

            [MethodImpl(Inline)]
            public static D operator % (D a, D b)
                => wrap(a.Data % b.Data);

            [MethodImpl(Inline)]
            public static D operator < (D a, D b)
                => a.Data < b.Data;

            [MethodImpl(Inline)]
            public static D operator <= (D a, D b)
                => a.Data <= b.Data;

            [MethodImpl(Inline)]
            public static D operator > (D a, D b)
                => a.Data > b.Data;

            [MethodImpl(Inline)]
            public static D operator >= (D a, D b)
                => a.Data >= b.Data;

            [MethodImpl(Inline)]
            public static D operator & (D a, D b)
                => (D)(a.Data & b.Data);

            [MethodImpl(Inline)]
            public static D operator | (D a, D b)
                => wrap(a.Data | b.Data);

            [MethodImpl(Inline)]
            public static D operator ^ (D a, D b)
                => wrap(a.Data ^ b.Data);

            [MethodImpl(Inline)]
            public static D operator >> (D a, int b)
                => wrap(a.Data >> b);

            [MethodImpl(Inline)]
            public static D operator << (D a, int b)
                => wrap(a.Data << b);

            [MethodImpl(Inline)]
            public static D operator ~ (D src)
                => wrap(~ src.Data);

            [MethodImpl(Inline)]
            public static D operator - (D src)
                => wrap(~src.Data + 1);

            [MethodImpl(Inline)]
            public static D operator -- (D src)
                => --src.Data;

            [MethodImpl(Inline)]
            public static D operator ++ (D src)
                => ++src.Data;

            [MethodImpl(Inline)]
            static D wrap(int x)
                => new D((byte)x);

            public static D zero => 0;

            public static D one => 1;
        }
    }
}