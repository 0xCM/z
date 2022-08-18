//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public record struct BlockPartition
    {
        [MethodImpl(Inline)]
        public static BlockPartition calc(ByteSize size, BitWidth bw, uint parts)
        {
            var dst = new BlockPartition();
            dst.SourceSize = (uint)size;
            dst.BlockSize = (uint)bw/8;
            dst.BlockCount = dst.SourceSize/dst.BlockSize;
            dst.BlockRemains = dst.SourceSize%dst.BlockSize;
            dst.BlockedSize = dst.BlockCount*dst.BlockSize;
            dst.PartCount = parts;
            dst.SegCount = dst.BlockCount/parts;
            dst.SegRemains = dst.BlockCount%parts;
            return dst;
        }

        [Render(12)]
        public uint SourceSize;

        [Render(12)]
        public uint BlockSize;

        [Render(12)]
        public uint BlockCount;

        [Render(12)]
        public uint BlockedSize;

        [Render(12)]
        public uint BlockRemains;

        [Render(12)]
        public uint PartCount;

        [Render(12)]
        public uint SegCount;

        [Render(12)]
        public uint SegRemains;
    }
}