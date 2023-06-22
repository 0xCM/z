//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost,Free]
    public class ApiHexPacks
    {
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

    }
}