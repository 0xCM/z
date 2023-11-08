//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class BitfieldAttribute : Attribute
{
    public BitfieldAttribute(uint i0, uint i1)
    {
        MinPos = i0;
        MaxPos = i1;
    }

    public BitfieldAttribute(uint i)
    {
        MinPos = i;
        MaxPos = i;
    }

    public readonly uint MinPos;

    public readonly uint MaxPos;
}
