//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmDataImporter : WfSvc<LlvmDataImporter>
    {
        LlvmDataProvider DataProvider => Wf.LlvmDataProvider();

        LlvmDataEmitter DataEmitter => Wf.LlvmDataEmitter();

        LlvmDataCalcs DataCalcs => Wf.LlvmDataCalcs();

        LlvmPaths LlvmPaths => Wf.LlvmPaths();

        LlvmLineMaps LineMaps => Wf.LlvmLineMaps();

        public void ImportTestLogs()
        {
            iter(new string[]
            {
                "clang",
                "llvm",
                "lldb",
                "lld",
                "mlir",
                "polly"
            }, name => DataEmitter.Emit(name, DataProvider.TestResults(name)), PllExec);
        }

        public void Run()
        {
            var lines = DataProvider.RecordLines(LlvmTargetName.x86);
            LlvmPaths.Tables().Delete();
            Index<LineRelations> defRelations = sys.empty<LineRelations>();
            LineMap<string> defMap = LineMap<string>.Empty;
            LineMap<string> classMap = LineMap<string>.Empty;
            Index<RecordField> classFields = sys.empty<RecordField>();
            Index<RecordField> defFields = sys.empty<RecordField>();

            exec(PllExec,
                () => ImportToolHelp(),
                ImportTestLogs,
                () => DataEmitter.Emit(DataCalcs.CalcRegIdentifiers(LlvmTargetName.x86)),
                () => classMap = EmitClasses(lines),
                () => defMap = EmitDefs(lines, out defRelations)
            );

            exec(PllExec,
                () => classFields = DataEmitter.EmitClassFields(RecordFieldParser.parse(lines, classMap)),
                () => defFields = DataEmitter.EmitDefFields(RecordFieldParser.parse(lines, defMap))
            );

            Emit(DataProvider.Entities(defRelations, defFields));
        }

        LineMap<string> EmitClasses(Index<TextLine> src)
        {
            var relations = DataCalcs.CalcClassRelations(src);
            DataEmitter.EmitClassRelations(relations);
            return LineMaps.EmitLineMap(relations, src, LlvmDatasets.X86Classes);
        }

        LineMap<string> EmitDefs(Index<TextLine> src, out Index<LineRelations> defs)
        {
            defs = DataCalcs.CalcDefRelations(src);
            DataEmitter.EmitDefRelations(defs);
            return LineMaps.EmitLineMap(defs, src, LlvmDatasets.X86Defs);
        }

        void Emit(Index<LlvmEntity> src)
        {
            var asmids = DataCalcs.CalcAsmIdentifiers(LlvmTargetName.x86);
            var instructions = DataProvider.Instructions(src);
            var variations = sys.empty<LlvmAsmVariation>();
            exec(PllExec,
                () => DataEmitter.Emit(asmids),
                () => DataEmitter.Emit(DataProvider.InstDefs(asmids, src)),
                () => variations = DataCalcs.CalcAsmVariations(asmids, instructions),
                () => DataEmitter.EmitChildRelations(src),
                () => DataEmitter.Emit(DataProvider.InstPatterns(asmids, src)),
                () => DataEmitter.Emit(DataProvider.AsmOpCodes(asmids, DataProvider.AsmOpCodeMap(instructions))),
                () => DataEmitter.EmitLists(src)
            );

            exec(PllExec,
                () => DataEmitter.Emit(DataCalcs.CalcAsmMnemonics(variations)),
                () => DataEmitter.Emit(variations)
            );
        }

        public Index<ToolHelpDoc> ImportToolHelp()
        {
            var imports = LlvmPaths.ToolImports();
            var docs = DataProvider.CalcHelpDocs();
            var count = docs.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var doc = ref docs[i];
                var content = doc.Content;
                var dst = imports.Path(FS.file(doc.Tool.Format(),FS.Help));
                var emitting = EmittingFile(dst);
                using var writer = dst.Writer();
                writer.Write(content);
                EmittedFile(emitting, content.Length);
            }
            return docs;
        }
   }
}