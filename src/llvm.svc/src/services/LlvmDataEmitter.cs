//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmDataEmitter : WfSvc<LlvmDataEmitter>
    {
        LlvmPaths LlvmPaths => Wf.LlvmPaths();

        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataCalcs DataCalcs => Wf.LlvmDataCalcs();

        public LlvmQuery Query => Service(() => LlvmQuery.create(Wf));

        public void EmitClassRelations(Index<LineRelations> src)
            => TableEmit(src, LlvmPaths.DbTable<LineRelations>("llvm.classes"));

        public void EmitDefRelations(Index<LineRelations> src)
            => TableEmit(src, LlvmPaths.DbTable<LineRelations>("llvm.defs"));

        public void Emit(string name, Index<TestResult> src)
            => TableEmit(src, LlvmPaths.TestResultTargets().PrefixedTable<TestResult>(name));

        public void Emit(ReadOnlySpan<LlvmInstDef> src)
            => TableEmit(src, LlvmPaths.DbTable<LlvmInstDef>());

        public void Emit(ReadOnlySpan<AsmMnemonicRow> src)
            => TableEmit(src, LlvmPaths.DbTable("llvm.asm.mnemonics"));

        public void Emit(ReadOnlySpan<LlvmAsmInstPattern> src)
            => TableEmit(src, LlvmPaths.DbTable<LlvmAsmInstPattern>());

        public void Emit(ReadOnlySpan<LlvmAsmVariation> src)
            => TableEmit(src, LlvmPaths.DbTable<LlvmAsmVariation>());

        public FilePath EmitList(LlvmList src)
        {
            var dst = LlvmPaths.ListTargetPath(src.Name);
            EmitList(src,dst);
            return dst;
        }

        public void EmitList(LlvmList src, FilePath dst)
            => TableEmit(src.Items, dst);

        public void Emit(RegIdentifiers src)
        {
            var dst = LlvmPaths.DbTable(RegIdentifier.TableId);
            var list = new LlvmList(dst, src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format())));
            EmitList(list, dst);
        }

        public void Emit(AsmIdentifiers src)
        {
            var items = src.Values.Select(x => new LlvmListItem(x.Id, x.Name.Format()));
            var dst = LlvmPaths.DbTable(AsmIdentifier.TableId);
            EmitList(new LlvmList(dst, items), dst);
        }

        public void Emit(ReadOnlySpan<LlvmAsmOpCode> src)
            => TableEmit(src, LlvmPaths.DbTable<LlvmAsmOpCode>());

        public Index<LlvmList> EmitLists(Index<LlvmEntity> entities)
        {
            Files paths = LlvmPaths.ListNames().Map(x => LlvmPaths.ListTargetPath(x));
            paths.Delete();
            return EmitLists(entities, DataProvider.ConfiguredListNames());
        }

        Index<LlvmList> EmitLists(Index<LlvmEntity> src, ReadOnlySpan<string> classes)
        {
            var lists = DataCalcs.CalcLists(src, classes);
            iter(lists, c => EmitList(c), true);
            return lists;
        }

        public void EmitChildRelations(ReadOnlySpan<LlvmEntity> src)
            => TableEmit(DataCalcs.CalcChildRelations(src), LlvmPaths.DbTable<ChildRelation>());

        public Index<RecordField> EmitDefFields(Index<RecordField> src)
            => EmitFields(src, LlvmDatasets.X86DefFields);

        public Index<RecordField> EmitClassFields(Index<RecordField> src)
            => EmitFields(src, LlvmDatasets.dataset(LlvmTargetName.x86).ClassFields);

        Index<RecordField> EmitFields(Index<RecordField> src, string id)
        {
            TableEmit<RecordField>(src, RecordField.RenderWidths, LlvmPaths.DbTable(id));
            return src;
        }
    }
}