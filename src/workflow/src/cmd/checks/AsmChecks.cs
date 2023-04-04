//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static sys;
    using static AsmPrefixCodes;
    using static AsmRegTokens;

    using gp32 = AsmRegTokens.Gp32Reg;

    class AsmChecks : WfAppCmd<AsmChecks>
    {
        AsmRegSets Regs => Service(AsmRegSets.create);

        [CmdOp("asm/regs/query")]
        Outcome RegQuery(CmdArgs args)
        {
            var selected = list<RegNameSet>();
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                for(var i=0; i<args.Count; i++)
                {
                    var pred = arg(args,i).Value;
                    result = DataParser.eparse(pred, out RegClassCode @class);
                    if(result.Fail)
                        return result;

                    var names = Regs.RegNames(@class);
                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }
            else
            {
                selected.Add(Regs.Gp8RegNames());
                selected.Add(Regs.Gp16RegNames());
                selected.Add(Regs.Gp32RegNames());
                selected.Add(Regs.Gp64RegNames());
                selected.Add(Regs.XmmRegNames());
                selected.Add(Regs.YmmRegNames());
                selected.Add(Regs.ZmmRegNames());
                selected.Add(Regs.MaskRegNames());
                selected.Add(Regs.MmxRegNames());
                selected.Add(Regs.SegRegNames());
                selected.Add(Regs.CrRegNames());
                selected.Add(Regs.DbRegNames());
                selected.Add(Regs.FpuRegNames());
            }

            var buffer = text.buffer();
            iter(selected, reg => buffer.AppendLine(string.Format("{0}:[{1}]", reg.Name, reg.Format())));
            Write(buffer.Emit());

            return result;
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
            var items = vgcpu.vinc<byte>(w, 64);
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

        [CmdOp("asm/check/jcc")]
        Outcome CheckJcc()
        {
            var @case = AsmCaseAssets.create().Branches();
            Utf8.decode(@case.ResBytes, out var doc);

            using var buffers = CompositeBuffers.create();
            var parser = DecodedAsmParser.create(buffers.Composite());
            var result = parser.ParseBlocks(doc);
            var blocks = parser.Parsed();
            iter(blocks, block => {
                iter(block.Code, code => Channel.Row(code.Decoded));
            });
            return result;
        }

        [CmdOp("asm/check/cases")]
        Outcome EmitAsmCases(CmdArgs args)
        {
            var src = AsmCases.mov();
            TableEmit(src, AppDb.ApiTargets().Table<AsmEncodingCase>());
            return true;
        }


        [CmdOp("asm/check/bitfields")]
        void CheckBitFields()
        {
            var storage = ByteBlock32.Empty;
            var buffer = storage.Bytes;
            byte segwidth = 8;
            ReadOnlySpan<byte> indices = new byte[]{3,33,59,61,101,203};
            gbits.enable(buffer, indices);
            var segcount = buffer.Length;
            for(var i=z8; i<segcount; i++)
            {
                ref readonly var cell = ref skip(buffer,i);
                var offset = (byte)(i*segwidth);
                if(cell != 0)
                {
                    var seg = BitfieldSeg.define(cell, offset, segwidth);
                    Write(seg.Format());
                }
            }            
        }


        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }

        [CmdOp("asm/check/arrays")]
        unsafe void CheckMdArrays(CmdArgs args)
        {
            var m = 0xF;
            var n = 0xA;
            var data = new ulong[m,n];
            for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                data[i,j] = (ulong)(i*j);


            fixed(ulong* pSrc = data)
            {
                MemoryAddress @base = pSrc;
                var pCurrent = pSrc;
                for(var i=0; i<m; i++)
                {
                    for(var j=0; j<n; j++)
                    {
                        MemoryAddress loc = pCurrent;
                        var a = *pCurrent++;
                        Require.equal(a, (ulong)(i*j));
                        Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, a));
                    }
                }
            }

            var dst = Unsafe.As<TableInfo>(data);
            Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));
        }


        [CmdOp("asm/check/blocks")]
        Outcome CheckBlockSize(CmdArgs args)
        {
            CheckTrimmedBlocks();
            CheckBlockPartitions();
            return true;
        }

        void CheckTrimmedBlocks()
        {
            var output = EmptyString;
            var input = ByteBlock4.Empty;

            input = 0xFF000000;
            output = TrimmedBlocks.trim(input).Format();

            input = 0xFF0000;
            output = TrimmedBlocks.trim(input).Format();

            input = 0xFF00;
            output = TrimmedBlocks.trim(input).Format();

            input = 0xFF;
            output = TrimmedBlocks.trim(input).Format();

            input = 0x0;
            output = TrimmedBlocks.trim(input).Format();
        }

        void CheckBlockPartitions()
        {
            var formatter = CsvTables.formatter<BlockPartition>();
            Write(formatter.FormatHeader());
            Write(formatter.Format(BlockPartition.calc(1024, 256, 11)));
            Write(formatter.Format(BlockPartition.calc(9591191, 256, 128)));
        }

        [CmdOp("asm/check/jmp")]
        void CheckJumps()
        {
            CheckJmp32(n0);
            CheckJmp32(n1);
            CheckJmp32(n2);
        }

        [CmdOp("asm/check/specs")]
        void CheckAsmSpecs()
        {
            const string Oc0 = "81 /4 id";
            const string Oc1 = "REX.W + 05 id";

            var asm0 = AsmSpecs.and(gp32.edx, 0xC1C1);
            Channel.Write($"{asm0}");

            var opcode = SdmOpCode.Empty;
            var result = SdmOpCodes.parse(Oc0, out opcode);
            Channel.Write($"{Oc0} -> {opcode}");
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
            var code1 = asm.asmhex("e9 58 10 00 00");

            if(!code0.Equals(code1))
                Channel.Error(string.Format("{0} != {1}", code1, code0));

            var label1 = 0x0065;
            var ip1 = @base + label1;
            var dx1 = AsmRel.disp32((ip1,sz), @return);
            var actual1 = JmpRel32.encode((ip1,sz), @return);
            var expect1 = asm.asmhex("e9 4d 10 00 00");
            if(!actual1.Equals(expect1))
                Channel.Error(string.Format("{0} != {1}", expect1, actual1));

            var label2 = 0x0070;
            var ip2 = @base + label2;
            var dx2 = AsmRel.disp32((ip2,sz), @return);
            var actual2 = JmpRel32.encode((ip2,sz), @return);
            var expect2 = asm.asmhex("e9 42 10 00 00");
            if(!actual2.Equals(expect2))
                Channel.Error(string.Format("{0} != {1}", expect2, actual2));

            var label3 = 0x007b;
            var ip3 = @base + label3;
            var dx3 = AsmRel.disp32((ip3,sz), @return);
            var actual3 = JmpRel32.encode((ip3,sz), @return);
            var expect3 = asm.asmhex("e9 37 10 00 00");
            if(!actual3.Equals(expect3))
                Channel.Error(string.Format("{0} != {1}", expect3, actual3));
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
                Channel.Error(string.Format("Encoding mismatch '{0}' != '{1}'", enc1, enc2));

            var box = new RipBox(Base, uint.MaxValue);
            if(!box.IP(Source))
                Error("Ip out of range");

            box.Advance(InstSize, dx, out var target1);

            if(target1 != Target)
                Channel.Error("Computed target did not match expected target");

            var target2 = AsmRel.target(rip, enc1);
            if(target2 != Target)
                Channel.Error("Computed target did not match expected target");
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
                Channel.Write(statement);
            }
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
            Channel.Write(Require.equal(Data,output));
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
                Channel.Write(r.Format());
            }
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
            Channel.Write(sz8);
            Channel.Write(sz16);
            Channel.Write(sz32);
            Channel.Write(sz64);

            return (result, result ? "Pass" : "Fail");
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
                Channel.Write(call.Format());
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

                    Channel.Write(dst.Emit(), FlairKind.StatusData);
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

        void CheckAsmHexCode()
        {
            // 4080C416                add spl,22
            var buffer = span<char>(20);
            var input1 = "40 80 c4 16";
            var input2 = "4080C416";
            Hex.parse64u(input2, out var input3);

            var code1 = asm.asmhex(input1);
            var code2 = asm.asmhex(input2);
            var code3 = asm.asmhex(input3);

            var text1 = code1.Format();
            var text2 = code2.Format();
            var text3 = code3.Format();

            // Write(code1.Format());
            // Write(code2.Format());
            // Write(code3.Format());

            var check1 = CheckEquality(text1,text2);
            if(check1.Fail)
               Channel.Error(check1.Message);
            else
                Channel.Status(check1.Message);

            var check2 = CheckEquality(text1,text3);
            if(check2.Fail)
               Channel.Error(check2.Message);
            else
                Channel.Status(check2.Message);            
        }

        static Outcome CheckEquality(string a, string b)
        {
            var same = a.Equals(b);
            return (same, string.Format("{0} {1} {2}", a, same ? "==" : "!=", b));
        }

        [CmdOp("asm/check/vex")]
        Outcome Vex(CmdArgs args)
        {
            var segments = VexPrefixC4.segments();

            var vp0 = VexPrefixC4.define(byte.MaxValue, byte.MaxValue);
            Channel.Write(vp0.FormatSemantic());
            segments.Fill(vp0);
            Channel.Write(segments.ToBitstring());

            var vp1 = VexPrefixC4.init(VexRXB.L0_V0F38, VexM.x0F3A, bit.On, 0b1111, VexLengthCode.L1, VexOpCodeExtension.F3);
            Channel.Write(vp1.FormatSemantic());
            segments.Fill(vp1);
            Channel.Write(segments.ToBitstring());

            var vp2 = VexPrefixC4.define(0xe3, 0x69);
            Channel.Write(vp2.FormatSemantic());
            segments.Fill(vp2);
            Channel.Write(segments.ToBitstring());

            return true;
        }

        [CmdOp("asm/check/flags")]
        Outcome CheckAsmFlags(CmdArgs args)
        {
            var result = Outcome.Success;
            var flags = new StatusFlags();
            flags.OF(true);
            flags.SF(true);
            Channel.Write(flags.Format());
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

        [CmdOp("asm/stubs/check")]
        void CheckStubDispatch()
        {
            // var dispatcher = new X86Dispatcher(12);
            // dispatcher.Create<ulong>(0);
            // var encoded = dispatcher.Encode(0);
            // Write(encoded.FormatHexData());
        }

        [CmdOp("asm/check/exec")]
        void CheckCodeExec()
        {
            AsmCheckExec.run(Emitter);        
        }

        [CmdOp("asm/check/regs")]
        void CheckRegstore()
        {
            var grid = RegGrid8x64.Empty;
            var regs = RegStore8x64.Empty;
            var names = recover<AsmRegName>(ByteBlock64.Empty.Bytes);
            var pairs = recover<AsmRegValue<ulong>>(ByteBlock128.Empty.Bytes);

            for(byte i=0; i<7; i++)
            {
                regs[i] = i;
                seek(names,i) = RegClasses.KReg.RegName((RegIndexCode)i);
                grid[i] = asm.regval(skip(names,i), regs[i]);
            }

            for(byte i=0; i<7; i++)
            {
                ref readonly var name = ref skip(names,i);
                ref readonly var value = ref regs[i];
                var output = grid[i].Format();
                Channel.Row(output);
            }

            var input = (ulong)PermLits.Perm16Identity;
            for(byte i=0; i<7; i++)
            {
                regs[i] = input << i*3;
                Channel.Row(asm.regval(skip(names,i), regs[i]));
            }           
        }

        [CmdOp("parsers/check")]
        void CheckParsers()
        {
            CheckDigitParsers();
        }

        void CheckDigitParsers()
        {
            var input = "01001101";
            // var count = Digital.parse(input, out GBlock64<BinaryDigit> dst);
            // var digits = dst.Segment(0,count);
            // var parsed = Digital.format(digits);
            //Write(Demand.eq(input,parsed));
            CheckDigitParser(base2);
            CheckDigitParser(base10);
            CheckDigitParser(base16);
        }

        void CheckDigitParser(Base10 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("346610");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }

        void CheckDigitParser(Base16 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("FA34CA");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }

        void CheckDigitParser(Base2 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("11001101");
            var buffer = CharBlock32.Null;
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }        


        [CmdOp("asm/gen/regnames")]
        Outcome EmitRegNames(CmdArgs args)
        {
            var dst = text.emitter();
            var input = AsmRegData.gp();
            var count = input.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i != 0 && i%4 == 0)
                    buffer.AppendLine();
                buffer.AppendFormat("{0,-6}", skip(input,i));
            }

            var data = recover<byte>(span(buffer.Emit()));
            var spec = ByteSpans.specify("GpRegNames", data.ToArray());
            var format = SpanResFormatter.format(spec);
            Channel.FileEmit(format, count, AppDb.CgStage().Path("regnames", FileKind.Cs));

            return true;
        }

    }
}