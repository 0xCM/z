//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class BitSpans
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static BitSpan scalar<T>(T src)
            where T : unmanaged
        {
            if(size<T>() == 1)
            {
                var input = bw8(src);
                var storage = ByteBlocks.alloc(n8).Storage<bit>();
                BitPack.unpack1x8(input, storage);
                return storage;
            }
            else if(size<T>() == 2)
            {
                var input = bw16(src);
                var storage = ByteBlocks.alloc(n16).Storage<bit>();
                BitPack.unpack1x16x8(input, storage);
                return storage;
            }
            else if(size<T>() == 4)
            {
                var input = bw32(src);
                var storage = ByteBlocks.alloc(n32).Storage<bit>();;
                BitPack.unpack1x32x8(input, storage);
                return storage;
            }
            else if(size<T>() == 8)
            {
                var input = bw64(src);
                var storage = ByteBlocks.alloc(n64).Storage<bit>();;
                BitPack.unpack1x64(input, storage);
                return storage;
            }
            else
                throw no<T>();
        }
    }
}