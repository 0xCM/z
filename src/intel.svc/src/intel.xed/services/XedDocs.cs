//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public partial class XedDocs : WfSvc<XedDocs>
{
    XedRuntime Xed => Wf.XedRuntime();

    public void Emit()
    {
        exec(PllExec,
            () => EmitPatternDocs(),
            () => EmitRuleDocs()
        );
    }

    void EmitPatternDocs()
    {
        EmitDetails();
        EmitSummary();
    }

    void EmitSummary()
    {
        var src = Xed.Views.Patterns;
        var dst = XedPaths.DocTarget("instructions", FileKind.Md);
        var inst = new XedInstDoc(src.Map(x => new InstDocPart(x)));
        Channel.FileEmit(inst.Format(), inst.Parts.Count, dst, TextEncodingKind.Asci);
    }

    void EmitDetails()
    {
        var src = Xed.Views.Patterns;
        var dst = XedPaths.DocTarget("instructions.detail", FileKind.Txt);
        var formatter = XedInstPages.create();
        var emitting = Channel.EmittingFile(dst);
        using var writer = dst.AsciWriter();
        for(var j=0; j<src.Count; j++)
            writer.Write(formatter.Format(src[j]));
        Channel.EmittedFile(emitting, src.Count);
    }

    void EmitRuleDocs()
        => Channel.FileEmit(XedRuleDocRender.create(Xed.Views.CellTables).Format(), 1, XedPaths.DocTarget("rules", FileKind.Md), TextEncodingKind.Asci);
}
