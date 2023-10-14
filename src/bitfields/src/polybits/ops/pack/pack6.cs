//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num6 pack(num2 a, num2 b, num2 c)
        => (num6)((uint)a | ((uint)b << 2) | ((uint)c << 4));

    [MethodImpl(Inline), Op]
    public static num6 pack(num2 a, num4 b)
        => (num6)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num6 pack(bit a, num5 b)
        => (num6)((uint)a | sll((uint)b, num1.Width));

    [MethodImpl(Inline), Op]
    public static num6 pack(num3 a, num3 b)
        => (num6)((uint)a | sll((uint)b, num3.Width));
}
