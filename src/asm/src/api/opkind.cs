//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static AsmOpKind opkind(AsmOpClass @class, NativeSize size)
        => (AsmOpKind)math.or((ushort)@class, math.sll((ushort)size,8));
}