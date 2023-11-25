//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct Hex
{
    [MethodImpl(Inline), Op]
    public static byte combine(HexDigitValue lo, HexDigitValue hi)
        => (byte)((byte)hi << 4 | (byte)lo);
}