//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ArgPrefixKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("-")]
        Dash,

        [Symbol("--")]
        Dashes,

        [Symbol("/")]
        FSlash,
    }
}