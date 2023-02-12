//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct AsmInfo
        {
            public asci64 Asm;

            public MemoryAddress IP;

            public AsmHexCode Encoded;

            public CategoryKind Category;

            public ExtensionKind Extension;

            public static AsmInfo Empty => default;
        }
    }
}