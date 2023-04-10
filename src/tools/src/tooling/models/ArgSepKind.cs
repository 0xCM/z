//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ArgSepKind : byte
    {
        [Symbol("")]
        None,

        [Symbol(" ")]
        Space,

        [Symbol("=")]
        Eq,

        [Symbol(":")]
        Colon,
    }
}