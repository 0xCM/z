//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a signed 32-bit displacement
    /// </summary>
    public readonly struct Disp32 : IDisplacement<Disp32,int>
    {
        public readonly int Value;

        [MethodImpl(Inline)]
        public Disp32(int value)
        {
            Value = value;
        }

        public NativeSize Size
            => NativeSizeCode.W32;

        public bool IsPositive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool IsNegative
        {
            [MethodImpl(Inline)]
            get => Value < 0;
        }

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Disp32 src)
            => Value == src.Value;

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp32(short src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(ushort src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(sbyte src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(byte src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(uint src)
            => new Disp32((int)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp32(int src)
            => new Disp32(src);

        [MethodImpl(Inline)]
        public static implicit operator int(Disp32 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator long(Disp32 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp32 src)
            => new Disp(src.Value, src.Size);

        [MethodImpl(Inline)]
        public static explicit operator uint(Disp32 src)
            => (uint)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator Disp32(long src)
            => new Disp32((int)src);

        [MethodImpl(Inline)]
        public static explicit operator byte(Disp32 src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Disp32 src)
            => (sbyte)src.Value;

        [MethodImpl(Inline)]
        public static Disp32 operator +(Disp32 a, Disp32 b)
            => new Disp32(a.Value + b.Value);

        [MethodImpl(Inline)]
        public static Disp32 operator -(Disp32 a, Disp32 b)
            => new Disp32(a.Value - b.Value);

        public static Disp32 Empty
        {
            [MethodImpl(Inline)]
            get => new Disp32(0);
        }

        int IDisplacement<int>.Value 
            => Value;
    }
}