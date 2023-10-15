//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num5 pack(bit a, num4 b)
        => (num5)((uint)a | sll((uint)b, num1.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num3 a, num2 b)
        => (num5)((uint)a | sll((uint)b, num3.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num2 a, num3 b)
        => (num5)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num3 a, bit b, bit c)
        => (num5)((uint)a | sll((uint)b, num3.Width) | sll((uint)c, num3.Width + 1));    
}
