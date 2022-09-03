//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCheckCmd
    {
        ReadOnlySpan<byte> Input => new byte[]{0x44, 0x01, 0x58,0x04};

        const string InputBitsA = "0100 0100 0000 0001 0101 1000 0000 0100";

        const uint InputBitsB = 0b0100_0100_0000_0001_0101_1000_0000_0100;

        [Op]
        public static uint bitstring(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(src, ref i, dst);
        }

        [CmdOp("asm/check/vmask")]
        unsafe void TestVCpu()
        {
            var v0 = vmask.veven<byte>(w128, n2, n2);
            var v0bits = v0.ToBitSpan();
            var options = BitFormat.configure();
            options.BlockWidth = 8;
            Write(v0bits.Format(options));
            var v1 = vmask.veven<byte>(w256, n2, n2);
            var v1bits = v1.ToBitSpan();
            Write(v1bits.Format(options));
        }

        [CmdOp("asm/check/bitstrings")]
        Outcome CheckBitstrings(CmdArgs args)
        {
            Storage.chars(n128, out var block1);
            var count = bitstring(Input, block1.Data);
            var chars = slice(block1.Data,0,count);
            var bits = text.format(chars);
            Write(InputBitsA);
            Write(bits);

            Storage.chars(n128, out var block2);
            count = bitstring(bytes(InputBitsB), block2.Data);
            bits = text.format(chars);
            Write(bits);

            var v = vpack.vunpack32x8(0xF0F0F0F0);
            Write(v.FormatBlockedBits(8));

            CheckBitSpans();
            CheckBitFormatter();
            return true;
        }

        void CheckBitSpans()
        {
            var result = Outcome.Success;
            var options = BitFormat.Default.WithBlockWidth(8);
            var v1 = vmask.vmsb<byte>(w128, n8, n7);
            var b1 = v1.ToBitSpan();
            Write(b1.Format(options));
        }

        void CheckBitFormatter()
        {
            var block = CharBlock128.Null;
            var buffer = block.Data;
            var input = 0b1100_0111_0101u;
            var n = 12u;
            var data = bytes(input);
            ref readonly var b0 = ref skip(data,0);
            ref readonly var b1 = ref skip(data,1);
            var i=0u;
            BitRender.render(b0, ref i, 8, buffer);
            seek(buffer,i++) = Chars.Underscore;
            BitRender.render(b1, ref i, 4, buffer);
            Write(block.Format());
        }
    }
}