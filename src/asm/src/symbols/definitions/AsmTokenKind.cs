//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

public enum AsmTokenKind : byte
{
    None,

    Register,

    OpCode,

    OpCodeTable,

    Sig,

    Conditions,

    Syntax
}