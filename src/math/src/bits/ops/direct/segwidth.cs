//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class bits
{
    [MethodImpl(Inline), Op]
    public static byte segwidth(byte i0, byte i1)
        => (byte)(i1 - i0 + 1);

    [MethodImpl(Inline), Op]
    public static uint segwidth(uint i0, uint i1)
        => i1 - i0 + 1;
}
