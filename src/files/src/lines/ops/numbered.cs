//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Lines
    {
        // [MethodImpl(Inline), Op]
        // public static bool numbered(ReadOnlySpan<char> src)
        // {
        //     if(src.Length < 9)
        //         return false;

        //     if(skip(src,8) != Chars.Colon)
        //         return false;

        //     for(var i=0; i<7; i++)
        //     {
        //         if(!Digital.test(base10, skip(src,i)))
        //             return false;
        //     }
        //     return true;
        // }

        // [MethodImpl(Inline), Op]
        // public static bool numbered(ReadOnlySpan<byte> src)
        // {
        //     if(src.Length < 9)
        //         return false;

        //     if(skip(src,8) != Chars.Colon)
        //         return false;

        //     for(var i=0; i<7; i++)
        //     {
        //         if(!Digital.test(base10, skip(src,i)))
        //             return false;
        //     }
        //     return true;
        // }
    }
}