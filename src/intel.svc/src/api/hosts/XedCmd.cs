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
}
