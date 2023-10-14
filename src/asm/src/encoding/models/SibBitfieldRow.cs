//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Record(TableId)]
public struct SibBitfieldRow
{
    const string TableId = "sib.bits";

    [Render(5)]
    public num2 scale;

    [Render(5)]
    public num3 index;

    [Render(5)]
    public num3 @base;

    [Render(3)]
    public Hex8 hex;

    [Render(10)]
    public CharBlock10 bitstring;
}
