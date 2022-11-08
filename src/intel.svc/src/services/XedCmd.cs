//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedDisasm;
    using static XedRules;

    public partial class XedCmd : WfAppCmd<XedCmd>
    {
        //static XedRuntime Xed;

        AsmObjects AsmObjects => Wf.AsmObjects();

        //XedDisasmSvc XedDisasm => Wf.XedDisasmSvc();

        XedPaths XedPaths => Xed.Paths;

        XedDb XedDb => Xed.XedDb;

        IntelSdm Sdm => Wf.IntelSdm();


        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        XedRuntime Xed => GlobalServices.Instance.Injected<XedRuntime>();

        //XedPaths XedPaths => Wf.XedPaths();

        [CmdOp("project/xed/etl")]
        void XedCollect()
            => Xed.Disasm.Collect(ProjectContext());

        [CmdOp("xed/start")]
        void StartRuntime()
        {
            if(!Xed.Running)
                Xed.Start();
        }

        [CmdOp("xed/emit/types")]
        Outcome CheckXedDb(CmdArgs args)
        {
            var rows = Xed.Views.TypeTables.SelectMany(x => x.Rows).Sort().Resequence();
            TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
            return true;
        }

        [CmdOp("xed/emit/sigs")]
        void EmitInstSig()
            => Xed.Rules.EmitInstSigs(Xed.Views.Patterns);

        [CmdOp("xed/import")]
        void RunImport()
            => Xed.Import.Run();

        [CmdOp("xed/import/check")]
        void CheckXedImports()
        {
            var blocks = Xed.Views.InstImports;
            ref readonly var lines = ref blocks.BlockLines;
            var forms = lines.Keys.Index().Sort();
            ref readonly var source = ref blocks.DataSource;
        }

        [CmdOp("xed/disasm/flow")]
        void RunDisasmFlow()
        {
            var context = ProjectContext();
            var flow = XedDisasm.flow(context);
            var targets = sys.bag<ITarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = Wf.DisasmAnalyser();
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);
        }

        [CmdOp("xed/emit/seq")]
        void EmitSeq()
            => Xed.Rules.EmitSeq();

        [CmdOp("xed/emit/patterns")]
        void EmitPatterns()
            => Xed.Rules.EmitPatternData(Xed.Views.Patterns);

        [CmdOp("xed/emit/expr")]
        void EmitRuleExpr()
            => Xed.Rules.Emit(Xed.Views.RuleExpr);

        [CmdOp("xed/db/emit")]
        void DbEmit()
            => Xed.XedDb.EmitArtifacts();

        [CmdOp("xed/emit/rules/tables")]
        void EmitRuleTables()
            => Xed.Rules.EmitRuleData(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/pages")]
        void EmitTableDefs()
            => Xed.Rules.EmitRulePages(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/specs")]
        void EmitTableCells()
            => Xed.Rules.EmitTableSpecs(Xed.Views.RuleTables);

        [CmdOp("xed/emit/docs")]
        void EmitDocs()
            => Xed.Docs.Emit();

        [CmdOp("xed/emit/attribs")]
        void EmitInstAttribs()
            => Xed.Rules.EmitInstAttribs(Xed.Views.Patterns);

        [CmdOp("xed/emit/groups")]
        void EmitInstGroups()
            => Xed.Rules.EmitInstGroups(Xed.Rules.CalcInstGroups(Xed.Views.Patterns));

        [CmdOp("xed/etl")]
        void EmitXedCat()
        {
            Xed.Start();
            Xed.RunEtl();
        }

        void GenRuleNames(FilePath path)
        {
            var assets = AsmCaseAssets.create();
            var header = assets.XedFileHeader().Utf8();

            var rules = Xed.Views.RuleTables;
            ref readonly var specs = ref rules.Specs();
            var rulenames = specs.Keys.Select(x => x.TableName.ToString()).ToHashSet();
            var names = rulenames.Index().Sort();

            var dst = text.emitter();
            dst.WriteLine(header);
            dst.WriteLine("namespace Z0");
            dst.WriteLine("{");
            var indent = 4u;

            dst.IndentLine(indent,"partial class XedRules");
            dst.IndentLine(indent,"{");
            indent+=4;
            dst.IndentLine(indent,"public enum RuleName : ushort");
            dst.IndentLine(indent,"{");
            var k=0u;
            indent += 4;
            dst.IndentLineFormat(indent, "{0} = {1},", "None", k++);
            dst.WriteLine();
            for(var i=0; i<names.Count; i++, k++)
            {
                ref readonly var name = ref names[i];
                dst.IndentLineFormat(indent, "{0} = {1},", name, k);
                if(i != names.Count-1)
                    dst.WriteLine();
            }
            indent -= 4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.Indent(indent,"}");
            using var writer = path.Utf8Emitter();
            writer.Write(dst.Emit());
        }

        [CmdOp("xed/gen/rulenames")]
        void GenRuleNames()
        {
            var path = FS.path(@"J:\z0\apps\asm.core\intel.xed\rules\models\RuleName.cs");
            GenRuleNames(path);
        }
    }
}