//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

[SymSource("asm.cc")]
public enum JccKind : byte
{
    None,

    Jcc8,

    Jcc8Alt,

    Jcc16,

    Jcc16Alt,

    Jcc32,

    Jcc32Alt,
}
