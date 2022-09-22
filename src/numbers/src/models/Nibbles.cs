//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static Bytes;

    using api = BitNumbers;

    [ApiComplete]
    public readonly ref struct Nibbles
    {
        [MethodImpl(Inline)]
        public static Nibbles from(Span<byte> src)
            => new Nibbles(src);

        [MethodImpl(Inline)]
        public static uint count(in Nibbles src)
            => src.Width/4;

        [MethodImpl(Inline)]
        public static uint4 read(in Nibbles src, uint index)
        {
            var cell = MemoryScales.index(4, -2, index);
            ref readonly var c = ref skip(src.Bytes, cell.Offset);
            return cell.Aligned ? api.uint4(c) : api.uint4(srl(c , (byte)cell.CellWidth));
        }

        [MethodImpl(Inline)]
        public static void write(uint4 src, uint index, in Nibbles dst)
        {
            const byte UpperMask = 0xF0;
            const byte LowerMask = 0x0F;
            var cell = MemoryScales.index(4, -2, index);
            ref var c = ref seek(dst.Bytes, cell.Offset);
            if(cell.Aligned)
                c = or(and(c, UpperMask), src);
            else
                c = or(sll(src, (byte)cell.CellWidth), and(c, LowerMask));
        }

        readonly Span<byte> Data;

        [MethodImpl(Inline)]
        internal Nibbles(Span<byte> data)
        {
            Data = data;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Size.Bits;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => count(this);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)Count;
        }

        public uint4 this[ulong index]
        {
            [MethodImpl(Inline)]
            get => read(this, (uint)index);

            [MethodImpl(Inline)]
            set => write(value, (uint)index, this);
        }

        public uint4 this[long index]
        {
            [MethodImpl(Inline)]
            get => read(this, (uint)index);

            [MethodImpl(Inline)]
            set => write(value, (uint)index, this);
        }

        public string Format()
        {
            var dst = text.buffer();
            var count = Data.Length;
            dst .Append(Chars.LBracket);
            for(var i=0; i<count; i++)
            {
                var buffer = CharBlock16.Null.Data;
                var j=0u;
                var length = BitRender.render8x4(skip(Data,i), buffer);
                dst.Append(slice(buffer,0,length));
                if(i != count -1)
                    dst.Append(Chars.Space);
            }
            dst .Append(Chars.RBracket);
            return dst.Emit();
        }
    }
}