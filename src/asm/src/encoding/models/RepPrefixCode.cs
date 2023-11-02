//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public enum RepPrefixCode : byte
{
    [Symbol("F2")]
    REPNZ = 0xf2,

    [Symbol("F3")]
    REPZ = 0xf3,
}
