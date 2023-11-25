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
        // [Op]
        // public static ByteSize emit(in MemoryBlock block, uint index, StreamWriter dst)
        // {
        //     var data = block.View;
        //     var size = (uint)data.Length;
        //     var buffer = sys.alloc<char>(data.Length*2);
        //     Hex.pack(data, buffer);
        //     dst.WriteLine(string.Format(HexLine.HexPackPattern, block.BaseAddress, index, size, new string(buffer)));
        //     return size;
        // }

        // [Op]
        // public static BinaryCode pack(uint size, ReadOnlySpan<ApiEncoded> src)
        // {
        //     var dst = alloc<byte>(size);
        //     var k = 0u;
        //     for(var i=0; i<src.Length; i++)
        //     {
        //         ref readonly var code = ref src[i].Code;
        //         for(var j=0; j<code.Length; j++, k++)
        //             seek(dst,k) = code[j];
        //     }
        //     return dst;
        // }

        // [Op]
        // public static BinaryCode pack(ReadOnlySpan<BinaryCode> src)
        // {
        //     var count = src.Length;
        //     if(count == 0)
        //         return BinaryCode.Empty;
        //     var dst = alloc<byte>(BinaryRows.size(src));
        //     var k = 0u;
        //     for(var i=0u; i<count; i++)
        //     {
        //         var data = skip(src,i).View;
        //         for(var j=0u; j<data.Length; j++, k++)
        //             seek(dst, k) = skip(data, j);
        //     }
        //     return dst;
        // }

        // [Op]
        // public static BinaryCode pack(ReadOnlySpan<HexDataRow> src)
        // {
        //     var count = src.Length;
        //     if(count == 0)
        //         return BinaryCode.Empty;

        //     var size = BinaryRows.size(src);
        //     var dst = alloc<byte>(size);
        //     var offset = 0u;
        //     for(var i=0; i<count; i++)
        //     {
        //         var data = skip(src,i).Data.View;
        //         for(var j=0; j<data.Length; j++)
        //             seek(dst, offset++) = skip(data,j);
        //     }
        //     return dst;
        // }
 

        // [MethodImpl(Inline), Op]
        // public static ByteSize size(ReadOnlySpan<HexDataRow> src)
        // {
        //     var dst = 0ul;
        //     for(var i=0; i<src.Length; i++)
        //         dst += skip(src,i).Data.Count;
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static ByteSize size(ReadOnlySpan<BinaryCode> src)
        // {
        //     var dst = 0ul;
        //     for(var i=0; i<src.Length; i++)
        //         dst += skip(src,i).Count;
        //     return dst;
        // }
    }
}