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
        [Parser]
        public static Outcome parse(string src, out Disp32 dst)
        {
            var result = Outcome.Success;
            var input = text.trim(src);
            if(text.empty(input))
            {
                dst = 0;
                return true;
            }

            dst = default;
            var disp = 0;
            if(HexFormatter.HasSpec(input))
            {
                result = Hex.parse32i(src, out disp);
                if(result)
                    dst = disp;
            }
            else
            {
                result = DataParser.parse(src, out disp);
                if(result)
                    dst = disp;
            }
            return result;
        }

        public readonly int Value {get;}

        [MethodImpl(Inline)]
        public Disp32(int value)
        {
            Value = value;
        }

        public NativeSize Size
            => NativeSizeCode.W32;

        public bool Positive
        {
            [MethodImpl(Inline)]
            get => Value > 0;
        }

        public bool Negative
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
    }
}