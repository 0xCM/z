//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num13 pack(num2 a, num11 b)
        => (num13)((uint)a | sll((uint)b, num2.Width));

    [MethodImpl(Inline), Op]
    public static num13 pack(num9 a, num4 b)
        => (num13)((uint)a | sll((uint)b, num9.Width));

    [MethodImpl(Inline), Op]
    public static num13 pack(num6 a, num7 b)
        => (num13)((uint)a | ((uint)b << num6.Width));
}
