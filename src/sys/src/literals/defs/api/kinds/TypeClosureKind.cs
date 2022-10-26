//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(api_kinds)]
    public enum TypeClosureKind : byte
    {
        None = 0,

        Numeric = 1,

        Natural = 2,

        Imm8 = 4,

        Width = 8,

        Fixed = 16,

        NaturalPairs = 32,

        Opaque = 64,
    }
}