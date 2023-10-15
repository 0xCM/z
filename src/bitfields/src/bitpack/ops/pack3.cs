//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num3 pack(num2 a, bit b)
        => (num3)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num3 pack(bit a, num2 b)
        => (num3)((uint)a | sll((uint)b, num1.Width));

    [MethodImpl(Inline), Op]
    public static num3 pack(bit a, bit b, bit c)
        => (num3)((uint)a | sll((uint)b, 1) | sll((uint)c, 2));    
}
