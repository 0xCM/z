//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    public sealed class AsmStatementProducer : WfSvc<AsmStatementProducer>
    {
        // public uint Produce(ReadOnlySpan<AsmMemberRoutine> src, FilePath dst)
        // {
        //     var count = src.Length;
        //     var flow = EmittingFile(dst);
        //     var buffer = text.buffer();
        //     var counter = 0u;
        //     using var writer = dst.Writer();
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var routine = ref skip(src,i);
        //         writer.WriteLine(PageBreak);
        //         FormatHeader(routine, buffer);
        //         writer.Write(buffer.Emit());

        //         counter += produce(routine, buffer);
        //         writer.Write(buffer.Emit());
        //     }
        //     EmittedFile(flow, counter);
        //     return counter;
        // }

        // [Op]
        // public static Index<AsmHostRoutines> run(IWfRuntime wf, Index<PartId> parts, CaptureWorkflowOptions options)
        //     => wf.CaptureRunner().Capture(parts, options);

        // [Op]
        // public static Index<AsmHostRoutines> run(IWfRuntime wf, Index<ApiHostUri> parts, CaptureWorkflowOptions options)
        //     => wf.CaptureRunner().Capture(parts, options);

        // public uint Produce(ApiHostUri[] hosts, FS.FolderPath dst)
        // {
        //     var options = CaptureWorkflowOptions.None;
        //     var routines = run(Wf, hosts, options).View;
        //     var count = routines.Length;
        //     var counter = 0u;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var hr = ref skip(routines,i);
        //         counter += Produce(skip(routines,i).View, dst + FS.file(hr.Host, FS.Asm));
        //     }
        //     return counter;
        // }

        // public void Produce(FilePath dst, params PartId[] parts)
        //     => Produce(run(Wf, parts, CaptureWorkflowOptions.EmitImm), dst);

        // uint Produce(Index<AsmHostRoutines> src, FilePath dst)
        //     => Produce(src.SelectMany(x => x.Storage), dst);

        // static void FormatHeader(in AsmMemberRoutine src, ITextBuffer dst)
        // {
        //     dst.AppendLine(asm.comment(src.Member.OpUri.Format()));
        //     dst.AppendLine(asm.comment(format(src.Base, src.CodeBlock.Code)));
        //     dst.AppendLine(new AsmOffsetLabel(16, src.Base));
        // }

        // static uint produce(in AsmMemberRoutine src, ITextBuffer dst)
        // {
        //     var instructions = src.Instructions.View;
        //     var count = instructions.Length;
        //     var counter = 0u;
        //     for(var i=0u; i<count; i++)
        //     {
        //         produce(skip(instructions,i), dst);
        //         dst.AppendLine();
        //         counter++;
        //     }
        //     return counter;
        // }

        // static AsmSigInfo sigxpr(in ApiInstruction src)
        // {
        //     if(AsmSigInfo.parse(src.Instruction.OpCode.InstructionString, out var info))
        //         return info;
        //     else
        //         return AsmSigInfo.Empty;
        // }

        // static AsmFormInfo formxpr(in ApiInstruction src)
        //     => (src.OpCode, sigxpr(src));

        // static AsmThumbprint thumbprint(in ApiInstruction src)
        //     => AsmThumbprint.define(src.Statment, formxpr(src), asm.asmhex(src.EncodedData));

        // static string format(MemoryAddress @base, CodeBlock code)
        //     => string.Format("{0}[{1}] => {2}", @base.Format(), code.Length, code.Format());

        // static string describe(in ApiInstruction src)
        //     => string.Format("{0} {1}", (Address16)src.Offset, thumbprint(src));

        // static AsmExpr statement(ApiInstruction src)
        //     => src.Statment.Replace(" ptr", EmptyString);

        // static void produce(in ApiInstruction src, ITextBuffer dst)
        //     => dst.Append(string.Format("{0} {1}", string.Format("{0,-46}", statement(src)), asm.comment(describe(src))));

        // const string PageBreak = "----------------------------------------------------------------------------------------------------------------------------------------------------------------";
    }
}