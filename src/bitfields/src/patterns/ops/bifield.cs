//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct BitPatterns
{
    public static BfDef bitfield(string name, BpExpr src)
        => Bitfields.define(name, segdefs(src));
}
