//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource]
    public enum TypeRefKind : byte
    {
        [Symbol("")]
        Direct = 0,

        Indirect = 1,

        [Symbol("in")]
        In = 2 | Indirect,

        [Symbol("out")]
        Out = 4 | Indirect,

        [Symbol("ref")]
        IO = In | Out,

        [Symbol("*")]
        Ptr = 8 | Indirect,
    }
}