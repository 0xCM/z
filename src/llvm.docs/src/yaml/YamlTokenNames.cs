//-----------------------------------------------------------------------------
// Copyright   : (c) LLVM Project
// License     : Apache-2.0 WITH LLVM-exceptions
// Source      : llvm/lib/Support/YAMLParser.cpp
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiAtomic;

    [LiteralProvider(llvm)]
    public readonly struct YamlTokenNames
    {
        public const string Alias = "Alias:";

        public const string Anchor = "Anchor:";

        public const string BlockEnd = "Block-End:";

        public const string BlockEntry = "Block-Entry:";

        public const string BlockMappingStart = "Block-Mapping-Start:";

        public const string BlockScalar = "Block Scalar:";

        public const string BlockSequenceStart = "Block-Sequence-Start:";

        public const string DocumentStart = "Document-Start:";

        public const string DocumentEnd = "Document-End:";

        public const string FlowEntry = "Flow-Entry:";

        public const string FlowMappingStart = "Flow-Mapping-Start:";

        public const string FlowMappingEnd = "Flow-Mapping-End:";

        public const string FlowSequenceStart = "Flow-Sequence-Start:";

        public const string FlowSequenceEnd = "Flow-Sequence-End:";

        public const string Key = "Key:";

        public const string Scalar = "Scalar:";

        public const string StreamStart = "Stream-Start:";

        public const string StreamEnd = "Stream-End:";

        public const string Tag = "Tag:";

        public const string TagDirective = "Tag-Directive:";

        public const string Value = "Value:";

        public const string VersionDirective = "Version-Directive:";
    }
}