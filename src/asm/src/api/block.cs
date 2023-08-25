//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static AsmBlockSpec block(AsmBlockLabel label)
        => new (AsmComment.Empty, label, sys.empty<AsmInstruction>());

    [MethodImpl(Inline), Op]
    public static AsmBlockSpec block(AsmBlockLabel label, params AsmInstruction[] content)
        => new (AsmComment.Empty, label, content);

    [MethodImpl(Inline), Op]
    public static AsmBlockSpec block(AsmComment comment, AsmBlockLabel label, params AsmInstruction[] content)
        => new (comment, label, content);
}
