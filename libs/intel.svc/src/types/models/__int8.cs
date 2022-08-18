//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = System.SByte;
    using D = intel.__int8;

    partial class intel
    {
        public struct __int8 : IEquatable<D>, IComparable<D>
        {
            P Data;

            [MethodImpl(Inline)]
            public __int8(P src)
                => Data =src;

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
            public static explicit operator byte(D src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator short(D src)
                => (short)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator ushort(D src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator int(D src)
                => (int)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator uint(D src)
                => (uint)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator long(D src)
                => (long)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator ulong(D src)
                => (ulong)src.Data;

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
                => (D)(a.Data | b.Data);

            [MethodImpl(Inline)]
            public static D operator ^ (D a, D b)
                => (D)(a.Data ^ b.Data);

            [MethodImpl(Inline)]
            public static D operator >> (D a, int offset)
                => (D)(a.Data >> offset);

            [MethodImpl(Inline)]
            public static D operator << (D a, int offset)
                => (D)(a.Data << offset);

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
}