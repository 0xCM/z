//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static AsmOcTokens;

    using Asm;

    class AsmDocsCmd : WfAppCmd<AsmDocsCmd>
    {
        AsmRegSets Regs => Service(AsmRegSets.create);

        [CmdOp("asm/emit/docs")]
        public void Emit()
        {
            EmitRexDocs();
            EmitSibDocs();
            EmitModRmDocs();
            EmitConditionDocs();
            EmitRegDocs();
            EmitRexBDocs();
            EmitAsmTokens();
        }

        void EmitAsmTokens()
        {
            TableEmit(AsmTokens.OcTokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens.opcodes", FileKind.Csv), UTF16);
            TableEmit(AsmTokens.SigTokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens.sigs", FileKind.Csv), UTF16);
            TableEmit(AsmTokens.TokenDefs.View, AppDb.ApiTargets().Path("api.asm.tokens", FileKind.Csv), UTF16);
        }

        void EmitRegDocs()
        {
            var dst = AppDb.ApiTargets("asm.docs").Path("asm.regs.strings", FileKind.Cs);
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(Regs.Gp8LoRegs().ToNameArray("Gp8LoRegs"));
            writer.WriteLine(Regs.Gp8HiRegs().ToNameArray("Gp8HiRegs"));
            writer.WriteLine(Regs.Gp8Regs().ToNameArray("Gp8Regs"));
            writer.WriteLine(Regs.Gp16Regs().ToNameArray("Gp16Regs"));
            writer.WriteLine(Regs.Gp32Regs().ToNameArray("Gp32Regs"));
            writer.WriteLine(Regs.Gp64Regs().ToNameArray("Gp64Regs"));
            writer.WriteLine(Regs.XmmRegs().ToNameArray("XmmRegs"));
            writer.WriteLine(Regs.YmmRegs().ToNameArray("YmmRegs"));
            writer.WriteLine(Regs.TmmRegs().ToNameArray("TmmRegs"));
            writer.WriteLine(Regs.ZmmRegs().ToNameArray("ZmmRegs"));
            writer.WriteLine(Regs.MmxRegs().ToNameArray("MmxRegs"));
            writer.WriteLine(Regs.MaskRegs().ToNameArray("MaskRegs"));
            writer.WriteLine(Regs.CrRegs().ToNameArray("CrRegs"));
            writer.WriteLine(Regs.DbRegs().ToNameArray("DbRegs"));
            writer.WriteLine(Regs.FpuRegs().ToNameArray("FpuRegs"));
            EmittedFile(emitting,4);
        }

        void EmitRexDocs()
        {
            var dst = AppDb.ApiTargets("asm.docs").Path("rex.bits", FileKind.Csv);
            var emitting = Channel.EmittingFile(dst);
            var bits = RexPrefix.Range();
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = RexPrefix.table(buffer);
            writer.Write(buffer.Emit());
            EmittedFile(emitting,count);
        }

        void EmitSibDocs()
        {
            var rows = AsmBytes.SibRows().View;
            TableEmit(rows, AppDb.ApiTargets("asm.docs").Path("asm.docs.sib.bits", FileKind.Csv));

            var codes = AsmBytes.SibRegCodes();
            TableEmit(codes.View, AppDb.ApiTargets("asm.docs").Path("asm.docs.sib.regs", FileKind.Csv));
        }

        void EmitModRmDocs()
        {
            var path = AppDb.ApiTargets("asm.docs").Path("asm.docs.modrm.bits", FileKind.Csv);
            var flow = Channel.EmittingFile(path);
            using var writer = path.AsciWriter();
            var dst = span<char>(256*128);
            var count = AsmBytes.ModRmTable(dst);
            var rendered = slice(dst,0,count);
            writer.Write(rendered);
            EmittedFile(flow, count);
        }

        void EmitRexBDocs()
        {
            var tokens = Symbols.index<RexBToken>();
            var g = RexBGenerator.create(Wf);
            var src = g.Generate();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref src[i];
                ref readonly var token = ref tokens[b.Token];
                uint2 value = (byte)token.Kind;
                var reg = AsmRegBits.reg(b.RegSize, b.Hi ? RegClassCode.GP8HI : RegClassCode.GP, b.Reg.Code);
                var fmt = string.Format("{0,-5} | {1,-5} | {2,-5} | {3,-5} | {4}", i, reg.Name, b.Reg.Code, b.Reg, value, token.Expr);
            }
        }

        void EmitConditionDocs()
        {
            EmitConditionDocs(Conditions.jcc8(), AppDb.ApiTargets("asm.docs").Path("jcc8", FileKind.Txt));
            EmitConditionDocs(Conditions.jcc32(), AppDb.ApiTargets("asm.docs").Path("jcc32", FileKind.Txt));
        }

        uint EmitConditionDocs<T>(ReadOnlySpan<T> src, FilePath dst)
            where T : IConditional
        {
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref skip(src,i);
                writer.WriteLine(info.Format(false));
                counter++;
                if(!info.Identical)
                {
                    writer.WriteLine(info.Format(true));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
            return counter;
        }
    }
}