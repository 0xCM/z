//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using C = AsciCode;
using S = AsciSymbol;

partial struct Hex
{
    [Op]
    public static ByteSize pack(MemorySegment src, StreamWriter dst)
    {
        var data = src.View;
        var size = (uint)data.Length;
        var buffer = sys.alloc<char>(data.Length*2);
        Hex.pack(data, buffer);
        dst.WriteLine(buffer);
        return size;
    }

    [Op]
    public static string pack(MemorySegment src, Span<char> dst)
    {
        var size = pack(src.View, dst);
        var chars = slice(dst, 0, size);
        return text.format(chars);
    }

    [MethodImpl(Inline), Op]
    public static uint pack(ReadOnlySpan<byte> src, Span<char> dst)
    {
        var j = 0u;
        var count = min(src.Length, dst.Length);
        for(var i=0; i<count; i++)
        {
            ref readonly var b = ref skip(src,i);
            seek(dst,j++) = hexchar(LowerCase, b, 1);
            seek(dst,j++) = hexchar(LowerCase, b, 0);
        }
        return j;
    }

    [MethodImpl(Inline), Op]
    public static uint pack(ReadOnlySpan<byte> src, Span<S> dst)
    {
        var j = 0u;
        var count = min(src.Length, dst.Length);
        for(var i=0; i<count; i++)
        {
            ref readonly var b = ref skip(src,i);
            seek(dst,j++) = hexchar(LowerCase, b, 1);
            seek(dst,j++) = hexchar(LowerCase, b, 0);
        }
        return j;
    }        

    [MethodImpl(Inline), Op]
    public static uint pack(ReadOnlySpan<byte> src, Span<C> dst)
        => pack(src, recover<C,S>(dst));

    // [MethodImpl(Inline), Op]
    // static MemoryBlock max(ReadOnlySpan<MemoryBlock> src)
    // {
    //     var max = MemoryBlock.Empty;
    //     var count = src.Length;
    //     if(count == 0)
    //         return max;
    //     for(var i=0; i<count; i++)
    //     {
    //         ref readonly var block = ref skip(src,i);
    //         if(block.Size > max.Size)
    //             max = block;
    //     }
    //     return max;
    // }

    // [Op]
    // public static ByteSize pack(MemoryBlocks src, FileUri dst)
    // {
    //     using var writer = dst.AsciWriter();
    //     return pack(src, writer);
    // }

    // [Op]
    // public static ByteSize pack(MemoryBlocks src, StreamWriter dst)
    // {
    //     var blocks = src.View;
    //     var maxsz = max(blocks).Size;
    //     var count = blocks.Length;
    //     var buffer = span<char>(maxsz*2);
    //     var total = 0u;
    //     for(var i=0u; i<count;i++)
    //     {
    //         buffer.Clear();
    //         ref readonly var block = ref skip(blocks,i);
    //         var charcount = Hex.pack(block.View, buffer);
    //         dst.WriteLine(slice(buffer,0, charcount));
    //         total += (uint)block.Size;
    //     }
    //     return total;
    // }

}
