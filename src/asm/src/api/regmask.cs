//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static RegMask regmask(RegOp target, RegIndex mask, RegMaskKind kind)
        => new (target,mask,kind);
}