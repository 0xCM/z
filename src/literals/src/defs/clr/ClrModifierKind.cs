//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags, SymSource(clr)]
    public enum ClrModifierKind : byte
    {
        None = 0,

        Static = 1,

        Const = 2,

        ReadOnly = 4
    }
}