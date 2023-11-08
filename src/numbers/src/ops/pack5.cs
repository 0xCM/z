//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;
using static sys;

partial class Numbers
{
    [MethodImpl(Inline), Op]
    public static num5 pack(bit a, num4 b)
        => (num5)((uint)a | sll((uint)b, num1.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num4 a, bit b)
        => (num5)((uint)a | sll((uint)b, num1.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num2 a, num3 b)
        => (num5)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num3 a, num2 b)
        => (num5)((uint)a | sll((uint)b, num3.Width));

    [MethodImpl(Inline), Op]
    public static num5 pack(num3 a, bit b, bit c)
        => (num5)(u32(a) | sll(u32(b), num3.Width) | sll(u32(c), num3.Width + num1.Width));    
}
