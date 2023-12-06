//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public class PolyBits : AppService<PolyBits>
{
    const NumericKind Closure = UInt64k;

    // public Index<BitMaskInfo> ApiBitMasks
    //     => Data("BitMasks", () => Bitfields.masks(typeof(BitMaskLiterals)));


    // public static Index<CharBlock8> blocks(W8 w, byte start = 0, byte end = byte.MaxValue)
    // {
    //     var count = end - start + 1;
    //     var buffer = alloc<CharBlock8>(count);
    //     ref var dst = ref first(buffer);
    //     var k = 0;
    //     for(uint i=start; i<=end; i++, k++)
    //     {
    //         var block = CharBlock8.Null;
    //         var data = block.Data;
    //         for(var j=0; j<8; j++)
    //             seek(data,j) = bit.test(i,(byte)j).ToChar();
    //         block.Data.Invert();
    //         seek(dst,k) = block;
    //     }

    //     return buffer;
    // }

    // public static Index<CharBlock16> blocks(W16 w, ushort start = 0, ushort end = ushort.MaxValue)
    // {
    //     var count = end - start + 1;
    //     var buffer = alloc<CharBlock16>(count);
    //     ref var dst = ref first(buffer);
    //     var k = 0;
    //     for(uint i=start; i<=end; i++, k++)
    //     {
    //         var block = CharBlock16.Null;
    //         var data = block.Data;
    //         for(var j=0; j<16; j++)
    //             seek(data,j) = bit.test(i,(byte)j).ToChar();
    //         block.Data.Invert();
    //         seek(dst,k) = block;
    //     }

    //     return buffer;
    // }
}
