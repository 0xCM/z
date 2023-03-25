//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static AsmRegTokens;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/check/sigs")]
        Outcome CheckSigs(CmdArgs args)
        {
            using var dispenser = CompositeBuffers.create();
            var specs = new NativeOpDef[3];
            seek(specs,0) = NativeTypes.ptr("op0", NativeTypes.u8());
            seek(specs,1) = NativeTypes.@const("op1", NativeTypes.i16());
            seek(specs,2) = NativeTypes.@out("op2", NativeTypes.u32());
            var sig = dispenser.Sig("funcs","f2", NativeTypes.i32(), specs);
            Write(sig.Format(SigFormatStyle.C));
            sig = dispenser.Sig("funcs","f1", NativeTypes.i32(), specs);

            ref readonly var ret = ref sig.Return;
            ref readonly var op0 = ref sig[0];
            ref readonly var op1 = ref sig[1];
            ref readonly var op2 = ref sig[2];
            ref readonly var name = ref sig.Name;
            ref readonly var scope = ref sig.Scope;

            var x0 = string.Format("{0}:{1}", op0.Name, op0.Type);
            var x1 = string.Format("{0}:{1}", op1.Name, op1.Type);
            var x2 = string.Format("{0}:{1}", op2.Name, op2.Type);
            Write(sig.Format(SigFormatStyle.C));

            return true;
        }

        [CmdOp("asm/check/luts")]
        void RunAsmChecks()
        {
            vlut(w128);
            vlut(w256);
        }

        [CmdOp("gen/hex-kind")]
        void GenHex8()
        {
            var dst = text.emitter();
            var indent = 4u;
            dst.IndentLineFormat(indent, "[SymSource(\"{0}\")]", "asm.opcodes");
            dst.IndentLineFormat(indent, "public enum {0} : byte", "Hex8Kind");
            dst.IndentLine(indent,"{");
            indent+=4;
            for(var i=0u; i<256; i++)
            {
                dst.IndentLineFormat(indent, "[Symbol(\"{0:X2}\")]", i);
                dst.IndentLineFormat(indent, "x{0:X2},", i);
                dst.AppendLine();
            }
            indent-=4;
            dst.IndentLine(indent,"}");
            Write(dst.Emit());
        }

        [CmdOp("asm/check/ccv")]
        void CheckCcv()
        {
            var r0 = Win64Ccv.reg(w64,0);
            Require.invariant(r0 == Gp64Reg.rcx);
            var r1 = Win64Ccv.reg(w64,1);
            Require.invariant(r1 == Gp64Reg.rdx);
            var r2 = Win64Ccv.reg(w64,2);
            Require.invariant(r2 == Gp64Reg.r8);
            var r3 = Win64Ccv.reg(w64,3);
            Require.invariant(r3 == Gp64Reg.r9);
            Write(string.Format("{0} | {1} | {2} | {3}", r0, r1, r2, r3));
        }         

        void vlut(W128 w)
        {
            // lut := <0,1,2,...,15> ; defines 16 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,79>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        void vlut(W256 w)
        {
            // lut := <0,1,2,...,31>  ; defines 32 indicies in a table with up to 255 entries
            var lut = VLut.init(gcpu.vinc<byte>(w));
            // items := <64,65,...,95>
            var items = gcpu.vinc<byte>(w, 64);
            var selected = VLut.select(lut,items);
            var expect = items;
            VClaim.veq(expect, selected);
        }

        [CmdOp("asm/check/hexlines")]
        void CheckHexLines()
        {
            var lines = Lines.lines(DataSource);
            var count = lines.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                AsmHexApi.parse(line, out var code);
                Write(code.Format());
            }
        }

        const string DataSource = @"66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 24 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c4 e2 7d 25 01
c3
66 2e 0f 1f 84 00 00 00 00 00
c5 f8 77
c5 f8 99 c8";

    }
}