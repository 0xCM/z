//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num9 pack(num2 a, num7 b)
        => (num9)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num9 pack(num3 a, num6 b)
        => (num9)((uint)a | sll((uint)b, num3.Width));

    [MethodImpl(Inline), Op]
    public static num9 pack(num5 a, num4 b)
        => (num9)((uint)a | sll((uint)b, num5.Width));

    [MethodImpl(Inline), Op]
    public static num9 pack(num4 a, num5 b)
        => (num9)((uint)a | sll((uint)b, num4.Width));

    [MethodImpl(Inline), Op]
    public static num12 pack(num6 a, num6 b)
        => (num12)((uint)a | sll((uint)b, num6.Width));

    [MethodImpl(Inline), Op]
    public static num9 pack(num8 a, bit b)
        => (num9)((uint)a | (sll((uint)b,num8.Width)));
}
