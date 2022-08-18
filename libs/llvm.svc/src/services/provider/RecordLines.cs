//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<TextLine> RecordLines(string project, string name)
            => data($"{project}.{name}.records",() => LlvmPaths.RecordSet(project, name).ReadNumberedLines());

        public ReadOnlySpan<TextLine> RecordLines(string project, string name, ClosedInterval<uint> range)
            => slice(RecordLines(project,name).View, range.Min - 1, range.Max - range.Min + 1);

        public Index<TextLine> RecordLines(LlvmTargetName target)
        {
            var project = "llvm";
            using var reader = LlvmPaths.RecordSet(project, LlvmTargetName.x86).LineReader(TextEncodingKind.Asci);
            var lines = reader.ReadAll().ToArray().Index();
            return (Index<TextLine>)DataSets.GetOrAdd(project + "lines", _ => lines);
        }

        public ReadOnlySpan<TextLine> RecordLines(LlvmTargetName target, ClosedInterval<uint> range)
            => slice(RecordLines(target).View, range.Min - 1, range.Max - range.Min + 1);
    }
}