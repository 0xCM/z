//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Build
    {
        [LiteralProvider("build")]
        public readonly record struct OutputTypes
        {
            public const string Library = nameof(Library);

            public const string Exe = nameof(Exe);
        }
    }
}