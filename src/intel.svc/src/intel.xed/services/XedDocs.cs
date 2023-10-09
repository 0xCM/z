//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedModels;
using static XedRules;

public partial class XedDocs : WfSvc<XedDocs>
{
    public void EmitPatternDocs(ReadOnlySeq<InstPattern> src)
    {
        EmitDetails(src);
        EmitSummary(src);
    }

    void EmitSummary(ReadOnlySeq<InstPattern> src)
    {
        var dst = XedPaths.DocTarget("instructions", FileKind.Md);
        var inst = new XedInstDoc(src.Map(x => new InstDocPart(x)));
        Channel.FileEmit(inst.Format(), inst.Parts.Count, dst, TextEncodingKind.Asci);
    }

    void EmitDetails(ReadOnlySeq<InstPattern> src)
    {
        var dst = XedPaths.DocTarget("instructions.detail", FileKind.Txt);
        var formatter = XedInstPages.create();
        var emitting = Channel.EmittingFile(dst);
        using var writer = dst.AsciWriter();
        for(var j=0; j<src.Count; j++)
            writer.Write(formatter.Format(src[j]));
        Channel.EmittedFile(emitting, src.Count);
    }

    public void EmitRuleDocs(CellTables src)
        => Channel.FileEmit(XedRuleDocRender.create(src).Format(), 1, XedPaths.DocTarget("rules", FileKind.Md), TextEncodingKind.Asci);
}
