//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class BitFormatChecks : Checker<BitFormatChecks>
    {
        FixedBitFormatter Formatter;

        Index<byte> _Data;

        Index<char> _Buffer;

        ReadOnlySpan<byte> Source
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        [MethodImpl(Inline)]
        string FormatBuffer(uint offset, uint length)
            => text.format(slice(_Buffer.View, offset, length));

        Span<char> RentBuffer()
            => _Buffer.Clear();

        void CheckBitView()
        {
            var result = Outcome.Success;
            //var m0 = BitMasks.odd<ulong>();
            var m = vmask.vodd(w128);
            var bits = BitView.create(m);
            Write(m.FormatHex(Chars.Space));
            var i=0u;
            Write($"1: {bits.View(w1, i)}");
            Write($"2: {bits.View(w2, i)}");
            Write($"3: {bits.View(w3, i)}");
            Write($"4: {bits.View(w4, i)}");
            Write($"5: {bits.View(w5, i)}");
            Write($"6: {bits.View(w6, i)}");
            Write($"7: {bits.View(w7, i)}");
            Write($"8: {bits.View(w8, i)}");

            i++;
            Write($"1: {bits.View(w1, i)}");
            Write($"2: {bits.View(w2, i)}");
            Write($"3: {bits.View(w3, i)}");
            Write($"4: {bits.View(w4, i)}");
            Write($"5: {bits.View(w5, i)}");
            Write($"6: {bits.View(w6, i)}");
            Write($"7: {bits.View(w7, i)}");
            Write($"8: {bits.View(w8, i)}");
        }

        void CheckAsciTables()
        {
            var buffer = span<char>(128);
            Write(AsciSymbols.format(AsciTables.letters(LowerCase).Codes, buffer));
            buffer.Clear();
            Write(AsciSymbols.format(AsciTables.letters(UpperCase).Codes, buffer));
            buffer.Clear();
            Write(AsciSymbols.format(AsciTables.digits().Codes, buffer));
            buffer.Clear();
        }

        public BitFormatChecks()
        {
            Formatter = new();
            _Buffer = alloc<char>(Pow2.T08);
        }

        Outcome CheckBraceMatching()
        {
            var result = Outcome.Success;
            const string Expect = "* 1 {} {33 a cde:} d*";
            var input = "aba {* 1 {} {33 a cde:} d*} x b";
            var inner = Fenced.unfence(input,0, Fenced.Embraced);
            if(inner!=Expect)
            {
                result = (false,string.Format("{0} != {1}", inner, Expect));
            }
            else
            {
                result = (true, "Success");
            }

            return result;

        }

        void CheckBv128()
        {
            var result = Outcome.Success;
            var bv0 = BitVectors.init(w128,(byte)0b10101010);
            Write(bv0.Format());
            var bv1 = bv0 << 12;
            Write(bv1.Format());
            var bv3 = bv1.Set(0,1).Set(1,1).Set(2,1).Set(3,1);
            Write(bv3);
        }


        Span<char> GenBitStrings8(uint count)
        {
            // var count = 256;
            // var length = 8;
            var buffer = span<char>(count*8);
            for(var i=0; i<count; i++)
            {
                ref var c = ref seek(buffer,i*8);
                for(byte j=0; j<8; j++)
                    seek(c,7-j) = bit.test(i,(byte)j).ToChar();
            }
            return buffer;
        }

        void CheckBitSeq()
        {
            var count = 256u;
            byte length = 8;
            var buffer = GenBitStrings8(count);

            for(var i=0; i<count; i++)
            {
                var offset = i*length;
                var s = slice(buffer,offset,length);
                Write(string.Format("{0:D3}=0x{0:X2}=0b{1}", i, text.format(s)));
            }
        }

        void CheckCells()
        {
            var source = alloc<byte>(Pow2.T08);
            source.Clear();
            Random.Bytes(source);
            var cells = recover<Cell16>(source);
            var count = cells.Length;
            var n = (uint)width<Cell16>();
            var buffer = span<char>(128);
            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                bits<Cell16> bits = (n, skip(cells,i));
                var len = BitRender.render(n,bits,buffer);
                slice(buffer,0,len);
                Write(string.Format("{0} Value{1} = {2};", bits.N, i, text.format(slice(buffer,0,len))));
            }
        }

        void CheckNibbleSpan()
        {
            var m0 =  Cells.cell64(BitMaskLiterals.Even64);
            var m1 = Cells.cell64(BitMaskLiterals.Lsb63x3x1);
            var storage = Cells.join(m0,m1);
            var bytes = sys.bytes(storage);
            var bits = BitRender.render8x8(bytes);
            Log(TextFormat.format(bits));

            var nibbles = Nibbles.from(bytes);
            var count = nibbles.Count;
            Log(string.Format("{0}:{1}", "Count", count));
            if(count != 32)
                return;

            Log(nibbles.Format());
        }

        void CheckJoin()
        {
            var c0 = Cells.cell64(BitMaskLiterals.Odd64);
            var c1 = Cells.cell64(BitMaskLiterals.Central64x16x8);
            var c2 = Cells.cell64(BitMaskLiterals.Lsb63x3x1);
            var c3 = Cells.cell64(BitMaskLiterals.Odd64);
            var c256 = Cells.join(c0,c1,c2,c3);
            Log(c256);
            var bytes = sys.bytes(c256);
            var nibbles = Nibbles.from(bytes);
            Log(nibbles.Format());
        }

        protected override void Execute(IEventTarget log)
        {
            _Data = Random.Bytes(256).Array();
            CheckNibbleSpan();
            CheckAsciTables();
            Check(w3);
            CheckJoin();
            CheckBitView();
            CheckBitSeq();
            CheckCells();
            Write(CheckBraceMatching());
            CheckBv128();
        }

        public Index<BitFormatCheck<W3,uint3>> Check(W3 w)
        {
            var buffer = alloc<BitFormatCheck<W3,uint3>>(_Data.Length);
            Check(w, buffer);
            return buffer;
        }

        [Op]
        void Check(W3 w, Index<BitFormatCheck<W3,uint3>> dst)
        {
            var target = dst.Edit;
            var count = _Data.Length;
            for(var i=0u; i<count; i++)
            {
                var a = skip(Source,i);
                var b = BitNumbers.uint3(a);
                seek(target,i) = result(w, i, b, Formatter.Format(b));
            }
        }

        [MethodImpl(Inline)]
        public static BitFormatCheck<W,T> result<W,T>(W w, uint seq, T input, string formatted)
            where T : unmanaged, IBitNumber
            where W : unmanaged, IDataWidth
        {
            var dst = new BitFormatCheck<W,T>();
            dst.Seq = seq;
            dst.Value = input;
            dst.Formatted = formatted;
            dst.LengthExpect = (uint)DataWidths.measure(w);
            dst.LengthActual = (uint)formatted.Length;
            dst.LenthMatch = dst.LengthExpect == dst.LengthActual;
            return dst;
        }
    }
}