//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static AsmPrefixCodes;
    using static sys;

    using gp32 = AsmRegTokens.Gp32Reg;

    public class IntelHexIO : WfSvc<IntelHexIO>
    {
        public static bool parse(ReadOnlySpan<char> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }

        public static bool parse(ReadOnlySpan<AsciCode> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }

        public static bool parse(ReadOnlySpan<AsciSymbol> src, out Seq<HexDigitValue> dst)
        {
            dst = sys.alloc<HexDigitValue>(src.Length);
            return Hex.digits(src, dst.Edit);
        }

    }

    [ApiHost]
    public partial class AsmCheckCmd : CheckCmd<AsmCheckCmd>
    {

        [CmdOp("asm/check/flags")]
        Outcome CheckAsmFlags(CmdArgs args)
        {
            var result = Outcome.Success;
            var flags = new StatusFlags();
            flags.OF(true);
            flags.SF(true);
            Write(flags.Format());
            return result;
        }

        [CmdOp("asm/check/directives")]
        Outcome CheckDirectives(CmdArgs args)
        {
            var data = array<byte>(1,2,3,4,5,6);
            var actual = NativeShape.calc(data);
            var expect = NativeShape.define(n4:1, n2:1);
            Require.equal(actual,expect);

            var a = AsmDirectives.section(CoffSectionKind.ReadOnlyData, CoffSectionFlags.d | CoffSectionFlags.r, CoffComDatKind.Discard, "block, vpmuldq_1, sdm/opcode, vpmuldq");
            var x = ".section .rdata, \"dr\", discard, \"block, vpmuldq_1, sdm/opcode, vpmuldq\"";
            Require.equal(a.Format(),x);
            return true;
        }

        [CmdOp("asm/check/vex")]
        Outcome Vex(CmdArgs args)
        {
            var segments = VexPrefixC4.segments();

            var vp0 = VexPrefixC4.define(byte.MaxValue, byte.MaxValue);
            Write(vp0.FormatSemantic());
            segments.Fill(vp0);
            Write(segments.ToBitstring());

            var vp1 = VexPrefixC4.init(VexRXB.L0_V0F38, VexM.x0F3A, bit.On, 0b1111, VexLengthCode.L1, VexOpCodeExtension.F3);
            Write(vp1.FormatSemantic());
            segments.Fill(vp1);
            Write(segments.ToBitstring());

            var vp2 = VexPrefixC4.define(0xe3, 0x69);
            Write(vp2.FormatSemantic());
            segments.Fill(vp2);
            Write(segments.ToBitstring());

            return true;
        }

        [CmdOp("asm/check/specs")]
        void CheckAsmSpecs()
        {
            const string Oc0 = "81 /4 id";
            const string Oc1 = "REX.W + 05 id";

            var asm0 = AsmSpecs.and(gp32.edx, 0xC1C1);
            Write($"{asm0}");

            var opcode = SdmOpCode.Empty;
            var result = SdmOpCodes.parse(Oc0, out opcode);
            Write($"{Oc0} -> {opcode}");
        }

        [CmdOp("asm/check/jmp")]
        void CheckJumps()
        {
            CheckJmp32(n0);
            CheckJmp32(n1);
            CheckJmp32(n2);
        }

        Outcome CheckJcc()
        {
            var @case = AsmCaseAssets.create().Branches();
            Utf8.decode(@case.ResBytes, out var doc);

            using var dispenser = Alloc.asm();
            var parser = DecodedAsmParser.create(dispenser);
            var result = parser.ParseBlocks(doc);
            return result;
        }

        void CheckJmp32(N1 n)
        {
            var w = w8;
            var result = Outcome.Success;
            var cases = AsmCases.jmp32();
            var count = cases.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expect = ref cases[i];
                var disp = AsmRel.disp32(expect.Encoding.Bytes);
                Require.equal(disp, expect.Disp);
                var source = expect.Source;
                Rip rip = (source, JmpRel32.InstSize);
                MemoryAddress target = (MemoryAddress)((long)rip + (int)disp);
                Require.equal(AsmRel.disp32(rip, target), disp);
                Require.equal(AsmRel.target(rip, expect.Encoding.Bytes), target);
                var encoding = JmpRel32.encode(rip, target);
                Require.equal(encoding, expect.Encoding);
                var relTarget = (int)disp + (int)JmpRel32.InstSize;
                @string statement = string.Format("jmp near ptr {0:x}h", relTarget);
                Require.equal(statement, expect.Statment);
                Write(statement);
            }
        }

        void CheckJmp32(N0 n)
        {
            var result = Outcome.Success;
            var @base = (MemoryAddress)0x7ffd4512bf30;
            var @return = @base + (MemoryAddress)0x10b7;
            var sz = (byte)5;

            // 005ah jmp near ptr 10b7h                            ; JMP rel32                        | E9 cd                            | 5   | e9 58 10 00 00
            var label0 = 0x005a;
            var ip0 = @base + label0;

            var dx0 = AsmRel.disp32((ip0, sz), @return);

            var code0 = JmpRel32.encode((ip0,sz), @return);
            var code1 = ApiNative.asmhex("e9 58 10 00 00");

            if(!code0.Equals(code1))
                Error(string.Format("{0} != {1}", code1, code0));

            var label1 = 0x0065;
            var ip1 = @base + label1;
            var dx1 = AsmRel.disp32((ip1,sz), @return);
            var actual1 = JmpRel32.encode((ip1,sz), @return);
            var expect1 = ApiNative.asmhex("e9 4d 10 00 00");
            if(!actual1.Equals(expect1))
                Error(string.Format("{0} != {1}", expect1, actual1));

            var label2 = 0x0070;
            var ip2 = @base + label2;
            var dx2 = AsmRel.disp32((ip2,sz), @return);
            var actual2 = JmpRel32.encode((ip2,sz), @return);
            var expect2 = ApiNative.asmhex("e9 42 10 00 00");
            if(!actual2.Equals(expect2))
                Error(string.Format("{0} != {1}", expect2, actual2));

            var label3 = 0x007b;
            var ip3 = @base + label3;
            var dx3 = AsmRel.disp32((ip3,sz), @return);
            var actual3 = JmpRel32.encode((ip3,sz), @return);
            var expect3 = ApiNative.asmhex("e9 37 10 00 00");
            if(!actual3.Equals(expect3))
                Error(string.Format("{0} != {1}", expect3, actual3));
        }

        void CheckJmp32(N2 n)
        {
            const string Asm = "call 7fff92427890h";
            const string Encoding = "e8 25 e4 b2 5f";
            const byte InstSize = CallRel32.InstSize;
            const ulong Base = 0x7fff328f9430ul;
            const ushort Offset = 0x36;
            const ulong Target = 0x7fff92427890ul;
            const ulong Source = Base + Offset;

            var rip = AsmRel.rip(Source,InstSize);

            Hex.hexbytes(Encoding, out var enc1);
            var dx = AsmRel.disp32(enc1);

            var enc2 = CallRel32.encode(rip, Target);
            if(enc1 != enc2)
                Error(string.Format("Encoding mismatch '{0}' != '{1}'", enc1, enc2));

            var box = new RipBox(Base, uint.MaxValue);
            if(!box.IP(Source))
                Error("Ip out of range");

            box.Advance(InstSize, dx, out var target1);

            if(target1 != Target)
                Error("Computed target did not match expected target");

            var target2 = AsmRel.target(rip, enc1);
            if(target2 != Target)
                Error("Computed target did not match expected target");
        }

        [CmdOp("asm/check/hex")]
        unsafe Outcome CheckHex(CmdArgs args)
        {
            const string Data = "38D10F9FC00FB6C0C338D10F97C00FB6C0C36639D10F9FC00FB6C0C36639D10F97C00FB6C0C339D10F9FC00FB6C0C339D10F97C0C34839D10F9FC00FB6C0C34839D10F97C00FB6C0C3";
            var result = Outcome.Success;
            var input = span(Data);
            var count = Data.Length;
            var dst = alloc<HexDigitValue>(count);
            result = Hex.map(Data,dst);
            if(result.Fail)
                return result;

            for(var i=0; i<count; i++)
            {
                if(Hex.upper(skip(dst,i)) != skip(input,i))
                    return (false, "Not Equal");
            }

            var buffer = alloc<byte>(count/2);
            var size = Digital.pack(dst,buffer);
            var output = buffer.FormatHex(HexOptionData.CompactHexOptions);
            Write(Require.equal(Data,output));
            return result;
        }

        [CmdOp("asm/check/mem")]
        public void CheckAsmMem()
        {
            var result = true;
            var results = AsmCases.check(AsmCases.MemOpCases());
            for(var i=0; i<results.Count; i++)
            {
                ref readonly var r = ref results[i];
                Write(r.Format());
            }
        }

        [CmdOp("asm/check/widths")]
        Outcome TestAsmWidths(CmdArgs args)
        {
            var result = bit.On;
            var pass = bit.Off;
            var test = default(AsmSizeCheck);
            var inputs = Symbols.index<NativeSizeCode>().Kinds;
            var count = inputs.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(inputs,i);
                test.Input = input;
                pass = check(ref test);
                result &= pass;
                Write(test, pass ? FlairKind.Status : FlairKind.Error);
            }

            BitWidth w8 = 8;
            BitWidth w16 = 16;
            BitWidth w32 = 32;
            BitWidth w64 = 64;

            var sz8 = Sized.native(w8);
            var sz16 = Sized.native(w16);
            var sz32 = Sized.native(w32);
            var sz64 = Sized.native(w64);
            Write(sz8);
            Write(sz16);
            Write(sz32);
            Write(sz64);

            return (result, result ? "Pass" : "Fail");
        }

        [CmdOp("asm/check/cases")]
        Outcome EmitAsmCases(CmdArgs args)
        {
            var src = AsmCases.mov();
            TableEmit(src, AppDb.ApiTargets().Table<AsmEncodingCase>());
            return true;
        }

        [CmdOp("asm/check/tokens")]
        void CheckAsmTokens()
        {
            AsmSigs.parse("adc r16, r16", out var sig);
            SdmOpCodes.parse("11 /r", out var oc1);
            SdmOpCodes.parse("13 /r", out var oc2);
            var count = min(oc1.TokenCount, oc2.TokenCount);
            var token = AsmOcToken.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref oc1[i];
                ref readonly var tb = ref oc2[i];
                if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                if(ta != tb)
                {
                    token = tb;
                    break;
                }
            }

            if(SdmOpCodes.diff(oc1, oc2, out token))
                Write(token.Format());

            var sigs = AsmSigTokens.create();
            var src = sigs;
            var types = src.TokenTypes;
            for(var i=0; i<types.Length; i++)
            {
                var sigTokens = src.TokensByType(skip(types,i));
                for(var j=0;j<sigTokens.Count; j++)
                {
                    Write(sigTokens[j].Format());
                }
            }
        }

        [CmdOp("asm/check/res")]
        void CheckStringRes()
        {
            var resources = TextAssets.strings(typeof(AsciText)).View;
            iter(resources, r => Write(r.Format()));
        }

        [CmdOp("asm/check/calls")]
        void CheckAsmCalls()
        {
            void Check1()
            {
                const ulong Base = 0x7ffc56862280;
                const ushort Offset = 0x25;
                const uint Disp = 0xfc632176;
                const ulong IP = Base + Offset;
                var rip = AsmRel.rip(IP, 5);
                var call = AsmRel.call(rip, (Disp32)Disp);
                Write(call.Format());
            }


            void Check3()
            {
                const string Asm = "call 7fff92427890h";
                const string Encoding = "e8 25 e4 b2 5f";
                const byte InstSize = CallRel32.InstSize;
                const long Base = 0x7fff328f9430;
                const ushort Offset = 0x36;
                const long Source = Base + Offset;
                const long Target = 0x7fff92427890;
                const long RIP = Source + InstSize;
                const uint Disp = 0x5FB2E425;
                const string RenderPattern = "{0,-12}: {1}";

                Hex.hexbytes(Encoding, out var code);

                var disp1 = AsmRel.disp32(code);
                var disp2 = asm.disp(code.View,1, NativeSizeCode.W32);
                Require.equal(disp1,disp2);
                var target = (MemoryAddress)(RIP + disp1);
                if(target == Target && disp1 == Disp)
                {
                    var dst = text.buffer();
                    dst.AppendLineFormat(RenderPattern, nameof(Asm), Asm);
                    dst.AppendLineFormat(RenderPattern, nameof(Encoding), Encoding);
                    dst.AppendLineFormat(RenderPattern, nameof(Base), (MemoryAddress)Base);
                    dst.AppendLineFormat(RenderPattern, nameof(Offset), (Address16)Offset);
                    dst.AppendLineFormat(RenderPattern, nameof(Source), (MemoryAddress)Source);
                    dst.AppendLineFormat(RenderPattern, nameof(RIP), (MemoryAddress)RIP);
                    dst.AppendLineFormat(RenderPattern, nameof(Target), (MemoryAddress)Target);
                    dst.AppendLineFormat(RenderPattern, "Disp",  disp1);

                    Write(dst.Emit(), FlairKind.StatusData);
                }
                else
                {
                    Error("Computed target did not match expected target");
                }
            }

            Check1();
            CheckAsmHexCode();
            Check3();
        }

        [Op]
        public static bit check(ref AsmSizeCheck src)
        {
            src.Actual = (ushort)Sized.width(src.Input);
            switch(src.Input.Code)
            {
                case NativeSizeCode.W8:
                    src.Expect = (ushort)Sized.native(w8).Width;
                break;
                case NativeSizeCode.W16:
                    src.Expect = (ushort)Sized.native(w16).Width;
                break;
                case NativeSizeCode.W32:
                    src.Expect = (ushort)Sized.native(w32).Width;
                break;
                case NativeSizeCode.W64:
                    src.Expect = (ushort)Sized.native(w64).Width;
                break;
                case NativeSizeCode.W128:
                    src.Expect = (ushort)Sized.native(w128).Width;
                break;
                case NativeSizeCode.W256:
                    src.Expect = (ushort)Sized.native(w256).Width;
                break;
                case NativeSizeCode.W512:
                    src.Expect = (ushort)Sized.native(w512).Width;
                break;
                case NativeSizeCode.W80:
                    src.Expect = (ushort)Sized.native(w80).Width;
                break;
            }
            return src.Passed;
        }

        void CheckAsmHexCode()
        {
            // 4080C416                add spl,22
            var buffer = span<char>(20);
            var input1 = "40 80 c4 16";
            var input2 = "4080C416";
            Hex.parse64u(input2, out var input3);

            var code1 = ApiNative.asmhex(input1);
            var code2 = ApiNative.asmhex(input2);
            var code3 = asm.asmhex(input3);

            var text1 = code1.Format();
            var text2 = code2.Format();
            var text3 = code3.Format();

            // Write(code1.Format());
            // Write(code2.Format());
            // Write(code3.Format());

            var check1 = CheckEquality(text1,text2);
            if(check1.Fail)
               Error(check1.Message);
            else
                Status(check1.Message);

            var check2 = CheckEquality(text1,text3);
            if(check2.Fail)
               Error(check2.Message);
            else
                Status(check2.Message);            
        }

        static Outcome CheckEquality(string a, string b)
        {
            var same = a.Equals(b);
            return (same, string.Format("{0} {1} {2}", a, same ? "==" : "!=", b));
        }
    }
}