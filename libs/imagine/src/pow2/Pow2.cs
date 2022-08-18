//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a DSL for 2^n
    /// </summary>
    [ApiHost]
    public partial struct Pow2 : IEquatable<Pow2>, IComparable<Pow2>
    {
        uint Index;

        [MethodImpl(Inline)]
        public Pow2(byte index)
            => Index = index;

        [MethodImpl(Inline)]
        public bool Equals(Pow2 src)
            => Index == src.Index;

        public override bool Equals(object src)
            => src is Pow2 p && Equals(p);

        public override int GetHashCode()
            => (int)Index;

        [MethodImpl(Inline)]
        public int CompareTo(Pow2 src)
            => Index.CompareTo(src.Index);

        [MethodImpl(Inline)]
        public string Format()
            => FormatHex();

        public string FormatHex()
            => Value.ToString("x") + "h";

        string FormatExponent()
            => string.Format("{0,-4}",$"{Index}^2");

        public string FormatSymbolic()
            => string.Format("{0} = {1}", FormatExponent(), FormatHex());

        public override string ToString()
            => Format();

        public ulong Value
        {
            [MethodImpl(Inline), Op]
            get => pow((byte)Index);
        }

        byte Val8u
        {
            [MethodImpl(Inline), Op]
            get => (byte)pow((byte)Index);
        }

        ushort Val16u
        {
            [MethodImpl(Inline), Op]
            get => (ushort)pow((byte)Index);
        }

        uint Val32u
        {
            [MethodImpl(Inline), Op]
            get => (uint)pow((byte)Index);
        }

        ulong Val64u
        {
            [MethodImpl(Inline), Op]
            get => pow((byte)Index);
        }

        [MethodImpl(Inline)]
        Pow2 Increment()
        {
            if(Index < 63)
                ++Index;
            else
                Index = 0;
            return this;
        }

        [MethodImpl(Inline)]
        Pow2 Decrement()
        {
            if(Index > 0)
                --Index;
            else
                Index = 63;
            return this;
        }

        [MethodImpl(Inline)]
        public static Pow2 operator ++(Pow2 src)
            => src.Increment();

        [MethodImpl(Inline)]
        public static Pow2 operator --(Pow2 src)
            => src.Decrement();

        [MethodImpl(Inline)]
        public static implicit operator Pow2(byte index)
            => new Pow2(index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(int index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x1 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x2 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x3 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x4 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x8 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x16 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x32 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static implicit operator Pow2(Pow2x64 index)
            => new Pow2((byte)index);

        [MethodImpl(Inline)]
        public static explicit operator Pow2x1(Pow2 src)
            => (Pow2x1)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x2(Pow2 src)
            => (Pow2x2)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x3(Pow2 src)
            => (Pow2x3)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x4(Pow2 src)
            => (Pow2x4)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x8(Pow2 src)
            => (Pow2x8)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x16(Pow2 src)
            => (Pow2x16)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x32(Pow2 src)
            => (Pow2x32)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Pow2x64(Pow2 src)
            => (Pow2x64)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(Pow2 src)
            => src.Val8u;

        [MethodImpl(Inline)]
        public static explicit operator ushort(Pow2 src)
            => src.Val16u;

        [MethodImpl(Inline)]
        public static explicit operator uint(Pow2 src)
            => src.Val32u;

        [MethodImpl(Inline)]
        public static explicit operator ulong(Pow2 src)
            => src.Val64u;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Pow2 src)
            => (sbyte)src.Val8u;

        [MethodImpl(Inline)]
        public static explicit operator short(Pow2 src)
            => (short)src.Val16u;

        [MethodImpl(Inline)]
        public static explicit operator int(Pow2 src)
            => (int)src.Val32u;

        [MethodImpl(Inline)]
        public static explicit operator long(Pow2 src)
            => (long)src.Val64u;
    }
}