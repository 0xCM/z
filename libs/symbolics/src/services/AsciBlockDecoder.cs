//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct AsciBlockDecoder
    {
        public static unsafe void decode(MemoryFile src, Action<CharBlock32> receiver)
        {
            var size = src.FileSize;
            var blocks = (uint)size/32;
            var remainder = (uint)size%32;
            decode(src, blocks, remainder, receiver);
        }

        public static unsafe void decode(MemoryFile src, uint blocks, uint remainder, Action<CharBlock32> receiver)
        {
            const uint BlockSize = 32;
            var counter = 0u;
            var seg = src.Segment();
            var offset = src.BaseAddress;
            var dst = CharBlock32.Null;
            for(var i=0u; i<blocks; i++)
            {
                decode(offset, BlockSize, out dst);
                receiver(dst);
                offset = offset + BlockSize;
            }
            decode(offset, remainder, out dst);
            receiver(dst);
        }

        public static unsafe void decode(MemoryAddress src, uint size, out CharBlock32 dst)
        {
            var input = core.cover(src.Pointer<byte>(), size);
            dst = CharBlock32.Null;
            var buffer = recover<ushort>(dst.Data);
            if(size == 32)
                gcpu.vstore(Asci.decode(cpu.vload(w256, input)), buffer);
            else
            {
                for(var i=0; i<size; i++)
                    seek(buffer,i) = skip(input,i);
            }
        }
    }
}