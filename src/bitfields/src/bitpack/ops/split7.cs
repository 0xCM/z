//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static void split(num7 src, out bit a, out num6 b)
    {
        a = (bit)src;
        b = (num6)(src >> num2.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num7 src, out num2 a, out num5 b)
    {
        a = (num2)src;
        b = (num5)(src >> num2.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num7 src, out num3 a, out num4 b)
    {
        a = (num3)src;
        b = (num4)(src >> num3.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num7 src, out num4 a, out num3 b)
    {
        a = (num4)src;
        b = (num3)(src >> num4.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num7 src, out num5 a, out num2 b)
    {
        a = (num5)src;
        b = (num2)(src >> num5.Width);
    }

    [MethodImpl(Inline), Op]
    public static void split(num7 src, out num6 a, out bit b)
    {
        a = (num6)src;
        b = (bit)(src >> num6.Width);
    }
}
