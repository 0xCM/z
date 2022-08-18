//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("llvm/query/lineage")]
        void EmitLineageSummary()
        {
            var defrel = DataProvider.DefRelations();
            var classrel = DataProvider.ClassRelations();
            var dst = LlvmPaths.QueryOut("llvm.lineage", FileKind.Dot);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();

            TableEmit(DataProvider.ClassLineage().Values, LlvmPaths.QueryOut("llvm.lineage.classes", FileKind.Csv));
            TableEmit(DataProvider.DefLineage().Values, LlvmPaths.QueryOut("llvm.lineage.defs", FileKind.Csv));

            writer.AppendLine("digrapph G {");
            iter(classrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.IndentLine(4, string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.IndentLine(4, r.Name);
            });

            iter(defrel, r => {
                if(r.Ancestors.IsNonEmpty)
                    writer.IndentLine(4, string.Format("{0} -> {1}", r.Name, r.Ancestors));
                else
                    writer.IndentLine(4, r.Name);
            });

            writer.AppendLine("}");

            iter(Lines.relations(classrel), c => Write(c.Format()));

            EmittedFile(emitting, classrel.Length + defrel.Length);
        }
    }
}