//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ProjectCmd
    {
        [CmdOp("mc/gen")]
        Outcome GenAsm(CmdArgs args)
        {
            // and              | r/m32, imm32                                                     | 81 /4 id
            const string SigOpCode = "and r32, imm32 | 81 /4 id";
            var buffer = text.buffer();
            var regs = Regs.Gp32Regs();
            var count = regs.Count;
            var pattern = "{0} {1}, 0x{2:x}";
            var inst = "and";
            var imm = 256u;
            buffer.AppendLine(AsmDirectives.define("intel_syntax", "noprefix").Format());
            buffer.AppendLine();
            buffer.AppendLine(asm.comment(SigOpCode));
            buffer.AppendLine(new AsmBlockLabel("and_r32_imm32").Format());
            var indent = 4u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var r = ref regs[i];
                var asm = string.Format(pattern, inst, r, imm++);
                if(i != count - 1)
                    buffer.IndentLine(indent,asm);
                else
                    buffer.Indent(indent,asm);
            }

            var dst = Project().SrcDir("asm") + FS.file(inst, FS.Asm);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(buffer.Emit());
            EmittedFile(emitting,count);

            return true;
        }
    }
}