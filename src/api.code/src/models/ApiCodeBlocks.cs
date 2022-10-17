//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class ApiCodeBlocks
    {
        public static Outcome<CoffHex> hex(CoffObject coff, HexDataRow[] rows)
        {
            var result = validate(coff, rows, out var hex);
            if(result)
                return new CoffHex(coff, rows, hex);
            else
                return result;
        }

        public static Outcome validate(CoffObject coff, HexDataRow[] src, out BinaryCode hex)
        {
            hex = ApiCodeBlocks.pack(src);
            var hexsize = hex.Size;
            var objsize = coff.Size;
            if(hexsize != objsize)
                return (false,string.Format("Size mismatch: {0} != {1}", objsize, hexsize));

            var objData = coff.Data;
            var hexData = hex;
            var size = (uint)objsize;
            for(var j=0u; j<size; j++)
            {
                MemoryAddress offset = j;
                ref readonly var a = ref coff[j];
                ref readonly var b = ref hex[j];
                if(a != b)
                    return (false, string.Format("{0} != {1} at offset {2}", a.FormatHex(), b.FormatHex(), offset));
            }

            return true;
        }

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
        public static ByteSize emit(in MemoryBlock src, FilePath dst)
        {
            using var writer = dst.Writer();
            return ApiCodeBlocks.emit(src, 0, writer);
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
        public static string pack(in MemorySeg src, uint index, Span<char> dst)
        {
            var memspan = src.ToSpan();
            var count = Hex.pack(memspan.View, dst);
            var chars = slice(dst, 0, count);
            return string.Format(HexLine.HexPackPattern, memspan.BaseAddress, index, (uint)memspan.Size, text.format(chars));
        }

        [Op]
        public static ByteSize pack(ReadOnlySpan<ApiCodeBlock> src, Span<ApiHexPack> dst, Span<char> buffer)
        {
            var count = (uint)min(src.Length, dst.Length);
            var size = 0ul;
            for(var i=0u; i<count; i++)
            {
                ref readonly var block = ref skip(src,i);
                buffer.Clear();
                ref var package = ref seek(dst,i);
                package.Index = i;
                package.Address = block.BaseAddress;
                package.Size = block.Size;
                package.Data = sys.@string(slice(buffer,0, Hex.pack(block.Bytes, buffer)));
                size += package.Size;
            }
            return size;
        }

        public static Index<ApiHexPack> pack(SortedIndex<ApiCodeBlock> src, bool validate)
        {
            const ushort BufferLength = 48400;

            var blocks = src.View;
            var count = blocks.Length;
            var packs = alloc<ApiHexPack>(count);
            var chars = alloc<char>(BufferLength);
            ref var dst = ref first(packs);
            var size = pack(blocks, packs, chars);
            if(validate)
            {
                var buffer = span<HexDigitValue>(BufferLength);
                for(var i=0; i<count; i++)
                {
                    buffer.Clear();
                    ref readonly var pack = ref skip(dst,i);
                    var outcome = Hex.digits(pack.Data,buffer);
                    if(!outcome)
                    {
                        Errors.Throw("Reconstitution failed");
                        break;
                    }
                }
            }

            return packs;
        }                
        [Op]
        public static BinaryCode pack(ReadOnlySpan<HexDataRow> src)
        {
            var count = src.Length;
            if(count == 0)
                return BinaryCode.Empty;

            var size = ApiCodeBlocks.size(src);
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
            var dst = alloc<byte>(size(src));
            var k = 0u;
            for(var i=0u; i<count; i++)
            {
                var data = skip(src,i).View;
                for(var j=0u; j<data.Length; j++, k++)
                    seek(dst, k) = skip(data, j);
            }
            return dst;
        }


    }

}