//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitPack
{
    [MethodImpl(Inline), Op]
    public static num15 pack(num9 a, num6 b)
        => (num15)((uint)a | ((uint)b << num9.Width));
}
