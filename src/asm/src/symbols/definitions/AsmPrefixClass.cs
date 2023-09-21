//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[Flags]
public enum AsmPrefixClass : byte
{
    None = 0,

    Legacy = Pow2x8.P2ᐞ01,

    REX = Pow2x8.P2ᐞ02,

    VEX = Pow2x8.P2ᐞ03,

    EVEX = Pow2x8.P2ᐞ04,
}
