//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    public partial class XedDocs : WfSvc<XedDocs>
    {
        XedRuntime Xed;

        public XedDocs With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        XedPaths XedPaths => Xed.Paths;

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
            var inst = new InstDoc(src.Map(x => new InstDocPart(x)));
            FileEmit(inst.Format(), inst.Parts.Count, dst, TextEncodingKind.Asci);
        }

        void EmitDetails()
        {
            var src = Xed.Views.Patterns;
            var dst = XedPaths.DocTarget("instructions.detail", FileKind.Txt);
            var formatter = InstPageFormatter.create();
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var j=0; j<src.Count; j++)
                writer.Write(formatter.Format(src[j]));
            EmittedFile(emitting, src.Count);
        }

        void EmitRuleDocs()
            => FileEmit(RuleDocFormatter.create(Xed.Views.CellTables).Format(), 1, XedPaths.DocTarget("rules", FileKind.Md), TextEncodingKind.Asci);
    }
}