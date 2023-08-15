//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class BinaryRows
    {
        [MethodImpl(Inline), Op]
        public static MemoryBlock max(ReadOnlySpan<MemoryBlock> src)
        {
            var max = MemoryBlock.Empty;
            var count = src.Length;
            if(count == 0)
                return max;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(src,i);
                if(block.Size > max.Size)
                    max = block;
            }
            return max;
        }

        [Op]
        public static ByteSize emit(in MemoryBlock block, uint index, StreamWriter dst)
        {
            var data = block.View;
            var size = (uint)data.Length;
            var buffer = sys.alloc<char>(data.Length*2);
            Hex.pack(data, buffer);
            dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, index, size, new string(buffer)));
            return size;
        }

        [Op]
        public static BinaryCode pack(uint size, ReadOnlySpan<ApiEncoded> src)
        {
            var dst = alloc<byte>(size);
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var code = ref src[i].Code;
                for(var j=0; j<code.Length; j++, k++)
                    seek(dst,k) = code[j];
            }
            return dst;
        }

        [Op]
        public static BinaryCode pack(ReadOnlySpan<BinaryCode> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;
            var dst = alloc<byte>(BinaryRows.size(src));
            var k = 0u;
            for(var i=0u; i<count; i++)
            {
                var data = skip(src,i).View;
                for(var j=0u; j<data.Length; j++, k++)
                    seek(dst, k) = skip(data, j);
            }
            return dst;
        }

        [Op]
        public static BinaryCode pack(ReadOnlySpan<HexDataRow> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = BinaryRows.size(src);
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                var data = skip(src,i).Data.View;
                for(var j=0; j<data.Length; j++)
                    seek(dst, offset++) = skip(data,j);
            }
            return dst;
        }
 
        [Op]
        public static string pack(MemorySegment src, uint index, Span<char> dst)
        {
            var memspan = src.ToSpan();
            var count = Hex.pack(memspan.View, dst);
            var chars = slice(dst, 0, count);
            return string.Format(HexLine.HexPackPattern, memspan.BaseAddress, index, (uint)memspan.Size, text.format(chars));
        }

        [Op]
        public static ByteSize emit(MemoryBlocks src, FilePath dst)
        {
            using var writer = dst.Writer();
            return emit(src, writer);
        }

        [Op]
        public static ByteSize emit(MemoryBlocks src, StreamWriter dst)
        {
            var blocks = src.View;
            var maxsz = max(blocks).Size;
            var count = blocks.Length;
            var buffer = span<char>(maxsz*2);
            var total = 0u;
            for(var i=0u; i<count;i++)
            {
                buffer.Clear();
                ref readonly var block = ref skip(blocks,i);
                var charcount = Hex.pack(block.View, buffer);
                var formatted = text.format(slice(buffer,0, charcount));
                var size = (uint)block.Size;
                dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, i, size, formatted));
                total += size;
            }
            return total;
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<HexDataRow> src)
        {
            var dst = 0ul;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i).Data.Count;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ByteSize size(ReadOnlySpan<BinaryCode> src)
        {
            var dst = 0ul;
            for(var i=0; i<src.Length; i++)
                dst += skip(src,i).Count;
            return dst;
        }
    }
}