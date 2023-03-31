//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies the presence of a bit and,if present, specifies its state
    /// </summary>
    [DataWidth(Width, 2)]
    public readonly record struct BitIndicator : IIndicator<BitIndicator,bit>
    {
        [MethodImpl(Inline)]
        public static BitIndicator defined(bit state)
            => new BitIndicator(state, 1);

        public const byte Width = num2.Width;

        readonly num2 Data;

        [MethodImpl(Inline)]
        public BitIndicator(num2 src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public BitIndicator(bit state, bit enabled)
        {
            Data = PolyBits.pack(state,enabled);
        }

        public bit Value
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,0);
        }

        public bit Enabled
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,1);
        }

        public bit Disabled
        {
            [MethodImpl(Inline)]
            get => !bit.test(Data,1);
        }

        [MethodImpl(Inline)]
        public int CompareTo(BitIndicator src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Disabled ? EmptyString : Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator bit(BitIndicator src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(BitIndicator src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator BitIndicator(byte src)
            => new BitIndicator(src);

        public static BitIndicator Empty => default;
    }
}