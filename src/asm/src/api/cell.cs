//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static AsmCell cell(string content, AsmCellKind kind)
        => new AsmCell(kind, content);
}
