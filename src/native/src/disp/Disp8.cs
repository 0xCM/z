//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a signed 8-bit displacement
    /// </summary>
    public readonly struct Disp8 : IDisplacement<Disp8,sbyte>
    {
        [Parser]
        public static Outcome parse(string src, out Disp8 dst)
        {
            var result = Outcome.Success;
            var input = text.trim(src);
            if(text.empty(input))
            {
                dst = z8i;
                return true;
            }

            dst = default;
            var disp = z8i;
            if(HexFormatter.HasSpec(input))
            {
                result = Hex.parse8i(src, out disp);
                if(result)
                    dst = disp;
            }
            else
            {
                result = NumericParser.parse(src, out disp);
                if(result)
                    dst = disp;
            }
            return result;
        }

        /// <summary>
        /// The base displacement magnitude
        /// </summary>
        public readonly sbyte Value {get;}

        [MethodImpl(Inline)]
        public Disp8(sbyte @base)
        {
            Value = @base;
        }

        public NativeSize Size
            => NativeSizeCode.W8;

        public bool IsNonZero
        {
            [MethodImpl(Inline)]
            get => Value == 0;
        }

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

        long IDisplacement.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Disp8 src)
            => Value == src.Value;

        public string Format()
            => Disp.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Disp8(byte src)
            => new Disp8((sbyte)src);

        [MethodImpl(Inline)]
        public static implicit operator Disp8(sbyte src)
            => new Disp8(src);

        [MethodImpl(Inline)]
        public static implicit operator byte(Disp8 src)
            => (byte)src.Value;

        [MethodImpl(Inline)]
        public static explicit operator sbyte(Disp8 src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Disp(Disp8 src)
            => new Disp(src.Value, src.Size);
    }
}