//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static void split(num8 src, out num4 a, out num4 b)
    {
        a = (num4)src;
        b = (num4)(src >> num4.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num8 src, out num5 a, out num3 b)
    {
        a = (num5)src;
        b = (num3)(src >> num5.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num8 src, out num6 a, out num2 b)
    {
        a = (num6)src;
        b = (num2)(src >> num6.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num8 src, out num7 a, out bit b)
    {
        a = (num7)src;
        b = (bit)(src >> num7.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num8 src, out num2 a, out num2 b, num2 c, num2 d)
    {
        a = (num2)src;
        b = (num2)(src >> num2.Width);
        c = (num2)(src >> num2.Width);
        d = (num2)(src >> num2.Width);
    }    
}
