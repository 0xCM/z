//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class ToolCmdArg
    {
        public ArgPrefixKind Prefix;

        public @string Name;

        public ArgSepKind Sep;

        public ArgValue Value;

        public ToolCmdArg()
        {
            Prefix = 0;
            Name = @string.Empty;
            Sep = 0;
            Value = ArgValue.Empty;
        }

        public ToolCmdArg(ArgPrefixKind prefix, @string name, ArgSepKind sep, ArgValue value)
        {
            Prefix = prefix;
            Name = name;
            Sep = sep;
            Value = value;
        }

        public string Format()
            => Tooling.format(this);

        public override string ToString()
            => Format();

        public static ToolCmdArg Empty => default;
    }
}