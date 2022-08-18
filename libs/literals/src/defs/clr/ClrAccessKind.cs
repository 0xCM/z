//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags, SymSource(clr)]
    public enum ClrAccessKind : uint
    {
        None = 0,

        [Symbol("public")]
        Public = 1,

        [Symbol("private")]
        Private = 2,

        [Symbol("protected")]
        Protected = 4,

        [Symbol("internal")]
        Internal = 8,

        [Symbol("protected internal")]
        ProtectedInternal = Protected | Internal
    }
}