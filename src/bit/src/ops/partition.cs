//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        // /// <summary>
        // /// Partitions a bitstring into blocks of a specified maximum width
        // /// </summary>
        // /// <param name="width">The maximum block width</param>
        // [Op]
        // public static Index<bit>[] partition(ReadOnlySpan<bit> src, uint width)
        // {
        //     var srcLength = (uint)src.Length;
        //     var minCount = srcLength/width;
        //     var rem = srcLength%width;
        //     var count = rem != 0 ? minCount + 1 : minCount;
        //     var dst = sys.alloc<Index<bit>>(count);
        //     var dstLength = (uint)dst.Length;
        //     var target = span(dst);
        //     var last = dstLength - 1u;
        //     for(uint i=0, offset = 0; i<dstLength; i++, offset += width)
        //     {
        //         if(i == last && rem != 0)
        //         {
        //             var fullBlockBuffer = alloc<bit>(width);
        //             var fullBlock = span(fullBlockBuffer);
        //             var seg = slice(src, offset, rem);
        //             seg.CopyTo(fullBlock);
        //             seek(target, i) = new Index<bit>(fullBlockBuffer);
        //         }
        //         else
        //         {
        //             var seg = slice(src, offset, width);
        //             seek(target, i) = new Index<bit>(seg.ToArray());
        //         }
        //     }
        //     return dst;
        // }
    }
}