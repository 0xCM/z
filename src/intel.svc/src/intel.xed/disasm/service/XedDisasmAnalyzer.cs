//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static XedRules;
using static XedModels;

public sealed class XedDisasmAnalyzer : XedDisasmTarget<XedDisasmAnalyzer>
{
    const string PaddedSlots = "{0,-24} | {1}";

    readonly ITextEmitter Output;

    protected override void Initialized()
    {
        Running += OnBegin;
        Ran += OnEnd;
        OpStateComputed += Handle;
        ComputingInst += OnBegin;
        ComputedInst += OnEnd;
        FieldsComputed += Handle;
        OpDetailComputed += Handle;
    }

    public XedDisasmAnalyzer()
    {
        Output = text.buffer();
    }

    void OnBegin(uint seq, in Instruction src)
    {
        Output.AppendLine(RP.PageBreak100);
        Output.AppendLineFormat(PaddedSlots, "Seq", seq);
        Output.AppendLineFormat(PaddedSlots, nameof(src.Id), src.Id);
        Output.AppendLineFormat(PaddedSlots, nameof(src.Asm), src.Asm);
    }

    void OnEnd(uint seq, in Instruction src)
    {
        Output.AppendLine();
    }

    void Handle(uint seq, in Fields src)
    {
        var kinds = src.MemberKinds();
        for(var i=0; i<kinds.Length; i++)
            Handle(src[skip(kinds,i)]);
    }

    void Handle(Field src)
    {
        Output.AppendLineFormat(PaddedSlots, src.Kind, Render[src.Kind](src));
    }

    void Handle(FieldKind kind, in XedOperandState src)
    {

    }

    void Handle(uint seq, in OpDetails src)
    {
        Output.AppendLine("Operands");
        XedDisasmRender.render(src, Output);
    }

    void Handle(uint seq, in XedOperandState state, ReadOnlySpan<FieldKind> fields)
    {
        for(var i=0; i<fields.Length; i++)
            Handle(skip(fields,i), state);
    }

    void OnBegin(FilePath src)
    {
        Output.Clear();
    }

    FileName TargetFile()
        => FS.file(string.Format("{0}.{1}", text.left(CurrentFile.FileName.Format(), Chars.Dot), "xed.disasm.flow"), FS.Txt);

    FilePath TargetPath()
        => FolderPath.Empty + FS.folder("xed.disasm") + TargetFile();

    void OnEnd(XedDisasmToken src)
        => FileEmit(Output.Emit(), 0, TargetPath());
}
