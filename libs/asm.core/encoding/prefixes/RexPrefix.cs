//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using F = RexFields;

    using static AsmPrefixCodes;

    /// <summary>
    /// REX = [0100 | W:4 | R:3 | X:2 | B:1]
    /// </summary>
    [ApiComplete]
    public struct RexPrefix : IAsmPrefix<RexPrefix>, IAsmByte<RexPrefix>
    {
        [MethodImpl(Inline), Op]
        public static uint render(RexPrefix src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            BitRender.render8x4(src.Encoded, ref  i, dst);
            return i-i0;
        }

        public static uint table(ITextBuffer dst)
        {
            static string describe(RexPrefix src)
            {
                const string RexFieldPattern = "[W:{0} | R:{1} | X:{2} | B:{3}]";
                var bits = text.format(BitRender.render8x4(src.Encoded));
                var bitfield = string.Format(RexFieldPattern, src.W, src.R, src.X, src.B);
                return $"{src.Encoded.FormatAsmHex()} | [{bits}] => {bitfield}";
            }

            var bits = RexPrefix.Range();
            var count = bits.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(describe(skip(bits,i)));
            return (uint)count;
        }

        [MethodImpl(Inline)]
        public static RexPrefix init()
            => new RexPrefix(0x40);

        byte Data;

        [MethodImpl(Inline)]
        public RexPrefix(byte src)
            => Data = src;

        [MethodImpl(Inline)]
        public RexPrefix(bit b, bit x, bit r, bit w)
        {
            Data = math.or(bit.pack(b,x,r,w), (byte)0x40);
        }

        public bit W
        {
            [MethodImpl(Inline)]
            get => bits.test(Data, F.W);

            [MethodImpl(Inline)]
            set => Data = bits.set(Data, F.W, value);
        }

        public bit R
        {
            [MethodImpl(Inline)]
            get => bits.test(Data, F.R);

            [MethodImpl(Inline)]
            set => Data = bits.set(Data, F.R, value);
        }

        public bit X
        {
            [MethodImpl(Inline)]
            get => bits.test(Data, F.X);

            [MethodImpl(Inline)]
            set => Data = bits.set(Data, F.X, value);
        }

        public bit B
        {
            [MethodImpl(Inline)]
            get => bits.test(Data, F.B);

            [MethodImpl(Inline)]
            set => Data = bits.set(Data, F.B, value);
        }

        public readonly byte Encoded
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        [MethodImpl(Inline)]
        public byte Value()
            => Data;

        public string Format()
            => AsmBytes.format(this);

        public string ToBitString()
            => BitRender.format8x4(Data);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hex8(RexPrefix src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RexPrefix(RexPrefixCode src)
            => new RexPrefix((byte)src);

        [MethodImpl(Inline)]
        public static implicit operator byte(RexPrefix src)
            => src.Data;

        [MethodImpl(Inline)]
        public static implicit operator RexPrefix(byte src)
            => new RexPrefix(src);

        public static RexPrefix Empty
            => new RexPrefix(0);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<RexPrefix> Range()
            => recover<RexPrefix>(RexPrefix._Range);

        static ReadOnlySpan<byte> _Range
            => new byte[16]{0x40,0x41,0x42,0x43,0x44,0x45,0x46,0x47,0x48,0x49,0x4A,0x4B,0x4C,0x4D,0x4E,0x4F};
    }
}