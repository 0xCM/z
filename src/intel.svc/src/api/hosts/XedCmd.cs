//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;

using static sys;
using static XedModels;

public partial class XedCmd : WfAppCmd<XedCmd>
{
    CsLang CsLang => Channel.Channeled<CsLang>();

    XedRuntime XedRuntime => Wf.XedRuntime();

    XedPaths XedPaths => XedRuntime.Paths;

    XedDb XedDb => XedRuntime.XedDb;

    IntelSdm Sdm => Wf.IntelSdm();

    XedFlows DataFlow => Wf.XedFlows();

    public IDbArchive LlvmModels(string scope)
        => AppDb.Dev($"llvm.models/{scope}");

    [CmdOp("xed/kit")]
    void XedHeaders()
    {
        var kit = Xed.kit();
        piter(kit.Headers(), header => Channel.Row(header.ToUri()));
        // var src = XedProject.KitHeaders();
        // iter(src, file => Channel.Row(file));
    }
    

    [CmdOp("asm/gen/vex")]
    Outcome GenTokenSpecs(CmdArgs args)
    {
        var result = Outcome.Success;
        var src = Symbols.concat(Symbols.index<AsmOpCodeTokens.VexToken>());
        var name = "VexTokens";
        var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
        using var writer = dst.Writer();
        writer.WriteLine(string.Format("public readonly struct {0}", name));
        writer.WriteLine("{");
        CsLang.StringLits().Emit("Data", src, writer);
        writer.WriteLine("}");
        return result;
    }


    ref readonly Index<InstPattern> Patterns
        => ref XedRuntime.Views.Patterns;

    [CmdOp("xed/emit/types")]
    Outcome CheckXedDb(CmdArgs args)
    {
        var rows = XedRuntime.Views.TypeTables.SelectMany(x => x.Rows).Sort().Resequence();
        Channel.TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
        return true;
    }

    [CmdOp("xed/inst/parse")]
    void ParseInstructions()
    {
        var src = XedPaths.DocSource(XedDocKind.EncInstDef);
        if(!src.Exists)
        {
            Channel.Error(FS.missing(src));
        }
        else
        {
            var running = Channel.Running($"Parsing {src}");
            var defs = XedInstDefParser.parse(src);
            Channel.Ran(running);
        }
    }

    [CmdOp("xed/emit/sigs")]
    void EmitInstSig()
        => XedRuntime.Rules.EmitInstSigs(XedRuntime.Views.Patterns);

    [CmdOp("xed/disasm/flow")]
    void RunDisasmFlow(CmdArgs args)
    {
        var src = FS.archive(args[0]);
        var flow = XedDisasm.flow();
        var targets = sys.bag<IXedDisasmTarget>();
        var sources = XedDisasm.sources(src);
        iter(XedDisasm.sources(src), src => {
            var dst = Wf.DisasmAnalyser();
            flow.Run(src,dst);
            targets.Add(dst);
        }, true);
    }

    [CmdOp("xed/emit/seq")]
    void EmitSeq()
        => XedRuntime.Rules.EmitSeq();

    [CmdOp("xed/emit/patterns")]
    void EmitPatterns()
        => XedRuntime.Rules.EmitPatternData(XedRuntime.Views.Patterns);

    [CmdOp("xed/emit/expr")]
    void EmitRuleExpr()
        => XedRuntime.Rules.Emit(XedRuntime.Views.RuleExpr);

    [CmdOp("xed/db/emit")]
    void DbEmit()
        => XedRuntime.XedDb.EmitArtifacts();

    [CmdOp("xed/emit/rules/pages")]
    void EmitTableDefs()
        => XedRuntime.Rules.EmitRulePages(XedRuntime.Views.RuleTables);

    [CmdOp("xed/emit/rules/specs")]
    void EmitTableCells()
        => XedRuntime.Rules.EmitTableSpecs(XedRuntime.Views.RuleTables);

    [CmdOp("xed/emit/docs")]
    void EmitDocs()
        => XedRuntime.Docs.Emit();

    [CmdOp("xed/emit/attribs")]
    void EmitInstAttribs()
        => XedRuntime.Rules.EmitInstAttribs(XedRuntime.Views.Patterns);

    [CmdOp("xed/emit/groups")]
    void EmitInstGroups()
        => XedRuntime.Rules.EmitInstGroups(XedRuntime.Rules.CalcInstGroups(XedRuntime.Views.Patterns));

    void GenRuleNames(FilePath path)
    {
        var assets = IntrinsicAssets.create();
        var header = assets.XedFileHeader().Utf8();

        var rules = XedRuntime.Views.RuleTables;
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
