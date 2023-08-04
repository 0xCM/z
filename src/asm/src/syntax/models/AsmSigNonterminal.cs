//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Record(TableId)]
public struct AsmSigNonterminal
{
    const string TableId = "sdm.sigs.nonterminal";

    public const byte FieldCount = 4;

    [Render(12)]
    public AsmSigToken Source;

    [Render(12)]
    public AsmSigToken Term1;

    [Render(12)]
    public AsmSigToken Term2;

    [Render(12)]
    public AsmSigToken Term3;        
}
