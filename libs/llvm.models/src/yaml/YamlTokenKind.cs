//-----------------------------------------------------------------------------
// Copyright   : (c) LLVM Project
// License     : Apache-2.0 WITH LLVM-exceptions
// Source      : llvm/lib/Support/YAMLParser.cpp
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static ApiAtomic;

    using N = YamlTokenNames;

    [SymSource(llvm)]
    public enum YamlTokenKind : byte
    {
        None,

        [Symbol(N.StreamStart)]
        StreamStart,

        [Symbol(N.StreamEnd)]
        StreamEnd,

        [Symbol(N.VersionDirective)]
        VersionDirective,

        [Symbol(N.TagDirective)]
        TagDirective,

        [Symbol(N.DocumentStart)]
        DocumentStart,

        [Symbol(N.DocumentEnd)]
        DocumentEnd,

        [Symbol(N.BlockEntry)]
        BlockEntry,

        [Symbol(N.BlockEnd)]
        BlockEnd,

        [Symbol(N.BlockSequenceStart)]
        BlockSequenceStart,

        [Symbol(N.BlockMappingStart)]
        BlockMappingStart,

        [Symbol(N.FlowEntry)]
        FlowEntry,

        [Symbol(N.FlowSequenceStart)]
        FlowSequenceStart,

        [Symbol(N.FlowSequenceEnd)]
        FlowSequenceEnd,

        [Symbol(N.FlowMappingStart)]
        FlowMappingStart,

        [Symbol(N.FlowMappingEnd)]
        FlowMappingEnd,

        [Symbol(N.Key)]
        Key,

        [Symbol(N.Value)]
        Value,

        [Symbol(N.Scalar)]
        Scalar,

        [Symbol(N.BlockScalar)]
        BlockScalar,

        [Symbol(N.Alias)]
        Alias,

        [Symbol(N.Anchor)]
        Anchor,

        [Symbol(N.Tag)]
        Tag
    }
}