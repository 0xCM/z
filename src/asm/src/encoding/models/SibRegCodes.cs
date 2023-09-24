//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[Record(TableId)]
public record struct SibRegCodes
{
    const string TableId = "sib.regcodes";

    [Render(5)]
    public asci8 Base;

    [Render(5)]
    public asci8 Index;

    [Render(5)]
    public uint2 Scale;

    [Render(3)]
    public Hex8 Hex;

    [Render(10)]
    public CharBlock10 Bits;
}
