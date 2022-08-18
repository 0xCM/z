//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource("asm")]
    public enum BranchTargetWidth : byte
    {
        None = 0,

        Branch16 = 16,

        Branch32 = 32,

        Branch64 = 64,
    }
}