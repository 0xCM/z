//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static sys;

    using static Asm.AsmOcTokens;

    class AsmCmd : WfAppCmd<AsmCmd>
    {
        IDbArchive Db => EnvDb.Scoped("asm.db");

        AsmRegSets Regs => Service(AsmRegSets.create);

        PolyBits PolyBits => Wf.PolyBits();

        
        void EmitPatterns()
        {
            PolyBits.EmitPatterns(typeof(AsmBitPatterns), Db.Scoped("patterns"));
        }

        void EmitTokens()
        {
            var groups = AsmTokens.groups();
            var dst = Db.Scoped("tokens");
            foreach(var g in groups)
                g.ExportTokens(Channel, dst);

            var jcc = Tokens.tokenize(typeof(Jcc32Code), typeof(Jcc8Code), typeof(Jcc32AltCode), typeof(Jcc8AltCode));
            var path = dst.Path("jcc.codes",FS.ext("ts"));
            using var writer = path.Writer();
            var indent = 0u;
            Emit(ref indent, jcc, writer);
        }

        void Emit(ref uint indent, TokenSeq src, StreamWriter dst)
        {
            var groups = src.Groups();
            foreach(var (g, tokens) in groups)
            {
                dst.AppendLine();
                dst.IndentLineFormat(indent, "export type {0} =", g);
                indent+=4;
                for(var i=0; i<tokens.Count; i++)
                {
                    ref readonly var token = ref tokens[i];
                    if(nonempty(token.Info))
                        dst.IndentLineFormat(indent, "// {0}", token.Info);


                    dst.IndentLine(indent, $"| {text.dquote(token.Expr)}");
                }
                indent-=4;
            }
        }


        [CmdOp("asm/emit/docs")]
        void EmitDocs()
        {
            exec(true, 
                EmitRexDocs,
                EmitTokens,
                EmitPatterns,
                EmitSibDocs,
                EmitModRmDocs,
                EmitConditionDocs,
                EmitRexBDocs,
                EmitRegDocs
                );
        }

        void EmitRegDocs()
        {
            var dst = Db.Scoped("docs").Path("asm.regs.strings", FileKind.Cs);
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
            Channel.EmittedFile(emitting,4);
        }

        void EmitRexDocs()
        {
            var dst = Db.Scoped("docs").Path("rex.bits", FileKind.Csv);
            var emitting = Channel.EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = RexPrefixTable.render(buffer);
            writer.Write(buffer.Emit());
            Channel.EmittedFile(emitting,count);
        }

        void EmitSibDocs()
        {
            var rows = AsmBytes.SibRows().View;
            Channel.TableEmit(rows, Db.Scoped("docs").Path("asm.docs.sib.bits", FileKind.Csv));
            var codes = AsmBytes.SibRegCodes();
            Channel.TableEmit(codes.View, Db.Scoped("docs").Path("asm.docs.sib.regs", FileKind.Csv));
        }

        void EmitModRmDocs()
        {
            var path = Db.Scoped("docs").Path("asm.docs.modrm.bits", FileKind.Csv);
            var flow = Channel.EmittingFile(path);
            using var writer = path.AsciWriter();
            var dst = span<char>(256*128);
            var count = ModRmTable.render(dst);
            var rendered = slice(dst,0,count);
            writer.Write(rendered);
            Channel.EmittedFile(flow, count);
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
            EmitConditionDocs(Conditions.jcc8(), Db.Scoped("docs").Path("jcc8", FileKind.Txt));
            EmitConditionDocs(Conditions.jcc32(), Db.Scoped("docs").Path("jcc32", FileKind.Txt));
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
            Channel.EmittedFile(emitting,counter);
            return counter;
        }
    }
}