//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class Numbers
{
    [MethodImpl(Inline), Op]
    public static num11 pack(num2 a, num9 b)
        => (num11)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num11 pack(num3 a, num8 b)
        => (num11)((uint)a | sll((uint)b, num3.Width));

    [MethodImpl(Inline), Op]
    public static num11 pack(num9 a, num2 b)
        => (num11)((uint)a | sll((uint)b, num9.Width));

    [MethodImpl(Inline), Op]
    public static num11 pack(bit a, bit b, num9 c)
        => (num11)((uint)a | ((uint)b << 1) | ((uint)c << 2));

    [MethodImpl(Inline), Op]
    public static num11 pack(num6 a, num5 b)
        => (num11)((uint)a | ((uint)b << num6.Width));    
}
