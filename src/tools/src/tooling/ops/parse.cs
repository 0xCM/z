//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Tooling
    {
        static readonly EnumParser<ArgPrefixKind> ArgPrefixParser = new();

        static readonly EnumParser<ArgSepKind> ArgSepParser = new();

        public static bool parse(string src, out ArgSepKind dst)
            => ArgSepParser.Parse(src, out dst);

        public static bool parse(string src, out ArgPrefixKind dst)
            => ArgPrefixParser.Parse(src, out dst);

    }
}