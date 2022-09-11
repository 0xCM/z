//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitMasks
    {
        // [MethodImpl(Inline)]
        // static char blendsymbol(bit b)
        //     => b ? 'R' : 'L';

        // [Op, Closures(Closure)]
        // static string vblendformat<T>(T spec, int len)
        //     where T : unmanaged
        // {
        //     Span<char> dst = stackalloc char[len];
        //     var bs =  BitRender.gformat(spec);
        //     for(var i=0; i<len; i++)
        //         seek(dst,i) = blendsymbol(bs[i]);
        //     return new string(dst);
        // }

        // [Op]
        // public static string format(Blend8x16 spec)
        //     => vblendformat(spec, 8);

        // [Op]
        // public static string format(Blend4x32 spec)
        //     => vblendformat(spec, 4);

        // [Op]
        // public static string format(Blend8x32 spec)
        //     => vblendformat(spec, 8);

        // [Op]
        // public static string format(Blend2x64 spec)
        //     => vblendformat(spec, 2);

        // [Op]
        // public static string format(Blend4x64 spec)
        //     => vblendformat(spec, 4);
    }
}