//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class PolyBits
{
    [MethodImpl(Inline), Op]
    public static num2 pack(bit a, bit b)
        => (num2)((uint)a | ((uint)b << 1));
}
