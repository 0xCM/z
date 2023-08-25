//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Flags,SymSource("asm")]
public enum AsmBitModeKind : byte
{
    None = 0,

    Mode16 = 1,

    Mode32 = 2,

    Mode64 = 4
}
