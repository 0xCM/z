//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ArgPrefixKind : byte
    {
        None,

        Dash,

        Dashes,

        FSlash,
    }

    public enum ArgSepKind : byte
    {
        None,

        Space,

        Eq,

        Colon,

    }

    public record struct ToolCmdArg
    {
        public ArgPrefixKind Prefix;

        public @string Name;

        public ArgSepKind Sep;

        public @string Value;
    }
}