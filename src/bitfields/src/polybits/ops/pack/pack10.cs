//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num10 pack(num2 a, num8 b)
        => (num10)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num10 pack(num5 a, num5 b)
        => (num10)((uint)a | sll((uint)b, num5.Width));

    [MethodImpl(Inline), Op]
    public static num10 pack(num9 a, bit b)
        => (num10)((uint)a |sll((uint)b, num9.Width));

    [MethodImpl(Inline), Op]
    public static num10 pack(num6 a, num4 b)
        => (num10) ((uint)a | ((uint)b << num6.Width));

}
