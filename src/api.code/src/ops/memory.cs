//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class ApiCode
    {
                    
        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeRow> src)
        {
            var count = src.Length;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = memory(skip(src,i));
            return dst;
        }

        [Op]
        public static MemoryBlocks memory(ReadOnlySpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return MemoryBlocks.Empty;
            var dst = sys.alloc<MemoryBlock>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                seek(dst,i) = new MemoryBlock(code.AddressRange, code.Encoded);
            }

            dst.Sort();
            return new MemoryBlocks(dst);
        }

        public static MemoryBlocks memory(FilePath src)
        {
            var dst = MemoryBlocks.Empty;
            var result = Outcome<MemoryBlocks>.Success;
            var unpacked = Outcome<ByteSize>.Success;
            var size  = ByteSize.Zero;
            var buffer = list<MemoryBlock>();
            var counter = z16;
            using var reader = src.AsciReader();
            var data = reader.ReadLine();
            var block = MemoryBlock.Empty;
            while(result.Ok && text.nonempty(data))
            {
                unpacked = parse(counter++, data, out block);
                if(unpacked.Fail)
                {
                    result = (false, unpacked.Message);
                    Errors.Throw(unpacked.Message);
                }
                else
                {
                    buffer.Add(block);
                    size += unpacked.Data;
                    data = reader.ReadLine();
                }
            }

            dst = buffer.ToArray();
            return dst;
        }

        [MethodImpl(Inline), Op]
        static MemoryBlock memory(in ApiCodeRow src)
            => new MemoryBlock(new MemoryRange(src.Address, src.Address + src.Data.Size), src.Data);
    }
}