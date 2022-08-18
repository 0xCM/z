//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using P = System.SByte;
    using T = CNum.int8_t;

    partial class CNum
    {
        public struct int8_t : IEquatable<T>, IComparable<T>
        {
            P Data;

            [MethodImpl(Inline)]
            public int8_t(P src)
                => Data =src;

            [MethodImpl(Inline)]
            public bool Equals(T src)
                => Data == src.Data;

            [MethodImpl(Inline)]
            public int CompareTo(T src)
                => Data.CompareTo(src.Data);

            public override int GetHashCode()
                => Data.GetHashCode();

            public override bool Equals(object src)
                => src is T a && Equals(a);

            public override string ToString()
                => Data.ToString();

            [MethodImpl(Inline)]
            public static bool operator true(T src)
                => src.Data != 0;

            [MethodImpl(Inline)]
            public static bool operator false(T src)
                => src.Data == 0;

            [MethodImpl(Inline)]
            public static implicit operator bool(T src)
                => src.Data != 0;

            [MethodImpl(Inline)]
            public static implicit operator T(bool src)
                => src ? one : zero;

            [MethodImpl(Inline)]
            public static implicit operator T(P src)
                => new T(src);

            [MethodImpl(Inline)]
            public static implicit operator P(T src)
                => src.Data;

            [MethodImpl(Inline)]
            public static explicit operator byte(T src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator short(T src)
                => (short)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator ushort(T src)
                => (byte)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator int(T src)
                => (int)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator uint(T src)
                => (uint)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator long(T src)
                => (long)src.Data;

            [MethodImpl(Inline)]
            public static explicit operator ulong(T src)
                => (ulong)src.Data;

            [MethodImpl(Inline)]
            public static implicit operator float(T src)
                => src.Data;

            [MethodImpl(Inline)]
            public static implicit operator double(T src)
                => src.Data;

            [MethodImpl(Inline)]
            public static T operator == (T a, T b)
                => a.Data == b.Data;

            [MethodImpl(Inline)]
            public static T operator != (T a, T b)
                => a.Data != b.Data;

            [MethodImpl(Inline)]
            public static T operator + (T a, T b)
                => (T)(a.Data + b.Data);

            [MethodImpl(Inline)]
            public static T operator - (T a, T b)
                => (T)(a.Data - b.Data);

            [MethodImpl(Inline)]
            public static T operator * (T a, T b)
                => (T)(a.Data * b.Data);

            [MethodImpl(Inline)]
            public static T operator / (T a, T b)
                => (T)(a.Data / b.Data);

            [MethodImpl(Inline)]
            public static T operator % (T a, T b)
                => (T)(a.Data % b.Data);

            [MethodImpl(Inline)]
            public static T operator < (T a, T b)
                => a.Data < b.Data;

            [MethodImpl(Inline)]
            public static T operator <= (T a, T b)
                => a.Data <= b.Data;

            [MethodImpl(Inline)]
            public static T operator > (T a, T b)
                => a.Data > b.Data;

            [MethodImpl(Inline)]
            public static T operator >= (T a, T b)
                => a.Data >= b.Data;

            [MethodImpl(Inline)]
            public static T operator & (T a, T b)
                => (T)(a.Data & b.Data);

            [MethodImpl(Inline)]
            public static T operator | (T a, T b)
                => (T)(a.Data | b.Data);

            [MethodImpl(Inline)]
            public static T operator ^ (T a, T b)
                => (T)(a.Data ^ b.Data);

            [MethodImpl(Inline)]
            public static T operator >> (T a, int offset)
                => (T)(a.Data >> offset);

            [MethodImpl(Inline)]
            public static T operator << (T a, int offset)
                => (T)(a.Data << offset);

            [MethodImpl(Inline)]
            public static T operator ~ (T src)
                => (T)~ src.Data;

            [MethodImpl(Inline)]
            public static T operator - (T src)
                => (T)(-src.Data);

            [MethodImpl(Inline)]
            public static T operator -- (T src)
                =>  --src.Data;

            [MethodImpl(Inline)]
            public static T operator ++ (T src)
                =>  ++src.Data;

            public static T zero => 0;

            public static T one => 1;
        }
    }
}